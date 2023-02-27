using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AccountingMS
{
    
    public partial class formAddSupplyRcpt : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
           CultureInfo _ci;
        ComponentResourceManager _resource;
        accountingEntities db = new accountingEntities();
        accountingEntities db2 = new accountingEntities();
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        ClsTblCurrency curData = new ClsTblCurrency();
        List<ClsProductQuantList> prdQtyList = new List<ClsProductQuantList>();
        ClsTblAccount clsTbAccount;
        ClsTblBox clsTbBox;
        ClsSupply clsSupply;
        ClsTblSupplier clsTbSupplier;
        ClsTblStore clsTbStore;
        ClsTblGroupStr clsTbGroupStr;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTbBarcode;
        ClsPrdQuantityOperations clsPrdQuantityOpr;
        ClsPrdPriceQuanOperations clsPrdPriceQuanOpr;
        ClsTblSupplyMain clsTbSupplyMain;
        IClsTblSupplySub clsTbSupplySub;
        ClsSupplyTarhel clsSupplyTarhel;
        tblSupplyMain tbSupplyMain;
        List<tblSupplySub> tbSupplySubList;
        List<tblSupplySub> tbSupplySubListOld;
        tblPrdPriceMeasurment tbPrdMsur;
        tblProduct tbProduct;
        IDictionary<int, double> dicTotal;
        FlyoutDialog flyDialogOrders;

        private readonly UCpurchases _ucPurchases;
        private readonly formSupplyMain _formSupplyMain;
        public readonly SupplyType supplyType;
        private string accBoxName;
        private string barcodeNo;
        private long accNo;
        private string accName;
        private bool isNew, autoSupplyTarhel, gridValid = true;
        private byte isCash;
        private byte isCashOld;
        private int supMainId;
        private int supNo;
        private int supNoOld;
        private byte currency = 0;
        private byte status1, status2;
        private float tax;
        private bool hasTax, isPrdLastPrice;
        private int splId;
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private void formAddSupplyRcpt_Load(object sender, EventArgs e)
        {
            SetLayoutGroupExpandMode();
           

            if (!this.isNew) CalculateTotalAmount();
            ClsPath.ReLodeCustomContol(this.gridView, this.Name);
            SetBbiSupplierInvoice();
            textEditBarcodeNo.Focus();
        }

        public formAddSupplyRcpt(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj, UserControl userControl, SupplyType supplyType,
            formSupplyMain formSupplyMain = null, ClsTblSupplier clsTbSupplier = null, ClsTblGroupStr clsTbGroupStr = null,
            ClsTblProduct clsTbProduct = null, ClsTblPrdPriceMeasurment clsTbPrdMsur = null, ClsPrdQuantityOperations clsPrdQuantityOperations = null,
            ClsTblStore clsTbStore = null, ClsSupplyTarhel clsSupplyTarhel = null, IClsTblSupplySub clsTbSupplySub = null,
            ClsTblAccount clsTbAccount = null, ClsTblBarcode clsTbBarcode = null)
        {
            ClsStopWatch clsStopWatch = new ClsStopWatch();
            this.supplyType = supplyType;
            _formSupplyMain = formSupplyMain;
            _ucPurchases = userControl as UCpurchases;

            InitializeComponent();

            InitDefaultData();
            clsStopWatch.Elapsed("InitDefaultData");
            InitObjects();
            clsStopWatch.Elapsed("InitObjects");
            InitObjects(clsTbSupplier, clsTbStore, clsTbGroupStr, clsTbProduct, clsTbPrdMsur, clsPrdQuantityOperations,
                clsSupplyTarhel, clsTbSupplySub, clsTbAccount, clsTbBarcode);
            clsStopWatch.Elapsed("InitObjects");
            InitForm();
            clsStopWatch.Elapsed("InitForm");
            InitBindingSourceData();
            clsStopWatch.Elapsed("InitBindingSourceData");
            InitData(obj, subObj);
            clsStopWatch.Elapsed("InitData");
            GetResources();
            clsStopWatch.Elapsed("GetResources");
            InitEvents();
            clsStopWatch.Elapsed("InitEvents");
            InitLists();
            clsStopWatch.Elapsed("InitLists");

            repositoryItemSearchLookUpEditSupplierBbi.ButtonClick += RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick;
            gridView.OptionsBehavior.Editable = true;
            AllowGridColumns(colsupPrdBarcode);
            AllowGridColumns(colsupPrdNo);
            AllowGridColumns(colsupMsur);
        }
        private void AllowGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = true;
            column.OptionsColumn.AllowFocus = true;
            column.OptionsColumn.TabStop = true;
        }
        private void InitLists()
        {
            this.dicTotal = new Dictionary<int, double>();
        }

        private void RepositoryItemSearchLookUpEditCustomerBbi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (formAddSupplier frm = new formAddSupplier(null, null))
                {
                    flyDialog.WaitForm(this, 0);
                    frm.CloseAfterSave = true;
                    frm.ShowDialog();
                    SetBbiSupplierSLE();
                    bbiSupplierSLE.EditValue = frm.supplierId;
                }
            }
        }
        private void InitEvents()
        {
            if (_formSupplyMain != null) this.Text += " " + _formSupplyMain.GetDocumentNo;
            dataLayoutControl1.GroupExpandChanged += DataLayoutControl1_GroupExpandChanged;

            gridView.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.CellValueChanged += GridView_CellValueChanged;
            gridView.CustomRowCellEditForEditing += GridView_CustomRowCellEditForEditing;
            repositorySalePriceCalcEdit.EditValueChanged += repositorySalePriceCalcEdit_EditValueChanged;
            gridView.FocusedColumnChanged += GridView_FocusedColumnChanged;
            gridView.HiddenEditor += GridView_HiddenEditor;
            gridView.InitNewRow += GridView_InitNewRow;
            gridView.ShowCustomizationForm += GridView_ShowCustomizationForm;
            gridView.HideCustomizationForm += GridView_HideCustomizationForm;
            gridView.ValidatingEditor += GridView_ValidatingEditor;
            gridView.CustomUnboundColumnData += GridView_CustomUnboundColumnData;
            gridView.RowDeleted += GridView_RowDeleted;
            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;
            this.Shown += FormAddSupplyRcpt_Shown;
            repositoryItemLookUpEditMeasurment.EditValueChanged += RepositoryItemLookUpEditMeasurment_EditValueChanged;
            repositoryItemSearchLookUpEditPrdNo.EditValueChanged += RepositoryItemSearchLookUpEditPrdNo_EditValueChanged;
            repositoryItemLookUpEditStrId.EditValueChanged += RepositoryItemLookUpEditStrId_EditValueChanged;

            checkEditTax.EditValueChanged += CheckEditTax_EditValueChanged;
            checkEditPrdLastPrice.EditValueChanged += CheckEditPrdLastPrice_EditValueChanged;
            purchaseNoTextEdit.EditValueChanged += PurchaseNoTextEdit_EditValueChanged;
            supAccNoTextEdit.EditValueChanged += SupAccNoTextEdit_EditValueChanged;
            supSplNoTextEdit.EditValueChanged += SupSplNoTextEdit_EditValueChanged;
            supDscntPercentTextEdit.KeyUp += SupDscntPercentTextEdit_KeyUp;
            //supDscntAmountTextEdit.KeyUp += SupDscntAmountTextEdit_KeyUp;
            supDscntAmountTextEdit.EditValueChanged += SupDscntAmountTextEdit_EditValueChanged;
            supDscntAmountTextEdit.Enter += SupDscntAmountTextEdit_Enter;
            supDscntAmountTextEdit.Leave += SupDscntAmountTextEdit_Leave;
            supCurrTextEdit.EditValueChanged += SupCurrTextEdit_EditValueChanged;
            textEditPaidCash.EditValueChanging += TextEditPaidCash_EditValueChanging;
            textEditPaidCreditCard.EditValueChanging += TextEditPaidCreditCard_EditValueChanging;
            textEditBarcodeNo.KeyDown += TextEditBarcodeNo_KeyDown;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
        }

        private void repositorySalePriceCalcEdit_EditValueChanged(object sender, EventArgs e)
        {
            double spric = Convert.ToDouble(gridView.GetRowCellValue(gridView.FocusedRowHandle, colsupSalePrice));
            spric = (spric * 15) / 100;
            gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupPrdManufacture, spric);
        }

        private void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
                tblPrdPriceMeasurmentBindingSource.DataSource = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
        }

        private void FormAddSupplyRcpt_Shown(object sender, EventArgs e)
        {
            if (gridView.RowCount > 0)
                CalculateTotalAmount();
        }

        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == colCount.FieldName)
                if (e.IsGetData) e.Value = e.ListSourceRowIndex + 1;

            if (checkEditTax.Checked && e.Column.FieldName == colTotal.FieldName)
            {
                if (!e.IsGetData) return;
                if (!this.dicTotal.ContainsKey(Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colsupPrdId)))) return;

                e.Value = this.dicTotal[Convert.ToInt32(gridView.GetRowCellValue(e.ListSourceRowIndex, colsupPrdId))] +
                    (Convert.ToDouble(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupPrice)) *
                    Convert.ToDouble(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colsupQuanMain)));
            }
        }

        private void InitDefaultData()
        {
            this.tax = MySetting.GetPrivateSetting.taxDefault;
            this.autoSupplyTarhel = MySetting.DefaultSetting.autoSupplyTarhel;
            bbiStrIdSLE.EditValue = MySetting.DefaultSetting.defaultStrId;

            this.isPrdLastPrice = MySetting.GetPrivateSetting.supPrdLastPrice;
            checkEditPrdLastPrice.Checked = this.isPrdLastPrice;
        }
        private void InitData(tblSupplyMain obj, IEnumerable<tblSupplySub> subObj)
        {
            if (obj == null)
            {
                this.isNew = true;
                this.isCash = 1;

                if (this.supplyType != SupplyType.PurchaseRtrn) InitSupplyMainObj();
            }
            else
            {
                this.isNew = false;
                this.supMainId = obj.id;
                this.supNoOld = obj.supNo;
                this.accNo = Convert.ToInt64(obj.supAccNo);
                this.currency = Convert.ToByte(obj.supCurrency);
                this.isCash = Convert.ToByte(obj.supIsCash);
                this.isCashOld = this.isCash;
                this.hasTax = (obj.supTaxPrice > 0) ? true : false;
                this.tbSupplyMain = obj;
                SetAccountBinding(this.isCash);
                IsCash(this.isCash, false);

                tblSupplyMainsBindingSource.DataSource = this.tbSupplyMain;
                db.tblSupplyMains.Attach(tblSupplyMainsBindingSource.Current as tblSupplyMain);

                InitSupplySubGrid(subObj);
                radioGroupIsCash.EditValue = this.isCash;
                bbiStrIdSLE.EditValue = obj.supStrId;
                bbiSaveAndNew.Visibility = BarItemVisibility.Never;

                InitInvoiceObjects();
                DisableItems();
                SetGridProperties();
                SetRibbonButtonsVisisbility();
                //SetBbiSupplierInvoice();
                SetBbiSupplierSLE();
            }
        }

        private void InitSupplySubGrid(IEnumerable<tblSupplySub> subObj)
        {
            this.tbSupplySubListOld = subObj.Select(a => new tblSupplySub { supPrdId = a.supPrdId, supMsur = a.supMsur, supQuanMain = a.supQuanMain }).ToList();
            tblSupplySubBindingSource.DataSource = subObj;
            foreach (var tbSupplySub in subObj) db.tblSupplySubs.Attach(tbSupplySub);
            //foreach (var tbSupplySub in subObj)
            //    tblSupplySubBindingSource.Add(tbSupplySub as TempSupplySub);
        }

        private void InitObjects(ClsTblSupplier clsTbSupplier, ClsTblStore clsTbStore, ClsTblGroupStr clsTbGroupStr, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdPriceMeasurment, ClsPrdQuantityOperations clsPrdQuantityOperations, ClsSupplyTarhel clsSupplyTarhel, IClsTblSupplySub clsTbSupplySub, ClsTblAccount clsTbAccount, ClsTblBarcode clsTbBarcode)
        {
            this.clsTbAccount = clsTbAccount;
            this.clsTbSupplySub = clsTbSupplySub;
            this.clsTbSupplier = clsTbSupplier;
            this.clsTbStore = clsTbStore;
            this.clsTbGroupStr = clsTbGroupStr;
            this.clsTbProduct = clsTbProduct;
            this.clsTbPrdMsur = clsTbPrdPriceMeasurment;
            this.clsTbBarcode = clsTbBarcode;
            this.clsPrdQuantityOpr = clsPrdQuantityOperations;
            this.clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur);
            this.clsSupplyTarhel = clsSupplyTarhel;
            this.clsTbBox = new ClsTblBox();

        }

        private void InitBindingSourceData()
        {
            new ClsTblBank().InitBankLookupEdit(supBankIdTextEdit);
            this.clsTbBox.InitBoxLookupEditAccNoValMbr(supAccNoTextEdit);
            tblCurrencyBindingSource.DataSource = this.curData.GetCurrencyList;
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList.Where(x => x.strBrnId == Session.CurBranch.brnId);
            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList.Where(x => x.prdBrnId == Session.CurBranch.brnId);
            tblSupplierBindingSource.DataSource = this.clsTbSupplier.GetSuppliersList().Where(x => x.splBrnId == Session.CurBranch.brnId);
        }

        private void InitObjects()
        {
            this.clsSupply = new ClsSupply();
        }
        private void GridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SaveDetailInvoToXmlFile();
        }

        private readonly string folderPath = @$"{ClsDrive.Path}:\B-Tech\TempSupplyRcpt";
        private void InitSupplyMainObj(bool reset = false)
        {
            this.hasTax = true;
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
            tblSupplyMainsBindingSource.DataSource = this.tbSupplyMain;
            SetSupplyNo();
            if (supplyType == SupplyType.Purchase)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<TempSupplySub>));
                lis.Clear();
                if (File.Exists(folderPath + @$"\{this.supNo}.xml") && !reset)
                {
                    using (FileStream stream = File.OpenRead(folderPath + @$"\{this.supNo}.xml"))
                    {
                        if (stream.Length > 0)
                            lis = (List<TempSupplySub>)serializer.Deserialize(stream);
                        stream.Close();
                    }
                }
                lis = (List<TempSupplySub>)lis.Where(x => x.supNo == this.tbSupplyMain.supNo).ToList();
                tblSupplySubBindingSource.DataSource = lis;
            }
            SupAccNoTextEdit_EditValueChanged(supAccNoTextEdit, EventArgs.Empty);
        }
        List<TempSupplySub> lis = new List<TempSupplySub>();
        public void SaveDetailInvoToXmlFile()
        {
            if (supplyType != SupplyType.Purchase) return;
            if (!isNew) return;
            XmlSerializer serialiser = new XmlSerializer(typeof(List<TempSupplySub>));

            TextWriter Filestream = new StreamWriter(folderPath + @$"\{this.supNo}.xml");
            serialiser.Serialize(Filestream, lis);

            Filestream.Close();
        }
        private void InitForm()
        {
            switch (this.supplyType)
            {
                case SupplyType.Purchase:
                    PurchasesForm();
                    break;
                case SupplyType.PurchaseRtrn:
                    PurchasesForm();
                    PurchaseRtrn();
                    break;
                case SupplyType.DirectPurchaseRtrn:
                    PurchasesForm();
                    PurchaseDirectRtrn();
                    break;
            }
        }

        private void SetLayoutGroupExpandMode()
        {
            if (this.supplyType == SupplyType.PurchaseRtrn) return;
            layoutControlGroup3.Expanded = MySetting.GetPrivateSetting.supplyPurchaseExpanded;
        }

        private void SupAccNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue(this.accBoxName) == null) return;

            this.accNo = Convert.ToInt64(editor.GetColumnValue("boxAccNo"));

            this.accName = this.clsTbBox.GetBoxNameByAccNo(this.accNo);
            this.currency = Convert.ToByte(editor.GetColumnValue("boxCurrency"));
            this.tbSupplyMain.supAccNo = this.accNo;
            this.tbSupplyMain.supAccName = this.accName;
            this.tbSupplyMain.supCurrency = this.currency;

            if(this.supplyType != SupplyType.PurchaseRtrn)
            SetSupplyNo();
            SetBbiSupplierSLE();

            accNameTextEdit.EditValue = this.accName;
            supCurrTextEdit.EditValue = this.currency;
            bbiSupplierSLE.EditValue = null;
        }

        private void SetBbiSupplierSLE()
        {
            this.clsTbSupplier = new ClsTblSupplier();

            if (this.supplyType == SupplyType.PurchaseRtrn) return;
            repositoryItemSearchLookUpEditSupplierBbi.DataSource = this.clsTbSupplier.GetTblSupplierListByCurrencyId(this.currency);
            //supSplNoTextEdit.Properties.DataSource = repositoryItemSearchLookUpEditSupplierBbi.DataSource;
        }

        private void SetSupplyNo()
        {
            if (!this.isNew) return;

            this.supNo = this.clsSupply.StoreEntryNoBox(this.status1, this.status2);
            this.tbSupplyMain.supNo = this.supNo;
        }

        private void SupSplNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;
            if (editor.GetColumnValue("splName") == null) return;

            this.splId = Convert.ToInt32(editor.GetColumnValue("id"));
            this.accNo = Convert.ToInt32(editor.GetColumnValue("splAccNo"));
            this.accName = Convert.ToString(editor.GetColumnValue("splName"));
            this.currency = Convert.ToByte(editor.GetColumnValue("splCurrency"));
            this.tbSupplyMain.supAccNo = this.accNo;
            this.tbSupplyMain.supAccName = this.accName;
            this.tbSupplyMain.supCurrency = this.currency;

            supSplNameTextEdit.EditValue = this.accName;
            supCurrTextEdit.EditValue = this.currency;
            SetSupplyNo();
        }

        private void SupCurrTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (((editor.EditValue as byte?)??0) == 0) return;

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

        private void PurchaseNoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
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
            tblSupplyMainsBindingSource.DataSource = this.tbSupplyMain;
            gridView.OptionsBehavior.Editable = false;
            this.tbSupplyMain.supNo = this.supNo;
            GetSupplySubData();
            CalculateTotalAmount();
            SetBbiSupplierInvoice();
        }

        private void GetSupplySubData()
        {
            IEnumerable<tblSupplySub> tbSupSubList = this.clsTbSupplySub.GetSupplySubListBySupId(this.supMainId);

            foreach (var tbSupplySub in tbSupSubList)
            {
                tbSupplySub.supCredit = tbSupplySub.supDebit;
                tbSupplySub.supDebit = 0;
                if (tbSupplySub.supCurrency != 1)
                {
                    tbSupplySub.supCredit = Convert.ToDouble(tbSupplySub.supDebitFrgn);
                    tbSupplySub.supDebitFrgn = 0;
                }
            }
            tblSupplySubBindingSource.DataSource = tbSupSubList;
        }

        private void TextEditPaidCash_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToDouble(e.NewValue) == 0) return;

            double cashAmount = Convert.ToDouble(e.NewValue), creditAmount = (!string.IsNullOrEmpty(textEditPaidCreditCard.Text)) ? Convert.ToDouble(textEditPaidCreditCard.EditValue) : 0;
            labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount:n2}";
            labelRemaingAmountDecimal.Text = $"{(cashAmount + creditAmount) - double.Parse(labelTotalFinalDecimal.Text)}";
        }

        private void TextEditPaidCreditCard_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            SetSupBankIdVale(Convert.ToDouble(e.NewValue));
            if (Convert.ToDouble(e.NewValue) == 0) return;
            if (Convert.ToDouble(e.NewValue) > (double)999999999999999999.99)
            {
                e.Cancel = true;
                return;
            }
            double cashAmount = Convert.ToDouble(textEditPaidCash.EditValue), creditAmount = Convert.ToDouble(e.NewValue);
            labelPaidAmountDecimal.Text = $"{cashAmount + creditAmount:n2}";
            labelRemaingAmountDecimal.Text = $"{(cashAmount + creditAmount) - double.Parse(labelTotalFinalDecimal.Text)}";
        }

        private void SupDscntPercentTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!ValidateDiscountAmount(supDscntPercentTextEdit.Text, out double discountPercent)) return;

            CalculateDiscountAmount(Convert.ToDouble(supDscntPercentTextEdit.Value));
            CalculateTotalFinal();
        }

        bool IsDescountValueFocesed;
        private void SupDscntAmountTextEdit_Enter(object sender, EventArgs e)
        {
            IsDescountValueFocesed = true;
        }

        private void SupDscntAmountTextEdit_Leave(object sender, EventArgs e)
        {
            IsDescountValueFocesed = false;
        }

        private void SupDscntAmountTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (IsDescountValueFocesed == false) return;
            if (!ValidateDiscountAmount(supDscntAmountTextEdit.Text, out double discountAmount)) return;
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;
            double discountPercent = ((discountAmount / totalAmount) * 100);
            supDscntPercentTextEdit.EditValue = discountPercent;
            CalculateDiscountAmount(discountPercent);
            CalculateTotalFinal();
        }

        private void SupDscntAmountTextEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateDiscountAmount(supDscntAmountTextEdit.Text, out double discountAmount)) return;
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount) || totalAmount == 0) return;

            double discountPercent = Math.Round((discountAmount / totalAmount) * 100, 2, MidpointRounding.AwayFromZero);

            supDscntPercentTextEdit.EditValue = discountPercent;
            CalculateDiscountAmount(discountPercent);
            CalculateTotalFinal();
        }

        private bool ValidateDiscountAmount(string textEdit, out double discount)
        {
            if (double.TryParse(textEdit, out discount) && discount > 0) return true;

            ClearDiscountValues();
            CalculateTotalFinal();
            return false;
        }

        private void CalculateDiscountAmount(double discountPercent)
        {
            if (discountPercent == 0) return;
            double discountAmount = Math.Round(double.Parse(labelTotalPriceDecimal.Text) * (discountPercent / 100), 2, MidpointRounding.AwayFromZero);
            double.TryParse(labelTotalPriceDecimal.Text, out double totalPrice);

            supDscntAmountTextEdit.EditValue = discountAmount;
            labelDiscountDecimal.Text = $"{discountAmount:n2}";
            labelTotalDecimal.Text = $"{totalPrice - discountAmount:n2}";
            SetColumnDiscountPercent(discountPercent);
        }
       
        private void CalculateRowTaxDiscount(int rowHandle, double dscntAmount)
        {
            if (!checkEditTax.Checked)
            {
                gridView.SetRowCellValue(rowHandle, colsupTaxPrice, null);
                return;
            }
            double taxPercent = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupTaxPercent));
            var supPrice = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupPrice)) *
                     Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));
            double tax = (supPrice * taxPercent / 100);
            var nta = (supPrice - dscntAmount) * (taxPercent / 100);
            var taxPrice = MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : tax;
            gridView.SetRowCellValue(rowHandle, colsupTaxPrice, taxPrice);
            gridView.SetRowCellValue(rowHandle, colsupTotalPrice, supPrice - dscntAmount + taxPrice);
        }
        private void CalculateTotalFinal()
        {
            double.TryParse(labelTotalDecimal.Text, out double totalAmount);
            double totalTax = CalculateTotalTax();
            double totalFinal = totalAmount + totalTax; ;

            labelTotalFinalDecimal.Text = $"{totalFinal:n2}";
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
                    salePrice = Convert.ToDouble(gridView.GetRowCellValue(i, colsupPrice));
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
            
            if (!double.TryParse(labelTotalPriceDecimal.Text, out double totalPrice)) return;

            labelDiscountDecimal.Text = $"{discountAmount:n2}";
            labelTotalDecimal.Text = $"{(totalPrice - discountAmount):n2}";
        }
        private double CalculateTotalTax()
        {
            double totalTax = 0;

            if (this.hasTax) for (short i = 0; i < gridView.DataRowCount; i++)
                    if (gridView.GetRowCellValue(i, colsupTaxPrice) != null)
                        totalTax += double.Parse(gridView.GetRowCellValue(i, colsupTaxPrice).ToString());

            labelTotalTaxDecimal.Text = $"{totalTax:n2}";
            return totalTax;
        }

        private void ClearDiscountValues()
        {
            SetColumnDiscountPercent(null);
            supDscntAmountTextEdit.Text = null;
            supDscntPercentTextEdit.EditValue = null;
            labelDiscountDecimal.Text = "0.00";
            labelTotalDecimal.Text = labelTotalPriceDecimal.Text;
        }

        private void SetColumnDiscountPercent(object discountPercent)
        {
            for (short i = 0; i < gridView.DataRowCount; i++)
                gridView.SetRowCellValue(i, colsupDscntPercent, discountPercent);

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                var dpr = Convert.ToDouble(gridView.GetRowCellValue(i, colsupDscntPercent));
                var tp = Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPercent));
                var ta = Convert.ToDouble(gridView.GetRowCellValue(i, colsupPrice)) * Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                var ntac = (ta * tp / 100);
                var nta = ntac - (ntac * dpr / 100);
                gridView.SetRowCellValue(i, colsupTaxPrice, MySetting.DefaultSetting.CalcTaxAfterDiscount ? nta : ntac);
            }
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

        private void CheckEditPrdLastPrice_EditValueChanged(object sender, EventArgs e)
        {
            this.isPrdLastPrice = checkEditPrdLastPrice.Checked;
            MySetting.GetPrivateSetting.supPrdLastPrice = this.isPrdLastPrice;
            MySetting.WriterSettingXml();
        }

        private void CheckEditTax_EditValueChanged(object sender, EventArgs e)
        {
            this.hasTax = (checkEditTax.Checked) ? true : false;
            HasTax();
        }

        private void repositoryItemRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            this.isCash = (byte)((RadioGroup)sender).EditValue;
            this.tbSupplyMain.supIsCash = this.isCash;

            IsCash(this.isCash);
            SetAccountBinding(this.isCash);
            ClearAccountFileds();
            SetSupplierRibbonGroupVisibility((this.isCash == 1) ? true : false);
        }

        private void SetSupplierRibbonGroupVisibility(bool isVisible)
        {
            ribbonPageGroupSupplier.Visible = isVisible;
        }

        private void SetAccountBinding(byte isCash)
        {
            supAccNoTextEdit.DataBindings.Clear();
            accNameTextEdit.DataBindings.Clear();
            supSplNoTextEdit.DataBindings.Clear();
            supSplNameTextEdit.DataBindings.Clear();

            if (isCash == 1)
            {
                supAccNoTextEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainsBindingSource, "supAccNo", true, DataSourceUpdateMode.OnPropertyChanged));
                accNameTextEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainsBindingSource, "supAccName", true, DataSourceUpdateMode.OnPropertyChanged));

            }
            else
            {
                supSplNoTextEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainsBindingSource, "supAccNo", true, DataSourceUpdateMode.OnPropertyChanged));
                supSplNameTextEdit.DataBindings.Add(new Binding("EditValue", tblSupplyMainsBindingSource, "supAccName", true, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (textEditBarcodeNo.ContainsFocus) InitRowData(e);
        }

        private void InitRowData(InitNewRowEventArgs e)
        {
            gridView.SetRowCellValue(e.RowHandle, colsupPrdBarcode, this.barcodeNo);
            gridView.SetRowCellValue(e.RowHandle, colsupMsur, this.tbPrdMsur.ppmId);
            gridView.SetRowCellValue(e.RowHandle, colsupNo, this.supNo);
            gridView.SetRowCellValue(e.RowHandle, colsupPrice, GetPrdPrice(this.tbPrdMsur));
            gridView.SetRowCellValue(e.RowHandle, colsupPrdId, this.tbProduct.id);
            gridView.SetRowCellValue(e.RowHandle, colsupPrdNo, this.tbProduct.prdNo);
            gridView.SetRowCellValue(e.RowHandle, colsupPrdName, this.tbProduct.prdName);
            gridView.SetRowCellValue(e.RowHandle, colsupAccNo, this.tbProduct.prdGrpNo);
            gridView.SetRowCellValue(e.RowHandle, colsupCurrency, clsTbGroupStr.GetGroupCurrencyById(this.tbProduct.prdGrpNo));
            gridView.SetRowCellValue(e.RowHandle, colsupQuanMain, 1);
            SetColTaxPercent(e.RowHandle);
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


        private void SetColTaxPercent(int rowIndex)
        {
            if (!checkEditTax.Checked) return;
            if (this.tbProduct.prdPurchaseTax) return;
            gridView.SetRowCellValue(rowIndex, colsupTaxPercent, this.tax);
        }

        private void GridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn == colsupMsur)
                tblPrdPriceMeasurmentBindingSource.DataSource = clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
        }

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "supMsur")
                e.RepositoryItem = repositoryItemLookUpEditMeasurment;
        }

        private void GridView_HiddenEditor(object sender, EventArgs e)
        {
            if (gridView.FocusedColumn == colsupQuanMain || gridView.FocusedColumn == colsupPrice)
            {
                CalculateTax(gridView.FocusedRowHandle);
                CalculateTotalAmount();
            }
        }
        public class TempSupplySub : tblSupplySub
        {
            public double NetAmount
            {

                get
                {
                    double q = supQuanMain.HasValue ? (double)supQuanMain.Value : 0;
                    double p = supPrice.HasValue ? supPrice.Value : 0;
                    return q * p;
                }
                set
                {
                    double q = supQuanMain.HasValue ? (double)supQuanMain.Value : 0;
                    if (q > 0)
                    {
                        supPrice = value / q;
                    }
                }
            }

            public double FinalAmount
            {
                get
                {
                    double d = supDscntAmount.HasValue ? supDscntAmount.Value : 0;
                    double t = supTaxPrice.HasValue ? supTaxPrice.Value : 0;
                    double price = supPrice.HasValue ? supPrice.Value : 0;
                    double q = supQuanMain.HasValue ? Convert.ToDouble(supQuanMain.Value) : 0;
                    //double q = supQuanMain.HasValue ? (double)supQuanMain.Value : 0;
                    return Math.Round(((price * q)-d) + t, 2);
                }
                set
                {
                    if (supTaxPrice > 0)
                    {
                        double price = supPrice.HasValue ? supPrice.Value : 0;
                        if (price == 0) return;
                        double q = supQuanMain.HasValue ? (double)supQuanMain.Value : 0;

                        double tax = supTaxPercent.HasValue ? supTaxPercent.Value : 0;

                        var discount = 1 - ((value / q) / (price * (1 + (tax / 100))));

                        supPrice = (price - (price * discount));
                    }
                }
            }
        }
        private void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName == "NetAmount" || e.Column.FieldName == "FinalAmount")
                GridView_CellValueChanging(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, colsupQuanMain, gridView.GetFocusedRowCellValue(colsupQuanMain)));

            else if (e.Column.FieldName == colMeter.FieldName)
            {
                double? meter = (double?)gridView.GetRowCellValue(e.RowHandle, colMeter);

                if (meter != null)
                {
                    if(this.tbPrdMsur==null)

                        this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId))).FirstOrDefault(c=>c.ppmId== Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupMsur)));

                    if (this.tbPrdMsur.ppmConversion != null)
                    {
                        var currentQte = Math.Ceiling(meter / this.tbPrdMsur.ppmConversion ?? 0);
                        var currentPacks = (int?)gridView.GetRowCellValue(e.RowHandle, col_SubNoPacks); ;

                        var lst = this.clsTbPrdMsur.GetPrdPriceMsurListByPrdId(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));
                        if (lst.Any())
                        {

                            //gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupQuanMain, currentQte);
                            var factor = this.tbPrdMsur.ppmConversion ?? 0;
                            //var mainUnit = lst.FirstOrDefault(c => c.ppmConversion == null);

                            if (currentPacks != currentQte)
                            {
                                gridView.SetRowCellValue(gridView.FocusedRowHandle, colsupQuanMain, currentQte * factor);
                                GridView_CellValueChanging(sender, new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(gridView.FocusedRowHandle, colsupQuanMain, currentQte * factor));

                                gridView.SetFocusedRowCellValue(col_SubNoPacks, currentQte);
                                gridView.UpdateCurrentRow();
                                gridView.SetFocusedRowCellValue(colMeter, currentQte * factor);
                            }

                        }





                        //gridView.UpdateCurrentRow();
                    }
                }
            }
            SaveDetailInvoToXmlFile();
        }
        private void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double tax, price, priceTax, quantity;

            if (e.Column.FieldName == "supQuanMain" && double.TryParse(e.Value.ToString(), out quantity))
            {
                //var prdQuanAvlb = GetQuanAvlb(Convert.ToInt32(gridView.GetFocusedRowCellValue(colsupPrdId)));

                //if (quantity > prdQuanAvlb)
                //{
                //    XtraMessageBox.Show(string.Format(_resource.GetString("CheckPrdQtyMssg"), prdQuanAvlb), caption: "", buttons: System.Windows.Forms.MessageBoxButtons.OK);
                //    gridView.DeleteSelectedRows();
                //    return;
                //}
                
                price = Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupPrice));
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

                    double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupPrice));
                    double dscntAmount = Math.Round(salePrice * (dscntPercent / 100), 2, MidpointRounding.AwayFromZero);
                    dscntAmount *= Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupQuanMain));

                    gridView.SetRowCellValue(e.RowHandle, colsupDscntAmount, dscntAmount);

                    CalculateRowTaxDiscount(e.RowHandle, dscntAmount);
                    CalculateGridDiscount(e.RowHandle, dscntAmount);
                    CalculateTotalFinal();


                }
            }
            else if (e.Column.FieldName == "supPrice")
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

                double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupPrice));
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

                double salePrice = Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupPrice));
                salePrice *= Convert.ToDouble(gridView.GetRowCellValue(e.RowHandle, colsupQuanMain));

                double dscntPercent = (dscntAmount / salePrice) * 100;
                gridView.SetRowCellValue(e.RowHandle, colsupDscntPercent, dscntPercent);

                CalculateRowTaxDiscount(e.RowHandle, dscntAmount);
                CalculateGridDiscount(e.RowHandle, dscntAmount);
                CalculateTotalFinal();
            }
        }
        
        private void GridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view?.FocusedColumn == colsupPrice)
            {
                if (Convert.ToDouble(e.Value) > (double)999999999999999999.99)
                {
                    this.gridValid = false;
                    e.Valid = false;
                    e.ErrorText = (!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value";
                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "عذرا المبلغ الذي ادخلته غير صحيح" : "Sorry wrong input value");
                }
                else this.gridValid = true;
            }
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "supMsur")
                e.DisplayText = clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(e.Value));
            else if (e.Column.FieldName == "supCurrency")
                e.DisplayText = curData.GetCurrencyNameById(Convert.ToByte(e.Value));
        }

        private void RepositoryItemLookUpEditStrId_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbSupplyMain.supStrId = Convert.ToInt16(editor.GetColumnValue("id"));
        }
       
        private void RepositoryItemSearchLookUpEditPrdNo_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            if (editor?.EditValue == null) return;

            int prdId = Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("id"));
            this.tbProduct = editor.GetSelectedDataRow() as tblProduct;

            gridView.SetFocusedRowCellValue(colsupPrdNo, editor.Properties.View.GetFocusedRowCellValue("prdNo").ToString());
            gridView.SetFocusedRowCellValue(colsupPrdName, editor.Properties.View.GetFocusedRowCellValue("prdName").ToString());
            gridView.SetFocusedRowCellValue(colsupAccNo, Convert.ToInt64(editor.Properties.View.GetFocusedRowCellValue("prdGrpNo")));
            gridView.SetFocusedRowCellValue(colsupCurrency, clsTbGroupStr.GetGroupCurrencyById(Convert.ToInt32(editor.Properties.View.GetFocusedRowCellValue("prdGrpNo"))));
            gridView.SetFocusedRowCellValue(colsupPrdId, prdId);
            gridView.SetFocusedRowCellValue(colsupNo, this.supNo);
        
            gridView.SetFocusedRowCellValue(colsupQuanMain, 1);
            gridView.UpdateCurrentRow();

           if(this.isNew == true) GetDefaultPrdPriceMsur(prdId);
            SetColTaxPercent(gridView.FocusedRowHandle);
            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            SetDicTotal(prdId);
        }

        private void RepositoryItemLookUpEditMeasurment_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit editor = sender as LookUpEdit;
            if (editor?.EditValue == null) return;

            this.tbPrdMsur = editor.GetSelectedDataRow() as tblPrdPriceMeasurment;
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);
            int ppmId = Convert.ToInt32(editor.GetColumnValue("ppmId"));
            gridView.SetFocusedRowCellValue(colsupMsur, ppmId);
            gridView.SetFocusedRowCellValue(colsupPrdBarcode, tbBarcode?.brcNo);
            //gridView.SetFocusedRowCellValue(colsupPrdBarcode, Convert.ToString(editor.GetColumnValue("ppmBarcode")));
            gridView.SetFocusedRowCellValue(colsupSalePrice, clsTbPrdMsur.GetPrdPriceMsurSalePrice(ppmId));   //سعر المنتج
            gridView.SetFocusedRowCellValue(colsupPrice, GetPrdPrice(this.tbPrdMsur));
            gridView.UpdateCurrentRow();

            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
        }

        private void RepositoryItemCalcEditPrice_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (Convert.ToDouble(e.Value) > (double)999999999999999999.99) e.AcceptValue = false;
        }

        private void TextEditBarcodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(textEditBarcodeNo.Text)) return;
            if (e.KeyCode == Keys.Enter) GetPrdBarcodeData(textEditBarcodeNo.Text);
        }

        private void SetDicTotal(int prdId)
        {
            if (this.dicTotal.ContainsKey(prdId)) return;
            this.dicTotal.Add(prdId, 0);
        }

        private void UpdateColTotal()
        {
            //gridView.SetRowCellValue(gridView.FocusedRowHandle, colTotal, 1);
        }

        private bool ValidateBarcodeNo(string barcode, out int prdMsurId)
        {
            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByNo(barcode);
            bool isValid = tbBarcode != null ? true : false;
            prdMsurId = tbBarcode != null ? tbBarcode.brcPrdMsurId : 0;

            if (!isValid)
            {
                XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBarcodeNoText();
            }

            return isValid;
        }

        private void GetPrdBarcodeData(string barcode)
        {
            if (!ValidateBarcodeNo(barcode, out int prdMsurId)) return;
            this.tbPrdMsur = this.clsTbPrdMsur.GetPrdPriceMsurById(prdMsurId);
            if (this.tbPrdMsur == null)
            {
                XtraMessageBox.Show(_resource.GetString("PrdNoFoundMssg"), "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBarcodeNoText();
                return;
            }
            this.tbProduct = clsTbProduct.GetPrdObjByPrdId(this.tbPrdMsur.ppmPrdId);
            if (CheckProductGrid(barcode)) return;
            this.barcodeNo = barcode;

            SystemSounds.Asterisk.Play();

            gridView.AddNewRow();
            //gridView.SetFocusedRowCellValue(colsupSalePrice, supSalPri(tbProduct.id));
            gridView.SetFocusedRowCellValue(colsupSalePrice, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax,this.tbPrdMsur));
            gridView.UpdateCurrentRow();

            ClearBarcodeNoText();
            CalculateTax(gridView.FocusedRowHandle);
            CalculateTotalRow(gridView.FocusedRowHandle);
            CalculateTotalAmount();
            SetDicTotal(this.tbProduct.id);
            gridView.FocusedColumn = colsupQuanMain;
        }

        private void ClearBarcodeNoText()
        {
            textEditBarcodeNo.EditValue = null;

        }

        private bool CheckProductGrid(string barcode)
        {
            bool isFound = false;

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                if (gridView.GetRowCellValue(i, colsupPrdBarcode) != null && gridView.GetRowCellValue(i, colsupPrdBarcode).ToString() == barcode)
                {
                    double quantity = Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                    gridView.SetRowCellValue(i, colsupQuanMain, ++quantity);

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

        private void GetDefaultPrdPriceMsur(int prdId)
        {
            this.tbPrdMsur = clsTbPrdMsur.GetPrdPriceMsurDefaultRowByPrdId(prdId);

            var tbBarcode = this.clsTbBarcode.GetBarcodeObjByPrdMsurId(this.tbPrdMsur.ppmId);

            if (tbPrdMsur != null && tbBarcode != null)
            {
                //gridView.SetFocusedRowCellValue(colsupPrdBarcode, tbPrdMsur.ppmBarcode1);
                gridView.SetFocusedRowCellValue(colsupPrdBarcode, tbBarcode.brcNo);
                gridView.SetFocusedRowCellValue(colsupMsur, tbPrdMsur.ppmId);
                gridView.SetFocusedRowCellValue(colsupPrice, GetPrdPrice(this.tbPrdMsur));
                gridView.SetFocusedRowCellValue(colsupSalePrice, clsTbPrdMsur.GetppmSalePrice(this.tbProduct.prdPriceTax, this.tbPrdMsur));
            }
        }

       
        private void CalculateTax(int rowHandle)
        {
            if (!checkEditTax.Checked || rowHandle < 0) return;
            if (this.tbProduct == null)
            {
                var currSup = tblSupplySubBindingSource.Current;
                this.tbProduct = this.clsTbProduct.GetPrdObjByPrdId(Convert.ToInt32(currSup.GetType().GetProperty("supPrdId").GetValue(currSup)));
            }
            if (this.tbProduct.prdPurchaseTax) return;
            double price = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupPrice))
                * Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));
            double DiscountPricent = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupDscntPercent));
            double taxPricent = (Convert.ToDouble(this.tax) / 100);
            double taxBeforDisPrice = price * taxPricent;
            double priceAfterDiscount = price - (DiscountPricent * price / 100);
            double priceTax = MySetting.DefaultSetting.CalcTaxAfterDiscount ?
                ((checkEditTax.Checked && price != 0) ? (priceAfterDiscount * taxPricent) : 0) : taxBeforDisPrice;
            gridView.SetRowCellValue(rowHandle, colsupTaxPrice, priceTax);
        }

        private void CalculateTotalRow(int rowHandle)
        {
            double price = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupPrice)), taxPrice = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupTaxPrice));
            double quantity = Convert.ToDouble(gridView.GetRowCellValue(rowHandle, colsupQuanMain));

            gridView.SetRowCellValue(rowHandle, colsupTotalPrice, Math.Round((price * quantity), 2, MidpointRounding.AwayFromZero) + taxPrice);
        }

        private void CalculateTotalAmount()
        {
            double totalPrdPrice = 0, totalTaxAmount = 0;

            labelItemsCount.Text = _resource.GetString("prdCount") + gridView.DataRowCount;
            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                totalPrdPrice += Convert.ToDouble(gridView.GetRowCellValue(i, colsupPrice)) *
                    Convert.ToDouble(gridView.GetRowCellValue(i, colsupQuanMain));
                totalTaxAmount += Convert.ToDouble(gridView.GetRowCellValue(i, colsupTaxPrice));
            }

            SetTotalLabels(totalPrdPrice, totalTaxAmount);
            if (!ValidateTextEditNullOrZero(supDscntPercentTextEdit))
                CalculateDiscountAmount(Convert.ToDouble(supDscntPercentTextEdit.EditValue));
            CalculateTotalFinal();
        }

        private void SetTotalLabels(double totalPrdPrice, double totalTaxAmount)
        {
            labelTotalTaxDecimal.Text = $"{((totalTaxAmount > 0) ? totalTaxAmount : 0):n2}";
            labelTotalPriceDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0):n2}";
            labelTotalDecimal.Text = $"{((totalPrdPrice > 0) ? totalPrdPrice : 0):n2}";
        }

        private void HasTax()
        {
            if (this.hasTax)
            {
                colsupTaxPercent.Visible = true;
                colsupTaxPrice.Visible = true;
                colsupTaxPercent.VisibleIndex = 7;
                colsupTaxPrice.VisibleIndex = 8;
            }
            else
            {
                colsupTaxPercent.Visible = false;
                colsupTaxPrice.Visible = false;
            }
        }

        private void IsCash(byte val, bool isSetSupNo = true)
        {
            if (val == 1)
            {
                ItemForsupAccNo.Visibility = LayoutVisibility.Always;
                ItemForsupAccName.Visibility = LayoutVisibility.Always;
                layoutControlItem1.Visibility = LayoutVisibility.Never;
                layoutControlItem2.Visibility = LayoutVisibility.Never;
                if (this.isCashOld == 1) SetOldSupNo();
            }
            if (val == 2)
            {
                ItemForsupAccNo.Visibility = LayoutVisibility.Never;
                ItemForsupAccName.Visibility = LayoutVisibility.Never;
                layoutControlItem1.Visibility = LayoutVisibility.Always;
                layoutControlItem2.Visibility = LayoutVisibility.Always;
                if (isSetSupNo&& this.isCashOld == 2)
                        SetOldSupNo();
                layoutControlGroup3.Expanded = true;
            }
        }

        private void SetOldSupNo()
        {
            this.supNo = this.supNoOld;
            this.tbSupplyMain.supNo = this.supNo;
            supNoTextEdit.EditValue = this.supNo;
        }

        private void ClearAccountFileds()
        {
            this.tbSupplyMain.supAccNo = null;
            this.tbSupplyMain.supAccName = null;
            this.tbSupplyMain.supCurrency = null;
            this.tbSupplyMain.supCurrencyChng = null;
            supAccNoTextEdit.EditValue = null;
            accNameTextEdit.EditValue = null;
            supSplNoTextEdit.EditValue = null;
            supSplNameTextEdit.EditValue = null;
            supCurrTextEdit.EditValue = null;
            supCurrencyChngTextEdit.EditValue = null;
        }

        private void PurchasesForm()
        {
            //lq.BoxNoAccNoValMbr(supAccNoTextEdit);

            this.status1 = 3;
            this.status2 = 7;
            this.accBoxName = "boxName";
            this.Text = "فاتورة مشتريات";
            ItemForsupNo.Text = "رقم الفاتورة";
            ItemForsupAccNo.Text = "رقم الصندوق";
            ItemForsupAccName.Text = "إسم الصندوق";

            if (!this.isNew) InitInvoiceObjects();
            SetAppearancePurchaseRtrn();
        }

        private void PurchaseRtrn()
        {
            InitSupplyObject();
            InitInvoiceObjects();
            InitSupplyTarhelObj();

            tblSupplyMainBindingSourceEditor.DataSource = this.clsTbSupplyMain.GetSupplyMainListPhasedPurchase();
            repositoryItemSearchLookUpEditSupplierBbi.DataSource = this.clsTbSupplier.GetSuppliersList();
            gridView.OptionsSelection.MultiSelect = true;

            bbiOrders.Visibility = BarItemVisibility.Never;

            SetPurchaseRtrnTextNdStatus();
            SetPurchaseRtrnRibbonItems();
            SetGridProperties();
            SetLayoutControl();
            SetAppearancePurchaseRtrn();
        }
        private void SetAppearancePurchaseRtrn()
        {
            foreach (GridColumn item in gridView.Columns)
                item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            //gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.SeaGreen;
            textEditBarcodeNo.BackColor = System.Drawing.Color.DarkOrange;
        }
        private void SetAppearancePurchase()
        {
            foreach (GridColumn item in gridView.Columns)
                item.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            //gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
        }

        private void PurchaseDirectRtrn()
        {
            InitInvoiceObjects();
            InitSupplyTarhelObj();
            SetPurchaseRtrnTextNdStatus();
            SetPurchaseDirectRtrnRibbonItems();

            this.clsTbSupplySub = new ClsTblSupplySub(SupplyType.Purchase, SupplyType.PurchaseRtrn);

            bbiOrders.Visibility = BarItemVisibility.Never;
        }

        private void SetPurchaseDirectRtrnRibbonItems()
        {
            ribbonPageGroupProducts.Visible = false;
            bbiNewInvoice.Visibility = BarItemVisibility.Never;
        }

        private void SetPurchaseRtrnTextNdStatus()
        {
            this.status1 = 9;
            this.status2 = 10;
            this.Text = "فاتورة مردود مشتريات";
            ItemForsupNo.Text = "رقم فاتورة المردود";
            layoutControlGroup3.Text = "بيانات فاتورة مردود المشتريات الرئيسية";
            colsupTotalPrice.FieldName = "supCredit";
        }

        private void SetPurchaseRtrnRibbonItems()
        {
            ribbonPageGroup2.Visible = true;
            bbiSaveAndNew.Visibility = BarItemVisibility.Never;
            bbiReset.Visibility = BarItemVisibility.Never;
            bbiEditPrice.Visibility = BarItemVisibility.Never;
            bbiStrIdSLE.Enabled = false;
            bbiSupplierSLE.Enabled = false;
            //   radioGroupIsCash.Enabled = false;
            ItemForpurchaseNo.Visibility = LayoutVisibility.Always;
            ItemForsupAccNo.Enabled = false;
            layoutControlItem1.Enabled = false;
            checkEditTax.Enabled = false;
        }

        private void InitSupplyObject()
        {
            this.clsTbSupplyMain = new ClsTblSupplyMain();
            this.clsTbSupplySub = new ClsTblSupplySub();

        }

        private void InitSupplyTarhelObj()
        {
            if (this.autoSupplyTarhel) this.clsSupplyTarhel = new ClsSupplyTarhel(this.supplyType, null, true);
        }

        private void InitInvoiceObjects()
        {
            this.clsTbAccount = new ClsTblAccount();
            this.clsTbSupplier = new ClsTblSupplier();
            this.clsTbStore = new ClsTblStore();
            this.clsTbGroupStr = new ClsTblGroupStr();
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            this.clsTbBarcode = new ClsTblBarcode();
            this.clsPrdQuantityOpr = new ClsPrdQuantityOperations();
            this.clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur);
        }

        private bool ValidateData()
        {
            if (!ValidateControls()) return false;
            if (!ValidateStrId()) return false;
            if (!ValidateRtrnMark()) return false;
            if (!ValidateEntryNo()) return false;
            if (!ValidateGridData()) return false;
            if (!SaveGridToList()) return false;
            return dxValidationProvider1.Validate();
        }
        
        private bool ValidateControls()
        {
            SetSupplyNo();
            if (this.tbSupplyMain == null && this.supplyType != SupplyType.PurchaseRtrn && this.isNew)
            {
               
                InitSupplyMainObj();
                if (bbiSupplierSLE?.EditValue != null) this.tbSupplyMain.supCustSplId = Convert.ToInt32(bbiSupplierSLE.EditValue);
                layoutControlGroup3.Expanded = true;
                ClsXtraMssgBox.ShowWarning("يرجى التاكد من بيانات الفاتورة الرئيسية!");
                return false;
            }
            if (this.tbSupplyMain?.supAccNo == null || this.tbSupplyMain.supAccName == null || this.tbSupplyMain.supCurrency == null || this.tbSupplyMain.supNo == 0)
                layoutControlGroup3.Expanded = true;
            return dxValidationProvider1.Validate();
        }

        private bool SaveData()
        {
            if (!ValidateData()) return false;

            bool isSaved = false;
           
            if (this.isNew)
            {
                saveSelPriceNew();
                if (SaveMain() && SaveSub() && ((this.supplyType == SupplyType.Purchase) ? 
                    this.clsPrdQuantityOpr.AddPrdQuantity(this.prdQtyList) 
                    && this.clsPrdPriceQuanOpr.AddNewPrdQuantity(this.prdQtyList) : 
                    this.clsPrdQuantityOpr.DeductPrdQuantity(this.prdQtyList) && 
                    this.clsPrdPriceQuanOpr.DeductPrdQuantity(this.prdQtyList)) && SupplyAutoTarhel())
                    isSaved = true;
            }
            else
            {
                bool isSaveMain = SaveMain();
                Console.WriteLine($"=========isSaveMain = {isSaveMain}");
                bool isSaveSub = SaveSub();
                Console.WriteLine($"=========isSaveSub = {isSaveSub}");


                if (isSaveMain && isSaveSub && 
                    this.clsPrdQuantityOpr.UpdateProductQuantity(this.tbSupplySubListOld, this.tbSupplySubList, Convert.ToInt16(bbiStrIdSLE.EditValue), (this.supplyType == SupplyType.Purchase)) 
                    && this.clsPrdPriceQuanOpr.UpdateProductQuantity(this.tbSupplySubListOld, this.tbSupplySubList, (this.supplyType == SupplyType.Purchase), true))
                    isSaved = true;
            }

            this.prdQtyList.Clear();

            return isSaved;
        }

        
        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Purchase) ? "purchaseSuccessMssg" : "purchaseRtrnSuccessMssg"), this.supNo);
            this.Close();

            if (this.isNew && this.supplyType == SupplyType.Purchase)
            {
                if (_formSupplyMain.CloseForm)
                {
                    _formSupplyMain.Close();
                    RefreschForm("barButtonItemPurchase", mssg);
                }
                else
                {
                    flyDialog.ShowDialogFormBelowRIbbon(_formSupplyMain, mainRibbonControl, mssg);
                    ShowPrintInvoice();
                }
            }
            else if (this.isNew && this.supplyType == SupplyType.PurchaseRtrn)
                RefreschForm("barButtonItemPurchaseRtrn", mssg);
            else if (this.supplyType == SupplyType.Purchase)
                RefreschForm("barButtonItemPurchase", mssg);
        }
        void RefreschForm(string barButton, string mssg)
        {
            Form form = Application.OpenForms["FormMain"];
            if (form is FormMain formMain && formMain.xtraTabControl1.TabPages.Any(x => x.Name == barButton))
            {
                XtraTabPage tabPage = formMain.xtraTabControl1.TabPages?.FirstOrDefault(x => x.Name == barButton);
                if (tabPage?.Controls[0] is UCpurchases uCsalesInstant)
                {
                    formMain.xtraTabControl1.SelectedTabPage = tabPage;
                    uCsalesInstant.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
                    uCsalesInstant.RefreshListDialog();
                }
            }
            else
            {
                using (UCpurchases uCsalesInstant = new UCpurchases(this.supplyType))
                {
                    uCsalesInstant.SetRefreshListDialog(mssg, this.tbSupplyMain.id, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
                    var tempMain = GetCopyOfCurrenttblSupplyMain();
                    Task.Run(() => ClsPrintReport.PrintSupply(tempMain, tbSupplySubList));
                }
            }
            flyDialog.ShowDialogForm(form, mssg, this.isNew);

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
                commission=this.tbSupplyMain.commission,
                TotalAfterDiscount=this.tbSupplyMain.TotalAfterDiscount,
                repName = this.tbSupplyMain.repName,
            };
        }
        private void bbiSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!SaveData()) return;

            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Purchase) ? "purchaseSuccessMssg" : "purchaseRtrnSuccessMssg"), this.tbSupplyMain.supNo);
            flyDialog.ShowDialogFormBelowRIbbon((this.supplyType != SupplyType.DirectPurchaseRtrn) ? _formSupplyMain : (Form)this, mainRibbonControl, mssg);

            ShowPrintInvoice();
            InitObjects();
            ResetData();

            this.isNew = true;
            this.isCash = 1;

            radioGroupIsCash.EditValue = this.isCash;
        }

       
        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(_resource.GetString("CloseFormMssg"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
                if (this.isNew && _formSupplyMain != null && this.supplyType == SupplyType.Purchase)
                    if (_formSupplyMain.CloseForm) _formSupplyMain.CloseMainForm();
            }
        }
        private void bbiReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ClsXtraMssgBox.ShowWarningYesNo("هل أنت متأكد من إعادة التهيئه؟ \nسيتم حذف جميع البيانات!") == DialogResult.No) return;
            ResetData();
        }

        private void bbiOrders_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            this.flyDialogOrders = ClsFlyoutDialog.InitFlyoutDialog(this, new ucOrders(OrderType.Purchase, this)
            { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 }, ClsOrderStatus.GetStringPlural(4));
            flyDialog.WaitForm(this, 0);

            this.flyDialogOrders.MouseCaptureChanged += FlyDialogOrders_MouseCaptureChanged;
            this.flyDialogOrders.Show();

            SetFormState(false);
        }

        private void FlyDialogOrders_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.flyDialogOrders.DialogResult != DialogResult.Yes) return;

            SetFormState(true);
            this.flyDialogOrders.Close();
        }

        private void SetFormState(bool isEnabled)
        {
            _formSupplyMain.Enabled = isEnabled;
        }

        protected internal void InitOrderSupply(tblOrderMain tbOrderMain, IList<tblOrderSub> tbOrderSubList)
        {
            flyDialog.WaitForm(this, 1);

            SetFormState(true);
            this.flyDialogOrders.Close();

            InitOrderMainSupply(tbOrderMain);
            InitOrderSubSupply(tbOrderSubList);
            CalculateTotalAmount();

            flyDialog.WaitForm(this, 0);
        }

        private void InitOrderMainSupply(tblOrderMain tbOrderMain)
        {
            this.tbSupplyMain = ClsObjectConverter.OrderToSupplyMain(tbOrderMain, this.supplyType);

            tblSupplyMainsBindingSource.DataSource = this.tbSupplyMain;
            SupAccNoTextEdit_EditValueChanged(supAccNoTextEdit, EventArgs.Empty);
        }

        private void InitOrderSubSupply(IList<tblOrderSub> tbOrderSubList)
        {
            var tbSupplySubList = ClsObjectConverter.OrderToSupplySub(tbOrderSubList, this.supplyType);

            tblSupplySubBindingSource.DataSource = tbSupplySubList;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (barCheckItem1.Checked && gridView.SelectedRowsCount < 1)
            {
                XtraMessageBox.Show(_resource.GetString("purchaseRtrnMarkErrMssg"));
                gridView.OptionsSelection.MultiSelect = true;
                barCheckItem1.Checked = false;
                return;
            }
            else if (barCheckItem1.Checked && gridView.SelectedRowsCount >= 1)
            {
                List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();

                for (short i = 0; i < gridView.SelectedRowsCount; i++)
                    tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplySub);

                this.tbSupplySubListOld = tbSupplySubList;
                tblSupplySubBindingSource.DataSource = tbSupplySubList;
                gridView.OptionsBehavior.Editable = true;
                gridView.OptionsSelection.MultiSelect = false;
            }
            else if (!barCheckItem1.Checked && this.tbSupplySubListOld != null)
            {
                gridView.OptionsSelection.MultiSelect = true;
                tblSupplySubBindingSource.DataSource = this.tbSupplySubListOld;
            }
            else
                gridView.OptionsSelection.MultiSelect = true;

            CalculateTotalAmount();
            //if (barCheckItem1.Checked)
            //{
            //    if (gridView.SelectedRowsCount < 1)
            //    {
            //        XtraMessageBox.Show(_resource.GetString("purchaseRtrnMarkErrMssg"));
            //        barCheckItem1.Checked = false;
            //        return;
            //    }

            //    List<tblSupplySub> tbSupplySubList = new List<tblSupplySub>();

            //    for (short i = 0; i < gridView.SelectedRowsCount; i++)
            //        tbSupplySubList.Add(gridView.GetRow(gridView.GetSelectedRows()[i]) as tblSupplySub);

            //    this.tbSupplySubListOld = tbSupplySubList;
            //    tblSupplySubBindingSource.DataSource = tbSupplySubList;
            //    gridView.OptionsSelection.MultiSelect = false;
            //}
            //else
            //{
            //    gridView.OptionsSelection.MultiSelect = true;
            //}
        }

        private void bbiEditQuantity_ItemClick(object sender, ItemClickEventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 1, gridView.FocusedRowHandle, Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupQuanMain))).ShowDialog();
        }

        private void bbiEditPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            new formPurchaseSaleShortcuts(this, 2, gridView.FocusedRowHandle, price: Convert.ToDouble(gridView.GetFocusedRowCellValue(colsupPrice))).ShowDialog();
        }

        private void bbiRefreshPrds_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitInvoiceObjects();
            flyDialog.WaitForm(this, 0);
        }

        private void BbiAddProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            using (formAddProduct frm = new formAddProduct(null, null))
            {
                flyDialog.WaitForm(this, 0);
                frm.ShowDialog();
                BbiRefreshProducts_ItemClick(null, null);
            }
        }

        private void BbiRefreshProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            InitInvoiceObjects();
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
            this.clsPrdQuantityOpr = new ClsPrdQuantityOperations();
            this.clsPrdPriceQuanOpr = new ClsPrdPriceQuanOperations(new ClsTblPrdPriceQuan(), this.clsTbPrdMsur);

            tblProductBindingSource.DataSource = this.clsTbProduct.GetProductList.Where(x=>x.prdBrnId==Session.CurBranch.brnId);
            flyDialog.WaitForm(this, 0);
        }

        private bool SaveGridToList()
        {
            ChangeFocusedColumn();
            gridView.UpdateCurrentRow();
            this.tbSupplySubList = new List<tblSupplySub>();
            long grpAccNo = 0;

            for (short i = 0; i < gridView.DataRowCount; i++)
            {
                if (gridView.GetRowCellValue(i, colsupPrdNo) == null) continue;
                tblSupplySub tbSupplySub = gridView.GetRow(i) as tblSupplySub;
                if (tbSupplySub == null) continue;

                if (!checkEditTax.Checked)
                {
                    tbSupplySub.supTaxPercent = 0;
                    tbSupplySub.supTaxPrice = 0;
                }
                if (this.supplyType != SupplyType.PurchaseRtrn)
                {
                    grpAccNo = this.clsTbGroupStr.GetGroupAccNoById(Convert.ToInt32(gridView.GetRowCellValue(i, colsupAccNo)));
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
                    if (this.supplyType == SupplyType.Purchase)
                    {
                        tbSupplySub.supDebit = tbSupplySub.supDebit * Convert.ToDouble(supCurrencyChngTextEdit.EditValue);
                        tbSupplySub.supDebitFrgn = tbSupplySub.supDebit;
                    }
                    else
                    {
                        tbSupplySub.supCredit = tbSupplySub.supCredit * Convert.ToDouble(supCurrencyChngTextEdit.EditValue);
                        tbSupplySub.supCreditFrgn = tbSupplySub.supCredit;
                    }
                }
                this.tbSupplySubList.Add(tbSupplySub);
            }
            return true;
        }

        private void ChangeFocusedColumn()
        {
            gridView.FocusedColumn = (gridView.FocusedColumn == colsupPrdNo) ? colprdName : colsupPrdNo;
        }

        private void UpdateTbSupplyMainTotalAmount()
        {
            double.TryParse(labelTotalTaxDecimal.Text, out double totaltax);
            double.TryParse(labelTotalPriceDecimal.Text, out double totalAmount);

            this.tbSupplyMain.supTotal = (this.currency == 1) ? totalAmount : totalAmount * (int)this.tbSupplyMain.supCurrencyChng;


            this.tbSupplyMain.supTotalFrgn = (this.currency > 1) ? totalAmount : 0;
            this.tbSupplyMain.supEqfal = (this.isCash == 1) ? (byte)2 : (byte)1;

            if (!this.hasTax) return;
            this.tbSupplyMain.supTaxPrice = totaltax;
            this.tbSupplyMain.supTaxPercent = MySetting.GetPrivateSetting.taxDefault;

            //TODO Math.Round
            // this.tbSupplyMain.supTotal = Math.Round(this.tbSupplyMain.supTotal, 1, MidpointRounding.AwayFromZero);

        }

        private bool SaveMain()
        {
            UpdateTbSupplyMainTotalAmount();
            bool isSaved = false;
            (tblSupplyMainsBindingSource.Current as tblSupplyMain).supCustSplId = (this.isCash == 1) ?
                 Convert.ToInt32(bbiSupplierSLE.EditValue) : this.splId;
            if (this.isNew)
            {
                if (this.supplyType != SupplyType.PurchaseRtrn)
                    db.tblSupplyMains.Add(tblSupplyMainsBindingSource.Current as tblSupplyMain);
                else
                    db2.tblSupplyMains.Add(tblSupplyMainsBindingSource.Current as tblSupplyMain);

                if (SaveDB())
                {
                    this.supMainId = this.tbSupplyMain.id;
                    isSaved = true;
                }
                else
                    return false;
            }
            else
            {
                var Baseitem = db.tblSupplyMains.Find(this.tbSupplyMain.id);
                this.tbSupplyMain.supNo = this.supNo;
                db.Entry(Baseitem).CurrentValues.SetValues(this.tbSupplyMain);
                isSaved = SaveDB();
              
                if (!isSaved) return false;
            }
            //else
            //{

            //var Baseitem = db.tblSupplyMains.Find((tblSupplyMainsBindingSource.Current as tblSupplyMain).id);
            //db.Entry(Baseitem).CurrentValues.SetValues(tblSupplyMainsBindingSource.Current as tblSupplyMain);
            //if (db.SaveChanges() > 0)
            //{
            //    this.supMainId = this.tbSupplyMain.id;
            //    isSaved = true;
            //}
            //}


            SaveSupplierInvoice();
            return isSaved;
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
                    ExpireDate = tbSupplySub.ExpireDate,
                    subHeight = 0,
                    subNoPacks = tbSupplySub.subNoPacks,
                    subQteMeter = tbSupplySub.subQteMeter,
                    subWidth = 0
                };
                AddPrdQtyList(supplySub);
                bool st;
                if (this.supplyType == SupplyType.PurchaseRtrn)
                {
                    db2.tblSupplySubs.Add(supplySub);
                    st = SaveDB();
                }
                else
                {
                    db.tblSupplySubs.Add(supplySub);
                    st = SaveDB();
                }
                if (!st)
                    return st;
            }
            return SaveDB();
        }

        private bool SupplyAutoTarhel()
        {
            if (!this.autoSupplyTarhel) return true;

            this.tbSupplyMain.id = this.supMainId;
            this.clsSupplyTarhel.PhaseInvoice(new Collection<tblSupplyMain>() { this.tbSupplyMain });

            return true;
        }

        private void SaveSupplierInvoice()
        {
            if (!isNew)
            {
                db.tblSupplierInvoices.RemoveRange(db.tblSupplierInvoices.Where(x => x.invSupId == this.supMainId));
                SaveDB();
            }
            if (this.isCash == 1 && bbiSupplierSLE.EditValue == null) return;

            tblSupplierInvoice tbSupplierInv = new tblSupplierInvoice()
            {
                invSupId = this.supMainId,
                invSplId = (this.isCash == 1) ? ((bbiSupplierSLE.EditValue as int?) ?? 0) : this.splId,
                invBrnId = Session.CurBranch.brnId
            };
            if (this.supplyType == SupplyType.PurchaseRtrn) db2.tblSupplierInvoices.Add(tbSupplierInv);
            else db.tblSupplierInvoices.Add(tbSupplierInv);
        }

        private void ResetData()
        {
            InitSupplyMainObj(true);
            SupAccNoTextEdit_EditValueChanged(supAccNoTextEdit, EventArgs.Empty);
            //tblSupplySubBindingSource.DataSource = null;
            //tblSupplySubBindingSource.DataSource = typeof(TempSupplySub);
            ResetTotalLabels();
            textEditBarcodeNo.Focus();
            textEditPaidCash.EditValue = null;
            SupAccNoTextEdit_EditValueChanged(supAccNoTextEdit, EventArgs.Empty);
        }

        private void CloseForm(string mssg)
        {
            _ucPurchases.SetRefreshListDialog(mssg, this.supNo, this.isNew, this.tbSupplyMain, this.tbSupplySubList);
            DialogResult = DialogResult.OK;
        }

        private void AddPrdQtyList(tblSupplySub tbSupplySub)
        {
            ClsProductQuantList prodQuan = new ClsProductQuantList()
            {
                prdId = Convert.ToInt32(tbSupplySub.supPrdId),
                prdNo = Convert.ToString(tbSupplySub.supPrdNo),
                prdName = Convert.ToString(tbSupplySub.supPrdName),
                prdPrice = Convert.ToDouble(tbSupplySub.supPrice),
                prdQuantity = Convert.ToDouble(tbSupplySub.supQuanMain),
                prdPriceMsurId = Convert.ToInt32(tbSupplySub.supMsur),
                prdStrId = Convert.ToInt16(bbiStrIdSLE.EditValue)
            };
            this.prdQtyList.Add(prodQuan);
        }

        private bool ValidateEntryNo()
        {
            ChangeFocus();

            bool isValid = true;
            this.supNo = Convert.ToInt32(supNoTextEdit.EditValue);
            string mssg = string.Format(_resource.GetString((this.supplyType == SupplyType.Purchase) ? "purchaseErrMssg" : "purchaseRtrnErrMssg"), this.supNo);

            if (this.isNew)
            {
                //if (this.isCash == 1 && this.clsSupply.IsSupFoundBox(this.supNo, this.accNo, this.status1, this.status2))
                //    this.supNo = this.clsSupply.StoreEntryNoBox(this.status1, this.status2);
                //else if (this.isCash == 2 && this.clsSupply.IsSupFoundCredit(this.supNo, this.status1, this.status2))
                //    this.supNo = this.clsSupply.StoreEntryNoCredit(this.status1, this.status2);
                this.tbSupplyMain.supNo = this.clsSupply.StoreEntryNoBox(this.status1, this.status2);
            }
            else
            {
                if (this.supNoOld != this.supNo && this.isCash == 1 && this.clsSupply.IsSupFoundBox(this.supNo, this.accNo, this.status1, this.status2))
                    isValid = false;
                else if (this.supNoOld != this.supNo && this.isCash == 2 && this.clsSupply.IsSupFoundCredit(this.supNo, this.status1, this.status2))
                    isValid = false;
            }

            if (!isValid) XtraMessageBox.Show(mssg);

            return isValid;
        }

        private void ChangeFocus()
        {
            textEditBarcodeNo.Focus();
        }

        private bool ValidateStrId()
        {
            bool isValid = (Convert.ToInt16(bbiStrIdSLE.EditValue) == 0) ? false : true;
            if (!isValid)
            {
                string mssg = (!MySetting.GetPrivateSetting.LangEng) ? "عذراً يجب تحديد المخزن أولاً." : "Please select store first!";
                XtraMessageBox.Show(mssg);
            }
            return isValid;
        }

        private bool ValidateRtrnMark()
        {
            if (this.supplyType != SupplyType.PurchaseRtrn) return true;

            bool isValid = barCheckItem1.Checked;
            if (!isValid) XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ?
                "عذرا يجب الضغط على زر التحديد أولاً" : "Please press check button first!"); ;

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
            textEditBarcodeNo.Focus();
            return true;
        }

        private void ShowPrintInvoice()
        {
            if (MySetting.DefaultSetting.ShowPrintMssg) PrintInvoiceMssg();
            else PrintReport();
        }

        private void PrintInvoiceMssg()
        {
            if (XtraMessageBox.Show(_resource.GetString("printInvoiceMssg"), "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flyDialog.WaitForm(this, 1);
                using (ReportForm frm = new ReportForm(((ReportType)MySetting.DefaultSetting.printA4), tbSupplyMain: this.tbSupplyMain, tbSupplySubList: this.tbSupplySubList, clsTbProduct: this.clsTbProduct, clsTbPrdMsur: this.clsTbPrdMsur))
                {
                    flyDialog.WaitForm(this, 0, frm);
                    frm.ShowDialog();
                }
            }
        }

        private void PrintReport()
        {
            ClsPrintReport.PrintSupply(this.tbSupplyMain, this.tbSupplySubList, this.clsTbProduct, this.clsTbPrdMsur);
        }

        public void SetProductQunatity(int rowHandle, double quantity)
        {
            gridView.SetRowCellValue(rowHandle, colsupQuanMain, quantity);
            CalculateTax(rowHandle);
            CalculateTotalRow(rowHandle);
            CalculateTotalAmount();
        }

        public void SetProductPrice(int rowHandle, double price)
        {
            gridView.SetRowCellValue(rowHandle, colsupPrice, price);
            CalculateTax(rowHandle);
            CalculateTotalRow(rowHandle);
            CalculateTotalAmount();
        }

        private void SetBbiSupplierInvoice()
        {
            if (this.isCash == 2)
            {
                SetSupplierRibbonGroupVisibility(false);
                return;
            }
            SetSupplierRibbonGroupVisibility(true);
            this.splId = new ClsTblSupplierInvoice().GetSupplierIdByInvoiceId(this.supMainId);

            if (this.splId != 0 && this.supplyType == SupplyType.Purchase)
                repositoryItemSearchLookUpEditSupplierBbi.DataSource = this.clsTbSupplier.GetTblSupplierListByCurrencyId(this.currency);
            if (this.splId > 0)
                bbiSupplierSLE.EditValue = this.splId;
            else
                bbiSupplierSLE.EditValue = null;
            //bbiSupplierSLE.Enabled = false;
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                GridControl control = sender as GridControl;
                if (control == null) return;
                GridView view = control.FocusedView as GridView;
                if (view == null) return;
                if (view.FocusedColumn == null) return;
                view.FocusedColumn = view.VisibleColumns[view.FocusedColumn.VisibleIndex + 1];
                e.Handled = true;
                return;
            }
            switch (e.KeyData)
            {
                case Keys.Delete:
                    gridView.DeleteSelectedRows();
                    CalculateTotalAmount();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    textEditBarcodeNo.Focus();
                    e.Handled = true;
                    break;
                case Keys.Tab:
                    gridView.FocusedColumn = colsupQuanMain;
                    e.Handled = true;
                    break;
            }
        }

        private void FormAddSupplyRcpt_Activated(object sender, EventArgs e)
        {
            textEditBarcodeNo.Focus();
        }

        private void layoutControlGroup9_CustomDrawBackground(object sender, GroupBackgroundCustomDrawEventArgs e)
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
            labelTotalFinalDecimal.Text = "0.00";
            labelPaidAmountDecimal.Text = "0.00";
            labelRemaingAmountDecimal.Text = "0.00";
        }

        private void DisableItems()
        {
            //  ItemForBarcodeText.Enabled = false;
            checkEditTax.Enabled = false;
            //    radioGroupIsCash.Enabled = false;
            bbiStrIdSLE.Enabled = false;
        }

        private void SetRibbonButtonsVisisbility()
        {
            bbiSaveAndNew.Visibility = BarItemVisibility.Never;
            bbiReset.Visibility = BarItemVisibility.Never;
            bbiNewInvoice.Visibility = BarItemVisibility.Never;
            bbiOrders.Visibility = BarItemVisibility.Never;
        }

        private void SetGridProperties()
        {
            DisableGridColumns(colsupPrdBarcode);
            DisableGridColumns(colsupPrdNo);
            DisableGridColumns(colsupMsur);
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
        }

        private void SetLayoutControl()
        {
            layoutControlGroup3.ExpandButtonVisible = false;
            layoutControlGroup3.ExpandOnDoubleClick = false;
            //dataLayoutControl1.Size = new Size(1136, 175);
        }

        private void saveSelPriceNew()
        {
            var lis = (tblSupplySubBindingSource.List as IList<TempSupplySub>)?.Where(x => x.supSalePrice.GetValueOrDefault() > 0).ToList();
            if (lis.Count <= 0) return;
            using (accountingEntities db5 = new accountingEntities())
            {
                lis.ForEach(x =>
                {
                    var pr = db5.tblPrdPriceMeasurments.FirstOrDefault(m => m.ppmId == x.supMsur);
                    if (pr != null && x.supSalePrice is double salePrice && salePrice > 0 && pr.ppmSalePrice != salePrice)
                    {
                        pr.ppmSalePrice = salePrice;
                        db5.SaveChanges();
                    }
                });
            }
        }

        private void DisableGridColumns(GridColumn column)
        {
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.TabStop = false;
        }

        private void GridView_HideCustomizationForm(object sender, EventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name);
        }

        private void GridView_ShowCustomizationForm(object sender, EventArgs e)
        {
            ((GridView)sender).CustomizationForm.Text = "تحديد الأعمده";
        }

        private void DataLayoutControl1_GroupExpandChanged(object sender, LayoutGroupEventArgs e)
        {
            MySetting.GetPrivateSetting.supplyPurchaseExpanded = layoutControlGroup3.Expanded;
            MySetting.WriterSettingXml(); 
        }



        private void formAddSupplyRcpt_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsPath.SaveCustomContol(this.gridView, this.Name);
        }

        private void GetResources()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(Language.PurchaseManagementAr));

            }
            else
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(Language.formAddSupplyRcptEn));
            }

            if (MySetting.GetPrivateSetting.LangEng) EnglishTranslation();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            UCsupplier uCsupplier = new UCsupplier() { Dock = DockStyle.Fill, Height = (ClientSize.Height / 2) + 100 };
            uCsupplier.ribbonControl.StatusBar.Hide();
            uCsupplier.ribbonControl.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            flyDialog.WaitForm(this, 0);

            ClsFlyoutDialog.ShowFlyoutDialog(this, uCsupplier, (!MySetting.GetPrivateSetting.LangEng) ? "الموردين" : "Suppliers");

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SetBbiSupplierSLE();

        }

        private void btnPriceTrans_ItemClick(object sender, ItemClickEventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0) return;

            flyDialog.WaitForm(this, 1);
            using var form = new formSupplyPricrTrans();
            flyDialog.WaitForm(this, 0);

            if (form.ShowDialog() == DialogResult.OK)
            {
                gridView.SetRowCellValue(rowHandle, colsupPrice, form.Price);
                CalculateTax(rowHandle);
                CalculateTotalRow(rowHandle);
                CalculateTotalAmount();
            }

        }

        private void textEditDscntTotalAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (Convert.ToDouble(textEditDscntTotalAmount.EditValue) == 0) return;
            this.hasTax = checkEditTax.Checked;
            var total = Convert.ToDouble(labelTotalPriceDecimal.Text);
            var Tax = this.hasTax ? Convert.ToDouble(this.tax) : 0;
            var discount = 0d;
            var net = Convert.ToDouble(textEditDscntTotalAmount.EditValue);

            discount = 1 - (net / (total * (1 + (Tax / 100))));
            supDscntPercentTextEdit.EditValue = discount * 100;
            SupDscntPercentTextEdit_KeyUp(null, null);
            textEditDscntTotalAmount.EditValue = 0;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (clsTbSupplyMain == null) clsTbSupplyMain = new ClsTblSupplyMain();
            if (clsTbSupplySub == null) clsTbSupplySub = new ClsTblSupplySub();
            var supplyMain = this.clsTbSupplyMain.GetSupplyMainListPurchase().OrderByDescending(x => x.supDate).FirstOrDefault();
            if (supplyMain != null)
            {
                var tbSupplySubList = this.clsTbSupplySub.GetSupplySubListBySupId(supplyMain.id);
                ClsStopWatch stopWatch2 = new ClsStopWatch();
                log.Debug("PrintReportClsPrintReportStart");
                Task.Run(() => ClsPrintReport.PrintSupply(supplyMain, tbSupplySubList));
                log.Debug($"PrintReportClsPrintReportEnd => {stopWatch2.Stop()}");
            }
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
                    {
            if (gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode")   != null)
            {
                      
            formBarcode frm = new formBarcode();
                frm.Show();
                frm. SearchProduct(gridView.GetRowCellValue(gridView.FocusedRowHandle, "supPrdBarcode").ToString());
            }
        }

        private void textEditDscntTotalAmount_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToDouble(textEditDscntTotalAmount.EditValue) == 0m) return;

            //var total = Convert.ToDouble(labelTotalPriceDecimal.Text);
            //var Tax = this.hasTax ? Convert.ToDouble(this.tax) : 0;
            //var discount = 0m;
            //var net = Convert.ToDouble(textEditDscntTotalAmount.EditValue);

            //discount = 1 - (net / (total * (1 + (Tax / 100))));
            //supDscntPercentTextEdit.EditValue = discount * 100;
            //SupDscntPercentTextEdit_KeyUp(null, null);
            //textEditDscntTotalAmount.EditValue = 0;
        }

        private void EnglishTranslation()
        {
            EnglishLayout();

            try
            {
                foreach (LayoutControlItem item in layoutControlGroup3.Items)
                    _resource.ApplyResources(item, item.Name, _ci);
            }
            catch { }
            try
            {
                foreach (LayoutControlItem item in layoutControlGroup6.Items)
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
            try { _resource.ApplyResources(mainRibbonPage, mainRibbonPage.Name); } catch { }
            try { _resource.ApplyResources(mainRibbonPageGroup, mainRibbonPageGroup.Name, _ci); } catch { }
            try { _resource.ApplyResources(ribbonPageGroup1, ribbonPageGroup1.Name, _ci); } catch { }
            try { _resource.ApplyResources(ribbonPageGroupShortcuts, ribbonPageGroupShortcuts.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSave, bbiSave.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiSaveAndNew, bbiSaveAndNew.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiClose, bbiClose.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditQuantity, bbiEditQuantity.Name, _ci); } catch { }
            try { _resource.ApplyResources(bbiEditPrice, bbiEditPrice.Name, _ci); } catch { }
            try { _resource.ApplyResources(barCheckItem1, barCheckItem1.Name, _ci); } catch { }
            try { _resource.ApplyResources(layoutControlGroup3, layoutControlGroup3.Name, _ci); } catch { }
            try { _resource.ApplyResources(checkEditTax, checkEditTax.Name, _ci); } catch { }
            try { _resource.ApplyResources(labelItemsCount, labelItemsCount.Name, _ci); } catch { }
            try { repoItemRadioGroupIsCash.Items[0].Description = _resource.GetString("radioGroupIsCash.Properties.Items1"); } catch { }
            try { repoItemRadioGroupIsCash.Items[1].Description = _resource.GetString("radioGroupIsCash.Properties.Items2"); } catch { }
            try { supAccNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("colAccNo"); } catch { }
            try { supAccNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("colAccName"); } catch { }
            try { supSplNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns0"); } catch { }
            try { supSplNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("supSplNoTextEdit.Properties.Columns1"); } catch { }
            try { purchaseNoTextEdit.Properties.Columns[0].Caption = _resource.GetString("purchaseNoTextEdit.Properties.Columns0"); } catch { }
            try { purchaseNoTextEdit.Properties.Columns[1].Caption = _resource.GetString("purchaseNoTextEdit.Properties.Columns1"); } catch { }
            try { purchaseNoTextEdit.Properties.Columns[2].Caption = _resource.GetString("purchaseNoTextEdit.Properties.Columns2"); } catch { }
            try { repositoryItemLookUpEditMeasurment.Columns[0].Caption = _resource.GetString("repositoryItemLookUpEditMeasurment.Columns1"); } catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[1].Caption = _resource.GetString("colprdNo.Caption"); } catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[2].Caption = _resource.GetString("colprdName.Caption"); } catch { }
            try { repositoryItemSearchLookUpEditPrdNo.View.Columns[3].Caption = _resource.GetString("colsplPhone.Caption"); } catch { }

            this.Text = (this.supplyType == SupplyType.Purchase) ? _resource.GetString("this.Purchase") : _resource.GetString("this.PurchaseRtrn");


            try { barButtonItem3.Caption = _resource.GetString("barButtonItem3"); } catch { }
            try { bsiStrName.Caption = _resource.GetString("bsiStrName"); } catch { }
            try { ribbonPageGroupStrId.Text = _resource.GetString("ribbonPageGroupStrId"); } catch { }
            try { bbiNewInvoice.Caption = _resource.GetString("bbiNewInvoice"); } catch { }
            try { bbiReset.Caption = _resource.GetString("bbiReset"); } catch { }
            try { ItemForBarcodeText.Text = _resource.GetString("ItemForBarcodeText"); } catch { }
            try { colCount.Caption = _resource.GetString("colCount"); } catch { }
            try { colsupDscntPercent.Caption = _resource.GetString("colsupDscntPercent"); } catch { }
            try { layoutControlItem5.Text = _resource.GetString("layoutControlItem5"); } catch { }
            try { labelTotalPriceString.Text = _resource.GetString("labelTotalPriceString"); } catch { }
            try { labelTotalTaxString.Text = _resource.GetString("labelTotalTaxString"); } catch { }
            try { layoutControlItem4.Text = _resource.GetString("layoutControlItem4"); } catch { }

            try { colTotal.Caption = _resource.GetString("colTotal"); } catch { }
            try { gridColumn1.Caption = _resource.GetString("gridColumn1"); } catch { }
            try { bsiSupplier.Caption = _resource.GetString("bsiSupplier"); } catch { }
            try { barButtonItem1.Caption = _resource.GetString("barButtonItem1"); } catch { }
            try { barButtonItem2.Caption = _resource.GetString("barButtonItem2"); } catch { }
            try { ribbonPageGroupSupplier.Text = _resource.GetString("ribbonPageGroupSupplier"); } catch { }
            try { bbiRefreshPrds.Caption = _resource.GetString("bbiRefreshPrds"); } catch { }
            try { btnPriceTrans.Caption = _resource.GetString("btnPriceTrans"); } catch { }
            try { bbiAddProduct.Caption = _resource.GetString("bbiAddProduct"); } catch { }
            try { bbiRefreshProducts.Caption = _resource.GetString("bbiRefreshProducts"); } catch { }
            try { ribbonPageGroupProducts.Text = _resource.GetString("ribbonPageGroupProducts"); } catch { }
            try { checkEditPrdLastPrice.Text = _resource.GetString("checkEditPrdLastPrice"); } catch { }
            try { layoutControlGroup8.Text = _resource.GetString("layoutControlGroup8"); } catch { }
            try { ItemForsupDscntPercent.Text = _resource.GetString("ItemForsupDscntPercent"); } catch { }
            try { ItemForsupDscntAmount.Text = _resource.GetString("ItemForsupDscntAmount"); } catch { }
            try { ItemForDiscTotalAmount.Text = _resource.GetString("ItemForDiscTotalAmount"); } catch { }
            try { ItemForsupBankId.Text = _resource.GetString("ItemForsupBankId"); } catch { }
        }

        private void EnglishLayout()
        {
            dataLayoutControl1.BeginUpdate();
            dataLayoutControl1.RightToLeft = RightToLeft.No;
            dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            dataLayoutControl1.EndUpdate();

            layoutControl1.BeginUpdate();
            layoutControl1.RightToLeft = RightToLeft.No;
            layoutControl1.OptionsView.RightToLeftMirroringApplied = false;
            layoutControl1.EndUpdate();

            radioGroupIsCash.EditWidth = 60;
            //itemForTotalPrice.TextToControlDistance = 76;

            this.RightToLeft = RightToLeft.No;
        }

        private bool SaveDB()
        {
            return ClsSaveDB.Save((this.supplyType == SupplyType.PurchaseRtrn) ? db2 : db, LogHelper.GetLogger());
        }
    }
}
