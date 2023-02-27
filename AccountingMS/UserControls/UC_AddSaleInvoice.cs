using AccountingMS.Classes;
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
using static AccountingMS.Session;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using AccountingMS.Classe;
//using DevExpress.XtraReports.Design;

namespace AccountingMS.Forms
{
    public partial class UC_AddSaleInvoice : UserControl
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        //List<ClsProductQuantList> tbPrdQuanListOld;
        List<tblSupplySub> tbSupplySubListOld;
        tblProductDataRow1 productData = new tblProductDataRow1();
        tblSupplyMain mandob = new tblSupplyMain();
        tblCustomer tbCustomer;
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
        private double MinSalePrice, totalFinalOld = 0;
        public bool isCustomer, isCredit, isSale, isRtrn, isDirPurRtrn = false;
        public SimpleButton btnSetCashInvoice = new SimpleButton();
        ClsAppearance clsAppearance = new ClsAppearance();
        public UC_AddSaleInvoice(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj, SupplyType supplyType)
        {
            if (supplyType == SupplyType.DirectPurchaseRtrn)
            {
                supplyType = SupplyType.PurchaseRtrn;
                isDirPurRtrn = true;
            }
            this.supplyType = supplyType;
            InitializeComponent();
            this.isNew = obj == null;
            radioGroupIsCash.Properties.Items.AddRange((from s in ClsSupplyStatus.PayMethodsList select new RadioGroupItem() { Description = s.Name, Value = s.ID }).ToArray());
            isCustomer = (supplyType == SupplyType.Sales || supplyType == SupplyType.SalesRtrn);
            isCredit = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.PurchaseRtrn);
            isSale = (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesRtrn);
            isRtrn = (this.supplyType == SupplyType.SalesRtrn || this.supplyType == SupplyType.PurchaseRtrn) && !isDirPurRtrn;
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
            SetAppearance();
        }
        void SetAppearance()
        {
            colsupCredit.Visible = isCredit;
            colsupDebit.Visible = !isCredit;
            btnPriceTrans.Visible = !isSale;
            colNetAmount.Visible = !isSale;
            System.Drawing.Color color = System.Drawing.SystemColors.GradientInactiveCaption;
            switch (supplyType)
            {
                case SupplyType.Purchase:
                    color = System.Drawing.Color.Gainsboro;
                    textEditBarcodeNo.BackColor = System.Drawing.Color.Gold;
                    state1 = 3;
                    state2 = 7;
                    break;
                case SupplyType.PurchaseRtrn:
                    color = System.Drawing.SystemColors.Control;
                    textEditBarcodeNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    bbiPriceOffer.Visible = false;
                    state1 = 9;
                    state2 = 10;
                    break;
                case SupplyType.Sales:
                    color = System.Drawing.SystemColors.GradientInactiveCaption;
                    state1 = 4;
                    state2 = 8;
                    break;
                case SupplyType.SalesRtrn:
                    bbiPriceOffer.Visible = false;
                    color = System.Drawing.Color.LightBlue;
                    textEditBarcodeNo.BackColor = System.Drawing.Color.LightYellow;
                    state1 = 11;
                    state2 = 12;
                    break;
            }
            clsAppearance.LayoutAppearanceInvo(layoutControlGroup4, null, color);
            clsAppearance.LayoutAppearanceInvo(layoutControlGroup10, null, color);
            clsAppearance.LayoutAppearanceInvo(layoutControlGroupPayCard, null, color);
            clsAppearance.LayoutAppearanceInvo(layoutControlGroupDiscount, null, color);
            clsAppearance.LayoutAppearanceInvo(layoutControlGroupMain, bindingNavigator11, color);

        }
        private void BtnSetCashInvoice_Click(object sender, EventArgs e)
        {
            var tblSupplyMain = GetCurSupplyMain;
            if (tblSupplyMain != null)
            {
                var formSetCashInvoice = new FormSetCashInvoice { Net = decimal.Parse(spinEditTotalFinalDecimal.Text) };
                formSetCashInvoice.ShowDialog();
                if (formSetCashInvoice.UnPaid >= 0)
                    tblSupplyMain.paidCash = Convert.ToDouble(formSetCashInvoice.Paid - formSetCashInvoice.UnPaid);
                else
                    tblSupplyMain.paidCash = Convert.ToDouble(formSetCashInvoice.Paid);
                if (!formSetCashInvoice.IsEscape)
                    BbiSaveAndNew_Click(null, null);
            }
        }
        #region Events
        private void UC_AddSaleInvoice_Load(object sender, EventArgs e)
        {

            InitBarcodeBeep();
            textEditBarcodeNo.Focus();
            layoutControlGroupMain.Expanded = (supplyType == SupplyType.Sales) ? MySetting.GetPrivateSetting.supplySaleExpanded : layoutControlGroupMain.Expanded;
            layoutControlCarData.Visibility = MySetting.DefaultSetting.ShowlayoutControlCarData ? LayoutVisibility.Always : LayoutVisibility.Never;
            SetFontAndInitFlyDialogPrdSrch();
            InitPrdBindingSourceData((GetCurSupplyMain?.supStrId as short?) ?? 0);
            //await InitObjects();
            if (isSale)
            {
                layoutCponName.Visibility = LayoutVisibility.Always;
                ItemForreprID.Visibility = LayoutVisibility.Always;
                layoutControlItem4.Visibility = LayoutVisibility.Never;
                using (accountingEntities dbr = new accountingEntities())
                {
                    tblRepresentativeBindingSource.DataSource = dbr.tblRepresentatives.ToList();
                }
                radioGroup1.SelectedIndex = 0;
            }

            else
            {
                layoutCponName.Visibility = LayoutVisibility.Never;
                ItemForreprID.Visibility = LayoutVisibility.Never;
                layoutControlItem4.Visibility = LayoutVisibility.Never;
            }

        }
        public void SetFontAndInitFlyDialogPrdSrch()
        {
            Task.Run(() => InitFlyDialogPrdSrch());
            Task.Run(() => this.Invoke(new MethodInvoker(delegate {
                    if (MySetting.GetPrivateSetting.SystemFontSales == MySetting.GetPrivateSetting.SystemFont) return;
                    Font fontConverter =myFunaction.SalesFontConverter();
                    this.layoutControlGroupMain.AppearanceItemCaption.Font = fontConverter;
                    dataLayConMain.Items.Where(x => x is LayoutControlItem).ToList().ForEach(y =>
                    ((LayoutControlItem)y).Owner.Appearance.Control.Font = fontConverter);
                    bindingNavigator11.Font = fontConverter;
                    repositoryItemSearchLookUpEditPrdNo.View.Appearance.Row.Font =
                    repositoryItemSearchLookUpEditPrdNo.View.Appearance.HeaderPanel.Font =
                        repositoryItemLookUpEditMeasurment.AppearanceDropDownHeader.Font =
                    repositoryItemLookUpEditMeasurment.AppearanceDropDown.Font = fontConverter;
                    gridView.Appearance.HeaderPanel.Font = gridView.Appearance.Row.Font = gridView.Appearance.FooterPanel.Font = fontConverter;
            })));

        }
      
        private void InitEvents()
        {
            dataLayConMain.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;
            radioGroupIsCash.EditValueChanged += RadioGroupIsCash_EditValueChanged;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            checkEditPrdLastPrice.EditValueChanged += CheckEditPrdLastPrice_EditValueChanged;
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
            gridView.RowDeleted += GridView_RowDeleted;
            repositoryItemBtnBarcode.Click += RepositoryItemBtnBarcode_Click;
            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            StrIdLookUpEdit.EditValueChanged += StrIdLookUpEdit_EditValueChanged;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            //checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
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
            bbiPriceOffer.Click += BbiPriceOffer_Click;
            btnAddProduct.Click += BtnAddProduct_Click;
            btnPriceTrans.Click += BtnPriceTrans_Click;
            //bbiUpdateInvoice.Click += BbiUpdateInvoice_Click;
            btnRefreashProduct.Click += BtnRefreashProduct_Click;
            btnPaidCreditShortcut.Click += bsiPaidCreditShortcut_Click;
            saleNoTextEdit.EditValueChanged += SaleNoTextEdit_EditValueChanged;
            textEditPaidCash.EditValueChanging += TextEditPaidCash_EditValueChanging;
            textEditPaidCreditCard.EditValueChanging += TextEditPaidCash_EditValueChanging;

        }

        private void CheckEditPrdLastPrice_EditValueChanged(object sender, EventArgs e)
        {
            MySetting.GetPrivateSetting.supPrdLastPrice = checkEditPrdLastPrice.Checked;
            MySetting.WriterSettingXml();
        }

        private void RepositoryItemBtnBarcode_Click(object sender, EventArgs e)
        {
            if (gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode") != null)
            {
                formBarcode frm = new formBarcode();
                frm.Show();
                frm.SearchProduct(gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode").ToString());
            }
        }

        private void BtnPriceTrans_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0 || isSale) return;

            flyDialog.WaitForm(this, 1);
            using var form = new formSupplyPricrTrans();
            flyDialog.WaitForm(this, 0);
            if (form.ShowDialog() == DialogResult.OK)
                if (gridView.GetRow(rowHandle) is tblSupplySub supplySub && supplySub != null)
                {
                    supplySub.supPrice = Convert.ToDouble(form.Price);
                    CalculateAllInGridViewRow(supplySub);
                }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddProduct frm = new formAddProduct(null, null))
            {
                flyDialog.WaitForm(this, 0);
                frm.ShowDialog();
                InitPrdBindingSourceData((GetCurSupplyMain?.supStrId as short?) ?? 0);
                //btnRefreashProduct.PerformClick();
            }
        }

        private void GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SaveDetailInvoToXmlFile();
        }
        private void BbiPriceOffer_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            OrderType orderType = isSale ? OrderType.PriceOffer : OrderType.Purchase;
            this.flyDialogOrders = ClsFlyoutDialog.InitFlyoutDialog(this.ParentForm, new ucOrders(orderType, this)
            { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 }, ClsOrderStatus.GetStringPlural((byte)orderType));
            flyDialog.WaitForm(this, 0);

            this.flyDialogOrders.MouseCaptureChanged += FlyDialogOrders_MouseCaptureChanged;
            this.flyDialogOrders.Show();

            SetFormState(false);
        }
        private void SetFormState(bool isEnabled)
        {
            this.ParentForm.Enabled = isEnabled;
        }

        private void FlyDialogOrders_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.flyDialogOrders.DialogResult != DialogResult.Yes) return;

            SetFormState(true);
            this.flyDialogOrders.Close();
        }

        protected internal void InitOrderSupply(tblOrderMain tbOrderMain, IList<tblOrderSub> tbOrderSubList)
        {
            flyDialog.WaitForm(this, 1);

            SetFormState(true);

            this.flyDialogOrders.Close();
            //this.tbPrdMsur = new tblPrdPriceMeasurment();

            InitOrderMainSupply(tbOrderMain);
            InitOrderSubSupply(tbOrderSubList);
            //CalculateTotalAmount();

            flyDialog.WaitForm(this, 0);
        }

        private void InitOrderMainSupply(tblOrderMain tbOrderMain)
        {
            //SupplyMainBindingSource.DataSource = ClsObjectConverter.OrderToSupplyMain(tbOrderMain, this.supplyType);
            if (GetCurSupplyMain == null) return;
            var box = Session.Boxes?.FirstOrDefault(x => x.boxAccNo == MySetting.DefaultSetting.defaultBox);
            GetCurSupplyMain.supBoxId = box?.id;
            GetCurSupplyMain.supAccName = AccNameByAccNo(box?.boxAccNo ?? 0);
            GetCurSupplyMain.supAccNo = MySetting.DefaultSetting.defaultBox;
            GetCurSupplyMain.supStrId = MySetting.DefaultSetting.defaultStrId;
            GetCurSupplyMain.supRefNo = tbOrderMain?.ordNo.ToString();
            GetCurSupplyMain.supDate = DateTime.Now;
            GetCurSupplyMain.supIsCash = 1;
            GetCurSupplyMain.supCurrency = box?.boxCurrency;
            GetCurSupplyMain.supBrnId = tbOrderMain.ordBrnId;
            GetCurSupplyMain.supUserId = Session.CurrentUser.id;
            GetCurSupplyMain.supStatus = (byte)supplyType;
        }

        private void InitOrderSubSupply(IList<tblOrderSub> tbOrderSubList)
        {
            var tbSupplySubList = ClsObjectConverter.OrderToSupplySub(tbOrderSubList, this.supplyType);

            SupplySubBindingSource.DataSource = tbSupplySubList;
        }

        private async void BtnRefreashProduct_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            await InitObjects();
            InitPrdBindingSourceData((GetCurSupplyMain?.supStrId as short?) ?? 0);
            flyDialog.WaitForm(this, 0);
        }
        public async Task InitObjects()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => GetDataProducts()));
            if (MySetting.GetPrivateSetting.supPrdLastPrice)
                taskList.Add(Task.Run(() => GetDataBuyPrices()));
            taskList.Add(Task.Run(() => GetDataPrdMeasurments()));
            taskList.Add(Task.Run(() => GetDataProductQunatities()));
            //taskList.Add(Task.Run(() => GetDataProductPrices()));
            taskList.Add(Task.Run(() => GetDataBarcodes()));
            await Task.WhenAll(taskList);

        }
        private void TextEditPaidCash_EditValueChanging(object sender, ChangingEventArgs e)
        {
            tblSupplyMain sale = GetCurSupplyMain;
            if (sale == null) return;
            if (sale.net < Convert.ToDouble(e.NewValue))
            {
                e.NewValue = sale.net;
                e.Cancel = true;
            }

            if (((BaseEdit)sender).Name == textEditPaidCreditCard.Name)
            {
                sale.supBankAmount = Convert.ToDouble(e.NewValue);
                CalculatePaid(sale);

            }
            else
            {
                sale.paidCash = Convert.ToDouble(e.NewValue);
                sale.supBankAmount = sale.net - sale.paidCash;
            }
            supIsCash();
        }

        private void SaleNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            var tbSupplyMain = GetCurSupplyMain;
            tblSupplyMain sale = ((tblSupplyMain)editor.GetSelectedDataRow()).ShallowCopy();
            if (isSale)
                tbSupplyMain.supNo = sale.supNo;
            tbSupplyMain.supBoxId = sale.supBoxId;
            tbSupplyMain.supCustSplId = sale.supCustSplId;
            if (sale.supIsCash == 1)
            {
                if (sale.supBoxId == null && Session.Boxes.Any(x => x.boxAccNo == sale.supAccNo))
                    tbSupplyMain.supBoxId = Session.Boxes.FirstOrDefault(x => x.boxAccNo == sale.supAccNo)?.id;
            }
            else if (sale.supCustSplId == null)
            {
                if (isSale)
                {
                    if (Session.Customers.Any(x => x.custAccNo == sale.supAccNo))
                        tbSupplyMain.supCustSplId = Session.Customers.FirstOrDefault(x => x.custAccNo == sale.supAccNo)?.id;
                }
                else
                {
                    if (Session.Customers.Any(x => x.custAccNo == sale.supAccNo))
                        tbSupplyMain.supCustSplId = Session.Customers.FirstOrDefault(x => x.custAccNo == sale.supAccNo)?.id;
                }
            }
            tbSupplyMain.id = sale.id;
            tbSupplyMain.supStrId = sale.supStrId;
            tbSupplyMain.supIsCash = sale.supIsCash;
            tbSupplyMain.supBankId = sale.supBankId;
            tbSupplyMain.supBrnId = sale.supBrnId;
            tbSupplyMain.supDscntPercent = sale.supDscntPercent;
            tbSupplyMain.supDscntAmount = sale.supDscntAmount;
            tbSupplyMain.supCurrency = sale.supCurrency;
            tbSupplyMain.supCurrencyChng = sale.supCurrencyChng;
            tbSupplyMain.supAccNo = sale.supAccNo;
            tbSupplyMain.supAccName = sale.supAccName;
            tbSupplyMain.supBankAmount = sale.supBankAmount;
            tbSupplyMain.supTotal = sale.supTotal;
            tbSupplySubListOld = null; ;
            checkEditTax.Checked = (tbSupplyMain.supTaxPrice > 0 || tbSupplyMain.supTaxPercent > 0) ? true : false;
            GetSupplySubData(tbSupplyMain);
            textEditBarcodeNo.Enabled = true;
        }
        byte state1, state2;
        private void GetSupplySubData(tblSupplyMain tbSupplyMain)
        {
            using (accountingEntities posDB = new accountingEntities())
            {
                var lis = posDB.tblSupplyMains.AsQueryable().Where(x => x.supNo == tbSupplyMain.supNo && (x.supStatus == state1 || x.supStatus == state2)
               && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd).ToList();
                IEnumerable<tblSupplySub> tbSupSubList = posDB.tblSupplySubs.AsQueryable().Where(x => x.supNo == tbSupplyMain.id);
                if (lis.Count() > 0)
                {
                    List<tblSupplySub> AllSupListInRet = new List<tblSupplySub>();
                    List<tblSupplySub> AllSupListNotInRet = new List<tblSupplySub>();
                    foreach (var item in lis)
                        AllSupListInRet.AddRange(posDB.tblSupplySubs.Where(x => x.supNo == item.id && x.supBrnId == Session.CurBranch.brnId).ToList());
                    foreach (var item1 in tbSupSubList)
                    {
                        double SumQ1 = AllSupListInRet.Where(x => x.supMsur == item1.supMsur).Sum(x => x.supQuanMain ?? 0);
                        double SumQ2 = tbSupSubList.Where(x => x.supMsur == item1.supMsur).Sum(x => x.supQuanMain ?? 0);
                        if (SumQ1 < SumQ2 && !AllSupListNotInRet.Any(x => x.supMsur == item1.supMsur))
                        {
                            tblSupplySub temp = item1.ShallowCopy();
                            temp.supQuanMain = SumQ2 - SumQ1;
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
                if (this.tbSupplySubListOld == null) this.tbSupplySubListOld = new List<tblSupplySub>();
                tbSupSubList.ForEach(x =>
                {
                    if (isCredit)
                    {
                        x.supCredit = x.supDebit;
                        x.supDebit = 0;
                        if (x.supCurrency != 1)
                        {
                            x.supCredit = Convert.ToDouble(x.supDebitFrgn);
                            x.supDebitFrgn = 0;
                        }
                    }
                    else
                    {
                        x.supDebit = x.supCredit;
                        x.supCredit = 0;
                        if (x.supCurrency != 1)
                        {
                            x.supDebit = Convert.ToDouble(x.supCreditFrgn);
                            x.supCreditFrgn = 0;
                        }
                    }
                    x.supStatus = (byte)supplyType;
                    this.tbSupplySubListOld.Add(x.ShallowCopy());
                });
                if (tbSupSubList.ToList().Count() > 0)
                    SupplySubBindingSource.DataSource = tbSupSubList.ToList();

            }
        }

        public bool FunClose() => (XtraMessageBox.Show(_resource.GetString("CloseFormMssg"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes);
        private void BbiClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FunClose()) return;
                ClsPath.SaveCustomContol(this.gridView, this.Name + this.supplyType);
                ClsPath.SaveCustomContol(this.dataLayConMain, this.Name + this.supplyType);
                if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
                    (this.Parent as XtraTabPage).Dispose();
                else
                    this.ParentForm.Close();
            }
            catch (Exception)
            {

                return;
            }
        }
        string GetSaveSuccessMssg()
        {
            switch (supplyType)
            {
                case SupplyType.Purchase:
                    return string.Format(_resource.GetString("saleSuccessMssg"), GetCurSupplyMain.supNo).Replace("المبيعات", "المشتريات");
                case SupplyType.Sales:
                    return string.Format(_resource.GetString("saleSuccessMssg"), GetCurSupplyMain.supNo);
                case SupplyType.PurchaseRtrn when isDirPurRtrn:
                    return string.Format(_resource.GetString("saleRtrnSuccessMssg"), GetCurSupplyMain.supNo).Replace("المبيعات", "المشتريات الفورية");
                case SupplyType.PurchaseRtrn when !isDirPurRtrn:
                    return string.Format(_resource.GetString("saleRtrnSuccessMssg"), GetCurSupplyMain.supNo).Replace("المبيعات", "المشتريات");
                case SupplyType.SalesRtrn:
                    return string.Format(_resource.GetString("saleRtrnSuccessMssg"), GetCurSupplyMain.supNo);
                default:
                    return "";
            }
        }
        private void BbiSave_Click(object sender, EventArgs e)
        {
            if (!SaveData(MySetting.DefaultSetting.defaultPrintOnSave)) return;
            string mssg = GetSaveSuccessMssg();
            Form temp = this.ParentForm;
            tblSupplyMain tbSupplyMain = GetCurSupplyMain.ShallowCopy();
            IEnumerable<tblSupplySub> tbSupplySubList = (from s in (SupplySubBindingSource.List as IList<tblSupplySub>) select s.ShallowCopy()).ToList(); ;
            if (this.Parent.Parent is XtraTabControl c && c.TabPages.Count() > 1)
            {
                (this.Parent as XtraTabPage).Dispose();
                flyDialog.ShowDialogForm(temp, mssg, this.isNew);
            }
            else
            {
                this.ParentForm.Close();
                flyDialog.ShowDialogForm(((formSupplyMain)temp).parent1, mssg, this.isNew);
            }
            RefreschForm(tbSupplyMain, tbSupplySubList);
        }
        void RefreschForm(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            string barButton = (this.supplyType) switch
            {
                SupplyType.Sales => "barButtonItemSale",
                SupplyType.SalesRtrn => "barButtonItemSaleRtrn",
                SupplyType.Purchase => "barButtonItemPurchase",
                SupplyType.PurchaseRtrn => "barButtonItemPurchaseRtrn",
            };
            Form form = Application.OpenForms["FormMain"];
            if (form is FormMain formMain && formMain.xtraTabControl1.TabPages.Any(x => x.Name == barButton))
            {
                XtraTabPage tabPage = formMain.xtraTabControl1.TabPages?.FirstOrDefault(x => x.Name == barButton);
                if (isSale)
                {
                    if (tabPage?.Controls[0] is UCsalesInstantFeedBack uCsalesInstant)
                    {
                        formMain.xtraTabControl1.SelectedTabPage = tabPage;
                        uCsalesInstant.SetRefreshListDialog(tbSupplyMain.id, this.isNew, tbSupplyMain, tbSupplySubList);
                        uCsalesInstant.RefreshListDialog();
                    }
                }
                else
                {
                    if (tabPage?.Controls[0] is UCpurchases uCpurchases)
                    {
                        formMain.xtraTabControl1.SelectedTabPage = tabPage;
                        uCpurchases.SetRefreshListDialog(tbSupplyMain.id, this.isNew, tbSupplyMain, tbSupplySubList);
                        uCpurchases.RefreshListDialog();
                    }
                }
            }
        }
        private void BbiSaveAndNew_Click(object sender, EventArgs e)
        {
            SaveAndNew(true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MySetting.DefaultSetting.ShowResetMssg)
                if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            layoutControlGroupMain.Expanded = (supplyType == SupplyType.Sales) ? MySetting.GetPrivateSetting.supplySaleExpanded : layoutControlGroupMain.Expanded;
            ResetData();
        }

        //private void BbiPrint_Click(object sender, EventArgs e)
        //{
        //    flyDialog.WaitForm(this, 1);
        //    //var tblSupplyMain = db.SupplyMains.AsQueryable().Where(a => (a.Status == 4 || a.Status == 8 || a.Status == 11 || a.Status == 12)
        //    //   && a.BrnId == Session.CurBranch.brnId&&a.supNo== noId).ToList().FirstOrDefault();
        //    //if (tblSupplyMain != null)
        //    //{
        //    //    var tbSupplySubList = db.SupplySubs.AsQueryable().Where(x => x.BrnId == Session.CurBranch.brnId && x.supNo == tblSupplyMain.ID).ToList();
        //    //    ClsStopWatch stopWatch2 = new ClsStopWatch();
        //    //    log.Debug("PrintReportClsPrintReportStart");
        //    //    flyDialog.WaitForm(this, 0);
        //    //    Task.Run(() => ClsPrintReport.PrintSupply(tblSupplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
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
            else if (((ToolStripButton)sender).Name == btnXslPrevious.Name)
                ShowPrintInvoice(true, PrintFileType.Xlsx);
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
                List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();
                for (short i = 0; i < gridView.SelectedRowsCount; i++)
                    tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplySub);
                SupplySubBindingSource.DataSource = tbSupplySubList;
                gridView.OptionsBehavior.Editable = true;
                foreach (GridColumn item in gridView.Columns)
                {
                    if (item != colQuanMain)
                        DisableGridColumns(item);
                    else AllowGridColumns(item);
                }
                gridView.OptionsSelection.MultiSelect = false;
            }
            else if (!bbiSelect.Checked && this.tbSupplySubListOld != null)
            {
                SupplySubBindingSource.DataSource = (from o in this.tbSupplySubListOld.ToList() select o.ShallowCopy()).ToList();
                gridView.OptionsSelection.MultiSelect = true;
            }
            else
                gridView.OptionsSelection.MultiSelect = true;
        }

        private void BbiPrdPrice_Click(object sender, EventArgs e)
        {
            if (gridView.DataRowCount <= 0) return;
            string proName = Session.Products.Where(x => x.id == ((gridView.GetFocusedRowCellValue(colsupPrdName) as int?) ?? 0)).Select(x => x.prdName).FirstOrDefault();
            XtraMessageBox.Show($"{_resource.GetString("PrdPrice")} {proName} {gridView.GetFocusedRowCellValue(colsupPrice)}");
        }

        private void BbiEditPrice_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as tblSupplySub;
            if (row != null)
            {
                if (isSale)
                    new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupSalePrice))).ShowDialog();
                else new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupPrice))).ShowDialog();
            }
        }

        private void BbiEditQuantity_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as tblSupplySub;
            if (row != null)
                new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colQuanMain))).ShowDialog();
        }

        private void bsiPaidCreditShortcut_Click(object sender, EventArgs e)
        {
            textEditPaidCreditCard.Focus();
            SetECRamout();
            if (!MySetting.DefaultSetting.isSendToECR) return;
            SendECR();
        }

        private void bbiSaveAndNewNoPrint_Click(object sender, EventArgs e)
        {
            SaveAndNew(false);
        }
        private void GridView_RowCountChanged(object sender, EventArgs e)
        {
            GridView_RowUpdated(sender, null);

        }

        private void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            tblSupplyMain sale = GetCurSupplyMain;
            if (sale != null)
            {
                var items = SupplySubBindingSource.List as IList<tblSupplySub>;
                if (items == null) return;
                if (items.Count() > 0)
                {
                    sale.supTotal = items.Sum(x => (x.supQuanMain ?? 0) * ((isSale ? x.supSalePrice : x.supPrice) ?? 0));
                    sale.supDscntAmount = items.Sum(x => x.supDscntAmount ?? 0);
                    sale.supTaxPrice = items.Sum(x => x.supTaxPrice ?? 0);
                    sale.supTaxPercent = (byte)items.Max(x => x.supTaxPercent ?? 0);
                    if (sale.supTotal > 0)
                        sale.supDscntPercent = ((sale.supDscntAmount / sale.supTotal) * 100d);
                    sale.TotalAfterDiscount = (sale.supTotal - (sale.supDscntAmount ?? 0));
                    sale.net = (sale.TotalAfterDiscount ?? 0) + (sale.supTaxPrice ?? 0);
                    CalculatePaid(sale);
                }
                else
                {
                    sale.supTotal = 0;
                    sale.supTaxPrice = 0;
                    sale.TotalAfterDiscount = 0;
                    sale.supDscntAmount = 0;
                    sale.supBankAmount = 0;
                    sale.supDscntPercent = 0;
                    sale.supTotalFrgn = 0;
                    sale.net = 0;
                    sale.paidCash = 0;
                    sale.remin = 0;
                    spinEditTotalFinalDecimal.EditValue = sale.net;
                    SpinEditTotalPay.ResetText();
                }
            }
            SaveDetailInvoToXmlFile();
        }
        private void CalculatePaid(tblSupplyMain sale)
        {
            if (sale.supIsCash == 1)
            {
                if (isRtrn&& sale.paidCash == 0 && (sale.supBankAmount ?? 0) > 0)
                        sale.supBankAmount = sale.net;
                else 
                    sale.paidCash = sale.net - (sale.supBankAmount ?? 0);
            }
            else
                sale.supBankAmount = sale.paidCash = 0;
            sale.remin = sale.net - (sale.supBankAmount ?? 0) - (sale.paidCash ?? 0);
            SpinEditTotalPay.EditValue = (sale.supBankAmount ?? 0) + (sale.paidCash ?? 0);
            labelTotalTaxDecimal.EditValue = sale.supTaxPrice;
            spinEditTotalFinalDecimal.EditValue = sale.net;
        }
        private void BoxNoLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain;
            tbSupplyMain.supBoxId = Convert.ToInt16(editor.GetColumnValue("ID"));
            tbSupplyMain.supCurrency = Convert.ToByte(editor.GetColumnValue("Currencie"));
        }
        private void BankLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain;
            tbSupplyMain.supBankId = Convert.ToInt16(editor.GetColumnValue("ID"));
            tbSupplyMain.supCurrency = Convert.ToByte(editor.GetColumnValue("Currencie"));
        }
        private void CustNoSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = GetCurSupplyMain;
            if (tbSupplyMain == null) return;
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null|| !(editor?.EditValue is int)) return;
            if (searchLookUpEdit1View.GetFocusedRowCellValue("ID") == null)
                return;
            tbSupplyMain.supCustSplId = Convert.ToInt32(searchLookUpEdit1View.GetFocusedRowCellValue("ID"));
            if (tbSupplyMain.supIsCash == 2)
                tbSupplyMain.supCurrency = Convert.ToByte(searchLookUpEdit1View.GetFocusedRowCellValue("Currency"));
            if (isCustomer)
            {
                this.tbCustomer = tbSupplyMain.supCustSplId != null ? Session.Customers.FirstOrDefault(x => x.id == tbSupplyMain.supCustSplId) : null;
                var balance = searchLookUpEdit1View.GetFocusedRowCellValue("Balance").ToString();
                if (balance.Contains("دائن"))
                {
                    CustBalance = double.Parse(balance.Substring(0, balance.IndexOf(" ")));
                    CustBalance = CustBalance * -1;
                }
                else CustBalance = 0;
                if ((this.tbCustomer?.custNo ?? 0) > 0)
                    tbSupplyMain.supRefNo = this.tbCustomer.custNo.ToString();
            }
        }
        double CustBalance = 0;
        private void StrIdLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            InitPrdBindingSourceData((StrIdLookUpEdit.EditValue as short?) ?? 0);
        }
        tblSupplyMain GetCurSupplyMain => SupplyMainBindingSource.Current as tblSupplyMain;
        private void RadioGroupIsCash_EditValueChanged(object sender, EventArgs e)
        {
            var tbSupplyMain = GetCurSupplyMain;
            if (tbSupplyMain == null || ((radioGroupIsCash.EditValue as byte?) ?? 0) == 0) return;
            tbSupplyMain.supIsCash = (radioGroupIsCash.EditValue as byte?) ?? 0;
            supIsCash();
            ItemFornotDate.Enabled = tbSupplyMain.supIsCash == 2 ? true : false;
            CalculatePaid(tbSupplyMain);
            //ItemFornotDate.Visibility = (tbSupplyMain.supIsCash == 2 && !MySetting.DefaultSetting.PayPartInvoValue) ? LayoutVisibility.Never : LayoutVisibility.Always;
        }

        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("Name") == null) return;
            var tbSupplyMain = GetCurSupplyMain;
            if (tbSupplyMain != null)
            {
                if (tbSupplyMain.supCurrency > 1)
                {
                    tbSupplyMain.supCurrency = Convert.ToByte(editor.GetColumnValue("ID"));
                    tbSupplyMain.supCurrencyChng = Convert.ToInt16(editor.GetColumnValue("Change"));
                    CurrencyChngTextEdit.EditValue = editor.GetColumnValue("Change");
                    ItemForCurrencyChng.Enabled = true;
                }
                else
                {
                    tbSupplyMain.supCurrencyChng = null;
                    CurrencyChngTextEdit.EditValue = null;
                    ItemForCurrencyChng.Enabled = false;
                }
            }
        }
        //private bool ValidateDscntAmount(double discountPercent)
        //{
        //    if (Session.CurrentUser.id == 1) return true;
        //    if (!this.clsTbDscntPrmsion.IsDscntUserFound(Session.CurrentUser.id)) return ValidateDscntPermission();
        //    if (!this.clsTbDscntPrmsion.IsDscntUserPermission(Session.CurrentUser.id))
        //    {
        //        ClsXtraMssgBox.ShowError($"عذراً ليس لديك صلاحية الخصم!");
        //        return false;
        //    }
        //    if (this.clsTbDscntPrmsion.GetDscntAmountByUsrId(Session.CurrentUser.id) >= discountPercent)
        //    {
        //        ClsXtraMssgBox.ShowError("عذراً لقد تجاوزت الحد المسموح للخصم!");
        //        return false;
        //    }
        //    return false;
        //}
        //ClsTblDscntPrmsion clsTbDscntPrmsion = new ClsTblDscntPrmsion();
        //private bool ValidateDscntPermission()
        //{


        //    return false;
        //}

        private void DscntAmountTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            tblSupplyMain tblSupplyMain = GetCurSupplyMain;
            if (tblSupplyMain == null || e.NewValue.ToString() == string.Empty)
            {
                e.Cancel = true;
                return;
            }
            bool per = ((BaseEdit)sender).Name == "DscntAmountTextEdit";
            var val = double.Parse(e.NewValue.ToString());
            double presentValue = per ? ((val / tblSupplyMain.supTotal) * 100) : val;
            if (!ValidateDscntAmount(presentValue))
            {
                e.Cancel = true;
                return;
            }
            if (per)
            {
                tblSupplyMain.supDscntPercent = ((val / tblSupplyMain.supTotal) * 100);
                tblSupplyMain.supDscntAmount = val;
            }
            else
            {
                tblSupplyMain.supDscntPercent = val;
                tblSupplyMain.supDscntAmount = tblSupplyMain.supTotal * (val / 100);
            }
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);
            var dpres = tblSupplyMain.supDscntPercent;
            foreach (var item in curList)
            {
                item.supDscntPercent = dpres;
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
            StrIdLookUpEdit.IntializeData(Session.tblStore.Where(x => x.strBrnId == CurBranch.brnId).ToList());
         
            customerBindingSource.DataSource = isCustomer ? Session.GetTablName(Session.CustomrtWhithBalances) : GetTablName(Session.Suppliers);
            BoxNoLookUpEdit.IntializeData(Boxes.Where(x=>x.boxBrnId==CurBranch.brnId).ToList());
            UserLookUpEdit.IntializeData(Session.tblUser);
            BankLookUpEdit.IntializeData(Banks.Where(x => x.bankBrnId == CurBranch.brnId).ToList());
            supCurrTextEdit.IntializeData(Session.Currencies);
            this.tax = MySetting.GetPrivateSetting.taxDefault;
            checkEditTax.Checked = this.tax > 0;
            checkEdit1.Checked = MySetting.DefaultSetting.IsInvoiceRound;
            checkEditPrdLastPrice.Checked = MySetting.GetPrivateSetting.supPrdLastPrice;
        }
        private void InitData(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj)
        {
            
            if (obj == null)
            {
                InitSupplyMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
            }
            else
            {
                if (obj.supIsCash == 1 && obj.supBoxId == null)
                {
                    var box = Session.Boxes?.FirstOrDefault(x => x.boxAccNo == obj.supAccNo);
                    obj.supBoxId = box?.id;
                }
                checkEditTax.Checked = (obj.supTaxPrice > 0) ? true : false;
                SupplyMainBindingSource.DataSource = obj;
                this.totalFinalOld = obj.net;
                SupplySubBindingSource.DataSource = subObj;
                this.tbSupplySubListOld = (from s in subObj select s.ShallowCopy()).ToList();
                DisableItems();
                SetRibbonButtonsVisisbility();
                if (isSale)
                {
                    EnableOrDisyble(false);
                    this.tbCustomer = Session.Customers.FirstOrDefault(x => x.id == obj.supCustSplId);
                }
            }

        }

        public void EnableOrDisyble(bool state)
        {
            btnEditPrice.Enabled = btnEditQuantity.Enabled = btnSaveAndNewNoPrint.Enabled
                 = btnReset.Enabled = state;
            gridView.OptionsBehavior.Editable = btnDeleteRow.Enabled = BtnAddFraction.Enabled = BtnDscnFraction.Enabled = state;
            layoutControlGroupDiscount.Enabled = DscntAmountTextEdit.Enabled = textEditBarcodeNo.Enabled = state;
            checkEditTax.Enabled = state;
            radioGroupIsCash.Enabled = state;
            StrIdLookUpEdit.Enabled = state;
        }
        private void InitSupplyMainObj(bool reset = false)
        {
            tblSupplyMain tblSupplyMain = new tblSupplyMain()
            {
                supDate = DateTime.Now,
                supStrId = (short)MySetting.DefaultSetting.defaultStrId,
                supUserId = Session.CurrentUser.id,
                supBrnId = Session.CurBranch.brnId,
                supStatus = (byte)supplyType,
                supTotal = 0,
                supTotalFrgn = 0,
                net = 0,
                supTaxPrice = 0,
                supDscntAmount = 0,
                supDscntPercent = 0,
                supIsCash = 1,
                EnterDate = DateTime.Now,
                TotalAfterDiscount = 0,
                supTaxPercent = (byte)this.tax,
                SendToserver = false,
                IsDelete = false,
            };
            SetSupplyNo(tblSupplyMain);
            var box = Session.Boxes?.FirstOrDefault(x => x.boxAccNo == MySetting.DefaultSetting.defaultBox);
            if (box != null)
            {
                tblSupplyMain.supBoxId = box?.id;
                tblSupplyMain.supCurrency = box?.boxCurrency ?? 1;
            }
            SupplyMainBindingSource.DataSource = tblSupplyMain;
            InitSupplySubGridObj();
            if (supplyType == SupplyType.Purchase)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<tblSupplySub>));
                    lis.Clear();
                    if (File.Exists(folderPath + @$"\{tblSupplyMain.supNo}.xml") && !reset)
                    {
                        using (FileStream stream = File.OpenRead(folderPath + @$"\{tblSupplyMain.supNo}.xml"))
                        {
                            if (stream.Length > 0)
                                lis = (List<tblSupplySub>)serializer.Deserialize(stream);
                            stream.Close();
                        }
                    }
                    lis = lis.Where(x => x.supNo == tblSupplyMain.supNo).ToList();
                    SupplySubBindingSource.DataSource = lis;
                }
                catch (Exception ex)
                {
                    ClsXtraMssgBox.ShowError(ex.Message);
                    return;
                }
            }
        }
        private readonly string folderPath = @$"{ClsDrive.Path}:\B-Tech\TempSupplyRcpt{Session.CurrentYear.fyName}";
        List<tblSupplySub> lis = new List<tblSupplySub>();
        public void SaveDetailInvoToXmlFile()
        {
            if (supplyType != SupplyType.Purchase) return;
            if (!isNew) return;
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(List<tblSupplySub>));
                using (TextWriter Filestream = new StreamWriter(folderPath + @$"\{GetCurSupplyMain.supNo}.xml"))
                {
                    //TextWriter Filestream = new StreamWriter(folderPath + @$"\{GetCurSupplyMain.supNo}.xml");
                    lis.ForEach(x => x.supNo = GetCurSupplyMain.supNo);
                    serialiser.Serialize(Filestream, lis);
                    Filestream.Close();
                }
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
            }
        }
        private void InitPrdBindingSourceData(short supStrId)
        {
            if (supStrId == 0) return;
            var tbProductList = (from prdQuantity in Session.ProductQunatities
                                 where prdQuantity.prdStrId == supStrId
                                 join prd in Session.Products
                                 on prdQuantity.prdId equals prd.id
                                 select prd).ToList();
            ProductBindingSource.DataSource = tbProductList;

            var q1 = (from prd in tbProductList
                      group prd by prd.id into prdGrp
                      join prdMsur in Session.tblPrdPriceMeasurment
                      on prdGrp.Key
                      equals prdMsur.ppmPrdId
                      where prdMsur.ppmDefault == true
                      select new
                      {
                          supPrdId = prdGrp.Key,
                          prdPrice = isSale ? myFunaction.GetMinSalePrice(prdGrp.FirstOrDefault().prdPriceTax, prdMsur) : prdMsur.ppmPrice,
                          PrdMsurName = prdMsur.ppmMsurName,
                      }).Select(x => new { x.supPrdId, x.prdPrice, x.PrdMsurName });
            this.listPrdMsurName = q1.GroupBy(x => x.supPrdId).ToDictionary(x => x.Key, y => y.FirstOrDefault().PrdMsurName);
            this.listPrdPriceDic = q1.GroupBy(x => x.supPrdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.prdPrice);
        }
        private void InitForm()
        {
            bbiSelect.Visible = isRtrn;
            bbiPriceOffer.Visible = isNew;
           
            if (MySetting.GetPrivateSetting.LangEng)
            {
                colprdSalePrice.Caption = isSale ? "Sale Price" : "Buy Price";
                colsupCustSplId.Caption = isSale ? "Customer Name" : "Supplier Name";
                bbiPriceOffer.Text = isSale ?"Price \nOffer(F10)" :"Invoice \n Order(F10)";
                ItemForsupCustNo.Text = isCustomer ? "Customer:" : "Supplier:";
            }
            else
            {
                colprdSalePrice.Caption = isSale ? "سعر البيع" : "سعر الشراء";
                colsupCustSplId.Caption = isSale ? "اسم العميل" : "اسم المورد";
                bbiPriceOffer.Text = isSale ? "عروض \nالأسعار(F10)": "فواتير\nالطلبات(F10)";
                ItemForsupCustNo.Text = isCustomer ?"العميل" : "المورد:";
            }
            ItemForUser.Enabled = (this.supplyType == SupplyType.SalesRtrn&&Session.CurrentUser.id==1);
            ItemForPoNumber.Enabled = isSale;
            colprdQuanAvlb.Visible = (supplyType == SupplyType.Sales);
            colBalance.Visible = isSale;
            if (isRtrn)
            {
                ItemForPrdLastPrice.Visibility = LayoutVisibility.Never;
                byte supType1 = (this.supplyType == SupplyType.SalesRtrn) ? (byte)8 : (this.supplyType == SupplyType.PurchaseRtrn) ? (byte)7 : (byte)0;
                using (accountingEntities posDB = new accountingEntities())
                {
                    SupplyMainBindingSourceEditor.DataSource = posDB.tblSupplyMains.Where(x => x.supDate >= Session.CurrentYear.fyDateStart
                    && (x.supStatus == supType1) && !x.IsDelete && x.supBrnId == Session.CurBranch.brnId).OrderByDescending(x=>x.supDate).ToList();
                }
                gridView.OptionsSelection.MultiSelect = true;
                ItemForsupNo.Text = MySetting.GetPrivateSetting.LangEng ? "Return invoice number :": "رقم فاتورة المردود :";
                btnReset.Visible = btnEditPrice.Visible = false;
                btnSaveAndNew.Visible = false;
                textEditBarcodeNo.Enabled = false;
                checkEditTax.Enabled = false;
                ItemForSalesNo.Text = (this.supplyType == SupplyType.PurchaseRtrn) ?(MySetting.GetPrivateSetting.LangEng? "Purchase invoice": "فاتورة المشتريات:") : 
                    (MySetting.GetPrivateSetting.LangEng ? "Sale invoice" : "فاتورة المبيعات:");
                ItemForSalesNo.Visibility = LayoutVisibility.Always;
                ItemForSalesNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
                ItemForBoxNo.Enabled = ItemForsupCustNo.Enabled = false;
                layoutControlGroupMain.ExpandButtonVisible = layoutControlGroupMain.ExpandOnDoubleClick = false;
                gridView.Columns.ForEach(item => item.OptionsColumn.AllowEdit = false);
            }
            else if (isDirPurRtrn)
            {
                ItemForsupNo.Text = MySetting.GetPrivateSetting.LangEng ? "Return invoice number :" : "رقم فاتورة المردود :";
                checkEditTax.Enabled = false;
            }
            if (MySetting.DefaultSetting.ShowlayoutControlCarData)
            {
                ItemForPeriodFrome.Visibility = ItemForPeriodTo.Visibility = ItemForPaymentTeam.Visibility = ItemForRegistrationNumber.Visibility
                    = ItemForShippingDate.Visibility = ItemForDeliveryDate.Visibility = ItemForFieldNumber.Visibility = LayoutVisibility.Never;
                ItemForPlateNumber.Text = MySetting.GetPrivateSetting.LangEng ? "Plate Number" : "رقم اللوحة";
                ItemForCounterNumber.Text = "رقم العداد";
                ItemForCarType.Text = "نوع السيارة";
            }
            else if (MySetting.GetPrivateSetting.LangEng)
            {
                ItemForPlateNumber.Text = "Order No.";
                ItemForCounterNumber.Text = "contract Number";
                ItemForCarType.Text = @"Site \ Location";
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
            double net = Convert.ToDouble(spinEditMonyFinal.Value);
            if (net == 0) return;
            var tblSupplyMain = GetCurSupplyMain;
            var total = tblSupplyMain.supTotal;
            var totalFainl = tblSupplyMain.net;
            var Tax = checkEditTax.Checked ? this.tax : 0;
            var discount = MySetting.DefaultSetting.CalcTaxAfterDiscount ? (1 - (net / (total * (1 + (Tax / 100))))) : ((totalFainl - net) / total);
            spinEditMonyFinal.EditValue = null;
            if (!ValidateDscntAmount(discount * 100)) return;
            supDscntPercentTextEdit.EditValue = discount * 100;
            GetCurSupplyMain.supDscntPercent = discount * 100;
            gridView.RefreshData();
        }
        ClsTblDscntPrmsion clsTbDscntPrmsion = new ClsTblDscntPrmsion();
        private bool ValidateDscntAmount(double discountPercent)
        {
            if (Session.CurrentUser.id == 1) return true;
            if (!this.clsTbDscntPrmsion.IsDscntUserFound(Session.CurrentUser.id)) return ValidateDscntPermission();
            if (!ValidateDscntPermission()) return false;
            if (this.clsTbDscntPrmsion.GetDscntAmountByUsrId(Session.CurrentUser.id) >= discountPercent) return true;
            supDscntPercentTextEdit.EditValue = 0;
            DscntAmountTextEdit.EditValue = 0;
            GetCurSupplyMain.supDscntPercent = 0;
            GetCurSupplyMain.supDscntAmount = 0;
            ClsXtraMssgBox.ShowError("عذراً لقد تجاوزت الحد المسموح للخصم!");
            return false;
        }

        private bool ValidateDscntPermission()
        {
            if (this.clsTbDscntPrmsion.IsDscntUserPermission(Session.CurrentUser.id)) return true;
            GetCurSupplyMain.supDscntPercent = 0;
            GetCurSupplyMain.supDscntAmount = 0;
            supDscntPercentTextEdit.EditValue = 0;
            DscntAmountTextEdit.EditValue = 0;
            ClsXtraMssgBox.ShowError($"عذراً ليس لديك صلاحية الخصم!");
            return false;
        }
        private void CheckEditTax_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (isRtrn) return;
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

        private void supIsCash()
        {
            var tbSupplyMain = GetCurSupplyMain;
            if (tbSupplyMain != null)
            {
                if (MySetting.GetPrivateSetting.LangEng)
                    ItemForsupDesc.Text = (GetCurSupplyMain.supIsCash == 1 || GetCurSupplyMain.supIsCash == 3) ? "The Name :" : "Description :";
                else
                    ItemForsupDesc.Text = (GetCurSupplyMain.supIsCash == 1 || GetCurSupplyMain.supIsCash == 3) ? "الاسم :" : "البيان :";
                if (isNew)
                    switch (tbSupplyMain.supIsCash)
                    {
                        case 1:
                            tbSupplyMain.supBoxId = tbSupplyMain.supBoxId == null ? (short)MySetting.DefaultSetting.defaultBox : tbSupplyMain.supBoxId;
                            tbSupplyMain.supBankId = tbSupplyMain.supBankId == null ? (short)MySetting.DefaultSetting.defaultBank : tbSupplyMain.supBankId;
                            if (tbSupplyMain.supBankAmount > 0 && tbSupplyMain.paidCash <= 0)
                                tbSupplyMain.supCurrency = Session.Banks.Where(x => x.id == tbSupplyMain.supBankId).Select(x => x.bankCurrency).FirstOrDefault().GetValueOrDefault();
                            else tbSupplyMain.supCurrency = Session.Boxes.Where(x => x.id == tbSupplyMain.supBoxId).Select(x => x.boxCurrency).FirstOrDefault().GetValueOrDefault();
                            layoutControlGroupPayCard.Visibility = ItemForBoxNo.Visibility = itemForPaidCash.Visibility = ItemForBankId.Visibility = itemForPaidCreditCard.Visibility = LayoutVisibility.Always;
                            break;
                        case 2:
                            //if (isCustomer)
                            //{
                            //    var cus = Session.Customers.FirstOrDefault(x => x.id == tbSupplyMain.supCustSplId);
                            //    if(cus ==null&& Session.Customers.Count>0) 
                            //        cus= Session.Customers.FirstOrDefault();
                            //    tbSupplyMain.supCustSplId = cus?.id;
                            //    tbSupplyMain.supCurrency = (cus?.custCurrency)??1;
                            //}
                            //else
                            //{
                            //    var cus = Session.Suppliers.FirstOrDefault(x => x.id == tbSupplyMain.supCustSplId);
                            //    if (cus == null && Session.Suppliers.Count > 0)
                            //        cus = Session.Suppliers.FirstOrDefault();
                            //    tbSupplyMain.supCustSplId = cus?.id;
                            //    tbSupplyMain.supCurrency = (cus?.splCurrency) ?? 1;
                            //}
                            if (!MySetting.DefaultSetting.PayPartInvoValue) tbSupplyMain.supBoxId = tbSupplyMain.supBankId = null;
                            layoutControlGroupPayCard.Visibility = ItemForBoxNo.Visibility = itemForPaidCash.Visibility = ItemForBankId.Visibility = itemForPaidCreditCard.Visibility = MySetting.DefaultSetting.PayPartInvoValue ? LayoutVisibility.Always : LayoutVisibility.Never;
                            break;
                        default:
                            break;
                    }
            }
        }
        private void SetWeightQuantity(int rowHandle)
        {
            if (!this.productData.PrdMeasurment.ppmWeight) return;

            string quanString = null;
            try
            {
                //quanString = this.barcodeNo.Substring(MySetting.DefaultSetting.barcodeWeightNo + MySetting.GetPrivateSetting.barcodeWeightPrdNo, MySetting.GetPrivateSetting.barcodeWeightQuanNo);
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError("عذراً رقم الباركود غير مسجل بشكل صحيح!" + $"\n\n{ex.Message}");
            }
            if (double.TryParse(quanString, out double quan)) gridView.SetRowCellValue(rowHandle, colQuanMain, quan);
        }
        //private double SetAveragePrdPrice(int supPrdId)
        //{
        //    if (this.productData.PrdMeasurment.ppmManufacture) return 0;
        //    //var tbPrdPriceQuan =new AveragePrdPrice(supPrdId).GetAverProPrice;
        //    //if (tbPrdPriceQuan == null) return 0;
        //    //return (this.productData.PrdMeasurment.ppmStatus) switch
        //    //{
        //    //    1 => tbPrdPriceQuan.pr1,
        //    //    2 => tbPrdPriceQuan.pr2,
        //    //    3 => tbPrdPriceQuan.pr3,
        //    //};
        //}
        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (!this.isNew || this.supplyType != SupplyType.Sales || gridView.DataRowCount == 0) return;
            if (!this.listPrdQuantDic.TryGetValue(e.RowHandle, out double quantity)) return;
          
            if (quantity <= Session.ProductColors.Where(x => x.colId == 3).Select(x => x.colQuan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.colId == 3).Select(x => x.colHtml).FirstOrDefault());
            if (quantity <= Session.ProductColors.Where(x => x.colId == 2).Select(x => x.colQuan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.colId == 2).Select(x => x.colHtml).FirstOrDefault());
            if (quantity <= Session.ProductColors.Where(x => x.colId == 1).Select(x => x.colQuan).FirstOrDefault())
                e.Appearance.BackColor = ColorTranslator.FromHtml(Session.ProductColors.Where(x => x.colId == 1).Select(x => x.colHtml).FirstOrDefault());
            tblSupplySub row = gridView.GetRow(e.RowHandle) as tblSupplySub;
            if (row != null)
            {
                if (MySetting.DefaultSetting.defaultSalePriceFloar)
                {
                    bool Ptax = Session.Products.FirstOrDefault(x => x.id == row.supPrdId)?.prdPriceTax ?? false;
                    double prdMinPrice = myFunaction.GetMinSalePrice(Ptax, Session.tblPrdPriceMeasurment?.FirstOrDefault(x=>x.ppmId== row.supMsur));
                    double salePrice = row.supSalePrice??0;
                    if (salePrice < prdMinPrice)
                        e.Appearance.BackColor = System.Drawing.Color.IndianRed;
                }
                if ((row.supSalePrice ?? 0) < (row.supPrice ?? 0) &&(MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.ShowWarning
                 || MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent))
                    e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            }
            e.HighPriority = true;
        }

        private double GetSalePrice()
        {
            bool Ptax = this.productData?.tblProduct?.prdPriceTax ?? false;
            if (this.tbCustomer == null || Convert.ToByte(this.tbCustomer.custSalePrice) == 0)
                return myFunaction.GetSalePrice(Ptax, this.productData.PrdMeasurment);

            switch ((SalePrice)this.tbCustomer.custSalePrice)
            {
                case SalePrice.PurchasePrice:
                    return Convert.ToDouble(this.productData.PrdMeasurment.ppmPrice);
                case SalePrice.SalePrice:
                    return myFunaction.GetSalePrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.MinSalePrice:
                    return myFunaction.GetMinSalePrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.RetailPrice:
                    return myFunaction.GetRetailPrice(Ptax, this.productData.PrdMeasurment);
                case SalePrice.BatchPrice:
                    return myFunaction.GetBatchPrice(Ptax, this.productData.PrdMeasurment);
                default:
                    return myFunaction.GetSalePrice(this.productData.tblProduct.prdPriceTax, this.productData.PrdMeasurment);
            }
        }

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Msur")
                e.RepositoryItem = repositoryItemLookUpEditMeasurment;
        }

        private void CalculateAllInGridViewRow(tblSupplySub row)
        {
            double price = 0;
            bool SaleOrPurTax;
            if (row != null)
            {
                if (isSale)
                {
                    price = (row.supSalePrice ?? 0) * (row.supQuanMain ?? 0);
                    SaleOrPurTax = (this.productData?.tblProduct?.prdSaleTax).GetValueOrDefault();
                }
                else
                {
                    price = (row.supPrice ?? 0) * (row.supQuanMain ?? 0);
                    SaleOrPurTax = (this.productData?.tblProduct?.prdPurchaseTax).GetValueOrDefault();
                }
                row.supDscntAmount = price * (row.supDscntPercent / 100d);
                if (checkEditTax.Checked && (!SaleOrPurTax && price != 0))
                {
                    row.supTaxPercent = (byte)(!this.productData.tblProduct.prdSaleTax ? this.tax : 0);
                    row.supTaxPrice = MySetting.DefaultSetting.CalcTaxAfterDiscount ? ((price - (row.supDscntAmount ?? 0)) * row.supTaxPercent / 100d) : (price * row.supTaxPercent / 100d);
                }
                else
                {
                    row.supTaxPrice = 0;
                    row.supTaxPercent = 0;
                }
                if (isCredit)
                    row.supCredit = row.supTaxPrice + price - (row.supDscntAmount ?? 0);
                else
                    row.supDebit = row.supTaxPrice + price - (row.supDscntAmount ?? 0);
            }
            gridView.RefreshData();
            GridView_RowUpdated(null, null);
        }
        //double GetConversionByMainUnit(tblPrdPriceMeasurment prMea)
        //{ 
        //    if (prMea == null) return 1;
        //    //if(prMea.ppmStatus==2) return prMea.ppmConversion ?? 1;
        //    var listMesur = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == prMea.ppmPrdId);
        //    switch (listMesur.Count())
        //    {
        //        //case 1:
        //        //    return prMea.ppmConversion ?? 1;
        //        //case 2:
        //        //    return (listMesur.FirstOrDefault(x => x.ppmStatus == 2)?.ppmConversion) ?? 1;
        //        //case 3:
        //        //    return (listMesur.FirstOrDefault(x => x.ppmStatus == 2)?.ppmConversion ?? 1) * (listMesur.FirstOrDefault(x => x.ppmStatus == 3)?.ppmConversion ?? 1);
        //        default:
        //            return prMea.ppmConversion ?? 1;
        //    }
        //}
        private void InitNewRowObject(tblSupplySub tblSupplySub, double QuanMainOrPriceWighit = 1, bool ProIsWaghit = false)
        {
            if (this.productData != null)
            {
                if (checkEditTax.Checked)
                {
                    if (isSale)
                        tblSupplySub.supTaxPercent = (byte)(!this.productData.tblProduct.prdSaleTax ? this.tax : 0);
                    else
                        tblSupplySub.supTaxPercent = (byte)(!this.productData.tblProduct.prdPurchaseTax ? this.tax : 0);
                }
                tblSupplySub.supPrdBarcode = this.productData.tblBarcode?.brcNo;
                tblSupplySub.supMsur = this.productData?.PrdMeasurment?.ppmId;
                tblSupplySub.supPrdId = this.productData.tblProduct.id;
                tblSupplySub.supPrdNo = this.productData.tblProduct.prdNo;
                tblSupplySub.supPrdName = this.productData.tblProduct.prdName;
                tblSupplySub.supDesc = this.productData.tblProduct.prdDesc;
                tblSupplySub.Conversion = (this.productData.PrdMeasurment?.ppmConversion ?? 1);
                tblSupplySub.StoreID = GetCurSupplyMain.supStrId;
                tblSupplySub.supPrice = GetPrdPrice(this.productData.PrdMeasurment);// SetAveragePrdPrice(this.productData.tblProduct.ID);
                if (ProIsWaghit)
                {
                    tblSupplySub.supSalePrice = (MySetting.DefaultSetting.ReadMode == 0) ? GetSalePrice() : QuanMainOrPriceWighit;
                    tblSupplySub.supQuanMain = (MySetting.DefaultSetting.ReadMode == 0) ? QuanMainOrPriceWighit : 1;
                }
                else
                {
                    tblSupplySub.supSalePrice = GetSalePrice();
                    tblSupplySub.supQuanMain = QuanMainOrPriceWighit;
                }
                tblSupplySub.supCurrency = this.productData.GroupStr.grpCurrency;
                tblSupplySub.supAccNo = this.productData.GroupStr.grpAccNo;
                var acc = Session.Accounts.FirstOrDefault(x => x.accNo == tblSupplySub.supAccNo);
                tblSupplySub.supAccName = acc != null ? acc.accName : this.productData.GroupStr.grpName;
                tblSupplySub.supStatus = (byte)supplyType;
            }
            CalculateAllInGridViewRow(tblSupplySub);
        }
        
        private double GetPrdPrice(tblPrdPriceMeasurment tbPrdMsur)
        {
            try
            {
                if (tbPrdMsur == null) 
                    return 0;

                if (!MySetting.GetPrivateSetting.supPrdLastPrice) 
                    return tbPrdMsur.ppmPrice ?? 0;

                var ff = Session.buyPrices.OrderByDescending(x => x.supDate).FirstOrDefault(x => x.supPrdId == tbPrdMsur.ppmPrdId);
                if (ff == null)
                    return tbPrdMsur.ppmPrice ?? 0;
                else 
                    return ((ff?.supPrice ?? 0) / ff.Converion) * (tbPrdMsur.ppmConversion ?? 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        tblSupplySub temp = new tblSupplySub();
        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            tblSupplySub row = SupplySubBindingSource.Current as tblSupplySub;
            double quantity;
            if (row != null)
            {
                switch (e.Column.FieldName)
                {
                    case nameof(temp.supQuanMain) when(e.Value != null):
                        if (double.TryParse(e.Value?.ToString(), out quantity))
                        {
                            if (isRtrn && this.tbSupplySubListOld != null)
                            {
                                var t = this.tbSupplySubListOld.FirstOrDefault(x => x.supPrdBarcode == row.supPrdBarcode);
                                double Q = (t != null ? t.supQuanMain ?? 0 : 0);
                                if (Q < quantity)
                                {
                                    MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة " + (isSale ? "البيع" : "الشراء"));
                                    row.supQuanMain = Q;
                                    gridView.SetFocusedRowCellValue(colQuanMain, Q);
                                }
                            }
                        }
                        break;
                    case nameof(temp.supSalePrice) when (e.Value != null):
                        row.supSalePrice = double.Parse(e.Value?.ToString());
                        ValidMinSalePrice(row);
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supCredit):
                        ValidMinSalePrice(row);
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supDebit):
                        CalculateAllInGridViewRow(row);
                        break;
                }
            }
            SaveDetailInvoToXmlFile();
        }
        void ValidMinSalePrice(tblSupplySub row)
        {
            if (!isSale) return;
            bool Ptax = this.productData?.tblProduct?.prdPriceTax ?? false;
            var pr = Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == (row.supMsur ?? 0));
            if (pr == null) return;
            double prdPrice = myFunaction.GetMinSalePrice(Ptax, pr);
            if (row.supSalePrice < prdPrice && MySetting.DefaultSetting.defaultSalePriceFloar)
            {
                string mess = $"عذرا لقد تجاوزت حد سعر البيع الأدنى! \n\nسعر البيع: {row.supSalePrice} \nسعر البيع الأدنى: {prdPrice}";
                ClsXtraMssgBox.ShowError(mess);
                //switch ()
                //{
                //    case (byte)WarningLevels.ShowWarning:
                //        ClsXtraMssgBox.ShowError(mess);
                //        return;
                //    case (byte)WarningLevels.Prevent:
                //        ClsXtraMssgBox.ShowError(mess);
                //        gridView.DeleteSelectedRows();
                //        return;
                //}
            }
            prdPrice = (pr?.ppmPrice) ?? 0;
            if (row.supSalePrice < prdPrice)
            {
                string mess = $"عذرا سعر البيع اقل من سعر الشراء ! \n\nسعر البيع: {row.supSalePrice} \nسعر الشراء: {prdPrice}";
                switch (MySetting.DefaultSetting.tsDefaultSalePriceAndBuy)
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
            var pro = FormDialogPrdSearch.gridViewSrchPrd.GetFocusedRow() as tblProduct;
            if (pro != null)
                GridView_CellValueChanging(gridView, new CellValueChangedEventArgs(-2147483647, colsupPrdNo, pro.id));
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
                double quantity, discount;
                tblSupplySub row = SupplySubBindingSource.Current as tblSupplySub;
                if (row == null && e.Column.FieldName != nameof(temp.supPrdId)) return;
                switch (e.Column.FieldName)
                {
                    case nameof(temp.supPrdId):
                        if (row == null || e.RowHandle < 0)
                        {
                            gridView.AddNewRow();
                            gridView.UpdateCurrentRow();
                        }
                        if (!GetData(null, ((e.Value as int?) ?? 0))) return;
                        if ((this.productData?.GroupStr?.grpAccNo ?? 0) == 0)
                        {
                            ClsXtraMssgBox.ShowError(_resource.GetString("grpErrorMssg"));
                            return;
                        }
                        row = SupplySubBindingSource.Current as tblSupplySub;
                        InitNewRowObject(row);
                        if (isSale)
                        {
                            if (this.productData.tblProduct.prdStatus == (byte)ProductType.Service)
                            {
                                if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle))
                                    this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
                            }
                            else
                            {
                                if (InitPrdQuantity((this.productData?.PrdMeasurment?.ppmStatus) ?? 0))
                                    return;
                                ValidMinSalePrice(row);
                                SetPrdQuanAvlbList(row);
                            }
                        }
                        break;
                    case nameof(temp.supMsur):
                        break;
                    case nameof(temp.supQuanMain):
                        if (double.TryParse(e.Value?.ToString(), out quantity))
                        {
                            row.supQuanMain = quantity;
                            if (InitPrdQuantity((this.productData?.PrdMeasurment?.ppmStatus)??0))
                                return;
                            CalculateAllInGridViewRow(row);
                            if (isCredit)
                                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupCredit, row.supCredit));
                            else
                                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupDebit, row.supDebit));
                        }
                        break;
                    case nameof(temp.subHeight):
                    case nameof(temp.subWidth):
                        row.subHeight = double.Parse((e.Column.FieldName == nameof(row.subHeight) ? e.Value : row.subHeight).ToString());
                        row.subWidth = double.Parse((e.Column.FieldName == nameof(row.subWidth) ? e.Value : row.subWidth).ToString());
                        if (row.subHeight > 0 && row.subWidth > 0)
                        {
                            row.supQuanMain = row.subHeight.GetValueOrDefault() * row.subWidth.GetValueOrDefault();
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.supQuanMain));
                        }
                        break;
                    case nameof(temp.supSalePrice):
                        row.supSalePrice = double.Parse(e.Value?.ToString());

                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supPrice):
                        row.supPrice = double.Parse(e.Value?.ToString());
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supOvertime):
                    case nameof(temp.supWorkingtime):
                        row.supOvertime = double.Parse((e.Column.FieldName == nameof(row.supOvertime) ? e.Value : row.supOvertime).ToString());
                        row.supWorkingtime = double.Parse((e.Column.FieldName == nameof(row.supWorkingtime) ? e.Value : row.supWorkingtime).ToString());
                        if (row.supWorkingtime > 0 && row.supOvertime > 0)
                        {
                            row.supQuanMain = row.supWorkingtime.Value + row.supOvertime.Value;
                            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.supQuanMain));
                        }
                        break;
                    case nameof(temp.subQteMeter):
                        row.subQteMeter = double.Parse(e.Value?.ToString());
                        var lst = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == Convert.ToInt32(row.supPrdId));
                        if (this.productData?.PrdMeasurment == null)
                            this.productData.PrdMeasurment = lst.FirstOrDefault(c => c.ppmId == Convert.ToInt32(row.supMsur));
                        if (lst.Count() > 1)
                        {
                            var factor = (lst.FirstOrDefault(c => c.ppmId != Convert.ToInt32(row.supMsur))?.ppmConversion) ?? 1;
                            var currentQte = (row.subQteMeter / factor);
                            var currentPacks = (int?)row.subNoPacks;
                            if (lst.Any())
                            {
                                if (currentPacks != currentQte)
                                {
                                    row.supQuanMain = currentQte * factor;
                                    GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colQuanMain, row.supQuanMain));
                                    row.subNoPacks = (int?)currentQte;
                                    row.subQteMeter = currentQte * factor;
                                }
                            }
                        }
                        break;
                    case nameof(temp.supDscntPercent):
                        row.supDscntPercent = double.Parse(e.Value?.ToString());
                        if (isSale)
                            row.supDscntAmount = row.supDscntPercent != 0 ? (row.supSalePrice * (row.supDscntPercent / 100d)) * row.supQuanMain : 0;
                        else
                            row.supDscntAmount = row.supDscntPercent != 0 ? (row.supPrice * (row.supDscntPercent / 100d)) * row.supQuanMain : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supDscntAmount):
                        row.supDscntAmount = double.Parse(e.Value?.ToString());
                        if (isSale)
                            row.supDscntPercent = row.supDscntAmount != 0 ? (row.supDscntAmount / (row.supSalePrice * row.supQuanMain)) * 100d : 0;
                        else
                            row.supDscntPercent = row.supDscntAmount != 0 ? (row.supDscntAmount / (row.supPrice * row.supQuanMain)) * 100d : 0;
                        CalculateAllInGridViewRow(row);
                        break;
                    case nameof(temp.supCredit) when (supplyType == SupplyType.Sales):
                        if (row.supSalePrice == 0 || (row.supQuanMain ?? 0) == 0) return;
                        discount = 1d - ((double.Parse(e.Value?.ToString()) / (row.supQuanMain ?? 0)) / ((row.supSalePrice ?? 0) * (1d + ((row.supTaxPercent ?? 0) / 100d))));
                        row.supSalePrice = (row.supSalePrice ?? 0) - ((row.supSalePrice ?? 0) * discount);
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupSalePrice, row.supSalePrice));
                        break;
                    case nameof(temp.supCredit) when (supplyType == SupplyType.PurchaseRtrn):
                        if (row.supPrice == 0 || (row.supQuanMain ?? 0) == 0) return;
                        discount = 1 - ((double.Parse(e.Value?.ToString()) / (row.supQuanMain ?? 0)) / ((row.supPrice ?? 0) * (1 + ((row.supTaxPercent ?? 0) / 100d))));
                        row.supPrice = (row.supPrice ?? 0) - ((row.supPrice ?? 0) * discount);
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupPrice, row.supPrice));
                        break;
                    case nameof(temp.supDebit) when (supplyType == SupplyType.SalesRtrn):
                        if (row.supSalePrice == 0 || (row.supQuanMain ?? 0) == 0) return;
                        discount = 1 - ((double.Parse(e.Value?.ToString()) / (row.supQuanMain ?? 0)) / ((row.supSalePrice ?? 0) * (1 + ((row.supTaxPercent ?? 0) / 100d))));
                        row.supSalePrice = (row.supSalePrice ?? 0) - ((row.supSalePrice ?? 0) * discount);
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupSalePrice, row.supSalePrice));
                        break;
                    case nameof(temp.supDebit) when (supplyType == SupplyType.Purchase):
                        if (row.supPrice == 0 || (row.supQuanMain ?? 0) == 0) return;
                        discount = 1 - ((double.Parse(e.Value?.ToString()) / (row.supQuanMain ?? 0)) / ((row.supPrice ?? 0) * (1 + ((row.supTaxPercent ?? 0) / 100d))));
                        row.supPrice = (row.supPrice ?? 0) - ((row.supPrice ?? 0) * discount);
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupPrice, row.supPrice));
                        break;
                    case "NetAmount" when (supplyType == SupplyType.Purchase):
                        double val = double.Parse(e.Value?.ToString());
                        if ((row.supQuanMain ?? 0) == 0) return;
                        row.supPrice = (val/* + (row.supDscntAmount ?? 0)*/) / (row.supQuanMain ?? 0);
                        GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupPrice, row.supPrice));
                        break;
                    default:
                        break;
                }

                gridView.RefreshData();
                GridView_RowUpdated(sender, null);
                ProductPriceOfferCal();
            }
            catch (Exception ex)
            {

            }
        }
        private void GridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (Session.tblPrdPriceMeasurment == null) return;
            if (e.Column.FieldName == "supMsur" && e.Value is int p && p > 0)
                e.DisplayText = Session.tblPrdPriceMeasurment?.FirstOrDefault(x => x.ppmId == p)?.ppmMsurName;
            else if (e.Column.FieldName == "supCurrency" && e.Value is short c && c > 0)
                e.DisplayText = Session.Currencies?.FirstOrDefault(x => x.id == c)?.curName;
        }
        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == colStatus.FieldName)
            {
                if (gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupIsCash) is byte iscash && e?.Value is byte val)
                    e.DisplayText = ClsSupplyStatus.GetString(val, iscash);
            }
            else if (e.Column.FieldName == "supCustSplId" && e.Value is int cus)
            {
                if (isSale)
                {
                    tblCustomer tblCustomer = Session.Customers.FirstOrDefault(x => x.id == cus);
                    if (tblCustomer == null) return;
                    e.DisplayText = tblCustomer?.custNo + " - " + tblCustomer?.custName;
                }
                else
                {
                    tblSupplier supplier = Session.Suppliers.FirstOrDefault(x => x.id == cus);
                    if (supplier == null) return;
                    e.DisplayText = supplier?.splNo + " - " + supplier?.splName;
                }
            }
        }

        private void GridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.tblProduct == null || !isNew || p != productData?.tblProduct?.id)
                GetData(null, p);
            if (e.FocusedColumn == colMsur)
                PrdMeasurmentBindingSource.DataSource = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == p).ToList();
        }
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var p = Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdNo));
            if (productData?.PrdMeasurment == null || productData?.tblProduct == null || !isNew || p != productData?.tblProduct?.id)
                GetData(null, p);
            if (e.FocusedRowHandle >= 0)
                PrdMeasurmentBindingSource.DataSource = Session.tblPrdPriceMeasurment.Where(x => x.ppmPrdId == p).ToList();
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
                e.ErrorText = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
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
                    e.ErrorText = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                }
                else this.gridValid = true;
            }

        }

        private void RepositoryItemLookUpEditMeasurment_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (InitPrdQuantity(Convert.ToByte(editor.GetColumnValue("ppmStatus")))) return;
            if (gridView.GetFocusedRow() is tblSupplySub tblSupplySub && tblSupplySub != null)
                ValidMinSalePrice(tblSupplySub);
            this.productData.PrdMeasurment = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            this.MinSalePrice = myFunaction.GetMinSalePrice(this.productData.tblProduct.prdPriceTax, this.productData.PrdMeasurment);
            var tbBarcode = Session.tblBarcode.FirstOrDefault(x => x.brcPrdMsurId == this.productData.PrdMeasurment.ppmId);
            tblSupplySub row = SupplySubBindingSource.Current as tblSupplySub;
            row.supMsur = this.productData.PrdMeasurment.ppmId;
            row.supPrdId = this.productData.PrdMeasurment.ppmPrdId;
            row.supPrdBarcode = tbBarcode?.brcNo;
            row.supPrice = this.productData.PrdMeasurment.ppmPrice;// SetAveragePrdPrice(this.productData.tblProduct.ID);
            row.Conversion = (this.productData.PrdMeasurment?.ppmConversion ?? 1);
            row.supSalePrice = GetSalePrice();
            gridView.UpdateCurrentRow();
            CalculateAllInGridViewRow(row);
            SetPrdQuanAvlbList(row);
        }
        private void RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (!e.IsGetData) return;
            int supPrdId = Convert.ToInt32(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colprdId));
            if (!this.listPrdPriceDic.ContainsKey(supPrdId)) return;
            if (e.Column.FieldName == colprdSalePrice.FieldName)
                e.Value = this.listPrdPriceDic[supPrdId];
            else if (e.Column.FieldName == colsupMusrName.FieldName)
                e.Value = this.listPrdMsurName[supPrdId];
        }

        private void GridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == colCount.FieldName)
                if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;

            if (e.Column.FieldName != colprdQuanAvlb.FieldName) return;
            if (!e.IsGetData) return;
            var row = e.Row as tblSupplySub;
            e.Value = GetQuanAvlb(row != null ? row.supPrdId.GetValueOrDefault() : 0);
        }
        double GetQuanAvlb(int supPrdId)
        {
            if (!this.listPrdQuanAvlbDic.ContainsKey(supPrdId)) return 0;
            double otherQuantity = GetQuantityProductInGrid(supPrdId);
            return this.listPrdQuanAvlbDic[supPrdId] - otherQuantity;
        }

        public double GetQuantityProductInGrid(int supPrdId)
        {
            var pro = SupplySubBindingSource.List as IList<tblSupplySub>;
            return pro.Where(x => x.supPrdId == supPrdId).Sum(x => x.supQuanMain ?? 0);
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
        private bool GetData(string barcode = null, int supPrdId = 0)
        {
           
            if (barcode != null && supPrdId == 0)
            {
                this.productData = (from b in Session.tblBarcode
                                    join m in Session.tblPrdPriceMeasurment on b.brcPrdMsurId equals m.ppmId
                                    join p in Session.Products on m.ppmPrdId equals p.id
                                    join g in Session.tblGroupStr on p.prdGrpNo equals g.id
                                    where b.brcNo == barcode //&& m.Default == 1
                                    select new tblProductDataRow1
                                    {
                                        tblBarcode = b,
                                        PrdMeasurment = m,
                                        tblProduct = p,
                                        GroupStr = g
                                    }).FirstOrDefault();
            }
            else if (barcode == null && supPrdId > 0)
            {
                if (Session.Products.Any(x => x.id == supPrdId && x.prdStatus == 2))
                {
                    this.productData = (from p in Session.Products
                                        join g in Session.tblGroupStr on p.prdGrpNo equals g.id
                                        where p.id == supPrdId
                                        select new tblProductDataRow1
                                        {
                                            PrdMeasurment = Session.tblPrdPriceMeasurment.FirstOrDefault(x=>x.ppmPrdId== supPrdId&&x.ppmDefault),
                                            tblProduct = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }
                else
                {
                    this.productData = (from b in Session.tblBarcode
                                        join m in Session.tblPrdPriceMeasurment on b.brcPrdMsurId equals m.ppmId
                                        join p in Session.Products on m.ppmPrdId equals p.id
                                        join g in Session.tblGroupStr on p.prdGrpNo equals g.id
                                        where p.id == supPrdId && m.ppmDefault == true
                                        select new tblProductDataRow1
                                        {
                                            tblBarcode = b,
                                            PrdMeasurment = m,
                                            tblProduct = p,
                                            GroupStr = g
                                        }).FirstOrDefault();
                }
            }
            return this.productData != null;
        }

        private void GetPrdBarcodeData(string barcode)
        {
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);

            tblSupplySub row = curList.FirstOrDefault(x => x.supPrdBarcode == barcode);
            bool FoundInGrid = curList.Any(x => x.supPrdBarcode == barcode);
            if (isRtrn)
            {
                this.tbSupplySubListOld = this.tbSupplySubListOld is null ? new List<tblSupplySub>() : this.tbSupplySubListOld;
                if (!this.tbSupplySubListOld.Any(x => x.supPrdBarcode == barcode))
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة " + (isSale ? "البيع" : "الشراء"));
                    return;
                }
                if (FoundInGrid)
                {
                    if (this.tbSupplySubListOld.FirstOrDefault(x => x.supPrdBarcode == barcode).supQuanMain <= row.supQuanMain)
                    {
                        MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة " + (isSale ? "البيع" : "الشراء"));
                        return;
                    }
                }
            }
            barcode = myFunaction.ChickBarcodWaghit(barcode, out bool ProIsWaghit, out double value);
            if (!GetData(barcode))
            {
                MessNotFoundBarcod();
                return;
            }
            if ((this.productData?.GroupStr?.grpAccNo ?? 0) == 0)
            {
                ClsXtraMssgBox.ShowError(_resource.GetString("grpErrorMssg"));
                return;
            }
            if (MySetting.DefaultSetting.ReadMode == 1 && ProIsWaghit)
            {
                var priceAfterTax = 100d * (value / (100d + tax));
                value = MySetting.DefaultSetting.TaxReadMode ? priceAfterTax : value;
            }
            if (FoundInGrid)
            {
                if ((ProIsWaghit && !MySetting.DefaultSetting.GroupWeightProdInInvoices) ||
                    (!ProIsWaghit && !MySetting.DefaultSetting.GroupProductsInInvoices))
                {
                    row = row.ShallowCopy();
                    InitNewRowObject(row, value, ProIsWaghit);
                    row.supPrdBarcode = textEditBarcodeNo.Text;
                    curList.Add(row);
                }
                else
                {
                    row.supSalePrice = (ProIsWaghit && MySetting.DefaultSetting.ReadMode == 1) ? value : row.supSalePrice;
                    row.supQuanMain += (ProIsWaghit && MySetting.DefaultSetting.ReadMode == 1) ? 1 : value;
                    CalculateAllInGridViewRow(row);
                }
            }
            else
            {
                row = (new tblSupplySub().ShallowCopy());
                InitNewRowObject(row, value, ProIsWaghit);
                row.supPrdBarcode = textEditBarcodeNo.Text;
                curList.Add(row);
            }
            gridView.RefreshData();
            SupplySubBindingSource.Position = SupplySubBindingSource.IndexOf(row);
            if (InitPrdQuantity(this.productData.PrdMeasurment.ppmStatus)) return;
            ValidMinSalePrice(row);
            PlayBarcodeBeep();
            SetPrdQuanAvlbList(row);

            return;
        }
        private bool InitPrdQuantity(byte msurStatus)
        {
            try
            {
                var supCurr = SupplySubBindingSource.Current as tblSupplySub;
                if (supCurr == null || supplyType != SupplyType.Sales) return false;
                tblProductQunatity tbPrdQty = Session.ProductQunatities?.FirstOrDefault(x => x.prdStrId == (supCurr.StoreID ?? 0) && x.prdId == (supCurr.supPrdId ?? 0));
                double prdQuantity = (tbPrdQty?.prdQuantity ?? 0) / (supCurr?.Conversion ?? 1);
                if ((!this.listPrdQuantDic?.ContainsKey(gridView.FocusedRowHandle)) ?? false)
                    this.listPrdQuantDic.Add(gridView.FocusedRowHandle, prdQuantity);
                if (!MySetting.DefaultSetting.showPrdQtyMssg || !isNew) return false;
                var pro = SupplySubBindingSource.List as IList<tblSupplySub>;
                if (pro.Count > 0)
                {
                    double otherQuantity = pro.Where(x => x.supPrdId == supCurr.supPrdId.GetValueOrDefault()).Sum(x => x.supQuanMain ?? 0);
                    if (otherQuantity > prdQuantity)
                    {
                        ClsXtraMssgBox.ShowError(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuantity));
                        if (prdQuantity <= 0)
                        {
                            DeleteRow();
                            GridView_RowUpdated(null, null);
                        }
                        else
                            supCurr.supQuanMain = prdQuantity;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return false;
            }
        }
     
        private void UpdatePrdQuanAvlb() => gridView.SetRowCellValue(gridView.FocusedRowHandle, colprdQuanAvlb, 1);
        private void SetPrdQuanAvlbList(tblSupplySub row)
        {
            if (!isSale||row==null) return;
            short StorID = (row.StoreID??0);
            tblProductQunatity tbPrdQty = Session.ProductQunatities?.FirstOrDefault(x => x.prdStrId == (row.StoreID ?? 0) && x.prdId == (row.supPrdId ?? 0));
            double prdQuantity = (tbPrdQty?.prdQuantity ?? 0) / (row?.Conversion??1);

            if (!this.listPrdQuanAvlbDic.ContainsKey(row.supPrdId??0))
                this.listPrdQuanAvlbDic.Add((row.supPrdId ?? 0), prdQuantity);
            else
                this.listPrdQuanAvlbDic[(row.supPrdId ?? 0)] = prdQuantity;
        }
        bool ValidGridErrorMssg()
        {
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);
            if ((curList == null || curList.Count <= 0) && this.gridValid)
            {
                XtraMessageBox.Show(_resource.GetString("GridErrorMssg"));
                return false;
            }
            return true;
        }
        bool ValidsupNo()
        {
            if (GetCurSupplyMain?.supNo == 0|| (string.IsNullOrWhiteSpace(GetCurSupplyMain?.supRefNo)&&!isSale))
            {
                layoutControlGroupMain.Expanded = true;
                return dxValidationProvider1.Validate();
            }
            return true;
        }
        bool ValidbbiSelect()
        {
            if (isRtrn && !bbiSelect.Checked)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب الضغط على زر التحديد أولاً" : "Please press check button first!");
                return false;
            }
            return true;
        }
        bool ValidsupTotal()
        {
            if (GetCurSupplyMain?.supTotal == 0)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب ان لا تكون قيمة الفاتورة 0" : "Sorry invoice amount can not be 0");
                return false;
            }
            return true;
        }
        bool ValidsupSalePrice()
        {
            if (this.supplyType != SupplyType.Sales) return true;
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);
            if (curList.Any(x => x.supSalePrice < x.supPrice) && MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent)
            {
                ClsXtraMssgBox.ShowWarning("عذرا يوجد اصناف سعر البيع اقل من سعر التكلفه ");
                return false;
            }
            return true;
        }
        bool ValidPayPartInvoValue(tblSupplyMain tbSupplyMain)
        {
            if (tbSupplyMain?.supIsCash == 2)
            {
                if (MySetting.DefaultSetting.PayPartInvoValue)
                {
                    double paid = (tbSupplyMain?.paidCash ?? 0) + (tbSupplyMain?.supBankAmount ?? 0);
                    if (paid == tbSupplyMain?.net)
                    {
                        XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? $"عذرا يجب ان لا تكون الفاتورة اجل لان اجمالي المدفوع {paid} يساوي قيمة الفاتورة {tbSupplyMain.net}" : $"Sorry, Payment method can not be Postpaid because the payment {paid} is equal to the value of the invoice {tbSupplyMain.net}");
                        return false;
                    }
                    if (paid > tbSupplyMain?.net)
                    {
                        XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? $"عذرا يجب ان لا يكون المدفوع {paid} اكبر من قيمة الفاتورة {tbSupplyMain.net}" : $"Sorry, the amount paid {paid} cannot be more than the invoice amount {tbSupplyMain.net}");
                        return false;
                    }
                }
                if (tbSupplyMain?.supCustSplId == null || tbSupplyMain?.supCustSplId <= 0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة اجل بدون اختيار " + (isCustomer ? "العميل" : "المورد"));
                    return false;
                }
            }
            else
            {
                if (tbSupplyMain?.supBoxId == null || tbSupplyMain?.supBoxId <= 0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة قم باختيار الصندوق اولا ");
                    return false;
                }
                if ((tbSupplyMain?.supBankId == null || tbSupplyMain?.supBankId <= 0)&& (tbSupplyMain?.supBankAmount??0)>0)
                {
                    ClsXtraMssgBox.ShowError("عذراً لا يمكن حفظ الفاتورة قم باختيار البنك اولا ");
                    return false;
                }
            }

            return true;
        }
        void SetAccNo(tblSupplyMain tbSupplyMain)
        {
            if (tbSupplyMain?.supIsCash == 2)
            {
                tbSupplyMain.supEqfal = 1;
                if (isCustomer)
                {
                    var cus = Session.Customers.FirstOrDefault(x => x.id == tbSupplyMain.supCustSplId);
                    tbSupplyMain.supAccNo = cus?.custAccNo;
                    tbSupplyMain.supAccName = cus?.custAccName;
                }
                else
                {
                    var sup = Session.Suppliers.FirstOrDefault(x => x.id == tbSupplyMain.supCustSplId);
                    tbSupplyMain.supAccNo = sup?.splAccNo;
                    tbSupplyMain.supAccName = AccNameByAccNo(sup?.splAccNo ?? 0);
                }
            }
            else
            {
                tbSupplyMain.supEqfal = 2;
                var box = Session.Boxes.FirstOrDefault(x => x.id == tbSupplyMain.supBoxId);
                tbSupplyMain.supAccNo = box?.boxAccNo;
                tbSupplyMain.supAccName = AccNameByAccNo(box?.boxAccNo ?? 0);
            }

        }
        void SetsupCurrency()
        {
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);
            if (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.Purchase)
            {
                bool istax = (!checkEditTax.Checked && curList.Any(x => x.supTaxPercent != 0 || x.supTaxPrice != 0));
                if (istax || curList.Any(x => x.supCurrency > 1))
                {
                    foreach (var tbSupplySub in curList)
                    {
                        if (istax)
                        {
                            tbSupplySub.supTaxPercent = 0;
                            tbSupplySub.supTaxPrice = 0;
                        }
                        if (tbSupplySub.supCurrency > 1)
                        {
                            if (isCredit)
                            {
                                tbSupplySub.supCreditFrgn = tbSupplySub.supCredit;
                                tbSupplySub.supCredit = tbSupplySub.supCredit * (GetCurSupplyMain.supCurrencyChng as short?) ?? 0;
                            }
                            else
                            {
                                tbSupplySub.supDebitFrgn = tbSupplySub.supDebit;
                                tbSupplySub.supDebit = tbSupplySub.supDebit * (GetCurSupplyMain.supCurrencyChng as short?) ?? 0;
                            }
                        }
                    }
                }
            }
        }
        string AccNameByAccNo(long acNo) => Session.Accounts.FirstOrDefault(x => x.accNo == acNo)?.accName;
        private bool SaveData(bool printInvoice = true)
        {
            bool isSaved = false;
            
            tblSupplyMain tbSupplyMain = GetCurSupplyMain;
            textEditBarcodeNo.Focus();
            gridView.FocusedColumn = (gridView.FocusedColumn == colsupPrdNo) ? colprdName : colsupPrdNo;
            if (tbSupplyMain == null) return false;
            var curList = (SupplySubBindingSource.List as IList<tblSupplySub>);
            if (!ValidGridErrorMssg()) return false;
            if (!ValidsupNo()) return false;
            if (!ValidbbiSelect()) return false;
            if (!ValidsupTotal()) return false;
            if (!ValidsupSalePrice()) return false;
            if (!ValidPayPartInvoValue(tbSupplyMain)) return false;
            if (!ValidateCustomerCelling(tbSupplyMain)) return false;
            SetAccNo(tbSupplyMain);
            SetsupCurrency();
            using (var db = new accountingEntities())
            {
                try
                {
                    if (this.isNew)
                    {
                        if (MySetting.DefaultSetting.UserDrawerPeriods == true)
                        {
                            if (!db.DrawerPeriods.Any(m => m.PeriodUserID == CurrentUser.id && m.Status == false))
                            {
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, Not saved Daily period must be opened first for the user" : "لم يتم الحفظ يجب فتح فترة يومية أولا للمستخدم");
                                return false;
                            }
                        }
                        tbSupplyMain.supCustSplId = tbSupplyMain.supCustSplId == 0 ? null : tbSupplyMain.supCustSplId;
                        if (this.supplyType != SupplyType.SalesRtrn)
                        {
                            var sup = db.tblSupplyMains.AsNoTracking().Where(x => x.supBrnId == CurBranch.brnId && x.supDate >= CurrentYear.fyDateStart && (x.supStatus == state1 || x.supStatus == state2));
                            if (sup.Count() > 0) tbSupplyMain.supNo = sup.Max(x => x.supNo) + 1;
                            else tbSupplyMain.supNo = 1;
                        }
                       
                        tbSupplyMain.EnterDate = DateTime.Now;
                        using (DbContextTransaction transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                if (isSale && reprIDTextEdit.Text.Trim()!=string.Empty.Trim() ) {
                                    mandibCopunSave(true);
                                    tbSupplyMain.commission= mandob.commission;
                                }
                                db.tblSupplyMains.Add(tbSupplyMain);
                                db.SaveChanges();
                                curList = supplySubs(curList, tbSupplyMain);
                                db.tblSupplySubs.AddRange(curList);
                                db.SaveChanges();
                                transaction.Commit();
                                isSaved = true;
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                ClsXtraMssgBox.ShowError(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        using (DbContextTransaction transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var Baseitem = db.tblSupplyMains.Find(tbSupplyMain.id);
                                db.Entry(Baseitem).CurrentValues.SetValues(tbSupplyMain);
                                curList = supplySubs(curList, tbSupplyMain);
                                db.tblSupplySubs.RemoveRange(db.tblSupplySubs.Where(y => y.supNo == tbSupplyMain.id));
                                db.tblSupplySubs.AddRange(curList);
                                db.SaveChanges();
                                transaction.Commit();
                                isSaved = true;
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                ClsXtraMssgBox.ShowError(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClsXtraMssgBox.ShowError(ex.Message);
                }
                if (isSaved)
                {
                    if (printInvoice)
                        ShowPrintInvoice();
                    SupplyAutoTarhel();
                }
                //}
            }

            switch (supplyType)
            {
                case SupplyType.Purchase: Session.MaxNoBuyInv = isSaved ? tbSupplyMain.supNo + 1 : Session.MaxNoBuyInv; break;
                case SupplyType.PurchaseRtrn: Session.MaxNoBuyInvRetr = isSaved ? tbSupplyMain.supNo + 1 : Session.MaxNoBuyInvRetr; break;
                case SupplyType.Sales: Session.MaxNoSaleInv = isSaved ? tbSupplyMain.supNo + 1 : Session.MaxNoSaleInv; break;
            }
            //if (MySetting.GetPrivateSetting.SendInvoToServerOnSave && this.isNew)
            //{
            //    List<tblSupplySub> tbSupplySubList = (from s in curList select s.ShallowCopy()).ToList();
            //    tblSupplyMain temp = tbSupplyMain.ShallowCopy();
            //    Task.Run(() => new UploadDataToMain(temp, tbSupplySubList));
            //}
            return isSaved;
        }
        private void SupplyAutoTarhel()
        {
            if (!MySetting.DefaultSetting.autoSupplyTarhel) return;
            tblSupplyMain tbSupplyMain = GetCurSupplyMain.ShallowCopy();
             Task.Run(() => new ClsSupplyTarhel(supplyType).PhaseAutoInvoice(tbSupplyMain));
        }

        private bool ValidateCustomerCelling(tblSupplyMain tbSupplyMain)
        {
            if (tbSupplyMain.supIsCash != 2 ||supplyType!= SupplyType.Sales) return true;
            if (this.tbCustomer != null && Convert.ToInt64(this.tbCustomer.custCellingCredit) == 0) return true;

            double totalFinal = this.isNew ? tbSupplyMain.net : tbSupplyMain.net - this.totalFinalOld;
            bool isValid = (totalFinal + CustBalance) <= this.tbCustomer.custCellingCredit;
            if (!isValid)
            {
                string mssg = "عذراً لا يمكن تجاوز سقف حساب العميل! \n\n";
                mssg += $"رصيد حساب العميل: {CustBalance:f2}\n";
                mssg += $"سقف حساب العميل: {this.tbCustomer.custCellingCredit:f2}\n\n";
                mssg += $"إجمالي الفاتورة: {tbSupplyMain.net:f2}";
                if (!this.isNew) mssg += $"\n\nإجمالي الفارق عند التعديل: {totalFinal:f2}";

                ClsXtraMssgBox.ShowError(mssg);
            }

            return isValid;
        }

        void SetSupplyNo(tblSupplyMain supplyMain) => supplyMain.supNo = (this.supplyType)
         switch
        {
            SupplyType.Purchase => supplyMain.supNo = Session.MaxNoBuyInv,
            SupplyType.Sales => supplyMain.supNo = Session.MaxNoSaleInv,
            SupplyType.SalesRtrn => supplyMain.supNo = supplyMain.supNo,
            SupplyType.PurchaseRtrn => supplyMain.supNo = Session.MaxNoBuyInvRetr,
        };
       
        IList<tblSupplySub> supplySubs(IList<tblSupplySub> curList, tblSupplyMain tbSupplyMain) => 
            (from i in curList
             select new tblSupplySub
             {
                 supDate = tbSupplyMain.supDate.GetValueOrDefault(),
                 supBrnId = tbSupplyMain.supBrnId,
                 supPrice = i.supPrice, /*supplyType == SupplyType.Sales ? myFunaction.GetCostOfNextProductTransaction(i, myFunaction.GetDataProductTransaction(i.supPrdId??0,i.StoreID??0,i.supDate)).supPrice * i.Conversion:*/
                 supCurrency = i.supCurrency,
                 supDesc = i.supDesc,
                 supDscntAmount = i.supDscntAmount,
                 supDscntPercent = i.supDscntPercent,
                 ExpireDate = i.ExpireDate,
                 subHeight = i.subHeight,
                 id = i.id,
                 supMsur = i.supMsur,
                 subNoPacks = i.subNoPacks,
                 supOvertime = i.supOvertime,
                 supNo = tbSupplyMain.id,
                 supPrdBarcode = i.supPrdBarcode,
                 supPrdId = i.supPrdId,
                 supPrdManufacture = i.supPrdManufacture,
                 subQteMeter = i.subQteMeter,
                 supQuanMain = i.supQuanMain,
                 supSalePrice = i.supSalePrice,
                 supStatus = tbSupplyMain.supStatus,
                 supTaxPercent = i.supTaxPercent,
                 supTaxPrice = i.supTaxPrice,
                 supDebit = i.supDebit,
                 supDebitFrgn = i.supDebitFrgn,
                 supCredit = i.supCredit,
                 supCreditFrgn = i.supCreditFrgn,
                 supUserId = tbSupplyMain.supUserId,
                 subWidth = i.subWidth,
                 supWorkingtime = i.supWorkingtime,
                 supAccName = i.supAccName,
                 supAccNo = i.supAccNo,
                 supPrdName = i.supPrdName,
                 supPrdNo = i.supPrdNo,
                 StoreID = tbSupplyMain.supStrId,
                 Conversion = i.Conversion>0? i.Conversion: GetConversion(i.supMsur??0),
                 EquipmentNo=i.EquipmentNo,
                 NumberDays=i.NumberDays
             }).ToList();
        double GetConversion(int unitID) => Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == unitID)?.ppmConversion ?? 1;
        private void SaveAndNew(bool printInvoice)
        {
            if (!SaveData(printInvoice)) return;
            string mssg = GetSaveSuccessMssg();
            flyDialog.ShowDialogUC(this, mssg, this.isNew);
            ResetData();
            this.isNew = true;
        }
        MyFunaction myFunaction = new MyFunaction();



        private void ResetData()
        {
            this.listPrdQuantDic = new Dictionary<int, double>();
            InitSupplyMainObj(true);
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
            this.gridValid = true;
            textEditBarcodeNo.Focus();
            SetDiscountCoumnsEditProperty(true);
            SpinEditTotalPay.ResetText();
        }
        private void InitSupplySubGridObj()
        {
            SupplySubBindingSource.DataSource = null;
            SupplySubBindingSource.DataSource = typeof(tblSupplySub);
        }
        IList<tblSupplySub> curList;
        private void ShowPrintInvoice(bool PrintBefor = false, PrintFileType printFileType = PrintFileType.Printer)
        {
            int No = GetCurSupplyMain?.supNo ?? 0;
            if (PrintBefor && No > 0)
            {
                using (var db = new accountingEntities())
                {
                    No--;
                    switch (printFileType)
                    {
                        case PrintFileType.Printer:
                            var supplyMain = db.tblSupplyMains.AsQueryable().FirstOrDefault(a => (a.supStatus == state1 || a.supStatus == state2) && a.supBrnId == Session.CurBranch.brnId && a.supNo == No&&a.supDate>=CurrentYear.fyDateStart);
                            if (supplyMain != null)
                            {
                                var tbSupplySubList = db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == supplyMain.id && x.supDate >= CurrentYear.fyDateStart).ToList();
                                if (isSale)
                                    Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList));
                                else
                                    Task.Run(() => ClsPrintReport.PrintA4Invoice(supplyMain, tbSupplySubList));
                            }
                            break;
                        case PrintFileType.PDF:
                        case PrintFileType.Xlsx:
                            //temp = MySetting.DefaultSetting.PrintFileMode == ((byte)PrintMode.Direct);
                            break;
                        default:
                            break;
                    }
                }
            }
            else 
            {
                if ((GetCurSupplyMain?.id ?? 0) == 0) return;
                curList = (from s in (SupplySubBindingSource.List as IList<tblSupplySub>) select s.ShallowCopy()).ToList();

                if (MySetting.DefaultSetting.ShowPrintMssg)
                {
                    if (ClsXtraMssgBox.ShowQuesPrint(string.Format(_resource.GetString("printMssg"), No)) == DialogResult.Yes)
                    {
                        flyDialog.WaitForm(this, 1);
                        using (ReportForm frm = new ReportForm((MySetting.DefaultSetting.supplyA4CustomRprt) ? ReportType.SupplyCustom :
                            (ReportType)MySetting.DefaultSetting.printA4, tbSupplyMain: GetCurSupplyMain, tbSupplySubList: curList))
                        {
                            flyDialog.WaitForm(this, 0, frm);
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    tblSupplyMain tbSupplyMain = GetCurSupplyMain.ShallowCopy();
                    if (isSale)
                        Task.Run(() => ClsPrintReport.PrintSupply(tbSupplyMain, this.curList));
                    else
                        Task.Run(() => ClsPrintReport.PrintA4Invoice(tbSupplyMain, this.curList));
                }
            }
        }
        private bool ExccededPrdPriceFloar(double price)
        {
            if (MySetting.DefaultSetting.defaultSalePriceFloar)
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
            CalculateAllInGridViewRow(gridView.GetRow(rowHandle) as tblSupplySub);
        }

        public void SetProductPrice(int rowHandle, double price)
        {
            if (ExccededPrdPriceFloar(price)) return;
            if (price > (double)999999999999999999.99)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                return;
            }
            if (isSale)
            {
                price = (checkEditTax.Checked ? (price / (this.tax + 100d)) * 100d : price);
                gridView.SetRowCellValue(rowHandle, colsupSalePrice, price);
                gridView.RefreshRowCell(rowHandle, colsupSalePrice);
            }
            else
            {
                gridView.SetRowCellValue(rowHandle, colsupPrice, price);
                gridView.RefreshRowCell(rowHandle, colsupPrice);
            }
            CalculateAllInGridViewRow(gridView.GetRow(rowHandle) as tblSupplySub);
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
            textEditBarcodeNo.EditValue = null;
            textEditBarcodeNo.Focus();
        }

        private void UpdateQuantity(KeyEventArgs e)
        {
            var row = gridView.GetFocusedRow() /*SupplySubBindingSource.Current*/ as tblSupplySub;
            if (row == null) return;
            double quantity = Convert.ToDouble(row.supQuanMain);
            quantity = (e.KeyData) switch
            {
                Keys.Add => ++quantity,
                Keys.Subtract when quantity > 1 => --quantity,
                _ => quantity
            };
            row.supQuanMain = quantity;
            gridView.SetRowCellValue(gridView.FocusedRowHandle, colQuanMain, quantity);
            UpdatePrdQuanAvlb();
            CalculateAllInGridViewRow(row);

            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        private void DeletePrdDataFromPrdQuantDicList()
        {
            if (this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Remove(gridView.FocusedRowHandle);
        }

       
        private void DisableItems()
        {
            if (isSale)
                ItemForBarcodeText.Enabled = false;
            //checkEditTax.Enabled = false;
            //radioGroupIsCash.Enabled = false;
            //StrIdLookUpEdit.Enabled = false;
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
            FormDialogPrdSearch.gridViewSrchPrd.Appearance.EvenRow.BackColor = bindingNavigator11.BackColor;
        }
        public void ShowPrdSearchPanel() => this.FormDialogPrdSearch.ShowDialog();
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
        //private void Txtdisround_EditValueChanged(object sender, EventArgs e)
        //{   var tblSupplyMain=GetCurSupplyMain;
        //    if (tblSupplyMain == null) return;
        //    double.TryParse(txtdisround.Text, out double disround);
        //    tblSupplyMain.net = tot - disround;
        //}
        //private void Txtdisround_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    double.TryParse(labelTotalFinalString.Text, out double net);
        //    //var tot = totalAmount + GetCurSupplyMain?.TaxPrice;
        //    //var r = tot;
        //    var rd = net - GetCurSupplyMain?.net;
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
                if (isSale)
                {
                    using (formAddCustomer frm = new formAddCustomer(null, null))
                    {
                        flyDialog.WaitForm(this, 0);
                        frm.CloseAfterSave = true;
                        frm.ShowDialog();
                        if (GetCurSupplyMain is tblSupplyMain ss && ss != null && frm.customersId != 0)
                        {
                            ss.supCustSplId = frm.customersId;
                            CustNoSearchLookUpEdit.EditValue = ss.supCustSplId;
                            Session.GetDataCustomrtWhithBalances();
                            customerBindingSource.DataSource = Session.GetTablName(Session.CustomrtWhithBalances);
                        }
                    }
                }
                else
                {
                    using (formAddSupplier frm = new formAddSupplier(null, null))
                    {
                        flyDialog.WaitForm(this, 0);
                        frm.CloseAfterSave = true;
                        frm.ShowDialog();
                        if (GetCurSupplyMain is tblSupplyMain ss && ss != null && frm.supplierId != 0)
                        {
                            ss.supCustSplId = frm.supplierId;
                            CustNoSearchLookUpEdit.EditValue = ss.supCustSplId;
                            customerBindingSource.DataSource = Session.GetTablName(Session.Suppliers);
                        }
                    }
                }
            }
            else if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Index == 1)
            {
                flyDialog.WaitForm(this, 1);
                if (isSale)
                {
                    UCcustomers ucCustomers = new UCcustomers() { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 };
                    ucCustomers.ribbonControl.StatusBar.Hide();
                    ucCustomers.ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
                    ClsFlyoutDialog.ShowFlyoutDialog(this.ParentForm, ucCustomers, (!MySetting.GetPrivateSetting.LangEng) ? "العملاء" : "Customers");
                }
                else
                {
                    UCsupplier uCsupplier = new UCsupplier() { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 };
                    uCsupplier.ribbonControl.StatusBar.Hide();
                    uCsupplier.ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
                    ClsFlyoutDialog.ShowFlyoutDialog(this.ParentForm, uCsupplier, (!MySetting.GetPrivateSetting.LangEng) ? "الموردين" : "Suppliers");
                }
                flyDialog.WaitForm(this, 0);
            }
            else if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Index == 2)
            {
                flyDialog.WaitForm(this, 1);
                if (isSale)
                {
                    Session.GetDataCustomrtWhithBalances();
                    customerBindingSource.DataSource = Session.GetTablName(Session.CustomrtWhithBalances);
                }
                else
                {
                    Session.GetDataSuppliers();
                    customerBindingSource.DataSource = Session.GetTablName(Session.Suppliers);
                }
                flyDialog.WaitForm(this, 0);
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
            var tblSupplyMain = GetCurSupplyMain;
            if (tblSupplyMain != null)
            {
                tblSupplyMain.supBankAmount = tblSupplyMain.net;
                tblSupplyMain.supBankId = tblSupplyMain.supBankId == null ? (short)MySetting.DefaultSetting.defaultBank : tblSupplyMain.supBankId;
                textEditPaidCreditCard.EditValue = tblSupplyMain.supBankAmount;
                CalculatePaid(tblSupplyMain);
            }
        }

        private void SendECR(string ecrAmount)
        {
            string ecrPort = MySetting.DefaultSetting.ecrPort;
            byte[] MSIGD = Encoding.ASCII.GetBytes(this.supplyType == SupplyType.Sales ? "PUR" : "REF");
            byte[] ECRno = Encoding.ASCII.GetBytes("123");
            byte[] Rcptno = Encoding.ASCII.GetBytes((GetCurSupplyMain).supNo.ToString());
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
                isValid = CUSTOMDLLNET.checkDevice(MySetting.DefaultSetting.ecrPort);
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
                    int ecrAmountFraction = Convert.ToInt32((ecrAmount % 1) * 100m);
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
            MySetting.GetPrivateSetting.supplySaleExpanded = layoutControlGroupMain.Expanded;
            MySetting.WriterSettingXml();
        }

        private void reprIDTextEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem4.Visibility = LayoutVisibility.Always;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                layoutControlItem5.Visibility = LayoutVisibility.Never;
            }
            else
            {
                // layoutControlItem20.Visibility = LayoutVisibility.Always;
            }
        }

        void copunsave(string disCpon)
        {
            //if (txtdisCpon.Text != "" )
            //{
            using (accountingEntities dbco = new accountingEntities())
            {
                var copun = dbco.CouponBarcodes.SingleOrDefault(w => w.BarCode == disCpon);
                if (copun != null)
                {
                    copun.IsDefault = false;
                    copun.supTotal = Convert.ToDecimal(spinEditTotalFinalDecimal.Text);
                    copun.supNo = Convert.ToInt32(supNoTextEdit.EditValue);
                    copun.dateExpir = DateTime.Now;
                    dbco.SaveChanges();

                }
            }
            //}

        }
        private void txtdisCpon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (txtdisCpon.Text.Trim() == string.Empty.Trim()) return;
            if (GetCurSupplyMain.net == 0) return;
            using (accountingEntities db = new accountingEntities())
            {
                //قسيمة خصم
                var offerTotalFatora = db.tblProductPriceOffers.FirstOrDefault(b => b.DiscountType == 3);
                if (offerTotalFatora == null) return;
                if (offerTotalFatora.State != 2)
                {
                    var copun = db.CouponBarcodes.FirstOrDefault(w => w.BarCode == txtdisCpon.EditValue.ToString());
                    if (copun == null)
                    {
                        ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, There is no coupon for this number" : "لا يوجد قسيمة بهذا الرقم");
                        txtdisCpon.Text = "";
                        return;
                    }

                    if (copun.IsDefault == false)
                    {
                        ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, This coupon has already been used" : "هذه القسيمة تم استخدامها من قبل");
                        txtdisCpon.Text = "";
                        return;
                    }
                    // اجمالى سعر الفاتورة
                   
                    double priceOffer = Convert.ToDouble(copun.couponPrice);
                    switch (offerTotalFatora.State)
                    {

                        case 0: //عرض دائم

                            if (GetCurSupplyMain.net < priceOffer) //لو قيمة الفاتورة اقل من قيمة الكوبون
                            {
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, The value of the coupon is greater than the value of the invoice" : "قيمة القسيمة اكبر من قيمة الفاتورة");
                                txtdisCpon.EditValue = null;
                            }
                            else
                                SetDiscounCoupon(priceOffer);
                            break;
                        case 1: //العرض بين تاريخين

                            if (offerTotalFatora.ExpireDate > DateTime.Now)
                            {
                                if (GetCurSupplyMain.net < priceOffer) //لو قيمة الفاتورة اقل من قيمة الكوبون
                                {
                                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, The value of the coupon is greater than the value of the invoice" : "قيمة القسيمة اكبر من قيمة الفاتورة");
                                    txtdisCpon.EditValue = null;
                                }
                                else
                                    SetDiscounCoupon(priceOffer);
                            }
                            else
                            {
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, This coupon has expired" : "لقد انتهت فترة صلاحية هذه القسيمة");
                            }
                            break;
                    }
                }
            }
        }
        void SetDiscounCoupon(double priceOffer)
        {
            copunsave(txtdisCpon.Text);
            GetCurSupplyMain.supDscntAmount = (GetCurSupplyMain.supDscntAmount ?? 0) + priceOffer;
            DscntAmountTextEdit.EditValue = GetCurSupplyMain.supDscntAmount;
            txtdisCpon.EditValue = null;
        }
        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
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
            layoutControlGroupMain.Items.Where(x => x is LayoutControlItem).ForEach(x =>_resource.ApplyResources(x, x.Name, _ci));
            layoutControlCarData.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            layoutControlGroupPayCard.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            layoutControlGroupDiscount.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            layoutControlGroup4.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            layoutControlGroup10.Items.Where(x => x is LayoutControlItem).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            layoutControlGroup3.Items.Where(x => x is LayoutControlGroup).ForEach(x => _resource.ApplyResources(x, x.Name, _ci));
            try
            {
                foreach (var control in bindingNavigator11.Items)
                    if (control is ToolStripItem c)
                        _resource.ApplyResources(c, c.Name, _ci);
            }
            catch { }
            try
            {
                foreach (GridColumn col in gridView.Columns)
                    _resource.ApplyResources(col, col.Name, _ci);
            }
            catch { }

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
            try { btnDeleteRow.Text = _resource.GetString("btnDeleteRow"); } catch { }
            try { btnAddProduct.Text = _resource.GetString("btnAddProduct"); } catch { }
            try { BtnAddFraction.Text = _resource.GetString("BtnAddFraction"); } catch { }
            try { BtnDscnFraction.Text = _resource.GetString("BtnDscnFraction"); } catch { }
        }

        private void supCurrTextEdit_Click(object sender, EventArgs e)
        {
          
        }

        private void spinEditTotalFinalDecimal_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (spinEditTotalFinalDecimal.Text == "0" || spinEditTotalFinalDecimal.Text == "") return;
            ProductPriceOfferCal();
        }

        private void BtnDscnFraction_Click(object sender, EventArgs e)
        {
            var sale = GetCurSupplyMain;
            spinEditMonyFinal.EditValue = sale.net.ToString().Split('.').FirstOrDefault();
            spinEditMonyFinal_KeyDown(spinEditMonyFinal, new KeyEventArgs(Keys.Enter));
        }
        private void BtnAddFraction_Click(object sender, EventArgs e)
        {
            var sale = GetCurSupplyMain;
            if (gridView.RowCount == 0 || sale == null) return;
            double total = sale.net;
            double elFaka = 1 - (total - Math.Truncate(total));
            if (elFaka == 1) return;
            var row = SupplySubBindingSource.Current as tblSupplySub;
            if (row == null) return;
            if (isCredit)
            {
                row.supCredit += elFaka;
                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupCredit, row.supCredit));
            }
            else
            {
                row.supDebit += elFaka;
                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupDebit, row.supDebit));
            }

        }

        private void mandibCopunSave(bool addEdit)
        {
         
            using (accountingEntities db = new accountingEntities())
            {
                if (reprIDTextEdit.Text != "")// && test == true)
                {
                    var mandobcommission = db.tblRepresentatives.Find(Convert.ToInt32(reprIDTextEdit.EditValue));
                    mandob.reprID = Convert.ToInt32(reprIDTextEdit.EditValue);
                    if (radioGroup1.SelectedIndex == 0)
                    {

                        var comm = Convert.ToDouble(mandobcommission.repRate);
                        double result = Math.Round((Convert.ToDouble(SpinEditTotalAfterDiscount.EditValue) * comm) / 100, 2);
                        mandob.commission = result;
                        // test = false;
                    }
                    else
                    {
                        double resultM = 0;
                        // gridView
                        for (int i = 0; i < gridView.RowCount - 1; i++)
                        {
                            double price = Convert.ToDouble(gridView.GetRowCellValue(i, "supSalePrice"));
                            double Quintity = Convert.ToDouble(gridView.GetRowCellValue(i, "supQuanMain"));
                            string productName = gridView.GetRowCellValue(i, "supPrdName").ToString();
                            var repsD = db.tblRepresentativeStores.FirstOrDefault(e => e.id ==Convert.ToInt32( reprIDTextEdit.EditValue) && e.ProudctName == productName);
                            if (repsD != null)
                            {
                                resultM += (price - Convert.ToDouble(repsD.repPrice) * Quintity);
                            }


                        }
                        mandob.commission = resultM;


                    }
                    //test = false;
                }
            }

        }

        private void mandibCopunSave1(bool addEdit)
        {
            if ((GetCurSupplyMain.reprID ?? 0) == 0) return;
            using (accountingEntities db = new accountingEntities())
            {
                //tblSupplyMain mandob = new tblSupplyMain();
                var mandobcommission = db.tblRepresentatives.Find(GetCurSupplyMain.reprID);
                mandob.reprID = GetCurSupplyMain.reprID;
                if (radioGroup1.SelectedIndex == 0)
                {
                    var comm = Convert.ToDouble(mandobcommission.repRate);
                    double result = Math.Round(((GetCurSupplyMain.TotalAfterDiscount ?? 0) * comm) / 100, 2);
                    mandob.commission = result;
                    // test = false;
                }
                else
                {
                    var subList = SupplySubBindingSource.List as IList<tblSupplySub>;
                    double resultM =0;
                    for (int i = 0; i < gridView.RowCount - 1; i++)
                    {
                        double price = Convert.ToDouble(gridView.GetRowCellValue(i, "supSalePrice"));
                        double Quintity = Convert.ToDouble(gridView.GetRowCellValue(i, "supQuanMain"));
                        string productName = gridView.GetRowCellValue(i, "supPrdName").ToString();
                        var repsD = db.tblRepresentativeStores.FirstOrDefault(e => e.id == GetCurSupplyMain.reprID && e.ProudctName == productName);
                        if (repsD != null)
                        {
                            resultM += (price - Convert.ToDouble(repsD.repPrice) * Quintity);
                        }
                    }
                    mandob.commission = resultM;
                }
            }

        }

        private int supPrdNotoID(string supPrdNo)
        {
            using (accountingEntities db = new accountingEntities())
            {
                var prid = db.tblProducts.SingleOrDefault(m => m.prdNo == supPrdNo);
                return (prid.id);
            }
        }

        private void ProductPriceOfferCal()
        {
            using (accountingEntities db = new accountingEntities())
            {
                //حساب منتجات العرض
                var offerproPrice = db.tblProductPriceOffers.Where(X => X.State == 1 && X.DiscountType == 0 && X.ExpireDate > DateTime.Now).ToList();
                if (offerproPrice.Count() > 0)
                {
                    foreach (var item in offerproPrice) //كل عروض المنتجات
                    {
                        //if (item.ExpireDate > DateTime.Now && item.State == 1 && item.DiscountType == 0) return;
                        if (item.DiscountType == 0)
                        {
                            var offerPrd = db.OffersProducts.Where(m => m.OffersID == item.id).ToList();  //منتجات العرض
                            if (offerPrd.Count() > 0)
                            {
                                Boolean[] testshow = new Boolean[offerPrd.Count()];

                                for (int i = 0; i < testshow.Count(); i++)
                                {
                                    testshow[i] = false;
                                }

                                int co = 0;
                                foreach (var p in offerPrd)
                                {

                                    for (int k = 0; k < gridView.RowCount - 1; k++)
                                    {

                                        if (gridView.RowCount - 1 >= offerPrd.Count())
                                        {
                                            var prId = supPrdNotoID(Convert.ToString(gridView.GetRowCellValue(k, "supPrdNo")));
                                            if (prId == p.productID && Convert.ToDouble(gridView.GetRowCellValue(k, "supQuanMain")) >= item.Quantity)
                                            {
                                                testshow[co] = true;
                                            }

                                        }

                                    }
                                    co += 1;
                                }
                                Boolean testAllPr = true;
                                for (int i = 0; i < testshow.Count(); i++)
                                {
                                    if (testshow[i] == false)
                                    {
                                        testAllPr = false;
                                        break;
                                    }
                                }
                                if (testAllPr == true)
                                {
                                    DscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(item.Price));
                                    //  SupDscntAmountTextEdit_KeyUp(null, null);
                                }
                            }
                        }
                    }
                }
                //---------------------------------------------------------------------------------------------------------------------------


                //خصم على اجمالى فاتورة
                var offerTotalFatora = db.tblProductPriceOffers.FirstOrDefault(b => b.DiscountType == 1);
                if (offerTotalFatora != null)
                {
                    if (offerTotalFatora.State != 2)
                    {
                        Double qui = 0;
                        Double des = 0;
                        if (spinEditTotalFinalDecimal.EditValue == null) spinEditTotalFinalDecimal.EditValue = 0;
                        Double qu = Convert.ToDouble(spinEditTotalFinalDecimal.Text); // اجمالى سعر الفاتورة
                        if (offerTotalFatora.ExpireDate < DateTime.Now && offerTotalFatora.State == 1) return; //خلال فترة
                        if (qu >= offerTotalFatora.TotalFatora)
                        {
                            qui = Convert.ToDouble((qu / offerTotalFatora.TotalFatora)); //حد اجمالى الفاتورة
                            qui = Math.Truncate(qui);
                            des = Convert.ToDouble(qui * offerTotalFatora.Price); //قيمة الخصم
                            DscntAmountTextEdit.EditValue = des;
                            //spinEditMonyFinal.Text = des.ToString();
                            //spinEditMonyFinal_KeyDown(null, null);

                        }
                    }
                }

                //---------------------------------------------------------------------------------------------------------------------------

                //خصم على اجمالى فواتير العميل عن فترة
                if (CustNoSearchLookUpEdit.EditValue == null || CustNoSearchLookUpEdit.Text == "{}" || CustNoSearchLookUpEdit.Text.Trim() == string.Empty.Trim())
                { }
                else
                {
                    var offerCustmer = db.tblProductPriceOffers.FirstOrDefault(b => b.DiscountType == 2);
                    var CustmerId = db.tblCustomers.FirstOrDefault(b => b.id == Convert.ToInt32(CustNoSearchLookUpEdit.EditValue));
                    var CustmerTotal = db.tblSupplyMains.Where(b => b.supRefNo == CustmerId.custNo.ToString() && b.supDate.Value.Date >= offerCustmer.CustmerStartDate.Value.Date && b.supDate.Value.Date <= offerCustmer.CustmerEndDate.Value.Date).ToList();
                    Double totalprice = Convert.ToDouble(CustmerTotal.Sum(s => s.supTotal));
                    if (offerCustmer != null)
                    {
                        if (offerCustmer.State != 2 && totalprice != 0)
                        {
                            Double qui = 0;
                            Double des = 0;
                            Double qu = Convert.ToDouble(spinEditTotalFinalDecimal.Text); // اجمالى سعر الفاتورة
                            if (offerCustmer.ExpireDate < DateTime.Now && offerCustmer.State == 1) return; //خلال فترة
                            if (qu >= totalprice)
                            {
                                qui = Convert.ToDouble((qu / totalprice)); //حد اجمالى الفاتورة
                                qui = Math.Truncate(qui);
                                des = Convert.ToDouble(qui * offerCustmer.Price); //قيمة الخصم
                                DscntAmountTextEdit.EditValue = des;
                                //spinEditMonyFinal.Text = des.ToString();
                                //spinEditMonyFinal_KeyDown(null, null);
                            }
                        }
                    }
                }

                // CalculateTotalFinal();
            }
        }
    }
}
