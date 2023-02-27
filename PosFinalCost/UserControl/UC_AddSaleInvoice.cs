using PosFinalCost.Classe;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.ExpressionEditor;
using System.Data.Entity;
using static PosFinalCost.Session;
using System.Transactions;
//using DevExpress.XtraReports.Design;

namespace PosFinalCost.Forms
{
    public partial class UC_AddSaleInvoice : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        //List<ClsProductQuantList> tbPrdQuanList;
        //List<ClsProductQuantList> tbPrdQuanListOld;
        List<SupplySub> tbSupplySubListOld;
        SupplyMain supplyMainOld;
        ProductData productData = new ProductData();
        ProductQunatity tbPrdQuantiy;
        Customer tbCustomer;
        FormSearchProduct FormDialogPrdSearch;
        FlyoutDialog flyDialogOrders;
        IDictionary<int, double> listPrdQuantDic;
        IDictionary<int, double?> listPrdPriceDic;
        IDictionary<int, string> listPrdMsurName;
        IDictionary<int, double> listPrdQuanAvlbDic;
        MediaPlayer barcodeBeep;
        Uri barcodeBeepUri;
        Timer ecrTimer = new Timer();
        double tax;
        private readonly SupplyType supplyType;
        private bool gridValid = true;
        public bool isNew;
        private double MinSalePrice;
        public SimpleButton btnSetCashInvoice = new SimpleButton();
        public UC_AddSaleInvoice(SupplyMain obj, IEnumerable<SupplySub> subObj, SupplyType supplyType)
        {
            this.supplyType = supplyType;
            InitializeComponent();
            new ClsUserRoleValidation(this, UserControls.Sale);
            this.Load += UC_AddSaleInvoice_Load;
            InitDefaultData();
            InitForm();
            InitData(obj, subObj);
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.listPrdQuantDic = new Dictionary<int, double>();
            GetResources();
            InitEvents();
            btnSetCashInvoice.Click += BtnSetCashInvoice_Click;
            ClsPath.ReLodeCustomContol(this.dataLayConMain, this.Name + this.supplyType);
            ClsPath.ReLodeCustomContol(this.gridView, this.Name + this.supplyType);
        }
        private void BtnSetCashInvoice_Click(object sender, EventArgs e)
        {
            var SupplyMain = GetCurSupplyMain();
            if (SupplyMain != null)
            {
                var formSetCashInvoice = new FormSetCashInvoice { Net = decimal.Parse(spinEditTotalFinalDecimal.Text) };
                formSetCashInvoice.ShowDialog();
                if (formSetCashInvoice.UnPaid >= 0)
                    SupplyMain.paidCash = Convert.ToDouble(formSetCashInvoice.Paid - formSetCashInvoice.UnPaid);
                else
                    SupplyMain.paidCash = Convert.ToDouble(formSetCashInvoice.Paid);
                if (!formSetCashInvoice.IsEscape)
                    BbiSaveAndNew_Click(null, null);
            }
        }
        #region Events
        private void UC_AddSaleInvoice_Load(object sender, EventArgs e)
        {
            Task.Run(() => InitFlyDialogPrdSrch());
            InitBarcodeBeep();
            layoutControlGrooupMain.Expanded = (supplyType == SupplyType.Sales) ? Program.My_Setting.supplySaleExpanded : layoutControlGrooupMain.Expanded;
            layoutControlCarData.Visibility = Session.CurrSettings.ShowlayoutControlCarData ? LayoutVisibility.Always : LayoutVisibility.Never;
            textEditBarcodeNo.Focus();
            layoutControlGrooupMain.BestFit();

            SetSettingSales();
            var Su = SupplyMainBindingSource.Current as SupplyMain;
            InitPrdBindingSourceData((Su?.StrId as short?) ?? 0);
            Task.Run(() => SetFont());
        }
        private void RepositoryItemBtnBarcode_Click(object sender, EventArgs e)
        {
            if (gridView.GetRowCellValue(gridView.FocusedRowHandle, "PrdBarcode") != null)
            {
                formBarcode frm = new formBarcode();
                frm.Show();
                frm.SearchProduct(gridView.GetRowCellValue(gridView.FocusedRowHandle, "PrdBarcode").ToString());
            }
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void SetFont()
        {
            this.Invoke(new MethodInvoker(delegate {
                if (Program.My_Setting.SystemFontSale == Program.My_Setting.SystemFont) return;
                Font fontConverter = (Font)converter.ConvertFromString(Program.My_Setting.SystemFontSale);
                this.layoutControlGrooupMain.AppearanceItemCaption.Font = fontConverter;
                dataLayConMain.Items.Where(x => x is LayoutControlItem).ToList().ForEach(y =>
                ((LayoutControlItem)y).Owner.Appearance.Control.Font = fontConverter);
                bindingNavigator11.Font = fontConverter;
                repositoryItemSearchLookUpEditPrdNo.View.Appearance.Row.Font =
                repositoryItemSearchLookUpEditPrdNo.View.Appearance.HeaderPanel.Font =
                    repositoryItemLookUpEditMeasurment.AppearanceDropDownHeader.Font =
                repositoryItemLookUpEditMeasurment.AppearanceDropDown.Font = fontConverter;
                gridView.Appearance.HeaderPanel.Font = gridView.Appearance.Row.Font = gridView.Appearance.FooterPanel.Font = fontConverter;
            }));
            
        }
        private void SetSettingSales()
        {
                btnEditPrice.Visible = btnEditPrice.Visible ? Session.CurrSettings.CanChangeItemPriceInSales : btnEditPrice.Visible;
                colsupSalePrice.OptionsColumn.AllowEdit = Session.CurrSettings.CanChangeItemPriceInSales;
                btnEditQuantity.Visible = btnEditQuantity.Visible ? Session.CurrSettings.CanChangeQtyInSales : btnEditQuantity.Visible;
                colQuanMain.OptionsColumn.AllowEdit = Session.CurrSettings.CanChangeQtyInSales;
                DateDateEdit.ReadOnly = !Session.CurrSettings.CanChangeSalesInvoiceDate;
                radioGroupIsCash.ReadOnly = !Session.CurrSettings.CanChangePayMethod;
        }
        private void InitEvents()
        {
            dataLayConMain.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;
            radioGroupIsCash.EditValueChanged += RadioGroupIsCash_EditValueChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.RowUpdated += GridView_RowUpdated;
            gridView.RowCountChanged += GridView_RowCountChanged;
            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.CellValueChanged += GridView_CellValueChanged;
            gridView.FocusedColumnChanged += GridView_FocusedColumnChanged;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.CustomRowCellEditForEditing += GridView_CustomRowCellEditForEditing;
            gridView.RowStyle += GridView_RowStyle;
            gridView.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView.HideCustomizationForm += GridView_HideCustomizationForm;
            dataLayConMain.ShowCustomization += DataLayoutControl1_ShowCustomization;
            dataLayConMain.HideCustomization += DataLayoutControl1_HideCustomization;
            gridView.ValidatingEditor += GridView_ValidatingEditor;
            gridView.InvalidRowException += GridView_InvalidRowException;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            StrIdLookUpEdit.EditValueChanged += StrIdLookUpEdit_EditValueChanged;
            repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            //checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
            repositoryItemBtnBarcode.Click += RepositoryItemBtnBarcode_Click;
            checkEditTax.EditValueChanging += CheckEditTax_EditValueChanging;
            supCurrTextEdit.EditValueChanged += SupCurrTextEdit_EditValueChanged;
            supDscntPercentTextEdit.EditValueChanging += DscntAmountTextEdit_EditValueChanging;
            DscntAmountTextEdit.EditValueChanging += DscntAmountTextEdit_EditValueChanging;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
            ecrTimer.Tick += EcrTimer_Tick;
            BoxNoLookUpEdit.EditValueChanged += BoxNoLookUpEdit_EditValueChanged;
            BankLookUpEdit.EditValueChanged += BankLookUpEdit_EditValueChanged;
            CustNoSearchLookUpEdit.EditValueChanged += CustNoSearchLookUpEdit_EditValueChanged;

            btnClose.Click += BbiClose_Click;
            btnEditPrice.Click += BbiEditPrice_Click;
            btnEditQuantity.Click += BbiEditQuantity_Click;
            btnPrdPrice.Click += BbiPrdPrice_Click;
            //bbiPrint.Click += BbiPrint_Click;
            btnPrintPrevious.Click += BbiPrintPrevious_Click;
            btnPdfPrevious.Click += BbiPrintPrevious_Click;
            btnXslPrevious.Click += BbiPrintPrevious_Click;
            btnReset.Click += btnReset_Click;
            btnSave.Click += BbiSave_Click;
            btnSaveAndNew.Click += BbiSaveAndNew_Click;
            btnSaveAndNewNoPrint.Click += bbiSaveAndNewNoPrint_Click;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            //bbiUpdateInvoice.Click += BbiUpdateInvoice_Click;
            btnPaidCreditShortcut.Click += bsiPaidCreditShortcut_Click;
            saleNoTextEdit.EditValueChanged += SaleNoTextEdit_EditValueChanged;
            textEditPaidCash.EditValueChanging += TextEditPaidCash_EditValueChanging;
            textEditPaidCreditCard.EditValueChanging += TextEditPaidCash_EditValueChanging;
           
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == colStatus.FieldName && !string.IsNullOrEmpty(e?.Value.ToString()))
                e.DisplayText = ClsSupplyStatus.GetString(Convert.ToByte(e?.Value), (byte)gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, colIsCash));
            //else if (e.Column.FieldName == "supCustSplId" && e.Value is int cus)
            //{
            //        Customer tblCustomer = Session.Customers.FirstOrDefault(x => x.id == cus);
            //        if (tblCustomer == null) return;
            //        e.DisplayText = tblCustomer?.custNo + " - " + tblCustomer?.custName;
            //}
        }
        private void TextEditPaidCash_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SupplyMain sale = GetCurSupplyMain();
            if (sale == null) return;
            if (sale.Net< Convert.ToDouble(e.NewValue))
            {
                e.NewValue = sale.Net;
                e.Cancel = true;
            }
                
            if (((BaseEdit)sender).Name== textEditPaidCreditCard.Name)
            {
                sale.BankAmount = Convert.ToDouble(e.NewValue);
                CalculatePaid(sale);
                
            }
            else
            {
                sale.paidCash = Convert.ToDouble(e.NewValue);
                sale.BankAmount = sale.Net - sale.paidCash;
            }
            IsCash();
        }

        private void SaleNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            var tbSupplyMain = GetCurSupplyMain();
            SupplyMain sale = myFunaction.GetCopyFromSupplyMain((SupplyMain)editor.GetSelectedDataRow());
            tbSupplyMain.No = sale.No;
            tbSupplyMain.ID = sale.ID;
            tbSupplyMain.StrId = sale.StrId;
            tbSupplyMain.IsCash = sale.IsCash;
            tbSupplyMain.CustId = sale.CustId;
            tbSupplySubListOld = null;
            checkEditTax.Checked = (tbSupplyMain.TaxPrice > 0) ? true : false;
            GetSupplySubData(tbSupplyMain);
            textEditBarcodeNo.Enabled = true;
        }
        private void GetSupplySubData(SupplyMain tbSupplyMain)
        {
            using (PosDBDataContext posDB = new PosDBDataContext(Program.ConnectionString))
            {
                var lis = posDB.SupplyMains.AsQueryable().Where(x => x.No == tbSupplyMain.No && (x.Status == 11 || x.Status == 12)
              && x.Date >= Session.CurrentYear.DateStart && x.Date <= Session.CurrentYear.DateEnd).ToList();
                IEnumerable<SupplySub> tbSupSubList = posDB.SupplySubs.AsQueryable().Where(x => x.ParentID == tbSupplyMain.ID);
                if (lis.Count() > 0)
                {
                    List<SupplySub> AllSupListInRet = new List<SupplySub>();
                    List<SupplySub> AllSupListNotInRet = new List<SupplySub>();
                    foreach (var item in lis)
                        AllSupListInRet.AddRange(posDB.SupplySubs.Where(x => x.ParentID == item.ID && x.BrnId == Session.CurrentBranch.ID).ToList());
                    foreach (var item1 in tbSupSubList)
                    {
                        double SumQ1 = AllSupListInRet.Where(x => x.Msur == item1.Msur).Sum(x => x.QuanMain);
                        double SumQ2 = tbSupSubList.Where(x => x.Msur == item1.Msur).Sum(x => x.QuanMain);
                        if (SumQ1 < SumQ2 && !AllSupListNotInRet.Any(x => x.Msur == item1.Msur))
                        {
                            SupplySub temp = myFunaction.GetCopyForObjectSupplySub(item1);
                            temp.QuanMain = SumQ2 - SumQ1;
                            AllSupListNotInRet.Add(temp);
                        }
                    }
                    if (AllSupListNotInRet.Count() <= 0)
                    {
                        MessGSalesRetQuantity("لقد تم ارجاع كل الكميات لهذه الفاتورة\n بفواتير مردود سابقه ولا يمكن اضافة مرتجع مرة \nاخرى لهذه الفاتورة ");
                        saleNoTextEdit.EditValue = null;
                        supNoTextEdit.EditValue = null;
                        return;
                    }
                    else
                    {
                        MessGSalesRetQuantity("يوجد فاتورة مرتجعه من قبل لفاتورة البيع المحددة\n سوف يتم عرض الاصناف والكميات التي لم يتم ارجاعها في \nفواتير المردودات السابقه");
                        tbSupSubList = AllSupListNotInRet;
                    }
                }
                this.tbSupplySubListOld = myFunaction.GetCopyFromSupplySub(tbSupSubList.ToList());
                if (tbSupSubList.Count() > 0)
                    SupplySubBindingSource.DataSource = tbSupSubList;
            }
        }

        public bool FunClose() => (XtraMessageBox.Show(_resource.GetString("CloseFormMssg"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes);
        private void BbiClose_Click(object sender, EventArgs e)
        {
            if (!FunClose()) return;
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.supplyType);
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name + this.supplyType);
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
                (this.Parent as XtraTabPage).Dispose();
            else
                this.ParentForm.Close();
        }

        private void BbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;
            SupplyMain tbSupplyMain = GetCurSupplyMain();
            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), tbSupplyMain.No);
            Form temp = this.ParentForm;
            //ShowPrintInvoice();
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
            {
                (this.Parent as XtraTabPage).Dispose();
                flyDialog.ShowDialogForm(temp, mssg, this.isNew);
            }
            else
            {
                this.ParentForm.Close();
                flyDialog.ShowDialogForm(((FormEntryMain)temp).parent1, mssg, this.isNew);
            }
          
        }
        private void BbiSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Session.CurrSettings.ShowResetMssg)
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }

        //private void BbiPrint_Click(object sender, EventArgs e)
        //{
        //    flyDialog.WaitForm(this, 1);
        //    //var supplyMain = db.SupplyMains.AsQueryable().Where(a => (a.Status == 4 || a.Status == 8 || a.Status == 11 || a.Status == 12)
        //    //   && a.BrnId == Session.CurrentBranch.ID&&a.supNo== noId).ToList().FirstOrDefault();
        //    //if (supplyMain != null)
        //    //{
        //    //    var tbSupplySubList = db.SupplySubs.AsQueryable().Where(x => x.BrnId == Session.CurrentBranch.ID && x.supNo == supplyMain.ID).ToList();
        //    //    ClsStopWatch stopWatch2 = new ClsStopWatch();
        //    //    log.Debug("PrintReportClsPrintReportStart");
        //    //    flyDialog.WaitForm(this, 0);
        //    //    Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
        //    //    log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
        //    //    return;
        //    //}
        //    flyDialog.WaitForm(this, 0);
        //}

        private void BbiPrintPrevious_Click(object sender, EventArgs e)
        {
            if (((ToolStripButton)sender).Name == btnPrintPrevious.Name)
                ShowPrintInvoice(true, PrintFileType.Printer);
           else if (((ToolStripButton)sender).Name == btnPdfPrevious.Name)
                ShowPrintInvoice(true, PrintFileType.PDF);
            else if (((ToolStripButton)sender).Name== btnXslPrevious.Name)
            ShowPrintInvoice(true,PrintFileType.Xlsx);
        }
        private void bbiSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (bbiSelect.Checked && gridView.SelectedRowsCount < 1)
            {
                XtraMessageBox.Show(_resource.GetString("saleRtrnMarkErrMssg"));
                gridView.OptionsSelection.MultiSelect = true;
                bbiSelect.Checked = false;
                return;
            }
            else if (bbiSelect.Checked && gridView.SelectedRowsCount >= 1)
            {
                List<SupplySub> tbSupplySubList = new List<SupplySub>();
                for (short i = 0; i < gridView.SelectedRowsCount; i++)
                    tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as SupplySub);
                SupplySubBindingSource.DataSource = tbSupplySubList;
                gridView.OptionsBehavior.Editable = true;
                foreach (GridColumn item in gridView.Columns)
                {
                    if (item != colQuanMain)
                        DisableGridColumns(item);
                }
                gridView.OptionsSelection.MultiSelect = false;
            }
            else if (!bbiSelect.Checked && this.tbSupplySubListOld != null)
            {
                SupplySubBindingSource.DataSource = myFunaction.GetCopyFromSupplySub(this.tbSupplySubListOld.ToList());
                gridView.OptionsSelection.MultiSelect = true;
            }
            else
                gridView.OptionsSelection.MultiSelect = true;
        }
       
        private void BbiPrdPrice_Click(object sender, EventArgs e)
        {
            if (gridView.DataRowCount <= 0) return;
            string proName = Session.Products.Where(x => x.ID == ((gridView.GetFocusedRowCellValue(colsupPrdName) as int?)??0)).Select(x => x.Name).FirstOrDefault();
            XtraMessageBox.Show($"{_resource.GetString("PrdPrice")} {proName} {gridView.GetFocusedRowCellValue(colsupPrice)}");
        }

        private void BbiEditPrice_Click(object sender, EventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDecimal(gridView.GetFocusedRowCellValue(colsupSalePrice))).ShowDialog();
        }

        private void BbiEditQuantity_Click(object sender, EventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain))).ShowDialog();
        }

        private void bsiPaidCreditShortcut_Click(object sender, EventArgs e)
        {
          textEditPaidCreditCard.Focus();
          SetECRamout();
            if (!Session.CurrSettings.isSendToECR) return;
          SendECR();
        }

        private void bbiSaveAndNewNoPrint_Click(object sender, EventArgs e)
        {
            SaveAndNew(false);
        }
        private void GridView_RowCountChanged(object sender, EventArgs e)
        {
            labelItemsCount.Text = $"عدد الاصناف :{SupplySubBindingSource.Count}";
            GridView_RowUpdated(sender, null);
        }

        private void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (SupplyMainBindingSource.Current != null)
            {
                SupplyMain sale = GetCurSupplyMain();
                var items = SupplySubBindingSource.List as IList<SupplySub>;
                if (items == null) return;
                if (items.Count() > 0)
                {
                    sale.Total = items.Sum(x => x.QuanMain * x.SalePrice);
                    sale.DscntAmount = items.Sum(x => x.DscntAmount);
                    sale.TaxPrice = items.Sum(x => x.TaxPrice);
                    sale.TaxPercent = (byte)items.Max(x => x.TaxPercent);
                    sale.TotalAfterDiscount = (sale.Total - sale.DscntAmount);
                    sale.Net = (sale.TotalAfterDiscount + sale.TaxPrice);
                    CalculatePaid(sale);
                }
            }
        }
        private void CalculatePaid(SupplyMain sale)
        {
                    //if (sale.IsCash == 3)
                    //{
                    //    sale.BankAmount = sale.Net.GetValueOrDefault();
                    //    sale.paidCash = 0;
                    //}
                    //else 
                    if (sale.IsCash == 1)
                        sale.paidCash = sale.Net- sale.BankAmount;
                    else
                        sale.BankAmount =sale.paidCash = 0;
            sale.TotalPaid = sale.BankAmount + sale.paidCash;
            sale.Remin = sale.Net - sale.TotalPaid;
        }
        private void BoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain();
            tbSupplyMain.BoxId = Convert.ToInt16(editor.GetColumnValue("ID"));
            tbSupplyMain.Currency = Convert.ToByte(editor.GetColumnValue("Currencie"));
        }
        private void BankLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain();
            tbSupplyMain.BankId = Convert.ToInt16(editor.GetColumnValue("ID"));
            tbSupplyMain.Currency = Convert.ToByte(editor.GetColumnValue("Currencie"));
        }
        private void CustNoSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = GetCurSupplyMain();
            if (tbSupplyMain == null) return;
            if (tbSupplyMain.IsCash != 2) return;
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            if (searchLookUpEdit1View.GetFocusedRowCellValue("ID") == null)
                return;
            tbSupplyMain.CustId = Convert.ToInt32(searchLookUpEdit1View.GetFocusedRowCellValue("ID"));
            tbSupplyMain.Currency = Convert.ToByte(searchLookUpEdit1View.GetFocusedRowCellValue("Currency"));
            this.tbCustomer = tbSupplyMain.CustId != null ? Session.Customers.FirstOrDefault(x => x.ID == tbSupplyMain.CustId) : null;
        }
        private void StrIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            InitPrdBindingSourceData((StrIdLookUpEdit.EditValue as short?) ?? 0);
        }
        SupplyMain GetCurSupplyMain()=> SupplyMainBindingSource.Current as SupplyMain;
        private void RadioGroupIsCash_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = GetCurSupplyMain();
            if(tbSupplyMain == null|| ((radioGroupIsCash.EditValue as byte?) ?? 0)==0) return;
            tbSupplyMain.IsCash = (radioGroupIsCash.EditValue as byte?) ?? 0;
            IsCash();
            ItemFornotDate.Enabled = tbSupplyMain.IsCash == 2 ? true : false;
            CalculatePaid(tbSupplyMain);
            //ItemFornotDate.Visibility = (tbSupplyMain.IsCash == 2 && !Session.CurrSettings.PayPartInvoValue) ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle >= 0 && this.productData?.Product != null)
            //    PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == this.productData.Product.ID);

            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.Product == null || !isNew || p != productData?.Product?.ID)
                GetData(null, p);
            if (e.FocusedRowHandle >= 0)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == p).ToList();
        }
        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain();
            if (tbSupplyMain != null)
            {
                if (tbSupplyMain.Currency > 1)
                {
                    tbSupplyMain.Currency = Convert.ToByte(editor.GetColumnValue("ID"));
                    tbSupplyMain.CurrencyChng = Convert.ToInt16(editor.GetColumnValue("Change"));
                    CurrencyChngTextEdit.EditValue = editor.GetColumnValue("Change");
                    ItemForCurrencyChng.Enabled =true;
                }
                else
                {
                    tbSupplyMain.CurrencyChng = null;
                    CurrencyChngTextEdit.EditValue = null;
                    ItemForCurrencyChng.Enabled = false;
                }
            }
        }
        private void DscntAmountTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SupplyMain supplyMain = GetCurSupplyMain();
            if (supplyMain == null)
            {
                e.Cancel = true;
                return;
            }
            bool per = ((BaseEdit)sender).Name == "DscntAmountTextEdit";
            var val = double.Parse(e.NewValue.ToString());
            double presentValue = per ? ((val / supplyMain.Total) * 100) : val;
            double MaxDis = (Session.CurrSettings.MaxDiscountInInvoice * 100);
            if (Session.CurrentUser.ID != 1)
            {
                if (MaxDis <= 0)
                {
                    ClsXtraMssgBox.ShowError($"عذراً ليس لديك صلاحية الخصم!");
                    e.Cancel = true;
                    return;
                }
                else if (MaxDis < val)
                {
                    e.NewValue = 0; val = 0;
                    e.Cancel = true;
                    ClsXtraMssgBox.ShowError("عذراً لقد تجاوزت الحد المسموح للخصم!");
                }
            }
            if (per)
            {
                supplyMain.DscntPercent = ((val / supplyMain.Total) * 100);
                supplyMain.DscntAmount = val;
            }
            else
            {
                supplyMain.DscntPercent = val;
                supplyMain.DscntAmount = supplyMain.Total * (val / 100);
            }
            var curList = (SupplySubBindingSource.List as IList<SupplySub>);
            foreach (var item in curList)
            {
                item.DscntPercent = (supplyMain.DscntPercent as double?) ?? 0;
                CalculateAllInGridViewRow(item);
            }
        }
        private void DataLayoutControl1_HideCustomization(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name + this.supplyType);
            dataLayConMain.AllowCustomization = false;
        }
        private void DataLayoutControl1_ShowCustomization(object sender, EventArgs e)
        {
            ((DataLayoutControl)sender).CustomizationForm.Text = "تغيير التصميم";
        }
       
        #endregion
        #region Function
        private void InitDefaultData()
        {
            StrIdLookUpEdit.IntializeData(Session.Stores);
            StrIdLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeStore;
            customerBindingSource.DataSource=MyTools.GetTablName(Session.Customers);
            CustNoSearchLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeCustomer;
            BoxNoLookUpEdit.IntializeData(Session.Boxes);
            BoxNoLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeBox;
            BankLookUpEdit.IntializeData(Session.Banks);
            BankLookUpEdit.ReadOnly = !Session.CurrSettings.CanChangeBank;
            supCurrTextEdit.IntializeData(Session.Currencies);
            this.tax = Session.CurrSettings.taxDefault*100;
            checkEditTax.Checked = Session.CurrSettings.EnableTax;
            checkEdit1.Checked = Session.CurrSettings.IsInvoiceRound;
        }
        private void InitData(SupplyMain obj, IEnumerable<SupplySub> subObj)
        {
            this.isNew = obj == null;
            if (obj == null)
            {
                InitSupplyMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
            }
            else
            {
                checkEditTax.Checked = (obj.TaxPrice > 0) ? true : false;
                //IsCash();
                SupplyMainBindingSource.DataSource = obj;
                SupplySubBindingSource.DataSource = subObj;
                DisableItems();
                SetRibbonButtonsVisisbility();
                SetGridProperties();
                //this.tbPrdQuanListOld = GetPrdQuanList(subObj.ToList());
                EnabledORDisabledUpdate(false);
            }
        }
        public void EnabledORDisabledUpdate(bool Enabled)
        {
            dataLayConMain.OptionsView.IsReadOnly = Enabled?DevExpress.Utils.DefaultBoolean.False:DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.ReadOnly = !Enabled;
            bindingNavigator11.Enabled = gridView.OptionsBehavior.Editable
                = btnDeleteRow.Enabled = BtnAddFraction.Enabled = BtnDscnFraction.Enabled = Enabled;
        }
        private void InitSupplyMainObj()
        {
            SupplyMain supplyMain = new SupplyMain()
            {
                Date = DateTime.Now,
                StrId = (short)Session.CurrSettings.DefaultStore,
                UserId = Session.CurrentUser.ID,
                BrnId = Session.CurrentBranch.ID,
                Status = (byte)supplyType,
                Total = 0,
                TotalFrgn = 0,
                TotalAfterDiscount=0,
                Net = 0,
                TaxPrice = 0,
                DscntAmount = 0,
                DscntPercent = 0,
            };
            supplyMain.No = this.supplyType != SupplyType.SalesRtrn ? Session.MaxNoInv : 0;
            supplyMain.IsCash = Session.CurrSettings.DefaultPayMethodInSales;
            switch (Session.CurrSettings.DefaultPayMethodInSales)
            {
                case (byte)PayMethods.Cash:
                    supplyMain.BoxId = (short)Session.CurrSettings.DefaultBox;
                    supplyMain.Currency = Session.Boxes.Where(x => x.ID == supplyMain.BoxId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                    break;
                case (byte)PayMethods.Carde:
                    supplyMain.BankId = (short)Session.CurrSettings.DefaultBank;
                    supplyMain.Currency = Session.Banks.Where(x => x.ID == supplyMain.BankId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                    break;
                case (byte)PayMethods.Credit:
                    supplyMain.CustId = Session.CurrSettings.DefaultCustomer;
                    supplyMain.Currency = Session.Customers.Where(x => x.ID == supplyMain.CustId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                    break;
                default:
                    break;
            }
            SupplyMainBindingSource.DataSource = supplyMain;
        }
   
        private void InitPrdBindingSourceData(short strId)
        {
            if (strId == 0) return;
            var tbProductList = (from prdQuantity in Session.ProductQunatities
                                 where prdQuantity.StrId == strId
                                 join prd in Session.Products
                                 on prdQuantity.prdId equals prd.ID
                                 select prd).ToList();
            ProductBindingSource.DataSource = tbProductList;

            var q1 = (from prd in tbProductList
                      group prd by prd.ID into prdGrp
                      join prdMsur in Session.PrdMeasurments
                      on prdGrp.Key
                      equals prdMsur.PrdId
                      where prdMsur.Default ==true
                      select new
                      {
                          prdId = prdGrp.Key,
                          prdPrice =myFunaction.GetMinSalePrice(prdGrp.FirstOrDefault().PriceTax, prdMsur),
                          PrdMsurName=prdMsur.Name,
                      }).Select(x => new { x.prdId, x.prdPrice, x.PrdMsurName });
            this.listPrdMsurName= q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault().PrdMsurName);
            this.listPrdPriceDic = q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.prdPrice);
        }
        private void InitForm()
        {
            colprdQuanAvlb.Visible = (supplyType == SupplyType.Sales);
            bbiSelect.Visible = (supplyType == SupplyType.SalesRtrn);
            switch (this.supplyType)
            {
                //case SupplyType.Sales:
                //    bbiPriceOffer.Visibility = BarItemVisibility.Always;
                //    break;
                case SupplyType.SalesRtrn:
                    using (PosDBDataContext posDB = new PosDBDataContext(Program.ConnectionString))
                    {
                        SupplyMainBindingSourceEditor.DataSource = posDB.SupplyMains.Where(x => x.Date >= Session.CurrentYear.DateStart&& (x.Status == 4 || x.Status == 8) 
                       && !x.IsDelete && x.BrnId == Session.CurrentBranch.ID).OrderByDescending(x => x.Date).ToList();
                    }
                    gridView.OptionsSelection.MultiSelect = true;
                    this.Text = "فاتورة مردود مبيعات";
                    ItemForsupNo.Text = "رقم فاتورة المردود :";
                    layoutControlGroup3.Text = "بيانات فاتورة مردود المبيعات الرئيسية :";
                    btnReset.Visible = btnEditPrice.Visible = false;
                    btnSaveAndNew.Visible = false;
                    ItemForSalesNo.Visibility = LayoutVisibility.Always;
                    ItemForSalesNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    ItemForBoxNo.Enabled = ItemForsupCustNo.Enabled = checkEditTax.Enabled = false;
                    textEditBarcodeNo.Enabled = false;
                    layoutControlGrooupMain.ExpandButtonVisible = layoutControlGrooupMain.ExpandOnDoubleClick = false;
                    foreach (GridColumn item in gridView.Columns)
                    {
                        item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                        item.OptionsColumn.AllowEdit = false;
                    }
                    gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
                    gridView.OptionsView.EnableAppearanceEvenRow = true;
                    textEditBarcodeNo.BackColor = System.Drawing.Color.Orange;
                    break;
            }
        }
       
        private void SetDiscountCoumnsEditProperty(bool allowEdit)
        {
            colDscntAmount.OptionsColumn.AllowEdit = allowEdit;
            colsupDscntPercent.OptionsColumn.AllowEdit = allowEdit;
        }
        #endregion

        private void spinEditMonyFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            decimal net = spinEditMonyFinal.Value;
                if (net == 0) return;
            var Supplymain = GetCurSupplyMain();
                var total = Convert.ToDecimal(Supplymain.Total);
                var Tax = checkEditTax.Checked ? Convert.ToDecimal(this.tax) : 0;
            decimal discount = 1 - (net / (total * (1 + (Tax / 100))));
            spinEditMonyFinal.EditValue = null;
            if (discount<0) return;
            supDscntPercentTextEdit.EditValue = discount * 100;
        }
        private void CheckEditTax_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.supplyType == SupplyType.SalesRtrn) return;
            if (Convert.ToBoolean(e.NewValue) != checkEditTax.Checked)
            {
                TextEdit editor = new TextEdit();
                editor.Properties.UseSystemPasswordChar = true;

                XtraInputBoxArgs inputBoxArgs = new XtraInputBoxArgs();
                inputBoxArgs.Editor = editor;
                inputBoxArgs.Caption = "تأكيد";
                inputBoxArgs.Prompt = "يرجى إدخال الرقم السري:";

                var result = XtraInputBox.Show(inputBoxArgs)?.ToString();

                if (result != "a123456")
                {
                    ClsXtraMssgBox.ShowError("عذراً الرقم السري غير صحيح");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void IsCash()
        {
            var tbSupplyMain = GetCurSupplyMain();
            if (tbSupplyMain != null)
            {
                ItemForsupDesc.Text = (tbSupplyMain.IsCash == 1 || tbSupplyMain.IsCash == 3) ? "الاسم :" : "البيان :";
            if(isNew)
                    switch (tbSupplyMain.IsCash)
                {
                    case 1 :
                        tbSupplyMain.BoxId = tbSupplyMain.BoxId == null ? (short)Session.CurrSettings.DefaultBox : tbSupplyMain.BoxId;
                        tbSupplyMain.BankId = tbSupplyMain.BankId == null ? (short)Session.CurrSettings.DefaultBank : tbSupplyMain.BankId;
                        if (tbSupplyMain.BankAmount > 0&& tbSupplyMain.paidCash<=0)
                            tbSupplyMain.Currency = Session.Banks.Where(x => x.ID == tbSupplyMain.BankId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                        else tbSupplyMain.Currency = Session.Boxes.Where(x => x.ID == tbSupplyMain.BoxId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                        ItemForBoxNo.Visibility = itemForPaidCash.Visibility = ItemForBankId.Visibility = itemForPaidCreditCard.Visibility= LayoutVisibility.Always;
                        break;
                    case 2:
                        tbSupplyMain.CustId = tbSupplyMain.CustId == null ? Session.CurrSettings.DefaultCustomer : tbSupplyMain.CustId;
                        tbSupplyMain.Currency = Session.Customers.Where(x => x.ID == tbSupplyMain.CustId).Select(x => x.Currency).FirstOrDefault().GetValueOrDefault();
                       if(!Session.CurrSettings.PayPartInvoValue) tbSupplyMain.BoxId = tbSupplyMain.BankId = null;
                        ItemForBoxNo.Visibility = itemForPaidCash.Visibility = ItemForBankId.Visibility = itemForPaidCreditCard.Visibility = Session.CurrSettings.PayPartInvoValue ? LayoutVisibility.Always : LayoutVisibility.Never;
                        break;
                    default:
                        break;
                }
            }
        }
        //private void SetWeightQuantity(int rowHandle)
        //{
        //    if (!this.productData.PrdMeasurment.Weight) return;

        //    string quanString = null;
        //    try
        //    {
        //        //quanString = this.barcodeNo.Substring(Session.CurrSettings.barcodeWeightNo + Program.My_Setting.barcodeWeightPrdNo, Program.My_Setting.barcodeWeightQuanNo);
        //    }
        //    catch (Exception ex)
        //    {
        //        ClsXtraMssgBox.ShowError("عذراً رقم الباركود غير مسجل بشكل صحيح!" + $"\n\n{ex.Message}");
        //    }
        //    if (double.TryParse(quanString, out double quan)) gridView.SetRowCellValue(rowHandle, colQuanMain, quan);
        //}
        //private double SetAveragePrdPrice(int prdId)
        //{
        //    if (this.productData.PrdMeasurment.Manufacture) return 0;
        //    var tbPrdPriceQuan =new AveragePrdPrice(prdId).GetAverProPrice;
        //    if (tbPrdPriceQuan == null) return 0;
        //    return (this.productData.PrdMeasurment.Status) switch
        //    {
        //        1 => tbPrdPriceQuan.pr1,
        //        2 => tbPrdPriceQuan.pr2,
        //        3 => tbPrdPriceQuan.pr3,
        //    };
        //}
        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (!this.isNew || this.supplyType == SupplyType.SalesRtrn || gridView.DataRowCount == 0) return;
            if (!this.listPrdQuantDic.TryGetValue(e.RowHandle, out double quantity)) return;
            if (quantity <= Session.ProductColors.Where(x => x.ID == 3).Select(x => x.Quan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.ID == 3).Select(x => x.Html).FirstOrDefault());
            if (quantity <= Session.ProductColors.Where(x => x.ID == 2).Select(x => x.Quan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.ID == 2).Select(x => x.Html).FirstOrDefault());
            if (quantity <= Session.ProductColors.Where(x => x.ID == 1).Select(x => x.Quan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.ID == 1).Select(x => x.Html).FirstOrDefault());
            if (Session.CurrSettings.defaultSalePriceFloar == 2)
            { 
                var ppmID = Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, colMsur) ?? "0");
                bool Ptax = this.productData?.Product?.PriceTax ?? false;
                double prdMinPrice =myFunaction.GetMinSalePrice(Ptax,Session.PrdMeasurments.FirstOrDefault(x => x.ID == ppmID));
                double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, "SalePrice") ?? "0");
                if (salePrice < prdMinPrice)
                    e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            }
            if (gridView.GetRowCellValue(e.RowHandle, colsupSalePrice) is decimal f
                && gridView.GetRowCellValue(e.RowHandle, colsupPrice) is decimal ff &&f<ff&&
             (Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.ShowWarning
             || Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent))
                e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            e.HighPriority = true;
        }

        private double GetSalePrice()
        { 
            bool Ptax = this.productData?.Product?.PriceTax??false;
            if (this.tbCustomer == null || Convert.ToByte(this.tbCustomer.SalePrice) == 0)
                return myFunaction.GetSalePrice(Ptax, this.productData.PrdMeasurment);

            switch ((SalePrice)this.tbCustomer.SalePrice)
            {
                case SalePrice.PurchasePrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.Price);
                case SalePrice.SalePrice:
                    return myFunaction.GetSalePrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.MinSalePrice:
                    return myFunaction.GetMinSalePrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.RetailPrice:
                    return myFunaction.GetRetailPrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.BatchPrice:
                    return myFunaction.GetBatchPrice(Ptax, this.productData.PrdMeasurment);
                default:
                    return myFunaction.GetSalePrice(this.productData.Product.PriceTax, this.productData.PrdMeasurment);
            }
        }

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Msur")
                e.RepositoryItem = repositoryItemLookUpEditMeasurment;
        }

        private void CalculateAllInGridViewRow(SupplySub row, bool saleTax = false)
        {
            double price = (row.SalePrice * row.QuanMain);
            row.DscntAmount = price * (row.DscntPercent / 100);
            price -= row.DscntAmount;
            bool SaleTax = (this.productData.Product?.SaleTax).GetValueOrDefault();
            row.TaxPrice = ((checkEditTax.Checked || !SaleTax) && price != 0) ? (price * row.TaxPercent / 100) : 0;
            row.Total = row.TaxPrice + price;
            GridView_RowUpdated(null, null);
        }
        private void InitNewRowObject(SupplySub supplySub,double QuanMainOrPriceWighit = 1, bool ProIsWaghit = false)
        {
            if (this.productData != null)
            {
                supplySub.TaxPercent = (checkEditTax.Checked || !this.productData.Product.SaleTax) ? this.tax : 0;
                supplySub.PrdBarcode = this.productData?.Barcode?.MsurBarcode;
                supplySub.Msur = this.productData.PrdMeasurment.ID;
                supplySub.PrdId = this.productData.PrdMeasurment.PrdId;
                supplySub.Desc = this.productData.Product.Desc;
                supplySub.BuyPrice =this.productData.PrdMeasurment.Price??0;// SetAveragePrdPrice(this.productData.Product.ID);
                if (ProIsWaghit)
                {
                    supplySub.SalePrice = (CurrSettings.ReadMode == (byte)ReadModeType.Weight) ? GetSalePrice() : QuanMainOrPriceWighit;
                    supplySub.QuanMain = (CurrSettings.ReadMode == (byte)ReadModeType.Weight) ? QuanMainOrPriceWighit : 1;
                }
                else
                {
                    supplySub.SalePrice = GetSalePrice();
                    supplySub.QuanMain = QuanMainOrPriceWighit;
                }
                supplySub.Currency = this.productData.GroupStr.Currency;
            }
            CalculateAllInGridViewRow(supplySub);
        }
        private double GetPrdPriceFromStore(PrdMeasurment tbPrdMsur)
        {
            List<PrdMeasurment> p = Session.PrdMeasurments.Where(x => x.PrdId == tbPrdMsur.PrdId).ToList();
            if (tbPrdMsur.Status == 1)
                return tbPrdMsur.Price ?? 0;
            else if (tbPrdMsur.Status == 2 && tbPrdMsur.Conversion is double con && con > 0)
                return (p.FirstOrDefault(x => x.Status == 1).Price / con) ?? 0;
            else if (tbPrdMsur.Status == 3 && tbPrdMsur.Conversion is double c1 && c1 > 0 && p?.FirstOrDefault(x => x.Status == 2)?.Conversion is double c && c > 0)
                return (p.FirstOrDefault(x => x.Status == 1).Price / c / c1) ?? 0;
            return default;
        }
        private double GetPrdPrice(PrdMeasurment tbPrdMsur)
        {
            try
            {
                if (tbPrdMsur == null) return default;
                var ff = Session.buyPrices.OrderByDescending(x => x.supDate).FirstOrDefault(x => x.supPrdId == tbPrdMsur.PrdId);
                if (ff == null)
                    return GetPrdPriceFromStore(tbPrdMsur);
                List<PrdMeasurment> p = Session.PrdMeasurments.Where(x => x.PrdId == tbPrdMsur.PrdId).ToList();
                byte state = (p.FirstOrDefault(x => x.ID == (ff?.supMsur ?? 0))?.Status) ?? 0;
                if (tbPrdMsur.Status == state)
                    return Convert.ToDouble(ff?.supPrice);
                else if (tbPrdMsur.Status - state == 1 && tbPrdMsur.Conversion is double con && con > 0)
                    return Convert.ToDouble(ff?.supPrice) / con;
                else if (tbPrdMsur.Status == 3 && state == 1 && p.FirstOrDefault(x => x.Status == 2).Conversion is double c && c > 0 && tbPrdMsur.Conversion is double c2 && c2 > 0)
                    return Convert.ToDouble(ff?.supPrice) / c / c2;
                else if (tbPrdMsur.Status - state == -1)
                    return Convert.ToDouble(ff?.supPrice) * (p.FirstOrDefault(x => x.Status == 2).Conversion ?? 0);
                else if (tbPrdMsur.Status == 1 && state == 3)
                    return (Convert.ToDouble(ff?.supPrice) * p.FirstOrDefault(x => x.Status == 2).Conversion * p.FirstOrDefault(x => x.Status == 3).Conversion ?? 0);
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        SupplySub temp = new SupplySub();
        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SupplySub row = SupplySubBindingSource.Current as SupplySub;
            double quantity;
            if (row == null) return;
            switch (e.Column.FieldName)
            {
                case nameof(temp.Msur):
                    break;
                case nameof(temp.QuanMain):
                    if (double.TryParse(e.Value.ToString(), out quantity))
                    {
                        if (this.supplyType == SupplyType.SalesRtrn && this.tbSupplySubListOld != null)
                        {
                            var t = this.tbSupplySubListOld.FirstOrDefault(x => x.PrdBarcode == row.PrdBarcode);
                            double Q = (t != null ? t.QuanMain : 0);
                            if (Q < quantity)
                            {
                                MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                                row.QuanMain = Q;
                                gridView.SetFocusedRowCellValue(colQuanMain, Q);
                                return;
                            }
                        }
                    }
                    break;
                case nameof(temp.SalePrice):
                    row.SalePrice = double.Parse(e.Value.ToString());
                    ValidMinSalePrice(row);
                    CalculateAllInGridViewRow(row);
                    break;
                case nameof(temp.Total):
                    ValidMinSalePrice(row); 
                    break;
            }
        }
        void ValidMinSalePrice(SupplySub row)
        {
            bool Ptax = this.productData?.Product?.PriceTax ?? false;
            var pr = Session.PrdMeasurments?.FirstOrDefault(x => x.ID == (row.Msur??0));
            if(pr== null)return;
            double prdPrice = myFunaction.GetMinSalePrice(Ptax, pr);
            if (row.SalePrice < prdPrice)
            {
                string mess = $"عذرا لقد تجاوزت حد سعر البيع الأدنى! \n\nسعر البيع: {row.SalePrice} \nسعر البيع الأدنى: {prdPrice}";
                switch (Session.CurrSettings.defaultSalePriceFloar)
                {
                    case (byte)WarningLevels.ShowWarning:
                        ClsXtraMssgBox.ShowError(mess);
                        return;
                    case (byte)WarningLevels.Prevent:
                        ClsXtraMssgBox.ShowError(mess);
                        gridView.DeleteSelectedRows();
                        return;
                }
            }
            prdPrice = (pr?.Price) ?? 0;
            if (row.SalePrice < prdPrice)
            {
                string mess = $"عذرا سعر البيع اقل من سعر الشراء ! \n\nسعر البيع: {row.SalePrice} \nسعر الشراء: {prdPrice}";
                switch (Session.CurrSettings.tsDefaultSalePriceAndBuy)
                {
                    case (byte)WarningLevels.ShowWarning:
                        ClsXtraMssgBox.ShowError(mess);
                        return;
                    case (byte)WarningLevels.Prevent:
                        ClsXtraMssgBox.ShowError(mess);
                        gridView.DeleteSelectedRows();
                        return;
                }
            }
        }
        public void InitPrdSrch()
        {
           var pro= FormDialogPrdSearch.gridViewSrchPrd.GetFocusedRow() as Product;
            if (pro != null)
            GridView_CellValueChanging(gridView, new CellValueChangedEventArgs(-2147483647, colsupPrdNo, pro.ID));
        }
        private void GridViewSrchPrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) InitPrdSrch();
            else if (e.KeyCode == Keys.F5) FormDialogPrdSearch.Close();
        }

        private void GridViewSrchPrd_DoubleClick(object sender, EventArgs e)
        {
            InitPrdSrch();
        }
        private void repItemButEditSelectPro_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            InitPrdSrch();
        }
        private void GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                double quantity;
                SupplySub row = SupplySubBindingSource.Current as SupplySub;
                if (row == null&& e.Column.FieldName!= nameof(temp.PrdId)) return;
                switch (e.Column.FieldName)
                {
                    case nameof(temp.PrdId):
                        if (row == null || e.RowHandle < 0)
                        {
                            gridView.AddNewRow();
                            gridView.UpdateCurrentRow();
                        }
                        if (!GetData(null, ((e.Value as int?) ?? 0))) return;
                        row = SupplySubBindingSource.Current as SupplySub;
                        InitNewRowObject(row);
                        if (this.productData.Product.Status == (byte)ProductType.Service)
                        {
                            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                                this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
                            //ResetMeasurmentColumns(gridView.FocusedRowHandle);
                        }
                        else
                        {
                            if (InitPrdQuantity(this.productData?.PrdMeasurment))
                                return;
                            ValidMinSalePrice(row);
                            SetPrdQuanAvlbList();
                        }
                        break;
                    case nameof(temp.Msur):
                        break;
                    case nameof(temp.QuanMain):
                        if (double.TryParse(e.Value.ToString(), out quantity))
                        {
                            row.QuanMain = quantity;
                            if (InitPrdQuantity(this.productData?.PrdMeasurment))
                                    return;
                            CalculateAllInGridViewRow(row);
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colTotalPrice, row.Total));
                        }
                        break;
                    case nameof(temp.Height):
                    case nameof(temp.Width):
                        row.Height = double.Parse((e.Column.FieldName == nameof(row.Height) ? e.Value : row.Height).ToString());
                        row.Width = double.Parse((e.Column.FieldName == nameof(row.Width) ? e.Value : row.Width).ToString());
                        if (row.Height > 0 && row.Width > 0)
                        {
                            row.QuanMain = row.Height.GetValueOrDefault() * row.Width.GetValueOrDefault();
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.QuanMain));
                        }
                        break;
                    case nameof(temp.SalePrice):
                        row.SalePrice = double.Parse(e.Value.ToString());
                        
                         CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.Overtime):
                    case nameof(temp.Workingtime):
                        row.Overtime = double.Parse((e.Column.FieldName == nameof(row.Overtime) ? e.Value : row.Overtime).ToString());
                        row.Workingtime = double.Parse((e.Column.FieldName == nameof(row.Workingtime) ? e.Value : row.Workingtime).ToString());
                        if (row.Workingtime > 0 && row.Overtime > 0)
                        {
                            row.QuanMain = row.Workingtime.Value + row.Overtime.Value;
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.QuanMain));
                        }
                        break;
                    case nameof(temp.QteMeter):
                        row.QteMeter = double.Parse(e.Value.ToString());
                        var lst = Session.PrdMeasurments.Where(x => x.PrdId == Convert.ToInt32(row.PrdId));
                        if (this.productData?.PrdMeasurment == null)
                            this.productData.PrdMeasurment = lst.FirstOrDefault(c => c.ID == Convert.ToInt32(row.Msur));
                        if (this.productData?.PrdMeasurment?.Conversion != null)
                        {
                            var currentQte = Math.Ceiling(row.QteMeter * this.productData?.PrdMeasurment?.Conversion ?? 1);
                            var currentPacks = (int?)row.NoPacks;
                            if (lst.Any())
                            {
                                var factor = this.productData?.PrdMeasurment?.Conversion ??1;
                                if (currentPacks != currentQte)
                                {
                                    row.QuanMain = currentQte * factor;
                                    GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.QuanMain));
                                    row.NoPacks = (int?)currentQte;
                                    row.QteMeter = currentQte * factor;
                                }
                            }
                        }
                        break;
                    case nameof(temp.DscntPercent):
                        row.DscntPercent = double.Parse(e.Value?.ToString());
                        row.DscntAmount = row.DscntPercent != 0 ? (row.SalePrice * (row.DscntPercent / 100)) * row.QuanMain : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.DscntAmount):

                        row.DscntAmount = double.Parse(e.Value?.ToString());
                        row.DscntPercent = row.DscntAmount != 0 ? (row.DscntAmount / (row.SalePrice * row.QuanMain)) * 100 : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.Total):
                        //if (row.TaxPrice > 0)
                        //{
                            if (row.SalePrice == 0) return;
                            var discount = 1 - ((double.Parse(e.Value?.ToString()) / row.QuanMain) / (row.SalePrice * (1 + (row.TaxPercent / 100))));
                            row.SalePrice = (row.SalePrice - (row.SalePrice * discount));
                        //}
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupSalePrice, row.SalePrice));
                        break;
                    default:
                        break;
                }
                gridView.RefreshData();
                GridView_RowUpdated(sender, null);
            }
            catch (Exception ex)
            {

            }
        }
        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Session.PrdMeasurments == null) return;
            if (e.Column.FieldName == "Msur" && e.Value is int p && p > 0)
                e.DisplayText = Session.PrdMeasurments?.FirstOrDefault(x => x.ID == p)?.Name;
            else if (e.Column.FieldName == "Currency" && e.Value is short c && c > 0)
                e.DisplayText = Session.Currencies?.FirstOrDefault(x => x.ID == c)?.Name;
        }


        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            //if (e.FocusedColumn == colMsur && this.productData?.Product != null)
            //    PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments?.Where(x => x.PrdId == this.productData?.Product?.ID);

            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.Product == null || !isNew || p != productData?.Product?.ID)
                GetData(null, p);
            if (e.FocusedColumn == colMsur)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == p).ToList();
        }
    
        private void RepositoryItemCalcEdit1SalePrice_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (Convert.ToDecimal(e.Value) > (decimal)999999999999999999.99) e.AcceptValue = false;
        }

        private void GridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        bool ValidPrice;
        private void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            e.Valid = ValidPrice;
            return;
            GridView view = sender as GridView;
            if (view == null) return;
            if (Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice)) > (decimal)999999999999999999.99)
            {
                e.Valid = false;
                view.SetColumnError(colsupSalePrice, "المبلغ الذي ادخلته غير صحيح");
                e.ErrorText = (!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
                this.gridValid = false;
            }
            else
                this.gridValid = true;

        }
        private void GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view?.FocusedColumn == colsupSalePrice)
            {
                if (Convert.ToDecimal(e.Value) > (decimal)99999999999999999.99)
                {
                    this.gridValid = false;
                    e.Valid = false;
                    e.ErrorText = (!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
                    XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                }
                else this.gridValid = true;
            }

        }

        private void RepositoryItemLookUpEditMeasurment_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if(gridView.GetFocusedRow() is SupplySub supplySub&&supplySub!=null)
            ValidMinSalePrice(supplySub);
            this.productData.PrdMeasurment = editor.GetSelectedDataRow() as PrdMeasurment;
            if (InitPrdQuantity(this.productData.PrdMeasurment)) return;
            this.MinSalePrice = myFunaction.GetMinSalePrice(this.productData.Product.PriceTax, this.productData.PrdMeasurment);
            var tbBarcode = Session.Barcodes.FirstOrDefault(x => x.MsurId == this.productData.PrdMeasurment.ID);
            SupplySub row = SupplySubBindingSource.Current as SupplySub;
            row.Msur = this.productData.PrdMeasurment.ID;
            row.PrdBarcode = tbBarcode?.MsurBarcode;
            row.BuyPrice =(this.productData.PrdMeasurment.Price??0);// SetAveragePrdPrice(this.productData.Product.ID);
            row.SalePrice = GetSalePrice();
            gridView.UpdateCurrentRow();
            CalculateAllInGridViewRow(row);
            SetPrdQuanAvlbList();
        }
        private void RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (!e.IsGetData) return;
            int prdId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colprdId));
            if (!this.listPrdPriceDic.ContainsKey(prdId)) return;
            if (e.Column.FieldName == colprdSalePrice.FieldName)
                e.Value = this.listPrdPriceDic[prdId];
            else if (e.Column.FieldName == colsupMusrName.FieldName)
                e.Value = this.listPrdMsurName[prdId];
        }

        private void GridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == colCount.FieldName)
                if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;
           
            if (e.Column.FieldName != colprdQuanAvlb.FieldName) return;
            if (!e.IsGetData) return;
            var row=e.Row as SupplySub;
            e.Value = GetQuanAvlb(row!=null? row.PrdId.GetValueOrDefault():0);
        }
        double GetQuanAvlb(int prdId)
        {
            if (!this.listPrdQuanAvlbDic.ContainsKey(prdId)) return 0;
            double otherQuantity = GetQuantityProductInGrid(prdId);
            return this.listPrdQuanAvlbDic[prdId] - otherQuantity;
        }

        public double GetQuantityProductInGrid(int PrdId)
        {
            var pro = SupplySubBindingSource.List as IList<SupplySub>;
            return pro.Where(x => x.PrdId == PrdId).Sum(x => x.QuanMain);
        }
        
        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract) UpdateQuantity(e);
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textEditBarcodeNo.Text))
                GetPrdBarcodeData(textEditBarcodeNo.Text);
        }
        private void MessNotFoundBarcod()
        {
            XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEditBarcodeNo.EditValue = null;
        }
        private void MessGSalesRetQuantity(string m)
        {
            XtraMessageBox.Show(m, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textEditBarcodeNo.EditValue = null;
        }
        private bool GetData(string barcode = null, int PrdId = 0)
        {
            if (barcode != null && PrdId == 0)
            {
                this.productData = (from b in Session.Barcodes
                                    join m in Session.PrdMeasurments on b.MsurId equals m.ID
                                    join p in Session.Products on m.PrdId equals p.ID
                                    join g in Session.GroupStrs on p.GrpNo equals g.ID
                                    where b.MsurBarcode == barcode //&& m.Default == 1
                                    select new ProductData
                                    {
                                        Barcode = b,
                                        PrdMeasurment = m,
                                        Product = p,
                                        GroupStr = g
                                    }).FirstOrDefault();
            }
            else if (barcode == null && PrdId > 0)
            {
               
                if (Session.Products.Any(x => x.ID == PrdId && x.Status == 2))
                {
                    this.productData = (from m in Session.PrdMeasurments
                                        join p in Session.Products on m.PrdId equals p.ID
                                        join g in Session.GroupStrs on p.GrpNo equals g.ID
                                        where p.ID == PrdId && m.Default == true
                                        select new ProductData
                                        {
                                            PrdMeasurment = m,
                                            Product = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }
                else
                {
                    this.productData = (from b in Session.Barcodes
                                        join m in Session.PrdMeasurments on b.MsurId equals m.ID
                                        join p in Session.Products on m.PrdId equals p.ID
                                        join g in Session.GroupStrs on p.GrpNo equals g.ID
                                        where p.ID == PrdId && m.Default == true
                                        select new ProductData
                                        {
                                            Barcode = b,
                                            PrdMeasurment = m,
                                            Product = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }

            }
            return this.productData != null;
        }
        
        private void GetPrdBarcodeData(string barcode)
        {
            var curList = (SupplySubBindingSource.List as IList<SupplySub>);
            SupplySub row = curList.FirstOrDefault(x => x.PrdBarcode == barcode);
            bool FoundInGrid = curList.Any(x => x.PrdBarcode == barcode);
            if (this.supplyType == SupplyType.SalesRtrn)
            {
                this.tbSupplySubListOld = this.tbSupplySubListOld is null ? new List<SupplySub>() : this.tbSupplySubListOld;
                if (!this.tbSupplySubListOld.Any(x => x.PrdBarcode == barcode))
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة البيع");
                    return;
                }
                if (FoundInGrid)
                {
                    if (this.tbSupplySubListOld.FirstOrDefault(x => x.PrdBarcode == barcode).QuanMain <= row.QuanMain)
                    {
                        MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                        return;
                    }
                }
            }
            barcode = myFunaction.ChickBarcodWaghit(barcode, out bool ProIsWaghit,out double value);
            if (!GetData(barcode))
            {
                MessNotFoundBarcod();
                return;
            }
            if (Session.CurrSettings.ReadMode == (byte)ReadModeType.Price&& ProIsWaghit)
            {
                var priceAfterTax = 100 * (value / (100 + 15));
                value = Session.CurrSettings.TaxReadMode ? priceAfterTax : value;
            }
        
            if (FoundInGrid) 
            {
                if ((ProIsWaghit&& !Session.CurrSettings.GroupProductWeightInInvoices)||
                    (!ProIsWaghit&& !Session.CurrSettings.GroupProductsInInvoices))
                {
                    row = myFunaction.GetCopyForObjectSupplySub(row);
                    InitNewRowObject(row, value, ProIsWaghit);
                    row.PrdBarcode = textEditBarcodeNo.Text;
                    curList.Add(row);
                }
                else
                {
                    row.SalePrice = (ProIsWaghit && Session.CurrSettings.ReadMode == (byte)ReadModeType.Price) ? value : row.SalePrice;
                    row.QuanMain += (ProIsWaghit && Session.CurrSettings.ReadMode == (byte)ReadModeType.Price) ? 1 : value;
                    CalculateAllInGridViewRow(row);
                }
            }
            else
            {
                row = myFunaction.GetCopyForObjectSupplySub(new SupplySub());
                InitNewRowObject(row, value, ProIsWaghit);
                row.PrdBarcode = textEditBarcodeNo.Text;
                curList.Add(row);
            }
            SupplySubBindingSource.Position = SupplySubBindingSource.IndexOf(row);
            if (InitPrdQuantity(this.productData.PrdMeasurment)) return;
                ValidMinSalePrice(row);
            PlayBarcodeBeep();
            SetPrdQuanAvlbList();
            gridView.RefreshData();
            return;
        }
        private bool InitPrdQuantity(PrdMeasurment msurStatus)
        {
            var supCurr = SupplySubBindingSource.Current as SupplySub;
            if(supCurr == null)return false;
            double prdQuantity = GetTotalPrdQuByPrdINdMsSta(supCurr.PrdId.GetValueOrDefault(), msurStatus, Convert.ToInt16(GetCurSupplyMain().StrId));
            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                this.listPrdQuantDic.Add(gridView.FocusedRowHandle, prdQuantity);
            if (!Session.CurrSettings.showPrdQtyMssg||!isNew) return false;
            var pro = SupplySubBindingSource.List as IList<SupplySub>;
            double otherQuantity = pro.Where(x => x.PrdId == supCurr.PrdId.GetValueOrDefault()).Sum(x => x.QuanMain);
            if (otherQuantity > prdQuantity)
            {
                ClsXtraMssgBox.ShowError(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuantity));
                if (prdQuantity <= 0)
                    gridView.DeleteSelectedRows();
                else
                    supCurr.QuanMain = prdQuantity;
                return true;
            }
            return false;
        }
        public double GetTotalPrdQuByPrdINdMsSta(int prdId, PrdMeasurment msurStatus, int strId)
        {
            ProductQunatity tbPrdQty = Session.ProductQunatities?.FirstOrDefault(x => x.StrId == strId && x.prdId == prdId);
            if (tbPrdQty == null) return 0;
            return (tbPrdQty.Quantity??0)*(msurStatus.Conversion??1);
        }

        private void UpdatePrdQuanAvlb()=>gridView.SetRowCellValue(gridView.FocusedRowHandle, colprdQuanAvlb, 1);
        private void SetPrdQuanAvlbList()
        { 
            short StorID = Convert.ToInt16(GetCurSupplyMain().StrId);
            if (!this.listPrdQuanAvlbDic.ContainsKey(this.productData.Product.ID))
                this.listPrdQuanAvlbDic.Add(this.productData.Product.ID, GetTotalPrdQuByPrdINdMsSta(this.productData.Product.ID, this.productData.PrdMeasurment, StorID));
            else
                this.listPrdQuanAvlbDic[this.productData.Product.ID] = GetTotalPrdQuByPrdINdMsSta(this.productData.Product.ID, this.productData.PrdMeasurment, StorID);
        }
        bool ValidPayPartInvoValue(SupplyMain tbSupplyMain)
        {
            if (tbSupplyMain?.IsCash == 2)
            {
                if (Session.CurrSettings.PayPartInvoValue)
                {
                    double paid = tbSupplyMain.paidCash + tbSupplyMain.BankAmount;
                    if (paid == tbSupplyMain.Net)
                    {
                        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? $"عذرا يجب ان لا تكون الفاتورة اجل لان اجمالي المدفوع {paid} يساوي قيمة الفاتورة {tbSupplyMain.Net}" : $"Sorry, Payment method can not be Postpaid because the payment {paid} is equal to the value of the invoice {tbSupplyMain.Net}");
                        return false;
                    }
                    if (paid > tbSupplyMain.Net)
                    {
                        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? $"عذرا يجب ان لا يكون المدفوع {paid} اكبر من قيمة الفاتورة {tbSupplyMain.Net}" : $"Sorry, the amount paid {paid} cannot be more than the invoice amount {tbSupplyMain.Net}");
                        return false;
                    }
                }
                if (tbSupplyMain.CustId == null || tbSupplyMain.CustId == 0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة اجل بدون اختيار العميل!");
                    return false;
                }
            }
            else
            {
                if (tbSupplyMain?.BoxId == null || tbSupplyMain?.BoxId <= 0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة قم باختيار الصندوق اولا ");
                    return false;
                }
                if ((tbSupplyMain?.BankId == null || tbSupplyMain?.BankId <= 0) && (tbSupplyMain?.BankAmount ?? 0) > 0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة قم باختيار البنك اولا ");
                    return false;
                }
            }
            return true;
        }
        bool ValidbbiSelect()
        {
            if (this.supplyType == SupplyType.SalesRtrn && !bbiSelect.Checked)
            {
                XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب الضغط على زر التحديد أولاً" : "Please press check button first!");
                return false;
            }
            return true;
        }
        void SetNo(PosDBDataContext db,SupplyMain tbSupplyMain)
        {
            var sup = db.SupplyMains.AsNoTracking().Where(x => x.BrnId == CurrentBranch.ID && x.Date >= CurrentYear.DateStart && (x.Status == 4 || x.Status == 8));
            if (sup.Count() > 0) tbSupplyMain.No = sup.Max(x => x.No) + 1;
            else tbSupplyMain.No = 1;
        }
        private bool SaveData(bool printInvoice=true)
        {
            //Console.WriteLine($"===============SaveData1 = {DateTime.Now.ToString("yy-MM-dd-hh-mm-ss-ffffff")}");
            bool isSaved = false;
            SupplyMain tbSupplyMain = GetCurSupplyMain();
            textEditBarcodeNo.Focus();
            gridView.FocusedColumn = (gridView.FocusedColumn == colsupPrdNo) ? colprdName : colsupPrdNo;
            if (tbSupplyMain == null) return false;
            var curList = (SupplySubBindingSource.List as IList<SupplySub>);
            if (curList == null && this.gridValid)
            {
                XtraMessageBox.Show(_resource.GetString("GridErrorMssg"));
                return false;
            }
            try
            {
               
                if (tbSupplyMain.No == 0)
                {
                    layoutControlGrooupMain.Expanded = true;
                    return dxValidationProvider1.Validate();
                }
                if (!ValidbbiSelect()) return false;
                else if (this.supplyType == SupplyType.Sales)
                {
                    if (curList.Any(x => x.SalePrice < x.BuyPrice) && Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent)
                    {
                        ClsXtraMssgBox.ShowWarning("عذرا يوجد اصناف سعر البيع اقل من سعر التكلفه ");
                        return false;
                    }
                    if (curList.Count<=0)
                    {
                        ClsXtraMssgBox.ShowWarning("عذرا لا يوجد اصناف في الفاتورة!!!! ");
                        return false;
                    }
                    if (tbSupplyMain.Total == 0)
                    {
                        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب ان لا تكون قيمة الفاتورة 0" : "Sorry invoice amount can not be 0");
                        return false;
                    }
                 
                    bool istax = (!checkEditTax.Checked && curList.Any(x => x.TaxPercent != 0 || x.TaxPrice != 0));
                    if (istax || curList.Any(x => x.Currency > 1))
                    {
                        foreach (var tbSupplySub in curList)
                        {
                            if (istax)
                                tbSupplySub.TaxPercent = tbSupplySub.TaxPrice = 0;
                            if (tbSupplySub.Currency > 1)
                            {
                                tbSupplySub.TotalFrgn = tbSupplySub.Total;
                                tbSupplySub.Total = tbSupplySub.Total * (tbSupplyMain.CurrencyChng as short?) ?? 0;
                            }
                        }
                    }
                }
                if (!ValidPayPartInvoValue(tbSupplyMain)) return false;
                using (var db = new PosDBDataContext(Program.ConnectionString))
                {
                    if (this.isNew)
                    {
                        if (Session.CurrSettings.UserDrawerPeriod == true)
                        {
                            if (!db.DrawerPeriods.Any(m => m.PeriodUserID == CurrentUser.ID && m.Status == false))
                            {
                                ClsXtraMssgBox.ShowWarning(Program.My_Setting.LangEng ? "Sorry, Not saved Daily period must be opened first for the user" : "لم يتم الحفظ يجب فتح فترة يومية أولا للمستخدم");
                                return false;
                            }
                        }
                        tbSupplyMain.CustId = tbSupplyMain.CustId == 0 ? null : tbSupplyMain.CustId;
                        if (supplyType == SupplyType.Sales)
                        {
                            if (Program.My_Setting.SendInvoToServerOnSave)
                            {
                                string ConnectionString_AccDB = new MyFunaction().ConnectionString_AccDB();
                                if (Database.Exists(ConnectionString_AccDB))
                                {
                                    using (var Accdb = new AccDBDataContext(ConnectionString_AccDB))
                                    {
                                        var sup1 = Accdb.tblSupplyMains.AsNoTracking().Where(x => x.supBrnId == CurrentBranch.ID && x.supDate >= CurrentYear.DateStart && (x.supStatus == 4 || x.supStatus == 8));
                                        if (sup1.Count() > 0) tbSupplyMain.No = sup1.Max(x => x.supNo) + 1;
                                        else tbSupplyMain.No = 1;
                                    }
                                }
                                else SetNo(db, tbSupplyMain);
                            }
                            else
                                SetNo(db, tbSupplyMain);
                            tbSupplyMain.EnterDate = DateTime.Now;
                        }
                    }
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            if (this.isNew)
                            {
                                db.SupplyMains.InsertOnSubmit(tbSupplyMain);
                                db.SubmitChanges();
                                curList = supplySubs(curList, tbSupplyMain);
                                db.SupplySubs.InsertAllOnSubmit(curList);
                            }
                            else
                            {
                                db.SupplyMains.DeleteOnSubmit(db.SupplyMains.FirstOrDefault(x => x.ID == tbSupplyMain.ID));
                                db.SupplyMains.InsertOnSubmit(tbSupplyMain);
                                curList = supplySubs(curList, tbSupplyMain);
                                db.SupplySubs.DeleteAllOnSubmit(db.SupplySubs.Where(y => y.ParentID == tbSupplyMain.ID));
                                db.SupplySubs.InsertAllOnSubmit(curList);
                            }
                            db.SubmitChanges();
                        
                            transaction.Complete();
                            isSaved = true;
                        }
                        catch (Exception ex)
                        {
                            isSaved = false;
                            ClsXtraMssgBox.ShowError(ex.Message);
                        }
                    }
                    if (printInvoice && isSaved)
                        ShowPrintInvoice();
                }
                //using (var db = new PosDBDataContext(Program.ConnectionString))
                //{
                //    if (this.isNew)
                //    {
                //        tbSupplyMain.CustId = tbSupplyMain.CustId == 0 ? null : tbSupplyMain.CustId;
                //        if (supplyType == SupplyType.Sales)
                //        {
                //            Session.GetMaxNoInv(db);
                //            tbSupplyMain.No = Session.MaxNoInv;
                //            tbSupplyMain.EnterDate = DateTime.Now;
                //        }
                //        db.SupplyMains.InsertOnSubmit(tbSupplyMain);
                //        db.SubmitChanges();
                //        curList = supplySubs(curList,tbSupplyMain);
                //        db.SupplySubs.InsertAllOnSubmit(curList);
                //    }
                //    else
                //    {
                //        db.SupplyMains.DeleteOnSubmit(db.SupplyMains.FirstOrDefault(x => x.ID == tbSupplyMain.ID));
                //        db.SupplyMains.InsertOnSubmit(tbSupplyMain);
                //        curList = supplySubs(curList, tbSupplyMain);
                //        db.SupplySubs.DeleteAllOnSubmit(db.SupplySubs.Where(y => y.ParentID == tbSupplyMain.ID));
                //        db.SupplySubs.InsertAllOnSubmit(curList);
                //    }
                //    db.SubmitChanges();
                //    //Console.WriteLine($"===============SaveData2 = {DateTime.Now.ToString("yy-MM-dd-hh-mm-ss-ffffff")}");
                //    if (printInvoice)
                //        ShowPrintInvoice();
                //    //Session.GetDataProductQunatities(db);
                //    isSaved = true;
                //}
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
            Session.MaxNoInv = isSaved ? tbSupplyMain.No + 1 : Session.MaxNoInv;
            if (Program.My_Setting.SendInvoToServerOnSave && this.isNew)
            {
                List<SupplySub> tbSupplySubList = myFunaction.GetCopyFromSupplySub(curList.ToList());
                SupplyMain temp = myFunaction.GetCopyFromSupplyMain(tbSupplyMain);
                Task.Run(() => new UploadDataToMain(temp, tbSupplySubList));
            }
            return isSaved;
        }
        IList<SupplySub> supplySubs(IList<SupplySub> curList, SupplyMain tbSupplyMain) => (from i in curList
                                                select new SupplySub
                                                {
                                                    BrnId = tbSupplyMain.BrnId,
                                                    BuyPrice = i.BuyPrice,
                                                    Currency = i.Currency,
                                                    Date = tbSupplyMain.Date.GetValueOrDefault(),
                                                    Desc = i.Desc,
                                                    DscntAmount = i.DscntAmount,
                                                    DscntPercent = i.DscntPercent,
                                                    ExpireDate = i.ExpireDate,
                                                    Height = i.Height,
                                                    ID = i.ID,
                                                    Msur = i.Msur,
                                                    NoPacks = i.NoPacks,
                                                    Overtime = i.Overtime,
                                                    ParentID = tbSupplyMain.ID,
                                                    PrdBarcode = i.PrdBarcode,
                                                    PrdId = i.PrdId,
                                                    PrdManufacture = i.PrdManufacture,
                                                    QteMeter = i.QteMeter,
                                                    QuanMain = i.QuanMain,
                                                    SalePrice = i.SalePrice,
                                                    Status = tbSupplyMain.Status,
                                                    TaxPercent = i.TaxPercent,
                                                    TaxPrice = i.TaxPrice,
                                                    Total = i.Total,
                                                    TotalFrgn = i.TotalFrgn,
                                                    UserId = tbSupplyMain.UserId,
                                                    Width = i.Width,
                                                    Workingtime = i.Workingtime,
                                                }).ToList();
        private void SaveAndNew(bool printInvoice)
        {
            if (!SaveData(printInvoice)) return;
            SupplyMain tbSupplyMain = GetCurSupplyMain();
            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), tbSupplyMain.No);
            flyDialog.ShowDialogUC(this, mssg,this.isNew);
            ResetData();
            this.isNew = true;
        }
        MyFunaction myFunaction = new MyFunaction();
        private void bbiPriceOffer_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////flyDialog.WaitForm(this, 1);
            ////this.flyDialogOrders = ClsFlyoutDialog.InitFlyoutDialog(this, new ucOrders(OrderType.PriceOffer, this)
            ////{ Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 }, ClsOrderStatus.GetStringPlural(5));
            ////flyDialog.WaitForm(this, 0);

            this.flyDialogOrders.MouseCaptureChanged += FlyDialogOrders_MouseCaptureChanged;
            this.flyDialogOrders.Show();

            SetFormState(false);
        }

        private void SetFormState(bool isEnabled)
        {
            ////_formSupplyMain.Enabled = isEnabled;
        }

        private void FlyDialogOrders_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.flyDialogOrders.DialogResult != DialogResult.Yes) return;

            SetFormState(true);
            this.flyDialogOrders.Close();
        }
    

        private List<ClsProductQuantList> GetPrdQuanList(List<SupplySub> curList)
        {
           var quantityList = (from s in curList where !s.PrdManufacture
                                  select new ClsProductQuantList
                                  {
                                      prdId = s.PrdId.GetValueOrDefault(),
                                      prdPrice = s.BuyPrice,
                                      prdQuantity = s.QuanMain,
                                      prdPriceMsurId = s.Msur.GetValueOrDefault(),
                                      prdStrId = Convert.ToInt16(StrIdLookUpEdit.EditValue)
                                  }).ToList();
            quantityList.AddRange(from s in curList
                                   join f in Session.PrdManufactures on s.PrdId equals f.PrdId
                                     where s.PrdManufacture
                                     select new ClsProductQuantList
                                     {
                                         prdId = f.PrdSubId,
                                         prdPrice = s.BuyPrice,
                                         prdQuantity = s.QuanMain*f.Quan,
                                         prdPriceMsurId = f.PrdMsurId,
                                         prdStrId = Convert.ToInt16(StrIdLookUpEdit.EditValue)
                                     });
            return quantityList;
        }
        private void ResetData()
        {
            layoutControlGrooupMain.Expanded = Program.My_Setting.supplySaleExpanded;
            this.listPrdQuantDic = new Dictionary<int, double>();
            InitSupplyMainObj();
            InitSupplySubGridObj();
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.gridValid = true;
            textEditBarcodeNo.Focus();
            SetDiscountCoumnsEditProperty(true);
            //txtdisround.Reset();
        }
        private void InitSupplySubGridObj()
        {
            SupplySubBindingSource.DataSource = null;
            SupplySubBindingSource.DataSource = typeof(SupplySub);
        }
        IList<SupplySub> curList;
        private void ShowPrintInvoice(bool PrintBefor=false,PrintFileType printFileType= PrintFileType.Printer)
        {
            SupplyMain tbSupplyMain = GetCurSupplyMain();
            int No = tbSupplyMain!=null? tbSupplyMain.No:0;
            if (!PrintBefor)
                curList = myFunaction.GetCopyFromSupplySub((SupplySubBindingSource.List as IList<SupplySub>).ToList());
            else
            {
                curList = null;
                tbSupplyMain = null;
                No--;
            }
            bool temp=false;
            switch (printFileType)
            {
                case PrintFileType.Printer:
                    if (Session.CurrSettings.ShowPrintMssg)
                        if (ClsXtraMssgBox.ShowQuesPrint(string.Format(_resource.GetString("printMssg"), No)) != DialogResult.Yes) return;
                    temp = Session.CurrSettings.InvoicePrintMode == ((byte)PrintMode.Direct);
                    break;
                case PrintFileType.PDF:
                case PrintFileType.Xlsx:
                    temp = Session.CurrSettings.PrintFileMode == ((byte)PrintMode.Direct);
                        break;
                default:
                    break;
            }
            if (temp)
            {
                SupplyMain tem = tbSupplyMain!=null? myFunaction.GetCopyFromSupplyMain(tbSupplyMain): tbSupplyMain;
                Task.Run(() => myFunaction.PrintInvoice(No, curList, tem, printFileType));
            }
            else
            {
                flyDialog.WaitForm(this, 1);
                myFunaction.PrintInvoice(No, curList, tbSupplyMain, printFileType);
                flyDialog.WaitForm(this, 0);
            }
        }
        private bool ExccededPrdPriceFloar(double price)
        {
            if (Session.CurrSettings.defaultSalePriceFloar==1)
                return false;
            bool isPriceFloar = false;
            if (price < this.MinSalePrice)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("ExccededPrdPriceFloarMssg"), price, this.MinSalePrice));
                gridView.SetFocusedRowCellValue(colsupSalePrice, this.MinSalePrice);
                isPriceFloar = true;
            }
            return isPriceFloar;
        }

        public void SetProductQunatity(int rowHandle, double quantity)
        {
            gridView.SetRowCellValue(rowHandle, colQuanMain, quantity);
            gridView.RefreshRowCell(rowHandle, colQuanMain);
            CalculateAllInGridViewRow(gridView.GetRow(rowHandle) as SupplySub);
        }

        public void SetProductPrice(int rowHandle, double price)
        {
            if (ExccededPrdPriceFloar(price)) return;
            if (price > (double)999999999999999999.99)
            {
                XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                return;
            }
            price = (checkEditTax.Checked ? (price / (this.tax + 100)) * 100 : price);
            gridView.SetRowCellValue(rowHandle, colsupSalePrice, price);
            gridView.RefreshRowCell(rowHandle, colsupSalePrice);
            CalculateAllInGridViewRow(gridView.GetRow(rowHandle) as SupplySub);
        }
        private void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!this.isNew) return;

            switch (e.KeyData)
            {
                case Keys.Delete:
                    DeleteRow();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    textEditBarcodeNo.Focus();
                    e.Handled = true;
                    break;
                case Keys.Add:
                case Keys.Subtract:
                    UpdateQuantity(e);
                    break;
            }
        }

        private void DeleteRow()
        {
            DeletePrdDataFromPrdQuantDicList();
            gridView.DeleteSelectedRows();
            textEditBarcodeNo.Focus();
        }

        private void UpdateQuantity(KeyEventArgs e)
        {
            var row =gridView.GetFocusedRow() /*SupplySubBindingSource.Current*/ as SupplySub;
            if (row == null) return;
            double quantity = Convert.ToDouble(row.QuanMain);
            quantity = (e.KeyData) switch
            {
                Keys.Add => ++quantity,
                Keys.Subtract when quantity > 1 => --quantity,
                _ => quantity
            };
            row.QuanMain = quantity;
            UpdatePrdQuanAvlb();
            CalculateAllInGridViewRow(row);
            e.SuppressKeyPress = true;
            e.Handled = true;

            //if (gridView.GetFocusedRowCellValue(colQuanMain) == null) return;
            //double quantity = Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain));

            //quantity = (e.KeyData) switch
            //{
            //    Keys.Add => ++quantity,
            //    Keys.Subtract when quantity > 1 => --quantity,
            //    _ => quantity
            //};

            //gridView.SetFocusedRowCellValue(colsupQuanMain, quantity);
            //UpdateCurrentRow(gridView.FocusedRowHandle);
            //UpdatePrdQuanAvlb();
            //e.SuppressKeyPress = true;
            //e.Handled = true;
        }
        private void DeletePrdDataFromPrdQuantDicList()
        {
            if (this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Remove(gridView.FocusedRowHandle);
        }

        private void layoutControlGroup8_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(System.Drawing.Brushes.AliceBlue, e.Bounds);
            e.Handled = true;
        }
        private void DisableItems()
        {
            ItemForBarcodeText.Enabled = false;
            checkEditTax.Enabled = false;
            radioGroupIsCash.Enabled = false;
            StrIdLookUpEdit.Enabled = false;
        }
        private void SetRibbonButtonsVisisbility()
        {
            btnSaveAndNew.Visible = false;
            btnSaveAndNewNoPrint.Visible = false;
            btnReset.Visible = false;
            //bbiUpdateInvoice.Visible = false;
        }
        private void SetGridProperties()
        {
            DisableGridColumns(colsupPrdBarcode);
            DisableGridColumns(colsupPrdNo);
            DisableGridColumns(colMsur);
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }
        private void DisableGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.TabStop = false;
        }
        private void AllowGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowFocus = true;
            column.OptionsColumn.TabStop = true;
        }

        private void GridView_HideCustomizationForm(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name + this.supplyType);
        }

        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }


        private void InitBarcodeBeep()
        {
            this.barcodeBeep = new MediaPlayer() { Volume = 1 };
            this.barcodeBeepUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\BarcodeBeep.wav");
        }

        private void PlayBarcodeBeep()
        {
            textEditBarcodeNo.EditValue = null;
            this.barcodeBeep.Open(this.barcodeBeepUri);
            this.barcodeBeep.Play();
        }

        private void InitFlyDialogPrdSrch()
        {
            if (this.InvokeRequired) this.Invoke(new MethodInvoker(delegate { InitFlyoutControls(); }));
            else InitFlyoutControls();
        }
        private void InitFlyoutControls()
        { 
            this.FormDialogPrdSearch = new FormSearchProduct(); 
            FormDialogPrdSearch.gridViewSrchPrd.KeyDown += GridViewSrchPrd_KeyDown;
            FormDialogPrdSearch.gridViewSrchPrd.DoubleClick += GridViewSrchPrd_DoubleClick;
            FormDialogPrdSearch.repItemButEditSelectPro.ButtonClick += repItemButEditSelectPro_ButtonClick;
        }
        public void ShowPrdSearchPanel()=>this.FormDialogPrdSearch.ShowDialog();
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
        //private void Txtdisround_EditValueChanged(object sender, EventArgs e)
        //{   var supplyMain=GetCurSupplyMain();
        //    if (supplyMain == null) return;
        //    double.TryParse(txtdisround.Text, out double disround);
        //    supplyMain.Net = tot - disround;
        //}
        //private void Txtdisround_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    double.TryParse(labelTotalFinalString.Text, out double Net);
        //    //var tot = totalAmount + GetCurSupplyMain()?.TaxPrice;
        //    //var r = tot;
        //    var rd = Net - GetCurSupplyMain()?.Net;
        //    if (rd < 0)
        //    {
        //        rd = rd + ((double)1.00);
        //    }
        //    txtdisround.Text = rd.ToString();
        //}

        private void RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                flyDialog.WaitForm(this, 1);
                using (FormAddCustomer frm = new FormAddCustomer())
                {
                    flyDialog.WaitForm(this, 0);
                    frm.ShowDialog();
                    SupplyMain ss = GetCurSupplyMain();
                    if (((frm.Cus?.No as int?) ?? 0) != 0)
                    {
                        ss.CustId = frm.Cus.ID;
                        ss.RefNo = frm.Cus.No.ToString();
                        CustNoSearchLookUpEdit.EditValue = ss.CustId;
                        customerBindingSource.DataSource = MyTools.GetTablName(Session.Customers);
                        this.tbCustomer = frm.Cus;
                    }
                }
            }
        }
       

       
        public void SendECR()
        {
            if (!ValidateECR()) return;
            if (!ValidateECRamount(out string ecrAmount)) return;
            SendECR(ecrAmount);
        }

        public void SetECRamout()
        {
           var SupplyMain = GetCurSupplyMain();
            if (SupplyMain != null)
            {
                SupplyMain.BankAmount = SupplyMain.Net;
                SupplyMain.BankId = SupplyMain.BankId == null ? (short)Session.CurrSettings.DefaultBank : SupplyMain.BankId;
                textEditPaidCreditCard.EditValue = SupplyMain.BankAmount;
                CalculatePaid(SupplyMain);
            }
        }

        private void SendECR(string ecrAmount)
        {
            string ecrPort = Session.CurrSettings.ecrPort;
            byte[] MSIGD = Encoding.ASCII.GetBytes(this.supplyType == SupplyType.Sales ? "PUR" : "REF");
            byte[] ECRno = Encoding.ASCII.GetBytes("123");
            byte[] Rcptno = Encoding.ASCII.GetBytes((GetCurSupplyMain()).No.ToString());
            byte[] Amount = Encoding.ASCII.GetBytes(ecrAmount);
            byte[] Addfield1 = Encoding.ASCII.GetBytes("E");
            byte[] Addfield2 = Encoding.ASCII.GetBytes(" ");
            byte[] Addfield3 = Encoding.ASCII.GetBytes(" ");
            byte[] Addfield4 = Encoding.ASCII.GetBytes(" ");
            byte[] Addfield5 = Encoding.ASCII.GetBytes(" ");

            this.isProcessing = true;
            UpdateECRresponse();

            try
            {
                Task.Run(() =>
                {
                    byte[] ecr = CUSTOMDLLNET.StartAUCECRTran(MSIGD, ECRno, Rcptno, Amount, Addfield1,
                        Addfield2, Addfield3, Addfield4, Addfield5, ecrPort, 1);

                    string result = CUSTOMDLLNET.mirrorMessage();
                    this.isProcessing = false;
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private bool ValidateECR()
        {
            bool isValid = true;

            try
            {
                isValid = CUSTOMDLLNET.checkDevice(Session.CurrSettings.ecrPort);
                if (!isValid) ClsXtraMssgBox.ShowError("فشل الإتصال بلصرافة الآلية");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            return isValid;
        }

        private bool ValidateECRamount(out string ecrAmountString)
        {
            ecrAmountString = null;
            bool isValid = !decimal.TryParse(textEditPaidCreditCard.Text, out decimal ecrAmount) || ecrAmount == 0 ? false : true;

            if (!isValid)
            {
                ClsXtraMssgBox.ShowError("يجب إدخال المدفوع بطاقة إئتمان أولاً!");
                textEditPaidCreditCard.Focus();
            }
            else
            {
                int ecrAmountInt = (int)ecrAmount;
                int ecrAmountCount = ecrAmountInt.ToString().Length;

                while (ecrAmountCount < 10)
                {
                    ecrAmountCount++;
                    ecrAmountString += "0";
                }

                ecrAmountString += ecrAmountInt.ToString();

                if (ecrAmount % 1 != 0)
                {
                    int ecrAmountFraction = Convert.ToInt32((ecrAmount % 1) * 100);
                    ecrAmountString += ecrAmountFraction.ToString();
                }

                while (ecrAmountString.Length < 12) ecrAmountString += "0";
            }

            return isValid;
        }

        private void UpdateECRresponse()
        {
            this.ecrTimer.Interval = 500;
            this.ecrTimer.Start();
        }

        bool isProcessing;
        private void EcrTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine($"=============insideEcrTimer");
            if (this.isProcessing)
            {
                string result = CUSTOMDLLNET.mirrorMessage();
                Console.WriteLine($"===============resultResponse = {result}");
                labelECR.Text = $"الحالة: {result}";
            }
            else
            {
                labelECR.Text = $"الحالة: {CUSTOMDLLNET.mirrorMessage()}";
                this.ecrTimer.Stop();
            }
        }
        private void DataLayoutControl1_GroupExpandChanged(object sender, LayoutGroupEventArgs e)
        {
            Program.My_Setting.supplySaleExpanded = layoutControlGrooupMain.Expanded;
            MySetting.ReadWriterSettingXml();
        }
        private void GetResources()
        {
            if (!Program.My_Setting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherEn));
            }

            if (Program.My_Setting.LangEng) EnglishTranslation();
        }
        private void EnglishLayout()
        {
            dataLayConMain.BeginUpdate();
            dataLayConMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataLayConMain.OptionsView.RightToLeftMirroringApplied = false;
            dataLayConMain.EndUpdate();
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        private void textEditPaidCreditCard_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.OK)
                    SendECR();
                else if (e.Button.Kind == ButtonPredefines.Delete)
                    CUSTOMDLLNET.sendCancel();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
            }
        }
        private void EnglishTranslation()
        {
            EnglishLayout();

            try
            {
                foreach (LayoutControlItem item in layoutControlGrooupMain.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                foreach (LayoutControlItem item in layoutControlGroup5.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                foreach (LayoutControlItem item in layoutControlGroup8.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                //foreach (LayoutControlItem item in layoutControlGroup9.Items)
                //    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                foreach (GridColumn col in gridView.Columns)
                    _resource.ApplyResources(col, col.Name, _ci);
            }
            catch { }
            try { _resource.ApplyResources(layoutControlGrooupMain, layoutControlGrooupMain.Name, _ci); } catch { }
            try { _resource.ApplyResources(layoutControlGroup5, layoutControlGroup5.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnSave, btnSave.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnClose, btnClose.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnSaveAndNew, btnSaveAndNew.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnEditQuantity, btnEditQuantity.Name, _ci); } catch { }
            try { _resource.ApplyResources(btnEditPrice, btnEditPrice.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSelect, bbiSelect.Name, _ci); } catch { }
            try { _resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci); } catch { }
            try { _resource.ApplyResources(labelItemsCount, labelItemsCount.Name, _ci); } catch { }

            try { BoxNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo"); } catch { }
            try { BoxNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName"); } catch { }
            try { repositoryItemLookUpEditMeasurment.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEditMeasurment.Columns1"); } catch { }
            try
            {
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Caption = _resource.GetString("colprdNo.Caption");
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Width = 150;
            }
            catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }
            this.Text = (this.supplyType == SupplyType.Sales) ? _resource.GetString("this.Sale") : _resource.GetString("this.SaleRtrn");
            try { btnPrintPrevious.Text = _resource.GetString("barButtonItem3"); } catch { }
            //try { bbiUpdateInvoice.Text = _resource.GetString("bbiUpdateInvvoice"); } catch { }
            try { btnPrdPrice.Text = _resource.GetString("bbiPrdPrice"); } catch { }
            try { colprdQuanAvlb.Caption = _resource.GetString("colprdQuanAvlb"); } catch { }
            try { btnReset.Text = _resource.GetString("btnReset"); } catch { }
            try { btnPaidCreditShortcut.Text = _resource.GetString("bsiPaidCreditShortcut"); } catch { }
            try { btnSaveAndNewNoPrint.Text = _resource.GetString("bbiSaveAndNewNoPrint"); } catch { }
            try { layoutControlGrooupMain.Text = _resource.GetString("layoutControlGrooupMain"); } catch { }
            try { checkEdit1.Text = _resource.GetString("checkEdit1"); } catch { }
            try { ItemForBarcodeText.Text = _resource.GetString("ItemForBarcodeText"); } catch { }
            try { btnDeleteRow.Text = _resource.GetString("btnDeleteRow"); } catch { }
            try { simpleLabelItem1.Text = _resource.GetString("simpleLabelItem1"); } catch { }
            try { colCount.Caption = _resource.GetString("colCount"); } catch { }
            try { colDscntAmount.Caption = _resource.GetString("colDscntAmount"); } catch { }
            try { colsupDscntPercent.Caption = _resource.GetString("colsupDscntPercent"); } catch { }
            try { colFinalAmount.Caption = _resource.GetString("colFinalAmount"); } catch { }
            try { ItemForBankId.Text = _resource.GetString("ItemForsupBankId"); } catch { }
            try { layoutControlItem5.Text = _resource.GetString("layoutControlItem5"); } catch { }
            try { labelTotalPriceString.Text = _resource.GetString("labelTotalPriceString"); } catch { }
            try { labelTotalTaxString.Text = _resource.GetString("labelTotalTaxString"); } catch { }
            try { itemForsupDscntPercent.Text = _resource.GetString("itemForsupDscntPercent"); } catch { }
            try { ItemForPoNumber.Text = _resource.GetString("ItemForPoNumber"); } catch { }
            try { ItemForNotes.Text = _resource.GetString("ItemForNotes"); } catch { }
            try { BtnAddFraction.Text = _resource.GetString("simpleButton2"); } catch { }
            try { BtnDscnFraction.Text = _resource.GetString("BtnDscnFraction"); } catch { }
            try { ItemForPlateNumber.Text = _resource.GetString("layoutControlItem8"); } catch { }
            try { ItemForCarType.Text = _resource.GetString("layoutControlItem7"); } catch { }
            try { ItemForCounter.Text = _resource.GetString("layoutControlItem9"); } catch { }
        }
        private void BtnDscnFraction_Click(object sender, EventArgs e)
        {
            var sale = GetCurSupplyMain();
            spinEditMonyFinal.EditValue = sale.Net.ToString().Split('.').FirstOrDefault();
            spinEditMonyFinal_KeyDown(spinEditMonyFinal, new KeyEventArgs(Keys.Enter));
        }
        private void BtnAddFraction_Click(object sender, EventArgs e)
        {
            var sale = GetCurSupplyMain();
            if (gridView.RowCount == 0 || sale == null) return;
            double total = sale.Net;
            double elFaka = 1 - (total - Math.Truncate(total));
            if (elFaka == 1) return;
            var row = SupplySubBindingSource.Current as SupplySub;
            if (row == null) return;
            row.Total +=elFaka;
            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colTotal, row.Total));
        }
    }
}
