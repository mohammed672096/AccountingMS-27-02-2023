using PosFinalCost.Classe;
using PosFinalCost.Forms;
using PosFinalCost.Properties;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Microsoft.PointOfService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors.Controls;

namespace PosFinalCost
{
    public partial class formAddSupplyVoucher : DevExpress.XtraBars.TabForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        List<ClsProductQuantList> tbPrdQuanList;
        List<ClsProductQuantList> tbPrdQuanListOld;
        List<SupplySub> tbSupplySubList;
        List<SupplySub> tbSupplySubListOld;
        ProductData productData = new ProductData();
        ProductQunatity tbPrdQuantiy;
        Customer tbCustomer;
        Form FormDialogPrdSearch;
        FlyoutDialog flyDialogOrders;
        IDictionary<int, double> listPrdQuantDic;
        IDictionary<int, double?> listPrdPriceDic;
        IDictionary<int, double> listPrdQuanAvlbDic;
        MediaPlayer barcodeBeep;
        Uri barcodeBeepUri;
        Timer ecrTimer = new Timer();
        double tax;
        private readonly SupplyType supplyType;
        private bool isNew, gridValid = true;
        private double MinSalePrice, totalAmount, totalTax, discountAmount = 0;
        private double totalFinalOld = 0;
        Uri barcodeBadBeepUri;
        public formAddSupplyVoucher(SupplyMain obj, IEnumerable<SupplySub> subObj, SupplyType supplyType)
        {
            this.supplyType = supplyType;
            InitializeComponent();
            InitDefaultData();
            InitForm();
            InitData(obj, subObj);
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.listPrdQuantDic = new Dictionary<int, double>();
            SetTax();
            GetResources();
            InitEvents();
            //bbiSave.ItemShortcut = new BarShortcut(Keys.F4);
            //bbiSaveAndNew.ItemShortcut = new BarShortcut(Keys.F3);
            var btn = new BarButtonItem { Caption = "" };
            btn.ItemShortcut = new BarShortcut(Keys.F2);
            btn.ItemClick += SetCashInvoice;
            //this.ribbonControl1.Items.Add(btn);
            gridView.OptionsBehavior.Editable = true;
            AllowGridColumns(colsupPrdBarcode);
            AllowGridColumns(colsupPrdNo);
            AllowGridColumns(colMsur);
            ClsPath.ReLodeCustomContol(this.dataLayConMain, this.Name);
            ClsPath.ReLodeCustomContol(this.gridView, this.Name);
        }

        #region Events
        private void formAddSupplyVocher_Load(object sender, EventArgs e)
        {
            Task.Run(() => InitFlyDialogPrdSrch());
            InitBarcodeBeep();
            //InitRibbonStyle();
            Txtdisround_EditValueChanged(null, null);
            layoutControlGrooupMain.Expanded = (supplyType == SupplyType.Sales) ? Program.My_Setting.supplySaleExpanded : layoutControlGrooupMain.Expanded;
            layoutControlCarData.Visibility = Session.CurrSettings.ShowlayoutControlCarData ? LayoutVisibility.Always : LayoutVisibility.Never;
            textEditBarcodeNo.Focus();
            SetFont();
        }
        private void InitEvents()
        {
            this.KeyDown += FormAddSupplyVoucher_KeyDown;
            dataLayConMain.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;
            radioGroupIsCash.EditValueChanged += RadioGroupIsCash_EditValueChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.RowUpdated += GridView_RowUpdated;
            gridView.RowCountChanged += GridView_RowCountChanged;
            gridView.CellValueChanging += GridView_CellValueChanging;
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
            SearchPro.gridViewSrchPrd.KeyDown += GridViewSrchPrd_KeyDown;
            SearchPro.gridViewSrchPrd.DoubleClick += GridViewSrchPrd_DoubleClick;
            SearchPro.gridViewSrchPrd.CustomUnboundColumnData += GridViewSrchPrd_CustomUnboundColumnData;
            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            StrIdLookUpEdit.EditValueChanged += StrIdLookUpEdit_EditValueChanged;
            repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            SearchPro.BtnClosSearchPro.Click += BtnClosSearchPro_Click;
            checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
            checkEditTax.EditValueChanging += CheckEditTax_EditValueChanging;
            supCurrTextEdit.EditValueChanged += SupCurrTextEdit_EditValueChanged;
            supDscntPercentTextEdit.EditValueChanging += DscntAmountTextEdit_EditValueChanging;
            DscntAmountTextEdit.EditValueChanging += DscntAmountTextEdit_EditValueChanging;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
            ecrTimer.Tick += EcrTimer_Tick;
            BoxNoLookUpEdit.EditValueChanged += BoxNoLookUpEdit_EditValueChanged;
            CustNoSearchLookUpEdit.EditValueChanged += CustNoSearchLookUpEdit_EditValueChanged;
        }

        private void GridView_RowCountChanged(object sender, EventArgs e)
        {
            
            GridView_RowUpdated(sender, null);
        }

        private void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (SupplyMainBindingSource.Current != null)
            {
                SupplyMain sale = SupplyMainBindingSource.Current as SupplyMain;
                var items = SupplySubBindingSource.List as IList<SupplySub>;
                if (items.Count() > 0)
                {
                    sale.Total = items.Sum(x => x.QuanMain * x.SalePrice);
                    sale.DscntAmount = items.Sum(x => x.DscntAmount);
                    sale.TaxPrice = items.Sum(x => x.TaxPrice);
                    sale.TotalAfterDiscount = (sale.Total - sale.DscntAmount);
                    sale.Net = (sale.TotalAfterDiscount + sale.TaxPrice);
                }
            }
        }
        private void BoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
            tbSupplyMain.BoxId = Convert.ToInt16(editor.GetColumnValue("ID"));
            tbSupplyMain.Currency = Convert.ToByte(editor.GetColumnValue("Currencie"));
        }
        private void CustNoSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
            if (tbSupplyMain== null) return;
            if (tbSupplyMain.IsCash != 2) return;
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            if (searchLookUpEdit1View.GetFocusedRowCellValue("ID") == null)
            {
                editor.EditValue = null;
                return;
            }
            tbSupplyMain.CustId = Convert.ToInt32(searchLookUpEdit1View.GetFocusedRowCellValue("ID"));
            tbSupplyMain.Currency = Convert.ToByte(searchLookUpEdit1View.GetFocusedRowCellValue("Currency"));
        }
        private void StrIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            InitPrdBindingSourceData((StrIdLookUpEdit.EditValue as short?) ?? 0);
        }
        private void RadioGroupIsCash_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
            tbSupplyMain.IsCash = (byte)((RadioGroup)sender).EditValue;
            IsCash();
            ItemFornotDate.Visibility = tbSupplyMain.IsCash == 2 ? LayoutVisibility.Always : LayoutVisibility.Never;
            layoutControlGroup9.Visibility = (tbSupplyMain.IsCash == 2 && !Session.CurrSettings.PayPartInvoValue) ? LayoutVisibility.Never : LayoutVisibility.Always;
        }
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && this.productData.Product != null)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == this.productData.Product.ID);
        }
        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
            if (tbSupplyMain != null)
            {
                if (tbSupplyMain.Currency > 1)
                {
                    tbSupplyMain.Currency = Convert.ToByte(editor.GetColumnValue("ID"));
                    tbSupplyMain.CurrencyChng = Convert.ToInt16(editor.GetColumnValue("Change"));
                    CurrencyChngTextEdit.EditValue = editor.GetColumnValue("Change");
                    ItemForCurrencyChng.Visibility = LayoutVisibility.Always;
                }
                else
                {
                    tbSupplyMain.CurrencyChng = null;
                    CurrencyChngTextEdit.EditValue = null;
                    ItemForCurrencyChng.Visibility = LayoutVisibility.Never;
                }
            }
        }
        private void DscntAmountTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SupplyMain supplyMain = SupplyMainBindingSource.Current as SupplyMain;
            if (supplyMain == null)
            {
                e.Cancel = true;
                return;
            }
            bool per = ((BaseEdit)sender).Name == "DscntAmountTextEdit";
            var val = double.Parse(e.NewValue.ToString());
            double presentValue = per ? ((val / supplyMain.Total) * 100) : val;
            if (Session.CurrentUser.ID != 1)
            {
                if (!Session.DscntPermissions.Any(x => x.UsrId == Session.CurrentUser.ID) || !Session.DscntPermissions.Where(x => x.UsrId == Session.CurrentUser.ID).Select(x => x.Permission).FirstOrDefault())
                {
                    ClsXtraMssgBox.ShowError($"عذراً ليس لديك صلاحية الخصم!");
                    e.Cancel = true;
                    return;
                }
                else if (Session.DscntPermissions.Where(x => x.UsrId == Session.CurrentUser.ID).Select(x => x.Percent).FirstOrDefault() < (byte)val)
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
                supplyMain.DscntAmount = Math.Round(supplyMain.Total * (val / 100), 2, MidpointRounding.AwayFromZero);
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
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name);
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
            CustNoSearchLookUpEdit.IntializeData(Session.Customers);
            BoxNoLookUpEdit.IntializeData(Session.Boxes);
            BankLookUpEdit.IntializeData(Session.Banks);
            supCurrTextEdit.IntializeData(Session.Currencies);
            this.tax = Session.CurrSettings.taxDefault;
            checkEditTax.Checked = Session.CurrSettings.EnableTax;
            checkEdit1.Checked = Session.CurrSettings.IsInvoiceRound;
        }
        private void InitData(SupplyMain obj, IEnumerable<SupplySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;
                if (this.supplyType != SupplyType.SalesRtrn) InitSupplyMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
            }
            else
            {
                this.isNew = false;
                checkEditTax.Checked = (obj.TaxPrice > 0) ? true : false;
                this.totalFinalOld = obj.Net.Value;
                IsCash();
                SupplyMainBindingSource.DataSource = obj;
                //db.SupplyMains.Attach(SupplyMainBindingSource.Current as SupplyMain);
                //InitSupSubGrid(subObj);
                DisableItems();
                SetRibbonButtonsVisisbility();
                SetGridProperties();

                this.tbPrdQuanListOld = new List<ClsProductQuantList>();

                foreach (var tbSupplySub in subObj)
                    if (tbSupplySub.PrdManufacture) foreach (var tbPrdMan in Session.PrdManufactures.Where(x => x.PrdId == Convert.ToInt32(tbSupplySub.PrdId)))
                            this.tbPrdQuanListOld.Add(new ClsProductQuantList()
                            {
                                prdId = tbPrdMan.PrdSubId,
                                prdPriceMsurId = tbPrdMan.PrdMsurId,
                                prdQuantity = Convert.ToDouble(tbPrdMan.Quan) * Convert.ToDouble(tbSupplySub.QuanMain),
                                prdStrId = Convert.ToInt16(obj.StrId),
                            });
                    else this.tbPrdQuanListOld.Add(new ClsProductQuantList()
                    {
                        prdId = Convert.ToInt32(tbSupplySub.PrdId),
                        prdPriceMsurId = Convert.ToInt32(tbSupplySub.Msur),
                        prdQuantity = Convert.ToDouble(tbSupplySub.QuanMain),
                        prdStrId = Convert.ToInt16(obj.StrId),
                    });
                // Txtdisround_EditValueChanged(null, null);
            }
        }
        private void InitSupplyMainObj()
        {
            checkEditTax.Checked = Session.CurrSettings.EnableTax;
            SupplyMainBindingSource.DataSource = new SupplyMain()
            {
                No = Session.MaxNoInv,
                BoxId = (short)Session.CurrSettings.DefaultBox,
                BankId = (short)Session.CurrSettings.DefaultBank,
                StrId = (short)Session.CurrSettings.DefaultStore,
                CustId = Session.CurrSettings.DefaultCustomer,
                Date = DateTime.Now,
                IsCash = 1,
                UserId = Session.CurrentUser.ID,
                BrnId = Session.CurrentBranch.ID,
                Status = (byte)supplyType,
            };

        }
        private void SetCashInvoice(object sender, ItemClickEventArgs e)
        {

            var formSetCashInvoice = new FormSetCashInvoice { Net = decimal.Parse(spinEditTotalFinalDecimal.Text) };
            formSetCashInvoice.ShowDialog();
            if (formSetCashInvoice.UnPaid >= 0)
                textEditPaidCash.EditValue = formSetCashInvoice.Paid - formSetCashInvoice.UnPaid;
            else
                textEditPaidCash.EditValue = formSetCashInvoice.Paid;
            if (!formSetCashInvoice.IsEscape)
                bbiSaveAndNew_Click(null, null);
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
                      where prdMsur.Default == 1
                      select new
                      {
                          prdId = prdGrp.Key,
                          prdPrice = prdMsur.MinSalePrice
                      }).Select(x => new { x.prdId, x.prdPrice });
            this.listPrdPriceDic = q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.prdPrice);
        }
        private void InitForm()
        {
            colprdQuanAvlb.Visible = (supplyType == SupplyType.Sales) ? true : false;
            //colprdQuanAvlb.VisibleIndex = (supplyType == SupplyType.Sales) ? 6 : colprdQuanAvlb.VisibleIndex;
            switch (this.supplyType)
            {
                //case SupplyType.Sales:
                //    bbiPriceOffer.Visibility = BarItemVisibility.Always;
                //    break;
                case SupplyType.SalesRtrn:
                    //  SupplyMainBindingSourceEditor.DataSource = this.clsTbSupplyMain.GetSupplyMainList.Where(x => x.BrnId == Session.CurrentBranch.ID);
                    gridView.OptionsSelection.MultiSelect = true;
                    this.Text = "فاتورة مردود مبيعات";
                    ItemForsupNo.Text = "رقم فاتورة المردود :";
                    layoutControlGroup3.Text = "بيانات فاتورة مردود المبيعات الرئيسية :";
                    //ribbonPageGroup4.Visible = true;
                    bbiReset.Visible = bbiEditPrice.Visible = false;
                    bbiSaveAndNew.Visible = false;
                    bbiUpdateInvvoice.Visible = false;
                    bbiNewInvoice.Visible = false;
                    ItemForSalesNo.Visibility = LayoutVisibility.Always;
                    ItemForSalesNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                    ItemForBoxNo.Enabled = ItemForsupCustNo.Enabled = checkEditTax.Enabled = false;

                    SetGridProperties();
                    layoutControlGrooupMain.ExpandButtonVisible = layoutControlGrooupMain.ExpandOnDoubleClick = false;
                    foreach (GridColumn item in gridView.Columns)
                        item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                    gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
                    gridView.OptionsView.EnableAppearanceEvenRow = true;
                    textEditBarcodeNo.BackColor = System.Drawing.Color.Orange;
                    break;
            }
        }
        #endregion

        private void FormAddSupplyVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                textEditPaidCreditCard.Focus();
                SetECRamout();
                if (!Session.CurrSettings.isSendToECR) return;
                SendECR();
            }
            if (e.Control && e.KeyCode == Keys.F && !gridControl.ContainsFocus && this.supplyType != SupplyType.SalesRtrn) ShowPrdSearchPanel();
        }

        private void FlyDialogPrd_Shown(object sender, EventArgs e)
        {
            SearchPro.gridViewSrchPrd.ShowFindPanel();
            SearchPro.gridViewSrchPrd.ShowFindPanel();
        }

        private void ShowPrdSearchPanel()
        {
            this.FormDialogPrdSearch.ShowDialog();
        }

        private void GridViewSrchPrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) InitPrdSrch();
            else if (e.KeyCode == Keys.F5) this.FormDialogPrdSearch.Close();
        }

        private void GridViewSrchPrd_DoubleClick(object sender, EventArgs e)
        {
            InitPrdSrch();
        }
        private void repItemButEditSelectPro_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            InitPrdSrch();
        }

        private void InitPrdSrch()
        {
            this.productData.Product = SearchPro.gridViewSrchPrd.GetFocusedRow() as Product;
            if (this.productData.Product == null) return;
            this.productData.PrdMeasurment = Session.PrdMeasurments.Where(x => x.PrdId == this.productData.Product.ID && x.Default == 1).FirstOrDefault();

            if (this.productData.PrdMeasurment == null) return;
            var barcodeNo = (Session.Barcodes.FirstOrDefault(x => x.MsurId == this.productData.PrdMeasurment.ID) is Barcode bar && bar != null) ? bar.MsurBarcode : "";
            //if (UpdateProductGrid(barcodeNo)) return;
            gridView.AddNewRow();
            gridView.UpdateCurrentRow();
            SetPrdQuanAvlbList();
        }
        private void SetDiscountCoumnsEditProperty(bool allowEdit)
        {
            colDscntAmount.OptionsColumn.AllowEdit = allowEdit;
            colsupDscntPercent.OptionsColumn.AllowEdit = allowEdit;
        }
        private void spinEditMonyFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            double net = 0;
            if (double.TryParse(spinEditMonyFinal.Text, out net))
            {
                if (net == 0) return;
                var total = Convert.ToDouble(labelTotalPriceDecimal.Text);
                var Tax = checkEditTax.Checked ? Convert.ToDouble(this.tax) : 0;
                double discount = 1 - (net / (total * (1 + (Tax / 100))));
                spinEditMonyFinal.EditValue = null;
                //if (!ValidateDscntAmount(discount * 100)) return;
                supDscntPercentTextEdit.EditValue = discount * 100;
                //SupDscntPercentTextEdit_KeyUp(null, null);
            }
            //if (e.KeyCode != Keys.Enter) return;
            //decimal net = 0;
            //if (decimal.TryParse(spinEditMonyFinal.Text, out net))
            //{
            //    if (net == 0m) return;
            //    var total = Convert.ToDecimal(labelTotalPriceDecimal.Text);
            //    var Tax = checkEditTax.Checked ? Convert.ToDecimal(this.tax) : 0;
            //    var discount = 0m;
            //    discount = 1 - (net / (total * (1 + (Tax / 100))));

            //    spinEditMonyFinal.EditValue = null;
            //    //if (!ValidateDscntAmount(discount * 100)) return;
            //    supDscntPercentTextEdit.EditValue = discount * 100;
            //    //SupDscntPercentTextEdit_KeyUp(null, null);
            //}
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (supDscntPercentTextEdit.Value <= 0)
            {
                var items = ((BindingSource)gridView.DataSource).List as IList<SupplySub>;
                if (items == null) return;
                double _discountAmount = items.Sum(x => x.DscntAmount);
                DscntAmountTextEdit.EditValue = _discountAmount;
                if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;
                double discountPercent = ((_discountAmount / totalAmount) * 100);
            }
            for (short i = 0; i < gridView.DataRowCount; i++)
                gridView.SetRowCellValue(i, colsupDscntPercent, supDscntPercentTextEdit.Value);

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                var dpr = Convert.ToDecimal(gridView.GetRowCellValue(i, colsupDscntPercent));
                var tp = Convert.ToDecimal(gridView.GetRowCellValue(i, colsupTaxPercent));
                var ta = Convert.ToDecimal(gridView.GetRowCellValue(i, colsupSalePrice)) * Convert.ToDecimal(gridView.GetRowCellValue(i, colQuanMain));
                var ntac = (ta * tp / 100);
                var nta = ntac - (ntac * dpr / 100);
                gridView.SetRowCellValue(i, colTaxPrice, nta);
                //SetColumnDiscountAmount(i, supDscntPercentTextEdit.Value);
            }
        }
        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
           
        }

        private void CheckEditTax_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.Text == "فاتورة مردود مبيعات") return;
            if (Convert.ToBoolean(e.NewValue) != checkEditTax.Checked)
            {
                TextEdit editor = new TextEdit();
                editor.Properties.UseSystemPasswordChar = true;

                XtraInputBoxArgs inputBoxArgs = new XtraInputBoxArgs();
                inputBoxArgs.Editor = editor;
                inputBoxArgs.Caption = "تأكيد";
                inputBoxArgs.Prompt = "يرجى إدخال الرقم السري:";

                var result = XtraInputBox.Show(inputBoxArgs).ToString();

                if (result != "a123456")
                {
                    ClsXtraMssgBox.ShowError("عذراً الرقم السري غير صحيح");
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void CheckEditTax_EditValueChanged(object sender, EventArgs e)
        {
            SetTax();
        }

        private void SetTax()
        {
            //Session.CurrentSystemSetting.checkEditTax = checkEditTax.Checked;
            //Program.My_Setting.Save();
            //HasTax();
        }


        private void IsCash(bool expandLayoutGroup = true)
        {
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
            if (tbSupplyMain != null)
            {
                ItemForsupDesc.Text = (tbSupplyMain.IsCash == 1 || tbSupplyMain.IsCash == 3) ? "الاسم :" : "البيان :";
                layoutControlGrooupMain.Expanded = expandLayoutGroup;
                switch (tbSupplyMain.IsCash)
                {
                    case 1:
                        tbSupplyMain.BoxId = tbSupplyMain.BoxId == null ? (short)Session.CurrSettings.DefaultBox : tbSupplyMain.BoxId;
                        tbSupplyMain.Currency = Session.Boxes.Where(x => x.ID == tbSupplyMain.BoxId).Select(x => x.Currency).FirstOrDefault();
                        tbSupplyMain.BankId = null;
                        ItemForBoxNo.Visibility = ItemForsupCustNo.Visibility = LayoutVisibility.Always;
                        ItemForBankId.Visibility = LayoutVisibility.Never;
                        break;
                    case 2:
                        tbSupplyMain.CustId = tbSupplyMain.CustId == null ? Session.CurrSettings.DefaultCustomer : tbSupplyMain.CustId;
                        tbSupplyMain.Currency = Session.Customers.Where(x => x.ID == tbSupplyMain.CustId).Select(x => x.Currency).FirstOrDefault();
                        ItemForBoxNo.Visibility = ItemForBankId.Visibility = LayoutVisibility.Never;
                        ItemForsupCustNo.Visibility = LayoutVisibility.Always;
                        break;
                    case 3:
                        tbSupplyMain.BankId = tbSupplyMain.BankId == null ? (short)Session.CurrSettings.DefaultBank : tbSupplyMain.BankId;
                        tbSupplyMain.Currency = Session.Banks.Where(x => x.ID == tbSupplyMain.BankId).Select(x => x.Currency).FirstOrDefault();
                        tbSupplyMain.BoxId = null;
                        ItemForBoxNo.Visibility = LayoutVisibility.Never;
                        ItemForBankId.Visibility = ItemForsupCustNo.Visibility = LayoutVisibility.Always;
                        break;
                    default:
                        break;
                }
            }
        }
        private void SetWeightQuantity(int rowHandle)
        {
            if (!this.productData.PrdMeasurment.Weight) return;

            string quanString = null;
            try
            {
                //quanString = this.barcodeNo.Substring(Session.CurrentSystemSetting.barcodeWeightNo + Program.My_Setting.barcodeWeightPrdNo, Program.My_Setting.barcodeWeightQuanNo);
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError("عذراً رقم الباركود غير مسجل بشكل صحيح!" + $"\n\n{ex.Message}");
            }
            if (double.TryParse(quanString, out double quan)) gridView.SetRowCellValue(rowHandle, colQuanMain, quan);
        }

        private void SetPrdPriceFIFO(int prdId, int rowHandle)
        {
            //if (this.productData.PrdMeasurmentRow.Manufacture) return;

            //var tbPrdPriceQuan = this.clsTbPrdPriceQuan.GetPrdPriceQuantObjByPrdId(prdId);
            //if (tbPrdPriceQuan == null) return;

            //double prdAveragePrice = (this.productData.PrdMeasurmentRow.Status) switch
            //{
            //    1 => tbPrdPriceQuan.pr1,
            //    2 => tbPrdPriceQuan.pr2,
            //    3 => tbPrdPriceQuan.pr3,
            //};

            ////gridView.SetRowCellValue(rowHandle, colsupPrice, prdAveragePrice);
        }

        private void SetAveragePrdPrice(int prdId, int rowHandle)
        {
            //if (this.productData.PrdMeasurmentRow.Manufacture) return;

            //var tbPrdPriceQuan = this.clsTbPrdPriceQuan.GetPrdPriceQuanAveragePriceObj(prdId,
            //    this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(prdId));
            //if (tbPrdPriceQuan == null) return;

            //decimal prdAveragePrice = (this.productData.PrdMeasurmentRow.Status) switch
            //{
            //    1 => tbPrdPriceQuan.pr1,
            //    2 => tbPrdPriceQuan.pr2,
            //    3 => tbPrdPriceQuan.pr3,
            //};

            //gridView.SetRowCellValue(rowHandle, colsupPrice, prdAveragePrice);
        }

        private void SetColTaxPercent(int rowIndex)
        {
            if (!checkEditTax.Checked || this.productData.Product.SaleTax) return;
            gridView.SetRowCellValue(rowIndex, colsupTaxPercent, this.tax);
        }

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
            if (Session.CurrSettings.defaultSalePriceFloar==1)
            {
                double prdMinPrice = Session.PrdMeasurments.Where(x => x.ID == Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, colMsur) ?? "0")).Select(x => x.MinSalePrice ?? 0).FirstOrDefault();
                double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, "SalePrice") ?? "0");
                if (salePrice < prdMinPrice)
                    e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            }
            if (Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice))
             < Convert.ToDecimal(gridView.GetRowCellValue(e.RowHandle, colsupPrice)) &&
             (Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.ShowWarning
             || Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent))
                e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            e.HighPriority = true;
        }

        private double GetSalePrice()
        {
            if (this.tbCustomer == null || Convert.ToByte(this.tbCustomer.SalePrice) == 0)
                return Convert.ToDouble(this.productData.PrdMeasurment.SalePrice);

            switch ((SalePrice)this.tbCustomer.SalePrice)
            {
                case SalePrice.PurchasePrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.Price);
                case SalePrice.SalePrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.SalePrice);
                case SalePrice.MinSalePrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.MinSalePrice);
                case SalePrice.RetailPrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.RetailPrice);
                case SalePrice.BatchPrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.BatchPrice);
                default:
                    return Convert.ToDouble(this.productData.PrdMeasurment.SalePrice);
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
            row.DscntAmount = Math.Round(price * (row.DscntPercent / 100), 2, MidpointRounding.AwayFromZero);
            price -= row.DscntAmount;
            row.TaxPrice = ((checkEditTax.Checked || !this.productData.Product.SaleTax) && price != 0) ? (price * row.TaxPercent / 100) : 0;
            row.Total = row.TaxPrice + price;
            GridView_RowUpdated(null, null);
        }
        private void InitNewRowObject(SupplySub supplySub)
        {
            if (this.productData != null)
            {
                supplySub.TaxPercent = (checkEditTax.Checked || !this.productData.Product.SaleTax) ? this.tax : 0;
                supplySub.PrdBarcode = this.productData.Barcode.MsurBarcode;
                supplySub.Msur = this.productData.PrdMeasurment.ID;
                supplySub.PrdId = this.productData.PrdMeasurment.PrdId;
                supplySub.Desc = this.productData.Product.Desc;
                supplySub.BuyPrice = this.productData.PrdMeasurment.Price.Value;
                supplySub.SalePrice = GetSalePrice();
                supplySub.Currency = this.productData.GroupStr.Currency;
                supplySub.QuanMain = 1;
            }
            CalculateAllInGridViewRow(supplySub);
        }
        SupplySub temp = new SupplySub();
        private void GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                double quantity;
                SupplySub row = SupplySubBindingSource.Current as SupplySub;
                switch (e.Column.FieldName)
                {
                    case nameof(temp.PrdId):
                        if (row == null || e.RowHandle < 0)
                        {
                            gridView.AddNewRow();
                            gridView.UpdateCurrentRow();
                            if (!GetData(null, ((e.Value as int?) ?? 0))) return;
                            row = SupplySubBindingSource.Current as SupplySub;
                            InitNewRowObject(row);
                        }
                        if (this.productData.Product.Status == (byte)ProductType.Service)
                        {
                            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                                this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
                            ResetMeasurmentColumns(gridView.FocusedRowHandle);
                        }
                        else
                        {
                            if (InitPrdQuantity(this.productData.PrdMeasurment.Status)) return;
                            SetAveragePrdPrice(this.productData.Product.ID, gridView.FocusedRowHandle);
                            SetPrdQuanAvlbList();
                        }
                        break;
                    case nameof(temp.Msur):
                        break;
                    case nameof(temp.QuanMain):
                        if (double.TryParse(e.Value.ToString(), out quantity))
                        {
                            row.QuanMain = quantity;
                            if (this.supplyType == SupplyType.SalesRtrn && this.tbSupplySubListOld != null)
                            {
                                var t = this.tbSupplySubListOld.FirstOrDefault(x => x.PrdBarcode == row.PrdBarcode);
                                if ((t != null ? t.QuanMain : 0) < quantity)
                                {
                                    MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                                    return;
                                }
                            }
                            if (this.productData.PrdMeasurment != null && InitPrdQuantity(this.productData.PrdMeasurment.Status, quantity))
                            {
                                if (quantity == 1)
                                {
                                    gridView.DeleteSelectedRows();
                                    return;
                                }
                                gridView.SetColumnError(e.Column, _resource.GetString("CheckPrdQtyMssg"));
                                return;
                            }
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
                            row.QuanMain = row.Height.Value * row.Width.Value;
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.QuanMain));
                        }
                        break;
                    case nameof(temp.SalePrice):
                        row.SalePrice = double.Parse(e.Value.ToString());
                        double prdMinPrice = Session.PrdMeasurments.Where(x => x.ID == Convert.ToInt32(row.Msur)).Select(x => x.MinSalePrice.Value).FirstOrDefault();
                        if ((row.SalePrice < prdMinPrice) && Session.CurrSettings.defaultSalePriceFloar==1)
                            gridView.SetColumnError(e.Column, $"عذرا لقد تجاوزت حد سعر البيع الأدنى! \n\nسعر البيع: {row.SalePrice} \nسعر البيع الأدنى: {prdMinPrice}");
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
                        if (this.productData.PrdMeasurment == null)
                            this.productData.PrdMeasurment = lst.FirstOrDefault(c => c.ID == Convert.ToInt32(row.Msur));
                        if (this.productData.PrdMeasurment.Conversion != null)
                        {
                            var currentQte = Math.Ceiling(row.QteMeter / this.productData.PrdMeasurment.Conversion ?? 0);
                            var currentPacks = (int?)row.NoPacks;
                            if (lst.Any())
                            {
                                var factor = this.productData.PrdMeasurment.Conversion ?? 0;
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
                        row.DscntPercent = double.Parse(e.Value.ToString());
                        row.DscntAmount = row.DscntPercent != 0 ? (row.SalePrice * (row.DscntPercent / 100)) * row.QuanMain : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.DscntAmount):

                        row.DscntAmount = double.Parse(e.Value.ToString());
                        row.DscntPercent = row.DscntAmount != 0 ? (row.DscntAmount / (row.SalePrice * row.QuanMain)) * 100 : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.Total):
                        if (row.TaxPrice > 0)
                        {
                            if (row.SalePrice == 0) return;
                            var discount = 1 - ((double.Parse(e.Value.ToString()) / row.QuanMain) / (row.SalePrice * (1 + (row.TaxPercent / 100))));
                            row.SalePrice = (row.SalePrice - (row.SalePrice * discount));
                        }
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
            finally
            {

            }
        }
        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Session.PrdMeasurments == null) return;
            if (e.Column.FieldName == "Msur")
                e.DisplayText = Session.PrdMeasurments.Where(x => x.ID == Convert.ToInt32(e.Value)).Select(x => x.Name).FirstOrDefault();
            else if (e.Column.FieldName == "Currency")
                e.DisplayText = Session.Currencies.Where(x => x.ID == Convert.ToInt16(e.Value)).Select(x => x.Name).FirstOrDefault();
        }


        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colMsur && this.productData.Product != null)
                PrdMeasurmentBindingSource.DataSource = Session.PrdMeasurments.Where(x => x.PrdId == this.productData.Product.ID);
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
            if (InitPrdQuantity(Convert.ToByte(editor.GetColumnValue("Status")))) return;

            this.productData.PrdMeasurment = editor.GetSelectedDataRow() as PrdMeasurment;
            this.MinSalePrice = Convert.ToDouble(this.productData.PrdMeasurment.MinSalePrice);
            var tbBarcode = Session.Barcodes.FirstOrDefault(x => x.MsurId == this.productData.PrdMeasurment.ID);
            SupplySub row = SupplySubBindingSource.Current as SupplySub;
            row.Msur = this.productData.PrdMeasurment.ID;
            row.PrdBarcode = tbBarcode?.MsurBarcode;
            row.BuyPrice = this.productData.PrdMeasurment.Price.Value;
            row.SalePrice = GetSalePrice();
            gridView.UpdateCurrentRow();
            if (this.productData.PrdMeasurment != null) SetAveragePrdPrice(this.productData.PrdMeasurment.PrdId, gridView.FocusedRowHandle);
            CalculateAllInGridViewRow(row);
            SetPrdQuanAvlbList();
        }
        private void RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (e.Column.FieldName != colprdSalePrice.FieldName) return;
            if (!e.IsGetData) return;

            int prdId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colprdId));
            if (!this.listPrdPriceDic.ContainsKey(prdId)) return;
            e.Value = this.listPrdPriceDic[prdId];
        }

        private void GridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == colCount.FieldName)
                if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;

            if (e.Column.FieldName != colprdQuanAvlb.FieldName) return;
            if (!e.IsGetData) return;
            e.Value = GetQuanAvlb(Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colprdId)));
        }
        double GetQuanAvlb(int prdId)
        {
            if (!this.listPrdQuanAvlbDic.ContainsKey(prdId)) return 0;
            double otherQuantity = GetQuantityProductInGrid(prdId);
            return this.listPrdQuanAvlbDic[prdId] - otherQuantity;
        }

        public double GetQuantityProductInGrid(int PrdId)
        {
            double otherQuantity = 0;
            int index = gridView.FocusedRowHandle;
            for (int i = 0; i < gridView.RowCount; i++)
            {
                int prdId = 0;
                if (int.TryParse(gridView.GetRowCellValue(i, colprdId)?.ToString(), out prdId))
                    if (prdId == PrdId) otherQuantity += double.Parse(gridView.GetRowCellValue(i, colQuanMain).ToString());
            }
            return otherQuantity;
        }
        private void GridViewSrchPrd_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != SearchPro.colPrdSalePrice2.FieldName) return;
            if (!e.IsGetData) return;
            //var row = view.GetRow(e.ListSourceRowIndex) as Product;
            //if (row != null)
            //    e.Value = GetFirstPriceInProduct(row.ID);
        }

        private bool CheckProductService(byte Status)
        {
            if (Status != 2) return false;
            gridView.UpdateCurrentRow();

            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
            ResetMeasurmentColumns(gridView.FocusedRowHandle);
            //CalculateTotalAmount();

            return true;
        }

        private void ResetMeasurmentColumns(int rowHandle)
        {
            gridView.SetRowCellValue(rowHandle, colMsur, null);
            gridView.SetRowCellValue(rowHandle, colsupPrice, null);
            gridView.SetRowCellValue(rowHandle, colsupSalePrice, null);
            gridView.SetRowCellValue(rowHandle, colTaxPrice, null);
            gridView.SetRowCellValue(rowHandle, colTotalPrice, null);
        }

        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract) UpdateQuantity(e);
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textEditBarcodeNo.Text))
                GetPrdBarcodeData(textEditBarcodeNo.Text);
        }

        private bool ValidateBarcodeNo(string barcode, out int prdMsurId)
        {
            var tbBarcode = Session.Barcodes.FirstOrDefault(x => x.MsurBarcode == barcode);
            bool isValid = tbBarcode != null ? true : false;

            prdMsurId = tbBarcode != null ? tbBarcode.MsurId : 0;

            if (!isValid)
            {
                if (File.Exists(@"beep-5.wav"))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"beep-5.wav");
                    player.Play();
                }

                XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditBarcodeNo.EditValue = null;
            }

            return isValid;
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
                                    where b.MsurBarcode == barcode && m.Default == 1
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
                this.productData = (from b in Session.Barcodes
                                    join m in Session.PrdMeasurments on b.MsurId equals m.ID
                                    join p in Session.Products on m.PrdId equals p.ID
                                    join g in Session.GroupStrs on p.GrpNo equals g.ID
                                    where p.ID == PrdId && m.Default == 1
                                    select new ProductData
                                    {
                                        Barcode = b,
                                        PrdMeasurment = m,
                                        Product = p,
                                        GroupStr = g
                                    }).FirstOrDefault();
            }
            return this.productData != null;
        }
        SupplySub row;
        private void GetPrdBarcodeData(string barcode)
        {
            var curList = (SupplySubBindingSource.List as IList<SupplySub>);

            if (this.supplyType == SupplyType.SalesRtrn)
            {
                if (this.tbSupplySubListOld.Count() <= 0)
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة البيع");
                    return;
                }
                else if (!this.tbSupplySubListOld.Any(x => x.PrdBarcode == barcode))
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة البيع");
                    return;
                }
                else if (curList.Any(x => x.PrdBarcode == barcode))
                {
                    if (this.tbSupplySubListOld.FirstOrDefault(x => x.PrdBarcode == barcode).QuanMain <= curList.FirstOrDefault(x => x.PrdBarcode == barcode).QuanMain)
                    {
                        MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                        return;
                    }
                }
            }
            if (curList.Count > 0)
            {
                if (Session.CurrSettings.GroupProductsInInvoices && curList.Any(x => x.PrdBarcode == barcode))
                {
                    row = curList.FirstOrDefault(x => x.PrdBarcode == barcode);
                    ChickProductWaghit(row, true);
                    PlayBarcodeBeep();
                    return;
                }
            }
            if (!GetData(barcode))
            {
                MessNotFoundBarcod();
                return;
            }
            this.tbPrdQuantiy = Session.ProductQunatities.Where(x => x.prdId == this.productData.PrdMeasurment.PrdId && x.StrId == Convert.ToInt16(StrIdLookUpEdit.EditValue)).FirstOrDefault();
            if (this.tbPrdQuantiy == null)
            {
                MessNotFoundBarcod();
                return;
            }
            if (row == null) row = new SupplySub();
            curList.Add(row);
            InitNewRowObject(row);
            ChickProductWaghit(row);
            if (InitPrdQuantity(this.productData.PrdMeasurment.Status)) return;
            PlayBarcodeBeep();
            SetPrdQuanAvlbList();
            return;
        }
        public double GetOtherQuantity(int PId)
        {
            double otherQuantity = 0;
            int index = gridView.FocusedRowHandle;
            for (int i = 0; i < gridView.RowCount - 1; i++)
            {
                var row = gridView.GetRow(i) as SupplySub;
                if (i != index && row.PrdId == PId)
                    otherQuantity += row.QuanMain;
            }
            return otherQuantity;
        }
        private bool InitPrdQuantity(byte msurStatus, double colQuantity)
        {
            var supCurr = SupplySubBindingSource.Current as SupplySub;
            int PId = supCurr.PrdId.Value;
            double otherQuantity = GetOtherQuantity(PId);
            double prdQuantity = GetTotalPrdQuByPrdINdMsSta(PId, msurStatus, Convert.ToInt16(StrIdLookUpEdit.EditValue));

            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                this.listPrdQuantDic.Add(gridView.FocusedRowHandle, prdQuantity);
            if (!Session.CurrSettings.showPrdQtyMssg) return false;
            if ((colQuantity + otherQuantity) > prdQuantity)
                return (XtraMessageBox.Show(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuantity), caption: "", buttons: MessageBoxButtons.OK) == DialogResult.OK);

            return false;
        }
        private bool InitPrdQuantity(byte msurStatus)
        {
            var supCurr = SupplySubBindingSource.Current as SupplySub;
            double prdQuantity = GetTotalPrdQuByPrdINdMsSta(supCurr.PrdId.Value, msurStatus, Convert.ToInt16(StrIdLookUpEdit.EditValue));

            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Add(gridView.FocusedRowHandle, prdQuantity);
            if (!Session.CurrSettings.showPrdQtyMssg) return false;
            if (supCurr.QuanMain > prdQuantity)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuantity));
                gridView.DeleteRow(gridView.FocusedRowHandle);
                return true;
            }
            return false;
        }
        public double GetTotalPrdQuByPrdINdMsSta(int prdId, byte msurStatus, int strId)
        {
            ProductQunatity tbPrdQty = Session.ProductQunatities.Where(x => x.StrId == strId && x.prdId == prdId).FirstOrDefault();
            if (tbPrdQty == null) return 0;

            double quantity1 = Convert.ToInt32(tbPrdQty.Quantity), quantity2 = Convert.ToInt32(tbPrdQty.SubQuantity),
                quantity3 = Convert.ToInt32(tbPrdQty.SubQuantity3), totalQuantity = 0;

            switch (msurStatus)
            {
                case 1:
                    totalQuantity = quantity1;
                    break;
                case 2:
                    totalQuantity = (quantity1 * GetPrdPriceConRate2ByPrdId(prdId)) + quantity2;
                    break;
                case 3:
                    totalQuantity = (quantity1 * GetPrdPriceConRate2ByPrdId(prdId)) + (quantity2 * GetPrdPriceConRate3ByPrdId(prdId)) + quantity3;
                    break;
            }
            return totalQuantity;
        }

        public double GetPrdPriceConRate2ByPrdId(int prdId)
        {
            return Convert.ToDouble(Session.PrdMeasurments.Where(x => x.PrdId == prdId && x.Status == 2).Select(x => x.Conversion).FirstOrDefault());
        }
        public double GetPrdPriceConRate3ByPrdId(int prdId)
        {
            return Convert.ToDouble(Session.PrdMeasurments.Where(x => x.PrdId == prdId && x.Status == 3).Select(x => x.Conversion).FirstOrDefault());
        }
        private bool InitPrdQuantity(int focusedRowHandle, byte msurStatus)
        {
            if (!Session.CurrSettings.showPrdQtyMssg) return false;

            int colQuantity = Convert.ToInt32(gridView.GetRowCellValue(focusedRowHandle, colQuanMain));
            //decimal prdQuantity = Convert.ToDecimal(this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(Convert.ToInt32(gridView.GetRowCellValue(focusedRowHandle, colPrdId0)), this.msurStatus, Convert.ToInt16(bbiStrIdSLE.EditValue)));

            //if (colQuantity > prdQuantity)
            //{
            //    XtraMessageBox.Show(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuantity));
            //    gridView.SetRowCellValue(focusedRowHandle, colQuanMain, prdQuantity);
            //    return true;
            //}
            return false;
        }
        private void UpdatePrdQuanAvlb()
        {
            gridView.SetRowCellValue(gridView.FocusedRowHandle, colprdQuanAvlb, 1);
        }

        private void SetPrdQuanAvlbList()
        {
            //if (!this.listPrdQuanAvlbDic.ContainsKey(this.productData.ProductRow.ID))
            //{

            //    this.listPrdQuanAvlbDic.Add(this.productData.ProductRow.ID, Convert.ToDecimal(this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(
            //        this.productData.ProductRow.ID, this.productData.PrdMeasurmentRow.Status, Convert.ToInt16(bbiStrIdSLE.EditValue))));
            //}
            //else
            //{
            //    this.listPrdQuanAvlbDic[this.productData.ProductRow.ID] = Convert.ToDecimal(this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(
            //        this.productData.ProductRow.ID, this.productData.PrdMeasurmentRow.Status, Convert.ToInt16(bbiStrIdSLE.EditValue)));
            //}
        }
        private void ChickProductWaghit(SupplySub row, bool InGrid = false)
        {
            if (Session.CurrSettings.ReadFormScaleBarcode && row.PrdBarcode.Length == Session.CurrSettings.BarcodeLength && row.PrdBarcode.StartsWith(Session.CurrSettings.ScaleBarcodePrefix))
            {
                string Readvalue = row.PrdBarcode.Substring(Session.CurrSettings.ScaleBarcodePrefix.Length + Session.CurrSettings.ProductCodeLength);
                if (Session.CurrSettings.IgnoreCheckDigit) Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
                double value = Convert.ToDouble(Readvalue);
                value = value / (Math.Pow(10, Session.CurrSettings.DivideValueBy));
                if (Session.CurrSettings.ReadMode == 0)
                    row.QuanMain = InGrid ? row.QuanMain + value : value;
                else if (Session.CurrSettings.ReadMode == 1)
                {
                    var priceAfterTax = 100 * (value / (100 + 15));
                    value = Session.CurrSettings.TaxReadMode ? priceAfterTax : value;
                    if (this.productData.PrdMeasurment != null)
                    {
                        value = (value / Convert.ToDouble(this.productData.PrdMeasurment.SalePrice ?? 1));
                        row.QuanMain = InGrid ? row.QuanMain + value : value;
                    }
                }
            }
            else row.QuanMain = InGrid ? row.QuanMain + 1 : row.QuanMain;
            CalculateAllInGridViewRow(row);
        }
        private bool ValidateData()
        {
          
            return true;
        }

        private bool SaveData()
        {
            bool isSaved = false;
            var tbSupplyMain = SupplyMainBindingSource.Current as SupplyMain;
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
                if (this.supplyType == SupplyType.SalesRtrn)
                {
                    //if (!barCheckItem1.Checked)
                    //{
                    //    XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب الضغط على زر التحديد أولاً" : "Please press check button first!");
                    //    return false;
                    //}
                }
                else if (this.supplyType == SupplyType.Sales)
                {
                    if (tbSupplyMain.Currency == null || tbSupplyMain.No == 0)
                    {
                        layoutControlGrooupMain.Expanded = true;
                        return dxValidationProvider1.Validate();
                    }
                    if (curList.Any(x => x.SalePrice < x.BuyPrice) && Session.CurrSettings.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent)
                    {
                        ClsXtraMssgBox.ShowWarning("عذرا يوجد اصناف سعر البيع اقل من سعر التكلفه ");
                        return false;
                    }
                    if (tbSupplyMain.Total == 0)
                    {
                        XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا يجب ان لا تكون قيمة الفاتورة 0" : "Sorry invoice amount can not be 0");
                        return false;
                    }
                    if (tbSupplyMain.IsCash == 2)
                    {
                        if (Session.CurrSettings.PayPartInvoValue)
                        {
                            double paid = (tbSupplyMain.paidCash as double?) ?? 0 + (tbSupplyMain.BankAmount as double?) ?? 0;
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
                        //if (tbSupplyMain.CustId != null && Convert.ToInt64(this.tbCustomer.CellingCredit) == 0) return true;

                        //double totalFinal = this.isNew ? tbSupplyMain.Net.Value : tbSupplyMain.Net.Value - this.totalFinalOld;
                        //bool isValid = (totalFinal + this.clsCustBalance.GetCurrentBalance()) <= this.tbCustomer.CellingCredit;

                        //if (!isValid)
                        //{
                        //    string mssg = "عذراً لا يمكن تجاوز سقف حساب العميل! \n\n";
                        //    mssg += $"رصيد حساب العميل: {this.clsCustBalance.GetCurrentBalance():f2}\n";
                        //    mssg += $"سقف حساب العميل: {this.tbCustomer.CellingCredit:f2}\n\n";
                        //    mssg += $"إجمالي الفاتورة: {tbSupplyMain.Net.Value:f2}";
                        //    if (!this.isNew) mssg += $"\n\nإجمالي الفارق عند التعديل: {totalFinal:f2}";

                        //    ClsXtraMssgBox.ShowError(mssg);
                        //}
                    }
                    this.tbPrdQuanList = new List<ClsProductQuantList>();
                    bool istax = (!checkEditTax.Checked && curList.Any(x => x.TaxPercent != 0 || x.TaxPrice != 0));
                    if (istax || curList.Any(x => x.Currency > 1))
                    {
                        foreach (var tbSupplySub in curList)
                        {
                            if (istax)
                            {
                                tbSupplySub.TaxPercent = 0;
                                tbSupplySub.TaxPrice = 0;
                            }
                            if (tbSupplySub.Currency > 1)
                            {
                                tbSupplySub.TotalFrgn = tbSupplySub.Total;
                                tbSupplySub.Total = tbSupplySub.Total * (tbSupplyMain.CurrencyChng as short?) ?? 0;
                            }
                            //if (tbSupplySub.Msur != null)
                            //    tbSupplySub.BuyPrice = GetPrdPrice(Session.PrdMeasurments.FirstOrDefault(x => x.ID == tbSupplySub.Msur.Value));
                            AddPrdQuanList(tbSupplySub);
                        }
                    }
                    using (var db = new PosDBDataContext(Program.ConnectionString))
                    {
                       
                            if (this.isNew)
                        {
                            db.SupplyMains.InsertOnSubmit(tbSupplyMain);
                            db.SubmitChanges();
                            foreach (var tbSupplySub in curList)
                            {
                                tbSupplySub.ParentID = tbSupplyMain.ID;
                            }
                            db.SupplySubs.InsertAllOnSubmit(curList);
                        }
                        else
                        {
                            db.SupplyMains.Attach(tbSupplyMain);
                            db.SupplySubs.DeleteAllOnSubmit(curList);
                            db.SupplySubs.InsertAllOnSubmit(curList);
                        }
                        db.SubmitChanges();
                            isSaved = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
            return isSaved;
        }
        ////UploadDataToMain SendDataToServer;
        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void SaveAndNew(bool printInvoice)
        {
            //log.Debug("StartSaveAndNew()");
            if (!SaveData()) return;
            //log.Debug("EndSaveAndNew()");

            //string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), this.supNo);
            //flyDialog.ShowDialogFormBelowRIbbon((this.supplyType != SupplyType.DirectSalesRtrn) ? _formSupplyMain : (Form)this, ribbonControl1, mssg);
            //if (Program.My_Setting.SendDataToServerOnSave && this.isNew)
            //{
            //    SupplyMain temp = GetCopyOfCurrentSupplyMain();
            //    Task.Run(() => SendDataToServer = new UploadDataToMain(temp, this.tbSupplySubList));
            //}
            if (printInvoice)
                ShowPrintInvoice();
            ResetData();
            this.isNew = true;
            txtdisround.Reset();
        }
     
        private void bbiSaveAndNewNoPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

       
        private void BbiCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //UCcustomers ucCustomers = new UCcustomers() { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 };
            //ucCustomers.ribbonControl.StatusBar.Hide();
            //ucCustomers.ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            //flyDialog.WaitForm(this, 0);

            //ClsFlyoutDialog.ShowFlyoutDialog(this, ucCustomers, (!Program.My_Setting.LangEng) ? "العملاء" : "Customers");
        }


        private void BbiUpdateInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

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

        ////private void InitFlyoutDialog(UCsales ucSales)
        ////{
        ////    FlyoutCommand flyoutCommand = new FlyoutCommand()
        ////    {
        ////        Text = (!Program.My_Setting.LangEng) ? "إغلاق" : "Close",
        ////        Result = DialogResult.Yes,
        ////    };
        ////    FlyoutAction flyoutAction = new FlyoutAction();
        ////    flyoutAction.Caption = (!Program.My_Setting.LangEng) ? "فواتير المبيعات" : "Sales Invoices";
        ////    flyoutAction.Commands.Add(flyoutCommand);

        ////    FlyoutDialog dialog = new FlyoutDialog(this, flyoutAction, ucSales);
        ////    flyDialog.WaitForm(this, 0);
        ////    if (dialog.ShowDialog() == DialogResult.Yes) dialog.Close();
        ////}

      

        private void bbiEditQuantity_ItemClick(object sender, ItemClickEventArgs e)
        {
              }

        private void bbiRibbonView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ChangeRibbonStyle();
            //SetBbiRibbonStyleCaption();
            //SaveRibbonSettings();
        }

        //private void ChangeRibbonStyle()
        //{
        //    ribbonControl1.RibbonStyle = (ribbonControl1.RibbonStyle == RibbonControlStyle.MacOffice) ? RibbonControlStyle.OfficeUniversal : RibbonControlStyle.MacOffice;
        //}

        //private void SetBbiRibbonStyleCaption()
        //{
        //    bbiRibbonStyle.Caption = (ribbonControl1.RibbonStyle == RibbonControlStyle.MacOffice) ?
        //        ((!Program.My_Setting.LangEng) ? "تصغير العرض" : "Minimize Ribbon") : ((!Program.My_Setting.LangEng) ? "تكبير العرض" : "Maximize Ribbon");
        //}

        //private void SaveRibbonSettings()
        //{
        //    if (this.supplyType == SupplyType.Sales) Program.My_Setting.ribbonStyleSaleForm = ribbonControl1.RibbonStyle;
        //    else Program.My_Setting.ribbonStyleSaleRtrnForm = ribbonControl1.RibbonStyle;
        //    MyTools.ReadWriterSettingXml();
        //    //Program.My_Setting.Save();
        //}

        //private void InitRibbonStyle()
        //{
        //    ribbonControl1.RibbonStyle = (this.supplyType == SupplyType.Sales) ? Program.My_Setting.ribbonStyleSaleForm : Program.My_Setting.ribbonStyleSaleRtrnForm;
        //    SetBbiRibbonStyleCaption();
        //}

        private void AddPrdQuanList(SupplySub tbSupplySub)
        {
            if (!tbSupplySub.PrdManufacture) AddPrdQuanListObj(tbSupplySub);
            else foreach (var tbPrdMan in Session.PrdManufactures.Where(x => x.PrdId == Convert.ToInt32(tbSupplySub.PrdId)))
                    AddPrdQuanListObj(tbSupplySub, tbPrdMan.PrdSubId, tbPrdMan.PrdMsurId, Convert.ToDouble(tbSupplySub.QuanMain) * Convert.ToDouble(tbPrdMan.Quan));
        }

        private void AddPrdQuanListObj(SupplySub tbSupplySub, int prdId = 0, int prdMsurId = 0, double quantity = 0)
        {
            this.tbPrdQuanList.Add(new ClsProductQuantList()
            {
                prdId = (prdId == 0) ? Convert.ToInt32(tbSupplySub.PrdId) : prdId,
                //No = Convert.ToString(tbSupplySub.supPrdNo),
                //Name = Convert.ToString(tbSupplySub.supPrdName),
                prdQuantity = (quantity == 0) ? Convert.ToDouble(tbSupplySub.QuanMain) : quantity,
                prdPriceMsurId = (prdMsurId == 0) ? Convert.ToInt32(tbSupplySub.Msur) : prdMsurId,
                prdStrId = Convert.ToInt16(StrIdLookUpEdit.EditValue)
            });
        }

        //private bool SupplyAutoTarhel()
        //{
        //    if (!this.autoSupplyTarhel) return true;

        //    this.tbSupplyMain.ID = this.supMainId;
        //    return this.clsSupplyTarhel.PhaseSales(new Collection<SupplyMain>() { this.tbSupplyMain });
        //}
        private void ResetData()
        {
            IsCash(Program.My_Setting.supplySaleExpanded);
            this.listPrdQuantDic = new Dictionary<int, double>();
            InitSupplyMainObj();
            InitSupplySubGridObj();
            //ResetTotalLabels();
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.gridValid = true;
            textEditBarcodeNo.Focus();
            textEditPaidCash.EditValue = null;
            notDateTextEdit.EditValue = null;
            this.discountAmount = 0;
            SetDiscountCoumnsEditProperty(true);

            txtdisround.Reset();
        }
        private void InitSupplySubGridObj()
        {
            SupplySubBindingSource.DataSource = null;
            SupplySubBindingSource.DataSource = typeof(SupplySub);
        }
  
        private void ShowPrintInvoice()
        {
            //if (Program.My_Setting.showPrintMssg)
            //    PrintInvoiceMssg();
            //else
            //    PrintReport();
        }

        private void PrintInvoiceMssg()
        {
            //if (XtraMessageBox.Show(_resource.GetString("printInvoiceMssg"), "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    flyDialog.WaitForm(this, 1);
            //    using (ReportForm frm = new ReportForm((Program.My_Setting.supplyA4CustomRprt) ? ReportType.SupplyCustom :
            //        (ReportType)Program.My_Setting.printA4, tbSupplyMain: this.tbSupplyMain, tbSupplySubList: this.tbSupplySubList, clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur))
            //    {
            //        flyDialog.WaitForm(this, 0, frm);
            //        frm.ShowDialog();
            //    }
            //}
        }
        private void PrintReport()
        {
            //SupplyMain temp = GetCopyOfCurrentSupplyMain();
            //Task.Run(() => ClsPrintReport.PrintSupply(temp, this.tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
        }

        private bool ExccededPrdPriceFloar(double price)
        {
            //if (!Session.CurrSettings.defaultSalePriceFloar)
            //    return false;
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
        }

        public void SetProductPrice(int rowHandle, double price)
        {
            if (ExccededPrdPriceFloar(price)) return;
            if (price > (double)999999999999999999.99)
            {
                XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                return;
            }

            price = (checkEditTax.Checked ? (price / (Convert.ToDouble(this.tax) + 100)) * 100 : price);

            gridView.SetRowCellValue(rowHandle, colsupSalePrice, price);
            gridView.RefreshRowCell(rowHandle, colsupSalePrice);
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
            //CalculateTotalAmount();
            textEditBarcodeNo.Focus();
        }

        private void UpdateQuantity(KeyEventArgs e)
        {
            if (gridView.GetFocusedRowCellValue(colQuanMain) == null) return;
            double quantity = Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain));

            //quantity = (e.KeyData) switch
            //{
            //    Keys.Add => ++quantity,
            //    Keys.Subtract when quantity > 1 => --quantity,
            //    _ => quantity
            //};

            gridView.SetFocusedRowCellValue(colQuanMain, quantity);
            UpdatePrdQuanAvlb();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        private void DeletePrdDataFromPrdQuantDicList()
        {
            if (this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Remove(gridView.FocusedRowHandle);
        }

        private void formAddSupplyVocher_Activated(object sender, EventArgs e)
        {
            textEditBarcodeNo.Focus();
        }

        private void layoutControlGroup8_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            e.DefaultDraw();
            e.Graphics.FillRectangle(System.Drawing.Brushes.White, e.Bounds);
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
            bbiSaveAndNew.Visible = false;
            bbiSaveAndNewNoPrint.Visible = false;
            bbiReset.Visible = false;
            bbiNewInvoice.Visible = false;
            bbiUpdateInvvoice.Visible = false;
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
            ClsPath.SaveCustomContol(this.gridView, this.Name);
        }

        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }


        private void InitBarcodeBeep()
        {
            this.barcodeBeep = new MediaPlayer() { Volume = 1 };
            this.barcodeBeepUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\BarcodeBeep.wav");
            barcodeBadBeepUri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\BarcodeBadBeep.wav");
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
            // this.gridControlSrchPrd.Height = 300;
            this.FormDialogPrdSearch.Shown += FlyDialogPrd_Shown;
        }
        SearchProWindow SearchPro = new SearchProWindow();
        private void InitFlyoutControls()
        {

            this.FormDialogPrdSearch = new Form() { Size = new Size(this.Width / 2, (this.Width / 2) / 2) };
            this.FormDialogPrdSearch.ShowIcon = false;
            this.FormDialogPrdSearch.Text = (!Program.My_Setting.LangEng) ? "بحث الأصناف" : "Search Product";
            this.FormDialogPrdSearch.Controls.Add(SearchPro.GetFormProduct());
            SearchPro.layoutControl3.Dock = DockStyle.Fill;
            this.FormDialogPrdSearch.StartPosition = FormStartPosition.CenterScreen;
            this.FormDialogPrdSearch.RightToLeft = (!Program.My_Setting.LangEng) ? RightToLeft.Yes : RightToLeft.No;
            this.FormDialogPrdSearch.RightToLeftLayout = (!Program.My_Setting.LangEng) ? true : false;
            this.FormDialogPrdSearch.MaximizeBox = false;
            this.FormDialogPrdSearch.MinimizeBox = false;
            this.FormDialogPrdSearch.BackColor = System.Drawing.Color.White;
        }
        private void BtnClosSearchPro_Click(object sender, EventArgs e)
        {
            this.FormDialogPrdSearch.Close();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void Txtdisround_EditValueChanged(object sender, EventArgs e)
        {
            double.TryParse(labelTotalDecimal.Text, out double totalAmount);
            //CalculateTotalTax(totalAmount);
            var tot = totalAmount + totalTax;
            double.TryParse(txtdisround.Text, out double disround);
            spinEditTotalFinalDecimal.Value = Convert.ToDecimal(tot - disround);
        }
        public double TotalFinal { get; set; }
        private void Txtdisround_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            double.TryParse(labelTotalDecimal.Text, out double totalAmount);

            //CalculateTotalTax(totalAmount);
            var tot = totalAmount + totalTax;
            var r = tot;
            var rd = tot - r;
            if (rd < 0)
            {
                rd = rd + ((double)1.00);
            }
            txtdisround.Text = rd.ToString();
        }

        private void RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                //flyDialog.WaitForm(this, 1);
                //using (formAddCustomer frm = new formAddCustomer(null, null))
                //{
                //    flyDialog.WaitForm(this, 0);
                //    frm.CloseAfterSave = true;
                //    frm.ShowDialog();
                //    BbiRefreshCustomers_ItemClick(null, null);
                //    bbiCustomerSLE.Refresh();
                //    bbiCustomerSLE.EditValue = frm.customersId;

                //    InitCustomerObj(frm.customersId);
                //}
            }
        }
        private void formAddSupplyVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name);
            ClsPath.SaveCustomContol(this.dataLayConMain, this.Name);
        }

        private void btnECRsend_Click(object sender, EventArgs e)
        {
            SendECR();
        }

        private void btnECRcancel_Click(object sender, EventArgs e)
        {
            CUSTOMDLLNET.sendCancel();
        }

        private void SendECR()
        {
            if (!ValidateECR()) return;
            if (!ValidateECRamount(out string ecrAmount)) return;
            SendECR(ecrAmount);
        }

        private void SetECRamout()
        {
            double t = ((textEditPaidCash.EditValue as double?) ?? 0);
            double ecrAmount = ((spinEditTotalFinalDecimal.EditValue as double?) ?? 0) - t;
            (SupplyMainBindingSource.Current as SupplyMain).BankAmount = ecrAmount;
            textEditPaidCreditCard.EditValue = ecrAmount;
        }

        private void SendECR(string ecrAmount)
        {
            string ecrPort = Session.CurrSettings.ecrPort;
            byte[] MSIGD = Encoding.ASCII.GetBytes(this.supplyType == SupplyType.Sales ? "PUR" : "REF");
            byte[] ECRno = Encoding.ASCII.GetBytes("123");
            byte[] Rcptno = Encoding.ASCII.GetBytes((SupplyMainBindingSource.Current as SupplyMain).No.ToString());
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
      
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //CalculateTotalFinal();
            //Session.CurrentSystemSetting.IsInvoiceRound = checkEdit1.Checked;
            //Program.My_Setting.Save(); 
        }

        private void DataLayoutControl1_GroupExpandChanged(object sender, LayoutGroupEventArgs e)
        {
            Program.My_Setting.supplySaleExpanded = layoutControlGrooupMain.Expanded;
            MyTools.ReadWriterSettingXml();
            //Program.My_Setting.Save();
        }

        private void btn_Calculator_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void formAddSupplyVoucher_Shown(object sender, EventArgs e)
        {
            if (this.supplyType == SupplyType.Sales)
                textEditBarcodeNo.Focus();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        public void SetFontForItems(LayoutControlItem LayContItem)
        {
            //LayContItem.AppearanceItemCaption.Font = (Program.My_Setting.SystemFontSales);
            //LayContItem.AppearanceItemCaptionDisabled.Font = (Program.My_Setting.SystemFontSales);
            //LayContItem.Owner.Appearance.Control.Font = Program.My_Setting.SystemFontSales;
        }
        public void SetFont()
        {
            //this.Font = Program.My_Setting.SystemFontSales;
            //foreach (var item in ribbonControl1.Items)
            //    if (item is BarItem bbi)
            //        bbi.ItemAppearance.SetFont(Program.My_Setting.SystemFontSales);

            //foreach (var item in ribbonControl1.RepositoryItems)
            //    if (item is RepositoryItem bbi)
            //        bbi.Appearance.Font = Program.My_Setting.SystemFontSales;

            //repositoryItemLookUpEditStrId.Appearance.Font = Program.My_Setting.SystemFontSales;
            //foreach (var item in dataLayoutControl1.Items)
            //    if (item is LayoutControlItem txtt)
            //        SetFontForItems(txtt);
            //foreach (var item in layoutControl1.Items)
            //    if (item is LayoutControlItem txtt)
            //        SetFontForItems(txtt);
            //foreach (var item in gridControl.Views)
            //{
            //    if (item is GridView em)
            //    {
            //        em.Appearance.Row.Font = Program.My_Setting.SystemFontSales;
            //        em.Appearance.HeaderPanel.Font = Program.My_Setting.SystemFontSales;
            //    }
            //}
            //foreach (var item in gridControl.RepositoryItems)
            //{
            //    if (item is RepositoryItem em)
            //    {
            //        em.Appearance.Font = Program.My_Setting.SystemFontSales;
            //        if (em.OwnerEdit != null) em.OwnerEdit.Font = Program.My_Setting.SystemFontSales;
            //    }
            //}

            //foreach (var item in gridControlSrchPrd.Views)
            //{
            //    if (item is GridView em)
            //    {
            //        em.Appearance.Row.Font = Program.My_Setting.SystemFontSales;
            //        em.Appearance.HeaderPanel.Font = Program.My_Setting.SystemFontSales;
            //    }
            //}

            //foreach (var item in layoutControl1.Items)
            //    if (item is LayoutControlItem txtt)
            //        SetFontForItems(txtt);
            //foreach (var item in layoutControl2.Items)
            //    if (item is LayoutControlItem txtt)
            //        SetFontForItems(txtt);
            //foreach (var item in layoutControl3.Items)
            //    if (item is LayoutControlItem txtt)
            //        SetFontForItems(txtt);
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

        private void bbiUpdateInvvoice_Click(object sender, EventArgs e)
        {
            ////flyDialog.WaitForm(this, 1);
            ////UCsales ucSales = new UCsales(SupplyType.Sales);
            ////ucSales.ribbonControl.Hide();
            ////ucSales.ribbonControl.StatusBar.Hide();
            ////ucSales.Dock = DockStyle.Fill;
            ////ucSales.Height = ClientSize.Height / 2;
            ////InitFlyoutDialog(ucSales);
        }

        private void bbiClose_Click(object sender, EventArgs e)
        {
            //if (XtraMessageBox.Show(_resource.GetString("CloseFormMssg"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            //{

            this.Close();
            //if (this.isNew && this.supplyType == SupplyType.Sales && _formSupplyMain != null)
            //    if (_formSupplyMain.CloseForm()) _formSupplyMain.CloseMainForm();
            //}
        }

        private void bbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData()) return;

            //  string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), this.supNo);
            this.Close();
            ////if (Program.My_Setting.SendDataToServerOnSave && this.isNew)
            ////{
            ////    SupplyMain temp = GetCopyOfCurrentSupplyMain();
            ////    Task.Run(() => SendDataToServer = new UploadDataToMain(temp, this.tbSupplySubList));
            ////}
            if (this.isNew && this.supplyType == SupplyType.Sales)
            {
                ////if (_formSupplyMain.CloseForm())
                ////{
                ////    _ucSales.SetRefreshListDialog(mssg, this.tbSupplyMain.ID, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
                ////    _formSupplyMain.SetDialogResultOK();
                ////}
                ////else
                ////{
                ////    flyDialog.ShowDialogFormBelowRIbbon(_formSupplyMain, ribbonControl1, mssg);
                ////    ShowPrintInvoice();
                ////}
                return;
            }
            //      CloseForm(mssg);
        }

        private void bbiSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew(true);
        }

        private void bbiReset_Click(object sender, EventArgs e)
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }

        private void bbiPrint1_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            //var supplyMain = db.SupplyMains.AsQueryable().Where(a => (a.Status == 4 || a.Status == 8 || a.Status == 11 || a.Status == 12)
            //   && a.BrnId == Session.CurrentBranch.ID&&a.supNo== noId).ToList().FirstOrDefault();
            //if (supplyMain != null)
            //{
            //    var tbSupplySubList = db.SupplySubs.AsQueryable().Where(x => x.BrnId == Session.CurrentBranch.ID && x.supNo == supplyMain.ID).ToList();
            //    ClsStopWatch stopWatch2 = new ClsStopWatch();
            //    log.Debug("PrintReportClsPrintReportStart");
            //    flyDialog.WaitForm(this, 0);
            //    Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
            //    log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
            //    return;
            //}
            flyDialog.WaitForm(this, 0);
        }

        private void bbiPrintPrevious_Click(object sender, EventArgs e)
        {
            //flyDialog.WaitForm(this, 1);
            //int ID = db.SupplyMains.AsQueryable().Where(a => (a.Status == 4 || a.Status == 8 || a.Status == 11 || a.Status == 12)
            //  && a.BrnId == Session.CurrentBranch.ID).Max(x => x.ID);
            //if (ID >0)
            //{
            //    SupplyMain supplyMain = db.SupplyMains.AsQueryable().Where(a => (a.Status == 4 || a.Status == 8 || a.Status == 11 || a.Status == 12)
            //  && a.BrnId == Session.CurrentBranch.ID && a.ID == ID).FirstOrDefault();
            //    var tbSupplySubList = db.SupplySubs.AsQueryable().Where(x => x.BrnId == Session.CurrentBranch.ID && x.supNo ==ID).ToList();
            //    ClsStopWatch stopWatch2 = new ClsStopWatch();
            //    log.Debug("PrintReportClsPrintReportStart");
            //    flyDialog.WaitForm(this, 0);
            //    Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
            //    log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
            //    return;
            //}
            //flyDialog.WaitForm(this, 0);
        }

        private void bbiSelect_Click(object sender, EventArgs e)
        {
            //if (barCheckItem1.Checked && gridView.SelectedRowsCount < 1)
            //{
            //    XtraMessageBox.Show(_resource.GetString("saleRtrnMarkErrMssg"));
            //    gridView.OptionsSelection.MultiSelect = true;
            //    barCheckItem1.Checked = false;
            //    return;
            //}
            //else if (barCheckItem1.Checked && gridView.SelectedRowsCount >= 1)
            //{
            //    List<SupplySub> tbSupplySubList = new List<SupplySub>();

            //    for (short i = 0; i < gridView.SelectedRowsCount; i++)
            //        tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as SupplySub);
            //    SupplySubBindingSource.DataSource = tbSupplySubList;
            //    gridView.OptionsBehavior.Editable = true;
            //    foreach (GridColumn item in gridView.Columns)
            //    {
            //        if (item != colQuanMain)
            //            DisableGridColumns(item);
            //    }
            //    gridView.OptionsSelection.MultiSelect = false;
            //}
            //else if (!barCheckItem1.Checked && this.tbSupplySubListOld != null)
            //{
            //    List<SupplySub> tbSupplySubList = new List<SupplySub>();
            //    //this.tbSupplySubListOld.ForEach(a => tbSupplySubList.Add(a.ShallowCopy()));
            //    gridView.OptionsSelection.MultiSelect = true;
            //    SupplySubBindingSource.DataSource = tbSupplySubList;
            //}
            //else
            //    gridView.OptionsSelection.MultiSelect = true;
        }

        private void bbiPrdPrice1_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show($"{_resource.GetString("PrdPrice")} {gridView.GetFocusedRowCellValue(colsupPrdName)} {gridView.GetFocusedRowCellValue(colsupPrice)}");
        }

        private void bbiEditPrice1_Click(object sender, EventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDecimal(gridView.GetFocusedRowCellValue(colsupSalePrice))).ShowDialog();
        }

        private void bbiEditQuantity1_Click(object sender, EventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain))).ShowDialog();
        }

        private void btnCalculator_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void barButFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = this.Font;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //Program.My_Setting.SystemFontSales = dialog.Font;
                    //Program.My_Setting.Save();
                }
                SetFont();
            }
        }

        private void bsiPaidCreditShortcut1_Click(object sender, EventArgs e)
        {

        }

        private void bbiSaveAndNewNoPrint_Click(object sender, EventArgs e)
        {
            SaveAndNew(false);
        }

        private void EnglishLayout()
        {
            dataLayConMain.BeginUpdate();
            dataLayConMain.RightToLeft = RightToLeft.No;
            dataLayConMain.OptionsView.RightToLeftMirroringApplied = false;
            dataLayConMain.EndUpdate();
            this.RightToLeft = RightToLeft.No;
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
                foreach (LayoutControlItem item in layoutControlGroup9.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
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
            try { _resource.ApplyResources(bbiSave, bbiSave.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiClose, bbiClose.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSaveAndNew, bbiSaveAndNew.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditQuantity, bbiEditQuantity.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditPrice, bbiEditPrice.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSelect, bbiSelect.Name, _ci); } catch { }
            try { _resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci); } catch { }
            try { _resource.ApplyResources(labelItemsCount, labelItemsCount.Name, _ci); } catch { }

            try { BoxNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo"); } catch { }
            try { BoxNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName"); } catch { }
            try { saleNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns0"); } catch { }
            try { saleNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns1"); } catch { }
            try { saleNoTextEdit.Properties.Columns[2].Caption = _resource.GetString("purchaseNoTextEdit.Properties.Columns2"); } catch { }
            try { repositoryItemLookUpEditMeasurment.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEditMeasurment.Columns1"); } catch { }
            try
            {
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Caption = _resource.GetString("colprdNo.Caption");
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Width = 150;
            }
            catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }
            this.Text = (this.supplyType == SupplyType.Sales) ? _resource.GetString("this.Sale") : _resource.GetString("this.SaleRtrn");
            try { bbiPrintPrevious.Text = _resource.GetString("barButtonItem3"); } catch { }
            try { bbiUpdateInvvoice.Text = _resource.GetString("bbiUpdateInvvoice"); } catch { }
            try { bbiNewInvoice.Text = _resource.GetString("bbiNewInvoice"); } catch { }
            try { bbiPrdPrice.Text = _resource.GetString("bbiPrdPrice"); } catch { }
            try { colprdQuanAvlb.Caption = _resource.GetString("colprdQuanAvlb"); } catch { }
            try { bbiReset.Text = _resource.GetString("bbiReset"); } catch { }
            try { bsiPaidCreditShortcut.Text = _resource.GetString("bsiPaidCreditShortcut"); } catch { }
            try { bbiSaveAndNewNoPrint.Text = _resource.GetString("bbiSaveAndNewNoPrint"); } catch { }
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
            try { layoutControlItem4.Text = _resource.GetString("layoutControlItem4"); } catch { }
            try { itemForDscntAmount.Text = _resource.GetString("itemForDscntAmount"); } catch { }
            try { itemForsupDscntPercent.Text = _resource.GetString("itemForsupDscntPercent"); } catch { }
            try { ItemForPoNumber.Text = _resource.GetString("ItemForPoNumber"); } catch { }
            try { ItemForNotes.Text = _resource.GetString("ItemForNotes"); } catch { }
            try { btnECRsend.Text = _resource.GetString("btnECRsend"); } catch { }
            try { btnECRcancel.Text = _resource.GetString("btnECRcancel"); } catch { }
            try { simpleButton2.Text = _resource.GetString("simpleButton2"); } catch { }
            try { BtnDscnFraction.Text = _resource.GetString("BtnDscnFraction"); } catch { }
            try { layoutControlItem8.Text = _resource.GetString("layoutControlItem8"); } catch { }
            try { layoutControlItem7.Text = _resource.GetString("layoutControlItem7"); } catch { }
            try { layoutControlItem9.Text = _resource.GetString("layoutControlItem9"); } catch { }
        }
        private void BtnDscnFraction_Click(object sender, EventArgs e)
        {
            var sale = SupplyMainBindingSource.Current as SupplyMain;
            spinEditMonyFinal.EditValue = sale.Net.Value.ToString().Split('.').FirstOrDefault();
            spinEditMonyFinal_KeyDown(spinEditMonyFinal, new KeyEventArgs(Keys.Enter));
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0) return;
            double total = 0;
            if (double.TryParse(spinEditTotalFinalDecimal.Text, out total))
            {
                double elFaka = 1 - (total - Math.Truncate(total));
                if (elFaka == 1) return;
                var row = gridView.GetRow(0) as SupplySub;
                if (row == null) return;
                //double price = row.FinalAmount + elFaka;
                //gridView.SetRowCellValue(0, colFinalAmount, price);
            }
        }
    }
}