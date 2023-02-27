namespace AccountingMS
{
    partial class formAddCustomer
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddCustomer));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupPrdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupMsur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupQuanSub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.supSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblSupplyMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupIsCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTotalFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCLose3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReportInvoiceType = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.bbiAutoAccNo = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAutoAddAccNo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageBalance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupBalance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageInvoices = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageEntries = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupEntries = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageMain = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CommercialRegisterEnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tblCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CommercialRegisterTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custAddressEnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custCityEnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custNameEnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custAccNoLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.custAccNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custPhnNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custCityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custEmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custCellingCreditTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custCountryTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblCountryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.custCurrencyTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.custSalePriceTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.custTaxNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.custCountryEnTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.cusBankIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cusBuildingNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cusAddNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cusAnotherIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cusDistrictTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.cusDistrictEnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForcustAccNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustAccName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCellingCredit = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForcustName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCountry = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustSalePrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustTaxNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustNameEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCityEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustPhnNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustAddressEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCommercialRegister = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCommercialRegisterEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcustCountryEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsupBankId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcusBuildingNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcusAddNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcusAnotherID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcusDistrict = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcusDistrictEn = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigationPageInvoices = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPageBalance = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlPeriodBalance = new DevExpress.XtraGrid.GridControl();
            this.clsBalanceColumnsDataBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPeriodBalance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldebit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcredit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcurrentBalance2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.clsBalanceColumnsDataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewCurrentBalance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldebit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcredit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcurrentBalance1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditDtStart = new DevExpress.XtraEditors.DateEdit();
            this.textEditDtEnd = new DevExpress.XtraEditors.DateEdit();
            this.btnCalculatePeriodBalance = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupPeriodBalance = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDtStart = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lciDtEnd = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupCurrentBalance = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.navigationPageEntries = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.tblEntrySubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colentAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentBoxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDebitFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCreditFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCurChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCusNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommercialRegisterEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommercialRegisterTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAddressEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCityEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNameEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAccNoLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAccNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custPhnNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custEmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCellingCreditTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCountryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCountryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCurrencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custSalePriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custTaxNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCountryEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusBankIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusBuildingNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusAddNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusAnotherIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDistrictTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDistrictEnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAccNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAccName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCellingCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustTaxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustNameEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCityEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustPhnNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAddressEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCommercialRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCommercialRegisterEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCountryEn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupBankId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusBuildingNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusAddNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusAnotherID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusDistrictEn)).BeginInit();
            this.navigationPageInvoices.SuspendLayout();
            this.navigationPageBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPeriodBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsBalanceColumnsDataBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPeriodBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsBalanceColumnsDataBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPeriodBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCurrentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.navigationPageEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Navy;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.NavajoWhite;
            this.gridView2.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(225)))), ((int)(((byte)(239)))));
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupPrdNo,
            this.colsupPrdName,
            this.colsupMsur,
            this.colsupQuanMain,
            this.colsupQuanSub,
            this.colsupPrice,
            this.supSalePrice,
            this.gridColumn1,
            this.colsupDebit});
            this.gridView2.DetailHeight = 485;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colsupPrdNo
            // 
            this.colsupPrdNo.Caption = "رقم الصنف";
            this.colsupPrdNo.FieldName = "supPrdNo";
            this.colsupPrdNo.MinWidth = 26;
            this.colsupPrdNo.Name = "colsupPrdNo";
            this.colsupPrdNo.Visible = true;
            this.colsupPrdNo.VisibleIndex = 0;
            this.colsupPrdNo.Width = 99;
            // 
            // colsupPrdName
            // 
            this.colsupPrdName.Caption = "إسم الصنف";
            this.colsupPrdName.FieldName = "supPrdName";
            this.colsupPrdName.MinWidth = 26;
            this.colsupPrdName.Name = "colsupPrdName";
            this.colsupPrdName.OptionsColumn.AllowEdit = false;
            this.colsupPrdName.OptionsColumn.TabStop = false;
            this.colsupPrdName.Visible = true;
            this.colsupPrdName.VisibleIndex = 1;
            this.colsupPrdName.Width = 99;
            // 
            // colsupMsur
            // 
            this.colsupMsur.AppearanceCell.Options.UseTextOptions = true;
            this.colsupMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupMsur.Caption = "وحدة القياس";
            this.colsupMsur.FieldName = "supMsur";
            this.colsupMsur.MinWidth = 26;
            this.colsupMsur.Name = "colsupMsur";
            this.colsupMsur.OptionsColumn.AllowEdit = false;
            this.colsupMsur.OptionsColumn.TabStop = false;
            this.colsupMsur.Visible = true;
            this.colsupMsur.VisibleIndex = 2;
            this.colsupMsur.Width = 99;
            // 
            // colsupQuanMain
            // 
            this.colsupQuanMain.AppearanceCell.Options.UseTextOptions = true;
            this.colsupQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupQuanMain.Caption = "الكمية";
            this.colsupQuanMain.FieldName = "supQuanMain";
            this.colsupQuanMain.MinWidth = 26;
            this.colsupQuanMain.Name = "colsupQuanMain";
            this.colsupQuanMain.Visible = true;
            this.colsupQuanMain.VisibleIndex = 3;
            this.colsupQuanMain.Width = 99;
            // 
            // colsupQuanSub
            // 
            this.colsupQuanSub.Caption = "الكمية الفرعية";
            this.colsupQuanSub.FieldName = "supQuanSub";
            this.colsupQuanSub.MinWidth = 26;
            this.colsupQuanSub.Name = "colsupQuanSub";
            this.colsupQuanSub.Width = 99;
            // 
            // colsupPrice
            // 
            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupPrice.Caption = "التكلفة";
            this.colsupPrice.DisplayFormat.FormatString = "#,#.##";
            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupPrice.FieldName = "supPrice";
            this.colsupPrice.MinWidth = 26;
            this.colsupPrice.Name = "colsupPrice";
            this.colsupPrice.Visible = true;
            this.colsupPrice.VisibleIndex = 4;
            this.colsupPrice.Width = 99;
            // 
            // supSalePrice
            // 
            this.supSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.supSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.supSalePrice.Caption = "سعر البيع";
            this.supSalePrice.DisplayFormat.FormatString = "#,#.##";
            this.supSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.supSalePrice.FieldName = "supSalePrice";
            this.supSalePrice.MinWidth = 26;
            this.supSalePrice.Name = "supSalePrice";
            this.supSalePrice.Visible = true;
            this.supSalePrice.VisibleIndex = 5;
            this.supSalePrice.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "البيان";
            this.gridColumn1.FieldName = "supDesc";
            this.gridColumn1.MinWidth = 26;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 99;
            // 
            // colsupDebit
            // 
            this.colsupDebit.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDebit.Caption = "الإجمالي";
            this.colsupDebit.DisplayFormat.FormatString = "#,#.##";
            this.colsupDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupDebit.FieldName = "supCredit";
            this.colsupDebit.MinWidth = 26;
            this.colsupDebit.Name = "colsupDebit";
            this.colsupDebit.Visible = true;
            this.colsupDebit.VisibleIndex = 7;
            this.colsupDebit.Width = 99;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblSupplyMainBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1075, 535);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // tblSupplyMainBindingSource
            // 
            this.tblSupplyMainBindingSource.DataSource = typeof(AccountingMS.tblSupplyMain);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupId,
            this.colsupStatus,
            this.colsupIsCash,
            this.colsupNo,
            this.colsupRefNo,
            this.colsupDesc,
            this.colsupTaxPercent,
            this.colsupTaxPrice,
            this.colsupTotal,
            this.colsupTotalFrgn,
            this.colsupCurrency,
            this.colsupDate,
            this.colsupAccNo,
            this.colsupAccName});
            this.gridView1.DetailHeight = 485;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colsupIsCash, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colsupId
            // 
            this.colsupId.FieldName = "id";
            this.colsupId.MinWidth = 26;
            this.colsupId.Name = "colsupId";
            this.colsupId.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupId.Width = 99;
            // 
            // colsupStatus
            // 
            this.colsupStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colsupStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupStatus.Caption = "نوع السند";
            this.colsupStatus.FieldName = "supStatus";
            this.colsupStatus.MaxWidth = 174;
            this.colsupStatus.MinWidth = 26;
            this.colsupStatus.Name = "colsupStatus";
            this.colsupStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "supStatus", "العدد : {0}")});
            this.colsupStatus.Visible = true;
            this.colsupStatus.VisibleIndex = 0;
            this.colsupStatus.Width = 120;
            // 
            // colsupIsCash
            // 
            this.colsupIsCash.AppearanceCell.Options.UseTextOptions = true;
            this.colsupIsCash.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupIsCash.Caption = "فواتير";
            this.colsupIsCash.FieldName = "supIsCash";
            this.colsupIsCash.MinWidth = 26;
            this.colsupIsCash.Name = "colsupIsCash";
            this.colsupIsCash.OptionsColumn.AllowShowHide = false;
            this.colsupIsCash.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupIsCash.Visible = true;
            this.colsupIsCash.VisibleIndex = 1;
            this.colsupIsCash.Width = 99;
            // 
            // colsupNo
            // 
            this.colsupNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsupNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupNo.Caption = "رقم الفاتورة";
            this.colsupNo.FieldName = "supNo";
            this.colsupNo.MaxWidth = 106;
            this.colsupNo.MinWidth = 26;
            this.colsupNo.Name = "colsupNo";
            this.colsupNo.Visible = true;
            this.colsupNo.VisibleIndex = 1;
            this.colsupNo.Width = 106;
            // 
            // colsupRefNo
            // 
            this.colsupRefNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsupRefNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupRefNo.Caption = "رقم المرجع";
            this.colsupRefNo.FieldName = "supRefNo";
            this.colsupRefNo.MinWidth = 26;
            this.colsupRefNo.Name = "colsupRefNo";
            this.colsupRefNo.Width = 99;
            // 
            // colsupDesc
            // 
            this.colsupDesc.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDesc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.FieldName = "supDesc";
            this.colsupDesc.MinWidth = 26;
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Visible = true;
            this.colsupDesc.VisibleIndex = 2;
            this.colsupDesc.Width = 138;
            // 
            // colsupTaxPercent
            // 
            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPercent.Caption = "نسبة الضريبة";
            this.colsupTaxPercent.FieldName = "supTaxPercent";
            this.colsupTaxPercent.MinWidth = 26;
            this.colsupTaxPercent.Name = "colsupTaxPercent";
            this.colsupTaxPercent.Width = 106;
            // 
            // colsupTaxPrice
            // 
            this.colsupTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPrice.Caption = "الضريبة";
            this.colsupTaxPrice.DisplayFormat.FormatString = "n2";
            this.colsupTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTaxPrice.FieldName = "supTaxPrice";
            this.colsupTaxPrice.MaxWidth = 106;
            this.colsupTaxPrice.MinWidth = 26;
            this.colsupTaxPrice.Name = "colsupTaxPrice";
            this.colsupTaxPrice.Visible = true;
            this.colsupTaxPrice.VisibleIndex = 3;
            this.colsupTaxPrice.Width = 106;
            // 
            // colsupTotal
            // 
            this.colsupTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTotal.Caption = "الإجمالي";
            this.colsupTotal.DisplayFormat.FormatString = "n2";
            this.colsupTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTotal.FieldName = "supTotal";
            this.colsupTotal.MaxWidth = 134;
            this.colsupTotal.MinWidth = 26;
            this.colsupTotal.Name = "colsupTotal";
            this.colsupTotal.Visible = true;
            this.colsupTotal.VisibleIndex = 4;
            this.colsupTotal.Width = 134;
            // 
            // colsupTotalFrgn
            // 
            this.colsupTotalFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTotalFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTotalFrgn.Caption = "إجمالي بلعملة الأجنبية";
            this.colsupTotalFrgn.DisplayFormat.FormatString = "n2";
            this.colsupTotalFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTotalFrgn.FieldName = "supTotalFrgn";
            this.colsupTotalFrgn.MaxWidth = 174;
            this.colsupTotalFrgn.MinWidth = 26;
            this.colsupTotalFrgn.Name = "colsupTotalFrgn";
            this.colsupTotalFrgn.Visible = true;
            this.colsupTotalFrgn.VisibleIndex = 5;
            this.colsupTotalFrgn.Width = 160;
            // 
            // colsupCurrency
            // 
            this.colsupCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colsupCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupCurrency.Caption = "العملة";
            this.colsupCurrency.FieldName = "supCurrency";
            this.colsupCurrency.MaxWidth = 94;
            this.colsupCurrency.MinWidth = 26;
            this.colsupCurrency.Name = "colsupCurrency";
            this.colsupCurrency.Width = 91;
            // 
            // colsupDate
            // 
            this.colsupDate.Caption = "التاريخ";
            this.colsupDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colsupDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colsupDate.FieldName = "supDate";
            this.colsupDate.MaxWidth = 134;
            this.colsupDate.MinWidth = 26;
            this.colsupDate.Name = "colsupDate";
            this.colsupDate.Visible = true;
            this.colsupDate.VisibleIndex = 6;
            this.colsupDate.Width = 134;
            // 
            // colsupAccNo
            // 
            this.colsupAccNo.FieldName = "supAccNo";
            this.colsupAccNo.MinWidth = 26;
            this.colsupAccNo.Name = "colsupAccNo";
            this.colsupAccNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupAccNo.Width = 99;
            // 
            // colsupAccName
            // 
            this.colsupAccName.FieldName = "supAccName";
            this.colsupAccName.MinWidth = 26;
            this.colsupAccName.Name = "colsupAccName";
            this.colsupAccName.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupAccName.Width = 99;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 33, 34, 33);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiClose,
            this.bbiClose2,
            this.bbiPrint2,
            this.bbiSave,
            this.bbiClose1,
            this.bbiCLose3,
            this.bbiPrint3,
            this.bbiReportInvoiceType,
            this.bbiAutoAccNo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 440;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageMain,
            this.ribbonPageBalance,
            this.ribbonPageInvoices,
            this.ribbonPageEntries});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemCheckEdit1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1075, 185);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 4;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick_1);
            // 
            // bbiClose2
            // 
            this.bbiClose2.Caption = "إغلاق";
            this.bbiClose2.Id = 5;
            this.bbiClose2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose2.ImageOptions.Image")));
            this.bbiClose2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose2.ImageOptions.LargeImage")));
            this.bbiClose2.Name = "bbiClose2";
            // 
            // bbiPrint2
            // 
            this.bbiPrint2.Caption = "طباعة الفاتورة";
            this.bbiPrint2.Id = 6;
            this.bbiPrint2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrint2.ImageOptions.Image")));
            this.bbiPrint2.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.printviapdf_32x32;
            this.bbiPrint2.Name = "bbiPrint2";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 14;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save1;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose1
            // 
            this.bbiClose1.Caption = "إغلاق";
            this.bbiClose1.Id = 15;
            this.bbiClose1.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiClose1.Name = "bbiClose1";
            // 
            // bbiCLose3
            // 
            this.bbiCLose3.Caption = "إغلاق";
            this.bbiCLose3.Id = 16;
            this.bbiCLose3.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiCLose3.Name = "bbiCLose3";
            // 
            // bbiPrint3
            // 
            this.bbiPrint3.Caption = "طباعة السند";
            this.bbiPrint3.Id = 17;
            this.bbiPrint3.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.printviapdf_32x32;
            this.bbiPrint3.Name = "bbiPrint3";
            // 
            // bbiReportInvoiceType
            // 
            this.bbiReportInvoiceType.Edit = this.repositoryItemRadioGroup1;
            this.bbiReportInvoiceType.EditHeight = 50;
            this.bbiReportInvoiceType.EditWidth = 60;
            this.bbiReportInvoiceType.Id = 19;
            this.bbiReportInvoiceType.Name = "bbiReportInvoiceType";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Columns = 1;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(4)), "A4"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(5)), "كاشير")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // bbiAutoAccNo
            // 
            this.bbiAutoAccNo.Caption = "إضافة حساب تلقائي";
            this.bbiAutoAccNo.Id = 21;
            this.bbiAutoAccNo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAutoAccNo.ImageOptions.Image")));
            this.bbiAutoAccNo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAutoAccNo.ImageOptions.LargeImage")));
            this.bbiAutoAccNo.Name = "bbiAutoAccNo";
            this.bbiAutoAccNo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // ribbonPageMain
            // 
            this.ribbonPageMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupAutoAddAccNo});
            this.ribbonPageMain.Name = "ribbonPageMain";
            this.ribbonPageMain.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroupAutoAddAccNo
            // 
            this.ribbonPageGroupAutoAddAccNo.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupAutoAddAccNo.ItemLinks.Add(this.bbiAutoAccNo, false, "", "", true);
            this.ribbonPageGroupAutoAddAccNo.Name = "ribbonPageGroupAutoAddAccNo";
            this.ribbonPageGroupAutoAddAccNo.Text = "حساب العميل";
            this.ribbonPageGroupAutoAddAccNo.Visible = false;
            // 
            // ribbonPageBalance
            // 
            this.ribbonPageBalance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupBalance});
            this.ribbonPageBalance.Name = "ribbonPageBalance";
            this.ribbonPageBalance.Text = "رصيد العميل";
            this.ribbonPageBalance.Visible = false;
            // 
            // ribbonPageGroupBalance
            // 
            this.ribbonPageGroupBalance.AllowTextClipping = false;
            this.ribbonPageGroupBalance.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupBalance.ItemLinks.Add(this.bbiClose1);
            this.ribbonPageGroupBalance.Name = "ribbonPageGroupBalance";
            this.ribbonPageGroupBalance.Text = "العمليات";
            // 
            // ribbonPageInvoices
            // 
            this.ribbonPageInvoices.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPageInvoices.Name = "ribbonPageInvoices";
            this.ribbonPageInvoices.Text = "الفواتير";
            this.ribbonPageInvoices.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "العمليات";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiPrint2);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiReportInvoiceType);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "الطباعة";
            // 
            // ribbonPageEntries
            // 
            this.ribbonPageEntries.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupEntries});
            this.ribbonPageEntries.Name = "ribbonPageEntries";
            this.ribbonPageEntries.Text = "السندات";
            this.ribbonPageEntries.Visible = false;
            // 
            // ribbonPageGroupEntries
            // 
            this.ribbonPageGroupEntries.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupEntries.ItemLinks.Add(this.bbiCLose3);
            this.ribbonPageGroupEntries.ItemLinks.Add(this.bbiPrint3);
            this.ribbonPageGroupEntries.Name = "ribbonPageGroupEntries";
            this.ribbonPageGroupEntries.Text = "العمليات";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPageMain);
            this.navigationFrame1.Controls.Add(this.navigationPageInvoices);
            this.navigationFrame1.Controls.Add(this.navigationPageBalance);
            this.navigationFrame1.Controls.Add(this.navigationPageEntries);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 185);
            this.navigationFrame1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageMain,
            this.navigationPageBalance,
            this.navigationPageInvoices,
            this.navigationPageEntries});
            this.navigationFrame1.SelectedPage = this.navigationPageMain;
            this.navigationFrame1.Size = new System.Drawing.Size(1075, 535);
            this.navigationFrame1.TabIndex = 2;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPageMain
            // 
            this.navigationPageMain.Controls.Add(this.dataLayoutControl1);
            this.navigationPageMain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigationPageMain.Name = "navigationPageMain";
            this.navigationPageMain.Size = new System.Drawing.Size(1075, 535);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Appearance.ControlDisabled.BackColor = System.Drawing.Color.White;
            this.dataLayoutControl1.Appearance.ControlDisabled.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseBackColor = true;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseForeColor = true;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.dataLayoutControl1.Controls.Add(this.CommercialRegisterEnTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CommercialRegisterTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custAddressEnTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCityEnTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custNameEnTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custAccNoLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.custAccNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custPhnNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custAddressTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custEmailTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCellingCreditTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCountryTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCurrencyTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custSalePriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custTaxNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.custCountryEnTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusBankIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusBuildingNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusAddNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusAnotherIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusDistrictTextEdit);
            this.dataLayoutControl1.Controls.Add(this.cusDistrictEnTextEdit);
            this.dataLayoutControl1.DataSource = this.tblCustomerBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(631, 81, 450, 400);
            this.dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1075, 535);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CommercialRegisterEnTextEdit
            // 
            this.CommercialRegisterEnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "PostalCode", true));
            this.CommercialRegisterEnTextEdit.Location = new System.Drawing.Point(18, 376);
            this.CommercialRegisterEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CommercialRegisterEnTextEdit.MenuManager = this.ribbonControl1;
            this.CommercialRegisterEnTextEdit.Name = "CommercialRegisterEnTextEdit";
            this.CommercialRegisterEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.CommercialRegisterEnTextEdit.StyleController = this.dataLayoutControl1;
            this.CommercialRegisterEnTextEdit.TabIndex = 17;
            // 
            // tblCustomerBindingSource
            // 
            this.tblCustomerBindingSource.DataSource = typeof(AccountingMS.tblCustomer);
            // 
            // CommercialRegisterTextEdit
            // 
            this.CommercialRegisterTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "CommercialRegister", true));
            this.CommercialRegisterTextEdit.Location = new System.Drawing.Point(538, 376);
            this.CommercialRegisterTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.CommercialRegisterTextEdit.MenuManager = this.ribbonControl1;
            this.CommercialRegisterTextEdit.Name = "CommercialRegisterTextEdit";
            this.CommercialRegisterTextEdit.Size = new System.Drawing.Size(373, 24);
            this.CommercialRegisterTextEdit.StyleController = this.dataLayoutControl1;
            this.CommercialRegisterTextEdit.TabIndex = 16;
            // 
            // custAddressEnTextEdit
            // 
            this.custAddressEnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custAddressEn", true));
            this.custAddressEnTextEdit.Location = new System.Drawing.Point(18, 292);
            this.custAddressEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custAddressEnTextEdit.MenuManager = this.ribbonControl1;
            this.custAddressEnTextEdit.Name = "custAddressEnTextEdit";
            this.custAddressEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custAddressEnTextEdit.StyleController = this.dataLayoutControl1;
            this.custAddressEnTextEdit.TabIndex = 15;
            // 
            // custCityEnTextEdit
            // 
            this.custCityEnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custCityEn", true));
            this.custCityEnTextEdit.Location = new System.Drawing.Point(18, 236);
            this.custCityEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCityEnTextEdit.MenuManager = this.ribbonControl1;
            this.custCityEnTextEdit.Name = "custCityEnTextEdit";
            this.custCityEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custCityEnTextEdit.StyleController = this.dataLayoutControl1;
            this.custCityEnTextEdit.TabIndex = 13;
            // 
            // custNameEnTextEdit
            // 
            this.custNameEnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custNameEn", true));
            this.custNameEnTextEdit.Location = new System.Drawing.Point(18, 180);
            this.custNameEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custNameEnTextEdit.MenuManager = this.ribbonControl1;
            this.custNameEnTextEdit.Name = "custNameEnTextEdit";
            this.custNameEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custNameEnTextEdit.StyleController = this.dataLayoutControl1;
            this.custNameEnTextEdit.TabIndex = 12;
            // 
            // custNoTextEdit
            // 
            this.custNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custNoTextEdit.Location = new System.Drawing.Point(711, 86);
            this.custNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custNoTextEdit.Name = "custNoTextEdit";
            this.custNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.custNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.custNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.custNoTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.custNoTextEdit.Properties.MaskSettings.Set("mask", "f0");
            this.custNoTextEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.custNoTextEdit.Size = new System.Drawing.Size(200, 24);
            this.custNoTextEdit.StyleController = this.dataLayoutControl1;
            this.custNoTextEdit.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.custNoTextEdit, conditionValidationRule1);
            // 
            // custAccNoLookUpEdit
            // 
            this.custAccNoLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custAccNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custAccNoLookUpEdit.Location = new System.Drawing.Point(365, 58);
            this.custAccNoLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custAccNoLookUpEdit.Name = "custAccNoLookUpEdit";
            this.custAccNoLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.custAccNoLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.custAccNoLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.custAccNoLookUpEdit.Properties.NullText = "";
            this.custAccNoLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.custAccNoLookUpEdit.Size = new System.Drawing.Size(546, 24);
            this.custAccNoLookUpEdit.StyleController = this.dataLayoutControl1;
            this.custAccNoLookUpEdit.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل!";
            conditionValidationRule2.Value1 = ((long)(0));
            this.dxValidationProvider1.SetValidationRule(this.custAccNoLookUpEdit, conditionValidationRule2);
            // 
            // custAccNameTextEdit
            // 
            this.custAccNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custAccName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custAccNameTextEdit.Enabled = false;
            this.custAccNameTextEdit.Location = new System.Drawing.Point(18, 58);
            this.custAccNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custAccNameTextEdit.Name = "custAccNameTextEdit";
            this.custAccNameTextEdit.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.custAccNameTextEdit.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.custAccNameTextEdit.Size = new System.Drawing.Size(197, 24);
            this.custAccNameTextEdit.StyleController = this.dataLayoutControl1;
            this.custAccNameTextEdit.TabIndex = 1;
            // 
            // custNameTextEdit
            // 
            this.custNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custNameTextEdit.Location = new System.Drawing.Point(538, 180);
            this.custNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custNameTextEdit.Name = "custNameTextEdit";
            this.custNameTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custNameTextEdit.StyleController = this.dataLayoutControl1;
            this.custNameTextEdit.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.custNameTextEdit, conditionValidationRule3);
            // 
            // custPhnNoTextEdit
            // 
            this.custPhnNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custPhnNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custPhnNoTextEdit.Location = new System.Drawing.Point(538, 264);
            this.custPhnNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custPhnNoTextEdit.Name = "custPhnNoTextEdit";
            this.custPhnNoTextEdit.Properties.MaxLength = 15;
            this.custPhnNoTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custPhnNoTextEdit.StyleController = this.dataLayoutControl1;
            this.custPhnNoTextEdit.TabIndex = 5;
            // 
            // custCityTextEdit
            // 
            this.custCityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custCity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custCityTextEdit.Location = new System.Drawing.Point(538, 236);
            this.custCityTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCityTextEdit.Name = "custCityTextEdit";
            this.custCityTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custCityTextEdit.StyleController = this.dataLayoutControl1;
            this.custCityTextEdit.TabIndex = 7;
            // 
            // custAddressTextEdit
            // 
            this.custAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custAddressTextEdit.Location = new System.Drawing.Point(538, 292);
            this.custAddressTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custAddressTextEdit.Name = "custAddressTextEdit";
            this.custAddressTextEdit.Properties.MaxLength = 100;
            this.custAddressTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custAddressTextEdit.StyleController = this.dataLayoutControl1;
            this.custAddressTextEdit.TabIndex = 8;
            // 
            // custEmailTextEdit
            // 
            this.custEmailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custEmail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custEmailTextEdit.Location = new System.Drawing.Point(18, 264);
            this.custEmailTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custEmailTextEdit.Name = "custEmailTextEdit";
            this.custEmailTextEdit.Properties.MaxLength = 40;
            this.custEmailTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custEmailTextEdit.StyleController = this.dataLayoutControl1;
            this.custEmailTextEdit.TabIndex = 9;
            // 
            // custCellingCreditTextEdit
            // 
            this.custCellingCreditTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custCellingCredit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custCellingCreditTextEdit.Location = new System.Drawing.Point(18, 86);
            this.custCellingCreditTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCellingCreditTextEdit.Name = "custCellingCreditTextEdit";
            this.custCellingCreditTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.custCellingCreditTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.custCellingCreditTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.custCellingCreditTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.custCellingCreditTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.custCellingCreditTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.custCellingCreditTextEdit.Size = new System.Drawing.Size(197, 24);
            this.custCellingCreditTextEdit.StyleController = this.dataLayoutControl1;
            this.custCellingCreditTextEdit.TabIndex = 3;
            // 
            // custCountryTextEdit
            // 
            this.custCountryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custCountry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custCountryTextEdit.Location = new System.Drawing.Point(538, 208);
            this.custCountryTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCountryTextEdit.Name = "custCountryTextEdit";
            this.custCountryTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.custCountryTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntArName", "Name5", 26, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntEnName", "Name6", 26, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.custCountryTextEdit.Properties.DataSource = this.tblCountryBindingSource;
            this.custCountryTextEdit.Properties.DisplayMember = "cntArName";
            this.custCountryTextEdit.Properties.NullText = "";
            this.custCountryTextEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.custCountryTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.custCountryTextEdit.Properties.ShowHeader = false;
            this.custCountryTextEdit.Properties.ValueMember = "cntArName";
            this.custCountryTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custCountryTextEdit.StyleController = this.dataLayoutControl1;
            this.custCountryTextEdit.TabIndex = 6;
            // 
            // tblCountryBindingSource
            // 
            this.tblCountryBindingSource.DataSource = typeof(AccountingMS.tblCountry);
            // 
            // custCurrencyTextEdit
            // 
            this.custCurrencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custCurrency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custCurrencyTextEdit.Location = new System.Drawing.Point(365, 86);
            this.custCurrencyTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCurrencyTextEdit.MenuManager = this.ribbonControl1;
            this.custCurrencyTextEdit.Name = "custCurrencyTextEdit";
            this.custCurrencyTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.custCurrencyTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.custCurrencyTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.custCurrencyTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.custCurrencyTextEdit.Properties.NullText = "";
            this.custCurrencyTextEdit.Properties.ShowHeader = false;
            this.custCurrencyTextEdit.Size = new System.Drawing.Size(196, 24);
            this.custCurrencyTextEdit.StyleController = this.dataLayoutControl1;
            this.custCurrencyTextEdit.TabIndex = 2;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule4.ErrorText = "يجب إدخال هذا الحقل!";
            conditionValidationRule4.Value1 = ((byte)(0));
            this.dxValidationProvider1.SetValidationRule(this.custCurrencyTextEdit, conditionValidationRule4);
            // 
            // custSalePriceTextEdit
            // 
            this.custSalePriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custSalePrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custSalePriceTextEdit.Location = new System.Drawing.Point(18, 348);
            this.custSalePriceTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custSalePriceTextEdit.MenuManager = this.ribbonControl1;
            this.custSalePriceTextEdit.Name = "custSalePriceTextEdit";
            this.custSalePriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.custSalePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.custSalePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.custSalePriceTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.custSalePriceTextEdit.Properties.NullText = "";
            this.custSalePriceTextEdit.Properties.PopupSizeable = false;
            this.custSalePriceTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.custSalePriceTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custSalePriceTextEdit.StyleController = this.dataLayoutControl1;
            this.custSalePriceTextEdit.TabIndex = 11;
            // 
            // custTaxNoTextEdit
            // 
            this.custTaxNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "custTaxNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.custTaxNoTextEdit.Location = new System.Drawing.Point(538, 348);
            this.custTaxNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custTaxNoTextEdit.MenuManager = this.ribbonControl1;
            this.custTaxNoTextEdit.Name = "custTaxNoTextEdit";
            this.custTaxNoTextEdit.Properties.MaxLength = 20;
            this.custTaxNoTextEdit.Size = new System.Drawing.Size(373, 24);
            this.custTaxNoTextEdit.StyleController = this.dataLayoutControl1;
            this.custTaxNoTextEdit.TabIndex = 10;
            // 
            // custCountryEnTextEdit
            // 
            this.custCountryEnTextEdit.Location = new System.Drawing.Point(18, 208);
            this.custCountryEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.custCountryEnTextEdit.Name = "custCountryEnTextEdit";
            this.custCountryEnTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.custCountryEnTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntArName", "Name5", 26, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntEnName", "Name6", 26, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.custCountryEnTextEdit.Properties.DataSource = this.tblCountryBindingSource;
            this.custCountryEnTextEdit.Properties.DisplayMember = "cntEnName";
            this.custCountryEnTextEdit.Properties.NullText = "";
            this.custCountryEnTextEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.custCountryEnTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.custCountryEnTextEdit.Properties.ShowHeader = false;
            this.custCountryEnTextEdit.Properties.ValueMember = "cntArName";
            this.custCountryEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.custCountryEnTextEdit.StyleController = this.dataLayoutControl1;
            this.custCountryEnTextEdit.TabIndex = 6;
            // 
            // cusBankIdTextEdit
            // 
            this.cusBankIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusBankId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusBankIdTextEdit.Location = new System.Drawing.Point(538, 432);
            this.cusBankIdTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusBankIdTextEdit.Name = "cusBankIdTextEdit";
            this.cusBankIdTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cusBankIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cusBankIdTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("bankName", "Name1", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cusBankIdTextEdit.Properties.DataSource = this.tblBankBindingSource;
            this.cusBankIdTextEdit.Properties.DisplayMember = "bankName";
            this.cusBankIdTextEdit.Properties.NullText = "";
            this.cusBankIdTextEdit.Properties.ShowHeader = false;
            this.cusBankIdTextEdit.Properties.ValueMember = "id";
            this.cusBankIdTextEdit.Size = new System.Drawing.Size(373, 24);
            this.cusBankIdTextEdit.StyleController = this.dataLayoutControl1;
            this.cusBankIdTextEdit.TabIndex = 6;
            // 
            // tblBankBindingSource
            // 
            this.tblBankBindingSource.DataSource = typeof(AccountingMS.tblAccountBank);
            // 
            // cusBuildingNoTextEdit
            // 
            this.cusBuildingNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusBuildingNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusBuildingNoTextEdit.Location = new System.Drawing.Point(538, 404);
            this.cusBuildingNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusBuildingNoTextEdit.Name = "cusBuildingNoTextEdit";
            this.cusBuildingNoTextEdit.Size = new System.Drawing.Size(373, 24);
            this.cusBuildingNoTextEdit.StyleController = this.dataLayoutControl1;
            this.cusBuildingNoTextEdit.TabIndex = 16;
            // 
            // cusAddNoTextEdit
            // 
            this.cusAddNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusAddNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusAddNoTextEdit.Location = new System.Drawing.Point(18, 404);
            this.cusAddNoTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusAddNoTextEdit.Name = "cusAddNoTextEdit";
            this.cusAddNoTextEdit.Size = new System.Drawing.Size(370, 24);
            this.cusAddNoTextEdit.StyleController = this.dataLayoutControl1;
            this.cusAddNoTextEdit.TabIndex = 16;
            // 
            // cusAnotherIDTextEdit
            // 
            this.cusAnotherIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusAnotherID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusAnotherIDTextEdit.Location = new System.Drawing.Point(18, 432);
            this.cusAnotherIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusAnotherIDTextEdit.Name = "cusAnotherIDTextEdit";
            this.cusAnotherIDTextEdit.Size = new System.Drawing.Size(370, 24);
            this.cusAnotherIDTextEdit.StyleController = this.dataLayoutControl1;
            this.cusAnotherIDTextEdit.TabIndex = 16;
            // 
            // cusDistrictTextEdit
            // 
            this.cusDistrictTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusDistrict", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusDistrictTextEdit.Location = new System.Drawing.Point(538, 320);
            this.cusDistrictTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusDistrictTextEdit.Name = "cusDistrictTextEdit";
            this.cusDistrictTextEdit.Properties.MaxLength = 100;
            this.cusDistrictTextEdit.Size = new System.Drawing.Size(373, 24);
            this.cusDistrictTextEdit.StyleController = this.dataLayoutControl1;
            this.cusDistrictTextEdit.TabIndex = 8;
            // 
            // cusDistrictEnTextEdit
            // 
            this.cusDistrictEnTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblCustomerBindingSource, "cusDistrictEn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cusDistrictEnTextEdit.Location = new System.Drawing.Point(18, 320);
            this.cusDistrictEnTextEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cusDistrictEnTextEdit.Name = "cusDistrictEnTextEdit";
            this.cusDistrictEnTextEdit.Properties.MaxLength = 100;
            this.cusDistrictEnTextEdit.Size = new System.Drawing.Size(370, 24);
            this.cusDistrictEnTextEdit.StyleController = this.dataLayoutControl1;
            this.cusDistrictEnTextEdit.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 2;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 7, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1075, 535);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1061, 525);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForcustAccNo,
            this.ItemForcustNo,
            this.ItemForcustAccName,
            this.ItemForcustCellingCredit,
            this.ItemForcustCurrency});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 7, 13, 13);
            this.layoutControlGroup3.Size = new System.Drawing.Size(1061, 122);
            this.layoutControlGroup3.Text = "بيانات الحساب";
            // 
            // ItemForcustAccNo
            // 
            this.ItemForcustAccNo.Control = this.custAccNoLookUpEdit;
            this.ItemForcustAccNo.Location = new System.Drawing.Point(347, 0);
            this.ItemForcustAccNo.Name = "ItemForcustAccNo";
            this.ItemForcustAccNo.Size = new System.Drawing.Size(696, 28);
            this.ItemForcustAccNo.Text = "رقم الحساب :";
            this.ItemForcustAccNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustNo
            // 
            this.ItemForcustNo.Control = this.custNoTextEdit;
            this.ItemForcustNo.Location = new System.Drawing.Point(693, 28);
            this.ItemForcustNo.Name = "ItemForcustNo";
            this.ItemForcustNo.Size = new System.Drawing.Size(350, 28);
            this.ItemForcustNo.Text = "رقم العميل :";
            this.ItemForcustNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustAccName
            // 
            this.ItemForcustAccName.Control = this.custAccNameTextEdit;
            this.ItemForcustAccName.Location = new System.Drawing.Point(0, 0);
            this.ItemForcustAccName.Name = "ItemForcustAccName";
            this.ItemForcustAccName.Size = new System.Drawing.Size(347, 28);
            this.ItemForcustAccName.Text = "إسم الحساب :";
            this.ItemForcustAccName.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCellingCredit
            // 
            this.ItemForcustCellingCredit.Control = this.custCellingCreditTextEdit;
            this.ItemForcustCellingCredit.Location = new System.Drawing.Point(0, 28);
            this.ItemForcustCellingCredit.Name = "ItemForcustCellingCredit";
            this.ItemForcustCellingCredit.Size = new System.Drawing.Size(347, 28);
            this.ItemForcustCellingCredit.Text = "سقف الحساب :";
            this.ItemForcustCellingCredit.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCurrency
            // 
            this.ItemForcustCurrency.Control = this.custCurrencyTextEdit;
            this.ItemForcustCurrency.Location = new System.Drawing.Point(347, 28);
            this.ItemForcustCurrency.Name = "ItemForcustCurrency";
            this.ItemForcustCurrency.Size = new System.Drawing.Size(346, 28);
            this.ItemForcustCurrency.Text = "العملة :";
            this.ItemForcustCurrency.TextSize = new System.Drawing.Size(144, 23);
            this.ItemForcustCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup4.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup4.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForcustName,
            this.ItemForcustCountry,
            this.ItemForcustAddress,
            this.ItemForcustSalePrice,
            this.ItemForcustTaxNo,
            this.ItemForcustNameEn,
            this.ItemForcustCityEn,
            this.ItemForcustCity,
            this.ItemForcustPhnNo,
            this.ItemForcustEmail,
            this.ItemForcustAddressEn,
            this.ItemForcustCommercialRegister,
            this.ItemForcustCommercialRegisterEn,
            this.ItemForcustCountryEn,
            this.ItemForsupBankId,
            this.ItemForcusBuildingNo,
            this.ItemForcusAddNo,
            this.ItemForcusAnotherID,
            this.ItemForcusDistrict,
            this.ItemForcusDistrictEn});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 122);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 7, 13, 13);
            this.layoutControlGroup4.Size = new System.Drawing.Size(1061, 403);
            this.layoutControlGroup4.Text = "بيانات العميل";
            // 
            // ItemForcustName
            // 
            this.ItemForcustName.Control = this.custNameTextEdit;
            this.ItemForcustName.Location = new System.Drawing.Point(520, 0);
            this.ItemForcustName.Name = "ItemForcustName";
            this.ItemForcustName.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustName.Text = "إسم العميل :";
            this.ItemForcustName.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCountry
            // 
            this.ItemForcustCountry.Control = this.custCountryTextEdit;
            this.ItemForcustCountry.Location = new System.Drawing.Point(520, 28);
            this.ItemForcustCountry.Name = "ItemForcustCountry";
            this.ItemForcustCountry.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustCountry.Text = "الدولة :";
            this.ItemForcustCountry.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustAddress
            // 
            this.ItemForcustAddress.Control = this.custAddressTextEdit;
            this.ItemForcustAddress.Location = new System.Drawing.Point(520, 112);
            this.ItemForcustAddress.Name = "ItemForcustAddress";
            this.ItemForcustAddress.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustAddress.Text = "العنوان :";
            this.ItemForcustAddress.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustSalePrice
            // 
            this.ItemForcustSalePrice.Control = this.custSalePriceTextEdit;
            this.ItemForcustSalePrice.Location = new System.Drawing.Point(0, 168);
            this.ItemForcustSalePrice.Name = "ItemForcustSalePrice";
            this.ItemForcustSalePrice.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustSalePrice.Text = "سعر البيع :";
            this.ItemForcustSalePrice.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustTaxNo
            // 
            this.ItemForcustTaxNo.Control = this.custTaxNoTextEdit;
            this.ItemForcustTaxNo.Location = new System.Drawing.Point(520, 168);
            this.ItemForcustTaxNo.Name = "ItemForcustTaxNo";
            this.ItemForcustTaxNo.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustTaxNo.Text = "الرقم الضريبي :";
            this.ItemForcustTaxNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustNameEn
            // 
            this.ItemForcustNameEn.Control = this.custNameEnTextEdit;
            this.ItemForcustNameEn.Location = new System.Drawing.Point(0, 0);
            this.ItemForcustNameEn.Name = "ItemForcustNameEn";
            this.ItemForcustNameEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustNameEn.Text = "اسم العميل أنجليزية:";
            this.ItemForcustNameEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCityEn
            // 
            this.ItemForcustCityEn.Control = this.custCityEnTextEdit;
            this.ItemForcustCityEn.Location = new System.Drawing.Point(0, 56);
            this.ItemForcustCityEn.Name = "ItemForcustCityEn";
            this.ItemForcustCityEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustCityEn.Text = "المدينة أنجليزية:";
            this.ItemForcustCityEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCity
            // 
            this.ItemForcustCity.Control = this.custCityTextEdit;
            this.ItemForcustCity.Location = new System.Drawing.Point(520, 56);
            this.ItemForcustCity.Name = "ItemForcustCity";
            this.ItemForcustCity.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustCity.Text = "المدينة :";
            this.ItemForcustCity.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustPhnNo
            // 
            this.ItemForcustPhnNo.Control = this.custPhnNoTextEdit;
            this.ItemForcustPhnNo.Location = new System.Drawing.Point(520, 84);
            this.ItemForcustPhnNo.Name = "ItemForcustPhnNo";
            this.ItemForcustPhnNo.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustPhnNo.Text = "رقم الهاتف :";
            this.ItemForcustPhnNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustEmail
            // 
            this.ItemForcustEmail.Control = this.custEmailTextEdit;
            this.ItemForcustEmail.Location = new System.Drawing.Point(0, 84);
            this.ItemForcustEmail.Name = "ItemForcustEmail";
            this.ItemForcustEmail.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustEmail.Text = "البريد الإلكتروني :";
            this.ItemForcustEmail.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustAddressEn
            // 
            this.ItemForcustAddressEn.Control = this.custAddressEnTextEdit;
            this.ItemForcustAddressEn.Location = new System.Drawing.Point(0, 112);
            this.ItemForcustAddressEn.Name = "ItemForcustAddressEn";
            this.ItemForcustAddressEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustAddressEn.Text = "العنوان انجليزية:";
            this.ItemForcustAddressEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCommercialRegister
            // 
            this.ItemForcustCommercialRegister.Control = this.CommercialRegisterTextEdit;
            this.ItemForcustCommercialRegister.Location = new System.Drawing.Point(520, 196);
            this.ItemForcustCommercialRegister.Name = "ItemForcustCommercialRegister";
            this.ItemForcustCommercialRegister.Size = new System.Drawing.Size(523, 28);
            this.ItemForcustCommercialRegister.Text = "سجل تجاري :";
            this.ItemForcustCommercialRegister.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCommercialRegisterEn
            // 
            this.ItemForcustCommercialRegisterEn.Control = this.CommercialRegisterEnTextEdit;
            this.ItemForcustCommercialRegisterEn.Location = new System.Drawing.Point(0, 196);
            this.ItemForcustCommercialRegisterEn.Name = "ItemForcustCommercialRegisterEn";
            this.ItemForcustCommercialRegisterEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustCommercialRegisterEn.Text = "الرمز البريدي :";
            this.ItemForcustCommercialRegisterEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcustCountryEn
            // 
            this.ItemForcustCountryEn.Control = this.custCountryEnTextEdit;
            this.ItemForcustCountryEn.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcustCountryEn.CustomizationFormText = "الدولة :";
            this.ItemForcustCountryEn.Location = new System.Drawing.Point(0, 28);
            this.ItemForcustCountryEn.Name = "ItemForcustCountryEn";
            this.ItemForcustCountryEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcustCountryEn.Text = "الدولة انجليزي:";
            this.ItemForcustCountryEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForsupBankId
            // 
            this.ItemForsupBankId.Control = this.cusBankIdTextEdit;
            this.ItemForsupBankId.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForsupBankId.CustomizationFormText = "البنك :";
            this.ItemForsupBankId.Location = new System.Drawing.Point(520, 252);
            this.ItemForsupBankId.Name = "ItemForsupBankId";
            this.ItemForsupBankId.Size = new System.Drawing.Size(523, 85);
            this.ItemForsupBankId.Text = "البنك :";
            this.ItemForsupBankId.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcusBuildingNo
            // 
            this.ItemForcusBuildingNo.Control = this.cusBuildingNoTextEdit;
            this.ItemForcusBuildingNo.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcusBuildingNo.CustomizationFormText = "سجل تجاري :";
            this.ItemForcusBuildingNo.Location = new System.Drawing.Point(520, 224);
            this.ItemForcusBuildingNo.Name = "ItemForcusBuildingNo";
            this.ItemForcusBuildingNo.Size = new System.Drawing.Size(523, 28);
            this.ItemForcusBuildingNo.Text = "رقم المبنى:";
            this.ItemForcusBuildingNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcusAddNo
            // 
            this.ItemForcusAddNo.Control = this.cusAddNoTextEdit;
            this.ItemForcusAddNo.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcusAddNo.CustomizationFormText = "سجل تجاري :";
            this.ItemForcusAddNo.Location = new System.Drawing.Point(0, 224);
            this.ItemForcusAddNo.Name = "ItemForcusAddNo";
            this.ItemForcusAddNo.Size = new System.Drawing.Size(520, 28);
            this.ItemForcusAddNo.Text = "الرقم الاضافي:";
            this.ItemForcusAddNo.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcusAnotherID
            // 
            this.ItemForcusAnotherID.Control = this.cusAnotherIDTextEdit;
            this.ItemForcusAnotherID.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcusAnotherID.CustomizationFormText = "سجل تجاري :";
            this.ItemForcusAnotherID.Location = new System.Drawing.Point(0, 252);
            this.ItemForcusAnotherID.Name = "ItemForcusAnotherID";
            this.ItemForcusAnotherID.Size = new System.Drawing.Size(520, 85);
            this.ItemForcusAnotherID.Text = "معرف اخر:";
            this.ItemForcusAnotherID.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcusDistrict
            // 
            this.ItemForcusDistrict.Control = this.cusDistrictTextEdit;
            this.ItemForcusDistrict.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcusDistrict.CustomizationFormText = "العنوان :";
            this.ItemForcusDistrict.Location = new System.Drawing.Point(520, 140);
            this.ItemForcusDistrict.Name = "ItemForcusDistrict";
            this.ItemForcusDistrict.Size = new System.Drawing.Size(523, 28);
            this.ItemForcusDistrict.Text = "الحي:";
            this.ItemForcusDistrict.TextSize = new System.Drawing.Size(144, 23);
            // 
            // ItemForcusDistrictEn
            // 
            this.ItemForcusDistrictEn.Control = this.cusDistrictEnTextEdit;
            this.ItemForcusDistrictEn.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForcusDistrictEn.CustomizationFormText = "العنوان :";
            this.ItemForcusDistrictEn.Location = new System.Drawing.Point(0, 140);
            this.ItemForcusDistrictEn.Name = "ItemForcusDistrictEn";
            this.ItemForcusDistrictEn.Size = new System.Drawing.Size(520, 28);
            this.ItemForcusDistrictEn.Text = "الحي انجليزي:";
            this.ItemForcusDistrictEn.TextSize = new System.Drawing.Size(144, 23);
            // 
            // navigationPageInvoices
            // 
            this.navigationPageInvoices.Controls.Add(this.gridControl1);
            this.navigationPageInvoices.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigationPageInvoices.Name = "navigationPageInvoices";
            this.navigationPageInvoices.Size = new System.Drawing.Size(1075, 535);
            // 
            // navigationPageBalance
            // 
            this.navigationPageBalance.Controls.Add(this.layoutControl2);
            this.navigationPageBalance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigationPageBalance.Name = "navigationPageBalance";
            this.navigationPageBalance.Size = new System.Drawing.Size(1075, 535);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControlPeriodBalance);
            this.layoutControl2.Controls.Add(this.gridControl3);
            this.layoutControl2.Controls.Add(this.textEditDtStart);
            this.layoutControl2.Controls.Add(this.textEditDtEnd);
            this.layoutControl2.Controls.Add(this.btnCalculatePeriodBalance);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 159, 650, 400);
            this.layoutControl2.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl2.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl2.Root = this.layoutControlGroup6;
            this.layoutControl2.Size = new System.Drawing.Size(1075, 535);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControlPeriodBalance
            // 
            this.gridControlPeriodBalance.DataSource = this.clsBalanceColumnsDataBindingSource2;
            this.gridControlPeriodBalance.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gridControlPeriodBalance.Location = new System.Drawing.Point(517, 127);
            this.gridControlPeriodBalance.MainView = this.gridViewPeriodBalance;
            this.gridControlPeriodBalance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControlPeriodBalance.MenuManager = this.ribbonControl1;
            this.gridControlPeriodBalance.Name = "gridControlPeriodBalance";
            this.gridControlPeriodBalance.Size = new System.Drawing.Size(554, 385);
            this.gridControlPeriodBalance.TabIndex = 8;
            this.gridControlPeriodBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPeriodBalance});
            // 
            // clsBalanceColumnsDataBindingSource2
            // 
            this.clsBalanceColumnsDataBindingSource2.DataSource = typeof(AccountingMS.ClsBalanceColumnsData);
            // 
            // gridViewPeriodBalance
            // 
            this.gridViewPeriodBalance.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridViewPeriodBalance.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewPeriodBalance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridViewPeriodBalance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldebit2,
            this.colcredit2,
            this.colcurrentBalance2,
            this.coldtStart,
            this.coldtEnd});
            this.gridViewPeriodBalance.DetailHeight = 485;
            this.gridViewPeriodBalance.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewPeriodBalance.GridControl = this.gridControlPeriodBalance;
            this.gridViewPeriodBalance.Name = "gridViewPeriodBalance";
            this.gridViewPeriodBalance.OptionsBehavior.Editable = false;
            this.gridViewPeriodBalance.OptionsBehavior.ReadOnly = true;
            this.gridViewPeriodBalance.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewPeriodBalance.OptionsCustomization.AllowFilter = false;
            this.gridViewPeriodBalance.OptionsMenu.EnableColumnMenu = false;
            this.gridViewPeriodBalance.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewPeriodBalance.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewPeriodBalance.OptionsView.ShowGroupPanel = false;
            this.gridViewPeriodBalance.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPeriodBalance.OptionsView.ShowIndicator = false;
            this.gridViewPeriodBalance.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // coldebit2
            // 
            this.coldebit2.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coldebit2.AppearanceCell.Options.UseForeColor = true;
            this.coldebit2.AppearanceCell.Options.UseTextOptions = true;
            this.coldebit2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coldebit2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coldebit2.AppearanceHeader.Options.UseForeColor = true;
            this.coldebit2.Caption = "مدين";
            this.coldebit2.DisplayFormat.FormatString = "n2";
            this.coldebit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldebit2.FieldName = "debit";
            this.coldebit2.MinWidth = 26;
            this.coldebit2.Name = "coldebit2";
            this.coldebit2.Visible = true;
            this.coldebit2.VisibleIndex = 0;
            this.coldebit2.Width = 99;
            // 
            // colcredit2
            // 
            this.colcredit2.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.colcredit2.AppearanceCell.Options.UseForeColor = true;
            this.colcredit2.AppearanceCell.Options.UseTextOptions = true;
            this.colcredit2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcredit2.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colcredit2.AppearanceHeader.Options.UseForeColor = true;
            this.colcredit2.Caption = "دائن";
            this.colcredit2.DisplayFormat.FormatString = "n2";
            this.colcredit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colcredit2.FieldName = "credit";
            this.colcredit2.MinWidth = 26;
            this.colcredit2.Name = "colcredit2";
            this.colcredit2.Visible = true;
            this.colcredit2.VisibleIndex = 1;
            this.colcredit2.Width = 99;
            // 
            // colcurrentBalance2
            // 
            this.colcurrentBalance2.AppearanceCell.Options.UseTextOptions = true;
            this.colcurrentBalance2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcurrentBalance2.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colcurrentBalance2.AppearanceHeader.Options.UseForeColor = true;
            this.colcurrentBalance2.Caption = "الرصيد الحالي";
            this.colcurrentBalance2.DisplayFormat.FormatString = "n2";
            this.colcurrentBalance2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colcurrentBalance2.FieldName = "currentBalance";
            this.colcurrentBalance2.MinWidth = 120;
            this.colcurrentBalance2.Name = "colcurrentBalance2";
            this.colcurrentBalance2.Visible = true;
            this.colcurrentBalance2.VisibleIndex = 2;
            this.colcurrentBalance2.Width = 120;
            // 
            // coldtStart
            // 
            this.coldtStart.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.coldtStart.AppearanceCell.Options.UseForeColor = true;
            this.coldtStart.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.coldtStart.AppearanceHeader.Options.UseForeColor = true;
            this.coldtStart.Caption = "من تاريخ";
            this.coldtStart.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.coldtStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtStart.FieldName = "dtStart";
            this.coldtStart.MinWidth = 26;
            this.coldtStart.Name = "coldtStart";
            this.coldtStart.Visible = true;
            this.coldtStart.VisibleIndex = 3;
            this.coldtStart.Width = 99;
            // 
            // coldtEnd
            // 
            this.coldtEnd.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.coldtEnd.AppearanceCell.Options.UseForeColor = true;
            this.coldtEnd.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.coldtEnd.AppearanceHeader.Options.UseForeColor = true;
            this.coldtEnd.Caption = "إلى تاريخ";
            this.coldtEnd.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.coldtEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtEnd.FieldName = "dtEnd";
            this.coldtEnd.MinWidth = 26;
            this.coldtEnd.Name = "coldtEnd";
            this.coldtEnd.Visible = true;
            this.coldtEnd.VisibleIndex = 4;
            this.coldtEnd.Width = 99;
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.clsBalanceColumnsDataBindingSource1;
            this.gridControl3.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gridControl3.Location = new System.Drawing.Point(4, 51);
            this.gridControl3.MainView = this.gridViewCurrentBalance;
            this.gridControl3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.gridControl3.MenuManager = this.ribbonControl1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(503, 164);
            this.gridControl3.TabIndex = 7;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCurrentBalance});
            // 
            // clsBalanceColumnsDataBindingSource1
            // 
            this.clsBalanceColumnsDataBindingSource1.DataSource = typeof(AccountingMS.ClsBalanceColumnsData);
            // 
            // gridViewCurrentBalance
            // 
            this.gridViewCurrentBalance.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridViewCurrentBalance.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewCurrentBalance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridViewCurrentBalance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldebit1,
            this.colcredit1,
            this.colcurrentBalance1});
            this.gridViewCurrentBalance.DetailHeight = 485;
            this.gridViewCurrentBalance.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewCurrentBalance.GridControl = this.gridControl3;
            this.gridViewCurrentBalance.Name = "gridViewCurrentBalance";
            this.gridViewCurrentBalance.OptionsBehavior.Editable = false;
            this.gridViewCurrentBalance.OptionsBehavior.ReadOnly = true;
            this.gridViewCurrentBalance.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewCurrentBalance.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewCurrentBalance.OptionsMenu.EnableColumnMenu = false;
            this.gridViewCurrentBalance.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCurrentBalance.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewCurrentBalance.OptionsView.ShowGroupPanel = false;
            this.gridViewCurrentBalance.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCurrentBalance.OptionsView.ShowIndicator = false;
            this.gridViewCurrentBalance.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // coldebit1
            // 
            this.coldebit1.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coldebit1.AppearanceCell.Options.UseForeColor = true;
            this.coldebit1.AppearanceCell.Options.UseTextOptions = true;
            this.coldebit1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.coldebit1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coldebit1.AppearanceHeader.Options.UseForeColor = true;
            this.coldebit1.Caption = "مدين";
            this.coldebit1.DisplayFormat.FormatString = "n2";
            this.coldebit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldebit1.FieldName = "debit";
            this.coldebit1.MinWidth = 26;
            this.coldebit1.Name = "coldebit1";
            this.coldebit1.Visible = true;
            this.coldebit1.VisibleIndex = 0;
            this.coldebit1.Width = 99;
            // 
            // colcredit1
            // 
            this.colcredit1.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.colcredit1.AppearanceCell.Options.UseForeColor = true;
            this.colcredit1.AppearanceCell.Options.UseTextOptions = true;
            this.colcredit1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcredit1.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.colcredit1.AppearanceHeader.Options.UseForeColor = true;
            this.colcredit1.Caption = "دائن";
            this.colcredit1.DisplayFormat.FormatString = "n2";
            this.colcredit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colcredit1.FieldName = "credit";
            this.colcredit1.MinWidth = 26;
            this.colcredit1.Name = "colcredit1";
            this.colcredit1.Visible = true;
            this.colcredit1.VisibleIndex = 1;
            this.colcredit1.Width = 99;
            // 
            // colcurrentBalance1
            // 
            this.colcurrentBalance1.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colcurrentBalance1.AppearanceCell.Options.UseForeColor = true;
            this.colcurrentBalance1.AppearanceCell.Options.UseTextOptions = true;
            this.colcurrentBalance1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcurrentBalance1.Caption = "الرصيد الحالي";
            this.colcurrentBalance1.DisplayFormat.FormatString = "n2";
            this.colcurrentBalance1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colcurrentBalance1.FieldName = "currentBalance";
            this.colcurrentBalance1.MinWidth = 26;
            this.colcurrentBalance1.Name = "colcurrentBalance1";
            this.colcurrentBalance1.Visible = true;
            this.colcurrentBalance1.VisibleIndex = 2;
            this.colcurrentBalance1.Width = 99;
            // 
            // textEditDtStart
            // 
            this.textEditDtStart.EditValue = null;
            this.textEditDtStart.Location = new System.Drawing.Point(651, 49);
            this.textEditDtStart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textEditDtStart.MenuManager = this.ribbonControl1;
            this.textEditDtStart.Name = "textEditDtStart";
            this.textEditDtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtStart.Properties.Mask.BeepOnError = true;
            this.textEditDtStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEditDtStart.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.textEditDtStart.Properties.MaskSettings.Set("allowBlankInput", true);
            this.textEditDtStart.Properties.MaskSettings.Set("mask", "(0?[1-9]|1[012])/([012]?[1-9]|[123]0|31)/([123][0-9])?[0-9][0-9]");
            this.textEditDtStart.Size = new System.Drawing.Size(342, 24);
            this.textEditDtStart.StyleController = this.layoutControl2;
            this.textEditDtStart.TabIndex = 0;
            // 
            // textEditDtEnd
            // 
            this.textEditDtEnd.EditValue = null;
            this.textEditDtEnd.Location = new System.Drawing.Point(651, 77);
            this.textEditDtEnd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textEditDtEnd.MenuManager = this.ribbonControl1;
            this.textEditDtEnd.Name = "textEditDtEnd";
            this.textEditDtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtEnd.Properties.Mask.BeepOnError = true;
            this.textEditDtEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEditDtEnd.Properties.MaskSettings.Set("mask", "yyyy/MM/dd");
            this.textEditDtEnd.Size = new System.Drawing.Size(342, 24);
            this.textEditDtEnd.StyleController = this.layoutControl2;
            this.textEditDtEnd.TabIndex = 1;
            // 
            // btnCalculatePeriodBalance
            // 
            this.btnCalculatePeriodBalance.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnCalculatePeriodBalance.Appearance.Options.UseFont = true;
            this.btnCalculatePeriodBalance.Location = new System.Drawing.Point(517, 51);
            this.btnCalculatePeriodBalance.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCalculatePeriodBalance.Name = "btnCalculatePeriodBalance";
            this.btnCalculatePeriodBalance.Size = new System.Drawing.Size(130, 48);
            this.btnCalculatePeriodBalance.StyleController = this.layoutControl2;
            this.btnCalculatePeriodBalance.TabIndex = 2;
            this.btnCalculatePeriodBalance.Text = "بحث";
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup6.GroupBordersVisible = false;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup8});
            this.layoutControlGroup6.Name = "Root";
            this.layoutControlGroup6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 4, 4);
            this.layoutControlGroup6.Size = new System.Drawing.Size(1075, 535);
            this.layoutControlGroup6.TextVisible = false;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup8.GroupBordersVisible = false;
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupPeriodBalance,
            this.layoutControlGroupCurrentBalance,
            this.emptySpaceItem1,
            this.splitterItem1});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Size = new System.Drawing.Size(1071, 527);
            this.layoutControlGroup8.Text = "layoutControlGroup2";
            // 
            // layoutControlGroupPeriodBalance
            // 
            this.layoutControlGroupPeriodBalance.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupPeriodBalance.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroupPeriodBalance.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupPeriodBalance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDtStart,
            this.layoutControlItem3,
            this.simpleSeparator1,
            this.lciDtEnd,
            this.layoutControlItem1});
            this.layoutControlGroupPeriodBalance.Location = new System.Drawing.Point(512, 0);
            this.layoutControlGroupPeriodBalance.Name = "layoutControlGroupPeriodBalance";
            this.layoutControlGroupPeriodBalance.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 13);
            this.layoutControlGroupPeriodBalance.Size = new System.Drawing.Size(559, 527);
            this.layoutControlGroupPeriodBalance.Text = "رصيد الفترة";
            // 
            // lciDtStart
            // 
            this.lciDtStart.Control = this.textEditDtStart;
            this.lciDtStart.Location = new System.Drawing.Point(133, 0);
            this.lciDtStart.Name = "lciDtStart";
            this.lciDtStart.Size = new System.Drawing.Size(422, 28);
            this.lciDtStart.Text = "من تاريخ :";
            this.lciDtStart.TextSize = new System.Drawing.Size(72, 23);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControlPeriodBalance;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 0, 4, 4);
            this.layoutControlItem3.Size = new System.Drawing.Size(555, 393);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 56);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 4, 4);
            this.simpleSeparator1.Size = new System.Drawing.Size(555, 20);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 5, 13);
            // 
            // lciDtEnd
            // 
            this.lciDtEnd.Control = this.textEditDtEnd;
            this.lciDtEnd.Location = new System.Drawing.Point(133, 28);
            this.lciDtEnd.Name = "lciDtEnd";
            this.lciDtEnd.Size = new System.Drawing.Size(422, 28);
            this.lciDtEnd.Text = "إلى تاريخ :";
            this.lciDtEnd.TextSize = new System.Drawing.Size(72, 23);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCalculatePeriodBalance;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(41, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 2, 4, 4);
            this.layoutControlItem1.Size = new System.Drawing.Size(133, 56);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "بحث";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroupCurrentBalance
            // 
            this.layoutControlGroupCurrentBalance.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupCurrentBalance.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupCurrentBalance.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupCurrentBalance.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroupCurrentBalance.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupCurrentBalance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroupCurrentBalance.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupCurrentBalance.Name = "layoutControlGroupCurrentBalance";
            this.layoutControlGroupCurrentBalance.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 13);
            this.layoutControlGroupCurrentBalance.Size = new System.Drawing.Size(507, 230);
            this.layoutControlGroupCurrentBalance.Text = "الرصيد الحالي";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl3;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 4, 4);
            this.layoutControlItem2.Size = new System.Drawing.Size(503, 172);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(507, 297);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHide = false;
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.IsCollapsible = DevExpress.Utils.DefaultBoolean.True;
            this.splitterItem1.Location = new System.Drawing.Point(507, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 527);
            // 
            // navigationPageEntries
            // 
            this.navigationPageEntries.Controls.Add(this.gridControl2);
            this.navigationPageEntries.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigationPageEntries.Name = "navigationPageEntries";
            this.navigationPageEntries.Size = new System.Drawing.Size(1075, 535);
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.tblEntrySubBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControl2.MenuManager = this.ribbonControl1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1075, 535);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // tblEntrySubBindingSource
            // 
            this.tblEntrySubBindingSource.DataSource = typeof(AccountingMS.tblEntrySub);
            // 
            // gridView3
            // 
            this.gridView3.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView3.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colentAccNo,
            this.colentAccName,
            this.colentBoxNo,
            this.colentStatus,
            this.colentNo,
            this.colentDesc,
            this.colentDebit,
            this.colentCredit,
            this.colentDebitFrgn,
            this.colentCreditFrgn,
            this.colentTaxPercent,
            this.colentTaxPrice,
            this.colentCurrency,
            this.colentCurChange,
            this.colentCusNo,
            this.colentCusName,
            this.colentDate});
            this.gridView3.DetailHeight = 485;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView3.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsFind.AlwaysVisible = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.gridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView3.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colentAccNo
            // 
            this.colentAccNo.FieldName = "entAccNo";
            this.colentAccNo.MinWidth = 26;
            this.colentAccNo.Name = "colentAccNo";
            this.colentAccNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentAccNo.Width = 99;
            // 
            // colentAccName
            // 
            this.colentAccName.FieldName = "entAccName";
            this.colentAccName.MinWidth = 26;
            this.colentAccName.Name = "colentAccName";
            this.colentAccName.OptionsColumn.ShowInCustomizationForm = false;
            this.colentAccName.Width = 99;
            // 
            // colentBoxNo
            // 
            this.colentBoxNo.FieldName = "entBoxNo";
            this.colentBoxNo.MinWidth = 26;
            this.colentBoxNo.Name = "colentBoxNo";
            this.colentBoxNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentBoxNo.Width = 99;
            // 
            // colentStatus
            // 
            this.colentStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colentStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentStatus.Caption = "نوع السند";
            this.colentStatus.FieldName = "entStatus";
            this.colentStatus.MinWidth = 26;
            this.colentStatus.Name = "colentStatus";
            this.colentStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "entStatus", "العدد : {0}")});
            this.colentStatus.Visible = true;
            this.colentStatus.VisibleIndex = 0;
            this.colentStatus.Width = 90;
            // 
            // colentNo
            // 
            this.colentNo.AppearanceCell.Options.UseTextOptions = true;
            this.colentNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentNo.Caption = "رقم السند";
            this.colentNo.FieldName = "entNo";
            this.colentNo.MinWidth = 26;
            this.colentNo.Name = "colentNo";
            this.colentNo.Visible = true;
            this.colentNo.VisibleIndex = 1;
            this.colentNo.Width = 90;
            // 
            // colentDesc
            // 
            this.colentDesc.Caption = "البيان";
            this.colentDesc.FieldName = "entDesc";
            this.colentDesc.MinWidth = 26;
            this.colentDesc.Name = "colentDesc";
            this.colentDesc.Visible = true;
            this.colentDesc.VisibleIndex = 2;
            this.colentDesc.Width = 90;
            // 
            // colentDebit
            // 
            this.colentDebit.AppearanceCell.Options.UseTextOptions = true;
            this.colentDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentDebit.Caption = "مدين";
            this.colentDebit.DisplayFormat.FormatString = "#,#.##";
            this.colentDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentDebit.FieldName = "entDebit";
            this.colentDebit.MinWidth = 26;
            this.colentDebit.Name = "colentDebit";
            this.colentDebit.Visible = true;
            this.colentDebit.VisibleIndex = 3;
            this.colentDebit.Width = 90;
            // 
            // colentCredit
            // 
            this.colentCredit.AppearanceCell.Options.UseTextOptions = true;
            this.colentCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCredit.Caption = "دائن";
            this.colentCredit.DisplayFormat.FormatString = "#,#.##";
            this.colentCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentCredit.FieldName = "entCredit";
            this.colentCredit.MinWidth = 26;
            this.colentCredit.Name = "colentCredit";
            this.colentCredit.Visible = true;
            this.colentCredit.VisibleIndex = 4;
            this.colentCredit.Width = 90;
            // 
            // colentDebitFrgn
            // 
            this.colentDebitFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colentDebitFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentDebitFrgn.Caption = "مدين عملةأجنبيه";
            this.colentDebitFrgn.DisplayFormat.FormatString = "#,#.##";
            this.colentDebitFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentDebitFrgn.FieldName = "entDebitFrgn";
            this.colentDebitFrgn.MinWidth = 120;
            this.colentDebitFrgn.Name = "colentDebitFrgn";
            this.colentDebitFrgn.Visible = true;
            this.colentDebitFrgn.VisibleIndex = 5;
            this.colentDebitFrgn.Width = 120;
            // 
            // colentCreditFrgn
            // 
            this.colentCreditFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colentCreditFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCreditFrgn.Caption = "دائن عملةأجنبيه";
            this.colentCreditFrgn.DisplayFormat.FormatString = "#,#.##";
            this.colentCreditFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentCreditFrgn.FieldName = "entCreditFrgn";
            this.colentCreditFrgn.MinWidth = 120;
            this.colentCreditFrgn.Name = "colentCreditFrgn";
            this.colentCreditFrgn.Visible = true;
            this.colentCreditFrgn.VisibleIndex = 6;
            this.colentCreditFrgn.Width = 120;
            // 
            // colentTaxPercent
            // 
            this.colentTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colentTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentTaxPercent.Caption = "نسبة الضريبة";
            this.colentTaxPercent.FieldName = "entTaxPercent";
            this.colentTaxPercent.MinWidth = 26;
            this.colentTaxPercent.Name = "colentTaxPercent";
            this.colentTaxPercent.Visible = true;
            this.colentTaxPercent.VisibleIndex = 7;
            this.colentTaxPercent.Width = 90;
            // 
            // colentTaxPrice
            // 
            this.colentTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colentTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentTaxPrice.Caption = "الصريبة";
            this.colentTaxPrice.DisplayFormat.FormatString = "#,#.##";
            this.colentTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentTaxPrice.FieldName = "entTaxPrice";
            this.colentTaxPrice.MinWidth = 26;
            this.colentTaxPrice.Name = "colentTaxPrice";
            this.colentTaxPrice.Visible = true;
            this.colentTaxPrice.VisibleIndex = 8;
            this.colentTaxPrice.Width = 90;
            // 
            // colentCurrency
            // 
            this.colentCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colentCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCurrency.Caption = "العمله";
            this.colentCurrency.FieldName = "entCurrency";
            this.colentCurrency.MaxWidth = 94;
            this.colentCurrency.MinWidth = 26;
            this.colentCurrency.Name = "colentCurrency";
            this.colentCurrency.Visible = true;
            this.colentCurrency.VisibleIndex = 9;
            this.colentCurrency.Width = 91;
            // 
            // colentCurChange
            // 
            this.colentCurChange.AppearanceCell.Options.UseTextOptions = true;
            this.colentCurChange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCurChange.Caption = "سعر الصرف";
            this.colentCurChange.FieldName = "entCurChange";
            this.colentCurChange.MinWidth = 26;
            this.colentCurChange.Name = "colentCurChange";
            this.colentCurChange.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCurChange.Width = 99;
            // 
            // colentCusNo
            // 
            this.colentCusNo.FieldName = "entCusNo";
            this.colentCusNo.MinWidth = 26;
            this.colentCusNo.Name = "colentCusNo";
            this.colentCusNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCusNo.Width = 99;
            // 
            // colentCusName
            // 
            this.colentCusName.FieldName = "entCusName";
            this.colentCusName.MinWidth = 26;
            this.colentCusName.Name = "colentCusName";
            this.colentCusName.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCusName.Width = 99;
            // 
            // colentDate
            // 
            this.colentDate.Caption = "التاريخ";
            this.colentDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colentDate.FieldName = "entDate";
            this.colentDate.MinWidth = 26;
            this.colentDate.Name = "colentDate";
            this.colentDate.Visible = true;
            this.colentDate.VisibleIndex = 10;
            this.colentDate.Width = 66;
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidateHiddenControls = false;
            // 
            // formAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 720);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "formAddCustomer";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة عميل";
            this.Load += new System.EventHandler(this.formAddCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommercialRegisterEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommercialRegisterTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAddressEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCityEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNameEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAccNoLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAccNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custPhnNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custEmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCellingCreditTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCountryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCountryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCurrencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custSalePriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custTaxNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custCountryEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusBankIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusBuildingNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusAddNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusAnotherIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDistrictTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusDistrictEnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAccNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAccName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCellingCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustTaxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustNameEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCityEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustPhnNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustAddressEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCommercialRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCommercialRegisterEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcustCountryEn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsupBankId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusBuildingNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusAddNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusAnotherID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcusDistrictEn)).EndInit();
            this.navigationPageInvoices.ResumeLayout(false);
            this.navigationPageBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPeriodBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsBalanceColumnsDataBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPeriodBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsBalanceColumnsDataBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCurrentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPeriodBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCurrentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.navigationPageEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageMain;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageInvoices;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageBalance;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageEntries;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private System.Windows.Forms.BindingSource tblCustomerBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit custNoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit custAccNoLookUpEdit;
        private DevExpress.XtraEditors.TextEdit custAccNameTextEdit;
        private DevExpress.XtraEditors.TextEdit custNameTextEdit;
        private DevExpress.XtraEditors.TextEdit custPhnNoTextEdit;
        private DevExpress.XtraEditors.TextEdit custCityTextEdit;
        private DevExpress.XtraEditors.TextEdit custAddressTextEdit;
        private DevExpress.XtraEditors.TextEdit custEmailTextEdit;
        private DevExpress.XtraEditors.TextEdit custCellingCreditTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustAccNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustAccName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCellingCredit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCountry;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustPhnNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustEmail;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageInvoices;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.BindingSource tblSupplyMainBindingSource;
        private DevExpress.XtraBars.BarButtonItem bbiClose2;
        private DevExpress.XtraBars.BarButtonItem bbiPrint2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageBalance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupBalance;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupCurrentBalance;
        private DevExpress.XtraEditors.DateEdit textEditDtStart;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPeriodBalance;
        private DevExpress.XtraLayout.LayoutControlItem lciDtStart;
        private DevExpress.XtraEditors.DateEdit textEditDtEnd;
        private DevExpress.XtraLayout.LayoutControlItem lciDtEnd;
        private DevExpress.XtraEditors.SimpleButton btnCalculatePeriodBalance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageEntries;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEntries;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private System.Windows.Forms.BindingSource tblEntrySubBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colentBoxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colentDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colentCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colentDebitFrgn;
        private DevExpress.XtraGrid.Columns.GridColumn colentCreditFrgn;
        private DevExpress.XtraGrid.Columns.GridColumn colentTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colentTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colentCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colentCurChange;
        private DevExpress.XtraGrid.Columns.GridColumn colentCusNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentCusName;
        private DevExpress.XtraGrid.Columns.GridColumn colentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colentDate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
        private DevExpress.XtraGrid.Columns.GridColumn colsupMsur;
        private DevExpress.XtraGrid.Columns.GridColumn colsupQuanMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsupQuanSub;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
        private DevExpress.XtraGrid.Columns.GridColumn supSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDebit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupId;
        private DevExpress.XtraGrid.Columns.GridColumn colsupStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colsupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTotalFrgn;
        private DevExpress.XtraGrid.Columns.GridColumn colsupCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDate;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colsupIsCash;
        private DevExpress.XtraBars.BarButtonItem bbiClose1;
        private DevExpress.XtraBars.BarButtonItem bbiCLose3;
        private DevExpress.XtraBars.BarButtonItem bbiPrint3;
        private DevExpress.XtraBars.BarEditItem bbiReportInvoiceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private System.Windows.Forms.BindingSource clsBalanceColumnsDataBindingSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCurrentBalance;
        private DevExpress.XtraGrid.Columns.GridColumn coldebit1;
        private DevExpress.XtraGrid.Columns.GridColumn colcredit1;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrentBalance1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControlPeriodBalance;
        private System.Windows.Forms.BindingSource clsBalanceColumnsDataBindingSource2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPeriodBalance;
        private DevExpress.XtraGrid.Columns.GridColumn coldebit2;
        private DevExpress.XtraGrid.Columns.GridColumn colcredit2;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrentBalance2;
        private DevExpress.XtraGrid.Columns.GridColumn coldtStart;
        private DevExpress.XtraGrid.Columns.GridColumn coldtEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit custCountryTextEdit;
        private System.Windows.Forms.BindingSource tblCountryBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarCheckItem bbiAutoAccNo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAutoAddAccNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCurrency;
        private DevExpress.XtraEditors.LookUpEdit custCurrencyTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustSalePrice;
        private DevExpress.XtraEditors.LookUpEdit custSalePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit custTaxNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustTaxNo;
        private DevExpress.XtraEditors.TextEdit custAddressEnTextEdit;
        private DevExpress.XtraEditors.TextEdit custCityEnTextEdit;
        private DevExpress.XtraEditors.TextEdit custNameEnTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustNameEn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCityEn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustAddressEn;
        private DevExpress.XtraEditors.TextEdit CommercialRegisterEnTextEdit;
        private DevExpress.XtraEditors.TextEdit CommercialRegisterTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCommercialRegister;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCommercialRegisterEn;
        private DevExpress.XtraEditors.LookUpEdit custCountryEnTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcustCountryEn;
        private DevExpress.XtraEditors.LookUpEdit cusBankIdTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsupBankId;
        private System.Windows.Forms.BindingSource tblBankBindingSource;
        private DevExpress.XtraEditors.TextEdit cusBuildingNoTextEdit;
        private DevExpress.XtraEditors.TextEdit cusAddNoTextEdit;
        private DevExpress.XtraEditors.TextEdit cusAnotherIDTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcusBuildingNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcusAddNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcusAnotherID;
        private DevExpress.XtraEditors.TextEdit cusDistrictTextEdit;
        private DevExpress.XtraEditors.TextEdit cusDistrictEnTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcusDistrict;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcusDistrictEn;
    }
}