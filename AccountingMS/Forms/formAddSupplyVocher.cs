using AccountingMS.Classes;
using AccountingMS.Forms;
using AccountingMS.Properties;
using CSHARPDLL;
using DevExpress.DataProcessing;
using DevExpress.Utils.Win;
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
using DevExpress.XtraTab;
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

namespace AccountingMS
{
    public partial class formAddSupplyVoucher : RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        accountingEntities db2 = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency curData = new ClsTblCurrency();
        ClsTblProductColor clsTbPrdColor = new ClsTblProductColor();
        ClsTblCustomer clsTbCustomer;
        //ClsSupply clsSupply;
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;
        ClsTblStore clsTbStore;
        ClsTblGroupStr clsTbGroupStr;
        ClsTblProduct clsTbProduct;
        ClsTblProductQunatity clsTbPrdQuantity;
        IClsTblPrdPriceQuan clsTbPrdPriceQuan;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTbBarcode;
        ClsTblPrdManufacture clsTbPrdMan;
        ClsTblAccount clsTbAccount;
        ClsTblBox clsTbBox;
        ClsTblEntrySub clsTbEntrySub;
        ClsSupplyTarhel clsSupplyTarhel;
        ClsPrdQuantityOperations clsPrdQuantityOpr;
        ClsPrdPriceQuanOperations clsPrdPriceQuanOpr;
        ClsProductByStore clsPrdStore;
        ClsPrdManAvrPrice clsPrdManAvrPrice;
        ClsCustomerBalanceData clsCustBalance;
        ClsTblDscntPrmsion clsTbDscntPrmsion;
        ClsTblNotification clsTbNotification;
        List<ClsProductQuantList> tbPrdQuanList;
        List<ClsProductQuantList> tbPrdQuanListOld;
        tblSupplyMain tbSupplyMain;
        List<tblSupplySub> tbSupplySubList;
        List<tblSupplySub> tbSupplySubListOld;
        tblPrdPriceMeasurment tbPrdMsur;
        tblProductQunatity tbPrdQuantiy;
        tblProduct tbProduct;
        tblCustomer tbCustomer;
        tblNotification tbNotification;
        Form FormDialogPrdSearch;
        FlyoutDialog flyDialogOrders;
        IDictionary<int, double> listPrdQuantDic;
        IDictionary<int, double?> listPrdPriceDic;
        IDictionary<int, string> listPrdMsurName;
        IDictionary<int, double> listPrdQuanAvlbDic;
        MediaPlayer barcodeBeep;
        Uri barcodeBeepUri;
        System.Windows.Forms.Timer ecrTimer = new Timer();

        private readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "B-Tech", "LayoutToXml");
        private readonly UCsalesInstantFeedBack _ucSales;
        //private readonly UCsales _ucSales;
        private readonly formSupplyMain _formSupplyMain;
        public SupplyType supplyType;
        private string accBoxName;
        private string barcodeNo;
        private long accNo;
        private string accName;
        private byte isCash;
        private bool isNew, autoSupplyTarhel, gridValid = true;
        private int supMainId;
        private int supNo;
        private int supNoOld;
        private long supAccNoOld;
        private byte currency;
        private byte status1, status2;
        private float tax;
        private bool hasTax;
        private bool checkEditTaxValue;
        private byte msurStatus;
        private int cstId;
        private double ppmMinSalePrice, totalAmount, totalTax, discountAmount = 0;
        private double totalFinalOld = 0;
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        Uri barcodeBadBeepUri;
        private void formAddSupplyVocher_Load(object sender, EventArgs e)
        {
            accountingEntities db = new accountingEntities();
            Task.Run(() => InitFlyDialogPrdSrch());
            // Task.Run(() => this.clsTbSupplySub = new ClsTblSupplySub());
            InitBarcodeBeep();
            InitRibbonStyle();
            SetLayoutGroupExpandMode();
            popsize();
            this.FormClosing += FormAddProduct_FormClosing;
            if (!this.isNew) CalculateTotalAmount();

            Txtdisround_EditValueChanged(null, null);

            ClsPath.ReLodeCustomContol(this.gridView, this.Name);

            layoutControlCarData.Visibility = MySetting.DefaultSetting.ShowlayoutControlCarData ? LayoutVisibility.Always : LayoutVisibility.Never;
            checkEdit1.Checked = MySetting.DefaultSetting.IsInvoiceRound;
            SetBbiCustomerInvoice();

            textEditBarcodeNo.Focus();
            textEditBarcodeNo.Focus();
            SetFont();
            Console.WriteLine($"======isFOucsed = {textEditBarcodeNo.Focused}");
            radioGroup1.SelectedIndex = 0;

            RepNameTextEdit.Properties.DataSource = (from Rep in db.tblRepresentatives.ToList() select new { repName = Rep.repName });
            RepNameTextEdit.Properties.DisplayMember = "repName";
            RepNameTextEdit.Properties.ValueMember = "repName";
            clsAppearance.AppearanceGridView(gridViewSaleReturn);
            clsAppearance.layoutAppearanceGroup(layoutControlGrooupMain);
            clsAppearance.layoutAppearanceGroup(layoutControlGroup5);
            clsAppearance.layoutAppearanceGroup(layoutControlCarData);
            clsAppearance.layoutAppearanceGroup(layoutControlGroup8);
            gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
        }
        ClsAppearance clsAppearance = new ClsAppearance();
        public formAddSupplyVoucher(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj, UserControl userControl, SupplyType supplyType,
            formSupplyMain formSupplyMain = null, ClsTblCustomer clsTbCustomer = null, ClsTblGroupStr clsTbGroupStr = null,
            ClsTblProduct clsTbProduct = null, ClsTblPrdPriceMeasurment clsTbPrdPriceMeasurment = null, ClsPrdQuantityOperations clsPrdQuantityOperations = null,
            ClsTblStore clsTbStore = null, ClsSupplyTarhel clsSupplyTarhel = null, ClsTblAccount clsTbAccount = null, ClsTblPrdManufacture clsTbPrdMan = null,
            ClsTblEntrySub clsTbEntrySub = null, ClsTblProductQunatity clsTbPrdQuantity = null, IClsTblPrdPriceQuan clsTbPrdPriceQuan = null,
            ClsTblBarcode clsTbBarcode = null, ClsTblDscntPrmsion clsTbDscntPrmsion = null)
        {
            this.supplyType = supplyType;
            _formSupplyMain = formSupplyMain;
            _ucSales = userControl as UCsalesInstantFeedBack;

            InitializeComponent();
            InitDefaultData();
            //InitObjects();
            InitObjectsRelatedData(clsTbCustomer, clsTbStore, clsTbGroupStr, clsTbProduct, clsTbPrdPriceMeasurment, clsPrdQuantityOperations, clsSupplyTarhel, clsTbAccount, clsTbPrdMan, clsTbEntrySub, clsTbPrdQuantity, clsTbPrdPriceQuan, clsTbBarcode, clsTbDscntPrmsion);
            InitForm();
            InitData(obj, subObj);
            InitPrdQuanAvlbList();
            InitPrdClrList();
            SetTax();
            GetResources();
            InitEvents();
            if (_formSupplyMain != null) this.Text += " " + _formSupplyMain.GetDocumentNo;
            repositoryItemSearchLookUpEditCustomerBbi.ButtonClick += RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick;
            supCustNo.ButtonClick += supCustNo_ButtonClick;
            barButtonItem2.ItemShortcut = new BarShortcut();// كنسلة F4
            barButtonItem1.ItemShortcut = new BarShortcut(Keys.F4);
            bbiSaveAndNew.ItemShortcut = new BarShortcut(Keys.F3);
            var btn = new BarButtonItem { Caption = "" };
            btn.ItemShortcut = new BarShortcut(Keys.F2);
            btn.ItemClick += SetCashInvoice;
            this.ribbonControl1.Items.Add(btn);
            gridView.OptionsBehavior.Editable = true;
            AllowGridColumns(colsupPrdBarcode);
            AllowGridColumns(colsupPrdNo);
            AllowGridColumns(colsupMsur);

        }
        private void SetAppearanceControl()
        {
            foreach (GridColumn item in gridView.Columns)
                item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            textEditBarcodeNo.BackColor = System.Drawing.Color.Orange;
        }
      
        private void RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                flyDialog.WaitForm(this, 1);
                using (formAddCustomer frm = new formAddCustomer(null, null))
                {
                    flyDialog.WaitForm(this, 0);
                    frm.CloseAfterSave = true;
                    frm.ShowDialog();
                    BbiRefreshCustomers_ItemClick(null, null);
                    bbiCustomerSLE.Refresh();
                    bbiCustomerSLE.EditValue = frm.customersId;
                    
                    InitCustomerObj(frm.customersId);
                }
            }
        }
        private void supCustNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                flyDialog.WaitForm(this, 1);
                using (formAddCustomer frm = new formAddCustomer(null, null))
                {
                    flyDialog.WaitForm(this, 0);
                    frm.CloseAfterSave = true;
                    frm.ShowDialog();
                    BbiRefreshCustomers_ItemClick(null, null);
                    this.tbCustomer = (tblCustomerBindingSource.List as IList<tblCustomer>)?.FirstOrDefault(x => x.id == frm.customersId);
                    supCustNo.EditValue = this.tbCustomer?.custAccNo;
                    supRefNoTextEdit.EditValue = this.tbCustomer?.custNo;
                }
            }
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
                bbiSaveAndNew_ItemClick(null, null);
        }

        private void InitEvents()
        {
            this.KeyDown += FormAddSupplyVoucher_KeyDown;
            dataLayoutControl1.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;

            //    gridView.RowCountChanged += (ss,ee)=> { if (gridView.RowCount == 0) FinalAmount = 0; };
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.CellValueChanged += GridView_CellValueChanged;
            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.FocusedColumnChanged += GridView_FocusedColumnChanged;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.CustomRowCellEditForEditing += GridView_CustomRowCellEditForEditing;
            gridView.HiddenEditor += GridView_HiddenEditor;
            gridView.InitNewRow += GridView_InitNewRow;
            gridView.RowStyle += GridView_RowStyle;
            gridView.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView.HideCustomizationForm += GridView_HideCustomizationForm;
            gridView.ValidatingEditor += GridView_ValidatingEditor;
            gridView.InvalidRowException += GridView_InvalidRowException;
            //gridView.ValidateRow += GridView_ValidateRow;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            gridViewSrchPrd.KeyDown += GridViewSrchPrd_KeyDown;
            gridViewSrchPrd.DoubleClick += GridViewSrchPrd_DoubleClick;
            gridViewSrchPrd.CustomUnboundColumnData += GridViewSrchPrd_CustomUnboundColumnData;
            gridViewSaleReturn.CustomColumnDisplayText += GridViewSaleReturn_CustomColumnDisplayText;

            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            repositoryItemSearchLookUpEditPrdNo.EditValueChanged += RepositoryItemSearchLookUpEditPrdNo_EditValueChanged;
            //  repositoryItemSpinEditQuan.EditValueChanging += RepositoryItemSpinEditQuan_EditValueChanging;
            repositoryItemSearchLookUpEdit1View.CustomUnboundColumnData += RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData;
            repositoryItemSearchLookUpEditCustomerBbi.EditValueChanged += RepositoryItemSearchLookUpEditCustomerBbi_EditValueChanged;
            repositoryItemLookUpEditStrId.EditValueChanged += RepositoryItemLookUpEditStrId_EditValueChanged;
            BtnClosSearchPro.Click += BtnClosSearchPro_Click;
            checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
            checkEditTax.EditValueChanging += CheckEditTax_EditValueChanging;
            supAccNoLookUpEdit.EditValueChanged += SupAccNoTextEdit_EditValueChanged;
            supCurrTextEdit.EditValueChanged += SupCurrTextEdit_EditValueChanged;
            saleNoTextEdit.EditValueChanged += SaleNoTextEdit_EditValueChanged;
            supDscntPercentTextEdit.KeyUp += SupDscntPercentTextEdit_KeyUp;
            supDscntAmountTextEdit.KeyUp += SupDscntAmountTextEdit_KeyUp;
            //supDscntAmountTextEdit.EditValueChanged += SupDscntAmountTextEdit_EditValueChanged;
            supDscntAmountTextEdit.Enter += SupDscntAmountTextEdit_Enter;
            supDscntAmountTextEdit.Leave += SupDscntAmountTextEdit_Leave;
            textEditPaidCash.EditValueChanging += TextEditPaidCash_EditValueChanging;
            textEditPaidCreditCard.EditValueChanging += TextEditPaidCreditCard_EditValueChanging;
            textEditPaidCreditCard.EditValueChanged += TextEditPaidCreditCard_EditValueChanged;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
            ecrTimer.Tick += EcrTimer_Tick;
            //if (this.supplyType != SupplyType.SalesRtrn) supCustNo.EditValueChanged += SupCustNo_EditValueChanged;
            //else supCustNo.EditValueChanging += SupCustNo_EditValueChanging;
            supCustNo.EditValueChanged += SupCustNo_EditValueChanged;
            btnBarCodeInv.Click += btnBarCodeInv_Click;
        }
        private void GridViewSaleReturn_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            if (e.Column.FieldName == "supCustSplId" && e.Value is int cus)
            {
                tblCustomer tblCustomer = clsTbCustomer.GetCustomerObjById(cus);
                if (e.Column.Name == colCustomerName.Name)
                    e.DisplayText = tblCustomer?.custName;
                else if (e.Column.Name == colsupCustSplId.Name)
                    e.DisplayText = tblCustomer?.custNo.ToString();
            }
            else if (e.Column.FieldName == "supIsCash" && e.Value is byte stat)
                e.DisplayText = ClsSupplyStatus.GetPaymentString(stat);
        }
        private void btnBarCodeInv_Click(object sender, EventArgs e)
        {
            if (gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode") != null)
            {

                formBarcode frm = new formBarcode();
                frm.Show();
                frm.SearchProduct(gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode").ToString());
            }
        }
        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
                tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
        }


        private void TextEditPaidCreditCard_EditValueChanged(object sender, EventArgs e)
        {
            double value = 0;
            if (double.TryParse(textEditPaidCreditCard.Text, out value))
            {
                double cashAmount = ((textEditPaidCash.EditValue as double?) ?? 0), creditAmount = value;
                // labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount}";
                labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount:f2}";
                labelRemaingAmountDecimal.Text = $"{(spinEditTotalFinalDecimal.Value - Convert.ToDecimal(cashAmount + creditAmount)):f2}";
                SetSupBankIdVale(value);
            }
        }

        private void SupDscntAmountTextEdit_Leave(object sender, EventArgs e)
        {
            IsDescountValueFocesed = false;

        }

        bool IsDescountValueFocesed;
        private void SupDscntAmountTextEdit_Enter(object sender, EventArgs e)
        {
            IsDescountValueFocesed = true;
        }

        internal void InitObjectsRelatedData(ClsTblCustomer clsTbCustomer, ClsTblStore clsTbStore, ClsTblGroupStr clsTbGroupStr, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur, ClsPrdQuantityOperations clsPrdQuantityOperations, ClsSupplyTarhel clsSupplyTarhel, ClsTblAccount clsTbAccount, ClsTblPrdManufacture clsTbPrdMan, ClsTblEntrySub clsTbEntrySub, ClsTblProductQunatity clsTbPrdQuantity, IClsTblPrdPriceQuan clsTbPrdPriceQuan, ClsTblBarcode clsTbBarcode, ClsTblDscntPrmsion clsTbDscntPrmsion)
        {
            if (clsTbStore == null) return;


            InitObjects(clsTbCustomer, clsTbStore, clsTbGroupStr, clsTbProduct, clsTbPrdMsur, clsPrdQuantityOperations, clsSupplyTarhel, clsTbAccount, clsTbPrdMan, clsTbEntrySub, clsTbPrdQuantity, clsTbPrdPriceQuan, clsTbBarcode, clsTbDscntPrmsion);
            InitPrdStoreObj();

            InitBindingSourceData();
            //this.clsCustBalance = new ClsCustomerBalanceData(new ClsTblSupplyMain(true), null, this.clsTbEntrySub);
            // Task.Run(() => InitBindingSourceData());
            // await InitBindingSourceData();
            // await  InitBindingSourceData();
        }

        private void InitDefaultData()
        {
            this.tax = MySetting.GetPrivateSetting.taxDefault;
            this.autoSupplyTarhel = MySetting.DefaultSetting.autoSupplyTarhel;
            bbiStrIdSLE.EditValue = MySetting.DefaultSetting.defaultStrId;
            clsTbBox = new ClsTblBox();
            var box = clsTbBox.GetBoxObjByAccNo(MySetting.DefaultSetting.defaultBox);
            supBoxIdTextEdit.EditValue = (box != null ? box.id : 0);

            checkEditTax.Checked = MySetting.GetPrivateSetting.checkEditTax;
        }

        private void InitPrdStoreObj()
        {
            this.clsPrdStore = new ClsProductByStore(this.clsTbProduct.GetProductList, this.clsTbPrdQuantity.GetPrdQuantityList);
        }

        private void InitObjects(ClsTblCustomer clsTbCustomer, ClsTblStore clsTbStore, ClsTblGroupStr clsTbGroupStr, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur, ClsPrdQuantityOperations clsPrdQuantityOperations, ClsSupplyTarhel clsSupplyTarhel, ClsTblAccount clsTbAccount, ClsTblPrdManufacture clsTbPrdMan, ClsTblEntrySub clsTbEntrySub, ClsTblProductQunatity clsTbPrdQuantity, IClsTblPrdPriceQuan clsTbPrdPriceQuan, ClsTblBarcode clsTbBarcode, ClsTblDscntPrmsion clsTbDscntPrmsion)
        {
            this.clsTbCustomer = clsTbCustomer;
            this.clsTbStore = clsTbStore;
            this.clsTbGroupStr = clsTbGroupStr;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdMsur;
            this.clsTbBarcode = clsTbBarcode;
            this.clsPrdQuantityOpr = clsPrdQuantityOperations;
            this.clsTbPrdPriceQuan = clsTbPrdPriceQuan;
            this.clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(this.clsTbPrdPriceQuan, this.clsTbPrdMsur);
            this.clsSupplyTarhel = clsSupplyTarhel;
            this.clsTbAccount = clsTbAccount;
            this.clsTbPrdMan = clsTbPrdMan;
            this.clsTbEntrySub = clsTbEntrySub;
            this.clsTbPrdQuantity = clsTbPrdQuantity;
            this.clsTbDscntPrmsion = clsTbDscntPrmsion;
            this.clsTbBox = new ClsTblBox();

            this.clsPrdManAvrPrice = new ClsPrdManAvrPrice(this.clsTbPrdPriceQuan, this.clsTbPrdMan, this.clsTbPrdMsur);
        }

        private void InitBindingSourceData()
        {
            new ClsTblBank().InitBankLookupEdit(supBankIdTextEdit);
            supBoxIdTextEdit.Properties.DataSource = this.clsTbBox.GetBoxList.Where(x => x.boxBrnId == Session.CurBranch.brnId);
            //new ClsTblBox().InitBoxLookupEdit(supBoxIdTextEdit);
            this.clsTbBox.InitBoxLookupEditAccNoValMbr(supAccNoLookUpEdit);
            tblAccountBindingSource.DataSource = this.clsTbAccount.GetAccountListCategoery3();
            tblCustomerBindingSource.DataSource = this.clsTbCustomer.GetCustomersList();
            tblCurrencyBindingSource.DataSource = this.curData.GetCurrencyList;
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            InitPrdBindingSourceData(Convert.ToInt16(bbiStrIdSLE.EditValue));
        }


        private void InitPrdBindingSourceData(short strId)
        {
            Console.WriteLine($"================strId = {strId}");
            if (strId == 0) return;
            var tbProductList = this.clsPrdStore.GetProductListByStrId(strId);
            tblProductBindingSource.DataSource = tbProductList;
            InitPrdPriceDic(tbProductList);
        }


        private void InitPrdPriceDic(IEnumerable<tblProduct> tbProducList)
        {
            ClsStopWatch stopWatch = new ClsStopWatch();


            var q1 = (from prd in tbProducList
                      group prd by prd.id into prdGrp
                      join prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList
                      on prdGrp.Key
                      equals prdMsur.ppmPrdId
                      where prdMsur.ppmDefault ==true
                      select new
                      {
                          prdId = prdGrp.Key,
                          prdPrice = clsTbPrdMsur.GetppmMinSalePrice(prdGrp.FirstOrDefault().prdPriceTax, prdMsur),
                          PrdMsurName =prdMsur.ppmMsurName
                      }).Select(x => new { x.prdId, x.prdPrice, x.PrdMsurName });
            this.listPrdMsurName = q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.PrdMsurName);
            this.listPrdPriceDic = q1.GroupBy(x => x.prdId).ToDictionary(x => x.Key, y => y.FirstOrDefault()?.prdPrice);

            string time = stopWatch.Stop("InitPrdPriceDicElapssedTime");
            LogHelper.GetLogger().Debug(time);

        }


        public IList<tblPrdPriceMeasurment> _tbPPMList;
        public IList<tblPrdPriceMeasurment> tbPPMList
        {
            get
            {
                if (_tbPPMList == null)
                {

                    accountingEntities db1 = new accountingEntities();
                    _tbPPMList = (from a in db1.tblPrdPriceMeasurments
                                  where a.ppmBrnId == Session.CurBranch.brnId
                                  orderby a.ppmPrdId
                                  select a).ToList();
                }
                return _tbPPMList;
            }
        }

        private void InitObjects()
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            //this.clsSupply = new ClsSupply();
            //this.clsTbPrdQuantity = new ClsTblProductQunatity();
            stopWatch.Stop("InitObjectsVchr");

        }

        private void InitPrdClrList()
        {
            this.listPrdQuantDic = new Dictionary<int, double>();
        }

        private void InitData(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.isCash = 1;

                if (this.supplyType != SupplyType.SalesRtrn) InitSupplyMainObj();
                gridControl.ProcessGridKey += GridControl_ProcessGridKey;
                supDateDateEdit.ReadOnly = !MySetting.DefaultSetting.AllowSaveInvoInBeforeDate;
            }
            else
            {
                this.isNew = false;
                this.supMainId = obj.id;

                this.supNoOld = obj.supNo;
                this.accNo = Convert.ToInt64(obj.supAccNo);
                this.supAccNoOld = Convert.ToInt64(obj.supAccNo);
                this.currency = Convert.ToByte(obj.supCurrency);
                this.isCash = Convert.ToByte(obj.supIsCash);
                this.hasTax = (obj.supTaxPrice > 0) ? true : false;
                this.tbSupplyMain = obj;
                this.checkEditTaxValue = this.hasTax;
                this.totalFinalOld = (obj.supTotal + Convert.ToDouble(obj.supTaxPrice)) - Convert.ToDouble(obj.supDscntAmount);
                SetAccountBinding(this.isCash);
                IsCash(this.isCash);

                tblSupplyMainBindingSource.DataSource = this.tbSupplyMain;
                db.tblSupplyMains.Attach(tblSupplyMainBindingSource.Current as tblSupplyMain);

                radioGroupIsCash.EditValue = this.isCash;
                bbiStrIdSLE.EditValue = obj.supStrId;

                InitSupSubGrid(subObj);
                DisableItems();
                SetRibbonButtonsVisisbility();
                SetGridProperties();
                InitInvoiceObjects();
                SetBbiCustomerInvoice();
                InitPrdQuanOld(subObj);
                InitNotification();
                // XtraMessageBox.Show(obj.supDscntAmount_Round.ToString());
                // this.txtdisround.Text = obj.supDscntAmount_Round.ToString();
                Txtdisround_EditValueChanged(null, null);
                EnabledORDisabledUpdate(false);
            }
        }
        public void EnabledORDisabledUpdate(bool Enabled)
        {
            layoutControl1.OptionsView.IsReadOnly
                  = layoutControl3.OptionsView.IsReadOnly
                  = Enabled ? DevExpress.Utils.DefaultBoolean.False : DevExpress.Utils.DefaultBoolean.True;
            supCurrencyChngTextEdit.ReadOnly = supCurrTextEdit.ReadOnly = checkEdit1.ReadOnly =
                checkEditTax.ReadOnly = gridView.OptionsBehavior.ReadOnly = !Enabled;
            gridView.OptionsBehavior.Editable
           = layoutControlGroup5.Enabled = bbiStrIdSLE.Enabled = bbiEditQuantity.Enabled = bbiEditPrice.Enabled =
             btnDeleteRow.Enabled = simpleButton1.Enabled
               = simpleButton2.Enabled = Enabled;
        }
        private void InitSupplyMainObj()
        {
            this.hasTax = true;
            this.checkEditTaxValue = MySetting.GetPrivateSetting.checkEditTax;

            this.tbSupplyMain = new tblSupplyMain()
            {
                supAccNo = MySetting.DefaultSetting.defaultBox,
                supStrId = MySetting.DefaultSetting.defaultStrId,
                supDate = DateTime.Now,
                supIsCash = 1,
                supUserId = Session.CurrentUser.id,
                supBrnId = Session.CurBranch.brnId,
                supStatus = this.status1
            };

            tblSupplyMainBindingSource.DataSource = this.tbSupplyMain;
            SupAccNoTextEdit_EditValueChanged(supAccNoLookUpEdit, EventArgs.Empty);
        }

        private void InitSupSubGrid(IEnumerable<tblSupplySub> subObj)
        {
            List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();
            this.tbSupplySubListOld = subObj.Select(a => new tblSupplySub { supPrdId = a.supPrdId, supMsur = a.supMsur, supQuanMain = a.supQuanMain }).ToList();

            foreach (var tbSupplySub in subObj)
            {
                tbSupplySubList.Add(tbSupplySub);
                db.tblSupplySubs.Attach(tbSupplySub);
            }
            tblSupplySubBindingSource.DataSource = tbSupplySubList;
        }

        private void InitNotification()
        {
            SetNotificationDateVisibility();

            this.clsTbNotification = new ClsTblNotification();
            if (!this.clsTbNotification.IsNotFoundBySupId(NotStatus.Sales, this.tbSupplyMain.id)) return;

            this.tbNotification = this.clsTbNotification.GetNotObjByStatusNdSupId(NotStatus.Sales, this.tbSupplyMain.id);
            this.clsTbNotification.Attach(this.tbNotification);

            notDateTextEdit.EditValue = this.tbNotification.notDate;
        }

        private void InitPrdQuanOld(IEnumerable<tblSupplySub> subObj)
        {
            this.tbPrdQuanListOld = new List<ClsProductQuantList>();

            foreach (var tbSupplySub in subObj)
                if (tbSupplySub.supPrdManufacture) foreach (var tbPrdMan in this.clsTbPrdMan.GetPrdManListByPrdId(Convert.ToInt32(tbSupplySub.supPrdId)))
                        this.tbPrdQuanListOld.Add(new ClsProductQuantList()
                        {
                            prdId = tbPrdMan.manPrdSubId,
                            prdPriceMsurId = tbPrdMan.manPrdMsurId,
                            prdQuantity = Convert.ToDouble(tbPrdMan.manQuan) * Convert.ToDouble(tbSupplySub.supQuanMain),
                            prdStrId = Convert.ToInt16(this.tbSupplyMain.supStrId),
                        });
                else this.tbPrdQuanListOld.Add(new ClsProductQuantList()
                {
                    prdId = Convert.ToInt32(tbSupplySub.supPrdId),
                    prdPriceMsurId = Convert.ToInt32(tbSupplySub.supMsur),
                    prdQuantity = Convert.ToDouble(tbSupplySub.supQuanMain),
                    prdStrId = Convert.ToInt16(this.tbSupplyMain.supStrId),
                });
        }

        private void InitForm()
        {
            switch (this.supplyType)
            {
                case SupplyType.Sales:
                    bbiPriceOffer.Visibility = BarItemVisibility.Always;
                    SaleForm();
                    break;
                case SupplyType.SalesRtrn:
                    SaleForm();
                    SaleRtrnForm();
                    break;
                case SupplyType.DirectSalesRtrn:
                    SaleForm();
                    SaleRtrnDirectForm();
                    break;
            }
        }

        private void SetLayoutGroupExpandMode()
        {
            if (this.supplyType == SupplyType.SalesRtrn) return;
            layoutControlGrooupMain.Expanded = MySetting.GetPrivateSetting.supplySaleExpanded;
        }

        private void SupAccNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue(this.accBoxName) == null) return;

            this.accNo = Convert.ToInt64(editor.GetColumnValue("boxAccNo"));
            this.accName = Convert.ToString(editor.GetColumnValue("boxName"));
            this.currency = Convert.ToByte(editor.GetColumnValue("boxCurrency"));
            this.tbSupplyMain.supAccNo = this.accNo;
            this.tbSupplyMain.supAccName = this.accName;
            this.tbSupplyMain.supCurrency = this.currency;
            SetSupplyNo();
            SetBbiCustomerSLE();

            supAccNameTextEdit.EditValue = this.accName;
            supCurrTextEdit.EditValue = this.currency;
            bbiCustomerSLE.EditValue = null;
        }

        private void SetBbiCustomerSLE()
        {
            if (this.supplyType != SupplyType.Sales) return;
            tblCustomerBindingSource.DataSource = this.clsTbCustomer.GetTblCustomerListByCurrencyId(this.currency).Where(x => x.custBrnId == Session.CurBranch.brnId);
        }

        private void SetSupplyNo()
        {
            if (!this.isNew) this.supNo = this.supNoOld;
            else
            {

                if (ItemForSalesNo.Visibility == LayoutVisibility.Always)
                {
                    var selectedInvoice = ((tblSupplyMain)saleNoTextEdit.GetSelectedDataRow()).ShallowCopy();
                    if (selectedInvoice != null)
                    {
                        this.supNo = selectedInvoice.supNo;
                    }
                }
                else
                { //this.supNo = this.clsSupply.StoreEntryNoBox(this.accNo, this.status1, this.status2);
                    var data = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                                   x.supDate.Value >= Session.CurrentYear.fyDateStart.Date && (x.supStatus == status1 || x.supStatus == status2));
                    if (data.Count() > 0)
                        this.supNo = ((data.Max(x => x.supNo) as int?) ?? 0) + 1;
                    else this.supNo = 1;
                }

            }

            this.tbSupplyMain.supNo = this.supNo;
            supNoTextEdit.EditValue = this.supNo;
        }

        private void RepositoryItemSearchLookUpEditCustomerBbi_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor == null) return;
            if (editor.EditValue == null)
            {
                this.tbCustomer = null;
                supRefNoTextEdit.EditValue = null;
                return;
            }
            this.tbCustomer = editor.Properties.View.GetFocusedRow() as tblCustomer;
            if (tbCustomer != null)
            {
                supRefNoTextEdit.EditValue = this.tbCustomer.custNo;
                this.tbSupplyMain.supCustSplId = this.tbCustomer.id;
            }

        }


        private void RepositoryItemLookUpEditStrId_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            short strId = Convert.ToInt16(editor.GetColumnValue("id"));
            this.tbSupplyMain.supStrId = strId;
            InitPrdBindingSourceData(strId);
        }

        private async void SupCustNo_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;
            this.tbCustomer = editor.GetSelectedDataRow() as tblCustomer;
            if (this.tbCustomer == null)
            {
                editor.EditValue = null;
                return;
            }
            this.cstId = this.tbCustomer.id;
            this.accNo = this.tbCustomer.custAccNo;
            this.accName = this.tbCustomer.custAccName;
            this.currency = Convert.ToByte(this.tbCustomer.custCurrency);

            this.tbSupplyMain.supAccNo = this.accNo;
            this.tbSupplyMain.supAccName = this.accName;
            this.tbSupplyMain.supCurrency = this.currency;
            this.clsCustBalance = new ClsCustomerBalanceData(false);
            this.clsCustBalance.CalculateBalance(this.tbCustomer.custAccNo);
            supCustName.EditValue = this.accName;
            supCustNo.EditValue = this.accNo;
            supCurrTextEdit.EditValue = this.currency;
            supRefNoTextEdit.EditValue = this.tbCustomer.custNo;
            SetSupplyNo();
        }

        private void SupCustNo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            //var tbCustomer = editor.GetSelectedDataRow() as tblCustomer;
            this.tbCustomer = editor.GetSelectedDataRow() as tblCustomer;

            if (tbCustomer == null)
            {
                editor.EditValue = null;
                return;
            }
            this.cstId = tbCustomer.id;
            this.accNo = tbCustomer.custAccNo;
            this.accName = tbCustomer.custAccName;
            this.currency = Convert.ToByte(tbCustomer.custCurrency);

            this.tbSupplyMain.supAccNo = this.accNo;
            this.tbSupplyMain.supAccName = this.accName;
            this.tbSupplyMain.supCurrency = this.currency;

            supCustName.EditValue = this.accName;
            supCurrTextEdit.EditValue = this.currency;
            supRefNoTextEdit.EditValue = this.tbCustomer.custNo;
        }

        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            if (this.currency > 1)
            {
                this.tbSupplyMain.supCurrencyChng = Convert.ToInt16(editor.GetColumnValue("curChange"));
                supCurrencyChngTextEdit.EditValue = editor.GetColumnValue("curChange");
                ItemForsupCurrencyChng.Visibility = LayoutVisibility.Always;
            }
            else
            {
                this.tbSupplyMain.supCurrencyChng = null;
                supCurrencyChngTextEdit.EditValue = null;
                ItemForsupCurrencyChng.Visibility = LayoutVisibility.Never;
            }
        }

        private void TextEditPaidCash_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (supBoxIdTextEdit.EditValue == null || supBoxIdTextEdit.EditValue == DBNull.Value)
            {
                var box = ((IEnumerable<tblAccountBox>)supBoxIdTextEdit.Properties.DataSource).FirstOrDefault();
                if (box != null) supBoxIdTextEdit.EditValue = box.id;
            }
            if (!(spinEditTotalFinalDecimal.Value > Convert.ToDecimal(e.NewValue))) return;
            if (Convert.ToDecimal(e.NewValue) > spinEditTotalFinalDecimal.Value * 2)
            {
                e.Cancel = true;
                e.NewValue = 0;
                return;
            }
            if (Convert.ToDouble(e.NewValue) == 0) return;
            double cashAmount = Convert.ToDouble(e.NewValue), creditAmount = (!string.IsNullOrEmpty(textEditPaidCreditCard.Text)) ? Convert.ToDouble(textEditPaidCreditCard.EditValue) : 0;
            //labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount}";
            labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount:f2}";
            labelRemaingAmountDecimal.Text = $"{(spinEditTotalFinalDecimal.Value - Convert.ToDecimal(cashAmount + creditAmount)):f2}";
            SetSupBoxIdVale(Convert.ToDouble(e.NewValue));
        }
        private void SetSupBoxIdVale(double cashAmount)
        {
            var Box = clsTbBox.GetBoxList.Where(b => b.boxAccNo == MySetting.DefaultSetting.defaultBox).ToList();
            short boxid = 0;
            if (Box.Count() > 0)
                boxid = Box[0].id;
            this.tbSupplyMain.supBoxId = (cashAmount > 0) ? boxid : (short)0;
            supBoxIdTextEdit.EditValue = (cashAmount > 0) ? boxid : 0;
        }
        private void TextEditPaidCreditCard_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (supBankIdTextEdit.EditValue == null || supBankIdTextEdit.EditValue == DBNull.Value)
            {
                var banck = ((IEnumerable<tblAccountBank>)supBankIdTextEdit.Properties.DataSource).FirstOrDefault();
                if (banck != null) supBankIdTextEdit.EditValue = banck.id;
            }
            if (Convert.ToDouble(e.NewValue) == 0) return;
            if (!(spinEditTotalFinalDecimal.Value > Convert.ToDecimal(e.NewValue))) return;
            if (Convert.ToDecimal(e.NewValue) > spinEditTotalFinalDecimal.Value * 2)
            {
                e.Cancel = true;
                e.NewValue = 0;
                return;
            }

            //double  = Convert.ToDouble(.Text), 
            //    creditAmount = Convert.ToDouble(e.NewValue);
            double creditAmount = Convert.ToDouble(e.NewValue),
                cashAmount = (!string.IsNullOrEmpty(textEditPaidCash.Text)) ? Convert.ToDouble(textEditPaidCash.EditValue) : 0;

            labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount:f2}";
            labelRemaingAmountDecimal.Text = $"{(spinEditTotalFinalDecimal.Value - Convert.ToDecimal(cashAmount + creditAmount)):f2}";
            SetSupBankIdVale(Convert.ToDouble(e.NewValue));

            // if (!double.TryParse(labelTotalFinalDecimal.Text, out double totaln) || totaln >= Convert.ToDouble(e.NewValue)) return;
        }

        private void FormAddSupplyVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isNew)
            {
                if (e.Control && e.Shift && e.Alt && e.KeyCode == Keys.U)
                    EnabledORDisabledUpdate(true);
                return;
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.N)
                supNoTextEdit.Enabled = true;
            if (e.KeyCode == Keys.F11)
            {
                textEditPaidCreditCard.Focus();
                SetECRamout();
                if (!MySetting.DefaultSetting.isSendToECR) return;
                SendECR();
            }
            if (e.Control && e.KeyCode == Keys.F && !gridControl.ContainsFocus && this.supplyType != SupplyType.SalesRtrn) ShowPrdSearchPanel();
        }

        private void FlyDialogPrd_Shown(object sender, EventArgs e)
        {
            gridViewSrchPrd.ShowFindPanel();
            gridViewSrchPrd.ShowFindPanel();
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
        private void repItemButEditSelectPro_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            InitPrdSrch();
        }

        private void InitPrdSrch()
        {

            this.tbProduct = gridViewSrchPrd.GetFocusedRow() as tblProduct;
            if (tbProduct == null) return;
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(this.tbProduct.id);

            if (this.tbPrdMsur == null) return;
            this.barcodeNo = (this.tbPrdMsur.ppmBarcode1 != null ? this.tbPrdMsur.ppmBarcode1 : clsTbBarcode.GetBarcodeNoByPrdMsurId(this.tbPrdMsur.ppmId));
            if (CheckProductGrid(this.barcodeNo)) return;
            gridView.AddNewRow();
            InitRowData1(new InitNewRowEventArgs(-2147483647));
            gridView.UpdateCurrentRow();

            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            SetPrdQuanAvlbList();
        }
        private void SupDscntPercentTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateDiscountAmount(supDscntPercentTextEdit.EditValue.ToString(), out double discountPercent)) return;
            for (short i = 0; i < gridView.DataRowCount; i++)
                gridView.SetRowCellValue(i, colsupDscntPercent, discountPercent);
            CalculateDiscountAmount(discountPercent);
            ValidateDscntAmount(discountPercent);
            CalculateTotalFinal();
        }

        private void SupDscntAmountTextEdit_KeyUp(object sender, KeyEventArgs e)
        {

            if (!ValidateDiscountAmount(supDscntAmountTextEdit.Text, out double discountAmount)) return;
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;
            double discountPercent = ((discountAmount / totalAmount) * 100);
            supDscntPercentTextEdit.EditValue = discountPercent;
            CalculateDiscountAmount(discountPercent);
            ValidateDscntAmount(discountPercent);
            CalculateTotalFinal();
        }

        private void SupDscntAmountTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (IsDescountValueFocesed == false) return;
            if (!ValidateDiscountAmount(supDscntAmountTextEdit.Text, out double discountAmount)) return;
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;
            double discountPercent = ((discountAmount / totalAmount) * 100);
            supDscntPercentTextEdit.EditValue = discountPercent;
            CalculateDiscountAmount(discountPercent);
            ValidateDscntAmount(discountPercent);
            CalculateTotalFinal();
        }

        //public void SetDiscount(double discount)
        //{

        //    this.tbSupplySubList.ForEach(x =>
        //    {
        //        x.supDscntPercent = discount;
        //        gridView.SetRowCellValue(gridView.GetRowHandle(this.tbSupplySubList.IndexOf(x)), SetColumnDiscountPercent, discount);
        //    });
        //    DetailsGridView.RefreshData();
        //}

        private void spinEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            double net = 0;
            if (double.TryParse(spinEdit1.Text, out net))
            {
                this.hasTax = checkEditTax.Checked;
                if (net == 0) return;
                var total = Convert.ToDouble(labelTotalPriceDecimal.Text);
                var totalFainl = Convert.ToDouble(spinEditTotalFinalDecimal.Text);
                var Tax = this.hasTax ? Convert.ToDouble(this.tax) : 0;
                var discount = MySetting.DefaultSetting.CalcTaxAfterDiscount ? (1 - (net / (total * (1 + (Tax / 100))))) : ((totalFainl - net) / total);
                spinEdit1.EditValue = null;
                if (!ValidateDscntAmount(discount * 100)) return;
                supDscntPercentTextEdit.EditValue = discount * 100;
                SupDscntPercentTextEdit_KeyUp(null, null);
            }
        }

        private bool ValidateDscntAmount(double discountPercent)
        {
            if (Session.CurrentUser.id == 1) return true;
            if (!this.clsTbDscntPrmsion.IsDscntUserFound(Session.CurrentUser.id)) return ValidateDscntPermission();
            if (!ValidateDscntPermission()) return false;
            if (this.clsTbDscntPrmsion.GetDscntAmountByUsrId(Session.CurrentUser.id) >= discountPercent) return true;

            supDscntPercentTextEdit.EditValue = null;
            supDscntAmountTextEdit.EditValue = null;
            ClsXtraMssgBox.ShowError("عذراً لقد تجاوزت الحد المسموح للخصم!");
            return false;
        }

        private bool ValidateDscntPermission()
        {
            if (this.clsTbDscntPrmsion.IsDscntUserPermission(Session.CurrentUser.id)) return true;

            supDscntPercentTextEdit.EditValue = null;
            supDscntAmountTextEdit.EditValue = null;
            ClsXtraMssgBox.ShowError($"عذراً ليس لديك صلاحية الخصم!");

            return false;
        }

        //private void SupDscntAmountTextEdit_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (!ValidateDiscountAmount(supDscntAmountTextEdit.Text, out double discountAmount)) return;
        //    if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;

        //    double discountPercent =((discountAmount / totalAmount) * 100);
        //    //double discountPercent = Math.Round((discountAmount / totalAmount) * 100, 2, MidpointRounding.AwayFromZero);
        //    supDscntPercentTextEdit.EditValue = discountPercent;
        //    CalculateDiscountAmount(discountPercent);
        //    CalculateTotalFinal();
        //}

        private bool ValidateDiscountAmount(string textEdit, out double discount)
        {
            if (double.TryParse(textEdit, out discount) && discount > 0)
            {
                SetDiscountCoumnsEditProperty(false);
                return true;
            }

            ClearDiscountValues();
            CalculateTotalFinal();
            SetDiscountCoumnsEditProperty(true);
            return false;
        }

        private void SetDiscountCoumnsEditProperty(bool allowEdit)
        {
            colsupDscntAmount.OptionsColumn.AllowEdit = allowEdit;
            colsupDscntPercent.OptionsColumn.AllowEdit = allowEdit;
        }

        private void CalculateDiscountAmount(double discountPercent)
        {
            if (discountPercent == 0)
            {
                CalculateGridDiscount(0, 0, true);
                return;
            }
            //double discountAmount = double.Parse(labelTotalPriceDecimal.Text) * (discountPercent / 100);
            double discountAmount = Math.Round(double.Parse(labelTotalPriceDecimal.Text) * (discountPercent / 100), 2, MidpointRounding.AwayFromZero);
            double.TryParse(labelTotalPriceDecimal.Text, out double totalPrice);

            supDscntAmountTextEdit.EditValue = discountAmount;
            //labelDiscountDecimal.Text = $"{discountAmount}";
            //labelTotalDecimal.Text = $"{totalPrice - discountAmount}";
            labelDiscountDecimal.Text = $"{discountAmount:f2}";
            labelTotalDecimal.Text = $"{totalPrice - discountAmount:f2}";
            SetColumnDiscountPercent(discountPercent);
        }

        private void CalculateTotalFinal()
        {
            double.TryParse(labelTotalDecimal.Text, out double totalAmount);

            CalculateTotalTax(totalAmount);
            spinEditTotalFinalDecimal.Value = Convert.ToDecimal(totalAmount + this.totalTax);
            //spinEditTotalFinalDecimal.Value = totalAmount + this.totalTax;
            if (checkEdit1.Checked)
            {
                double fraction =Convert.ToDouble(spinEditTotalFinalDecimal.Value - Math.Truncate(spinEditTotalFinalDecimal.Value));
                if (fraction > 0)
                    while (!isDivisibleBy5(fraction.ToString().Remove(4, fraction.ToString().Length - 4)))
                    {
                        fraction = (fraction + 0.01);
                        totalAmount = (totalAmount + 0.01);
                    }
            }
            if (spinEditTotalFinalDecimal.Value != 0)
            {
                //spinEditTotalFinalDecimal.EditValue = (totalAmount + this.totalTax).ToString().Remove(4, (totalAmount + this.totalTax).ToString().Length - 4);
                // spinEditTotalFinalDecimal.EditValue = $"{totalAmount + this.totalTax:f2}";
                spinEditTotalFinalDecimal.Value = Convert.ToDecimal(totalAmount + this.totalTax);
            }
        }
        bool isDivisibleBy5(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return true;
            int n = str.Length;
            return (((str[n - 1] - '0') == 0) || ((str[n - 1] - '0') == 5));
        }
        private void CalculateTotalTax(double totalAmount)
        {
            //if (!this.hasTax  ) return;
            //this.totalTax = Math.Round(totalAmount * (Convert.ToDouble(this.tax) / 100), 2, MidpointRounding.AwayFromZero);
            //labelTotalTaxDecimal.Text = $"{this.totalTax:f2}";

            if (hasTax)
            {
                double taxsum = 0;
                for (short i = 0; i < gridView.DataRowCount; i++)
                {
                    if (gridView.GetRowCellValue(i, colsupTaxPrice) != null)
                    {
                        taxsum += double.Parse(gridView.GetRowCellValue(i, colsupTaxPrice).ToString());
                    }
                }
                this.totalTax = taxsum;// Math.Round(taxsum, 2);// Math.Round(totalAmount * (Convert.ToDouble(this.tax) / 100), 2, MidpointRounding.AwayFromZero);
                                       //  labelTotalTaxDecimal.Text = $"{this.totalTax}";
                labelTotalTaxDecimal.Text = $"{this.totalTax:f2}";
            }
            else
            {
                this.totalTax = 0;
                // labelTotalTaxDecimal.Text = $"{this.totalTax}";
                labelTotalTaxDecimal.Text = $"{this.totalTax:f2}";
            }
        }

        private void ClearDiscountValues()
        {
            SetColumnDiscountPercent(null);
            supDscntAmountTextEdit.Text = null;
            supDscntPercentTextEdit.EditValue = null;
            labelDiscountDecimal.Text = "0.00";
            labelTotalDecimal.Text = labelTotalPriceDecimal.Text;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (supDscntPercentTextEdit.Value <= 0)
            {
                var items = ((System.Windows.Forms.BindingSource)gridView.DataSource).List as IList<TempSupplySub>;
                if (items == null) return;
                double _discountAmount = items.Sum(x => x.supDscntAmount ?? 0);
                supDscntAmountTextEdit.EditValue = _discountAmount;
                if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;
                double discountPercent = ((_discountAmount / totalAmount) * 100);

            }
            for (short i = 0; i < gridView.DataRowCount; i++)
                gridView.SetRowCellValue(i, colsupDscntPercent, supDscntPercentTextEdit.Value);
            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                var dpr = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntPercent));
                var tp = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPercent));
                var ta = Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice)) * Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                var ntac = (ta * tp / 100);
                var nta = ntac - (ntac * dpr / 100);

                gridView.SetRowCellValue(i, colsupTaxPrice, MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : ntac);

                SetColumnDiscountAmount(i, supDscntPercentTextEdit.Value);
            }
        }
        private void SetColumnDiscountPercent(object discountPercent)
        {

            //for (short i = 0; i < gridView.DataRowCount; i++)
            //    gridView.SetRowCellValue(i, colsupDscntPercent, discountPercent);

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                var dpr = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntPercent));
                var tp = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPercent));
                var ta = Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice)) * Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                var ntac = (ta * tp / 100);
                var nta = ntac - (ntac * dpr / 100);
                gridView.SetRowCellValue(i, colsupDscntPercent, discountPercent);
                gridView.SetRowCellValue(i, colsupTaxPrice, MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : ntac);

                SetColumnDiscountAmount(i, discountPercent);
            }
        }

        private void SetColumnDiscountAmount(short i, object discountPercent)
        {
            if (discountPercent == null)
            {
                gridView.SetRowCellValue(i, colsupDscntAmount, null);
                return;
            }

            double dscntPercent = Convert.ToDouble(discountPercent);
            double salePrice = Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice));
            salePrice *= Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));

            double dscntAmount = Math.Round(salePrice * (dscntPercent / 100), 2, MidpointRounding.AwayFromZero);
            gridView.SetRowCellValue(i, colsupDscntAmount, dscntAmount);
            double tax = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPrice));
            gridView.SetRowCellValue(i, colsupTotalPrice, salePrice - dscntAmount + tax);
        }

        private bool ValidateTextEditNullOrZero(TextEdit textEdit)
        {
            return (string.IsNullOrEmpty(textEdit.Text) || Convert.ToDouble(textEdit.EditValue) == 0) ? true : false;
        }

        private void SetSupBankIdVale(double creditAmount)
        {
            this.tbSupplyMain.supBankId = (creditAmount > 0) ? MySetting.DefaultSetting.defaultBank : (short)0;
            supBankIdTextEdit.EditValue = (creditAmount > 0) ? MySetting.DefaultSetting.defaultBank : 0;
        }

        private void SaleNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
           SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbSupplyMain = ((tblSupplyMain)editor.GetSelectedDataRow()).ShallowCopy();
            //this.tbSupplyMain.supNo = this.supNo;
            this.tbSupplyMain.supDate = DateTime.Now;
            this.tbSupplyMain.supUserId = Session.CurrentUser.id;
            this.tbSupplyMain.supBrnId = Session.CurBranch.brnId;
            this.tbSupplyMain.supStatus = (byte)this.supplyType;
            this.supMainId = this.tbSupplyMain.id;
            this.currency = (byte)this.tbSupplyMain.supCurrency;
            this.isCash = (byte)this.tbSupplyMain.supIsCash;
            this.hasTax = (this.tbSupplyMain.supTaxPrice > 0) ? true : false;
            this.tbSupplySubListOld = null;

            barCheckItem1.Checked = false;
            radioGroupIsCash.EditValue = this.isCash;
            checkEditTax.Checked = this.hasTax;

            IsCash(this.isCash);
            SetAccountBinding(this.isCash);
            this.supNo = tbSupplyMain.supNo;
            supNoTextEdit.EditValue = tbSupplyMain.supNo;
            this.tbSupplyMain.supNo = this.supNo;
            tblSupplyMainBindingSource.DataSource = this.tbSupplyMain;
            gridView.OptionsBehavior.Editable = false;
            SetSupplyNo();
            GetSupplySubData();
            CalculateTotalAmount();
            SetBbiCustomerInvoice();
        }

        private void GetSupplySubData()
        {
            var lis = db.tblSupplyMains.AsQueryable().Where(x => x.supNo == this.tbSupplyMain.supNo && (x.supStatus == 11 || x.supStatus == 12)
            && x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd).ToList();
            IEnumerable<tblSupplySub> tbSupSubList = this.clsTbSupplySub.GetSupplySubListBySupId(this.supMainId);
            if (lis.Count() > 0)
            {
                List<tblSupplySub> AllSupListInRet = new List<tblSupplySub>();
                List<tblSupplySub> AllSupListNotInRet = new List<tblSupplySub>();
                foreach (var item in lis)
                    AllSupListInRet.AddRange(this.clsTbSupplySub.GetSupplySubListBySupId(item.id));
                foreach (var item1 in tbSupSubList)
                {
                    double SumQ1 = AllSupListInRet.Where(x => x.supMsur == item1.supMsur).Sum(x => x.supQuanMain).Value;
                    double SumQ2 = tbSupSubList.Where(x => x.supMsur == item1.supMsur).Sum(x => x.supQuanMain).Value;
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

            this.tbSupplySubListOld = new List<tblSupplySub>();
            foreach (var tbSupplySub in tbSupSubList)
            {
                tbSupplySub.supDebit = tbSupplySub.supCredit;
                tbSupplySub.supCredit = 0;
                if (tbSupplySub.supCurrency != 1)
                {
                    tbSupplySub.supDebit = Convert.ToDouble(tbSupplySub.supCreditFrgn);
                    tbSupplySub.supCreditFrgn = 0;
                }
                this.tbSupplySubListOld.Add(tbSupplySub.ShallowCopy());
            }
            if (tbSupSubList.Count() > 0)
                tblSupplySubBindingSource.DataSource = tbSupSubList;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (barCheckItem1.Checked && gridView.SelectedRowsCount < 1)
            {
                XtraMessageBox.Show(_resource.GetString("saleRtrnMarkErrMssg"));
                gridView.OptionsSelection.MultiSelect = true;
                barCheckItem1.Checked = false;
                return;
            }
            else if (barCheckItem1.Checked && gridView.SelectedRowsCount >= 1)
            {
                List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();

                for (short i = 0; i < gridView.SelectedRowsCount; i++)
                    tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplySub);
                tblSupplySubBindingSource.DataSource = tbSupplySubList;
                gridView.OptionsBehavior.Editable = true;
                foreach (GridColumn item in gridView.Columns)
                {
                    if (item != colsupQuanMain)
                        DisableGridColumns(item);
                }
                gridView.OptionsSelection.MultiSelect = false;
            }
            else if (!barCheckItem1.Checked && this.tbSupplySubListOld != null)
            {
                List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();
                this.tbSupplySubListOld.ForEach(a => tbSupplySubList.Add(a.ShallowCopy()));
                gridView.OptionsSelection.MultiSelect = true;
                tblSupplySubBindingSource.DataSource = tbSupplySubList;
            }
            else
                gridView.OptionsSelection.MultiSelect = true;

            CalculateTotalAmount();
        }

        private void CheckEditTax_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.Text == "فاتورة مردود مبيعات") return;
            if (Convert.ToBoolean(e.NewValue) != this.checkEditTaxValue)
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
                else
                {
                    this.checkEditTaxValue = Convert.ToBoolean(e.NewValue);
                }
            }
        }

        private void CheckEditTax_EditValueChanged(object sender, EventArgs e)
        {
            SetTax();
        }

        private void SetTax()
        {
            this.hasTax = (checkEditTax.Checked) ? true : false;
            SaveTaxSettings();
            HasTax();
        }

        private void SaveTaxSettings()
        {
            MySetting.GetPrivateSetting.checkEditTax = this.hasTax;
            MySetting.WriterSettingXml();
        }

        private void radioGroupIsCash_EditValueChanged(object sender, EventArgs e)
        {
            this.isCash = (byte)((RadioGroup)sender).EditValue;
            if (this.tbSupplyMain != null)
                this.tbSupplyMain.supIsCash = this.isCash;

            IsCash(this.isCash);
            SetAccountBinding(this.isCash);
            ClearAccountFileds();
            ResetCustomerSLE();
            SetCustomerRibbonGroupVisibility((this.isCash == 1) ? BarItemVisibility.Always : BarItemVisibility.Never);

            SetNotificationDateVisibility();
            layoutControlGroup9.Visibility = (this.isCash == 2 && !MySetting.DefaultSetting.PayPartInvoValue) ? LayoutVisibility.Never : LayoutVisibility.Always;


        }

        private void SetNotificationDateVisibility()
        {
            ItemFornotDate.Visibility = this.isCash == 2 ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void ResetCustomerSLE()
        {
            this.tbCustomer = null;
            bbiCustomerSLE.EditValue = null;
            supRefNoTextEdit.EditValue = null;
        }

        private void SetCustomerRibbonGroupVisibility(BarItemVisibility isVisible)
        {
            bsiCustomer.Visibility = isVisible;
            bbiCustomerSLE.Visibility = isVisible;
        }

        private void IsCash(byte val, bool expandLayoutGroup = true, bool isResetSupplyNo = true)
        {
            if (val == 1)
            {
                ItemForsupCustNo.Visibility = LayoutVisibility.Never;
                ItemForsupCustName.Visibility = LayoutVisibility.Never;
                ItemForsupAccNo.Visibility = LayoutVisibility.Always;
                ItemForsupAccName.Visibility = LayoutVisibility.Always;
                ItemForsupDesc.Text = "الاسم :";
                if (this.isNew && isResetSupplyNo && this.supplyType != SupplyType.SalesRtrn) this.tbSupplyMain.supNo = 0;
            }
            else
            {
                ItemForsupAccNo.Visibility = LayoutVisibility.Never;
                ItemForsupAccName.Visibility = LayoutVisibility.Never;
                ItemForsupCustNo.Visibility = LayoutVisibility.Always;
                ItemForsupCustName.Visibility = LayoutVisibility.Always;
                ItemForsupDesc.Text = "البيان :";
                ResetCustomerSLE();
                //if (this.isNew)
                //{
                //    this.supNo = this.clsSupply.StoreEntryNoCredit(this.status1, this.status2);
                //    this.tbSupplyMain.supNo = this.supNo;
                //    supNoTextEdit.EditValue = this.supNo;
                //}
            }
            layoutControlGrooupMain.Expanded = expandLayoutGroup;
        }

        private void SetAccountBinding(byte isCash)
        {
            supAccNoLookUpEdit.DataBindings.Clear();
            supAccNameTextEdit.DataBindings.Clear();
            supCustNo.DataBindings.Clear();
            supCustName.DataBindings.Clear();

            if (isCash == 1)
            {
                supAccNoLookUpEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainBindingSource, "supAccNo", true, DataSourceUpdateMode.OnPropertyChanged));
                supAccNameTextEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainBindingSource, "supAccName", true, DataSourceUpdateMode.OnPropertyChanged));
            }
            else
            {
                supCustNo.DataBindings.Add(new Binding("EditValue", tblSupplyMainBindingSource, "supAccNo", true, DataSourceUpdateMode.OnPropertyChanged));
                supCustName.DataBindings.Add(new Binding("EditValue", tblSupplyMainBindingSource, "supAccName", true, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        private void ClearAccountFileds()
        {
            if (this.tbSupplyMain != null)
            {
                this.tbSupplyMain.supAccNo = null;
                this.tbSupplyMain.supAccName = null;
                this.tbSupplyMain.supCurrency = null;
                this.tbSupplyMain.supCurrencyChng = null;
            }
            supAccNoLookUpEdit.EditValue = null;
            supAccNameTextEdit.EditValue = null;
            supCustNo.EditValue = null;
            supCustName.EditValue = null;
            supCurrTextEdit.EditValue = null;
            supCurrencyChngTextEdit.EditValue = null;
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (textEditBarcodeNo.ContainsFocus) InitRowData1(e);
        }


        private void SetManAveragePrdPrice(int rowHandle)
        {
            if (!this.tbPrdMsur.ppmManufacture) return;
            gridView.SetRowCellValue(rowHandle, colsupPrice, this.clsPrdManAvrPrice.GetManPrdPriceFIFOByPrdId(this.tbProduct.id));
            //gridView.SetRowCellValue(rowHandle, colsupPrice, this.clsPrdManAvrPrice.GetAveragePrdPrice(this.tbProduct.id));
        }

        private void SetWeightQuantity(int rowHandle)
        {
            if (!this.tbPrdMsur.ppmWeight) return;

            string quanString = null;
            //gridView.SetRowCellValue(rowHandle, colsupPrdBarcode, this.tbPrdMsur.ppmBarcode1);

            try
            {
                quanString = this.barcodeNo.Substring(BarSetting.GetBarSetting.barcodeWeightNo + BarSetting.GetBarSetting.barcodeWeightNo, BarSetting.GetBarSetting.barcodeWeightQuanNo);
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError("عذراً رقم الباركود غير مسجل بشكل صحيح!" + $"\n\n{ex.Message}");
            }
            if (double.TryParse(quanString, out double quan)) gridView.SetRowCellValue(rowHandle, colsupQuanMain, quan);
        }

        //private void SetPrdPriceFIFO(int prdId, int rowHandle)
        //{
        //    if (this.tbPrdMsur.ppmManufacture) return;

        //    var tbPrdPriceQuan = this.clsTbPrdPriceQuan.GetPrdPriceQuantObjByPrdId(prdId);
        //    if (tbPrdPriceQuan == null) return;

        //    double prdAveragePrice = (this.tbPrdMsur.ppmStatus) switch
        //    {
        //        1 => tbPrdPriceQuan.pr1,
        //        2 => tbPrdPriceQuan.pr2,
        //        3 => tbPrdPriceQuan.pr3,
        //    };

        //    gridView.SetRowCellValue(rowHandle, colsupPrice, prdAveragePrice);
        //}

        //private void SetAveragePrdPrice(int prdId, int rowHandle)
        //{
        //    if (this.tbPrdMsur.ppmManufacture) return;

        //    var tbPrdPriceQuan = this.clsTbPrdPriceQuan.GetPrdPriceQuanAveragePriceObj(prdId,
        //        this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(prdId));
        //    if (tbPrdPriceQuan == null) return;

        //    double prdAveragePrice = (this.tbPrdMsur.ppmStatus) switch
        //    {
        //        1 => tbPrdPriceQuan.pr1,
        //        2 => tbPrdPriceQuan.pr2,
        //        3 => tbPrdPriceQuan.pr3,
        //    };

        //    gridView.SetRowCellValue(rowHandle, colsupPrice, prdAveragePrice);
        //}

        private void SetColTaxPercent(int rowIndex)
        {
            if (!checkEditTax.Checked || this.tbProduct.prdSaleTax) return;
            gridView.SetRowCellValue(rowIndex, colsupTaxPercent, this.tax);
        }

        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {

            if (!this.isNew || this.supplyType == SupplyType.SalesRtrn || gridView.DataRowCount == 0) return;
            if (!this.listPrdQuantDic.TryGetValue(e.RowHandle, out double quantity)) return;
            if (quantity <= this.clsTbPrdColor.GetProductColorQuantById(3))
                e.Appearance.BackColor = ColorTranslator.FromHtml(this.clsTbPrdColor.GetProductColorHtmlById(3));
            if (quantity <= this.clsTbPrdColor.GetProductColorQuantById(2))
                e.Appearance.BackColor = ColorTranslator.FromHtml(this.clsTbPrdColor.GetProductColorHtmlById(2));
            if (quantity <= this.clsTbPrdColor.GetProductColorQuantById(1))
                e.Appearance.BackColor = ColorTranslator.FromHtml(this.clsTbPrdColor.GetProductColorHtmlById(1));
            if (MySetting.DefaultSetting.defaultSalePriceFloar)
            {
                double prdMinPrice = this.clsTbPrdMsur.GetPrdPriceMsurMinSalePrice(Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, colsupMsur) ?? "0"));
                double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, "supSalePrice") ?? "0");
                if (salePrice < prdMinPrice)
                    e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            }
            if (Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice))
             < Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupPrice)) &&
             (MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.ShowWarning
             || MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent))
                e.Appearance.BackColor = System.Drawing.Color.IndianRed;
            e.HighPriority = true;
        }

        private double GetSalePrice()
        {
            if (this.tbCustomer == null || Convert.ToByte(this.tbCustomer.custSalePrice) == 0)
                return clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, tbPrdMsur);

            switch ((SalePrice)this.tbCustomer.custSalePrice)
            {
                case SalePrice.PurchasePrice:
                    return Convert.ToDouble(this.tbPrdMsur.ppmPrice);
                case SalePrice.SalePrice:
                    return clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, tbPrdMsur);
                case SalePrice.MinSalePrice:
                    return clsTbPrdMsur.GetppmMinSalePrice(this.tbProduct.prdPriceTax, tbPrdMsur);
                case SalePrice.RetailPrice:
                    return clsTbPrdMsur.GetppmRetailPrice(this.tbProduct.prdPriceTax, tbPrdMsur);
                case SalePrice.BatchPrice:
                    return clsTbPrdMsur.GetppmBatchPrice(this.tbProduct.prdPriceTax, tbPrdMsur);
                default:
                    return clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, tbPrdMsur);
            }
        }

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "supMsur")
                e.RepositoryItem = repositoryItemLookUpEditMeasurment;
        }

        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colFinalAmount)
            {
                double qty = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupQuanMain));
                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, qty));
            }

            if (e.Column.FieldName == colsupSalePrice.FieldName)
            {
                double prdMinPrice = this.clsTbPrdMsur.GetPrdPriceMsurMinSalePrice(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMsur)));
                double salePrice = Convert.ToDouble(e.Value);
                if ((salePrice < prdMinPrice) && MySetting.DefaultSetting.defaultSalePriceFloar)
                {
                    var msgValidPrice = $"عذرا لقد تجاوزت حد سعر البيع الأدنى! \n\nسعر البيع: {salePrice} \nسعر البيع الأدنى: {prdMinPrice}";
                    gridView.SetColumnError(e.Column, $"عذرا لقد تجاوزت حد سعر البيع الأدنى! \n\nسعر البيع: {salePrice} \nسعر البيع الأدنى: {prdMinPrice}");
                }
            }

            else if (e.Column.FieldName == colWidth.FieldName || e.Column.FieldName == colHeight.FieldName)
            {
                double? height = (double?)gridView.GetRowCellValue(gridView.FocusedRowHandle, colHeight);
                double? width = (double?)gridView.GetRowCellValue(gridView.FocusedRowHandle, colWidth);
                if (height > 0 && width > 0)
                {
                    var qte = (height ?? 0) * (width ?? 0);

                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupQuanMain, qte);
                    GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, qte));
                    gridView.UpdateCurrentRow();
                }
            }
            else if (e.Column.FieldName == colsupOvertime.FieldName || e.Column.FieldName == colsupWorkingtime.FieldName)
            {
                double? Workingtime = (double?)gridView.GetRowCellValue(gridView.FocusedRowHandle, colsupWorkingtime);
                double? Overtime = (double?)gridView.GetRowCellValue(gridView.FocusedRowHandle, colsupOvertime);
                if (Workingtime > 0 && Overtime > 0)
                {
                    var qte = (Workingtime ?? 0) + (Overtime ?? 0);
                    gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupQuanMain, qte);
                    GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, qte));
                    gridView.UpdateCurrentRow();
                }
            }
            else if (e.Column.FieldName == colMeter.FieldName)
            {
                double? meter = (double?)gridView.GetRowCellValue(e.RowHandle, colMeter);

                if (meter != null)
                {
                    if (this.tbPrdMsur == null)
                        this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId))).FirstOrDefault(c => c.ppmId == Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMsur)));
                    if (this.tbPrdMsur.ppmConversion != null)
                    {
                        var currentQte = Math.Ceiling(meter / this.tbPrdMsur.ppmConversion ?? 0);
                        var currentPacks = (int?)gridView.GetRowCellValue(e.RowHandle, col_SubNoPacks); ;
                        var lst = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
                        if (lst.Any())
                        {
                            var factor = this.tbPrdMsur.ppmConversion ?? 0;
                            if (currentPacks != currentQte)
                            {
                                gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupQuanMain, currentQte * factor);
                                GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, currentQte * factor));
                                gridView.SetFocusedRowCellValue(col_SubNoPacks, currentQte);
                                gridView.UpdateCurrentRow();
                                gridView.SetFocusedRowCellValue(colMeter, currentQte * factor);
                            }
                        }
                    }
                }
            }
        }

        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double tax, price, priceTax, quantity;


                if (e.Column.FieldName == "supQuanMain" && double.TryParse(e.Value.ToString(), out quantity))
                {
                    if (this.supplyType == SupplyType.SalesRtrn && this.tbSupplySubListOld != null)
                    {
                        var gf = gridView.GetFocusedRow() as tblSupplySub;
                        if (gf == null) return;
                        var t = this.tbSupplySubListOld.Where(x => x.supPrdBarcode == gf?.supPrdBarcode && x.supPrdId == gf?.supPrdId);
                        double lQ = Convert.ToDouble(t?.Count() > 0 ? t?.FirstOrDefault()?.supQuanMain.Value : 0);
                        if (lQ < quantity)
                        {
                            MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                            return;
                        }
                    }
                    if (this.tbPrdMsur != null && InitPrdQuantity(this.tbPrdMsur.ppmStatus, double.Parse(e.Value.ToString())))
                    {
                        if (double.Parse(e.Value.ToString()) == 1)
                        {
                            gridView.DeleteSelectedRows();
                            return;
                        }
                        gridView.SetColumnError(e.Column, _resource.GetString("CheckPrdQtyMssg"));

                        return;
                    }
                    price = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupSalePrice));
                    if (price > 0)
                    {
                        if (!double.TryParse(e.Value.ToString(), out quantity)) return;
                        tax = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupTaxPercent));
                        price = price * quantity;
                        priceTax = (checkEditTax.Checked) ? (price * (tax / 100)) : 0;
                        //priceTax = (checkEditTax.Checked) ? Math.Round(price * (tax / 100), 2, MidpointRounding.AwayFromZero) : 0;
                        gridView.SetFocusedRowCellValue(colsupTaxPrice, priceTax);
                        gridView.SetFocusedRowCellValue(colsupTotalPrice, price + priceTax);
                        CalculateTotalAmount();
                        if (!double.TryParse(gridView.GetRowCellValue(e.RowHandle, colsupDscntPercent)?.ToString(), out double dscntPercent)) return;

                        double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice));
                        double dscntAmount = Math.Round(salePrice * (dscntPercent / 100), 2, MidpointRounding.AwayFromZero);
                        dscntAmount *= Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupQuanMain));

                        gridView.SetRowCellValue(e.RowHandle, colsupDscntAmount, dscntAmount);

                        CalculateRowTaxDiscount(e.RowHandle, dscntAmount);
                        CalculateGridDiscount(e.RowHandle, dscntAmount);
                        CalculateTotalFinal();


                    }
                }
                else if (e.Column.FieldName == "supSalePrice")
                {
                    if (string.IsNullOrWhiteSpace(e.Value.ToString())) return;
                    var dscntAmount = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupDscntAmount));
                    tax = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupTaxPercent));
                    quantity = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupQuanMain));
                    price = Convert.ToDouble(e.Value) * quantity;
                    priceTax = (checkEditTax.Checked) ? (price * (tax / 100)) : 0;
                    var nta = (price - dscntAmount) * (tax / 100);
                    var taxPrice = MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : priceTax;

                    gridView.SetFocusedRowCellValue(colsupTaxPrice, taxPrice);
                    gridView.SetFocusedRowCellValue(colsupTotalPrice, price - dscntAmount + taxPrice);
                    CalculateTotalAmount();
                }
                else if (e.Column.FieldName == colsupDscntPercent.FieldName)
                {
                    if (string.IsNullOrWhiteSpace(e.Value.ToString()))
                    {
                        gridView.SetRowCellValue(e.RowHandle, colsupDscntAmount, null);
                        CalculateRowTaxDiscount(e.RowHandle, 0);
                        CalculateGridDiscount(e.RowHandle, 0);
                        CalculateTotalFinal();
                        return;
                    }
                    if (!double.TryParse(e.Value.ToString(), out double dscntPercent)) return;

                    double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice));
                    double dscntAmount = Math.Round(salePrice * (dscntPercent / 100), 2, MidpointRounding.AwayFromZero);
                    dscntAmount *= Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupQuanMain));

                    gridView.SetRowCellValue(e.RowHandle, colsupDscntAmount, dscntAmount);

                    CalculateRowTaxDiscount(e.RowHandle, dscntAmount);
                    CalculateGridDiscount(e.RowHandle, dscntAmount);
                    CalculateTotalFinal();
                }
                else if (e.Column.FieldName == colsupDscntAmount.FieldName)
                {
                    if (string.IsNullOrWhiteSpace(e.Value.ToString()))
                    {
                        gridView.SetRowCellValue(e.RowHandle, colsupDscntPercent, null);
                        CalculateRowTaxDiscount(e.RowHandle, 0);
                        CalculateGridDiscount(e.RowHandle, 0);
                        CalculateTotalFinal();
                        return;
                    }
                    if (!double.TryParse(e.Value.ToString(), out double dscntAmount)) return;

                    double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice));
                    salePrice *= Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupQuanMain));

                    double dscntPercent = (dscntAmount / salePrice) * 100;
                    gridView.SetRowCellValue(e.RowHandle, colsupDscntPercent, dscntPercent);

                    CalculateRowTaxDiscount(e.RowHandle, dscntAmount);
                    CalculateGridDiscount(e.RowHandle, dscntAmount);
                    CalculateTotalFinal();
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void CalculateGridDiscount(int rowHandle, double dscntAmount, bool isCalculateAllGrid = false)
        {
            double discountAmount = 0, quantity = 0, salePrice = 0, dscntPercent = 0;
            discountAmount += dscntAmount;

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                if (isCalculateAllGrid)
                {
                    quantity = Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                    salePrice = Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice));
                    dscntPercent = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntPercent));
                    if (dscntPercent > 0) gridView.SetRowCellValue(i, colsupDscntAmount,
                                Math.Round((salePrice * quantity) * (dscntPercent / 100), 2, MidpointRounding.AwayFromZero));
                    discountAmount += Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntAmount));
                }

                if (i == rowHandle) continue;
                discountAmount += Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntAmount));
            }

            SetDiscountLabels(discountAmount);
        }

        private void SetDiscountLabels(double discountAmount)
        {
            this.discountAmount = discountAmount;
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalPrice)) return;

            labelDiscountDecimal.Text = $"{discountAmount:f2}";
            labelTotalDecimal.Text = $"{(totalPrice - discountAmount):f2}";
        }

        private void CalculateRowTaxDiscount(int rowHandle, double dscntAmount)
        {
            if (!checkEditTax.Checked)
            {
                gridView.SetRowCellValue(rowHandle, colsupTaxPrice, null);
                return;
            }
            var salePrice = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupSalePrice)) *
                Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));
            var ntac = (salePrice * Convert.ToDouble(this.tax) / 100);
            var nta = (salePrice - dscntAmount) * (Convert.ToDouble(this.tax) / 100);
            var taxPrice = MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : ntac;
            gridView.SetRowCellValue(rowHandle, colsupTaxPrice, taxPrice);
            gridView.SetRowCellValue(rowHandle, colsupTotalPrice, salePrice - dscntAmount + taxPrice);

        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (this.clsTbPrdMsur == null) return;
            if (e.Column.FieldName == "supMsur")
                e.DisplayText = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = this.curData.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void GridView_HiddenEditor(object sender, EventArgs e)
        {
            if (gridView.FocusedColumn == colsupQuanMain || gridView.FocusedColumn == colsupSalePrice)
            {
                CalculateTax(gridView.FocusedRowHandle);
                CalculateTotalAmount();
            }
        }

        private void GridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colsupMsur)
                tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
        }

        private void RepositoryItemCalcEdit1SalePrice_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (Convert.ToDouble(e.Value) > (double)999999999999999999.99) e.AcceptValue = false;
        }

        private void GridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        bool ValidPrice;
        private void GridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            e.Valid = ValidPrice;
            return;

            GridView view = sender as GridView;
            if (view == null) return;
            if (Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupSalePrice)) > (double)999999999999999999.99)
            {
                e.Valid = false;
                view.SetColumnError(colsupSalePrice, "المبلغ الذي ادخلته غير صحيح");
                e.ErrorText = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
                this.gridValid = false;
            }
            else
                this.gridValid = true;

        }
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view?.FocusedColumn == colsupSalePrice)
            {
                if (Convert.ToDouble(e.Value) > (double)99999999999999999.99)
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

            this.tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            this.ppmMinSalePrice = Convert.ToDouble(editor.GetColumnValue("ppmMinSalePrice"));
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);

            gridView.SetFocusedRowCellValue(colsupMsur, Convert.ToInt32(editor.GetColumnValue("ppmId")));
            gridView.SetFocusedRowCellValue(colsupPrdBarcode, tbBarcode?.brcNo);
            //gridView.SetFocusedRowCellValue(colsupPrdBarcode, Convert.ToString(editor.GetColumnValue("ppmBarcode1")));
            gridView.SetFocusedRowCellValue(colsupPrice, GetPrdPrice(tbPrdMsur));
            gridView.SetFocusedRowCellValue(colsupSalePrice, GetSalePrice());
            gridView.UpdateCurrentRow();

            //if (this.tbPrdMsur != null) SetAveragePrdPrice(this.tbPrdMsur.ppmPrdId, gridView.FocusedRowHandle);
            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            SetPrdQuanAvlbList();
        }

        private void RepositoryItemSearchLookUpEditPrdNo_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            int prdId = Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("id"));
            this.tbProduct = editor.Properties.View.GetFocusedRow() as tblProduct;

            gridView.SetFocusedRowCellValue(colsupPrdNo, editor.Properties.View.GetFocusedRowCellValue("prdNo").ToString());
            gridView.SetFocusedRowCellValue(colsupPrdName, editor.Properties.View.GetFocusedRowCellValue("prdName").ToString());
            gridView.SetFocusedRowCellValue(colsupAccNo, Convert.ToInt64(editor.Properties.View.GetFocusedRowCellValue("prdGrpNo")));
            gridView.SetFocusedRowCellValue(colsupCurrency, this.clsTbGroupStr.GetGroupCurrencyById(Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("prdGrpNo"))));
            gridView.SetFocusedRowCellValue(colsupPrdId, prdId);
            gridView.SetFocusedRowCellValue(colsupQuanMain, 1);
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId);
            GridView_CellValueChanging(sender, new CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, 1));
            gridView.SetFocusedRowCellValue(colsupDesc, this.tbProduct.prdDesc);
            SetColTaxPercent(gridView.FocusedRowHandle);

            if (CheckProductService(this.tbProduct.prdStatus)) return;
            GetDefaultPrdPriceMsur(prdId);

            gridView.UpdateCurrentRow();

            //SetAveragePrdPrice(this.tbProduct.id, gridView.FocusedRowHandle);
            SetColTaxPercent(gridView.FocusedRowHandle);
            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            SetPrdQuanAvlbList();
        }

        private void InitRowData1(InitNewRowEventArgs e)
        {
            gridView.SetRowCellValue(e.RowHandle, colsupPrdBarcode, this.barcodeNo);
            gridView.SetRowCellValue(e.RowHandle, colsupMsur, this.tbPrdMsur.ppmId);
            //gridView.SetRowCellValue(e.RowHandle, colsupPrice, this.tbPrdMsur.ppmPrice);
            gridView.SetRowCellValue(e.RowHandle, colsupPrice, GetPrdPrice(this.tbPrdMsur));
            gridView.SetRowCellValue(e.RowHandle, colsupPrdManufacture, this.tbPrdMsur.ppmManufacture);
            gridView.SetRowCellValue(e.RowHandle, colsupSalePrice, GetSalePrice());
            gridView.SetRowCellValue(e.RowHandle, colsupPrdId, this.tbProduct.id);
            gridView.SetRowCellValue(e.RowHandle, colsupPrdNo, this.tbProduct.prdNo);
            gridView.SetRowCellValue(e.RowHandle, colsupPrdName, this.tbProduct.prdName);
            gridView.SetRowCellValue(e.RowHandle, colsupAccNo, this.tbProduct.prdGrpNo);
            gridView.SetRowCellValue(e.RowHandle, colsupCurrency, clsTbGroupStr.GetGroupCurrencyById(this.tbProduct.prdGrpNo));
            gridView.SetRowCellValue(e.RowHandle, colsupQuanMain, 1);
            gridView.SetRowCellValue(e.RowHandle, colsupDesc, this.tbProduct.prdDesc);

            //SetAveragePrdPrice(this.tbProduct.id, e.RowHandle);
            //SetPrdPriceFIFO(this.tbProduct.id, e.RowHandle);
            SetManAveragePrdPrice(e.RowHandle);
            SetColTaxPercent(e.RowHandle);

            SetWeightQuantity(e.RowHandle);
            CalculateTax(e.RowHandle);
        }
        private double? GetPrdPriceFromStore(tblPrdPriceMeasurment tbPrdMsur)
        {
            List<tblPrdPriceMeasurment> p = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(tbPrdMsur.ppmPrdId).ToList();
            if (tbPrdMsur.ppmStatus == 1)
                return tbPrdMsur.ppmPrice;
            else if (tbPrdMsur.ppmStatus == 2)
                return (p.FirstOrDefault(x => x.ppmStatus == 1).ppmPrice / tbPrdMsur.ppmConversion);
            else if (tbPrdMsur.ppmStatus == 3)
                return (p.FirstOrDefault(x => x.ppmStatus == 1).ppmPrice / p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion / tbPrdMsur.ppmConversion);
            return default;
        }
        private double? GetPrdPrice(tblPrdPriceMeasurment tbPrdMsur)
        {
            try
            {
                if (tbPrdMsur == null) return default;
                if (!MySetting.GetPrivateSetting.supPrdLastPrice) return GetPrdPriceFromStore(tbPrdMsur);
                else
                {
                    using (var temp = new accountingEntities())
                    {
                        var ff = temp.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                    (x.supDate >= Session.CurrentYear.fyDateStart && x.supDate <= Session.CurrentYear.fyDateEnd) && x.supPrdId == tbPrdMsur.ppmPrdId &&
                    (x.supStatus == 3 || x.supStatus == 7)).OrderByDescending(x => new { x.supDate, x.id }).FirstOrDefault();
                        if (ff == null)
                            return GetPrdPriceFromStore(tbPrdMsur);
                        List<tblPrdPriceMeasurment> p = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(tbPrdMsur.ppmPrdId).ToList();
                        byte state = (p.FirstOrDefault(x => x.ppmId == (ff?.supMsur ?? 0))?.ppmStatus) ?? 0;
                        if (tbPrdMsur.ppmStatus == state)
                            return ff?.supPrice;
                        else if (tbPrdMsur.ppmStatus - state == 1)
                            return ff?.supPrice / tbPrdMsur.ppmConversion;
                        else if (tbPrdMsur.ppmStatus == 3 && state == 1)
                            return (ff?.supPrice / p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion / tbPrdMsur.ppmConversion);
                        else if (tbPrdMsur.ppmStatus - state == -1)
                            return ff?.supPrice * p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion;
                        else if (tbPrdMsur.ppmStatus == 1 && state == 3)
                            return (ff?.supPrice * p.FirstOrDefault(x => x.ppmStatus == 2).ppmConversion * p.FirstOrDefault(x => x.ppmStatus == 3).ppmConversion);
                    }
                    return default;
                }
            }
            catch (Exception ex)
            {
                return default;
            }

        }


        double GetFirstPriceInProduct(int id)
        {
            var ppm = tbPPMList.FirstOrDefault(x => x.ppmPrdId == id && x.ppmDefault);
            var pro = Session.Products.FirstOrDefault(x => x.id == id)?.prdPriceTax ?? false;
            return  clsTbPrdMsur.GetppmSalePrice(pro,ppm);
        }

        private void RepositoryItemSearchLookUpEdit1View_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (e.Column.FieldName != colprdSalePrice.FieldName && e.Column.FieldName != colsupMusrName.FieldName) return;
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
            e.Value = GetQuanAvlb(Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colsupPrdId)));
            //  if (!this.listPrdQuanAvlbDic.ContainsKey(Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colsupPrdId)))) return;


            ////  double rowQ = Convert.ToDouble(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupQuanMain));
            //  var prdId = Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colsupPrdId));
            //  double otherQuantity = GetQuantityProductInGrid(prdId);
            //  e.Value = this.listPrdQuanAvlbDic[prdId] - otherQuantity;// rowQ -
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
                if (int.TryParse(gridView.GetRowCellValue(i, colsupPrdId)?.ToString(), out prdId))
                    if (prdId == PrdId) otherQuantity += double.Parse(gridView.GetRowCellValue(i, colsupQuanMain).ToString());
            }
            return otherQuantity;
        }
        private void GridViewSrchPrd_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName != colPrdSalePrice2.FieldName) return;
            if (!e.IsGetData) return;
            var row = view.GetRow(e.ListSourceRowIndex) as tblProduct;
            if (row != null)
            {
                e.Value = GetFirstPriceInProduct(row.id);
            }
            // if (this.tbPrdPriceDic.ContainsKey(e.ListSourceRowIndex)) e.Value = this.tbPrdPriceDic[e.ListSourceRowIndex];
        }

        private bool CheckProductService(byte prdStatus)
        {
            if (prdStatus != 2) return false;
            gridView.UpdateCurrentRow();

            if (!this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Add(gridView.FocusedRowHandle, 200);
            ResetMeasurmentColumns(gridView.FocusedRowHandle);
            CalculateTotalAmount();

            return true;
        }

        private void ResetMeasurmentColumns(int rowHandle)
        {
            gridView.SetRowCellValue(rowHandle, colsupMsur, null);
            gridView.SetRowCellValue(rowHandle, colsupPrice, null);
            gridView.SetRowCellValue(rowHandle, colsupSalePrice, null);
            gridView.SetRowCellValue(rowHandle, colsupTaxPrice, null);
            gridView.SetRowCellValue(rowHandle, colsupTotalPrice, null);
        }

        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract) UpdateQuantity(e);
            if (e.KeyCode == Keys.Enter)
                GetPrdBarcodeData(textEditBarcodeNo.Text);
        }

        private bool ValidateBarcodeNo(string barcode, out int prdMsurId)
        {
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcode);
            bool isValid = tbBarcode != null ? true : false;

            prdMsurId = tbBarcode != null ? tbBarcode.brcPrdMsurId : 0;

            if (!isValid)
            {
                if (File.Exists(@"beep-5.wav"))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"beep-5.wav");
                    player.Play();
                }

                XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBarcodeNoText();
            }

            return isValid;
        }
        private void MessGSalesRetQuantity(string m)
        {
            XtraMessageBox.Show(m, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ClearBarcodeNoText();
        }
        private void GetPrdBarcodeData(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return;
            if (this.supplyType == SupplyType.SalesRtrn)
            {
                var curList = (tblSupplySubBindingSource.List as IList<tblSupplySub>);
                if (this.tbSupplySubListOld.Count() <= 0)
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة البيع");
                    return;
                }
                else if (!this.tbSupplySubListOld.Any(x => x.supPrdBarcode == barcode))
                {
                    MessGSalesRetQuantity("لا يمكن اضافة صنف غير موجود في فاتورة البيع");
                    return;
                }
                else if (curList.Any(x => x.supPrdBarcode == barcode))
                {
                    if (this.tbSupplySubListOld.FirstOrDefault(x => x.supPrdBarcode == barcode).supQuanMain <= curList.FirstOrDefault(x => x.supPrdBarcode == barcode).supQuanMain)
                    {
                        MessGSalesRetQuantity("لا يمكن ان تكون الكمية المرتجعه للصنف \nاكبر من كمية الصنف في فاتورة البيع");
                        return;
                    }
                }
            }
            if (MySetting.DefaultSetting.GroupProductsInInvoices && CheckProductGrid(barcode))
            {
                PlayBarcodeBeep();
                return;
            }
            if (!ValidateBarcodeNo(barcode, out int prdMsurId)) return;

            this.barcodeNo = barcode;
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(prdMsurId);

            if (this.tbPrdMsur != null)
                this.tbPrdQuantiy = this.clsTbPrdQuantity.GetPrdQuantityObjByPrdIdNdStrId(tbPrdMsur.ppmPrdId, Convert.ToInt16(bbiStrIdSLE.EditValue));

            if (this.tbPrdMsur == null || this.tbPrdQuantiy == null)
            {
                XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBarcodeNoText();
                return;
            }
            var tempPro = this.clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur.ppmPrdId);
            if (tempPro == null)
            {
                this.tbProduct = this.clsTbProduct.ChickDataProduct(tempPro, this.tbPrdMsur, this.barcodeNo);
                if (this.tbProduct == null)
                {
                    XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearBarcodeNoText();
                    return;
                }
                else
                {
                    InitPrdStoreObj();
                    InitPrdBindingSourceData(Convert.ToInt16(bbiStrIdSLE.EditValue));
                }
            }
            else this.tbProduct = tempPro;

            this.ppmMinSalePrice = clsTbPrdMsur.GetppmMinSalePrice(this.tbProduct.prdPriceTax,tbPrdMsur);


            double ItemQty = 1;
            string ItemCode = barcode;
            if (MySetting.DefaultSetting.ReadFormScaleBarcode &&
                    ItemCode.Length == MySetting.DefaultSetting.BarcodeLength &&
                    ItemCode.StartsWith(MySetting.DefaultSetting.ScaleBarcodePrefix))
            {
                string Readvalue = barcode.ToString().Substring(
                    MySetting.DefaultSetting.ScaleBarcodePrefix.Length +
                    MySetting.DefaultSetting.ProductCodeLength);
                if (MySetting.DefaultSetting.IgnoreCheckDigit)
                    Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
                double value = Convert.ToDouble(Readvalue);
                value = value / (Math.Pow(10, MySetting.DefaultSetting.DivideValueBy));


                if (MySetting.DefaultSetting.ReadMode == 0)
                    ItemQty = value;
                else if (MySetting.DefaultSetting.ReadMode == 1)
                {
                    var priceAfterTax = 100 * (value / (100 + 15));
                    value = MySetting.DefaultSetting.TaxReadMode ? priceAfterTax : value;
                    if (this.tbPrdMsur != null)
                    { 
                        var pr = clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur);
                        ItemQty = value / (pr == 0?1: pr);
                    }
                    
                }
            }

            gridView.AddNewRow();
            gridView.UpdateCurrentRow();
            ClearBarcodeNoText();

            if (InitPrdQuantity(this.tbPrdMsur.ppmStatus)) return;


            gridView.SetFocusedRowCellValue(colsupQuanMain, ItemQty);
            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            PlayBarcodeBeep();
            HasTax();
            SetPrdQuanAvlbList();
            return;
        }

        private void ClearBarcodeNoText()
        {
            textEditBarcodeNo.EditValue = null;
        }

        private void InitPrdQuanAvlbList()
        {
            this.listPrdQuanAvlbDic = new Dictionary<int, double>();
        }

        private void UpdatePrdQuanAvlb()
        {
            gridView.SetRowCellValue(gridView.FocusedRowHandle, colprdQuanAvlb, 1);
        }

        private void SetPrdQuanAvlbList()
        {
            if (!this.listPrdQuanAvlbDic.ContainsKey(this.tbProduct.id))
            {

                this.listPrdQuanAvlbDic.Add(this.tbProduct.id, Convert.ToDouble(this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(
                    this.tbProduct.id, this.tbPrdMsur.ppmStatus, Convert.ToInt16(bbiStrIdSLE.EditValue))));
            }
            else
            {
                this.listPrdQuanAvlbDic[this.tbProduct.id] = Convert.ToDouble(this.clsTbPrdQuantity.GetTotalPrdQuantityByPrdINddMsurStatus(
                    this.tbProduct.id, this.tbPrdMsur.ppmStatus, Convert.ToInt16(bbiStrIdSLE.EditValue)));
            }
        }
        private bool CheckProductGrid(string barcode)
        {
            bool isFound = false;

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                if (gridView.GetRowCellValue(i, colsupPrdBarcode) != null && gridView.GetRowCellValue(i, colsupPrdBarcode).ToString() == barcode)
                {
                    double quantity = Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                    this.msurStatus = this.clsTbPrdMsur.GetPrdPriceMsurStatus(Convert.ToInt32(gridView.GetRowCellValue(i, colsupMsur)));
                    string ItemCode = barcode;
                    if (MySetting.DefaultSetting.ReadFormScaleBarcode && ItemCode.Length == MySetting.DefaultSetting.BarcodeLength && ItemCode.StartsWith(MySetting.DefaultSetting.ScaleBarcodePrefix))
                    {
                        if (!MySetting.DefaultSetting.GroupWeightProdInInvoices) return false;
                        string Readvalue = barcode.ToString().Substring(MySetting.DefaultSetting.ScaleBarcodePrefix.Length + MySetting.DefaultSetting.ProductCodeLength);
                        if (MySetting.DefaultSetting.IgnoreCheckDigit)
                            Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);

                        double value = Convert.ToDouble(Readvalue) / (Math.Pow(10, MySetting.DefaultSetting.DivideValueBy));

                        if (MySetting.DefaultSetting.ReadMode == 0)
                            quantity = quantity + value;
                        else if (MySetting.DefaultSetting.ReadMode == 1)
                        {
                            var priceAfterTax = 100 * (value / (100 + 15));
                            value = MySetting.DefaultSetting.TaxReadMode ? priceAfterTax : value;
                            if (this.tbPrdMsur != null)
                            {
                                var pr = clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur);
                                quantity = quantity + (value / (pr == 0 ? 1 : pr));
                            }
                        }
                    }
                    else quantity++;
                    gridView.SetRowCellValue(i, colsupQuanMain, quantity);
                    if (InitPrdQuantity(i, this.msurStatus))
                    {
                        isFound = true;
                        break;
                    }
                    CalculateTax(i);
                    CalculateTotalRow(i);
                    CalculateTotalAmount();

                    isFound = true;
                    break;
                }
            }

            if (isFound) ClearBarcodeNoText();
            return isFound;
        }

       
        private void CalculateTax(int rowHandle)
        {

            if (!checkEditTax.Checked || (this.tbProduct != null && this.tbProduct.prdSaleTax)) return;
            double price = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupSalePrice)) * Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));
            double DiscountPricent = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupDscntPercent));
            double taxPricent = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupTaxPercent));
            double taxBeforDisPrice = price * (taxPricent / 100);
            double priceAfterDiscount = price - (DiscountPricent * price / 100);
            double priceTax = MySetting.DefaultSetting.CalcTaxAfterDiscount ?
                ((checkEditTax.Checked && price != 0) ? (priceAfterDiscount * (taxPricent / 100)) : 0) : taxBeforDisPrice;
            gridView.SetRowCellValue(rowHandle, colsupTaxPrice, priceTax);
        }
        private void CalculateTotalRow(int rowHandle)
        {
            double price = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupSalePrice)),
                    taxPrice = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupTaxPrice));
            double quantity = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));
            double dis = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupDscntAmount));
            gridView.SetRowCellValue(rowHandle, colsupTotalPrice, (price * quantity) - dis + taxPrice);
            //gridView.SetRowCellValue(rowHandle, colsupTotalPrice, (price * quantity) + taxPrice);
            //gridView.SetRowCellValue(rowHandle, colsupTotalPrice, Math.Round((price * quantity), 2, MidpointRounding.AwayFromZero) + taxPrice);
        }

        private void CalculateTotalAmount()
        {
            //if(gridView.DataRowCount==0 || gridView.DataRowCount==null)
            try
            {
                labelItemsCount.Text = _resource?.GetString("prdCount") + gridView.DataRowCount;
                this.totalAmount = 0;
            }
            catch { }


            for (short i = 0; i < gridView.DataRowCount; i++)
                this.totalAmount += Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice)) * Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));

            SetTotalLabels(this.totalAmount);
            CalculateDiscountAmount(Convert.ToDouble(supDscntPercentTextEdit.EditValue));
            CalculateTotalFinal();
        }

        private void SetTotalLabels(double totalPrdPrice)

        {
            //labelTotalPriceDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0)}";
            //labelTotalDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0)}";
            labelTotalPriceDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0):f2}";
            labelTotalDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0):f2}";
        }

        private void GetDefaultPrdPriceMsur(int prdId)
        {
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId);
            if (this.tbPrdMsur == null) return;

            gridView.UpdateCurrentRow();
            if (InitPrdQuantity(this.tbPrdMsur.ppmStatus)) return;

            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);

            //gridView.SetFocusedRowCellValue(colsupPrdBarcode, this.tbPrdMsur.ppmBarcode1);
            gridView.SetFocusedRowCellValue(colsupPrdBarcode, tbBarcode?.brcNo);
            gridView.SetFocusedRowCellValue(colsupMsur, this.tbPrdMsur.ppmId);
            gridView.SetFocusedRowCellValue(colsupPrice, GetPrdPrice(this.tbPrdMsur));
            gridView.SetFocusedRowCellValue(colsupSalePrice, GetSalePrice());
        }

        private void HasTax()
        {
            IEnumerable<tblProduct> products = tblProductBindingSource.DataSource as IEnumerable<tblProduct>;
            if (this.hasTax)
            {
                // colsupTaxPercent.Visible = true;
                colsupTaxPrice.Visible = true;
                //  colsupTaxPercent.VisibleIndex = 7;
                //  colsupTaxPrice.VisibleIndex = 8;
                //  colsupDesc.VisibleIndex = 9;

             
                for (short i = 0; i < gridView.DataRowCount; i++)
                {

                    int prdId = Convert.ToInt32(gridView.GetRowCellValue(i, colsupPrdId));
                    var prod = products.FirstOrDefault(p => p.id == prdId);
                    if (!prod.prdSaleTax)
                    {
                        var dscntAmount = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntAmount));
                        var salePrice = Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice)) *
                                        Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                        var ntac = (salePrice * Convert.ToDouble(this.tax) / 100);
                        var nta = (salePrice - dscntAmount) * (Convert.ToDouble(this.tax) / 100);
                        var taxPrice = MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : ntac;
                        gridView.SetRowCellValue(i, colsupTaxPrice, taxPrice);
                        gridView.SetRowCellValue(i, colsupTaxPercent, this.tax);
                        gridView.SetRowCellValue(i, colsupTotalPrice, salePrice - dscntAmount + taxPrice);
                    }
                }
            }
            else
            {
                colsupTaxPercent.Visible = false;
                colsupTaxPrice.Visible = false;

                for (short i = 0; i < gridView.DataRowCount; i++)
                {
                    int prdId = Convert.ToInt32(gridView.GetRowCellValue(i, colsupPrdId));
                    var prod = products.FirstOrDefault(p => p.id == prdId);
                    if (!prod.prdSaleTax)
                    {
                        double tot = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTotalPrice));
                        double ptax = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPrice));
                        double dscntAmount = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntAmount));
                        tot -= dscntAmount;

                        gridView.SetRowCellValue(i, colsupTaxPrice, 0);
                        gridView.SetRowCellValue(i, colsupTaxPercent, 0);
                        gridView.SetRowCellValue(i, colsupTotalPrice, tot - ptax);


                    }
                }
            }

            CalculateTotalAmount();
        }

        private void SaleForm()
        {
            this.status1 = 4;
            this.status2 = 8;
            this.accBoxName = "boxName";
            ItemForsupNo.Text = "رقم الفاتورة :";
            ItemForsupAccNo.Text = "رقم الصندوق :";
            ItemForsupAccName.Text = "إسم الصندوق :";

            if (this.supplyType == SupplyType.Sales)
            {
                colprdQuanAvlb.Visible = true;
                colprdQuanAvlb.VisibleIndex = 6;
            }
        }

        private void SaleRtrnForm()
        {
            InitSupplyObjects();
            InitInvoiceObjects();
            InitSupplyTarhelObj();

            tblSupplyMainBindingSourceEditor.DataSource = this.clsTbSupplyMain.GetSupplyMainList.Where(x => x.supBrnId == Session.CurBranch.brnId);
            repositoryItemSearchLookUpEditCustomerBbi.DataSource = this.clsTbCustomer.GetCustomersList().Where(x => x.custBrnId == Session.CurBranch.brnId);
            gridView.OptionsSelection.MultiSelect = true;

            SetSaleRtrnTextNdStatus();
            SetSaleRtrnRibbonItems();
            SetGridProperties();
            SetLayoutControl();
            SetAppearanceControl();
        }

        private void SaleRtrnDirectForm()
        {
            InitInvoiceObjects();
            InitSupplyTarhelObj();
            SetSaleRtrnTextNdStatus();
            SetSaleRtrnDirectRibbonItems();
        }

        private void SetSaleRtrnDirectRibbonItems()
        {
            ribbonPageGroupUpdateInvoice.Visible = false;
            bbiUpdateInvvoice.Visibility = BarItemVisibility.Never;
            bbiNewInvoice.Visibility = BarItemVisibility.Never;
        }

        private void SetSaleRtrnTextNdStatus()
        {
            this.status1 = 11;
            this.status2 = 12;
            this.Text = "فاتورة مردود مبيعات";

            ItemForsupNo.Text = "رقم فاتورة المردود :";
            layoutControlGroup3.Text = "بيانات فاتورة مردود المبيعات الرئيسية :";
            colsupTotalPrice.FieldName = "supDebit";
        }

        private void SetSaleRtrnRibbonItems()
        {
            ribbonPageGroup4.Visible = true;
            bbiSaveAndNew.Visibility = BarItemVisibility.Never;
            bbiReset.Visibility = BarItemVisibility.Never;
            bbiEditPrice.Visibility = BarItemVisibility.Never;
            bbiNewInvoice.Visibility = BarItemVisibility.Never;
            bbiUpdateInvvoice.Visibility = BarItemVisibility.Never;
            ribbonPageGroupUpdateInvoice.Visible = false;
            bbiStrIdSLE.Enabled = false;
            bbiCustomerSLE.Enabled = false;
            //   radioGroupIsCash.Enabled = false;
            ItemForSalesNo.Visibility = LayoutVisibility.Always;
            ItemForSalesNo.TextAlignMode = TextAlignModeItem.UseParentOptions;
            ItemForsupAccNo.Enabled = false;
            ItemForsupCustNo.Enabled = false;
            checkEditTax.Enabled = false;
        }

        private void InitSupplyObjects()
        {
            this.clsTbSupplyMain = new ClsTblSupplyMain(SupplyType.SalesPhase);// ClsTblSupplyMain(true);
            this.clsTbSupplySub = new ClsTblSupplySub(false);// ClsTblSupplySub(SupplyType.SalesPhase);
        }

        private void InitSupplyTarhelObj()
        {
            if (!this.autoSupplyTarhel) return;
            this.clsSupplyTarhel = new ClsSupplyTarhel(this.supplyType, null, true, this.clsTbPrdMsur);
        }

        private void InitInvoiceObjects()
        {
            this.clsTbCustomer = new ClsTblCustomer();
            this.clsTbStore = new ClsTblStore();
            this.clsTbGroupStr = new ClsTblGroupStr();
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            this.clsTbBarcode = new ClsTblBarcode();
            this.clsPrdQuantityOpr = new ClsPrdQuantityOperations();
            this.clsTbPrdPriceQuan = new ClsTblPrdPriceQuan(false);
            this.clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(this.clsTbPrdPriceQuan, this.clsTbPrdMsur);
            this.clsTbAccount = new ClsTblAccount();
            this.clsTbBox = new ClsTblBox();
            this.clsTbPrdMan = new ClsTblPrdManufacture();
            this.clsTbEntrySub = new ClsTblEntrySub();
            this.clsTbPrdQuantity = new ClsTblProductQunatity();
            this.clsTbDscntPrmsion = new ClsTblDscntPrmsion();
            this.clsPrdManAvrPrice = new ClsPrdManAvrPrice(this.clsTbPrdPriceQuan, this.clsTbPrdMan, this.clsTbPrdMsur);
            InitPrdStoreObj();
            /*Task.Run(() =>*/
            InitBindingSourceData()/*)*/;
        }

        private bool ValidateData()
        {
            UpdateControls();
            try
            {
                if (!ValidateControls()) return false;
                if (!ValidateSupplyObj()) return false;
                if (!ValidateRtrnMark()) return false;
                if (!ValidateEntryNo()) return false;
                log.Debug("StartValidateGridData");
                if (!ValidateGridData()) return false;
                log.Debug("EndValidateGridData");
                if (!ValidateSupplyAmount()) return false;
                log.Debug("EndValidateSupplyAmount");
                if (!ValidateCustomerCelling()) return false;
                log.Debug("EndValidateCustomerCelling");
                if (!SaveGridToList()) return false;
                log.Debug("EndSaveGridToList");
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                new ExceptionLogger(ex, "formAddSupplyVoucher::ValidateData()");
                return false;
            }

            return true;
        }

        private void UpdateControls()
        {
            ChangeFocus();
            ChangeFocusedColumn();
            gridView.UpdateCurrentRow();
        }

        private void mandibCopunSave(bool addEdit)
        {
            if (txtdisCpon.Text != "")
            {
                var copun = db.CouponBarcodes.SingleOrDefault(w => w.BarCode == txtdisCpon.EditValue.ToString());
                if (copun != null)
                {
                    copun.IsDefault = false;
                    copun.supTotal = Convert.ToDecimal(spinEditTotalFinalDecimal.Text);
                    copun.supNo = Convert.ToInt32(supNoTextEdit.EditValue);
                    //copun.dateExpir = DateTime.Now;

                }
            }

            if (RepNameTextEdit.Text != "")// && test == true)
            {
                tblSupplyMain mandob = new tblSupplyMain(); 
                if (addEdit == true)
                    mandob = db.tblSupplyMains.Add(this.tbSupplyMain);
                else
                    mandob = db.tblSupplyMains.ToList().FirstOrDefault(m=>m.supNo == int.Parse(supNoTextEdit.Text));
                //var mandob = db.();
                //tblSupplyMain mandob = new tblSupplyMain();
                var mandobcommission = db.tblRepresentatives.FirstOrDefault(g => g.repName == RepNameTextEdit.Text);
                mandob.repName = RepNameTextEdit.Text;
                if (radioGroup1.SelectedIndex == 0)
                {

                    var comm = Convert.ToDouble(mandobcommission.repRate);
                    double result = Math.Round((Convert.ToDouble(labelTotalDecimal.Text) * comm) / 100, 2);
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
                        var repsD = db.tblRepresentativeStores.FirstOrDefault(e => e.RepName == RepNameTextEdit.Text && e.ProudctName == productName);
                        if (repsD != null)
                        {
                            resultM += (price - Convert.ToDouble(repsD.repPrice)) * Quintity;
                        }


                    }
                    mandob.commission = resultM;


                }
                //test = false;
            }

        }
        private bool SaveData()
        {
            //UserBoxPeriodsCheckEdit
            var userdr = db.tblSettings.First();
            if (userdr.UserDrawerPeriods == true)
            {
                var drp = db.DrawerPeriods.FirstOrDefault(m => m.PeriodUserID == Session.CurrentUser.id && m.Status == false);
                if (drp == null)
                {
                    ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry, Not saved Daily period must be opened first for the user" : "لم يتم الحفظ يجب فتح فترة يومية أولا للمستخدم");
                    return false;
                }
            }

            ClsStopWatch stopWatch = new ClsStopWatch();
            log.Debug("SaveDataStart");
            if (!ValidateData())
            {
                log.Debug($"SaveDataEnd !ValidateData()=> {stopWatch.Stop()}");
                return false;
            }
            bool isSaved = false;
            try
            {
                if (this.isNew)
                {
                    mandibCopunSave(true);
                    log.Debug($"StartSaveMain supNo = {this.tbSupplyMain.supNo}");
                    bool isSaveMain = SaveMain();
                    log.Debug($"StartSaveSub");
                    bool isSaveSub = SaveSub();
                    log.Debug($"EndSaveSub");
                    bool isQuantity = false;

                    if (this.supplyType == SupplyType.Sales)
                        isQuantity = this.clsPrdQuantityOpr.DeductPrdQuantity(this.tbPrdQuanList) && this.clsPrdPriceQuanOpr.DeductPrdQuantity(this.tbPrdQuanList);
                    else
                        isQuantity = clsPrdQuantityOpr.AddPrdQuantity(this.tbPrdQuanList) && this.clsPrdPriceQuanOpr.AddPrdQuantity(this.tbPrdQuanList);

                    log.Debug("StartSupplyAutoTarhel");
                    bool isSupplyAutoTarhel = SupplyAutoTarhel();
                    log.Debug("EndSupplyAutoTarhel");
                    if (isSaveMain && isSaveSub && isQuantity && isSupplyAutoTarhel) isSaved = true;
                }
                else
                {
                    mandibCopunSave(false);
                    bool isSaveMain = SaveMain();
                    bool isSaveSub = SaveSub();
                    bool is1 = this.clsPrdQuantityOpr.UpdateProductQuantity(this.tbPrdQuanListOld, this.tbPrdQuanList, (this.supplyType == SupplyType.Sales));
                    bool is2 = this.clsPrdPriceQuanOpr.UpdateProductQuantity(this.tbPrdQuanListOld, this.tbPrdQuanList, (this.supplyType == SupplyType.Sales));
                    isSaved = true;

                }

                SaveNotification();
            }
            catch (Exception ex)
            {
                new ExceptionLogger(ex, "formAddSupplyVoucher::SaveData()");
            }

            log.Debug($"SaveDataEnd, isSaved = {isSaved} => {stopWatch.Stop()}");
            return isSaved;
        }
        UploadDataToMain SendDataToServer;
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!SaveData()) return;

            //string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), this.supNo);
            //this.Close();
            //if (ConnSetting.GetConnSetting.SendDataToServerOnSave && this.isNew)
            //{
            //    tblSupplyMain temp = GetCopyOfCurrenttblSupplyMain();
            //    Task.Run(() => SendDataToServer = new UploadDataToMain(temp, this.tbSupplySubList));
            //}
            //if (this.isNew && this.supplyType == SupplyType.Sales)
            //{
            //    if (_formSupplyMain.CloseForm())
            //    {
            //        _ucSales.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
            //        _formSupplyMain.SetDialogResultOK();
            //    }
            //    else
            //    {
            //        flyDialog.ShowDialogFormBelowRIbbon(_formSupplyMain, ribbonControl1, mssg);
            //        ShowPrintInvoice();
            //    }
            //    return;
            //}
            //CloseForm(mssg);

            if (!SaveData()) return;
            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), this.supNo);
            this.Close();
            if (this.isNew && this.supplyType == SupplyType.Sales)
            {
                if (_formSupplyMain.CloseForm)
                {
                    _formSupplyMain.Close();
                    RefreschForm("barButtonItemSale", mssg);
                }
                else
                {
                    flyDialog.ShowDialogFormBelowRIbbon(_formSupplyMain, ribbonControl1, mssg);
                    ShowPrintInvoice();
                }
            }
            else if (this.isNew && this.supplyType == SupplyType.SalesRtrn)
                RefreschForm("barButtonItemSaleRtrn", mssg);
            else if (this.supplyType == SupplyType.Sales)
                RefreschForm("barButtonItemSale", mssg);
        }
        void RefreschForm(string barButton, string mssg)
        {
            Form form = Application.OpenForms["FormMain"];
            if (form is FormMain formMain && formMain.xtraTabControl1.TabPages.Any(x => x.Name == barButton))
            {
                XtraTabPage tabPage = formMain.xtraTabControl1.TabPages?.FirstOrDefault(x => x.Name == barButton);
                if (tabPage?.Controls[0] is UCsalesInstantFeedBack uCsalesInstant)
                {
                    formMain.xtraTabControl1.SelectedTabPage = tabPage;
                    uCsalesInstant.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
                    uCsalesInstant.RefreshListDialog();
                }
            }
            else
            {
                using (UCsalesInstantFeedBack uCsalesInstant = new UCsalesInstantFeedBack(this.supplyType))
                {
                    uCsalesInstant.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
                    uCsalesInstant.PrintInvoice();
                }
            }

            flyDialog.ShowDialogForm(form, mssg, this.isNew);
        }
        private void SaveAndNew(bool printInvoice)
        {
            log.Debug("StartSaveAndNew()");
            if (!SaveData()) return;
            log.Debug("EndSaveAndNew()");

            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleSuccessMssg" : "saleRtrnSuccessMssg"), this.supNo);
            flyDialog.ShowDialogFormBelowRIbbon((this.supplyType != SupplyType.DirectSalesRtrn) ? _formSupplyMain : (Form)this, ribbonControl1, mssg);
            if (ConnSetting.GetConnSetting.SendDataToServerOnSave && this.isNew)
            {
                tblSupplyMain temp = GetCopyOfCurrenttblSupplyMain();
                Task.Run(() => SendDataToServer = new UploadDataToMain(temp, this.tbSupplySubList));
            }
            if (printInvoice)
                ShowPrintInvoice();
            ResetData();
            this.isNew = true;
            this.isCash = 1;
            test = true;
            txtdisCpon.Text = "";
            radioGroupIsCash.EditValue = this.isCash;

            log.Debug("EndSaveAndNew() \n\n");
            this.hasTax = checkEditTax.Checked;
            //HasTax();
            SetNotificationDateVisibility();
            txtdisround.Reset();
        }
        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAndNew(true);
        }

        private void bbiSaveAndNewNoPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAndNew(false);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(_resource.GetString("CloseFormMssg"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
                if (this.isNew && this.supplyType == SupplyType.Sales && _formSupplyMain != null)
                    if (_formSupplyMain.CloseForm) _formSupplyMain.CloseMainForm();
            }
        }

        private void BbiCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            UCcustomers ucCustomers = new UCcustomers() { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 };
            ucCustomers.ribbonControl.StatusBar.Hide();
            ucCustomers.ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            flyDialog.WaitForm(this, 0);

            ClsFlyoutDialog.ShowFlyoutDialog(this, ucCustomers, (!MySetting.GetPrivateSetting.LangEng) ? "العملاء" : "Customers");
        }

        private void BbiRefreshCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            this.clsTbCustomer = new ClsTblCustomer();
            //repositoryItemSearchLookUpEditCustomerBbi.DataSource = 
            tblCustomerBindingSource.DataSource = this.clsTbCustomer.GetCustomersList().Where(x => x.custBrnId == Session.CurBranch.brnId);
            bbiCustomerSLE.Refresh();
            SetBbiCustomerSLE();
            flyDialog.WaitForm(this, 0);
        }

        private void BbiUpdateInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            UCsales ucSales = new UCsales(SupplyType.Sales);
            ucSales.ribbonControl.Hide();
            ucSales.ribbonControl.StatusBar.Hide();
            ucSales.Dock = DockStyle.Fill;
            ucSales.Height = ClientSize.Height / 2;
            InitFlyoutDialog(ucSales);
        }

        private void bbiPriceOffer_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            this.flyDialogOrders = ClsFlyoutDialog.InitFlyoutDialog(this, new ucOrders(OrderType.PriceOffer, this)
            { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 }, ClsOrderStatus.GetStringPlural(5));
            flyDialog.WaitForm(this, 0);

            this.flyDialogOrders.MouseCaptureChanged += FlyDialogOrders_MouseCaptureChanged;
            this.flyDialogOrders.Show();

            SetFormState(false);
        }

        private void SetFormState(bool isEnabled)
        {
            _formSupplyMain.Enabled = isEnabled;
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
            this.tbPrdMsur = new tblPrdPriceMeasurment();

            InitOrderMainSupply(tbOrderMain);
            InitOrderSubSupply(tbOrderSubList);
            CalculateTotalAmount();

            flyDialog.WaitForm(this, 0);
        }

        private void InitOrderMainSupply(tblOrderMain tbOrderMain)
        {
            this.tbSupplyMain = ClsObjectConverter.OrderToSupplyMain(tbOrderMain, this.supplyType);

            tblSupplyMainBindingSource.DataSource = this.tbSupplyMain;
            SupAccNoTextEdit_EditValueChanged(supAccNoLookUpEdit, EventArgs.Empty);
        }

        private void InitOrderSubSupply(IList<tblOrderSub> tbOrderSubList)
        {
            var tbSupplySubList = ClsObjectConverter.OrderToSupplySubTmp(tbOrderSubList, this.supplyType, this.clsTbProduct,
                this.clsTbGroupStr, this.clsTbPrdMsur, this.clsTbBarcode);

            tblSupplySubBindingSource.DataSource = tbSupplySubList;
        }

        private void InitFlyoutDialog(UCsales ucSales)
        {
            FlyoutCommand flyoutCommand = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق" : "Close",
                Result = DialogResult.Yes,
            };
            FlyoutAction flyoutAction = new FlyoutAction();
            flyoutAction.Caption = (!MySetting.GetPrivateSetting.LangEng) ? "فواتير المبيعات" : "Sales Invoices";
            flyoutAction.Commands.Add(flyoutCommand);

            FlyoutDialog dialog = new FlyoutDialog(this, flyoutAction, ucSales);
            flyDialog.WaitForm(this, 0);
            if (dialog.ShowDialog() == DialogResult.Yes) dialog.Close();
        }

        private void bbiReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }

        private void bbiEditQuantity_ItemClick(object sender, ItemClickEventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupQuanMain))).ShowDialog();
        }

        private void bbiEditPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupSalePrice))).ShowDialog();
        }

        private void bbiPrdPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show($"{_resource.GetString("PrdPrice")} {gridView.GetFocusedRowCellValue(colsupPrdName)} {gridView.GetFocusedRowCellValue(colsupPrice)}");
            //XtraMessageBox.Show($"{_resource.GetString("PrdPrice")} {gridView.GetFocusedRowCellValue(colsupPrdName)} {gridView.GetFocusedRowCellValue(colsupPrice):f2}");
        }

        private void bbiRibbonView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChangeRibbonStyle();
            SetRibbonItemsStyle();
            SetBbiRibbonStyleCaption();
            SaveRibbonSettings();
        }

        private void ChangeRibbonStyle()
        {
            ribbonControl1.RibbonStyle = (ribbonControl1.RibbonStyle == RibbonControlStyle.MacOffice) ?
                RibbonControlStyle.OfficeUniversal : RibbonControlStyle.MacOffice;
        }

        private void SetBbiRibbonStyleCaption()
        {
            bbiRibbonStyle.Caption = (ribbonControl1.RibbonStyle == RibbonControlStyle.MacOffice) ?
                ((!MySetting.GetPrivateSetting.LangEng) ? "تصغير العرض" : "Minimize Ribbon") : ((!MySetting.GetPrivateSetting.LangEng) ? "تكبير العرض" : "Maximize Ribbon");
        }

        private void SetRibbonItemsStyle()
        {
            switch (ribbonControl1.RibbonStyle)
            {
                case RibbonControlStyle.OfficeUniversal:
                    repositoryItemRadioGroupIsCash.Columns = 2;
                    radioGroupIsCash.EditWidth = 100;
                    break;
                case RibbonControlStyle.MacOffice:
                    repositoryItemRadioGroupIsCash.Columns = 1;
                    radioGroupIsCash.EditWidth = -1;
                    break;
            }
        }
        private void SaveRibbonSettings()
        {
            if (this.supplyType == SupplyType.Sales) MySetting.GetPrivateSetting.ribbonStyleSaleForm = ribbonControl1.RibbonStyle;
            else MySetting.GetPrivateSetting.ribbonStyleSaleRtrnForm = ribbonControl1.RibbonStyle;
            MySetting.WriterSettingXml();
        }

        private void InitRibbonStyle()
        {
            ribbonControl1.RibbonStyle = (this.supplyType == SupplyType.Sales) ? MySetting.GetPrivateSetting.ribbonStyleSaleForm : MySetting.GetPrivateSetting.ribbonStyleSaleRtrnForm;
            SetRibbonItemsStyle();
            SetBbiRibbonStyleCaption();
        }

     

        private bool SaveGridToList()
        {
            this.tbSupplySubList = new List<tblSupplySub>();
            this.tbPrdQuanList = new List<ClsProductQuantList>();
            long grpAccNo = 0;

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                if (gridView.GetRowCellValue(i, colsupPrdNo) == null) continue;

                tblSupplySub tbSupplySub = gridView.GetRow(i) as tblSupplySub;
                if (tbSupplySub == null || this.tbSupplySubList == null)
                {
                    ClsXtraMssgBox.ShowWarningYesNo("يرجى إعادة المحاولة");
                    return false;
                }

                if (!checkEditTax.Checked)
                {
                    tbSupplySub.supTaxPercent = 0;
                    tbSupplySub.supTaxPrice = 0;
                }
                if (this.supplyType != SupplyType.SalesRtrn)
                {
                    grpAccNo = this.clsTbGroupStr.GetGroupAccNoById(Convert.ToInt64(gridView.GetRowCellValue(i, colsupAccNo)));
                    if (grpAccNo == 0)
                    {
                        XtraMessageBox.Show(_resource.GetString("grpErrorMssg"));
                        return false;
                    }
                    else
                    {
                        tbSupplySub.supAccNo = grpAccNo;
                        tbSupplySub.supAccName = this.clsTbAccount.GetAccountNameByNo(grpAccNo);
                    }
                }

                if (tbSupplySub.supCurrency > 1)
                {
                    if (this.supplyType == SupplyType.Sales)
                    {
                        tbSupplySub.supCredit = tbSupplySub.supCredit * Convert.ToDouble(supCurrencyChngTextEdit.EditValue);
                        tbSupplySub.supCreditFrgn = tbSupplySub.supCredit;
                    }
                    else
                    {
                        tbSupplySub.supDebit = tbSupplySub.supDebit * Convert.ToDouble(supCurrencyChngTextEdit.EditValue);
                        tbSupplySub.supDebitFrgn = tbSupplySub.supDebit;
                    }
                }
                if (tbSupplySub.supMsur != null)
                    tbSupplySub.supPrice = GetPrdPrice(this.clsTbPrdMsur.GetPrdPriceMsurById(tbSupplySub.supMsur.Value));
                this.tbSupplySubList.Add(tbSupplySub);
                AddPrdQuanList(tbSupplySub);
            }
            return true;
        }

        private void ChangeFocusedColumn()
        {
            gridView.FocusedColumn = (gridView.FocusedColumn == colsupPrdNo) ? colprdName : colsupPrdNo;
        }
        private bool UpdateTbSupplyMainTotalAmount()
        {
            //this.tbSupplyMain.supTotal = ((this.currency == 1) ? this.totalAmount : this.totalAmount * (int)this.tbSupplyMain.supCurrencyChng);
            this.tbSupplyMain.supTotal = (this.currency == 1) ? this.totalAmount : this.totalAmount * (int)this.tbSupplyMain.supCurrencyChng;
            this.tbSupplyMain.supTotalFrgn = (this.currency > 1) ? this.totalAmount : 0;
            this.tbSupplyMain.supEqfal = (this.isCash == 1) ? (byte)2 : (byte)1;

            //if (!this.hasTax) return true;
            this.tbSupplyMain.supTaxPrice = this.totalTax;
            this.tbSupplyMain.supTaxPercent = (this.hasTax) ? MySetting.GetPrivateSetting.taxDefault : (byte)0;
            if (textEditPaidCash.Text != string.Empty)
            {
                this.tbSupplyMain.paidCash = double.Parse(textEditPaidCash.Text);
                //this.tbSupplyMain.supBoxId = ((supBoxIdTextEdit.EditValue as short?) ?? 0);
            }

            //this.tbSupplyMain.supTaxPercent = MySetting.GetPrivateSetting.taxDefault;
            //double Final = double.Parse(spinEditTotalFinalDecimal.Text);
            //this.tbSupplyMain.supTotal = (Final - tbSupplyMain.supTaxPrice ?? 0);
            SetTbSupplyMainDscnt();
            return false;
        }

        private void SetTbSupplyMainDscnt()
        {
            if (!string.IsNullOrWhiteSpace(supDscntAmountTextEdit.Text)) return;

            Console.WriteLine("=========passed 1 condition");
            Console.WriteLine($"====================decimalTryParseDiscountAmount = {double.TryParse(supDscntAmountTextEdit.Text, out double dscntAmount2)}");
            if (double.TryParse(supDscntAmountTextEdit.Text, out double dscntAmount) || dscntAmount > 0) return;
            Console.WriteLine("=========passed 2 condition");
            if (this.discountAmount == 0) return;
            Console.WriteLine("=========passed 3 condition");

            this.tbSupplyMain.supDscntAmount = this.discountAmount;
            this.tbSupplyMain.supDscntPercent = (this.discountAmount != 0 ? Convert.ToDouble((this.discountAmount / this.totalAmount) * 100) : 0);
        }

        //private void SetCustomerId()
        //{
        //    if (this.tbCustomer == null) return;
        //    this.tbSupplyMain.supCustSplId = this.tbCustomer.id;
        //    this.tbSupplyMain.DueDate = (notDateTextEdit.EditValue as DateTime?) ?? null;
        //}
        private void SetCustomerId()
        {
            if (this.tbCustomer == null && bbiCustomerSLE.EditValue == null && ((supRefNoTextEdit.EditValue as string) ?? "") == string.Empty) return;
            else if (this.tbCustomer != null)
                this.tbSupplyMain.supCustSplId = this.tbCustomer.id;
            else if (this.isCash == 1 && bbiCustomerSLE.EditValue != null)
                this.tbSupplyMain.supCustSplId = (int)bbiCustomerSLE.EditValue;
            else if (((supRefNoTextEdit.EditValue as string) ?? "") != string.Empty)
            {
                tblCustomer cus = this.clsTbCustomer.GetCustomersList().Where(x => x.custNo == Convert.ToInt32(supRefNoTextEdit.EditValue)).FirstOrDefault();
                if (cus != null)
                    this.tbSupplyMain.supCustSplId = cus.id;
            }
            this.tbSupplyMain.DueDate = (notDateTextEdit.EditValue as DateTime?) ?? null;
        }

        private bool SaveMain()
        {
            bool isSaved = false;
            SetCustomerId();
            UpdateTbSupplyMainTotalAmount();
            this.tbSupplyMain.supDate = (supDateDateEdit.EditValue as DateTime?) ?? null;
            if (this.isNew)
            {
                this.tbSupplyMain.supDate = MySetting.DefaultSetting.AllowSaveInvoInBeforeDate ? supDateDateEdit.DateTime : DateTime.Now;
                if (this.supplyType == SupplyType.SalesRtrn)
                    db2.tblSupplyMains.Add(this.tbSupplyMain);
                else
                {
                    if (!supNoTextEdit.Enabled)
                    {
                        var sup = db.tblSupplyMains.Where(x => x.supBrnId == Session.CurBranch.brnId &&
                                 x.supDate.Value >= Session.CurrentYear.fyDateStart.Date && (x.supStatus == status1 || x.supStatus == status2));
                        if (sup.Count() > 0)
                            this.tbSupplyMain.supNo = sup.Max(x => x.supNo) + 1;
                        else this.tbSupplyMain.supNo = 1;
                    }
                    else if (db.tblSupplyMains.Any(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == this.tbSupplyMain.supNo &&
                                 x.supDate.Value >= Session.CurrentYear.fyDateStart.Date && (x.supStatus == status1 || x.supStatus == status2)))
                    {
                        ClsXtraMssgBox.ShowError("عفوا رقم الفاتورة موجود من قبل قم باختيار رقم اخر!!!");
                        return false;
                    }
                    this.supNo = this.tbSupplyMain.supNo;
                    db.tblSupplyMains.Add(this.tbSupplyMain);
                }
                if (SaveDB())
                {
                    this.supMainId = this.tbSupplyMain.id;
                    isSaved = true;
                }
            }
            else
            {
                var Baseitem = db.tblSupplyMains.Find(this.tbSupplyMain.id);
                db.Entry(Baseitem).CurrentValues.SetValues(this.tbSupplyMain);
                if (db.SaveChanges() > 0)
                {
                    this.supMainId = this.tbSupplyMain.id;
                    this.cstId = ((this.tbSupplyMain.supCustSplId as int?) ?? 0);
                    isSaved = true;
                }
            }
            bool isSaveCustomerInvoices = SaveCustomerInvoice();
            return isSaved && isSaveCustomerInvoices ? true : false;
        }

        private bool SaveCustomerInvoice()
        {
            try
            {
                if (!this.isNew)
                {
                    db.tblCustomerInvoices.RemoveRange(db.tblCustomerInvoices.Where(x => x.invSupId == this.supMainId));
                    SaveDB();
                }

                if (this.tbSupplyMain.supCustSplId == null) return true;

                tblCustomerInvoice tbCustomerInv = new tblCustomerInvoice()
                {
                    invSupId = this.supMainId,
                    invCstId = (this.isCash == 1) ? (int)this.tbSupplyMain.supCustSplId : this.cstId,
                    invBrnId = Session.CurBranch.brnId
                };
                if (this.supplyType == SupplyType.Sales)
                    db.tblCustomerInvoices.Add(tbCustomerInv);
                else
                    db2.tblCustomerInvoices.Add(tbCustomerInv);
                return SaveDB();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"====================errorSaveCustomerInvoices \n {ex.Message}");
                new ExceptionLogger(ex, "formAddSupplyVoucher::SaveCustomerInvoice()");
                return false;
            }
        }

        private bool SaveSub()
        {
            if (!isNew)
            {
                db.tblSupplySubs.RemoveRange(db.tblSupplySubs.Where(x => x.supNo == this.supMainId));
                SaveDB();
            }

            foreach (var tbSupplySub in this.tbSupplySubList)
            {
                if (((tbSupplySub.supCredit as double?) ?? 0) != 0)
                {
                    string value = tbSupplySub.supCredit.Value.ToString();
                    if (value.Contains("."))
                    {
                        float floatValu = float.Parse(value.Substring(value.IndexOf(".")));
                        if (floatValu >= 0.99)
                        {
                            int intValue = Convert.ToInt32(tbSupplySub.supCredit.Value);
                            tbSupplySub.supCredit = intValue;
                        }
                        else if (floatValu <= 0.009)
                            tbSupplySub.supCredit = Math.Floor(tbSupplySub.supCredit.Value * 100) / 100;// double.Parse(value.Substring(0, value.IndexOf(".") + 2));
                    }
                }
                if ((!MySetting.DefaultSetting.AllowSaveInvoInBeforeDate) & isNew) supDateDateEdit.DateTime = DateTime.Now;
                tblSupplySub supplySub = new tblSupplySub
                {
                    supNo = this.supMainId,
                    supDate = supDateDateEdit.DateTime,
                    supBrnId = Session.CurBranch.brnId,
                    supUserId = Session.CurrentUser.id,
                    supStatus = this.status1,
                    supAccNo = tbSupplySub.supAccNo,
                    supAccName = tbSupplySub.supAccName,
                    supDesc = tbSupplySub.supDesc,
                    supPrdBarcode = tbSupplySub.supPrdBarcode,
                    supPrdNo = tbSupplySub.supPrdNo,
                    supPrdName = tbSupplySub.supPrdName,
                    supPrdId = tbSupplySub.supPrdId,
                    supMsur = tbSupplySub.supMsur,
                    supPrdManufacture = tbSupplySub.supPrdManufacture,
                    supCurrency = tbSupplySub.supCurrency,
                    supQuanMain = tbSupplySub.supQuanMain,
                    supPrice = tbSupplySub.supPrice,
                    supSalePrice = tbSupplySub.supSalePrice,
                    supTaxPercent = tbSupplySub.supTaxPercent,
                    supTaxPrice = tbSupplySub.supTaxPrice,
                    supDscntPercent = tbSupplySub.supDscntPercent,
                    supDebit = tbSupplySub.supDebit,
                    supCredit = tbSupplySub.supCredit,
                    supDebitFrgn = tbSupplySub.supDebitFrgn,
                    supCreditFrgn = tbSupplySub.supCreditFrgn,
                    supDscntAmount = tbSupplySub.supDscntAmount,
                    subHeight = tbSupplySub.subHeight,
                    subQteMeter = tbSupplySub.subQteMeter,
                    subWidth = tbSupplySub.subWidth,
                    subNoPacks = tbSupplySub.subNoPacks,
                    supOvertime = tbSupplySub.supOvertime,
                    supWorkingtime = tbSupplySub.supWorkingtime,
                };

                if (this.supplyType != SupplyType.SalesRtrn)
                    db.tblSupplySubs.Add(supplySub);
                else
                    db2.tblSupplySubs.Add(supplySub);
            }

            return SaveDB();

        }

        private void SaveNotification()
        {
            if (this.isCash == 1 || (this.isCash == 2 && notDateTextEdit.DateTime.Date ==
                new DateTime(0001, 01, 01, 00, 00, 00))) return;

            if (this.isNew || (!this.isNew && this.tbNotification == null)) SaveNewNotification();
            else UpdateNotification();
        }

        private void SaveNewNotification()
        {
            new ClsTblNotification().Add(this.tbSupplyMain.id, this.tbSupplyMain.supNo, $"العميل: {this.tbSupplyMain.supAccName}",
                this.tbSupplyMain.supDesc, GetTotalAmountFinal(), notDateTextEdit.DateTime.Date, NotStatus.Sales);
        }

        private void UpdateNotification()
        {
            this.tbNotification.notNo = this.tbSupplyMain.supNo;
            this.tbNotification.notName = $"العميل: {this.tbSupplyMain.supAccName}";
            this.tbNotification.notDesc = this.tbSupplyMain.supDesc;
            this.tbNotification.notAmount = GetTotalAmountFinal();
            this.tbNotification.notDate = notDateTextEdit.DateTime.Date;

            this.clsTbNotification.SaveDB();
        }

        private double GetTotalAmountFinal()
        {
            double.TryParse(spinEditTotalFinalDecimal.Text, out double amount);
            return amount;
        }

        private void AddPrdQuanList(tblSupplySub tbSupplySub)
        {
            if (!tbSupplySub.supPrdManufacture) AddPrdQuanListObj(tbSupplySub);
            else foreach (var tbPrdMan in this.clsTbPrdMan.GetPrdManListByPrdId(Convert.ToInt32(tbSupplySub.supPrdId)))
                    AddPrdQuanListObj(tbSupplySub, tbPrdMan.manPrdSubId, tbPrdMan.manPrdMsurId, Convert.ToDouble(tbSupplySub.supQuanMain) * Convert.ToDouble(tbPrdMan.manQuan));
        }

        private void AddPrdQuanListObj(tblSupplySub tbSupplySub, int prdId = 0, int prdMsurId = 0, double quantity = 0)
        {
            this.tbPrdQuanList.Add(new ClsProductQuantList()
            {
                prdId = (prdId == 0) ? Convert.ToInt32(tbSupplySub.supPrdId) : prdId,
                prdNo = Convert.ToString(tbSupplySub.supPrdNo),
                prdName = Convert.ToString(tbSupplySub.supPrdName),
                prdQuantity = (quantity == 0) ? Convert.ToDouble(tbSupplySub.supQuanMain) : quantity,
                prdPriceMsurId = (prdMsurId == 0) ? Convert.ToInt32(tbSupplySub.supMsur) : prdMsurId,
                prdStrId = Convert.ToInt16(bbiStrIdSLE.EditValue)
            });
        }

        private bool SupplyAutoTarhel()
        {
            if (!this.autoSupplyTarhel) return true;

            this.tbSupplyMain.id = this.supMainId;
            return this.clsSupplyTarhel.PhaseInvoice(new Collection<tblSupplyMain>() { this.tbSupplyMain });
        }

        private bool ValidateControls()
        {
            if (this.tbSupplyMain == null && this.supplyType != SupplyType.SalesRtrn && this.isNew)
            {
                InitSupplyMainObj();
                if (bbiCustomerSLE?.EditValue != null) this.tbSupplyMain.supCustSplId = Convert.ToInt32(bbiCustomerSLE.EditValue);
                layoutControlGrooupMain.Expanded = true;
                ClsXtraMssgBox.ShowWarning("يرجى التاكد من بيانات الفاتورة الرئيسية!");
                return false;
            }
            if (this.tbSupplyMain?.supAccNo == null || this.tbSupplyMain.supAccName == null || this.tbSupplyMain.supCurrency == null || this.tbSupplyMain.supNo == 0)
                layoutControlGrooupMain.Expanded = true;
            return dxValidationProvider1.Validate();
        }

        private bool ValidateEntryNo()
        {
            ClsStopWatch stopWatch = new ClsStopWatch();
            log.Debug("StartValidateEntryNo()");

            ChangeFocus();
            bool isValid = true;
            //this.clsSupply = new ClsSupply();
            this.supNo = this.tbSupplyMain.supNo;
            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Sales) ? "saleErrMssg" : "saleRtrnErrMssg"), this.supNo);

            //if (this.isNew && this.supNo == 0) this.supNo = (this.isCash == 1) ? this.clsSupply.StoreEntryNoBox(this.accNo, this.status1, this.status2) :
            //        this.clsSupply.StoreEntryNoCredit(this.status1, this.status2);

            //if (this.isNew)
            //{
            //    SetSupplyNo();
            //}
            //else
            //{
            //    if (this.supNoOld != this.supNo && this.isCash == 1 && this.clsSupply.IsSupFoundBox(this.supNo, this.accNo, this.status1, this.status2))
            //        isValid = false;
            //    else if (this.supNoOld != this.supNo && this.isCash == 2 && this.clsSupply.IsSupFoundCredit(this.supNo, this.status1, this.status2))
            //        isValid = false;
            //}

            if (!isValid) XtraMessageBox.Show(mssg);
            log.Debug($"EndValidateEntryNo() => isValid: {isValid}, {stopWatch.Stop()}");

            return isValid;
        }

        private bool ValidateRtrnMark()
        {
            if (this.supplyType != SupplyType.SalesRtrn) return true;

            bool isValid = barCheckItem1.Checked;
            if (!isValid) XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ?
                "عذرا يجب الضغط على زر التحديد أولاً" : "Please press check button first!");

            return isValid;
        }

        private bool ValidateGridData()
        {
            if (!this.gridValid) return false;
            if (gridView.DataRowCount == 0)
            {
                XtraMessageBox.Show(_resource.GetString("GridErrorMssg"));
                return false;
            }
            else
            {
                //if (!MySetting.DefaultSetting.showPrdQtyMssg) return true;
                //for (int i = 0; i < gridView.RowCount; i++)
                //{
                //    if (gridView.GetRowCellValue(i, colprdQuanAvlb) != null && gridView.GetRowCellValue(i, colprdQuanAvlb) is double c)
                //        if (c < 0)
                //        {
                //            XtraMessageBox.Show("عذرا يوجد اصناف سالبة ");
                //            return false;

                //        }
                //}
                //if (!MySetting.DefaultSetting.showPrdQtyMssg) return true;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRowCellValue(i, colprdQuanAvlb) != null && gridView.GetRowCellValue(i, colprdQuanAvlb) is double c)
                        if (c < 0 && MySetting.DefaultSetting.showPrdQtyMssg)
                        {
                            XtraMessageBox.Show("عذرا يوجد اصناف سالبة ");
                            return false;

                        }
                    if (Convert.ToDouble(gridView.GetRowCellValue(i, colsupSalePrice)) < Convert.ToDouble(gridView.GetRowCellValue(i, colsupPrice)) &&
                      (MySetting.DefaultSetting.tsDefaultSalePriceAndBuy == (short)WarningLevels.Prevent))
                    {
                        ClsXtraMssgBox.ShowWarning("عذرا يوجد اصناف سعر البيع اقل من سعر التكلفه ");
                        return false;
                    }
                }
            }
            textEditBarcodeNo.Focus();
            return true;
        }

        private bool ValidateSupplyObj()
        {
            // SetSupplyNo();
            if (this.tbSupplyMain != null) return true;

            InitSupplyMainObj();
            InitSupplySubGridObj();
            return false;
        }

        private bool ValidateSupplyAmount()
        {
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا يجب ان لا تكون قيمة الفاتورة 0" : "Sorry invoice amount can not be 0");
                return false;
            }
            double Final = double.Parse(spinEditTotalFinalDecimal.Text);
            double paidCash = (textEditPaidCash.Text == string.Empty ? 0 : double.Parse(textEditPaidCash.Text));
            double paidCreditCard = (textEditPaidCreditCard.Text == string.Empty ? 0 : double.Parse(textEditPaidCreditCard.Text));
            double paid = paidCash + paidCreditCard;
            if (this.tbSupplyMain.supIsCash == 2 && paid == Final)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? $"عذرا يجب ان لا تكون الفاتورة اجل لان اجمالي المدفوع {paid} يساوي قيمة الفاتورة {Final}" : $"Sorry, Payment method can not be Postpaid because the payment {paid} is equal to the value of the invoice {Final}");
                return false;
            }
            if (paid > Final)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? $"عذرا يجب ان لا يكون المدفوع {paid} اكبر من قيمة الفاتورة {Final}" : $"Sorry, the amount paid {paid} cannot be more than the invoice amount {Final}");
                return false;
            }
            return true;
        }

        private bool ValidateCustomerCelling()
        {
            if (this.tbSupplyMain.supIsCash != 2) return true;
            if (this.tbCustomer != null && Convert.ToInt64(this.tbCustomer.custCellingCredit) == 0) return true;

            double totalFinal = this.isNew ? GetTotalAmountFinal() : GetTotalAmountFinal() - this.totalFinalOld;
            bool isValid = (totalFinal + this.clsCustBalance.GetCurrentBalance()) <= this.tbCustomer.custCellingCredit;

            if (!isValid)
            {
                string mssg = "عذراً لا يمكن تجاوز سقف حساب العميل! \n\n";
                mssg += $"رصيد حساب العميل: {this.clsCustBalance.GetCurrentBalance():f2}\n";
                mssg += $"سقف حساب العميل: {this.tbCustomer.custCellingCredit:f2}\n\n";
                mssg += $"إجمالي الفاتورة: {GetTotalAmountFinal():f2}";
                if (!this.isNew) mssg += $"\n\nإجمالي الفارق عند التعديل: {totalFinal:f2}";

                ClsXtraMssgBox.ShowError(mssg);
            }

            return isValid;
        }

        private void ResetData()
        {
            IsCash(1, MySetting.GetPrivateSetting.supplySaleExpanded, false);
            InitPrdClrList();
            //XtraMessageBox.Show("1");
            InitSupplyMainObj();
            // XtraMessageBox.Show("2");
            InitSupplySubGridObj();
            // XtraMessageBox.Show("3");
            ResetCustomerSLE();
            // XtraMessageBox.Show("4");
            ResetTotalLabels();
            // XtraMessageBox.Show("5");
            InitPrdQuanAvlbList();
            SetCustomerRibbonGroupVisibility(BarItemVisibility.Always);
            // XtraMessageBox.Show("6");

            this.gridValid = true;
            textEditBarcodeNo.Focus();
            textEditPaidCash.EditValue = null;
            notDateTextEdit.EditValue = null;
            SupAccNoTextEdit_EditValueChanged(supAccNoLookUpEdit, EventArgs.Empty);
            //  XtraMessageBox.Show("7");

            this.hasTax = checkEditTax.Checked;
            HasTax();

            this.discountAmount = 0;
            SetDiscountCoumnsEditProperty(true);

            txtdisround.Reset();
        }
        public class TempSupplySub : tblSupplySub
        {
            public double FinalAmount
            {
                get
                {
                    double t = supTaxPrice.HasValue ? supTaxPrice.Value : 0;
                    double price = supSalePrice.HasValue ? supSalePrice.Value : 0;
                    double q = supQuanMain.HasValue ? Convert.ToDouble(supQuanMain.Value) : 0;
                    double d = supDscntAmount.HasValue ? (double)supDscntAmount.Value : 0;
                    return Math.Round((price * q) - d + t, 2);
                    //return Math.Round(((price * q)) + t, 2);
                }
                set
                {
                    if (supTaxPrice > 0)
                    {
                        double price = supSalePrice.HasValue ? supSalePrice.Value : 0;
                        if (price == 0) return;
                        double q = supQuanMain.HasValue ? (double)supQuanMain.Value : 0;

                        double tax = supTaxPercent.HasValue ? supTaxPercent.Value : 0;

                        var discount = 1 - ((value / q) / (price * (1 + (tax / 100))));

                        supSalePrice = (price - (price * discount));
                    }
                }
            }
        }
        private void InitSupplySubGridObj()
        {
            tblSupplySubBindingSource.DataSource = null;
            tblSupplySubBindingSource.DataSource = typeof(TempSupplySub);
        }

        private void CloseForm(string mssg)
        {
            _ucSales.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
            DialogResult = DialogResult.OK;
        }

        private void ChangeFocus()
        {
            textEditBarcodeNo.Focus();
        }

        private void ShowPrintInvoice()
        {
            if (MySetting.DefaultSetting.ShowPrintMssg)
                PrintInvoiceMssg();
            else
                PrintReport();
        }

        private void PrintInvoiceMssg()
        {
            if (XtraMessageBox.Show(_resource.GetString("printInvoiceMssg"), "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flyDialog.WaitForm(this, 1);
                using (ReportForm frm = new ReportForm((MySetting.DefaultSetting.supplyA4CustomRprt) ? ReportType.SupplyCustom :
                    (ReportType)MySetting.DefaultSetting.printA4, tbSupplyMain: this.tbSupplyMain, tbSupplySubList: this.tbSupplySubList, clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur))
                {
                    flyDialog.WaitForm(this, 0, frm);
                    frm.ShowDialog();
                }
            }
        }
        public tblSupplyMain GetCopyOfCurrenttblSupplyMain()
        {
                return new tblSupplyMain()
                {
                    supNo = this.tbSupplyMain.supNo,
                    supDate = this.tbSupplyMain.supDate,
                    supAccName = this.tbSupplyMain.supAccName,
                    supAccNo = this.tbSupplyMain.supAccNo,
                    supBankAmount = this.tbSupplyMain.supBankAmount,
                    supBankId = this.tbSupplyMain.supBankId,
                    supBoxId = this.tbSupplyMain.supBoxId,
                    supBrnId = this.tbSupplyMain.supBrnId,
                    supCurrency = this.tbSupplyMain.supCurrency,
                    supCurrencyChng = this.tbSupplyMain.supCurrencyChng,
                    supCustSplId = this.tbSupplyMain.supCustSplId,
                    supDesc = this.tbSupplyMain.supDesc,
                    supDscntAmount = this.tbSupplyMain.supDscntAmount,
                    supDscntAmount_Round = this.tbSupplyMain.supDscntAmount_Round,
                    supDscntPercent = this.tbSupplyMain.supDscntPercent,
                    supEqfal = this.tbSupplyMain.supEqfal,
                    supIsCash = this.tbSupplyMain.supIsCash,
                    supRefNo = this.tbSupplyMain.supRefNo,
                    supStatus = this.tbSupplyMain.supStatus,
                    supStrId = this.tbSupplyMain.supStrId,
                    supTaxPercent = this.tbSupplyMain.supTaxPercent,
                    supTaxPrice = this.tbSupplyMain.supTaxPrice,
                    supTotal = this.tbSupplyMain.supTotal,
                    supTotalFrgn = this.tbSupplyMain.supTotalFrgn,
                    supUserId = this.tbSupplyMain.supUserId,
                    SendToserver = this.tbSupplyMain.SendToserver,

                    AccNoInBank = this.tbSupplyMain.AccNoInBank,
                    bankAccIBAN = this.tbSupplyMain.bankAccIBAN,
                    bankName = this.tbSupplyMain.bankName,
                    bankNameEn = this.tbSupplyMain.bankNameEn,
                    bankSwiftCode = this.tbSupplyMain.bankSwiftCode,
                    CarType = this.tbSupplyMain.CarType,
                    CommercialRegister = this.tbSupplyMain.CommercialRegister,
                    CounterNumber = this.tbSupplyMain.CounterNumber,
                    custAddressEn = this.tbSupplyMain.custAddressEn,

                    CustCountry = this.tbSupplyMain.CustCountry,
                    CustCountryEn = this.tbSupplyMain.CustCountryEn,
                    custNameEn = this.tbSupplyMain.custNameEn,
                    DueDate = this.tbSupplyMain.DueDate,
                    EnterDate = this.tbSupplyMain.EnterDate,
                    id = this.tbSupplyMain.id,
                    IsDelete = this.tbSupplyMain.IsDelete,
                    net = this.tbSupplyMain.net,
                    NetTextAr = this.tbSupplyMain.NetTextAr,

                    NetTextEn = this.tbSupplyMain.NetTextEn,
                    Notes = this.tbSupplyMain.Notes,
                    paidCash = this.tbSupplyMain.paidCash,
                    PlateNumber = this.tbSupplyMain.PlateNumber,
                    PoNumber = this.tbSupplyMain.PoNumber,
                    PostalCode = this.tbSupplyMain.PostalCode,
                    remin = this.tbSupplyMain.remin,
                    TaxAsTextAr = this.tbSupplyMain.TaxAsTextAr,
                    TaxAsTextEn = this.tbSupplyMain.TaxAsTextEn,
                    commission = this.tbSupplyMain.commission,
                    TotalAfterDiscount = this.tbSupplyMain.TotalAfterDiscount,
                    repName = this.tbSupplyMain.repName,
                };
            }
        private void PrintReport()
        {
            //ClsStopWatch stopWatch = new ClsStopWatch();
            //log.Debug("PrintReportFlyDialogStart");
            //flyDialog.WaitForm((this.supplyType == SupplyType.Sales) ? _formSupplyMain : (Form)this, 1);
            tblSupplyMain temp = GetCopyOfCurrenttblSupplyMain();
            ClsStopWatch stopWatch2 = new ClsStopWatch();
            log.Debug("PrintReportClsPrintReportStart");
            Task.Run(() => ClsPrintReport.PrintSupply(temp, this.tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
            log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");

            //flyDialog.WaitForm(this, 0);
            //log.Debug($"PrintReportFlyDialogEnd => {stopWatch.Stop()}");
        }

        private bool ExccededPrdPriceFloar(double price)
        {
            if (!MySetting.DefaultSetting.defaultSalePriceFloar)
                return false;
            bool isPriceFloar = false;

            if (price < this.ppmMinSalePrice)
            {
                XtraMessageBox.Show(string.Format(_resource.GetString("ExccededPrdPriceFloarMssg"), price, this.ppmMinSalePrice));
                gridView.SetFocusedRowCellValue(colsupSalePrice, this.ppmMinSalePrice);
                UpdateCurrentRow(gridView.FocusedRowHandle);
                isPriceFloar = true;
            }

            return isPriceFloar;
        }

        public void SetProductQunatity(int rowHandle, double quantity)
        {
            gridView.SetRowCellValue(rowHandle, colsupQuanMain, quantity);
            UpdateCurrentRow(rowHandle);
        }

        public void SetProductPrice(int rowHandle, double price)
        {
            if (ExccededPrdPriceFloar(price)) return;
            if (price > (double)999999999999999999.99)
            {
                XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                return;
            }

            price = (checkEditTax.Checked ? (price / (Convert.ToDouble(this.tax) + 100)) * 100 : price);

            gridView.SetRowCellValue(rowHandle, colsupSalePrice, price);
            gridView.RefreshRowCell(rowHandle, colsupSalePrice);

            UpdateCurrentRow(rowHandle);
        }

        private void UpdateCurrentRow(int rowHandle)
        {
            CalculateTax(rowHandle);
            CalculateTotalRow(rowHandle);
            CalculateTotalAmount();
        }

        private void SetBbiCustomerInvoice()
        {
            if (this.isCash == 2)
            {
                SetCustomerRibbonGroupVisibility(BarItemVisibility.Never);
                return;
            }
            SetCustomerRibbonGroupVisibility(BarItemVisibility.Always);
            this.cstId = new ClsTblCustomerInvoice().GetCustomerIdByInvoiceId(this.supMainId);

            if (this.cstId != 0 && this.supplyType == SupplyType.Sales)
                tblCustomerBindingSource.DataSource = this.clsTbCustomer.GetTblCustomerListByCurrencyId(this.currency).Where(x => x.custBrnId == Session.CurBranch.brnId);
            if (cstId > 0)
                bbiCustomerSLE.EditValue = this.cstId;
            else
            {
                bbiCustomerSLE.EditValue = null;
                this.tbCustomer = null;
            }

            //  bbiCustomerSLE.Enabled = false;
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
            CalculateTotalAmount();
            textEditBarcodeNo.Focus();
        }

        private void UpdateQuantity(KeyEventArgs e)
        {
            if (gridView.GetFocusedRowCellValue(colsupQuanMain) == null) return;
            double quantity = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupQuanMain));

            quantity = (e.KeyData) switch
            {
                Keys.Add => ++quantity,
                Keys.Subtract when quantity > 1 => --quantity,
                _ => quantity
            };

            gridView.SetFocusedRowCellValue(colsupQuanMain, quantity);
            UpdateCurrentRow(gridView.FocusedRowHandle);
            UpdatePrdQuanAvlb();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void DeletePrdDataFromPrdQuantDicList()
        {
            if (this.listPrdQuantDic.ContainsKey(gridView.FocusedRowHandle)) this.listPrdQuantDic.Remove(gridView.FocusedRowHandle);
            CalculateTotalAmount();
        }

        private void formAddSupplyVocher_Activated(object sender, EventArgs e)
        {
            textEditBarcodeNo.Focus();
        }

        private void layoutControlGroup8_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
        {
            //e.DefaultDraw();
            //e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            ////e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(193, 225, 254, 255)), e.Bounds);
            //e.Handled = true;
        }

        private void ResetTotalLabels()
        {
            labelTotalPriceDecimal.Text = "0.00";
            labelTotalTaxDecimal.Text = "0.00";
            labelTotalDecimal.Text = "0.00";
            labelDiscountDecimal.Text = "0.00";
            spinEditTotalFinalDecimal.EditValue = "0.00";
            spinEditTotalFinalDecimal.Text = "0.00";
            labelPaidAmountDecimal.Text = "0.00";
            labelRemaingAmountDecimal.Text = "0.00";
        }

        private void DisableItems()
        {
            ItemForBarcodeText.Enabled = false;
            checkEditTax.Enabled = false;
            //      radioGroupIsCash.Enabled = false;
            bbiStrIdSLE.Enabled = false;
        }

        private void SetRibbonButtonsVisisbility()
        {
            bbiSaveAndNew.Visibility = BarItemVisibility.Never;
            bbiSaveAndNewNoPrint.Visibility = BarItemVisibility.Never;
            bbiReset.Visibility = BarItemVisibility.Never;
            bbiNewInvoice.Visibility = BarItemVisibility.Never;
            bbiUpdateInvvoice.Visibility = BarItemVisibility.Never;
            ribbonPageGroupUpdateInvoice.Visible = false;
        }

        private void SetGridProperties()
        {
            DisableGridColumns(colsupPrdBarcode);
            DisableGridColumns(colsupPrdNo);
            DisableGridColumns(colsupMsur);
            //   gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }

        private void SetLayoutControl()
        {
            layoutControlGrooupMain.ExpandButtonVisible = false;
            layoutControlGrooupMain.ExpandOnDoubleClick = false;
            //dataLayoutControl1.Size = new Size(1137, 160);
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
            this.barcodeBeep.Open(this.barcodeBeepUri);
            this.barcodeBeep.Play();
        }

        private void InitFlyDialogPrdSrch()
        {
            if (this.InvokeRequired) this.Invoke(new MethodInvoker(delegate { InitFlyoutControls(); }));
            else InitFlyoutControls();

            this.gridControlSrchPrd.Height = 300;
            this.FormDialogPrdSearch.Shown += FlyDialogPrd_Shown;
        }

        private void InitFlyoutControls()
        {
            gridViewSrchPrd.Appearance.Row.Font = fontConverter;
            gridViewSrchPrd.Appearance.HeaderPanel.Font = fontConverter;
            BtnClosSearchPro.Text = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق" : "Close";
            this.FormDialogPrdSearch = new Form() { Size = new Size(this.Width / 2, (this.Width / 2) / 2) };
            this.FormDialogPrdSearch.ShowIcon = false;
            this.FormDialogPrdSearch.Text = (!MySetting.GetPrivateSetting.LangEng) ? "بحث الأصناف" : "Search Product";
            this.FormDialogPrdSearch.Controls.Add(layoutControl3);
            this.FormDialogPrdSearch.StartPosition = FormStartPosition.CenterScreen;
            this.FormDialogPrdSearch.RightToLeft = (!MySetting.GetPrivateSetting.LangEng) ? RightToLeft.Yes : RightToLeft.No;
            this.FormDialogPrdSearch.RightToLeftLayout = (!MySetting.GetPrivateSetting.LangEng) ? true : false;
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
            CalculateTotalTax(totalAmount);
            var tot = totalAmount + totalTax;
            double.TryParse(txtdisround.Text, out double disround);
            spinEditTotalFinalDecimal.Value = Convert.ToDecimal( tot - disround);
        }
        public double TotalFinal { get; set; }
        private void Txtdisround_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            double.TryParse(labelTotalDecimal.Text, out double totalAmount);

            CalculateTotalTax(totalAmount);
            var tot = totalAmount + totalTax;
            var r = tot;
            //var r = Math.Round(tot, 0);
            var rd = tot - r;
            if (rd < 0)
            {
                rd = rd + ((double)1.00);
            }
            txtdisround.Text = rd.ToString();
            //double.TryParse(txtdisround.Text, out double disround);
            //labelTotalFinalDecimal.Text = $"{tot - disround:f2}";
        }

        
        private void InitCustomerObj(int customersId)
        {
            if (customersId == 0) return;
            this.tbCustomer = this.clsTbCustomer.GetCustomerObjById(customersId);

            if (this.tbCustomer == null)
            {
                this.clsTbCustomer = new ClsTblCustomer();
                this.tbCustomer = this.clsTbCustomer.GetCustomerObjById(customersId);
            }
            
            supRefNoTextEdit.EditValue = this.tbCustomer?.custNo;
        }

        private void formAddSupplyVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name);

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
            double ecrAmount = ((spinEditTotalFinalDecimal.EditValue as double?) ?? 0) -
              Convert.ToDouble(t);
            this.tbSupplyMain.supBankAmount = ecrAmount;
            textEditPaidCreditCard.EditValue = ecrAmount;
        }

        private void SendECR(string ecrAmount)
        {
            string ecrPort = MySetting.DefaultSetting.ecrPort;
            byte[] MSIGD = Encoding.ASCII.GetBytes(this.supplyType == SupplyType.Sales ? "PUR" : "REF");
            byte[] ECRno = Encoding.ASCII.GetBytes("123");
            byte[] Rcptno = Encoding.ASCII.GetBytes(this.tbSupplyMain.supNo.ToString());
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
            bool isValid = !double.TryParse(textEditPaidCreditCard.Text, out double ecrAmount) || ecrAmount == 0 ? false : true;

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


        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            int id = db.tblSupplyMains.AsQueryable().Where(a => (a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12)
              && a.supBrnId == Session.CurBranch.brnId).Max(x => x.id);
            if (id > 0)
            {
                tblSupplyMain supplyMain = db.tblSupplyMains.AsQueryable().Where(a => (a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12)
              && a.supBrnId == Session.CurBranch.brnId && a.id == id).FirstOrDefault();
                var tbSupplySubList = db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == id).ToList();
                ClsStopWatch stopWatch2 = new ClsStopWatch();
                log.Debug("PrintReportClsPrintReportStart");
                flyDialog.WaitForm(this, 0);
                Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
                log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
                return;
            }
            flyDialog.WaitForm(this, 0);
        }

        private void checkEditTax_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotalFinal();
            MySetting.DefaultSetting.IsInvoiceRound = checkEdit1.Checked;
            MySetting.WriterSettingPublic();
        }

        private void DataLayoutControl1_GroupExpandChanged(object sender, LayoutGroupEventArgs e)
        {
            MySetting.GetPrivateSetting.supplySaleExpanded = layoutControlGrooupMain.Expanded;
            MySetting.WriterSettingXml();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);

            if (barEditItem1.EditValue is double noId && noId > 0)
            {
                //   var supplyMain = this.clsTbSupplyMain.GetSupplyMainListSale().FirstOrDefault(x => x.supNo == noId);
                var supplyMain = db.tblSupplyMains.AsQueryable().Where(a => (a.supStatus == 4 || a.supStatus == 8 || a.supStatus == 11 || a.supStatus == 12)
                   && a.supBrnId == Session.CurBranch.brnId && a.supNo == noId).ToList().FirstOrDefault();
                if (supplyMain != null)
                {
                    var tbSupplySubList = db.tblSupplySubs.AsQueryable().Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == supplyMain.id).ToList();
                    ClsStopWatch stopWatch2 = new ClsStopWatch();
                    log.Debug("PrintReportClsPrintReportStart");
                    flyDialog.WaitForm(this, 0);
                    Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur));
                    log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
                    return;
                }
            }
            flyDialog.WaitForm(this, 0);
        }

        private void btn_Calculator_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void formAddSupplyVoucher_Shown(object sender, EventArgs e)
        {
            if (this.supplyType == SupplyType.Sales)
                textEditBarcodeNo.Focus();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = this.Font;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MySetting.GetPrivateSetting.SystemFontSales = converter.ConvertToString(dialog.Font);
                    MySetting.WriterSettingXml();
                }
                SetFont();
            }
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void SetFontForItems(LayoutControlItem LayContItem)
        {
            LayContItem.AppearanceItemCaption.Font = LayContItem.AppearanceItemCaptionDisabled.Font =
            LayContItem.Owner.Appearance.Control.Font = fontConverter;
        }
        Font fontConverter => (Font)converter.ConvertFromString(MySetting.GetPrivateSetting.SystemFontSales);
        public void SetFont()
        {
            this.Font = fontConverter;
            ribbonControl1.Items.Where(x => x is BarItem).ToList().ForEach(x => x.ItemAppearance.SetFont(fontConverter));
            foreach (var item in ribbonControl1.RepositoryItems)
                if (item is RepositoryItem bbi)
                    bbi.Appearance.Font = fontConverter;
            repositoryItemLookUpEditStrId.Appearance.Font = fontConverter;
            dataLayoutControl1.Items.Where(x => x is LayoutControlItem).ToList().ForEach(x => SetFontForItems((LayoutControlItem)x));
            gridControl.Views.Where(item => item is GridView).ToList().ForEach(em =>
             ((GridView)em).Appearance.Row.Font = ((GridView)em).Appearance.HeaderPanel.Font = fontConverter);
            gridControlSrchPrd.Views.Where(item => item is GridView).ToList().ForEach(em =>
            ((GridView)em).Appearance.Row.Font = ((GridView)em).Appearance.HeaderPanel.Font = fontConverter);
            layoutControl1.Items.Where(x => x is LayoutControlItem).ToList().ForEach(x => SetFontForItems((LayoutControlItem)x));
            layoutControl2.Items.Where(x => x is LayoutControlItem).ToList().ForEach(x => SetFontForItems((LayoutControlItem)x));
            layoutControl3.Items.Where(x => x is LayoutControlItem).ToList().ForEach(x => SetFontForItems((LayoutControlItem)x));
        }
       
        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.SalesManagementAr));
            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyVocherEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                layoutControlItem20.Visibility = LayoutVisibility.Never;


            }
            else
            {
                // layoutControlItem20.Visibility = LayoutVisibility.Always;
            }
        }

        private void RepNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem19.Visibility = LayoutVisibility.Always;
        }

        private void txtdisCpon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (supDscntAmountTextEdit.Text == "") supDscntAmountTextEdit.Text = "0";
                //قسيمة خصم
                var offerTotalFatora = db.tblProductPriceOffers.ToList().FirstOrDefault(b => b.DiscountType == 3);

                if (offerTotalFatora.State != 2)
                {

                    var copun = db.CouponBarcodes.SingleOrDefault(w => w.BarCode == txtdisCpon.EditValue.ToString());
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

                    //double qui = 0;
                    //double des = 0;
                    double qu = Convert.ToDouble(labelTotalPriceDecimal.Text); // اجمالى سعر الفاتورة
                    double priceOffer = Convert.ToDouble(offerTotalFatora.Price);
                    switch (offerTotalFatora.State)
                    {

                        case 0: //عرض دائم

                            if (Convert.ToDouble(spinEditTotalFinalDecimal.Text) < priceOffer) //لو قيمة الفاتورة اكل من قيمة الكوبون
                            {
                                supDscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(spinEditTotalFinalDecimal.Text));
                                SupDscntAmountTextEdit_KeyUp(null, null);
                            }
                            else
                            {
                                supDscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(supDscntAmountTextEdit.Text) + Convert.ToDouble(offerTotalFatora.Price));
                                SupDscntAmountTextEdit_KeyUp(null, null);
                            }
                            break;
                        case 1: //العرض بين تاريخين


                            if (offerTotalFatora.ExpireDate > DateTime.Now)
                            {
                                if (Convert.ToDouble(spinEditTotalFinalDecimal.Text) < priceOffer) //لو قيمة الفاتورة اكل من قيمة الكوبون
                                {
                                    supDscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(spinEditTotalFinalDecimal.Text));
                                    SupDscntAmountTextEdit_KeyUp(null, null);
                                }
                                else
                                {

                                    supDscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(supDscntAmountTextEdit.Text) + Convert.ToDouble(offerTotalFatora.Price));
                                    SupDscntAmountTextEdit_KeyUp(null, null);
                                }


                            }
                            else
                            {
                                ClsXtraMssgBox.ShowWarning(MySetting.GetPrivateSetting.LangEng ? "Sorry!, This coupon has expired" : "لقد انتهت فترة صلاحية هذه القسيمة");
                            }


                            break;

                        default:
                            //des
                            break;
                    }
                }

                CalculateTotalFinal();

            }
        }

        private void EnglishLayout()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            layoutControl2.BeginUpdate();
            layoutControl2.RightToLeft = RightToLeft.No;
            layoutControl2.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl2.EndUpdate();

            radioGroupIsCash.EditWidth = 60;


            this.RightToLeft = RightToLeft.No;
        }

        private void bbiCustomerSLE_ShownEditor(object sender, ItemClickEventArgs e)
        {


        }

        private void bbiCustomerSLE_ShowingEditor(object sender, ItemCancelEventArgs e)
        {

        }
        void popsize()
        {
            int w = MySetting.GetPrivateSetting.bbiCustomerSLEH;
            int h = MySetting.GetPrivateSetting.bbiCustomerSLEW;
            repositoryItemSearchLookUpEditCustomerBbi.PopupFormMinSize = new Size(w, h);
            repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize = repositoryItemSearchLookUpEditCustomerBbi.PopupFormMinSize;
            repositoryItemSearchLookUpEditCustomerBbi.PopupWidthMode = PopupWidthMode.UseEditorWidth;
        }

        private void formAddSupplyVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void bbiCustomerSLE_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void FormAddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            MySetting.GetPrivateSetting.bbiCustomerSLEH= repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize.Width;
            MySetting.GetPrivateSetting.bbiCustomerSLEW= repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize.Height;
            MySetting.WriterSettingXml();
        }

        private void bbiCustomerSLE_EditValueChanged(object sender, EventArgs e)
        {
            // repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize = new Size(600, 600);
            // MySetting.DefaultSetting.bbiCustomerSLEH = size.Width;
            //MySetting.DefaultSetting.bbiCustomerSLEW = size.Height;
            //MySetting.DefaultSetting.bbiCustomerSLEH = repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize.Width ;
            //MySetting.DefaultSetting.bbiCustomerSLEW = repositoryItemSearchLookUpEditCustomerBbi.PopupFormSize.Height ;
            // MySetting.DefaultSetting.Save();
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

            try { _resource.ApplyResources(ribbonPage1, ribbonPage1.Name); } catch { }
            try { _resource.ApplyResources(ribbonPageGroup2, ribbonPageGroup2.Name, _ci); } catch { }
            try { _resource.ApplyResources(ribbonPageGroup3, ribbonPageGroup3.Name, _ci); } catch { }
            try { _resource.ApplyResources(ribbonPageGroupShortcuts, ribbonPageGroupShortcuts.Name, _ci); } catch { }
            try { _resource.ApplyResources(layoutControlGrooupMain, layoutControlGrooupMain.Name, _ci); } catch { }
            try { _resource.ApplyResources(layoutControlGroup5, layoutControlGroup5.Name, _ci); } catch { }
            try { _resource.ApplyResources(barButtonItem1, barButtonItem1.Name, _ci); } catch { }
            try { _resource.ApplyResources(barButtonItem2, barButtonItem2.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSaveAndNew, bbiSaveAndNew.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditQuantity, bbiEditQuantity.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditPrice, bbiEditPrice.Name, _ci); } catch { }
            try { _resource.ApplyResources(barCheckItem1, barCheckItem1.Name, _ci); } catch { }
            try { _resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci); } catch { }
            try { _resource.ApplyResources(labelItemsCount, labelItemsCount.Name, _ci); } catch { }

            try { repositoryItemRadioGroupIsCash.Items[0].Description = _resource.GetString("radioGroupIsCash.Properties.Items1"); } catch { }
            try { repositoryItemRadioGroupIsCash.Items[1].Description = _resource.GetString("radioGroupIsCash.Properties.Items2"); } catch { }
            try { supAccNoLookUpEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo"); } catch { }
            try { supAccNoLookUpEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName"); } catch { }
            //try { saleNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns0"); } catch { }
            //try { saleNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns1"); } catch { }
            //try { saleNoTextEdit.Properties.Columns[2].Caption = _resource.GetString("purchaseNoTextEdit.Properties.Columns2"); } catch { }
            try { repositoryItemLookUpEditMeasurment.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEditMeasurment.Columns1"); } catch { }
            try
            {
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Caption = _resource.GetString("colprdNo.Caption");
                repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Width = 150;
            }
            catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }

            this.Text = (this.supplyType == SupplyType.Sales) ? _resource.GetString("this.Sale") : _resource.GetString("this.SaleRtrn");

            try { barButtonItem3.Caption = _resource.GetString("barButtonItem3"); } catch { }
            try { bsiStrName.Caption = _resource.GetString("bsiStrName"); } catch { }
            try { ribbonPageGroupStrId.Text = _resource.GetString("ribbonPageGroupStrId"); } catch { }
            try { bsiCustomer.Caption = _resource.GetString("bsiCustomer"); } catch { }
            try { bbiCustomers.Caption = _resource.GetString("bbiCustomers"); } catch { }
            try { bbiRefreshCustomers.Caption = _resource.GetString("bbiRefreshCustomers"); } catch { }
            try { ribbonPageGroupCustomerInv.Text = _resource.GetString("ribbonPageGroupCustomerInv"); } catch { }
            try { ribbonPageGroupUpdateInvoice.Text = _resource.GetString("ribbonPageGroupUpdateInvoice"); } catch { }
            try { bbiUpdateInvvoice.Caption = _resource.GetString("bbiUpdateInvvoice"); } catch { }
            try { bbiNewInvoice.Caption = _resource.GetString("bbiNewInvoice"); } catch { }
            try { bbiPrdPrice.Caption = _resource.GetString("bbiPrdPrice"); } catch { }
            try { colprdQuanAvlb.Caption = _resource.GetString("colprdQuanAvlb"); } catch { }
            try { bbiReset.Caption = _resource.GetString("bbiReset"); } catch { }
            try { bsiPaidCreditShortcut.Caption = _resource.GetString("bsiPaidCreditShortcut"); } catch { }
            try { bbiSaveAndNewNoPrint.Caption = _resource.GetString("bbiSaveAndNewNoPrint"); } catch { }
            try { ribbonPageGroupRibbonView.Text = _resource.GetString("ribbonPageGroupRibbonView"); } catch { }
            try { layoutControlGrooupMain.Text = _resource.GetString("layoutControlGrooupMain"); } catch { }
            try { checkEdit1.Text = _resource.GetString("checkEdit1"); } catch { }
            try { ItemForBarcodeText.Text = _resource.GetString("ItemForBarcodeText"); } catch { }
            try { btnDeleteRow.Text = _resource.GetString("btnDeleteRow"); } catch { }
            try { simpleLabelItem1.Text = _resource.GetString("simpleLabelItem1"); } catch { }
            try { colCount.Caption = _resource.GetString("colCount"); } catch { }
            try { colsupDscntAmount.Caption = _resource.GetString("colsupDscntAmount"); } catch { }
            try { colsupDscntPercent.Caption = _resource.GetString("colsupDscntPercent"); } catch { }
            try { colFinalAmount.Caption = _resource.GetString("colFinalAmount"); } catch { }
            try { ItemForsupBankId.Text = _resource.GetString("ItemForsupBankId"); } catch { }
            try { layoutControlItem5.Text = _resource.GetString("layoutControlItem5"); } catch { }
            try { labelTotalPriceString.Text = _resource.GetString("labelTotalPriceString"); } catch { }
            try { labelTotalTaxString.Text = _resource.GetString("labelTotalTaxString"); } catch { }
            try { layoutControlItem4.Text = _resource.GetString("layoutControlItem4"); } catch { }
            try { itemForsupDscntAmount.Text = _resource.GetString("itemForsupDscntAmount"); } catch { }
            try { itemForsupDscntPercent.Text = _resource.GetString("itemForsupDscntPercent"); } catch { }
            try { ItemForPoNumber.Text = _resource.GetString("ItemForPoNumber"); } catch { }
            try { ItemForNotes.Text = _resource.GetString("ItemForNotes"); } catch { }
            try { btnECRsend.Text = _resource.GetString("btnECRsend"); } catch { }
            try { btnECRcancel.Text = _resource.GetString("btnECRcancel"); } catch { }
            try { simpleButton2.Text = _resource.GetString("simpleButton2"); } catch { }
            try { simpleButton1.Text = _resource.GetString("simpleButton1"); } catch { }
            try { layoutControlItem8.Text = _resource.GetString("layoutControlItem8"); } catch { }
            try { layoutControlItem7.Text = _resource.GetString("layoutControlItem7"); } catch { }
            try { layoutControlItem9.Text = _resource.GetString("layoutControlItem9"); } catch { }
        }

        Boolean test = true;

        private bool SaveDB()
        {

            // db.tblSupplyMains.Attach(tblSupplyMainBindingSource.Current as tblSupplyMain);


            return ClsSaveDB.Save((this.supplyType != SupplyType.SalesRtrn) ? db : db2, LogHelper.GetLogger());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            spinEdit1.EditValue = spinEditTotalFinalDecimal.Text.Split('.').FirstOrDefault();
            spinEdit1_KeyDown(spinEdit1, new KeyEventArgs(Keys.Enter));

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0) return;
            double total = 0;
            if (double.TryParse(spinEditTotalFinalDecimal.Text, out total))
            {
                double elFaka = 1 - (total - Math.Truncate(total));
                if (elFaka == 1) return;
                var row = gridView.GetRow(0) as TempSupplySub;
                if (row == null) return;
                double price = row.FinalAmount + elFaka;
                gridView.SetRowCellValue(0, colFinalAmount, price);
            }
        }

        private int supPrdNotoID(string supPrdNo)
        {
            var prid = db.tblProducts.SingleOrDefault(m => m.prdNo == supPrdNo);
            return (prid.id);
        }
        // private void ProductPriceOfferCal(double quni, double pric, string PrdNo, int RowHandle)
        private void ProductPriceOfferCal()
        {

            //حساب منتجات العرض
            var offerproPrice = db.tblProductPriceOffers.ToList();
            if (offerproPrice.Count() == 0) return;
            foreach (var item in offerproPrice) //كل عروض المنتجات
            {
                if (item.ExpireDate > DateTime.Now && item.State == 1 && item.DiscountType == 0) return;
                if (item.DiscountType == 0)
                {
                    var offerPrd = db.OffersProducts.ToList().Where(m => m.OffersID == item.id);  //منتجات العرض
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
                            supDscntAmountTextEdit.Text = Convert.ToString(Convert.ToDouble(item.Price));
                            SupDscntAmountTextEdit_KeyUp(null, null);
                        }
                    }
                }
            }

            //---------------------------------------------------------------------------------------------------------------------------


            //خصم على اجمالى فاتورة
            var offerTotalFatora = db.tblProductPriceOffers.ToList().FirstOrDefault(b => b.DiscountType == 1);
            if (offerTotalFatora != null)
            {
                if (offerTotalFatora.State != 2)
                {
                    Double qui = 0;
                    Double des = 0;
                    Double qu = Convert.ToDouble(labelTotalPriceDecimal.Text); // اجمالى سعر الفاتورة
                    if (offerTotalFatora.ExpireDate < DateTime.Now && offerTotalFatora.State == 1) return; //خلال فترة
                    if (qu >= offerTotalFatora.TotalFatora)
                    {
                        qui = Convert.ToDouble((qu / offerTotalFatora.TotalFatora)); //حد اجمالى الفاتورة
                        qui = Math.Truncate(qui);
                        des = Convert.ToDouble(qui * offerTotalFatora.Price); //قيمة الخصم
                        supDscntAmountTextEdit.Text = des.ToString();
                        SupDscntAmountTextEdit_KeyUp(null, null);

                    }
                }
            }

            //---------------------------------------------------------------------------------------------------------------------------

            //خصم على اجمالى فواتير العميل عن فترة
            if (bbiCustomerSLE.EditValue != null)
            {
                var offerCustmer = db.tblProductPriceOffers.ToList().FirstOrDefault(b => b.DiscountType == 2);  // && b.StartDate.Value.Date >= datestar && b.ExpireDate.Value.Date <= dateend);
                var CustmerId = db.tblCustomers.ToList().FirstOrDefault(b => b.id == Convert.ToInt32(bbiCustomerSLE.EditValue));
                var CustmerTotal = db.tblSupplyMains.ToList().Where(b => b.supRefNo == CustmerId.custNo.ToString() && b.supDate.Value.Date >= offerCustmer.CustmerStartDate.Value.Date && b.supDate.Value.Date <= offerCustmer.CustmerEndDate.Value.Date);
                Double totalprice = Convert.ToDouble(CustmerTotal.Sum(s => s.supTotal));
                if (offerCustmer != null)
                {
                    if (offerCustmer.State != 2 && totalprice != 0)
                    {
                        Double qui = 0;
                        Double des = 0;
                        Double qu = Convert.ToDouble(labelTotalPriceDecimal.Text); // اجمالى سعر الفاتورة
                        if (offerCustmer.ExpireDate < DateTime.Now && offerCustmer.State == 1) return; //خلال فترة
                        if (qu >= totalprice)
                        {
                            qui = Convert.ToDouble((qu / totalprice)); //حد اجمالى الفاتورة
                            qui = Math.Truncate(qui);
                            des = Convert.ToDouble(qui * offerCustmer.Price); //قيمة الخصم
                            supDscntAmountTextEdit.Text = des.ToString();
                            SupDscntAmountTextEdit_KeyUp(null, null);
                        }
                    }
                }
            }
            // CalculateTotalFinal();
        }
    }
}