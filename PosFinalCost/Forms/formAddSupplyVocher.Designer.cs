using System.Windows.Forms;

namespace PosFinalCost
{
    partial class formAddSupplyVoucher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddSupplyVoucher));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayConMain = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.bindingNavigator11 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bbiNewInvoice = new System.Windows.Forms.ToolStripButton();
            this.bbiSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiSaveAndNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiPrintPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiPrint1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiUpdateInvvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiPrdPrice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiEditPrice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiEditQuantity = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.bbiSaveAndNewNoPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bsiPaidCreditShortcut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.SupplySubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupPrdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEditPrdNo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colprdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNameEng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdGrpNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditProName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMsur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditMeasurment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.PrdMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditQuan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colsupSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1SalePrice = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colsupTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditDesc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrdManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDscntPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDscntAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdQuanAvlb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SubNoPacks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupOvertime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupWorkingtime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditBarcodeNo = new DevExpress.XtraEditors.TextEdit();
            this.btnDeleteRow = new DevExpress.XtraEditors.SimpleButton();
            this.supDscntPercentTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.SupplyMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DscntAmountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.txtdisround = new DevExpress.XtraEditors.ButtonEdit();
            this.spinEditMonyFinal = new DevExpress.XtraEditors.TextEdit();
            this.BtnDscnFraction = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPaidCreditCard = new DevExpress.XtraEditors.TextEdit();
            this.textEditPaidCash = new DevExpress.XtraEditors.TextEdit();
            this.btnECRsend = new DevExpress.XtraEditors.SimpleButton();
            this.btnECRcancel = new DevExpress.XtraEditors.SimpleButton();
            this.spinEditTotalFinalDecimal = new DevExpress.XtraEditors.SpinEdit();
            this.labelTotalPriceDecimal = new DevExpress.XtraEditors.TextEdit();
            this.labelDiscountDecimal = new DevExpress.XtraEditors.TextEdit();
            this.labelTotalTaxDecimal = new DevExpress.XtraEditors.TextEdit();
            this.labelTotalDecimal = new DevExpress.XtraEditors.TextEdit();
            this.supNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.radioGroupIsCash = new DevExpress.XtraEditors.RadioGroup();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textEditCounterNumber = new DevExpress.XtraEditors.TextEdit();
            this.textEditPlateNumber = new DevExpress.XtraEditors.TextEdit();
            this.textEditCarType = new DevExpress.XtraEditors.TextEdit();
            this.supRefNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.supDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.BoxNoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.saleNoTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SupplyMainBindingSourceEditor = new System.Windows.Forms.BindingSource(this.components);
            this.CurrencyChngTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.checkEditTax = new DevExpress.XtraEditors.CheckEdit();
            this.supCurrTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CustNoSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcustNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustPhnNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustCurrency1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.notDateTextEdit = new DevExpress.XtraEditors.DateEdit();
            this.PoNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NotesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StrIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.BankLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGrooupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSalesNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCarData = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupCur = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBoxNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrencyChng = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBankId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPoNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupRefNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNotes = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupCustNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFornotDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.labelTotalFinalString = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelTotalPriceString = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelDiscountString = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelTotalTaxString = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelTotalString = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForPaidCreditCard = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForPaidCash = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelECR = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.ItemForBarcodeText = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBtnDeleteRow = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelItemsCount = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForsupDscntPercent = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForDscntAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridViewCustomerSLE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcstId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.dxValidationProvider11 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.toolStripButton47 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton46 = new System.Windows.Forms.ToolStripButton();
            this.toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.tabFormControl1 = new DevExpress.XtraBars.TabFormControl();
            this.tabFormPage2 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer2 = new DevExpress.XtraBars.TabFormContentContainer();
            this.tabFormPage3 = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer3 = new DevExpress.XtraBars.TabFormContentContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayConMain)).BeginInit();
            this.dataLayConMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).BeginInit();
            this.bindingNavigator11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplySubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditPrdNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMeasurment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrdMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1SalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarcodeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supDscntPercentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DscntAmountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdisround.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMonyFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidCreditCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTotalFinalDecimal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalPriceDecimal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDiscountDecimal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalTaxDecimal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalDecimal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupIsCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCounterNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPlateNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCarType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supRefNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supDescTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxNoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyMainBindingSourceEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyChngTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supCurrTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustNoSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notDateTextEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGrooupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCarData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupCur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBoxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencyChng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBankId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPoNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupRefNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupCustNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFornotDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalFinalString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalPriceString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDiscountString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalTaxString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalString)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPaidCreditCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPaidCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelECR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBarcodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBtnDeleteRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelItemsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForsupDscntPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForDscntAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerSLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayConMain
            // 
            this.dataLayConMain.Appearance.ControlDisabled.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            this.dataLayConMain.Appearance.ControlDisabled.Options.UseForeColor = true;
            this.dataLayConMain.Appearance.DisabledLayoutItem.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            this.dataLayConMain.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.dataLayConMain.Controls.Add(this.bindingNavigator11);
            this.dataLayConMain.Controls.Add(this.gridControl);
            this.dataLayConMain.Controls.Add(this.textEditBarcodeNo);
            this.dataLayConMain.Controls.Add(this.btnDeleteRow);
            this.dataLayConMain.Controls.Add(this.supDscntPercentTextEdit);
            this.dataLayConMain.Controls.Add(this.DscntAmountTextEdit);
            this.dataLayConMain.Controls.Add(this.txtdisround);
            this.dataLayConMain.Controls.Add(this.spinEditMonyFinal);
            this.dataLayConMain.Controls.Add(this.BtnDscnFraction);
            this.dataLayConMain.Controls.Add(this.simpleButton2);
            this.dataLayConMain.Controls.Add(this.textEditPaidCreditCard);
            this.dataLayConMain.Controls.Add(this.textEditPaidCash);
            this.dataLayConMain.Controls.Add(this.btnECRsend);
            this.dataLayConMain.Controls.Add(this.btnECRcancel);
            this.dataLayConMain.Controls.Add(this.spinEditTotalFinalDecimal);
            this.dataLayConMain.Controls.Add(this.labelTotalPriceDecimal);
            this.dataLayConMain.Controls.Add(this.labelDiscountDecimal);
            this.dataLayConMain.Controls.Add(this.labelTotalTaxDecimal);
            this.dataLayConMain.Controls.Add(this.labelTotalDecimal);
            this.dataLayConMain.Controls.Add(this.supNoTextEdit);
            this.dataLayConMain.Controls.Add(this.radioGroupIsCash);
            this.dataLayConMain.Controls.Add(this.checkEdit1);
            this.dataLayConMain.Controls.Add(this.textEditCounterNumber);
            this.dataLayConMain.Controls.Add(this.textEditPlateNumber);
            this.dataLayConMain.Controls.Add(this.textEditCarType);
            this.dataLayConMain.Controls.Add(this.supRefNoTextEdit);
            this.dataLayConMain.Controls.Add(this.supDescTextEdit);
            this.dataLayConMain.Controls.Add(this.DateDateEdit);
            this.dataLayConMain.Controls.Add(this.BoxNoLookUpEdit);
            this.dataLayConMain.Controls.Add(this.saleNoTextEdit);
            this.dataLayConMain.Controls.Add(this.CurrencyChngTextEdit);
            this.dataLayConMain.Controls.Add(this.checkEditTax);
            this.dataLayConMain.Controls.Add(this.supCurrTextEdit);
            this.dataLayConMain.Controls.Add(this.CustNoSearchLookUpEdit);
            this.dataLayConMain.Controls.Add(this.notDateTextEdit);
            this.dataLayConMain.Controls.Add(this.PoNumberTextEdit);
            this.dataLayConMain.Controls.Add(this.NotesTextEdit);
            this.dataLayConMain.Controls.Add(this.StrIdLookUpEdit);
            this.dataLayConMain.Controls.Add(this.BankLookUpEdit);
            this.dataLayConMain.DataSource = this.SupplyMainBindingSource;
            this.dataLayConMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayConMain.Location = new System.Drawing.Point(0, 69);
            this.dataLayConMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayConMain.Name = "dataLayConMain";
            this.dataLayConMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 87, 650, 400);
            this.dataLayConMain.OptionsFocus.EnableAutoTabOrder = false;
            this.dataLayConMain.OptionsView.AllowExpandAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.dataLayConMain.OptionsView.AutoSizeInLayoutControl = DevExpress.XtraLayout.AutoSizeModes.UseMinAndMaxSize;
            this.dataLayConMain.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayConMain.Root = this.layoutControlGroup1;
            this.dataLayConMain.Size = new System.Drawing.Size(1414, 804);
            this.dataLayConMain.TabIndex = 0;
            this.dataLayConMain.Text = "dataLayoutControl1";
            // 
            // bindingNavigator11
            // 
            this.bindingNavigator11.AddNewItem = this.bbiNewInvoice;
            this.bindingNavigator11.AutoSize = false;
            this.bindingNavigator11.CountItem = null;
            this.bindingNavigator11.DeleteItem = null;
            this.bindingNavigator11.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator11.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbiSave,
            this.toolStripSeparator10,
            this.bbiSaveAndNew,
            this.toolStripSeparator5,
            this.bbiClose,
            this.toolStripSeparator1,
            this.bbiReset,
            this.toolStripSeparator4,
            this.bbiPrintPrevious,
            this.toolStripSeparator11,
            this.bbiPrint1,
            this.toolStripSeparator6,
            this.bbiNewInvoice,
            this.toolStripSeparator8,
            this.bbiUpdateInvvoice,
            this.toolStripSeparator12,
            this.bbiSelect,
            this.toolStripSeparator7,
            this.bbiPrdPrice,
            this.toolStripSeparator2,
            this.bbiEditPrice,
            this.toolStripSeparator13,
            this.bbiEditQuantity,
            this.toolStripSeparator9,
            this.bbiSaveAndNewNoPrint,
            this.toolStripSeparator3,
            this.bsiPaidCreditShortcut,
            this.toolStripSeparator14,
            this.toolStripButton3});
            this.bindingNavigator11.Location = new System.Drawing.Point(2, 2);
            this.bindingNavigator11.MaximumSize = new System.Drawing.Size(0, 75);
            this.bindingNavigator11.MinimumSize = new System.Drawing.Size(0, 60);
            this.bindingNavigator11.MoveFirstItem = null;
            this.bindingNavigator11.MoveLastItem = null;
            this.bindingNavigator11.MoveNextItem = null;
            this.bindingNavigator11.MovePreviousItem = null;
            this.bindingNavigator11.Name = "bindingNavigator11";
            this.bindingNavigator11.PositionItem = null;
            this.bindingNavigator11.Size = new System.Drawing.Size(1410, 62);
            this.bindingNavigator11.TabIndex = 20;
            this.bindingNavigator11.Text = "bindingNavigator2";
            // 
            // bbiNewInvoice
            // 
            this.bbiNewInvoice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiNewInvoice.ForeColor = System.Drawing.Color.Black;
            this.bbiNewInvoice.Image = global::PosFinalCost.Properties.Resources.add_32x32;
            this.bbiNewInvoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiNewInvoice.Name = "bbiNewInvoice";
            this.bbiNewInvoice.RightToLeftAutoMirrorImage = true;
            this.bbiNewInvoice.Size = new System.Drawing.Size(122, 59);
            this.bbiNewInvoice.Text = " فاتورة جديدة(F1)";
            this.bbiNewInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bbiSave
            // 
            this.bbiSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiSave.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.Image")));
            this.bbiSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.Size = new System.Drawing.Size(68, 59);
            this.bbiSave.Text = "حفظ(F4)";
            this.bbiSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiSave.Click += new System.EventHandler(this.bbiSave_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiSaveAndNew.ForeColor = System.Drawing.Color.Black;
            this.bbiSaveAndNew.Image = global::PosFinalCost.Properties.Resources.saveandnew_32x32;
            this.bbiSaveAndNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiSaveAndNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.Size = new System.Drawing.Size(150, 59);
            this.bbiSaveAndNew.Text = "حفظ و إنشاء جديد(F3)";
            this.bbiSaveAndNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiSaveAndNew.Click += new System.EventHandler(this.bbiSaveAndNew_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiClose
            // 
            this.bbiClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiClose.ForeColor = System.Drawing.Color.Black;
            this.bbiClose.Image = global::PosFinalCost.Properties.Resources.close_32x32;
            this.bbiClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.RightToLeftAutoMirrorImage = true;
            this.bbiClose.Size = new System.Drawing.Size(49, 59);
            this.bbiClose.Text = "Close";
            this.bbiClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiClose.Click += new System.EventHandler(this.bbiClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiReset
            // 
            this.bbiReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiReset.ForeColor = System.Drawing.Color.Black;
            this.bbiReset.Image = global::PosFinalCost.Properties.Resources.reset_32x32;
            this.bbiReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.Size = new System.Drawing.Size(115, 59);
            this.bbiReset.Text = "إعادة التهيئه(F5)";
            this.bbiReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiReset.Click += new System.EventHandler(this.bbiReset_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiPrintPrevious
            // 
            this.bbiPrintPrevious.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiPrintPrevious.ForeColor = System.Drawing.Color.Black;
            this.bbiPrintPrevious.Image = global::PosFinalCost.Properties.Resources.report_32x32;
            this.bbiPrintPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiPrintPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiPrintPrevious.Name = "bbiPrintPrevious";
            this.bbiPrintPrevious.Size = new System.Drawing.Size(154, 59);
            this.bbiPrintPrevious.Text = "طباعة الفاتورة السابقة";
            this.bbiPrintPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiPrintPrevious.Click += new System.EventHandler(this.bbiPrintPrevious_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiPrint1
            // 
            this.bbiPrint1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiPrint1.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrint1.Image")));
            this.bbiPrint1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiPrint1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiPrint1.Name = "bbiPrint1";
            this.bbiPrint1.Size = new System.Drawing.Size(52, 59);
            this.bbiPrint1.Text = "طباعة";
            this.bbiPrint1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiPrint1.Click += new System.EventHandler(this.bbiPrint1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 62);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiUpdateInvvoice
            // 
            this.bbiUpdateInvvoice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bbiUpdateInvvoice.ForeColor = System.Drawing.Color.Black;
            this.bbiUpdateInvvoice.Image = global::PosFinalCost.Properties.Resources.editcontact_32x32;
            this.bbiUpdateInvvoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiUpdateInvvoice.Name = "bbiUpdateInvvoice";
            this.bbiUpdateInvvoice.RightToLeftAutoMirrorImage = true;
            this.bbiUpdateInvvoice.Size = new System.Drawing.Size(176, 59);
            this.bbiUpdateInvvoice.Text = "تعديل فاتورة المبيعات(F9)";
            this.bbiUpdateInvvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiUpdateInvvoice.Click += new System.EventHandler(this.bbiUpdateInvvoice_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiSelect
            // 
            this.bbiSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiSelect.Image = global::PosFinalCost.Properties.Resources.apply_32x321;
            this.bbiSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.Size = new System.Drawing.Size(48, 59);
            this.bbiSelect.Text = "تحديد";
            this.bbiSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiSelect.Click += new System.EventHandler(this.bbiSelect_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiPrdPrice
            // 
            this.bbiPrdPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiPrdPrice.Name = "bbiPrdPrice";
            this.bbiPrdPrice.Size = new System.Drawing.Size(79, 59);
            this.bbiPrdPrice.Text = "عرض سعر\r\nالشراء(F8)";
            this.bbiPrdPrice.Click += new System.EventHandler(this.bbiPrdPrice1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiEditPrice
            // 
            this.bbiEditPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiEditPrice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiEditPrice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiEditPrice.Name = "bbiEditPrice";
            this.bbiEditPrice.Size = new System.Drawing.Size(75, 59);
            this.bbiEditPrice.Text = "تعديل\r\nالسعر(F7)";
            this.bbiEditPrice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiEditPrice.Click += new System.EventHandler(this.bbiEditPrice1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiEditQuantity
            // 
            this.bbiEditQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiEditQuantity.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiEditQuantity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiEditQuantity.Name = "bbiEditQuantity";
            this.bbiEditQuantity.Size = new System.Drawing.Size(77, 59);
            this.bbiEditQuantity.Text = "تعديل\r\nالكمية(F6)";
            this.bbiEditQuantity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiEditQuantity.Click += new System.EventHandler(this.bbiEditQuantity1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 62);
            // 
            // bbiSaveAndNewNoPrint
            // 
            this.bbiSaveAndNewNoPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bbiSaveAndNewNoPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbiSaveAndNewNoPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbiSaveAndNewNoPrint.Name = "bbiSaveAndNewNoPrint";
            this.bbiSaveAndNewNoPrint.Size = new System.Drawing.Size(120, 59);
            this.bbiSaveAndNewNoPrint.Text = "حفظ وإضافة\r\nبدون طباعه(F12)";
            this.bbiSaveAndNewNoPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bbiSaveAndNewNoPrint.Click += new System.EventHandler(this.bbiSaveAndNewNoPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 62);
            // 
            // bsiPaidCreditShortcut
            // 
            this.bsiPaidCreditShortcut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bsiPaidCreditShortcut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bsiPaidCreditShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bsiPaidCreditShortcut.Name = "bsiPaidCreditShortcut";
            this.bsiPaidCreditShortcut.Size = new System.Drawing.Size(80, 44);
            this.bsiPaidCreditShortcut.Text = "المدفوع\nشبكة(F11)";
            this.bsiPaidCreditShortcut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bsiPaidCreditShortcut.Click += new System.EventHandler(this.bsiPaidCreditShortcut1_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 60);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(118, 24);
            this.toolStripButton3.Text = "تعديل الكمية(F6)";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.SupplySubBindingSource;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Font = new System.Drawing.Font("Tahoma", 10F);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(14, 181);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEditQuan,
            this.repositoryItemCalcEdit1SalePrice,
            this.repositoryItemLookUpEditMeasurment,
            this.repositoryItemSearchLookUpEditPrdNo,
            this.repositoryItemTextEditDesc,
            this.repositoryItemLookUpEditProName});
            this.gridControl.Size = new System.Drawing.Size(1386, 350);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // SupplySubBindingSource
            // 
            this.SupplySubBindingSource.DataSource = typeof(PosFinalCost.SupplySub);
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupPrdNo,
            this.colsupPrdName,
            this.colMsur,
            this.colCurrency,
            this.colsupPrice,
            this.colQuanMain,
            this.colsupSalePrice,
            this.colsupTaxPercent,
            this.colTaxPrice,
            this.colsupDesc,
            this.colTotalPrice,
            this.colPrdManufacture,
            this.colsupDscntPercent,
            this.colDscntAmount,
            this.colid,
            this.colsupNo,
            this.colsupPrdBarcode,
            this.colprdQuanAvlb,
            this.colCount,
            this.colFinalAmount,
            this.colWidth,
            this.colHeight,
            this.colMeter,
            this.col_SubNoPacks,
            this.colsupOvertime,
            this.colsupWorkingtime});
            this.gridView.DetailHeight = 400;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsFind.AllowFindPanel = false;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colsupPrdNo
            // 
            this.colsupPrdNo.Caption = "رقم الصنف";
            this.colsupPrdNo.ColumnEdit = this.repositoryItemSearchLookUpEditPrdNo;
            this.colsupPrdNo.CustomizationCaption = "رقم الصنف";
            this.colsupPrdNo.FieldName = "PrdId";
            this.colsupPrdNo.Name = "colsupPrdNo";
            this.colsupPrdNo.Visible = true;
            this.colsupPrdNo.VisibleIndex = 2;
            this.colsupPrdNo.Width = 107;
            // 
            // repositoryItemSearchLookUpEditPrdNo
            // 
            this.repositoryItemSearchLookUpEditPrdNo.AutoHeight = false;
            this.repositoryItemSearchLookUpEditPrdNo.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemSearchLookUpEditPrdNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEditPrdNo.DataSource = this.ProductBindingSource;
            this.repositoryItemSearchLookUpEditPrdNo.DisplayMember = "No";
            this.repositoryItemSearchLookUpEditPrdNo.Name = "repositoryItemSearchLookUpEditPrdNo";
            this.repositoryItemSearchLookUpEditPrdNo.NullText = "";
            this.repositoryItemSearchLookUpEditPrdNo.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.repositoryItemSearchLookUpEditPrdNo.ValueMember = "ID";
            // 
            // ProductBindingSource
            // 
            this.ProductBindingSource.DataSource = typeof(PosFinalCost.Product);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colprdId,
            this.colprdNo,
            this.colprdName,
            this.colprdSalePrice,
            this.colprdNameEng,
            this.colprdGrpNo});
            this.repositoryItemSearchLookUpEdit1View.DetailHeight = 400;
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colprdId
            // 
            this.colprdId.FieldName = "ID";
            this.colprdId.Name = "colprdId";
            // 
            // colprdNo
            // 
            this.colprdNo.Caption = "رقم الصنف";
            this.colprdNo.FieldName = "No";
            this.colprdNo.MaxWidth = 150;
            this.colprdNo.Name = "colprdNo";
            this.colprdNo.Visible = true;
            this.colprdNo.VisibleIndex = 0;
            this.colprdNo.Width = 80;
            // 
            // colprdName
            // 
            this.colprdName.Caption = "إسم الصنف";
            this.colprdName.FieldName = "Name";
            this.colprdName.Name = "colprdName";
            this.colprdName.Visible = true;
            this.colprdName.VisibleIndex = 1;
            this.colprdName.Width = 240;
            // 
            // colprdSalePrice
            // 
            this.colprdSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colprdSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colprdSalePrice.Caption = "سعر البيع";
            this.colprdSalePrice.FieldName = "colPrdSalePrice";
            this.colprdSalePrice.MaxWidth = 100;
            this.colprdSalePrice.Name = "colprdSalePrice";
            this.colprdSalePrice.OptionsColumn.AllowIncrementalSearch = false;
            this.colprdSalePrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colprdSalePrice.Visible = true;
            this.colprdSalePrice.VisibleIndex = 2;
            this.colprdSalePrice.Width = 80;
            // 
            // colprdNameEng
            // 
            this.colprdNameEng.FieldName = "NameEng";
            this.colprdNameEng.Name = "colprdNameEng";
            // 
            // colprdGrpNo
            // 
            this.colprdGrpNo.FieldName = "GrpNo";
            this.colprdGrpNo.Name = "colprdGrpNo";
            // 
            // colsupPrdName
            // 
            this.colsupPrdName.Caption = "إسم الصنف";
            this.colsupPrdName.ColumnEdit = this.repositoryItemLookUpEditProName;
            this.colsupPrdName.CustomizationCaption = "إسم الصنف";
            this.colsupPrdName.FieldName = "PrdId";
            this.colsupPrdName.Name = "colsupPrdName";
            this.colsupPrdName.OptionsColumn.AllowEdit = false;
            this.colsupPrdName.OptionsColumn.AllowFocus = false;
            this.colsupPrdName.OptionsColumn.ReadOnly = true;
            this.colsupPrdName.OptionsColumn.TabStop = false;
            this.colsupPrdName.Visible = true;
            this.colsupPrdName.VisibleIndex = 3;
            this.colsupPrdName.Width = 110;
            // 
            // repositoryItemLookUpEditProName
            // 
            this.repositoryItemLookUpEditProName.AutoHeight = false;
            this.repositoryItemLookUpEditProName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditProName.DataSource = this.ProductBindingSource;
            this.repositoryItemLookUpEditProName.DisplayMember = "Name";
            this.repositoryItemLookUpEditProName.Name = "repositoryItemLookUpEditProName";
            this.repositoryItemLookUpEditProName.NullText = "";
            this.repositoryItemLookUpEditProName.ValueMember = "ID";
            // 
            // colMsur
            // 
            this.colMsur.AppearanceCell.Options.UseTextOptions = true;
            this.colMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMsur.Caption = "وحدة القياس";
            this.colMsur.ColumnEdit = this.repositoryItemLookUpEditMeasurment;
            this.colMsur.CustomizationCaption = "وحدة القياس";
            this.colMsur.FieldName = "Msur";
            this.colMsur.Name = "colMsur";
            this.colMsur.Visible = true;
            this.colMsur.VisibleIndex = 4;
            this.colMsur.Width = 118;
            // 
            // repositoryItemLookUpEditMeasurment
            // 
            this.repositoryItemLookUpEditMeasurment.AutoHeight = false;
            this.repositoryItemLookUpEditMeasurment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditMeasurment.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "وحدة القياس")});
            this.repositoryItemLookUpEditMeasurment.DataSource = this.PrdMeasurmentBindingSource;
            this.repositoryItemLookUpEditMeasurment.DisplayMember = "Name";
            this.repositoryItemLookUpEditMeasurment.Name = "repositoryItemLookUpEditMeasurment";
            this.repositoryItemLookUpEditMeasurment.NullText = "";
            this.repositoryItemLookUpEditMeasurment.ValueMember = "ID";
            // 
            // PrdMeasurmentBindingSource
            // 
            this.PrdMeasurmentBindingSource.DataSource = typeof(PosFinalCost.PrdMeasurment);
            // 
            // colCurrency
            // 
            this.colCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCurrency.Caption = "العملة";
            this.colCurrency.CustomizationCaption = "العملة";
            this.colCurrency.FieldName = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.OptionsColumn.AllowEdit = false;
            this.colCurrency.OptionsColumn.AllowFocus = false;
            this.colCurrency.OptionsColumn.ShowInExpressionEditor = false;
            this.colCurrency.OptionsColumn.TabStop = false;
            this.colCurrency.Width = 72;
            // 
            // colsupPrice
            // 
            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupPrice.Caption = "سعر الشراء";
            this.colsupPrice.CustomizationCaption = "سعر الشراء";
            this.colsupPrice.DisplayFormat.FormatString = "f2";
            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupPrice.FieldName = "BuyPrice";
            this.colsupPrice.Name = "colsupPrice";
            this.colsupPrice.Visible = true;
            this.colsupPrice.VisibleIndex = 13;
            this.colsupPrice.Width = 103;
            // 
            // colQuanMain
            // 
            this.colQuanMain.AppearanceCell.Options.UseTextOptions = true;
            this.colQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colQuanMain.Caption = "الكمية";
            this.colQuanMain.ColumnEdit = this.repositoryItemSpinEditQuan;
            this.colQuanMain.CustomizationCaption = "الكمية";
            this.colQuanMain.FieldName = "QuanMain";
            this.colQuanMain.Name = "colQuanMain";
            this.colQuanMain.Visible = true;
            this.colQuanMain.VisibleIndex = 5;
            this.colQuanMain.Width = 71;
            // 
            // repositoryItemSpinEditQuan
            // 
            this.repositoryItemSpinEditQuan.AutoHeight = false;
            this.repositoryItemSpinEditQuan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditQuan.Mask.EditMask = "###,###.##";
            this.repositoryItemSpinEditQuan.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            131072});
            this.repositoryItemSpinEditQuan.Name = "repositoryItemSpinEditQuan";
            // 
            // colsupSalePrice
            // 
            this.colsupSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupSalePrice.Caption = "سعر البيع";
            this.colsupSalePrice.ColumnEdit = this.repositoryItemCalcEdit1SalePrice;
            this.colsupSalePrice.CustomizationCaption = "سعر البيع";
            this.colsupSalePrice.DisplayFormat.FormatString = "N2";
            this.colsupSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupSalePrice.FieldName = "SalePrice";
            this.colsupSalePrice.Name = "colsupSalePrice";
            this.colsupSalePrice.Visible = true;
            this.colsupSalePrice.VisibleIndex = 6;
            this.colsupSalePrice.Width = 95;
            // 
            // repositoryItemCalcEdit1SalePrice
            // 
            this.repositoryItemCalcEdit1SalePrice.AutoHeight = false;
            this.repositoryItemCalcEdit1SalePrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1SalePrice.Mask.EditMask = "n4";
            this.repositoryItemCalcEdit1SalePrice.Name = "repositoryItemCalcEdit1SalePrice";
            this.repositoryItemCalcEdit1SalePrice.Precision = 2;
            this.repositoryItemCalcEdit1SalePrice.ShowCloseButton = true;
            this.repositoryItemCalcEdit1SalePrice.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.RepositoryItemCalcEdit1SalePrice_CloseUp);
            // 
            // colsupTaxPercent
            // 
            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPercent.Caption = "نسبة الضريبة";
            this.colsupTaxPercent.CustomizationCaption = "نسبة الضريبة";
            this.colsupTaxPercent.FieldName = "TaxPercent";
            this.colsupTaxPercent.Name = "colsupTaxPercent";
            this.colsupTaxPercent.OptionsColumn.AllowEdit = false;
            this.colsupTaxPercent.OptionsColumn.AllowFocus = false;
            this.colsupTaxPercent.OptionsColumn.TabStop = false;
            this.colsupTaxPercent.Visible = true;
            this.colsupTaxPercent.VisibleIndex = 7;
            this.colsupTaxPercent.Width = 122;
            // 
            // colTaxPrice
            // 
            this.colTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTaxPrice.Caption = "الضريبة";
            this.colTaxPrice.CustomizationCaption = "الضريبة";
            this.colTaxPrice.DisplayFormat.FormatString = "n2";
            this.colTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPrice.FieldName = "TaxPrice";
            this.colTaxPrice.Name = "colTaxPrice";
            this.colTaxPrice.OptionsColumn.AllowEdit = false;
            this.colTaxPrice.OptionsColumn.AllowFocus = false;
            this.colTaxPrice.OptionsColumn.TabStop = false;
            this.colTaxPrice.Visible = true;
            this.colTaxPrice.VisibleIndex = 8;
            this.colTaxPrice.Width = 82;
            // 
            // colsupDesc
            // 
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.ColumnEdit = this.repositoryItemTextEditDesc;
            this.colsupDesc.CustomizationCaption = "البيان";
            this.colsupDesc.FieldName = "Desc";
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Visible = true;
            this.colsupDesc.VisibleIndex = 11;
            this.colsupDesc.Width = 163;
            // 
            // repositoryItemTextEditDesc
            // 
            this.repositoryItemTextEditDesc.AutoHeight = false;
            this.repositoryItemTextEditDesc.MaxLength = 150;
            this.repositoryItemTextEditDesc.Name = "repositoryItemTextEditDesc";
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalPrice.Caption = "الإجمالي";
            this.colTotalPrice.CustomizationCaption = "الإجمالي";
            this.colTotalPrice.DisplayFormat.FormatString = "n2";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.FieldName = "Total";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.TabStop = false;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "SUM={0:n2}")});
            this.colTotalPrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 12;
            this.colTotalPrice.Width = 85;
            // 
            // colPrdManufacture
            // 
            this.colPrdManufacture.Caption = "صنف صناعي";
            this.colPrdManufacture.CustomizationCaption = "صنف صناعي";
            this.colPrdManufacture.FieldName = "PrdManufacture";
            this.colPrdManufacture.Name = "colPrdManufacture";
            this.colPrdManufacture.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colsupDscntPercent
            // 
            this.colsupDscntPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDscntPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDscntPercent.Caption = "نسبة الخصم";
            this.colsupDscntPercent.CustomizationCaption = "نسبة الخصم";
            this.colsupDscntPercent.DisplayFormat.FormatString = "n2";
            this.colsupDscntPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupDscntPercent.FieldName = "DscntPercent";
            this.colsupDscntPercent.Name = "colsupDscntPercent";
            this.colsupDscntPercent.Visible = true;
            this.colsupDscntPercent.VisibleIndex = 9;
            this.colsupDscntPercent.Width = 114;
            // 
            // colDscntAmount
            // 
            this.colDscntAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colDscntAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDscntAmount.Caption = "الخصم";
            this.colDscntAmount.CustomizationCaption = "الخصم";
            this.colDscntAmount.FieldName = "DscntAmount";
            this.colDscntAmount.Name = "colDscntAmount";
            this.colDscntAmount.Visible = true;
            this.colDscntAmount.VisibleIndex = 10;
            this.colDscntAmount.Width = 74;
            // 
            // colid
            // 
            this.colid.FieldName = "ID";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colsupNo
            // 
            this.colsupNo.Caption = "رقم الفاتورة";
            this.colsupNo.CustomizationCaption = "رقم الفاتورة";
            this.colsupNo.FieldName = "ParentID";
            this.colsupNo.Name = "colsupNo";
            this.colsupNo.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colsupPrdBarcode
            // 
            this.colsupPrdBarcode.Caption = "الباركود";
            this.colsupPrdBarcode.CustomizationCaption = "الباركود";
            this.colsupPrdBarcode.FieldName = "PrdBarcode";
            this.colsupPrdBarcode.Name = "colsupPrdBarcode";
            this.colsupPrdBarcode.OptionsColumn.AllowEdit = false;
            this.colsupPrdBarcode.OptionsColumn.AllowFocus = false;
            this.colsupPrdBarcode.OptionsColumn.ReadOnly = true;
            this.colsupPrdBarcode.OptionsColumn.TabStop = false;
            this.colsupPrdBarcode.Visible = true;
            this.colsupPrdBarcode.VisibleIndex = 1;
            this.colsupPrdBarcode.Width = 80;
            // 
            // colprdQuanAvlb
            // 
            this.colprdQuanAvlb.AppearanceCell.Options.UseTextOptions = true;
            this.colprdQuanAvlb.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colprdQuanAvlb.Caption = "الكمية المتوفرة";
            this.colprdQuanAvlb.CustomizationCaption = "الكمية المتوفرة";
            this.colprdQuanAvlb.FieldName = "colprdQuanAvlb";
            this.colprdQuanAvlb.Name = "colprdQuanAvlb";
            this.colprdQuanAvlb.OptionsColumn.AllowEdit = false;
            this.colprdQuanAvlb.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colCount
            // 
            this.colCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCount.Caption = "العدد";
            this.colCount.CustomizationCaption = "العدد";
            this.colCount.FieldName = "colCount";
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.ReadOnly = true;
            this.colCount.OptionsColumn.TabStop = false;
            this.colCount.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 0;
            // 
            // colFinalAmount
            // 
            this.colFinalAmount.Caption = "الاجمالي النهائي";
            this.colFinalAmount.CustomizationCaption = "الاجمالي النهائي";
            this.colFinalAmount.FieldName = "FinalAmount";
            this.colFinalAmount.Name = "colFinalAmount";
            this.colFinalAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colFinalAmount.Width = 47;
            // 
            // colWidth
            // 
            this.colWidth.Caption = "العرض";
            this.colWidth.CustomizationCaption = "العرض";
            this.colWidth.FieldName = "Width";
            this.colWidth.Name = "colWidth";
            this.colWidth.Width = 47;
            // 
            // colHeight
            // 
            this.colHeight.Caption = "الطول";
            this.colHeight.FieldName = "Height";
            this.colHeight.Name = "colHeight";
            this.colHeight.Width = 47;
            // 
            // colMeter
            // 
            this.colMeter.Caption = "الامتار";
            this.colMeter.FieldName = "QteMeter";
            this.colMeter.Name = "colMeter";
            this.colMeter.Width = 68;
            // 
            // col_SubNoPacks
            // 
            this.col_SubNoPacks.Caption = "عدد الكراتين";
            this.col_SubNoPacks.FieldName = "NoPacks";
            this.col_SubNoPacks.Name = "col_SubNoPacks";
            this.col_SubNoPacks.OptionsColumn.AllowEdit = false;
            this.col_SubNoPacks.Width = 47;
            // 
            // colsupOvertime
            // 
            this.colsupOvertime.Caption = "وقت عمل اضافي";
            this.colsupOvertime.FieldName = "Overtime";
            this.colsupOvertime.MinWidth = 25;
            this.colsupOvertime.Name = "colsupOvertime";
            this.colsupOvertime.Width = 60;
            // 
            // colsupWorkingtime
            // 
            this.colsupWorkingtime.Caption = "وقت العمل";
            this.colsupWorkingtime.FieldName = "Workingtime";
            this.colsupWorkingtime.MinWidth = 25;
            this.colsupWorkingtime.Name = "colsupWorkingtime";
            this.colsupWorkingtime.Width = 60;
            // 
            // textEditBarcodeNo
            // 
            this.textEditBarcodeNo.EditValue = "";
            this.textEditBarcodeNo.Location = new System.Drawing.Point(936, 150);
            this.textEditBarcodeNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditBarcodeNo.Name = "textEditBarcodeNo";
            this.textEditBarcodeNo.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.textEditBarcodeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.textEditBarcodeNo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEditBarcodeNo.Properties.Appearance.Options.UseBackColor = true;
            this.textEditBarcodeNo.Properties.Appearance.Options.UseFont = true;
            this.textEditBarcodeNo.Properties.Appearance.Options.UseForeColor = true;
            this.textEditBarcodeNo.Size = new System.Drawing.Size(356, 26);
            this.textEditBarcodeNo.StyleController = this.dataLayConMain;
            this.textEditBarcodeNo.TabIndex = 0;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDeleteRow.Appearance.Options.UseFont = true;
            this.btnDeleteRow.Location = new System.Drawing.Point(476, 150);
            this.btnDeleteRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(456, 27);
            this.btnDeleteRow.StyleController = this.dataLayConMain;
            this.btnDeleteRow.TabIndex = 2;
            this.btnDeleteRow.Text = "حذف";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // supDscntPercentTextEdit
            // 
            this.supDscntPercentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "DscntPercent", true));
            this.supDscntPercentTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.supDscntPercentTextEdit.Location = new System.Drawing.Point(1030, 610);
            this.supDscntPercentTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supDscntPercentTextEdit.Name = "supDscntPercentTextEdit";
            this.supDscntPercentTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.supDscntPercentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.supDscntPercentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.supDscntPercentTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.supDscntPercentTextEdit.Properties.DisplayFormat.FormatString = "n2";
            this.supDscntPercentTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.supDscntPercentTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.supDscntPercentTextEdit.Properties.Mask.BeepOnError = true;
            this.supDscntPercentTextEdit.Properties.MaskSettings.Set("mask", "n2");
            this.supDscntPercentTextEdit.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.supDscntPercentTextEdit.Size = new System.Drawing.Size(222, 24);
            this.supDscntPercentTextEdit.StyleController = this.dataLayConMain;
            this.supDscntPercentTextEdit.TabIndex = 7;
            // 
            // SupplyMainBindingSource
            // 
            this.SupplyMainBindingSource.DataSource = typeof(PosFinalCost.SupplyMain);
            // 
            // DscntAmountTextEdit
            // 
            this.DscntAmountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "DscntAmount", true));
            this.DscntAmountTextEdit.Location = new System.Drawing.Point(1030, 638);
            this.DscntAmountTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DscntAmountTextEdit.Name = "DscntAmountTextEdit";
            this.DscntAmountTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.DscntAmountTextEdit.Properties.Mask.BeepOnError = true;
            this.DscntAmountTextEdit.Properties.Mask.EditMask = "N2";
            this.DscntAmountTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.DscntAmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DscntAmountTextEdit.Size = new System.Drawing.Size(222, 22);
            this.DscntAmountTextEdit.StyleController = this.dataLayConMain;
            this.DscntAmountTextEdit.TabIndex = 8;
            // 
            // txtdisround
            // 
            this.txtdisround.Location = new System.Drawing.Point(787, 641);
            this.txtdisround.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdisround.Name = "txtdisround";
            this.txtdisround.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtdisround.Properties.Mask.BeepOnError = true;
            this.txtdisround.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtdisround.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtdisround.Size = new System.Drawing.Size(91, 22);
            this.txtdisround.StyleController = this.dataLayConMain;
            this.txtdisround.TabIndex = 9;
            this.txtdisround.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Txtdisround_ButtonClick);
            this.txtdisround.EditValueChanged += new System.EventHandler(this.Txtdisround_EditValueChanged);
            // 
            // spinEditMonyFinal
            // 
            this.spinEditMonyFinal.EditValue = "";
            this.spinEditMonyFinal.Location = new System.Drawing.Point(787, 667);
            this.spinEditMonyFinal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEditMonyFinal.Name = "spinEditMonyFinal";
            this.spinEditMonyFinal.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEditMonyFinal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEditMonyFinal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.spinEditMonyFinal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.spinEditMonyFinal.Size = new System.Drawing.Size(465, 22);
            this.spinEditMonyFinal.StyleController = this.dataLayConMain;
            this.spinEditMonyFinal.TabIndex = 10;
            this.spinEditMonyFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spinEditMonyFinal_KeyDown);
            // 
            // BtnDscnFraction
            // 
            this.BtnDscnFraction.Location = new System.Drawing.Point(908, 610);
            this.BtnDscnFraction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDscnFraction.Name = "BtnDscnFraction";
            this.BtnDscnFraction.Size = new System.Drawing.Size(118, 27);
            this.BtnDscnFraction.StyleController = this.dataLayConMain;
            this.BtnDscnFraction.TabIndex = 14;
            this.BtnDscnFraction.Text = "خصم الكسور";
            this.BtnDscnFraction.Click += new System.EventHandler(this.BtnDscnFraction_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(787, 610);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(117, 27);
            this.simpleButton2.StyleController = this.dataLayConMain;
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "اضافة الكسور";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // textEditPaidCreditCard
            // 
            this.textEditPaidCreditCard.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "BankAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditPaidCreditCard.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textEditPaidCreditCard.Location = new System.Drawing.Point(1173, 743);
            this.textEditPaidCreditCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditPaidCreditCard.Name = "textEditPaidCreditCard";
            this.textEditPaidCreditCard.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditPaidCreditCard.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.textEditPaidCreditCard.Properties.Mask.BeepOnError = true;
            this.textEditPaidCreditCard.Properties.Mask.EditMask = "n2";
            this.textEditPaidCreditCard.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditPaidCreditCard.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEditPaidCreditCard.Size = new System.Drawing.Size(79, 22);
            this.textEditPaidCreditCard.StyleController = this.dataLayConMain;
            this.textEditPaidCreditCard.TabIndex = 5;
            // 
            // textEditPaidCash
            // 
            this.textEditPaidCash.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "paidCash", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditPaidCash.Location = new System.Drawing.Point(787, 717);
            this.textEditPaidCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditPaidCash.Name = "textEditPaidCash";
            this.textEditPaidCash.Properties.Mask.BeepOnError = true;
            this.textEditPaidCash.Properties.Mask.EditMask = "n2";
            this.textEditPaidCash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditPaidCash.Size = new System.Drawing.Size(465, 22);
            this.textEditPaidCash.StyleController = this.dataLayConMain;
            this.textEditPaidCash.TabIndex = 4;
            // 
            // btnECRsend
            // 
            this.btnECRsend.Location = new System.Drawing.Point(1061, 743);
            this.btnECRsend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnECRsend.Name = "btnECRsend";
            this.btnECRsend.Size = new System.Drawing.Size(108, 27);
            this.btnECRsend.StyleController = this.dataLayConMain;
            this.btnECRsend.TabIndex = 12;
            this.btnECRsend.Text = "إرسال";
            this.btnECRsend.Click += new System.EventHandler(this.btnECRsend_Click);
            // 
            // btnECRcancel
            // 
            this.btnECRcancel.Location = new System.Drawing.Point(787, 743);
            this.btnECRcancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnECRcancel.Name = "btnECRcancel";
            this.btnECRcancel.Size = new System.Drawing.Size(270, 27);
            this.btnECRcancel.StyleController = this.dataLayConMain;
            this.btnECRcancel.TabIndex = 13;
            this.btnECRcancel.Text = "إلغاء";
            this.btnECRcancel.Click += new System.EventHandler(this.btnECRcancel_Click);
            // 
            // spinEditTotalFinalDecimal
            // 
            this.spinEditTotalFinalDecimal.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Net", true));
            this.spinEditTotalFinalDecimal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditTotalFinalDecimal.Location = new System.Drawing.Point(15, 740);
            this.spinEditTotalFinalDecimal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEditTotalFinalDecimal.Name = "spinEditTotalFinalDecimal";
            this.spinEditTotalFinalDecimal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinEditTotalFinalDecimal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.spinEditTotalFinalDecimal.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spinEditTotalFinalDecimal.Properties.Appearance.Options.UseFont = true;
            this.spinEditTotalFinalDecimal.Properties.Appearance.Options.UseForeColor = true;
            this.spinEditTotalFinalDecimal.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEditTotalFinalDecimal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spinEditTotalFinalDecimal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.spinEditTotalFinalDecimal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditTotalFinalDecimal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditTotalFinalDecimal.Properties.MaskSettings.Set("mask", "f2");
            this.spinEditTotalFinalDecimal.Properties.ReadOnly = true;
            this.spinEditTotalFinalDecimal.Size = new System.Drawing.Size(550, 46);
            this.spinEditTotalFinalDecimal.StyleController = this.dataLayConMain;
            this.spinEditTotalFinalDecimal.TabIndex = 11;
            // 
            // labelTotalPriceDecimal
            // 
            this.labelTotalPriceDecimal.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Total", true));
            this.labelTotalPriceDecimal.EditValue = "";
            this.labelTotalPriceDecimal.Location = new System.Drawing.Point(15, 604);
            this.labelTotalPriceDecimal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalPriceDecimal.Name = "labelTotalPriceDecimal";
            this.labelTotalPriceDecimal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalPriceDecimal.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelTotalPriceDecimal.Properties.Appearance.Options.UseFont = true;
            this.labelTotalPriceDecimal.Properties.Appearance.Options.UseForeColor = true;
            this.labelTotalPriceDecimal.Properties.Appearance.Options.UseTextOptions = true;
            this.labelTotalPriceDecimal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelTotalPriceDecimal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelTotalPriceDecimal.Properties.DisplayFormat.FormatString = "n2";
            this.labelTotalPriceDecimal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.labelTotalPriceDecimal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.labelTotalPriceDecimal.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.labelTotalPriceDecimal.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.labelTotalPriceDecimal.Properties.MaskSettings.Set("mask", "n");
            this.labelTotalPriceDecimal.Size = new System.Drawing.Size(595, 30);
            this.labelTotalPriceDecimal.StyleController = this.dataLayConMain;
            this.labelTotalPriceDecimal.TabIndex = 10;
            // 
            // labelDiscountDecimal
            // 
            this.labelDiscountDecimal.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "DscntAmount", true));
            this.labelDiscountDecimal.EditValue = "";
            this.labelDiscountDecimal.Location = new System.Drawing.Point(15, 638);
            this.labelDiscountDecimal.Margin = new System.Windows.Forms.Padding(0);
            this.labelDiscountDecimal.Name = "labelDiscountDecimal";
            this.labelDiscountDecimal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.labelDiscountDecimal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelDiscountDecimal.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelDiscountDecimal.Properties.Appearance.Options.UseFont = true;
            this.labelDiscountDecimal.Properties.Appearance.Options.UseForeColor = true;
            this.labelDiscountDecimal.Properties.Appearance.Options.UseTextOptions = true;
            this.labelDiscountDecimal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelDiscountDecimal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelDiscountDecimal.Properties.DisplayFormat.FormatString = "n2";
            this.labelDiscountDecimal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.labelDiscountDecimal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.labelDiscountDecimal.Size = new System.Drawing.Size(595, 30);
            this.labelDiscountDecimal.StyleController = this.dataLayConMain;
            this.labelDiscountDecimal.TabIndex = 10;
            // 
            // labelTotalTaxDecimal
            // 
            this.labelTotalTaxDecimal.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "TaxPrice", true));
            this.labelTotalTaxDecimal.EditValue = "";
            this.labelTotalTaxDecimal.Location = new System.Drawing.Point(15, 706);
            this.labelTotalTaxDecimal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalTaxDecimal.Name = "labelTotalTaxDecimal";
            this.labelTotalTaxDecimal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.labelTotalTaxDecimal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalTaxDecimal.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelTotalTaxDecimal.Properties.Appearance.Options.UseFont = true;
            this.labelTotalTaxDecimal.Properties.Appearance.Options.UseForeColor = true;
            this.labelTotalTaxDecimal.Properties.Appearance.Options.UseTextOptions = true;
            this.labelTotalTaxDecimal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelTotalTaxDecimal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelTotalTaxDecimal.Properties.DisplayFormat.FormatString = "n2";
            this.labelTotalTaxDecimal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.labelTotalTaxDecimal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.labelTotalTaxDecimal.Size = new System.Drawing.Size(595, 30);
            this.labelTotalTaxDecimal.StyleController = this.dataLayConMain;
            this.labelTotalTaxDecimal.TabIndex = 10;
            // 
            // labelTotalDecimal
            // 
            this.labelTotalDecimal.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "TotalAfterDiscount", true));
            this.labelTotalDecimal.EditValue = "";
            this.labelTotalDecimal.Location = new System.Drawing.Point(15, 672);
            this.labelTotalDecimal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalDecimal.Name = "labelTotalDecimal";
            this.labelTotalDecimal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.labelTotalDecimal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalDecimal.Properties.Appearance.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelTotalDecimal.Properties.Appearance.Options.UseFont = true;
            this.labelTotalDecimal.Properties.Appearance.Options.UseForeColor = true;
            this.labelTotalDecimal.Properties.Appearance.Options.UseTextOptions = true;
            this.labelTotalDecimal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelTotalDecimal.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelTotalDecimal.Properties.DisplayFormat.FormatString = "n2";
            this.labelTotalDecimal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.labelTotalDecimal.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.labelTotalDecimal.Size = new System.Drawing.Size(595, 30);
            this.labelTotalDecimal.StyleController = this.dataLayConMain;
            this.labelTotalDecimal.TabIndex = 10;
            // 
            // supNoTextEdit
            // 
            this.supNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "No", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.supNoTextEdit.Enabled = false;
            this.supNoTextEdit.Location = new System.Drawing.Point(1055, 95);
            this.supNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supNoTextEdit.Name = "supNoTextEdit";
            this.supNoTextEdit.Properties.Mask.BeepOnError = true;
            this.supNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.supNoTextEdit.Properties.ReadOnly = true;
            this.supNoTextEdit.Properties.UseReadOnlyAppearance = false;
            this.supNoTextEdit.Size = new System.Drawing.Size(203, 22);
            this.supNoTextEdit.StyleController = this.dataLayConMain;
            this.supNoTextEdit.TabIndex = 4;
            // 
            // radioGroupIsCash
            // 
            this.radioGroupIsCash.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "IsCash", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioGroupIsCash.Location = new System.Drawing.Point(705, 95);
            this.radioGroupIsCash.Margin = new System.Windows.Forms.Padding(0);
            this.radioGroupIsCash.Name = "radioGroupIsCash";
            this.radioGroupIsCash.Properties.Columns = 3;
            this.radioGroupIsCash.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "نقدا"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(2)), "آجل"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(3)), "شبكة")});
            this.radioGroupIsCash.Properties.Padding = new System.Windows.Forms.Padding(0);
            this.radioGroupIsCash.Size = new System.Drawing.Size(198, 23);
            this.radioGroupIsCash.StyleController = this.dataLayConMain;
            this.radioGroupIsCash.TabIndex = 19;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(2, 203);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "تقريب الاجمالي النهائي";
            this.checkEdit1.Size = new System.Drawing.Size(699, 24);
            this.checkEdit1.StyleController = this.dataLayConMain;
            this.checkEdit1.TabIndex = 15;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // textEditCounterNumber
            // 
            this.textEditCounterNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "CounterNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditCounterNumber.Location = new System.Drawing.Point(14, 274);
            this.textEditCounterNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditCounterNumber.Name = "textEditCounterNumber";
            this.textEditCounterNumber.Size = new System.Drawing.Size(309, 22);
            this.textEditCounterNumber.StyleController = this.dataLayConMain;
            this.textEditCounterNumber.TabIndex = 14;
            // 
            // textEditPlateNumber
            // 
            this.textEditPlateNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "PlateNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditPlateNumber.Location = new System.Drawing.Point(475, 274);
            this.textEditPlateNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditPlateNumber.Name = "textEditPlateNumber";
            this.textEditPlateNumber.Size = new System.Drawing.Size(306, 22);
            this.textEditPlateNumber.StyleController = this.dataLayConMain;
            this.textEditPlateNumber.TabIndex = 13;
            // 
            // textEditCarType
            // 
            this.textEditCarType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "CarType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditCarType.Location = new System.Drawing.Point(933, 274);
            this.textEditCarType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditCarType.Name = "textEditCarType";
            this.textEditCarType.Size = new System.Drawing.Size(313, 22);
            this.textEditCarType.StyleController = this.dataLayConMain;
            this.textEditCarType.TabIndex = 12;
            // 
            // supRefNoTextEdit
            // 
            this.supRefNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "RefNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.supRefNoTextEdit.Location = new System.Drawing.Point(1055, 176);
            this.supRefNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supRefNoTextEdit.Name = "supRefNoTextEdit";
            this.supRefNoTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.supRefNoTextEdit.Properties.Mask.BeepOnError = true;
            this.supRefNoTextEdit.Properties.Mask.EditMask = "f0";
            this.supRefNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.supRefNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.supRefNoTextEdit.Size = new System.Drawing.Size(203, 22);
            this.supRefNoTextEdit.StyleController = this.dataLayConMain;
            this.supRefNoTextEdit.TabIndex = 5;
            // 
            // supDescTextEdit
            // 
            this.supDescTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Desc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.supDescTextEdit.Location = new System.Drawing.Point(352, 176);
            this.supDescTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supDescTextEdit.Name = "supDescTextEdit";
            this.supDescTextEdit.Properties.MaxLength = 100;
            this.supDescTextEdit.Size = new System.Drawing.Size(201, 22);
            this.supDescTextEdit.StyleController = this.dataLayConMain;
            this.supDescTextEdit.TabIndex = 7;
            // 
            // DateDateEdit
            // 
            this.DateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DateDateEdit.EditValue = null;
            this.DateDateEdit.Location = new System.Drawing.Point(2, 95);
            this.DateDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateDateEdit.Name = "DateDateEdit";
            this.DateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.DateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Size = new System.Drawing.Size(198, 22);
            this.DateDateEdit.StyleController = this.dataLayConMain;
            this.DateDateEdit.TabIndex = 6;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.DateDateEdit, conditionValidationRule1);
            // 
            // BoxNoLookUpEdit
            // 
            this.BoxNoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "BoxId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BoxNoLookUpEdit.Location = new System.Drawing.Point(1055, 122);
            this.BoxNoLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BoxNoLookUpEdit.Name = "BoxNoLookUpEdit";
            this.BoxNoLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.BoxNoLookUpEdit.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.BoxNoLookUpEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.BoxNoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BoxNoLookUpEdit.Properties.NullText = "";
            this.BoxNoLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.BoxNoLookUpEdit.Size = new System.Drawing.Size(203, 22);
            this.BoxNoLookUpEdit.StyleController = this.dataLayConMain;
            this.BoxNoLookUpEdit.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.BoxNoLookUpEdit, conditionValidationRule2);
            // 
            // saleNoTextEdit
            // 
            this.saleNoTextEdit.Location = new System.Drawing.Point(2, 68);
            this.saleNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saleNoTextEdit.Name = "saleNoTextEdit";
            this.saleNoTextEdit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.saleNoTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.saleNoTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.saleNoTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("supNo", "رقم الفاتورة"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Date", "تاريخ الفاتورة", 17, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("supDesc", "البيان"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Total", "المبلغ")});
            this.saleNoTextEdit.Properties.DataSource = this.SupplyMainBindingSourceEditor;
            this.saleNoTextEdit.Properties.DisplayMember = "supNo";
            this.saleNoTextEdit.Properties.DropDownRows = 20;
            this.saleNoTextEdit.Properties.NullText = "";
            this.saleNoTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.saleNoTextEdit.Properties.ValueMember = "supNo";
            this.saleNoTextEdit.Size = new System.Drawing.Size(1256, 22);
            this.saleNoTextEdit.StyleController = this.dataLayConMain;
            this.saleNoTextEdit.TabIndex = 0;
            // 
            // SupplyMainBindingSourceEditor
            // 
            this.SupplyMainBindingSourceEditor.DataSource = typeof(PosFinalCost.SupplyMain);
            // 
            // CurrencyChngTextEdit
            // 
            this.CurrencyChngTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "CurrencyChng", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CurrencyChngTextEdit.Location = new System.Drawing.Point(2, 122);
            this.CurrencyChngTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CurrencyChngTextEdit.Name = "CurrencyChngTextEdit";
            this.CurrencyChngTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CurrencyChngTextEdit.Size = new System.Drawing.Size(198, 22);
            this.CurrencyChngTextEdit.StyleController = this.dataLayConMain;
            this.CurrencyChngTextEdit.TabIndex = 3;
            // 
            // checkEditTax
            // 
            this.checkEditTax.EditValue = true;
            this.checkEditTax.Location = new System.Drawing.Point(705, 203);
            this.checkEditTax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEditTax.Name = "checkEditTax";
            this.checkEditTax.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.checkEditTax.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.checkEditTax.Properties.Appearance.Options.UseFont = true;
            this.checkEditTax.Properties.Appearance.Options.UseForeColor = true;
            this.checkEditTax.Properties.Caption = "إضافة قيمة الضريبة";
            this.checkEditTax.Size = new System.Drawing.Size(701, 24);
            this.checkEditTax.StyleController = this.dataLayConMain;
            this.checkEditTax.TabIndex = 8;
            // 
            // supCurrTextEdit
            // 
            this.supCurrTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Currency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.supCurrTextEdit.Location = new System.Drawing.Point(352, 122);
            this.supCurrTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.supCurrTextEdit.Name = "supCurrTextEdit";
            this.supCurrTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.supCurrTextEdit.Properties.DisplayMember = "curName";
            this.supCurrTextEdit.Properties.NullText = "";
            this.supCurrTextEdit.Properties.ReadOnly = true;
            this.supCurrTextEdit.Properties.UseReadOnlyAppearance = false;
            this.supCurrTextEdit.Properties.ValueMember = "ID";
            this.supCurrTextEdit.Size = new System.Drawing.Size(201, 22);
            this.supCurrTextEdit.StyleController = this.dataLayConMain;
            this.supCurrTextEdit.TabIndex = 6;
            this.supCurrTextEdit.TabStop = false;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.supCurrTextEdit, conditionValidationRule3);
            // 
            // CustNoSearchLookUpEdit
            // 
            this.CustNoSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "CustId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CustNoSearchLookUpEdit.Location = new System.Drawing.Point(1055, 149);
            this.CustNoSearchLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CustNoSearchLookUpEdit.Name = "CustNoSearchLookUpEdit";
            this.CustNoSearchLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CustNoSearchLookUpEdit.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.CustNoSearchLookUpEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.CustNoSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.CustNoSearchLookUpEdit.Properties.DisplayMember = "Name";
            this.CustNoSearchLookUpEdit.Properties.NullText = "";
            this.CustNoSearchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.CustNoSearchLookUpEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.CustNoSearchLookUpEdit.Properties.ValueMember = "ID";
            this.CustNoSearchLookUpEdit.Size = new System.Drawing.Size(203, 22);
            this.CustNoSearchLookUpEdit.StyleController = this.dataLayConMain;
            this.CustNoSearchLookUpEdit.TabIndex = 2;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.CustNoSearchLookUpEdit, conditionValidationRule4);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcustNo1,
            this.colcustName1,
            this.colcustPhnNo1,
            this.colcustCurrency1});
            this.searchLookUpEdit1View.DetailHeight = 400;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colcustNo1
            // 
            this.colcustNo1.AppearanceCell.Options.UseTextOptions = true;
            this.colcustNo1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustNo1.Caption = "رقم العميل";
            this.colcustNo1.FieldName = "ID";
            this.colcustNo1.MaxWidth = 75;
            this.colcustNo1.Name = "colcustNo1";
            // 
            // colcustName1
            // 
            this.colcustName1.Caption = "إسم العميل";
            this.colcustName1.FieldName = "Name";
            this.colcustName1.Name = "colcustName1";
            this.colcustName1.Visible = true;
            this.colcustName1.VisibleIndex = 0;
            this.colcustName1.Width = 150;
            // 
            // colcustPhnNo1
            // 
            this.colcustPhnNo1.Caption = "رقم الهاتف";
            this.colcustPhnNo1.FieldName = "PhnNo";
            this.colcustPhnNo1.Name = "colcustPhnNo1";
            this.colcustPhnNo1.Visible = true;
            this.colcustPhnNo1.VisibleIndex = 1;
            // 
            // colcustCurrency1
            // 
            this.colcustCurrency1.Caption = "العملة";
            this.colcustCurrency1.FieldName = "Currency";
            this.colcustCurrency1.Name = "colcustCurrency1";
            // 
            // notDateTextEdit
            // 
            this.notDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "DueDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.notDateTextEdit.EditValue = null;
            this.notDateTextEdit.Location = new System.Drawing.Point(705, 149);
            this.notDateTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.notDateTextEdit.Name = "notDateTextEdit";
            this.notDateTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.notDateTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.notDateTextEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.notDateTextEdit.Properties.DisplayFormat.FormatString = "";
            this.notDateTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.notDateTextEdit.Properties.EditFormat.FormatString = "";
            this.notDateTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.notDateTextEdit.Properties.Mask.BeepOnError = true;
            this.notDateTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.notDateTextEdit.Size = new System.Drawing.Size(198, 22);
            this.notDateTextEdit.StyleController = this.dataLayConMain;
            this.notDateTextEdit.TabIndex = 16;
            // 
            // PoNumberTextEdit
            // 
            this.PoNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "PoNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PoNumberTextEdit.Location = new System.Drawing.Point(705, 176);
            this.PoNumberTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PoNumberTextEdit.Name = "PoNumberTextEdit";
            this.PoNumberTextEdit.Size = new System.Drawing.Size(198, 22);
            this.PoNumberTextEdit.StyleController = this.dataLayConMain;
            this.PoNumberTextEdit.TabIndex = 17;
            // 
            // NotesTextEdit
            // 
            this.NotesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "Notes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NotesTextEdit.Location = new System.Drawing.Point(2, 176);
            this.NotesTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NotesTextEdit.Name = "NotesTextEdit";
            this.NotesTextEdit.Size = new System.Drawing.Size(198, 22);
            this.NotesTextEdit.StyleController = this.dataLayConMain;
            this.NotesTextEdit.TabIndex = 18;
            // 
            // StrIdLookUpEdit
            // 
            this.StrIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "StrId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StrIdLookUpEdit.Location = new System.Drawing.Point(352, 95);
            this.StrIdLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StrIdLookUpEdit.Name = "StrIdLookUpEdit";
            this.StrIdLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.StrIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StrIdLookUpEdit.Properties.NullText = "";
            this.StrIdLookUpEdit.Properties.ShowHeader = false;
            this.StrIdLookUpEdit.Size = new System.Drawing.Size(201, 22);
            this.StrIdLookUpEdit.StyleController = this.dataLayConMain;
            this.StrIdLookUpEdit.TabIndex = 6;
            // 
            // BankLookUpEdit
            // 
            this.BankLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplyMainBindingSource, "BankId", true));
            this.BankLookUpEdit.Location = new System.Drawing.Point(705, 122);
            this.BankLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BankLookUpEdit.Name = "BankLookUpEdit";
            this.BankLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.BankLookUpEdit.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.BankLookUpEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.BankLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BankLookUpEdit.Properties.NullText = "";
            this.BankLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.BankLookUpEdit.Size = new System.Drawing.Size(198, 22);
            this.BankLookUpEdit.StyleController = this.dataLayConMain;
            this.BankLookUpEdit.TabIndex = 1;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider11.SetValidationRule(this.BankLookUpEdit, conditionValidationRule5);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsCustomization.AllowDrag = DevExpress.XtraLayout.ItemDragDropMode.UseParentOptions;
            this.layoutControlGroup1.OptionsCustomization.AllowDrop = DevExpress.XtraLayout.ItemDragDropMode.UseParentOptions;
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 2;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1414, 804);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGrooupMain,
            this.layoutControlGroup8,
            this.layoutControlGroup9,
            this.layoutControlGroup10,
            this.layoutControlItem3,
            this.layoutControlGroup5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "autoGeneratedGroup0";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1414, 804);
            // 
            // layoutControlGrooupMain
            // 
            this.layoutControlGrooupMain.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGrooupMain.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGrooupMain.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGrooupMain.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGrooupMain.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGrooupMain.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGrooupMain.ExpandButtonVisible = true;
            this.layoutControlGrooupMain.Expanded = false;
            this.layoutControlGrooupMain.ExpandOnDoubleClick = true;
            this.layoutControlGrooupMain.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGrooupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSalesNo,
            this.layoutControlItem1,
            this.layoutControlCarData,
            this.layoutControlItem18,
            this.layoutControlItem10,
            this.ItemForsupNo,
            this.layoutControlItem19,
            this.ItemForDate,
            this.ItemForsupCur,
            this.ItemForBoxNo,
            this.ItemForCurrencyChng,
            this.ItemForBankId,
            this.ItemForsupDesc,
            this.ItemForPoNumber,
            this.ItemForsupRefNo,
            this.ItemForNotes,
            this.ItemForsupCustNo,
            this.ItemFornotDate});
            this.layoutControlGrooupMain.Location = new System.Drawing.Point(0, 66);
            this.layoutControlGrooupMain.Name = "layoutControlGrooupMain";
            this.layoutControlGrooupMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 3, 5);
            this.layoutControlGrooupMain.Size = new System.Drawing.Size(1414, 39);
            this.layoutControlGrooupMain.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 0);
            this.layoutControlGrooupMain.Text = "البيانات الرئيسية";
            // 
            // ItemForSalesNo
            // 
            this.ItemForSalesNo.Control = this.saleNoTextEdit;
            this.ItemForSalesNo.CustomizationFormText = "رقم فاتورة المبيعات";
            this.ItemForSalesNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForSalesNo.Name = "ItemForSalesNo";
            this.ItemForSalesNo.Size = new System.Drawing.Size(1408, 27);
            this.ItemForSalesNo.Text = "فاتورة المبيعات :";
            this.ItemForSalesNo.TextSize = new System.Drawing.Size(146, 23);
            this.ItemForSalesNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEditTax;
            this.layoutControlItem1.CustomizationFormText = "إضافة قيمة الضريبة";
            this.layoutControlItem1.Location = new System.Drawing.Point(703, 135);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(705, 28);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlCarData
            // 
            this.layoutControlCarData.CustomizationFormText = "بيانات السيارة";
            this.layoutControlCarData.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlCarData.Location = new System.Drawing.Point(0, 163);
            this.layoutControlCarData.Name = "layoutControlCarData";
            this.layoutControlCarData.Size = new System.Drawing.Size(1408, 82);
            this.layoutControlCarData.Text = "بيانات السيارة";
            this.layoutControlCarData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.textEditCounterNumber;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(461, 27);
            this.layoutControlItem9.Text = "رقم العداد";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(146, 23);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.textEditCarType;
            this.layoutControlItem7.Location = new System.Drawing.Point(919, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(465, 27);
            this.layoutControlItem7.Text = "نوع السياره";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(146, 23);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.textEditPlateNumber;
            this.layoutControlItem8.Location = new System.Drawing.Point(461, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(458, 27);
            this.layoutControlItem8.Text = "رقم اللوحة";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(146, 23);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.StrIdLookUpEdit;
            this.layoutControlItem18.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem18.Location = new System.Drawing.Point(350, 27);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(353, 27);
            this.layoutControlItem18.Text = "المخزن:";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(146, 23);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.checkEdit1;
            this.layoutControlItem10.CustomizationFormText = "تقريب الاجمالي النهائي";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 135);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(703, 28);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // ItemForsupNo
            // 
            this.ItemForsupNo.Control = this.supNoTextEdit;
            this.ItemForsupNo.Location = new System.Drawing.Point(1053, 27);
            this.ItemForsupNo.Name = "ItemForsupNo";
            this.ItemForsupNo.Size = new System.Drawing.Size(355, 27);
            this.ItemForsupNo.Text = "رقم الفاتورة:";
            this.ItemForsupNo.TextSize = new System.Drawing.Size(146, 23);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.radioGroupIsCash;
            this.layoutControlItem19.Location = new System.Drawing.Point(703, 27);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(214, 27);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(350, 27);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "نوع الفاتورة:";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateDateEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 27);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(350, 27);
            this.ItemForDate.Text = "التاريخ :";
            this.ItemForDate.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForsupCur
            // 
            this.ItemForsupCur.Control = this.supCurrTextEdit;
            this.ItemForsupCur.Location = new System.Drawing.Point(350, 54);
            this.ItemForsupCur.Name = "ItemForsupCur";
            this.ItemForsupCur.Size = new System.Drawing.Size(353, 54);
            this.ItemForsupCur.Text = "العملة :";
            this.ItemForsupCur.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForBoxNo
            // 
            this.ItemForBoxNo.Control = this.BoxNoLookUpEdit;
            this.ItemForBoxNo.Location = new System.Drawing.Point(1053, 54);
            this.ItemForBoxNo.Name = "ItemForsupAccNo";
            this.ItemForBoxNo.Size = new System.Drawing.Size(355, 27);
            this.ItemForBoxNo.Text = "الصندوق:";
            this.ItemForBoxNo.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForCurrencyChng
            // 
            this.ItemForCurrencyChng.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForCurrencyChng.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.ItemForCurrencyChng.Control = this.CurrencyChngTextEdit;
            this.ItemForCurrencyChng.CustomizationFormText = "سعر الصرف";
            this.ItemForCurrencyChng.Location = new System.Drawing.Point(0, 54);
            this.ItemForCurrencyChng.MinSize = new System.Drawing.Size(153, 29);
            this.ItemForCurrencyChng.Name = "ItemForCurrencyChng";
            this.ItemForCurrencyChng.Size = new System.Drawing.Size(350, 54);
            this.ItemForCurrencyChng.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForCurrencyChng.Text = "سعر الصرف :";
            this.ItemForCurrencyChng.TextSize = new System.Drawing.Size(146, 23);
            this.ItemForCurrencyChng.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ItemForBankId
            // 
            this.ItemForBankId.Control = this.BankLookUpEdit;
            this.ItemForBankId.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForBankId.Location = new System.Drawing.Point(703, 54);
            this.ItemForBankId.Name = "ItemForBankId";
            this.ItemForBankId.Size = new System.Drawing.Size(350, 27);
            this.ItemForBankId.Text = "البنك:";
            this.ItemForBankId.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForsupDesc
            // 
            this.ItemForsupDesc.Control = this.supDescTextEdit;
            this.ItemForsupDesc.Location = new System.Drawing.Point(350, 108);
            this.ItemForsupDesc.Name = "ItemForsupDesc";
            this.ItemForsupDesc.Size = new System.Drawing.Size(353, 27);
            this.ItemForsupDesc.Text = "الاسم :";
            this.ItemForsupDesc.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForPoNumber
            // 
            this.ItemForPoNumber.Control = this.PoNumberTextEdit;
            this.ItemForPoNumber.Location = new System.Drawing.Point(703, 108);
            this.ItemForPoNumber.Name = "ItemForPoNumber";
            this.ItemForPoNumber.Size = new System.Drawing.Size(350, 27);
            this.ItemForPoNumber.Text = "رقم طلب الشراء :";
            this.ItemForPoNumber.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForsupRefNo
            // 
            this.ItemForsupRefNo.Control = this.supRefNoTextEdit;
            this.ItemForsupRefNo.Location = new System.Drawing.Point(1053, 108);
            this.ItemForsupRefNo.Name = "ItemForsupRefNo";
            this.ItemForsupRefNo.Size = new System.Drawing.Size(355, 27);
            this.ItemForsupRefNo.Text = "رقم المرجع :";
            this.ItemForsupRefNo.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForNotes
            // 
            this.ItemForNotes.Control = this.NotesTextEdit;
            this.ItemForNotes.CustomizationFormText = "ملاحظات : ";
            this.ItemForNotes.Location = new System.Drawing.Point(0, 108);
            this.ItemForNotes.Name = "ItemForNotes";
            this.ItemForNotes.Size = new System.Drawing.Size(350, 27);
            this.ItemForNotes.Text = "ملاجظات : ";
            this.ItemForNotes.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemForsupCustNo
            // 
            this.ItemForsupCustNo.Control = this.CustNoSearchLookUpEdit;
            this.ItemForsupCustNo.Location = new System.Drawing.Point(1053, 81);
            this.ItemForsupCustNo.Name = "ItemForsupCustNo";
            this.ItemForsupCustNo.Size = new System.Drawing.Size(355, 27);
            this.ItemForsupCustNo.Text = "العميل :";
            this.ItemForsupCustNo.TextSize = new System.Drawing.Size(146, 23);
            // 
            // ItemFornotDate
            // 
            this.ItemFornotDate.Control = this.notDateTextEdit;
            this.ItemFornotDate.Location = new System.Drawing.Point(703, 81);
            this.ItemFornotDate.Name = "ItemFornotDate";
            this.ItemFornotDate.Size = new System.Drawing.Size(350, 27);
            this.ItemFornotDate.Text = "تاريخ الإستحقاق:";
            this.ItemFornotDate.TextSize = new System.Drawing.Size(146, 23);
            this.ItemFornotDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup8.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.labelTotalFinalString,
            this.labelTotalPriceString,
            this.labelDiscountString,
            this.labelTotalTaxString,
            this.labelTotalString});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 565);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 3, 12);
            this.layoutControlGroup8.Size = new System.Drawing.Size(773, 239);
            this.layoutControlGroup8.Text = "الإجماليات";
            this.layoutControlGroup8.CustomDrawBackground += new System.EventHandler<DevExpress.XtraEditors.GroupBackgroundCustomDrawEventArgs>(this.layoutControlGroup8_CustomDrawBackground);
            // 
            // labelTotalFinalString
            // 
            this.labelTotalFinalString.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.labelTotalFinalString.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTotalFinalString.AppearanceItemCaption.Options.UseFont = true;
            this.labelTotalFinalString.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelTotalFinalString.Control = this.spinEditTotalFinalDecimal;
            this.labelTotalFinalString.Location = new System.Drawing.Point(0, 136);
            this.labelTotalFinalString.Name = "labelTotalFinalString";
            this.labelTotalFinalString.Size = new System.Drawing.Size(747, 51);
            this.labelTotalFinalString.Text = "الإجمالي النهائي : ";
            this.labelTotalFinalString.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.labelTotalFinalString.TextSize = new System.Drawing.Size(193, 41);
            this.labelTotalFinalString.TextToControlDistance = 0;
            // 
            // labelTotalPriceString
            // 
            this.labelTotalPriceString.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalPriceString.AppearanceItemCaption.ForeColor = System.Drawing.Color.SlateBlue;
            this.labelTotalPriceString.AppearanceItemCaption.Options.UseFont = true;
            this.labelTotalPriceString.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelTotalPriceString.Control = this.labelTotalPriceDecimal;
            this.labelTotalPriceString.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.labelTotalPriceString.Location = new System.Drawing.Point(0, 0);
            this.labelTotalPriceString.Name = "labelTotalPriceString";
            this.labelTotalPriceString.Size = new System.Drawing.Size(747, 34);
            this.labelTotalPriceString.Text = "إجمالي السعر :";
            this.labelTotalPriceString.TextSize = new System.Drawing.Size(146, 23);
            // 
            // labelDiscountString
            // 
            this.labelDiscountString.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelDiscountString.AppearanceItemCaption.ForeColor = System.Drawing.Color.SlateBlue;
            this.labelDiscountString.AppearanceItemCaption.Options.UseFont = true;
            this.labelDiscountString.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelDiscountString.Control = this.labelDiscountDecimal;
            this.labelDiscountString.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.labelDiscountString.CustomizationFormText = "الخصم :";
            this.labelDiscountString.Location = new System.Drawing.Point(0, 34);
            this.labelDiscountString.Name = "labelDiscountString";
            this.labelDiscountString.Size = new System.Drawing.Size(747, 34);
            this.labelDiscountString.Text = "الخصم :";
            this.labelDiscountString.TextSize = new System.Drawing.Size(146, 23);
            // 
            // labelTotalTaxString
            // 
            this.labelTotalTaxString.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalTaxString.AppearanceItemCaption.ForeColor = System.Drawing.Color.SlateBlue;
            this.labelTotalTaxString.AppearanceItemCaption.Options.UseFont = true;
            this.labelTotalTaxString.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelTotalTaxString.Control = this.labelTotalTaxDecimal;
            this.labelTotalTaxString.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.labelTotalTaxString.CustomizationFormText = "إجمالي الضريبة : ";
            this.labelTotalTaxString.Location = new System.Drawing.Point(0, 102);
            this.labelTotalTaxString.Name = "labelTotalTaxString";
            this.labelTotalTaxString.Size = new System.Drawing.Size(747, 34);
            this.labelTotalTaxString.Text = "إجمالي الضريبة : ";
            this.labelTotalTaxString.TextSize = new System.Drawing.Size(146, 23);
            // 
            // labelTotalString
            // 
            this.labelTotalString.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.labelTotalString.AppearanceItemCaption.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelTotalString.AppearanceItemCaption.Options.UseFont = true;
            this.labelTotalString.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelTotalString.Control = this.labelTotalDecimal;
            this.labelTotalString.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.labelTotalString.Location = new System.Drawing.Point(0, 68);
            this.labelTotalString.Name = "labelTotalString";
            this.labelTotalString.Size = new System.Drawing.Size(747, 34);
            this.labelTotalString.Text = "الإجمالي بعد الخصم :";
            this.labelTotalString.TextSize = new System.Drawing.Size(146, 25);
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForPaidCreditCard,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.itemForPaidCash,
            this.labelECR});
            this.layoutControlGroup9.Location = new System.Drawing.Point(773, 703);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Size = new System.Drawing.Size(641, 101);
            this.layoutControlGroup9.TextVisible = false;
            this.layoutControlGroup9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // itemForPaidCreditCard
            // 
            this.itemForPaidCreditCard.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.itemForPaidCreditCard.AppearanceItemCaption.Options.UseFont = true;
            this.itemForPaidCreditCard.Control = this.textEditPaidCreditCard;
            this.itemForPaidCreditCard.Location = new System.Drawing.Point(386, 26);
            this.itemForPaidCreditCard.Name = "itemForPaidCreditCard";
            this.itemForPaidCreditCard.Size = new System.Drawing.Size(231, 31);
            this.itemForPaidCreditCard.Text = "المدفوع بطاقة :";
            this.itemForPaidCreditCard.TextSize = new System.Drawing.Size(146, 22);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnECRsend;
            this.layoutControlItem11.Location = new System.Drawing.Point(274, 26);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(112, 31);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnECRcancel;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(274, 31);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // itemForPaidCash
            // 
            this.itemForPaidCash.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.itemForPaidCash.AppearanceItemCaption.Options.UseFont = true;
            this.itemForPaidCash.Control = this.textEditPaidCash;
            this.itemForPaidCash.CustomizationFormText = "المدفوع نقدا:";
            this.itemForPaidCash.Location = new System.Drawing.Point(0, 0);
            this.itemForPaidCash.Name = "itemForPaidCash";
            this.itemForPaidCash.Size = new System.Drawing.Size(617, 26);
            this.itemForPaidCash.Text = "المدفوع نقدا :";
            this.itemForPaidCash.TextSize = new System.Drawing.Size(146, 22);
            // 
            // labelECR
            // 
            this.labelECR.AllowHotTrack = false;
            this.labelECR.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelECR.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.labelECR.AppearanceItemCaption.Options.UseFont = true;
            this.labelECR.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelECR.Location = new System.Drawing.Point(0, 57);
            this.labelECR.Name = "labelECR";
            this.labelECR.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.labelECR.Size = new System.Drawing.Size(617, 20);
            this.labelECR.Text = " ";
            this.labelECR.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.labelECR.TextSize = new System.Drawing.Size(4, 20);
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.ExpandButtonVisible = true;
            this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1,
            this.ItemForBarcodeText,
            this.ItemForBtnDeleteRow,
            this.labelItemsCount,
            this.layoutControlItem2});
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 105);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.Size = new System.Drawing.Size(1414, 460);
            this.layoutControlGroup10.Text = "اصناف الفاتورة";
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.simpleLabelItem1.AppearanceItemCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 23, 3, 3);
            this.simpleLabelItem1.Size = new System.Drawing.Size(462, 31);
            this.simpleLabelItem1.Text = "بحث الأصناف: Ctrl + F";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(162, 23);
            // 
            // ItemForBarcodeText
            // 
            this.ItemForBarcodeText.Control = this.textEditBarcodeNo;
            this.ItemForBarcodeText.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForBarcodeText.CustomizationFormText = "رقم الباركود :";
            this.ItemForBarcodeText.Location = new System.Drawing.Point(922, 0);
            this.ItemForBarcodeText.Name = "ItemForBarcodeText";
            this.ItemForBarcodeText.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 30, 2, 2);
            this.ItemForBarcodeText.Size = new System.Drawing.Size(468, 31);
            this.ItemForBarcodeText.Text = "رقم الباركود :";
            this.ItemForBarcodeText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForBarcodeText.TextSize = new System.Drawing.Size(75, 17);
            this.ItemForBarcodeText.TextToControlDistance = 5;
            // 
            // ItemForBtnDeleteRow
            // 
            this.ItemForBtnDeleteRow.Control = this.btnDeleteRow;
            this.ItemForBtnDeleteRow.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForBtnDeleteRow.CustomizationFormText = "حذف";
            this.ItemForBtnDeleteRow.Location = new System.Drawing.Point(462, 0);
            this.ItemForBtnDeleteRow.Name = "ItemForBtnDeleteRow";
            this.ItemForBtnDeleteRow.Size = new System.Drawing.Size(460, 31);
            this.ItemForBtnDeleteRow.Text = "حذف";
            this.ItemForBtnDeleteRow.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForBtnDeleteRow.TextVisible = false;
            // 
            // labelItemsCount
            // 
            this.labelItemsCount.AllowHotTrack = false;
            this.labelItemsCount.AppearanceItemCaption.ForeColor = System.Drawing.Color.Green;
            this.labelItemsCount.AppearanceItemCaption.Options.UseFont = true;
            this.labelItemsCount.AppearanceItemCaption.Options.UseForeColor = true;
            this.labelItemsCount.CustomizationFormText = "عدد الأصناف : 0";
            this.labelItemsCount.Location = new System.Drawing.Point(0, 385);
            this.labelItemsCount.Name = "labelItemsCount";
            this.labelItemsCount.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 0);
            this.labelItemsCount.Size = new System.Drawing.Size(1390, 20);
            this.labelItemsCount.Text = "عدد الأصناف : 0";
            this.labelItemsCount.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl;
            this.layoutControlItem2.CustomizationFormText = "قائمة اصناف الفاتورة";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1390, 354);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bindingNavigator11;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1414, 66);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup5.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.layoutControlGroup5.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceGroup.Options.UseForeColor = true;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForsupDscntPercent,
            this.itemForDscntAmount,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(773, 565);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(641, 138);
            this.layoutControlGroup5.Text = "بيانات الخصم";
            // 
            // itemForsupDscntPercent
            // 
            this.itemForsupDscntPercent.Control = this.supDscntPercentTextEdit;
            this.itemForsupDscntPercent.Location = new System.Drawing.Point(243, 0);
            this.itemForsupDscntPercent.Name = "itemForsupDscntPercent";
            this.itemForsupDscntPercent.Size = new System.Drawing.Size(374, 28);
            this.itemForsupDscntPercent.Text = "نسبة الخصم :";
            this.itemForsupDscntPercent.TextSize = new System.Drawing.Size(146, 17);
            // 
            // itemForDscntAmount
            // 
            this.itemForDscntAmount.Control = this.DscntAmountTextEdit;
            this.itemForDscntAmount.Location = new System.Drawing.Point(243, 28);
            this.itemForDscntAmount.Name = "itemForDscntAmount";
            this.itemForDscntAmount.Size = new System.Drawing.Size(374, 29);
            this.itemForDscntAmount.Text = "مبلغ الخصم :";
            this.itemForDscntAmount.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.BtnDscnFraction;
            this.layoutControlItem13.CustomizationFormText = "خصم الكسور";
            this.layoutControlItem13.Location = new System.Drawing.Point(121, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(122, 31);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.simpleButton2;
            this.layoutControlItem14.CustomizationFormText = "اضافة الكسور";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(121, 31);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtdisround;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(243, 26);
            this.layoutControlItem4.Text = "خصم التقريب";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(146, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spinEditMonyFinal;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 57);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(617, 26);
            this.layoutControlItem5.Text = "ألمبلغ النهائي";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(146, 17);
            // 
            // gridViewCustomerSLE
            // 
            this.gridViewCustomerSLE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcstId,
            this.colcustName,
            this.colcustPhnNo,
            this.colcustNo});
            this.gridViewCustomerSLE.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewCustomerSLE.Name = "gridViewCustomerSLE";
            this.gridViewCustomerSLE.OptionsBehavior.Editable = false;
            this.gridViewCustomerSLE.OptionsBehavior.ReadOnly = true;
            this.gridViewCustomerSLE.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCustomerSLE.OptionsView.ShowGroupPanel = false;
            this.gridViewCustomerSLE.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCustomerSLE.OptionsView.ShowIndicator = false;
            // 
            // colcstId
            // 
            this.colcstId.Caption = "colcstId";
            this.colcstId.FieldName = "ID";
            this.colcstId.Name = "colcstId";
            // 
            // colcustName
            // 
            this.colcustName.Caption = "إٍسم العميل";
            this.colcustName.FieldName = "Name";
            this.colcustName.MinWidth = 150;
            this.colcustName.Name = "colcustName";
            this.colcustName.Visible = true;
            this.colcustName.VisibleIndex = 1;
            this.colcustName.Width = 150;
            // 
            // colcustPhnNo
            // 
            this.colcustPhnNo.Caption = "رقم هاتف العميل";
            this.colcustPhnNo.FieldName = "PhnNo";
            this.colcustPhnNo.Name = "colcustPhnNo";
            this.colcustPhnNo.Visible = true;
            this.colcustPhnNo.VisibleIndex = 2;
            // 
            // colcustNo
            // 
            this.colcustNo.AppearanceCell.Options.UseTextOptions = true;
            this.colcustNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustNo.Caption = "رقم العميل";
            this.colcustNo.FieldName = "No";
            this.colcustNo.MaxWidth = 75;
            this.colcustNo.Name = "colcustNo";
            this.colcustNo.Visible = true;
            this.colcustNo.VisibleIndex = 0;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidateHiddenControls = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الاجمالي النهائي";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 14;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "تعديل فاتورة المبيعات(F9)";
            this.barButtonItem6.Id = 23;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // dxValidationProvider11
            // 
            this.dxValidationProvider11.ValidateHiddenControls = false;
            // 
            // toolStripButton47
            // 
            this.toolStripButton47.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton47.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton47.Image")));
            this.toolStripButton47.Name = "toolStripButton47";
            this.toolStripButton47.RightToLeftAutoMirrorImage = true;
            this.toolStripButton47.Size = new System.Drawing.Size(29, 57);
            this.toolStripButton47.Text = "Move previous";
            // 
            // toolStripButton46
            // 
            this.toolStripButton46.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton46.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton46.Image")));
            this.toolStripButton46.Name = "toolStripButton46";
            this.toolStripButton46.RightToLeftAutoMirrorImage = true;
            this.toolStripButton46.Size = new System.Drawing.Size(29, 57);
            this.toolStripButton46.Text = "Move first";
            // 
            // toolbarFormControl1
            // 
            this.toolbarFormControl1.Location = new System.Drawing.Point(0, 69);
            this.toolbarFormControl1.Manager = this.toolbarFormManager1;
            this.toolbarFormControl1.Name = "toolbarFormControl1";
            this.toolbarFormControl1.Size = new System.Drawing.Size(1414, 0);
            this.toolbarFormControl1.TabIndex = 2;
            this.toolbarFormControl1.TabStop = false;
            this.toolbarFormControl1.TitleItemLinks.Add(this.barButtonItem1);
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            this.toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.toolbarFormManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1414, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 873);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1414, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 873);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1414, 0);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 873);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 69);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1414, 804);
            this.fluentDesignFormContainer1.TabIndex = 5;
            // 
            // tabFormControl1
            // 
            this.tabFormControl1.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl1.Name = "tabFormControl1";
            this.tabFormControl1.Pages.Add(this.tabFormPage2);
            this.tabFormControl1.Pages.Add(this.tabFormPage3);
            this.tabFormControl1.SelectedPage = this.tabFormPage2;
            this.tabFormControl1.Size = new System.Drawing.Size(1414, 69);
            this.tabFormControl1.TabForm = this;
            this.tabFormControl1.TabIndex = 10;
            this.tabFormControl1.TabStop = false;
            // 
            // tabFormPage2
            // 
            this.tabFormPage2.ContentContainer = this.tabFormContentContainer2;
            this.tabFormPage2.Name = "tabFormPage2";
            this.tabFormPage2.Text = "Page 1";
            // 
            // tabFormContentContainer2
            // 
            this.tabFormContentContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer2.Location = new System.Drawing.Point(0, 69);
            this.tabFormContentContainer2.Name = "tabFormContentContainer2";
            this.tabFormContentContainer2.Size = new System.Drawing.Size(1414, 804);
            this.tabFormContentContainer2.TabIndex = 12;
            // 
            // tabFormPage3
            // 
            this.tabFormPage3.ContentContainer = this.tabFormContentContainer3;
            this.tabFormPage3.Name = "tabFormPage3";
            this.tabFormPage3.Text = "Page 2";
            // 
            // tabFormContentContainer3
            // 
            this.tabFormContentContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer3.Location = new System.Drawing.Point(0, 69);
            this.tabFormContentContainer3.Name = "tabFormContentContainer3";
            this.tabFormContentContainer3.Size = new System.Drawing.Size(1412, 803);
            this.tabFormContentContainer3.TabIndex = 13;
            // 
            // formAddSupplyVoucher
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 873);
            this.Controls.Add(this.dataLayConMain);
            this.Controls.Add(this.toolbarFormControl1);
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.tabFormContentContainer2);
            this.Controls.Add(this.tabFormControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(851, 478);
            this.Name = "formAddSupplyVoucher";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabFormControl = this.tabFormControl1;
            this.Text = "فاتورة مبيعات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.formAddSupplyVocher_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAddSupplyVoucher_FormClosing);
            this.Load += new System.EventHandler(this.formAddSupplyVocher_Load);
            this.Shown += new System.EventHandler(this.formAddSupplyVoucher_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayConMain)).EndInit();
            this.dataLayConMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).EndInit();
            this.bindingNavigator11.ResumeLayout(false);
            this.bindingNavigator11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplySubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditPrdNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditProName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMeasurment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrdMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1SalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBarcodeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supDscntPercentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DscntAmountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdisround.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMonyFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidCreditCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTotalFinalDecimal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalPriceDecimal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDiscountDecimal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalTaxDecimal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalDecimal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupIsCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCounterNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPlateNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCarType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supRefNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supDescTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxNoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyMainBindingSourceEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyChngTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supCurrTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustNoSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notDateTextEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PoNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGrooupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSalesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCarData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupCur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBoxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencyChng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBankId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPoNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupRefNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupCustNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFornotDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalFinalString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalPriceString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelDiscountString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalTaxString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelTotalString)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPaidCreditCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPaidCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelECR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBarcodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBtnDeleteRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelItemsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForsupDscntPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForDscntAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerSLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit supNoTextEdit;
        private System.Windows.Forms.BindingSource SupplyMainBindingSource;
        private DevExpress.XtraEditors.TextEdit supRefNoTextEdit;
        private DevExpress.XtraEditors.TextEdit supDescTextEdit;
        private DevExpress.XtraEditors.DateEdit DateDateEdit;
        private DevExpress.XtraEditors.LookUpEdit BoxNoLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGrooupMain;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupRefNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupCur;
        private System.Windows.Forms.BindingSource SupplySubBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupCustNo;
        private DevExpress.XtraEditors.LookUpEdit saleNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSalesNo;
        private System.Windows.Forms.BindingSource SupplyMainBindingSourceEditor;
        private DevExpress.XtraEditors.TextEdit CurrencyChngTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrencyChng;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
        private DevExpress.XtraGrid.Columns.GridColumn colMsur;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsupSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colsupNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditQuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1SalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPrice;
        private DevExpress.XtraEditors.CheckEdit checkEditTax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMeasurment;
        private System.Windows.Forms.BindingSource PrdMeasurmentBindingSource;
        private DevExpress.XtraLayout.SimpleLabelItem labelItemsCount;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraEditors.TextEdit textEditPaidCash;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdBarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEditPrdNo;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colprdId;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNameEng;
        private DevExpress.XtraGrid.Columns.GridColumn colprdGrpNo;
        private DevExpress.XtraEditors.LookUpEdit supCurrTextEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCustomerSLE;
        private DevExpress.XtraGrid.Columns.GridColumn colcstId;
        private DevExpress.XtraGrid.Columns.GridColumn colcustName;
        private DevExpress.XtraEditors.SpinEdit supDscntPercentTextEdit;
        private DevExpress.XtraEditors.TextEdit DscntAmountTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colprdSalePrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDscntPercent;
        private DevExpress.XtraEditors.TextEdit textEditPaidCreditCard;
        private DevExpress.XtraGrid.Columns.GridColumn colcustPhnNo;
        private DevExpress.XtraEditors.SearchLookUpEdit CustNoSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colcustName1;
        private DevExpress.XtraGrid.Columns.GridColumn colcustPhnNo1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrdManufacture;
        private DevExpress.XtraGrid.Columns.GridColumn colcustNo1;
        private DevExpress.XtraGrid.Columns.GridColumn colcustCurrency1;
        private DevExpress.XtraGrid.Columns.GridColumn colcustNo;
        private DevExpress.XtraEditors.ButtonEdit txtdisround;
        private DevExpress.XtraEditors.SpinEdit spinEditTotalFinalDecimal;
        private DevExpress.XtraLayout.LayoutControlItem labelTotalFinalString;
        private DevExpress.XtraEditors.TextEdit textEditCounterNumber;
        private DevExpress.XtraEditors.TextEdit textEditPlateNumber;
        private DevExpress.XtraEditors.TextEdit textEditCarType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlCarData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraGrid.Columns.GridColumn colDscntAmount;
        private DevExpress.XtraEditors.SimpleButton btnECRsend;
        private DevExpress.XtraEditors.SimpleButton btnECRcancel;
        private DevExpress.XtraGrid.Columns.GridColumn colprdQuanAvlb;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit spinEditMonyFinal;
        private DevExpress.XtraEditors.SimpleButton BtnDscnFraction;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.DateEdit notDateTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemFornotDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colHeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMeter;
        private DevExpress.XtraGrid.Columns.GridColumn col_SubNoPacks;
        private DevExpress.XtraEditors.TextEdit PoNumberTextEdit;
        private DevExpress.XtraEditors.TextEdit NotesTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNotes;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPoNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colsupOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn colsupWorkingtime;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraEditors.LookUpEdit StrIdLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraEditors.RadioGroup radioGroupIsCash;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraEditors.TextEdit textEditBarcodeNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBarcodeText;
        private DevExpress.XtraEditors.SimpleButton btnDeleteRow;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBtnDeleteRow;
        private DevExpress.XtraEditors.TextEdit labelTotalPriceDecimal;
        private DevExpress.XtraEditors.TextEdit labelDiscountDecimal;
        private DevExpress.XtraEditors.TextEdit labelTotalTaxDecimal;
        private DevExpress.XtraLayout.LayoutControlItem labelTotalPriceString;
        private DevExpress.XtraLayout.LayoutControlItem labelDiscountString;
        private DevExpress.XtraLayout.LayoutControlItem labelTotalTaxString;
        private DevExpress.XtraEditors.TextEdit labelTotalDecimal;
        private DevExpress.XtraLayout.LayoutControlItem labelTotalString;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditProName;
        private DevExpress.XtraEditors.LookUpEdit BankLookUpEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider11;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem itemForsupDscntPercent;
        private DevExpress.XtraLayout.LayoutControlItem itemForDscntAmount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBoxNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBankId;
        private DevExpress.XtraLayout.SimpleLabelItem labelECR;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem itemForPaidCreditCard;
        private DevExpress.XtraLayout.LayoutControlItem itemForPaidCash;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayConMain;
        private ToolStripButton toolStripButton47;
        private ToolStripButton toolStripButton46;
        public BindingNavigator bindingNavigator11;
        public ToolStripButton bbiNewInvoice;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripButton bbiSave;
        private ToolStripSeparator toolStripSeparator10;
        public ToolStripButton bbiSaveAndNew;
        private ToolStripSeparator toolStripSeparator11;
        public ToolStripButton bbiPrintPrevious;
        private ToolStripSeparator toolStripSeparator5;
        public ToolStripButton bbiReset;
        private ToolStripSeparator toolStripSeparator6;
        public ToolStripButton bbiUpdateInvvoice;
        private ToolStripSeparator toolStripSeparator7;
        public ToolStripButton bbiPrint1;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator12;
        public ToolStripButton bbiClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private ToolStripSeparator toolStripSeparator1;
        public ToolStripButton bbiSelect;
        public ToolStripButton bbiPrdPrice;
        public ToolStripButton bbiEditPrice;
        public ToolStripButton toolStripButton3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        public ToolStripButton bbiSaveAndNewNoPrint;
        public ToolStripButton bbiEditQuantity;
        public ToolStripButton bsiPaidCreditShortcut;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator14;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormControl toolbarFormControl1;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormManager toolbarFormManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer2;
        private DevExpress.XtraBars.TabFormControl tabFormControl1;
        private DevExpress.XtraBars.TabFormPage tabFormPage2;
        private DevExpress.XtraBars.TabFormPage tabFormPage3;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer3;
    }
}