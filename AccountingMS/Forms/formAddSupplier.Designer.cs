namespace AccountingMS
{
    partial class formAddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddSupplier));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
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
            this.colsupIsCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReportInvoiceType = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.bbiCLose3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAutoAccNo = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPageMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAutoAddAccNo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageBalance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupBalance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageInvoices = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupInvoices = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageEntries = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupEntries = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.tblSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.splNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.splNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splPhnNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splAccNoTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.splTaxNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splCityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splEmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splCountryTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblCountryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splCurrencyTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForsplNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplAccNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplTaxNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForsplName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplPhnNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplCountry = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForsplEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageMain = new DevExpress.XtraBars.Navigation.NavigationPage();
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
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupCurrentBalance = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.navigationPageInvoices = new DevExpress.XtraBars.Navigation.NavigationPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splPhnNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splAccNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splTaxNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splEmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCountryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCountryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCurrencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplAccNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplTaxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplPhnNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPageMain.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCurrentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.navigationPageInvoices.SuspendLayout();
            this.navigationPageEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
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
            this.gridView2.DetailHeight = 377;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colsupPrdNo
            // 
            this.colsupPrdNo.Caption = "رقم الصنف";
            this.colsupPrdNo.FieldName = "supPrdNo";
            this.colsupPrdNo.MinWidth = 23;
            this.colsupPrdNo.Name = "colsupPrdNo";
            this.colsupPrdNo.Visible = true;
            this.colsupPrdNo.VisibleIndex = 0;
            this.colsupPrdNo.Width = 87;
            // 
            // colsupPrdName
            // 
            this.colsupPrdName.Caption = "إسم الصنف";
            this.colsupPrdName.FieldName = "supPrdName";
            this.colsupPrdName.MinWidth = 23;
            this.colsupPrdName.Name = "colsupPrdName";
            this.colsupPrdName.OptionsColumn.AllowEdit = false;
            this.colsupPrdName.OptionsColumn.TabStop = false;
            this.colsupPrdName.Visible = true;
            this.colsupPrdName.VisibleIndex = 1;
            this.colsupPrdName.Width = 87;
            // 
            // colsupMsur
            // 
            this.colsupMsur.AppearanceCell.Options.UseTextOptions = true;
            this.colsupMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupMsur.Caption = "وحدة القياس";
            this.colsupMsur.FieldName = "supMsur";
            this.colsupMsur.MinWidth = 23;
            this.colsupMsur.Name = "colsupMsur";
            this.colsupMsur.OptionsColumn.AllowEdit = false;
            this.colsupMsur.OptionsColumn.TabStop = false;
            this.colsupMsur.Visible = true;
            this.colsupMsur.VisibleIndex = 2;
            this.colsupMsur.Width = 87;
            // 
            // colsupQuanMain
            // 
            this.colsupQuanMain.AppearanceCell.Options.UseTextOptions = true;
            this.colsupQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupQuanMain.Caption = "الكمية";
            this.colsupQuanMain.FieldName = "supQuanMain";
            this.colsupQuanMain.MinWidth = 23;
            this.colsupQuanMain.Name = "colsupQuanMain";
            this.colsupQuanMain.Visible = true;
            this.colsupQuanMain.VisibleIndex = 3;
            this.colsupQuanMain.Width = 87;
            // 
            // colsupQuanSub
            // 
            this.colsupQuanSub.Caption = "الكمية الفرعية";
            this.colsupQuanSub.FieldName = "supQuanSub";
            this.colsupQuanSub.MinWidth = 23;
            this.colsupQuanSub.Name = "colsupQuanSub";
            this.colsupQuanSub.Width = 87;
            // 
            // colsupPrice
            // 
            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupPrice.Caption = "التكلفة";
            this.colsupPrice.DisplayFormat.FormatString = "#,#.##";
            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupPrice.FieldName = "supPrice";
            this.colsupPrice.MinWidth = 23;
            this.colsupPrice.Name = "colsupPrice";
            this.colsupPrice.Visible = true;
            this.colsupPrice.VisibleIndex = 4;
            this.colsupPrice.Width = 87;
            // 
            // supSalePrice
            // 
            this.supSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.supSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.supSalePrice.Caption = "سعر البيع";
            this.supSalePrice.DisplayFormat.FormatString = "#,#.##";
            this.supSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.supSalePrice.FieldName = "supSalePrice";
            this.supSalePrice.MinWidth = 23;
            this.supSalePrice.Name = "supSalePrice";
            this.supSalePrice.OptionsColumn.ShowInCustomizationForm = false;
            this.supSalePrice.Width = 87;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "البيان";
            this.gridColumn1.FieldName = "supDesc";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 87;
            // 
            // colsupDebit
            // 
            this.colsupDebit.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDebit.Caption = "الإجمالي";
            this.colsupDebit.DisplayFormat.FormatString = "#,#.##";
            this.colsupDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupDebit.FieldName = "supCredit";
            this.colsupDebit.MinWidth = 23;
            this.colsupDebit.Name = "colsupDebit";
            this.colsupDebit.Visible = true;
            this.colsupDebit.VisibleIndex = 6;
            this.colsupDebit.Width = 87;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblSupplyMainBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(930, 313);
            this.gridControl1.TabIndex = 6;
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
            this.colsupAccName,
            this.colsupIsCash});
            this.gridView1.DetailHeight = 377;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colsupId
            // 
            this.colsupId.FieldName = "id";
            this.colsupId.MinWidth = 23;
            this.colsupId.Name = "colsupId";
            this.colsupId.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupId.Width = 87;
            // 
            // colsupStatus
            // 
            this.colsupStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colsupStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupStatus.Caption = "نوع السند";
            this.colsupStatus.FieldName = "supStatus";
            this.colsupStatus.MinWidth = 23;
            this.colsupStatus.Name = "colsupStatus";
            this.colsupStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "supStatus", "العدد : {0}")});
            this.colsupStatus.Visible = true;
            this.colsupStatus.VisibleIndex = 0;
            this.colsupStatus.Width = 93;
            // 
            // colsupNo
            // 
            this.colsupNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsupNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupNo.Caption = "رقم الفاتورة";
            this.colsupNo.FieldName = "supNo";
            this.colsupNo.MinWidth = 23;
            this.colsupNo.Name = "colsupNo";
            this.colsupNo.Visible = true;
            this.colsupNo.VisibleIndex = 1;
            this.colsupNo.Width = 93;
            // 
            // colsupRefNo
            // 
            this.colsupRefNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsupRefNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupRefNo.Caption = "رقم المرجع";
            this.colsupRefNo.FieldName = "supRefNo";
            this.colsupRefNo.MinWidth = 23;
            this.colsupRefNo.Name = "colsupRefNo";
            this.colsupRefNo.Width = 87;
            // 
            // colsupDesc
            // 
            this.colsupDesc.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDesc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.FieldName = "supDesc";
            this.colsupDesc.MinWidth = 23;
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Visible = true;
            this.colsupDesc.VisibleIndex = 2;
            this.colsupDesc.Width = 93;
            // 
            // colsupTaxPercent
            // 
            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPercent.Caption = "نسبة الضريبة";
            this.colsupTaxPercent.FieldName = "supTaxPercent";
            this.colsupTaxPercent.MinWidth = 23;
            this.colsupTaxPercent.Name = "colsupTaxPercent";
            this.colsupTaxPercent.Visible = true;
            this.colsupTaxPercent.VisibleIndex = 3;
            this.colsupTaxPercent.Width = 93;
            // 
            // colsupTaxPrice
            // 
            this.colsupTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPrice.Caption = "الضريبة";
            this.colsupTaxPrice.DisplayFormat.FormatString = "#,#.##";
            this.colsupTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTaxPrice.FieldName = "supTaxPrice";
            this.colsupTaxPrice.MinWidth = 23;
            this.colsupTaxPrice.Name = "colsupTaxPrice";
            this.colsupTaxPrice.Visible = true;
            this.colsupTaxPrice.VisibleIndex = 4;
            this.colsupTaxPrice.Width = 93;
            // 
            // colsupTotal
            // 
            this.colsupTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTotal.Caption = "الإجمالي";
            this.colsupTotal.DisplayFormat.FormatString = "#,#.##";
            this.colsupTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTotal.FieldName = "supTotal";
            this.colsupTotal.MinWidth = 23;
            this.colsupTotal.Name = "colsupTotal";
            this.colsupTotal.Visible = true;
            this.colsupTotal.VisibleIndex = 5;
            this.colsupTotal.Width = 93;
            // 
            // colsupTotalFrgn
            // 
            this.colsupTotalFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTotalFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTotalFrgn.Caption = "إجمالي بلعملة الأجنبية";
            this.colsupTotalFrgn.DisplayFormat.FormatString = "#,#.##";
            this.colsupTotalFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTotalFrgn.FieldName = "supTotalFrgn";
            this.colsupTotalFrgn.MinWidth = 152;
            this.colsupTotalFrgn.Name = "colsupTotalFrgn";
            this.colsupTotalFrgn.Visible = true;
            this.colsupTotalFrgn.VisibleIndex = 6;
            this.colsupTotalFrgn.Width = 161;
            // 
            // colsupCurrency
            // 
            this.colsupCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colsupCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupCurrency.Caption = "العملة";
            this.colsupCurrency.FieldName = "supCurrency";
            this.colsupCurrency.MaxWidth = 82;
            this.colsupCurrency.MinWidth = 23;
            this.colsupCurrency.Name = "colsupCurrency";
            this.colsupCurrency.Visible = true;
            this.colsupCurrency.VisibleIndex = 7;
            this.colsupCurrency.Width = 80;
            // 
            // colsupDate
            // 
            this.colsupDate.Caption = "التاريخ";
            this.colsupDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colsupDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colsupDate.FieldName = "supDate";
            this.colsupDate.MinWidth = 23;
            this.colsupDate.Name = "colsupDate";
            this.colsupDate.Visible = true;
            this.colsupDate.VisibleIndex = 8;
            this.colsupDate.Width = 103;
            // 
            // colsupAccNo
            // 
            this.colsupAccNo.FieldName = "supAccNo";
            this.colsupAccNo.MinWidth = 23;
            this.colsupAccNo.Name = "colsupAccNo";
            this.colsupAccNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupAccNo.Width = 87;
            // 
            // colsupAccName
            // 
            this.colsupAccName.FieldName = "supAccName";
            this.colsupAccName.MinWidth = 23;
            this.colsupAccName.Name = "colsupAccName";
            this.colsupAccName.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupAccName.Width = 87;
            // 
            // colsupIsCash
            // 
            this.colsupIsCash.Caption = "supIsCash";
            this.colsupIsCash.FieldName = "supIsCash";
            this.colsupIsCash.MinWidth = 23;
            this.colsupIsCash.Name = "colsupIsCash";
            this.colsupIsCash.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupIsCash.Width = 87;
            // 
            // ribbonControl1
            // 
            //this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.bbiClose,
            this.bbiClose1,
            this.bbiClose2,
            this.bbiPrint2,
            this.bbiReportInvoiceType,
            this.bbiCLose3,
            this.bbiPrint3,
            this.bbiAutoAccNo});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageMain,
            this.ribbonPageBalance,
            this.ribbonPageInvoices,
            this.ribbonPageEntries});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRadioGroup1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(930, 166);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "حفظ";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiClose1
            // 
            this.bbiClose1.Caption = "إغلاق";
            this.bbiClose1.Id = 3;
            this.bbiClose1.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiClose1.Name = "bbiClose1";
            // 
            // bbiClose2
            // 
            this.bbiClose2.Caption = "إغلاق";
            this.bbiClose2.Id = 4;
            this.bbiClose2.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiClose2.Name = "bbiClose2";
            // 
            // bbiPrint2
            // 
            this.bbiPrint2.Caption = "طباعة الفاتورة";
            this.bbiPrint2.Id = 5;
            this.bbiPrint2.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.printviapdf_32x32;
            this.bbiPrint2.Name = "bbiPrint2";
            // 
            // bbiReportInvoiceType
            // 
            this.bbiReportInvoiceType.Edit = this.repositoryItemRadioGroup1;
            this.bbiReportInvoiceType.EditHeight = 50;
            this.bbiReportInvoiceType.EditWidth = 60;
            this.bbiReportInvoiceType.Id = 6;
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
            // bbiCLose3
            // 
            this.bbiCLose3.Caption = "إغلاق";
            this.bbiCLose3.Id = 7;
            this.bbiCLose3.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiCLose3.Name = "bbiCLose3";
            // 
            // bbiPrint3
            // 
            this.bbiPrint3.Caption = "طباعة السند";
            this.bbiPrint3.Id = 8;
            this.bbiPrint3.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.printviapdf_32x32;
            this.bbiPrint3.Name = "bbiPrint3";
            // 
            // bbiAutoAccNo
            // 
            this.bbiAutoAccNo.Caption = "إضافة حساب تلقائي";
            this.bbiAutoAccNo.Id = 9;
            this.bbiAutoAccNo.ImageOptions.Image = global::AccountingMS.Properties.Resources.apply_16x16;
            this.bbiAutoAccNo.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.apply_32x321;
            this.bbiAutoAccNo.Name = "bbiAutoAccNo";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroupAutoAddAccNo
            // 
            this.ribbonPageGroupAutoAddAccNo.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupAutoAddAccNo.ItemLinks.Add(this.bbiAutoAccNo);
            this.ribbonPageGroupAutoAddAccNo.Name = "ribbonPageGroupAutoAddAccNo";
            this.ribbonPageGroupAutoAddAccNo.Text = "حساب المورد";
            this.ribbonPageGroupAutoAddAccNo.Visible = false;
            // 
            // ribbonPageBalance
            // 
            this.ribbonPageBalance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupBalance});
            this.ribbonPageBalance.Name = "ribbonPageBalance";
            this.ribbonPageBalance.Text = "رصيد المورد";
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
            this.ribbonPageGroup3,
            this.ribbonPageGroupInvoices});
            this.ribbonPageInvoices.Name = "ribbonPageInvoices";
            this.ribbonPageInvoices.Text = "الفواتير";
            this.ribbonPageInvoices.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiClose2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "العمليات";
            // 
            // ribbonPageGroupInvoices
            // 
            this.ribbonPageGroupInvoices.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupInvoices.ItemLinks.Add(this.bbiPrint2);
            this.ribbonPageGroupInvoices.ItemLinks.Add(this.bbiReportInvoiceType);
            this.ribbonPageGroupInvoices.Name = "ribbonPageGroupInvoices";
            this.ribbonPageGroupInvoices.Text = "الطباعة";
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
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // tblSupplierBindingSource
            // 
            this.tblSupplierBindingSource.DataSource = typeof(AccountingMS.tblSupplier);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidateHiddenControls = false;
            // 
            // splNoTextEdit
            // 
            this.splNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splNoTextEdit.Location = new System.Drawing.Point(20, 69);
            this.splNoTextEdit.MenuManager = this.ribbonControl1;
            this.splNoTextEdit.Name = "splNoTextEdit";
            this.splNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.splNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.splNoTextEdit.Properties.Mask.EditMask = "f0";
            this.splNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.splNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.splNoTextEdit.Size = new System.Drawing.Size(787, 20);
            this.splNoTextEdit.StyleController = this.dataLayoutControl1;
            this.splNoTextEdit.TabIndex = 1;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule4.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule4.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.splNoTextEdit, conditionValidationRule4);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Appearance.ControlDisabled.BackColor = System.Drawing.Color.White;
            this.dataLayoutControl1.Appearance.ControlDisabled.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseBackColor = true;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseForeColor = true;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.dataLayoutControl1.Controls.Add(this.splNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splPhnNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splAccNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splTaxNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splCityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splAddressTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splEmailTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splCountryTextEdit);
            this.dataLayoutControl1.Controls.Add(this.splCurrencyTextEdit);
            this.dataLayoutControl1.DataSource = this.tblSupplierBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(930, 313);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // splNameTextEdit
            // 
            this.splNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splNameTextEdit.Location = new System.Drawing.Point(465, 187);
            this.splNameTextEdit.MenuManager = this.ribbonControl1;
            this.splNameTextEdit.Name = "splNameTextEdit";
            this.splNameTextEdit.Properties.MaxLength = 50;
            this.splNameTextEdit.Size = new System.Drawing.Size(342, 20);
            this.splNameTextEdit.StyleController = this.dataLayoutControl1;
            this.splNameTextEdit.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.splNameTextEdit, conditionValidationRule1);
            // 
            // splPhnNoTextEdit
            // 
            this.splPhnNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splPhnNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splPhnNoTextEdit.Location = new System.Drawing.Point(20, 187);
            this.splPhnNoTextEdit.MenuManager = this.ribbonControl1;
            this.splPhnNoTextEdit.Name = "splPhnNoTextEdit";
            this.splPhnNoTextEdit.Properties.MaxLength = 15;
            this.splPhnNoTextEdit.Size = new System.Drawing.Size(338, 20);
            this.splPhnNoTextEdit.StyleController = this.dataLayoutControl1;
            this.splPhnNoTextEdit.TabIndex = 5;
            // 
            // splAccNoTextEdit
            // 
            this.splAccNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splAccNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splAccNoTextEdit.Location = new System.Drawing.Point(20, 45);
            this.splAccNoTextEdit.MenuManager = this.ribbonControl1;
            this.splAccNoTextEdit.Name = "splAccNoTextEdit";
            this.splAccNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.splAccNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.splAccNoTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.splAccNoTextEdit.Properties.NullText = "";
            this.splAccNoTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.splAccNoTextEdit.Size = new System.Drawing.Size(787, 20);
            this.splAccNoTextEdit.StyleController = this.dataLayoutControl1;
            this.splAccNoTextEdit.TabIndex = 0;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule2.Value1 = ((long)(0));
            this.dxValidationProvider1.SetValidationRule(this.splAccNoTextEdit, conditionValidationRule2);
            // 
            // splTaxNoTextEdit
            // 
            this.splTaxNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splTaxNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splTaxNoTextEdit.Location = new System.Drawing.Point(20, 117);
            this.splTaxNoTextEdit.MenuManager = this.ribbonControl1;
            this.splTaxNoTextEdit.Name = "splTaxNoTextEdit";
            this.splTaxNoTextEdit.Properties.MaxLength = 20;
            this.splTaxNoTextEdit.Size = new System.Drawing.Size(787, 20);
            this.splTaxNoTextEdit.StyleController = this.dataLayoutControl1;
            this.splTaxNoTextEdit.TabIndex = 3;
            // 
            // splCityTextEdit
            // 
            this.splCityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splCity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splCityTextEdit.Location = new System.Drawing.Point(20, 211);
            this.splCityTextEdit.MenuManager = this.ribbonControl1;
            this.splCityTextEdit.Name = "splCityTextEdit";
            this.splCityTextEdit.Size = new System.Drawing.Size(338, 20);
            this.splCityTextEdit.StyleController = this.dataLayoutControl1;
            this.splCityTextEdit.TabIndex = 7;
            // 
            // splAddressTextEdit
            // 
            this.splAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splAddressTextEdit.Location = new System.Drawing.Point(465, 235);
            this.splAddressTextEdit.MenuManager = this.ribbonControl1;
            this.splAddressTextEdit.Name = "splAddressTextEdit";
            this.splAddressTextEdit.Properties.MaxLength = 100;
            this.splAddressTextEdit.Size = new System.Drawing.Size(342, 20);
            this.splAddressTextEdit.StyleController = this.dataLayoutControl1;
            this.splAddressTextEdit.TabIndex = 8;
            // 
            // splEmailTextEdit
            // 
            this.splEmailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splEmail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splEmailTextEdit.Location = new System.Drawing.Point(20, 235);
            this.splEmailTextEdit.MenuManager = this.ribbonControl1;
            this.splEmailTextEdit.Name = "splEmailTextEdit";
            this.splEmailTextEdit.Properties.MaxLength = 40;
            this.splEmailTextEdit.Size = new System.Drawing.Size(338, 20);
            this.splEmailTextEdit.StyleController = this.dataLayoutControl1;
            this.splEmailTextEdit.TabIndex = 9;
            // 
            // splCountryTextEdit
            // 
            this.splCountryTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splCountry", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splCountryTextEdit.Location = new System.Drawing.Point(465, 211);
            this.splCountryTextEdit.MenuManager = this.ribbonControl1;
            this.splCountryTextEdit.Name = "splCountryTextEdit";
            this.splCountryTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.splCountryTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntArName", "Name1", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cntEnName", "Name2", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.splCountryTextEdit.Properties.DataSource = this.tblCountryBindingSource;
            this.splCountryTextEdit.Properties.DisplayMember = "cntArName";
            this.splCountryTextEdit.Properties.NullText = "";
            this.splCountryTextEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.splCountryTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.splCountryTextEdit.Properties.ShowHeader = false;
            this.splCountryTextEdit.Properties.ValueMember = "cntArName";
            this.splCountryTextEdit.Size = new System.Drawing.Size(342, 20);
            this.splCountryTextEdit.StyleController = this.dataLayoutControl1;
            this.splCountryTextEdit.TabIndex = 6;
            // 
            // tblCountryBindingSource
            // 
            this.tblCountryBindingSource.DataSource = typeof(AccountingMS.tblCountry);
            // 
            // splCurrencyTextEdit
            // 
            this.splCurrencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblSupplierBindingSource, "splCurrency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splCurrencyTextEdit.Location = new System.Drawing.Point(20, 93);
            this.splCurrencyTextEdit.MenuManager = this.ribbonControl1;
            this.splCurrencyTextEdit.Name = "splCurrencyTextEdit";
            this.splCurrencyTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.splCurrencyTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.splCurrencyTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.splCurrencyTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.splCurrencyTextEdit.Properties.NullText = "";
            this.splCurrencyTextEdit.Size = new System.Drawing.Size(787, 20);
            this.splCurrencyTextEdit.StyleController = this.dataLayoutControl1;
            this.splCurrencyTextEdit.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule3.Value1 = ((byte)(0));
            this.dxValidationProvider1.SetValidationRule(this.splCurrencyTextEdit, conditionValidationRule3);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 2;
            this.layoutControlGroup1.Size = new System.Drawing.Size(930, 313);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(910, 293);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForsplNo,
            this.ItemForsplAccNo,
            this.ItemForsplTaxNo,
            this.ItemForsplCurrency});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 5, 11);
            this.layoutControlGroup3.Size = new System.Drawing.Size(910, 142);
            this.layoutControlGroup3.Text = "بيانات الحساب";
            // 
            // ItemForsplNo
            // 
            this.ItemForsplNo.Control = this.splNoTextEdit;
            this.ItemForsplNo.Location = new System.Drawing.Point(0, 24);
            this.ItemForsplNo.Name = "ItemForsplNo";
            this.ItemForsplNo.Size = new System.Drawing.Size(894, 24);
            this.ItemForsplNo.Text = "رقم المورد :";
            this.ItemForsplNo.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplAccNo
            // 
            this.ItemForsplAccNo.Control = this.splAccNoTextEdit;
            this.ItemForsplAccNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForsplAccNo.Name = "ItemForsplAccNo";
            this.ItemForsplAccNo.Size = new System.Drawing.Size(894, 24);
            this.ItemForsplAccNo.Text = "رقم حساب المورد :";
            this.ItemForsplAccNo.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplTaxNo
            // 
            this.ItemForsplTaxNo.Control = this.splTaxNoTextEdit;
            this.ItemForsplTaxNo.Location = new System.Drawing.Point(0, 72);
            this.ItemForsplTaxNo.Name = "ItemForsplTaxNo";
            this.ItemForsplTaxNo.Size = new System.Drawing.Size(894, 24);
            this.ItemForsplTaxNo.Text = "الرقم الضريبي :";
            this.ItemForsplTaxNo.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplCurrency
            // 
            this.ItemForsplCurrency.Control = this.splCurrencyTextEdit;
            this.ItemForsplCurrency.Location = new System.Drawing.Point(0, 48);
            this.ItemForsplCurrency.Name = "ItemForsplCurrency";
            this.ItemForsplCurrency.Size = new System.Drawing.Size(894, 24);
            this.ItemForsplCurrency.Text = "العملة :";
            this.ItemForsplCurrency.TextSize = new System.Drawing.Size(101, 17);
            this.ItemForsplCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup4.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup4.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForsplName,
            this.ItemForsplPhnNo,
            this.ItemForsplCountry,
            this.ItemForsplCity,
            this.ItemForsplAddress,
            this.ItemForsplEmail});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 142);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 5, 11);
            this.layoutControlGroup4.Size = new System.Drawing.Size(910, 151);
            this.layoutControlGroup4.Text = "بيانات المورد";
            // 
            // ItemForsplName
            // 
            this.ItemForsplName.Control = this.splNameTextEdit;
            this.ItemForsplName.Location = new System.Drawing.Point(445, 0);
            this.ItemForsplName.Name = "ItemForsplName";
            this.ItemForsplName.Size = new System.Drawing.Size(449, 24);
            this.ItemForsplName.Text = "إسم المورد :";
            this.ItemForsplName.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplPhnNo
            // 
            this.ItemForsplPhnNo.Control = this.splPhnNoTextEdit;
            this.ItemForsplPhnNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForsplPhnNo.Name = "ItemForsplPhnNo";
            this.ItemForsplPhnNo.Size = new System.Drawing.Size(445, 24);
            this.ItemForsplPhnNo.Text = "رقم الهاتف :";
            this.ItemForsplPhnNo.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplCountry
            // 
            this.ItemForsplCountry.Control = this.splCountryTextEdit;
            this.ItemForsplCountry.Location = new System.Drawing.Point(445, 24);
            this.ItemForsplCountry.Name = "ItemForsplCountry";
            this.ItemForsplCountry.Size = new System.Drawing.Size(449, 24);
            this.ItemForsplCountry.Text = "الدولة :";
            this.ItemForsplCountry.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplCity
            // 
            this.ItemForsplCity.Control = this.splCityTextEdit;
            this.ItemForsplCity.Location = new System.Drawing.Point(0, 24);
            this.ItemForsplCity.Name = "ItemForsplCity";
            this.ItemForsplCity.Size = new System.Drawing.Size(445, 24);
            this.ItemForsplCity.Text = "المدينة :";
            this.ItemForsplCity.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplAddress
            // 
            this.ItemForsplAddress.Control = this.splAddressTextEdit;
            this.ItemForsplAddress.Location = new System.Drawing.Point(445, 48);
            this.ItemForsplAddress.Name = "ItemForsplAddress";
            this.ItemForsplAddress.Size = new System.Drawing.Size(449, 57);
            this.ItemForsplAddress.Text = "العنوان :";
            this.ItemForsplAddress.TextSize = new System.Drawing.Size(101, 17);
            // 
            // ItemForsplEmail
            // 
            this.ItemForsplEmail.Control = this.splEmailTextEdit;
            this.ItemForsplEmail.Location = new System.Drawing.Point(0, 48);
            this.ItemForsplEmail.Name = "ItemForsplEmail";
            this.ItemForsplEmail.Size = new System.Drawing.Size(445, 57);
            this.ItemForsplEmail.Text = "البريد الإلكتروني :";
            this.ItemForsplEmail.TextSize = new System.Drawing.Size(101, 17);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPageMain);
            this.navigationFrame1.Controls.Add(this.navigationPageBalance);
            this.navigationFrame1.Controls.Add(this.navigationPageInvoices);
            this.navigationFrame1.Controls.Add(this.navigationPageEntries);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 166);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageMain,
            this.navigationPageBalance,
            this.navigationPageInvoices,
            this.navigationPageEntries});
            this.navigationFrame1.SelectedPage = this.navigationPageMain;
            this.navigationFrame1.Size = new System.Drawing.Size(930, 313);
            this.navigationFrame1.TabIndex = 3;
            this.navigationFrame1.Text = "navigationFrame1";
            this.navigationFrame1.TransitionAnimationProperties.FrameInterval = 7000;
            // 
            // navigationPageMain
            // 
            this.navigationPageMain.Controls.Add(this.dataLayoutControl1);
            this.navigationPageMain.Name = "navigationPageMain";
            this.navigationPageMain.Size = new System.Drawing.Size(930, 313);
            // 
            // navigationPageBalance
            // 
            this.navigationPageBalance.Controls.Add(this.layoutControl2);
            this.navigationPageBalance.Name = "navigationPageBalance";
            this.navigationPageBalance.Size = new System.Drawing.Size(930, 313);
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
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 159, 650, 400);
            this.layoutControl2.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl2.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl2.Root = this.layoutControlGroup6;
            this.layoutControl2.Size = new System.Drawing.Size(930, 313);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControlPeriodBalance
            // 
            this.gridControlPeriodBalance.DataSource = this.clsBalanceColumnsDataBindingSource2;
            this.gridControlPeriodBalance.Location = new System.Drawing.Point(448, 100);
            this.gridControlPeriodBalance.MainView = this.gridViewPeriodBalance;
            this.gridControlPeriodBalance.MenuManager = this.ribbonControl1;
            this.gridControlPeriodBalance.Name = "gridControlPeriodBalance";
            this.gridControlPeriodBalance.Size = new System.Drawing.Size(478, 196);
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
            this.gridViewPeriodBalance.DetailHeight = 377;
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
            this.coldebit2.MinWidth = 23;
            this.coldebit2.Name = "coldebit2";
            this.coldebit2.Visible = true;
            this.coldebit2.VisibleIndex = 0;
            this.coldebit2.Width = 87;
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
            this.colcredit2.MinWidth = 23;
            this.colcredit2.Name = "colcredit2";
            this.colcredit2.Visible = true;
            this.colcredit2.VisibleIndex = 1;
            this.colcredit2.Width = 87;
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
            this.colcurrentBalance2.MinWidth = 105;
            this.colcurrentBalance2.Name = "colcurrentBalance2";
            this.colcurrentBalance2.Visible = true;
            this.colcurrentBalance2.VisibleIndex = 2;
            this.colcurrentBalance2.Width = 105;
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
            this.coldtStart.MinWidth = 23;
            this.coldtStart.Name = "coldtStart";
            this.coldtStart.Visible = true;
            this.coldtStart.VisibleIndex = 3;
            this.coldtStart.Width = 87;
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
            this.coldtEnd.MinWidth = 23;
            this.coldtEnd.Name = "coldtEnd";
            this.coldtEnd.Visible = true;
            this.coldtEnd.VisibleIndex = 4;
            this.coldtEnd.Width = 87;
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.clsBalanceColumnsDataBindingSource1;
            this.gridControl3.Location = new System.Drawing.Point(4, 37);
            this.gridControl3.MainView = this.gridViewCurrentBalance;
            this.gridControl3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.gridControl3.MenuManager = this.ribbonControl1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(429, 86);
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
            this.gridViewCurrentBalance.DetailHeight = 377;
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
            this.coldebit1.MinWidth = 23;
            this.coldebit1.Name = "coldebit1";
            this.coldebit1.Visible = true;
            this.coldebit1.VisibleIndex = 0;
            this.coldebit1.Width = 87;
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
            this.colcredit1.MinWidth = 23;
            this.colcredit1.Name = "colcredit1";
            this.colcredit1.Visible = true;
            this.colcredit1.VisibleIndex = 1;
            this.colcredit1.Width = 87;
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
            this.colcurrentBalance1.MinWidth = 23;
            this.colcurrentBalance1.Name = "colcurrentBalance1";
            this.colcurrentBalance1.Visible = true;
            this.colcurrentBalance1.VisibleIndex = 2;
            this.colcurrentBalance1.Width = 87;
            // 
            // textEditDtStart
            // 
            this.textEditDtStart.EditValue = null;
            this.textEditDtStart.Location = new System.Drawing.Point(563, 37);
            this.textEditDtStart.MenuManager = this.ribbonControl1;
            this.textEditDtStart.Name = "textEditDtStart";
            this.textEditDtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtStart.Properties.Mask.BeepOnError = true;
            this.textEditDtStart.Properties.Mask.EditMask = "(0?[1-9]|1[012])/([012]?[1-9]|[123]0|31)/([123][0-9])?[0-9][0-9]";
            this.textEditDtStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditDtStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEditDtStart.Size = new System.Drawing.Size(295, 20);
            this.textEditDtStart.StyleController = this.layoutControl2;
            this.textEditDtStart.TabIndex = 0;
            // 
            // textEditDtEnd
            // 
            this.textEditDtEnd.EditValue = null;
            this.textEditDtEnd.Location = new System.Drawing.Point(563, 61);
            this.textEditDtEnd.MenuManager = this.ribbonControl1;
            this.textEditDtEnd.Name = "textEditDtEnd";
            this.textEditDtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditDtEnd.Properties.Mask.BeepOnError = true;
            this.textEditDtEnd.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.textEditDtEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEditDtEnd.Size = new System.Drawing.Size(295, 20);
            this.textEditDtEnd.StyleController = this.layoutControl2;
            this.textEditDtEnd.TabIndex = 1;
            // 
            // btnCalculatePeriodBalance
            // 
            this.btnCalculatePeriodBalance.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculatePeriodBalance.Appearance.Options.UseFont = true;
            this.btnCalculatePeriodBalance.Location = new System.Drawing.Point(448, 37);
            this.btnCalculatePeriodBalance.Name = "btnCalculatePeriodBalance";
            this.btnCalculatePeriodBalance.Size = new System.Drawing.Size(111, 44);
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
            this.layoutControlGroup6.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup6.Size = new System.Drawing.Size(930, 313);
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
            this.layoutControlGroup8.Size = new System.Drawing.Size(926, 309);
            this.layoutControlGroup8.Text = "layoutControlGroup2";
            // 
            // layoutControlGroupPeriodBalance
            // 
            this.layoutControlGroupPeriodBalance.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupPeriodBalance.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroupPeriodBalance.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroupPeriodBalance.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupPeriodBalance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDtStart,
            this.layoutControlItem3,
            this.simpleSeparator1,
            this.lciDtEnd,
            this.layoutControlItem2});
            this.layoutControlGroupPeriodBalance.Location = new System.Drawing.Point(443, 0);
            this.layoutControlGroupPeriodBalance.Name = "layoutControlGroupPeriodBalance";
            this.layoutControlGroupPeriodBalance.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 11);
            this.layoutControlGroupPeriodBalance.Size = new System.Drawing.Size(483, 309);
            this.layoutControlGroupPeriodBalance.Text = "رصيد الفترة";
            // 
            // lciDtStart
            // 
            this.lciDtStart.Control = this.textEditDtStart;
            this.lciDtStart.Location = new System.Drawing.Point(114, 0);
            this.lciDtStart.Name = "lciDtStart";
            this.lciDtStart.Size = new System.Drawing.Size(365, 24);
            this.lciDtStart.Text = "من تاريخ :";
            this.lciDtStart.TextSize = new System.Drawing.Size(54, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControlPeriodBalance;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 63);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 0, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(479, 200);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 48);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 2, 2);
            this.simpleSeparator1.Size = new System.Drawing.Size(479, 15);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 5, 9);
            // 
            // lciDtEnd
            // 
            this.lciDtEnd.Control = this.textEditDtEnd;
            this.lciDtEnd.Location = new System.Drawing.Point(114, 24);
            this.lciDtEnd.Name = "lciDtEnd";
            this.lciDtEnd.Size = new System.Drawing.Size(365, 24);
            this.lciDtEnd.Text = "إلى تاريخ :";
            this.lciDtEnd.TextSize = new System.Drawing.Size(54, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCalculatePeriodBalance;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(36, 28);
            this.layoutControlItem2.Name = "layoutControlItem1";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(114, 48);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "بحث";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroupCurrentBalance
            // 
            this.layoutControlGroupCurrentBalance.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupCurrentBalance.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroupCurrentBalance.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroupCurrentBalance.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroupCurrentBalance.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupCurrentBalance.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroupCurrentBalance.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupCurrentBalance.Name = "layoutControlGroupCurrentBalance";
            this.layoutControlGroupCurrentBalance.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 11);
            this.layoutControlGroupCurrentBalance.Size = new System.Drawing.Size(433, 136);
            this.layoutControlGroupCurrentBalance.Text = "الرصيد الحالي";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl3;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem2";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(429, 90);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 136);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(433, 173);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHide = false;
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.IsCollapsible = DevExpress.Utils.DefaultBoolean.True;
            this.splitterItem1.Location = new System.Drawing.Point(433, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(10, 309);
            // 
            // navigationPageInvoices
            // 
            this.navigationPageInvoices.Controls.Add(this.gridControl1);
            this.navigationPageInvoices.Name = "navigationPageInvoices";
            this.navigationPageInvoices.Size = new System.Drawing.Size(930, 313);
            // 
            // navigationPageEntries
            // 
            this.navigationPageEntries.Controls.Add(this.gridControl2);
            this.navigationPageEntries.Name = "navigationPageEntries";
            this.navigationPageEntries.Size = new System.Drawing.Size(930, 313);
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.tblEntrySubBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.MenuManager = this.ribbonControl1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(930, 313);
            this.gridControl2.TabIndex = 1;
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
            this.gridView3.DetailHeight = 377;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsFind.AlwaysVisible = true;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView3.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colentAccNo
            // 
            this.colentAccNo.FieldName = "entAccNo";
            this.colentAccNo.MinWidth = 23;
            this.colentAccNo.Name = "colentAccNo";
            this.colentAccNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentAccNo.Width = 87;
            // 
            // colentAccName
            // 
            this.colentAccName.FieldName = "entAccName";
            this.colentAccName.MinWidth = 23;
            this.colentAccName.Name = "colentAccName";
            this.colentAccName.OptionsColumn.ShowInCustomizationForm = false;
            this.colentAccName.Width = 87;
            // 
            // colentBoxNo
            // 
            this.colentBoxNo.FieldName = "entBoxNo";
            this.colentBoxNo.MinWidth = 23;
            this.colentBoxNo.Name = "colentBoxNo";
            this.colentBoxNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentBoxNo.Width = 87;
            // 
            // colentStatus
            // 
            this.colentStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colentStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentStatus.Caption = "نوع السند";
            this.colentStatus.FieldName = "entStatus";
            this.colentStatus.MinWidth = 23;
            this.colentStatus.Name = "colentStatus";
            this.colentStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "entStatus", "العدد : {0}")});
            this.colentStatus.Visible = true;
            this.colentStatus.VisibleIndex = 0;
            this.colentStatus.Width = 78;
            // 
            // colentNo
            // 
            this.colentNo.AppearanceCell.Options.UseTextOptions = true;
            this.colentNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentNo.Caption = "رقم السند";
            this.colentNo.FieldName = "entNo";
            this.colentNo.MinWidth = 23;
            this.colentNo.Name = "colentNo";
            this.colentNo.Visible = true;
            this.colentNo.VisibleIndex = 1;
            this.colentNo.Width = 78;
            // 
            // colentDesc
            // 
            this.colentDesc.Caption = "البيان";
            this.colentDesc.FieldName = "entDesc";
            this.colentDesc.MinWidth = 23;
            this.colentDesc.Name = "colentDesc";
            this.colentDesc.Visible = true;
            this.colentDesc.VisibleIndex = 2;
            this.colentDesc.Width = 78;
            // 
            // colentDebit
            // 
            this.colentDebit.AppearanceCell.Options.UseTextOptions = true;
            this.colentDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentDebit.Caption = "مدين";
            this.colentDebit.DisplayFormat.FormatString = "#,#.##";
            this.colentDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentDebit.FieldName = "entDebit";
            this.colentDebit.MinWidth = 23;
            this.colentDebit.Name = "colentDebit";
            this.colentDebit.Visible = true;
            this.colentDebit.VisibleIndex = 3;
            this.colentDebit.Width = 78;
            // 
            // colentCredit
            // 
            this.colentCredit.AppearanceCell.Options.UseTextOptions = true;
            this.colentCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCredit.Caption = "دائن";
            this.colentCredit.DisplayFormat.FormatString = "#,#.##";
            this.colentCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentCredit.FieldName = "entCredit";
            this.colentCredit.MinWidth = 23;
            this.colentCredit.Name = "colentCredit";
            this.colentCredit.Visible = true;
            this.colentCredit.VisibleIndex = 4;
            this.colentCredit.Width = 78;
            // 
            // colentDebitFrgn
            // 
            this.colentDebitFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colentDebitFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentDebitFrgn.Caption = "مدين عملةأجنبيه";
            this.colentDebitFrgn.DisplayFormat.FormatString = "#,#.##";
            this.colentDebitFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentDebitFrgn.FieldName = "entDebitFrgn";
            this.colentDebitFrgn.MinWidth = 105;
            this.colentDebitFrgn.Name = "colentDebitFrgn";
            this.colentDebitFrgn.Visible = true;
            this.colentDebitFrgn.VisibleIndex = 5;
            this.colentDebitFrgn.Width = 105;
            // 
            // colentCreditFrgn
            // 
            this.colentCreditFrgn.AppearanceCell.Options.UseTextOptions = true;
            this.colentCreditFrgn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCreditFrgn.Caption = "دائن عملةأجنبيه";
            this.colentCreditFrgn.DisplayFormat.FormatString = "#,#.##";
            this.colentCreditFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentCreditFrgn.FieldName = "entCreditFrgn";
            this.colentCreditFrgn.MinWidth = 105;
            this.colentCreditFrgn.Name = "colentCreditFrgn";
            this.colentCreditFrgn.Visible = true;
            this.colentCreditFrgn.VisibleIndex = 6;
            this.colentCreditFrgn.Width = 105;
            // 
            // colentTaxPercent
            // 
            this.colentTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colentTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentTaxPercent.Caption = "نسبة الضريبة";
            this.colentTaxPercent.FieldName = "entTaxPercent";
            this.colentTaxPercent.MinWidth = 23;
            this.colentTaxPercent.Name = "colentTaxPercent";
            this.colentTaxPercent.Visible = true;
            this.colentTaxPercent.VisibleIndex = 7;
            this.colentTaxPercent.Width = 78;
            // 
            // colentTaxPrice
            // 
            this.colentTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colentTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentTaxPrice.Caption = "الصريبة";
            this.colentTaxPrice.DisplayFormat.FormatString = "#,#.##";
            this.colentTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentTaxPrice.FieldName = "entTaxPrice";
            this.colentTaxPrice.MinWidth = 23;
            this.colentTaxPrice.Name = "colentTaxPrice";
            this.colentTaxPrice.Visible = true;
            this.colentTaxPrice.VisibleIndex = 8;
            this.colentTaxPrice.Width = 78;
            // 
            // colentCurrency
            // 
            this.colentCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colentCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCurrency.Caption = "العمله";
            this.colentCurrency.FieldName = "entCurrency";
            this.colentCurrency.MaxWidth = 82;
            this.colentCurrency.MinWidth = 23;
            this.colentCurrency.Name = "colentCurrency";
            this.colentCurrency.Visible = true;
            this.colentCurrency.VisibleIndex = 9;
            this.colentCurrency.Width = 80;
            // 
            // colentCurChange
            // 
            this.colentCurChange.AppearanceCell.Options.UseTextOptions = true;
            this.colentCurChange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCurChange.Caption = "سعر الصرف";
            this.colentCurChange.FieldName = "entCurChange";
            this.colentCurChange.MinWidth = 23;
            this.colentCurChange.Name = "colentCurChange";
            this.colentCurChange.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCurChange.Width = 87;
            // 
            // colentCusNo
            // 
            this.colentCusNo.FieldName = "entCusNo";
            this.colentCusNo.MinWidth = 23;
            this.colentCusNo.Name = "colentCusNo";
            this.colentCusNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCusNo.Width = 87;
            // 
            // colentCusName
            // 
            this.colentCusName.FieldName = "entCusName";
            this.colentCusName.MinWidth = 23;
            this.colentCusName.Name = "colentCusName";
            this.colentCusName.OptionsColumn.ShowInCustomizationForm = false;
            this.colentCusName.Width = 87;
            // 
            // colentDate
            // 
            this.colentDate.Caption = "التاريخ";
            this.colentDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colentDate.FieldName = "entDate";
            this.colentDate.MinWidth = 23;
            this.colentDate.Name = "colentDate";
            this.colentDate.Visible = true;
            this.colentDate.VisibleIndex = 10;
            this.colentDate.Width = 66;
            // 
            // formAddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 479);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "formAddSupplier";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مورد";
            this.Load += new System.EventHandler(this.formAddSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splPhnNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splAccNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splTaxNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splEmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCountryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCountryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splCurrencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplAccNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplTaxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplPhnNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForsplEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPageMain.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCurrentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.navigationPageInvoices.ResumeLayout(false);
            this.navigationPageEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntrySubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.Windows.Forms.BindingSource tblSupplierBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageMain;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit splNoTextEdit;
        private DevExpress.XtraEditors.TextEdit splNameTextEdit;
        private DevExpress.XtraEditors.TextEdit splPhnNoTextEdit;
        private DevExpress.XtraEditors.LookUpEdit splAccNoTextEdit;
        private DevExpress.XtraEditors.TextEdit splTaxNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplAccNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplPhnNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplTaxNo;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageBalance;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageInvoices;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageEntries;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageBalance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupBalance;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageInvoices;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageEntries;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEntries;
        private DevExpress.XtraBars.BarButtonItem bbiClose1;
        private DevExpress.XtraBars.BarButtonItem bbiClose2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupInvoices;
        private DevExpress.XtraBars.BarButtonItem bbiPrint2;
        private DevExpress.XtraBars.BarEditItem bbiReportInvoiceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiCLose3;
        private DevExpress.XtraBars.BarButtonItem bbiPrint3;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridControlPeriodBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPeriodBalance;
        private DevExpress.XtraGrid.Columns.GridColumn coldebit2;
        private DevExpress.XtraGrid.Columns.GridColumn colcredit2;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrentBalance2;
        private DevExpress.XtraGrid.Columns.GridColumn coldtStart;
        private DevExpress.XtraGrid.Columns.GridColumn coldtEnd;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCurrentBalance;
        private DevExpress.XtraGrid.Columns.GridColumn coldebit1;
        private DevExpress.XtraGrid.Columns.GridColumn colcredit1;
        private DevExpress.XtraGrid.Columns.GridColumn colcurrentBalance1;
        private DevExpress.XtraEditors.DateEdit textEditDtStart;
        private DevExpress.XtraEditors.DateEdit textEditDtEnd;
        private DevExpress.XtraEditors.SimpleButton btnCalculatePeriodBalance;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPeriodBalance;
        private DevExpress.XtraLayout.LayoutControlItem lciDtStart;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem lciDtEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupCurrentBalance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
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
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colentBoxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colentNo;
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
        private DevExpress.XtraGrid.Columns.GridColumn colentDate;
        private System.Windows.Forms.BindingSource tblEntrySubBindingSource;
        private System.Windows.Forms.BindingSource tblSupplyMainBindingSource;
        private System.Windows.Forms.BindingSource clsBalanceColumnsDataBindingSource1;
        private System.Windows.Forms.BindingSource clsBalanceColumnsDataBindingSource2;
        private DevExpress.XtraEditors.TextEdit splCityTextEdit;
        private DevExpress.XtraEditors.TextEdit splAddressTextEdit;
        private DevExpress.XtraEditors.TextEdit splEmailTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplCountry;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplEmail;
        private DevExpress.XtraEditors.LookUpEdit splCountryTextEdit;
        private System.Windows.Forms.BindingSource tblCountryBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem ItemForsplCurrency;
        private DevExpress.XtraEditors.LookUpEdit splCurrencyTextEdit;
        private DevExpress.XtraBars.BarCheckItem bbiAutoAccNo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAutoAddAccNo;
    }
}