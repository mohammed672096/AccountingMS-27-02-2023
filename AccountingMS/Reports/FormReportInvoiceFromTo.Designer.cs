namespace AccountingMS.Report
{
    partial class FormReportInvoiceFromTo
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportInvoiceFromTo));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupPrdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDscntPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInvoice = new DevExpress.XtraGrid.GridControl();
            this.supplyMainBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFrgn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyChng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDscntAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAfterDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpaidCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDscntPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreash = new DevExpress.XtraEditors.SimpleButton();
            this.dtime_End = new DevExpress.XtraEditors.DateEdit();
            this.dtime_Start = new DevExpress.XtraEditors.DateEdit();
            this.CustLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.customerBindingSource = new System.Windows.Forms.BindingSource();
            this.CustLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SuppLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource();
            this.SuppLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.InvoType = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.PayMethod = new DevExpress.XtraEditors.RadioGroup();
            this.CurruncyLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource();
            this.CurruncyLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StoreLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.GroupStrBindingSource = new System.Windows.Forms.BindingSource();
            this.StoreLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.userTblBindingSource = new System.Windows.Forms.BindingSource();
            this.UserLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BoxLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.boxBindingSource = new System.Windows.Forms.BindingSource();
            this.BoxLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BankLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.bankBindingSource = new System.Windows.Forms.BindingSource();
            this.BankLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ReportType = new DevExpress.XtraEditors.RadioGroup();
            this.ReportModel = new DevExpress.XtraEditors.RadioGroup();
            this.BranchLookup = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tblBranchBindingSource = new System.Windows.Forms.BindingSource();
            this.BranchLookupView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAccName3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAccName5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).BeginInit();
            this.dataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_End.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_Start.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_Start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurruncyLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurruncyLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupStrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBranchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchLookupView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName5)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupPrdNo,
            this.colsupPrdName,
            this.gridColumn1,
            this.colsupPrice,
            this.colQuanMain,
            this.colsupSalePrice,
            this.colsupTaxPercent,
            this.gridColumn2,
            this.colsupDesc,
            this.colTotalPrice,
            this.colsupDscntPercent,
            this.gridColumn3,
            this.gridColumn4,
            this.colsupNo,
            this.gridColumn6});
            this.gridView1.GridControl = this.gcInvoice;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 39;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ViewCaption = "تفاصيل الفاتورة";
            // 
            // colsupPrdNo
            // 
            this.colsupPrdNo.Caption = "كود الصنف";
            this.colsupPrdNo.CustomizationCaption = "كود الصنف";
            this.colsupPrdNo.FieldName = "supPrdId";
            this.colsupPrdNo.MinWidth = 23;
            this.colsupPrdNo.Name = "colsupPrdNo";
            this.colsupPrdNo.OptionsColumn.AllowEdit = false;
            this.colsupPrdNo.Visible = true;
            this.colsupPrdNo.VisibleIndex = 0;
            this.colsupPrdNo.Width = 125;
            // 
            // colsupPrdName
            // 
            this.colsupPrdName.Caption = "إسم الصنف";
            this.colsupPrdName.CustomizationCaption = "إسم الصنف";
            this.colsupPrdName.FieldName = "supPrdId";
            this.colsupPrdName.MinWidth = 23;
            this.colsupPrdName.Name = "colsupPrdName";
            this.colsupPrdName.OptionsColumn.AllowEdit = false;
            this.colsupPrdName.OptionsColumn.ReadOnly = true;
            this.colsupPrdName.OptionsColumn.TabStop = false;
            this.colsupPrdName.Visible = true;
            this.colsupPrdName.VisibleIndex = 1;
            this.colsupPrdName.Width = 113;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "العملة";
            this.gridColumn1.CustomizationCaption = "العملة";
            this.gridColumn1.FieldName = "supCurrency";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn1.OptionsColumn.TabStop = false;
            this.gridColumn1.Width = 82;
            // 
            // colsupPrice
            // 
            this.colsupPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupPrice.Caption = "سعر الشراء";
            this.colsupPrice.CustomizationCaption = "سعر الشراء";
            this.colsupPrice.DisplayFormat.FormatString = "n";
            this.colsupPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupPrice.FieldName = "supPrice";
            this.colsupPrice.MinWidth = 23;
            this.colsupPrice.Name = "colsupPrice";
            this.colsupPrice.OptionsColumn.ReadOnly = true;
            this.colsupPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "supPrice", "{0:n}")});
            this.colsupPrice.Visible = true;
            this.colsupPrice.VisibleIndex = 4;
            this.colsupPrice.Width = 104;
            // 
            // colQuanMain
            // 
            this.colQuanMain.AppearanceCell.Options.UseTextOptions = true;
            this.colQuanMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colQuanMain.Caption = "الكمية";
            this.colQuanMain.CustomizationCaption = "الكمية";
            this.colQuanMain.DisplayFormat.FormatString = "n";
            this.colQuanMain.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuanMain.FieldName = "supQuanMain";
            this.colQuanMain.MinWidth = 23;
            this.colQuanMain.Name = "colQuanMain";
            this.colQuanMain.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "supQuanMain", "{0:n}")});
            this.colQuanMain.Visible = true;
            this.colQuanMain.VisibleIndex = 3;
            this.colQuanMain.Width = 83;
            // 
            // colsupSalePrice
            // 
            this.colsupSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupSalePrice.Caption = "سعر البيع";
            this.colsupSalePrice.CustomizationCaption = "سعر البيع";
            this.colsupSalePrice.DisplayFormat.FormatString = "n";
            this.colsupSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupSalePrice.FieldName = "supSalePrice";
            this.colsupSalePrice.MinWidth = 23;
            this.colsupSalePrice.Name = "colsupSalePrice";
            this.colsupSalePrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "supSalePrice", "{0:n}")});
            this.colsupSalePrice.Visible = true;
            this.colsupSalePrice.VisibleIndex = 5;
            this.colsupSalePrice.Width = 109;
            // 
            // colsupTaxPercent
            // 
            this.colsupTaxPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPercent.Caption = "نسبة الضريبة";
            this.colsupTaxPercent.CustomizationCaption = "نسبة الضريبة";
            this.colsupTaxPercent.FieldName = "supTaxPercent";
            this.colsupTaxPercent.MinWidth = 23;
            this.colsupTaxPercent.Name = "colsupTaxPercent";
            this.colsupTaxPercent.OptionsColumn.AllowEdit = false;
            this.colsupTaxPercent.OptionsColumn.AllowFocus = false;
            this.colsupTaxPercent.OptionsColumn.TabStop = false;
            this.colsupTaxPercent.Visible = true;
            this.colsupTaxPercent.VisibleIndex = 6;
            this.colsupTaxPercent.Width = 130;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.Caption = "الضريبة";
            this.gridColumn2.CustomizationCaption = "الضريبة";
            this.gridColumn2.DisplayFormat.FormatString = "n2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "supTaxPrice";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.TabStop = false;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "supTaxPrice", "{0:n2}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 99;
            // 
            // colsupDesc
            // 
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.CustomizationCaption = "البيان";
            this.colsupDesc.FieldName = "supDesc";
            this.colsupDesc.MinWidth = 23;
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Width = 186;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalPrice.Caption = "الإجمالي";
            this.colTotalPrice.CustomizationCaption = "الإجمالي";
            this.colTotalPrice.DisplayFormat.FormatString = "n2";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.MinWidth = 23;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.TabStop = false;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "SUM={0:n2}")});
            this.colTotalPrice.Width = 125;
            // 
            // colsupDscntPercent
            // 
            this.colsupDscntPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colsupDscntPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupDscntPercent.Caption = "نسبة الخصم";
            this.colsupDscntPercent.CustomizationCaption = "نسبة الخصم";
            this.colsupDscntPercent.DisplayFormat.FormatString = "n2";
            this.colsupDscntPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupDscntPercent.FieldName = "supDscntPercent";
            this.colsupDscntPercent.MinWidth = 23;
            this.colsupDscntPercent.Name = "colsupDscntPercent";
            this.colsupDscntPercent.Visible = true;
            this.colsupDscntPercent.VisibleIndex = 8;
            this.colsupDscntPercent.Width = 126;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.Caption = "الخصم";
            this.gridColumn3.CustomizationCaption = "الخصم";
            this.gridColumn3.DisplayFormat.FormatString = "n";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "supDscntAmount";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "supDscntAmount", "{0:n}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 87;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "id";
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn4.Width = 86;
            // 
            // colsupNo
            // 
            this.colsupNo.Caption = "رقم الفاتورة";
            this.colsupNo.CustomizationCaption = "رقم الفاتورة";
            this.colsupNo.FieldName = "supNo";
            this.colsupNo.MinWidth = 23;
            this.colsupNo.Name = "colsupNo";
            this.colsupNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colsupNo.Width = 86;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "وحدة القياس";
            this.gridColumn6.FieldName = "supMsur";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 95;
            // 
            // gcInvoice
            // 
            this.gcInvoice.DataSource = this.supplyMainBindingSource;
            this.gcInvoice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "Level1";
            this.gcInvoice.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcInvoice.Location = new System.Drawing.Point(8, 296);
            this.gcInvoice.MainView = this.gridView;
            this.gcInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcInvoice.Name = "gcInvoice";
            this.gcInvoice.Size = new System.Drawing.Size(1578, 495);
            this.gcInvoice.TabIndex = 12;
            this.gcInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // supplyMainBindingSource
            // 
            this.supplyMainBindingSource.DataSource = typeof(AccountingMS.tblSupplyMain);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Appearance.Row.Options.UseTextOptions = true;
            this.gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colID,
            this.colNo,
            this.colRefNo,
            this.colTotal,
            this.colDate,
            this.colUserId,
            this.colIsCash,
            this.colTotalFrgn,
            this.colTaxPrice,
            this.colCurrency,
            this.colCurrencyChng,
            this.colStrId,
            this.colDscntAmount,
            this.colNet,
            this.colTotalAfterDiscount,
            this.colBoxId,
            this.colBankId,
            this.colpaidCash,
            this.colBankAmount,
            this.colCustId,
            this.colTaxType,
            this.colTaxPercent,
            this.colNotes,
            this.colDscntPercent,
            this.colBranchID,
            this.colDueDate,
            this.colTotalPaid,
            this.colRemin,
            this.gridColumn5});
            this.gridView.GridControl = this.gcInvoice;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowViewCaption = true;
            this.gridView.ViewCaption = "قائمة الفواتير";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "نوع الفاتورة";
            this.colStatus.FieldName = "supStatus";
            this.colStatus.MinWidth = 30;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            this.colStatus.Width = 154;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "id";
            this.colID.MinWidth = 30;
            this.colID.Name = "colID";
            this.colID.Width = 117;
            // 
            // colNo
            // 
            this.colNo.Caption = "رقم الفاتورة";
            this.colNo.FieldName = "supNo";
            this.colNo.MinWidth = 30;
            this.colNo.Name = "colNo";
            this.colNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "supNo", "{0}")});
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 93;
            // 
            // colRefNo
            // 
            this.colRefNo.Caption = "رقم المرجع";
            this.colRefNo.FieldName = "supRefNo";
            this.colRefNo.MinWidth = 30;
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.Width = 121;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "المبلغ";
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "supTotal";
            this.colTotal.MinWidth = 30;
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 6;
            this.colTotal.Width = 97;
            // 
            // colDate
            // 
            this.colDate.Caption = "التاريخ";
            this.colDate.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "supDate";
            this.colDate.MinWidth = 23;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            this.colDate.Width = 125;
            // 
            // colUserId
            // 
            this.colUserId.Caption = "المستخدم";
            this.colUserId.FieldName = "supUserId";
            this.colUserId.MinWidth = 30;
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 10;
            this.colUserId.Width = 113;
            // 
            // colIsCash
            // 
            this.colIsCash.Caption = "supIsCash";
            this.colIsCash.FieldName = "supIsCash";
            this.colIsCash.MinWidth = 30;
            this.colIsCash.Name = "colIsCash";
            this.colIsCash.Width = 113;
            // 
            // colTotalFrgn
            // 
            this.colTotalFrgn.Caption = "المبلغ عملة أجنبية";
            this.colTotalFrgn.DisplayFormat.FormatString = "n2";
            this.colTotalFrgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFrgn.FieldName = "supTotalFrgn";
            this.colTotalFrgn.MinWidth = 30;
            this.colTotalFrgn.Name = "colTotalFrgn";
            this.colTotalFrgn.Width = 113;
            // 
            // colTaxPrice
            // 
            this.colTaxPrice.Caption = "الضريبة";
            this.colTaxPrice.DisplayFormat.FormatString = "n2";
            this.colTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPrice.FieldName = "supTaxPrice";
            this.colTaxPrice.MinWidth = 30;
            this.colTaxPrice.Name = "colTaxPrice";
            this.colTaxPrice.Visible = true;
            this.colTaxPrice.VisibleIndex = 8;
            this.colTaxPrice.Width = 95;
            // 
            // colCurrency
            // 
            this.colCurrency.Caption = "العملة";
            this.colCurrency.FieldName = "supCurrency";
            this.colCurrency.MinWidth = 30;
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.Width = 94;
            // 
            // colCurrencyChng
            // 
            this.colCurrencyChng.Caption = "CurrencyChng";
            this.colCurrencyChng.FieldName = "supCurrencyChng";
            this.colCurrencyChng.MinWidth = 30;
            this.colCurrencyChng.Name = "colCurrencyChng";
            this.colCurrencyChng.Width = 113;
            // 
            // colStrId
            // 
            this.colStrId.Caption = "المخزن";
            this.colStrId.FieldName = "supStrId";
            this.colStrId.MinWidth = 30;
            this.colStrId.Name = "colStrId";
            this.colStrId.Width = 113;
            // 
            // colDscntAmount
            // 
            this.colDscntAmount.Caption = "الخصم";
            this.colDscntAmount.DisplayFormat.FormatString = "n2";
            this.colDscntAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDscntAmount.FieldName = "supDscntAmount";
            this.colDscntAmount.MinWidth = 26;
            this.colDscntAmount.Name = "colDscntAmount";
            this.colDscntAmount.Visible = true;
            this.colDscntAmount.VisibleIndex = 7;
            this.colDscntAmount.Width = 77;
            // 
            // colNet
            // 
            this.colNet.Caption = "الإجمالي النهائي";
            this.colNet.DisplayFormat.FormatString = "n2";
            this.colNet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNet.FieldName = "net";
            this.colNet.MinWidth = 26;
            this.colNet.Name = "colNet";
            this.colNet.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colNet.Visible = true;
            this.colNet.VisibleIndex = 9;
            this.colNet.Width = 149;
            // 
            // colTotalAfterDiscount
            // 
            this.colTotalAfterDiscount.Caption = "الإجمالي بعد الخصم";
            this.colTotalAfterDiscount.DisplayFormat.FormatString = "n2";
            this.colTotalAfterDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAfterDiscount.MinWidth = 29;
            this.colTotalAfterDiscount.Name = "colTotalAfterDiscount";
            this.colTotalAfterDiscount.Width = 128;
            // 
            // colBoxId
            // 
            this.colBoxId.Caption = "الصندوق";
            this.colBoxId.FieldName = "supBoxId";
            this.colBoxId.MinWidth = 29;
            this.colBoxId.Name = "colBoxId";
            this.colBoxId.Width = 107;
            // 
            // colBankId
            // 
            this.colBankId.Caption = "البنك";
            this.colBankId.FieldName = "supBankId";
            this.colBankId.MinWidth = 23;
            this.colBankId.Name = "colBankId";
            this.colBankId.Visible = true;
            this.colBankId.VisibleIndex = 5;
            this.colBankId.Width = 107;
            // 
            // colpaidCash
            // 
            this.colpaidCash.Caption = "المدفوع نقدا";
            this.colpaidCash.DisplayFormat.FormatString = "n2";
            this.colpaidCash.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colpaidCash.FieldName = "paidCash";
            this.colpaidCash.MinWidth = 29;
            this.colpaidCash.Name = "colpaidCash";
            this.colpaidCash.Width = 107;
            // 
            // colBankAmount
            // 
            this.colBankAmount.Caption = "المدفوع بنك";
            this.colBankAmount.DisplayFormat.FormatString = "n2";
            this.colBankAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBankAmount.FieldName = "supBankAmount";
            this.colBankAmount.MinWidth = 29;
            this.colBankAmount.Name = "colBankAmount";
            this.colBankAmount.Width = 107;
            // 
            // colCustId
            // 
            this.colCustId.Caption = "العميل/المورد";
            this.colCustId.FieldName = "supCustSplId";
            this.colCustId.MinWidth = 29;
            this.colCustId.Name = "colCustId";
            this.colCustId.Visible = true;
            this.colCustId.VisibleIndex = 4;
            this.colCustId.Width = 129;
            // 
            // colTaxType
            // 
            this.colTaxType.Caption = "نوع الضريبة";
            this.colTaxType.MinWidth = 29;
            this.colTaxType.Name = "colTaxType";
            this.colTaxType.Width = 93;
            // 
            // colTaxPercent
            // 
            this.colTaxPercent.Caption = "نسبة الضريبة";
            this.colTaxPercent.DisplayFormat.FormatString = "p";
            this.colTaxPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPercent.FieldName = "supTaxPercent";
            this.colTaxPercent.MinWidth = 29;
            this.colTaxPercent.Name = "colTaxPercent";
            this.colTaxPercent.Width = 87;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "البيان";
            this.colNotes.FieldName = "supDesc";
            this.colNotes.MinWidth = 29;
            this.colNotes.Name = "colNotes";
            this.colNotes.Width = 133;
            // 
            // colDscntPercent
            // 
            this.colDscntPercent.Caption = "نسبة الخصم";
            this.colDscntPercent.DisplayFormat.FormatString = "n2";
            this.colDscntPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDscntPercent.FieldName = "supDscntPercent";
            this.colDscntPercent.MinWidth = 29;
            this.colDscntPercent.Name = "colDscntPercent";
            // 
            // colBranchID
            // 
            this.colBranchID.Caption = "الفرع";
            this.colBranchID.FieldName = "supBrnId";
            this.colBranchID.MinWidth = 29;
            this.colBranchID.Name = "colBranchID";
            this.colBranchID.Visible = true;
            this.colBranchID.VisibleIndex = 11;
            this.colBranchID.Width = 107;
            // 
            // colDueDate
            // 
            this.colDueDate.Caption = "تاريخ الاستحقاق";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.MinWidth = 29;
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.Width = 107;
            // 
            // colTotalPaid
            // 
            this.colTotalPaid.Caption = "اجمالي المدفوع";
            this.colTotalPaid.DisplayFormat.FormatString = "n2";
            this.colTotalPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPaid.MinWidth = 29;
            this.colTotalPaid.Name = "colTotalPaid";
            this.colTotalPaid.Width = 107;
            // 
            // colRemin
            // 
            this.colRemin.Caption = "المتبقي";
            this.colRemin.DisplayFormat.FormatString = "n2";
            this.colRemin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemin.FieldName = "remin";
            this.colRemin.MinWidth = 29;
            this.colRemin.Name = "colRemin";
            this.colRemin.Width = 107;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "اسم الحساب";
            this.gridColumn5.FieldName = "supAccName";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 125;
            // 
            // dataLayout
            // 
            this.dataLayout.AllowGeneratingNestedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.dataLayout.Controls.Add(this.labelControl1);
            this.dataLayout.Controls.Add(this.btnExportExcel);
            this.dataLayout.Controls.Add(this.btnClose);
            this.dataLayout.Controls.Add(this.btnPrint);
            this.dataLayout.Controls.Add(this.btnExportPDF);
            this.dataLayout.Controls.Add(this.btnRefreash);
            this.dataLayout.Controls.Add(this.dtime_End);
            this.dataLayout.Controls.Add(this.gcInvoice);
            this.dataLayout.Controls.Add(this.dtime_Start);
            this.dataLayout.Controls.Add(this.CustLookup);
            this.dataLayout.Controls.Add(this.SuppLookup);
            this.dataLayout.Controls.Add(this.InvoType);
            this.dataLayout.Controls.Add(this.PayMethod);
            this.dataLayout.Controls.Add(this.CurruncyLookup);
            this.dataLayout.Controls.Add(this.StoreLookup);
            this.dataLayout.Controls.Add(this.UserLookup);
            this.dataLayout.Controls.Add(this.BoxLookup);
            this.dataLayout.Controls.Add(this.BankLookup);
            this.dataLayout.Controls.Add(this.ReportType);
            this.dataLayout.Controls.Add(this.ReportModel);
            this.dataLayout.Controls.Add(this.BranchLookup);
            this.dataLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayout.Location = new System.Drawing.Point(0, 0);
            this.dataLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayout.Root = this.Root;
            this.dataLayout.Size = new System.Drawing.Size(1594, 806);
            this.dataLayout.TabIndex = 5;
            this.dataLayout.Text = "dataLayout";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.ImageOptions.Image")));
            this.labelControl1.Location = new System.Drawing.Point(8, 8);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1578, 36);
            this.labelControl1.StyleController = this.dataLayout;
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "خيارات البحث";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportExcel.ImageOptions.SvgImage")));
            this.btnExportExcel.Location = new System.Drawing.Point(686, 233);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(217, 44);
            this.btnExportExcel.StyleController = this.dataLayout;
            this.btnExportExcel.TabIndex = 20;
            this.btnExportExcel.Text = "حفظ الى Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.ExportExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(244, 233);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(217, 44);
            this.btnClose.StyleController = this.dataLayout;
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "خروج";
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(1129, 233);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(217, 44);
            this.btnPrint.StyleController = this.dataLayout;
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.Click += new System.EventHandler(this.Print_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportPDF.ImageOptions.SvgImage")));
            this.btnExportPDF.Location = new System.Drawing.Point(907, 233);
            this.btnExportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(218, 44);
            this.btnExportPDF.StyleController = this.dataLayout;
            this.btnExportPDF.TabIndex = 17;
            this.btnExportPDF.Text = "حفظ الى PDF";
            this.btnExportPDF.Click += new System.EventHandler(this.ExportPDF_Click);
            // 
            // btnRefreash
            // 
            this.btnRefreash.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefreash.ImageOptions.SvgImage")));
            this.btnRefreash.Location = new System.Drawing.Point(465, 233);
            this.btnRefreash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(217, 44);
            this.btnRefreash.StyleController = this.dataLayout;
            this.btnRefreash.TabIndex = 16;
            this.btnRefreash.Text = "تحديث";
            this.btnRefreash.Click += new System.EventHandler(this.Refreash_Click);
            // 
            // dtime_End
            // 
            this.dtime_End.EditValue = null;
            this.dtime_End.Location = new System.Drawing.Point(540, 96);
            this.dtime_End.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtime_End.Name = "dtime_End";
            this.dtime_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtime_End.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtime_End.Properties.MaskSettings.Set("mask", "G");
            this.dtime_End.Size = new System.Drawing.Size(373, 24);
            this.dtime_End.StyleController = this.dataLayout;
            this.dtime_End.TabIndex = 13;
            this.dtime_End.EditValueChanged += new System.EventHandler(this.Dtime_Start_EditValueChanged);
            // 
            // dtime_Start
            // 
            this.dtime_Start.EditValue = null;
            this.dtime_Start.Location = new System.Drawing.Point(1058, 96);
            this.dtime_Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtime_Start.Name = "dtime_Start";
            this.dtime_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtime_Start.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtime_Start.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm:ss");
            this.dtime_Start.Properties.MaskSettings.Set("mask", "G");
            this.dtime_Start.Size = new System.Drawing.Size(377, 24);
            this.dtime_Start.StyleController = this.dataLayout;
            this.dtime_Start.TabIndex = 13;
            this.dtime_Start.EditValueChanged += new System.EventHandler(this.Dtime_Start_EditValueChanged);
            // 
            // CustLookup
            // 
            this.CustLookup.Location = new System.Drawing.Point(1058, 124);
            this.CustLookup.Name = "CustLookup";
            this.CustLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.CustLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CustLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CustLookup.Properties.DataSource = this.customerBindingSource;
            this.CustLookup.Properties.DisplayMember = "custName";
            this.CustLookup.Properties.NullText = "";
            this.CustLookup.Properties.PopupView = this.CustLookupView;
            this.CustLookup.Properties.ValueMember = "id";
            this.CustLookup.Size = new System.Drawing.Size(377, 24);
            this.CustLookup.StyleController = this.dataLayout;
            this.CustLookup.TabIndex = 4;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(AccountingMS.tblCustomer);
            // 
            // CustLookupView
            // 
            this.CustLookupView.DetailHeight = 394;
            this.CustLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.CustLookupView.Name = "CustLookupView";
            this.CustLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.CustLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // SuppLookup
            // 
            this.SuppLookup.Location = new System.Drawing.Point(540, 124);
            this.SuppLookup.Name = "SuppLookup";
            this.SuppLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.SuppLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SuppLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SuppLookup.Properties.DataSource = this.supplierBindingSource;
            this.SuppLookup.Properties.DisplayMember = "splName";
            this.SuppLookup.Properties.NullText = "";
            this.SuppLookup.Properties.PopupView = this.SuppLookupView;
            this.SuppLookup.Properties.ValueMember = "id";
            this.SuppLookup.Size = new System.Drawing.Size(373, 24);
            this.SuppLookup.StyleController = this.dataLayout;
            this.SuppLookup.TabIndex = 4;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(AccountingMS.tblSupplier);
            // 
            // SuppLookupView
            // 
            this.SuppLookupView.DetailHeight = 394;
            this.SuppLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SuppLookupView.Name = "SuppLookupView";
            this.SuppLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SuppLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // InvoType
            // 
            this.InvoType.Location = new System.Drawing.Point(1058, 58);
            this.InvoType.MaximumSize = new System.Drawing.Size(0, 34);
            this.InvoType.Name = "InvoType";
            this.InvoType.Properties.AllowMultiSelect = true;
            this.InvoType.Properties.Appearance.Options.UseTextOptions = true;
            this.InvoType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.InvoType.Properties.AutoHeight = false;
            this.InvoType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.InvoType.Size = new System.Drawing.Size(377, 34);
            this.InvoType.StyleController = this.dataLayout;
            this.InvoType.TabIndex = 4;
            // 
            // PayMethod
            // 
            this.PayMethod.Location = new System.Drawing.Point(540, 58);
            this.PayMethod.MaximumSize = new System.Drawing.Size(0, 34);
            this.PayMethod.Name = "PayMethod";
            this.PayMethod.Properties.Appearance.Options.UseTextOptions = true;
            this.PayMethod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PayMethod.Properties.Columns = 3;
            this.PayMethod.Size = new System.Drawing.Size(373, 34);
            this.PayMethod.StyleController = this.dataLayout;
            this.PayMethod.TabIndex = 4;
            // 
            // CurruncyLookup
            // 
            this.CurruncyLookup.Location = new System.Drawing.Point(18, 96);
            this.CurruncyLookup.Name = "CurruncyLookup";
            this.CurruncyLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.CurruncyLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CurruncyLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CurruncyLookup.Properties.DataSource = this.currencyBindingSource;
            this.CurruncyLookup.Properties.DisplayMember = "Name";
            this.CurruncyLookup.Properties.NullText = "";
            this.CurruncyLookup.Properties.PopupView = this.CurruncyLookupView;
            this.CurruncyLookup.Properties.ValueMember = "ID";
            this.CurruncyLookup.Size = new System.Drawing.Size(377, 24);
            this.CurruncyLookup.StyleController = this.dataLayout;
            this.CurruncyLookup.TabIndex = 4;
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataSource = typeof(AccountingMS.tblCurrency);
            // 
            // CurruncyLookupView
            // 
            this.CurruncyLookupView.DetailHeight = 394;
            this.CurruncyLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.CurruncyLookupView.Name = "CurruncyLookupView";
            this.CurruncyLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.CurruncyLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // StoreLookup
            // 
            this.StoreLookup.Location = new System.Drawing.Point(18, 152);
            this.StoreLookup.Name = "StoreLookup";
            this.StoreLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.StoreLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.StoreLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StoreLookup.Properties.DataSource = this.GroupStrBindingSource;
            this.StoreLookup.Properties.DisplayMember = "grpName";
            this.StoreLookup.Properties.NullText = "";
            this.StoreLookup.Properties.PopupView = this.StoreLookupView;
            this.StoreLookup.Properties.ValueMember = "id";
            this.StoreLookup.Size = new System.Drawing.Size(377, 24);
            this.StoreLookup.StyleController = this.dataLayout;
            this.StoreLookup.TabIndex = 4;
            // 
            // GroupStrBindingSource
            // 
            this.GroupStrBindingSource.DataSource = typeof(AccountingMS.tblGroupStr);
            // 
            // StoreLookupView
            // 
            this.StoreLookupView.DetailHeight = 394;
            this.StoreLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.StoreLookupView.Name = "StoreLookupView";
            this.StoreLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.StoreLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // UserLookup
            // 
            this.UserLookup.Location = new System.Drawing.Point(18, 124);
            this.UserLookup.Name = "UserLookup";
            this.UserLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.UserLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.UserLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UserLookup.Properties.DataSource = this.userTblBindingSource;
            this.UserLookup.Properties.DisplayMember = "userName";
            this.UserLookup.Properties.NullText = "";
            this.UserLookup.Properties.PopupView = this.UserLookupView;
            this.UserLookup.Properties.ValueMember = "id";
            this.UserLookup.Size = new System.Drawing.Size(377, 24);
            this.UserLookup.StyleController = this.dataLayout;
            this.UserLookup.TabIndex = 4;
            // 
            // userTblBindingSource
            // 
            this.userTblBindingSource.DataSource = typeof(AccountingMS.tblUser);
            // 
            // UserLookupView
            // 
            this.UserLookupView.DetailHeight = 394;
            this.UserLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.UserLookupView.Name = "UserLookupView";
            this.UserLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.UserLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // BoxLookup
            // 
            this.BoxLookup.Location = new System.Drawing.Point(1058, 152);
            this.BoxLookup.Name = "BoxLookup";
            this.BoxLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.BoxLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BoxLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BoxLookup.Properties.DataSource = this.boxBindingSource;
            this.BoxLookup.Properties.DisplayMember = "boxName";
            this.BoxLookup.Properties.NullText = "";
            this.BoxLookup.Properties.PopupView = this.BoxLookupView;
            this.BoxLookup.Properties.ValueMember = "id";
            this.BoxLookup.Size = new System.Drawing.Size(377, 24);
            this.BoxLookup.StyleController = this.dataLayout;
            this.BoxLookup.TabIndex = 4;
            // 
            // boxBindingSource
            // 
            this.boxBindingSource.DataSource = typeof(AccountingMS.tblAccountBox);
            // 
            // BoxLookupView
            // 
            this.BoxLookupView.DetailHeight = 394;
            this.BoxLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.BoxLookupView.Name = "BoxLookupView";
            this.BoxLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.BoxLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // BankLookup
            // 
            this.BankLookup.Location = new System.Drawing.Point(540, 152);
            this.BankLookup.Name = "BankLookup";
            this.BankLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.BankLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BankLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BankLookup.Properties.DataSource = this.bankBindingSource;
            this.BankLookup.Properties.DisplayMember = "bankName";
            this.BankLookup.Properties.NullText = "";
            this.BankLookup.Properties.PopupView = this.BankLookupView;
            this.BankLookup.Properties.ValueMember = "id";
            this.BankLookup.Size = new System.Drawing.Size(373, 24);
            this.BankLookup.StyleController = this.dataLayout;
            this.BankLookup.TabIndex = 4;
            // 
            // bankBindingSource
            // 
            this.bankBindingSource.DataSource = typeof(AccountingMS.tblAccountBank);
            // 
            // BankLookupView
            // 
            this.BankLookupView.DetailHeight = 394;
            this.BankLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.BankLookupView.Name = "BankLookupView";
            this.BankLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.BankLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // ReportType
            // 
            this.ReportType.EditValue = ((byte)(1));
            this.ReportType.Location = new System.Drawing.Point(18, 58);
            this.ReportType.MaximumSize = new System.Drawing.Size(0, 34);
            this.ReportType.Name = "ReportType";
            this.ReportType.Properties.Appearance.Options.UseTextOptions = true;
            this.ReportType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ReportType.Properties.Columns = 2;
            this.ReportType.Size = new System.Drawing.Size(377, 34);
            this.ReportType.StyleController = this.dataLayout;
            this.ReportType.TabIndex = 4;
            // 
            // ReportModel
            // 
            this.ReportModel.EditValue = ((byte)(1));
            this.ReportModel.Location = new System.Drawing.Point(540, 180);
            this.ReportModel.Name = "ReportModel";
            this.ReportModel.Properties.Appearance.Options.UseTextOptions = true;
            this.ReportModel.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ReportModel.Properties.Columns = 4;
            this.ReportModel.Size = new System.Drawing.Size(895, 24);
            this.ReportModel.StyleController = this.dataLayout;
            this.ReportModel.TabIndex = 4;
            // 
            // BranchLookup
            // 
            this.BranchLookup.Location = new System.Drawing.Point(18, 180);
            this.BranchLookup.Name = "BranchLookup";
            this.BranchLookup.Properties.Appearance.Options.UseTextOptions = true;
            this.BranchLookup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BranchLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BranchLookup.Properties.DataSource = this.tblBranchBindingSource;
            this.BranchLookup.Properties.DisplayMember = "brnName";
            this.BranchLookup.Properties.NullText = "";
            this.BranchLookup.Properties.PopupView = this.BranchLookupView;
            this.BranchLookup.Properties.ValueMember = "brnId";
            this.BranchLookup.Size = new System.Drawing.Size(377, 24);
            this.BranchLookup.StyleController = this.dataLayout;
            this.BranchLookup.TabIndex = 4;
            // 
            // tblBranchBindingSource
            // 
            this.tblBranchBindingSource.DataSource = typeof(AccountingMS.tblBranch);
            // 
            // BranchLookupView
            // 
            this.BranchLookupView.DetailHeight = 394;
            this.BranchLookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.BranchLookupView.Name = "BranchLookupView";
            this.BranchLookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.BranchLookupView.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.Root.Size = new System.Drawing.Size(1594, 806);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem1,
            this.layoutControlGroup5,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1582, 794);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.labelControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1582, 40);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcInvoice;
            this.layoutControlItem1.CustomizationFormText = "قائمة الفواتير";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 288);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 9);
            this.layoutControlItem1.Size = new System.Drawing.Size(1582, 506);
            this.layoutControlItem1.Text = "تفاصيل كشف الحساب";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 210);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(1582, 78);
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup4.Size = new System.Drawing.Size(1558, 54);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1327, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(225, 48);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnPrint;
            this.layoutControlItem6.CustomizationFormText = "طباعة";
            this.layoutControlItem6.Location = new System.Drawing.Point(1106, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(221, 48);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnExportPDF;
            this.layoutControlItem5.CustomizationFormText = "حفظ الى PDF";
            this.layoutControlItem5.Location = new System.Drawing.Point(884, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(222, 48);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnExportExcel;
            this.layoutControlItem8.CustomizationFormText = "حفظ الى Excel";
            this.layoutControlItem8.Location = new System.Drawing.Point(663, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(221, 48);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRefreash;
            this.layoutControlItem4.CustomizationFormText = "تحديث";
            this.layoutControlItem4.Location = new System.Drawing.Point(442, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(221, 48);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnClose;
            this.layoutControlItem7.CustomizationFormText = "خروج";
            this.layoutControlItem7.Location = new System.Drawing.Point(221, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(221, 48);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(221, 48);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAccName3,
            this.ItemForAccName4,
            this.ItemForAccName1,
            this.ItemForAccName2,
            this.ItemForAccName9,
            this.ItemForAccName8,
            this.ItemForAccName10,
            this.ItemForAccName7,
            this.ItemForAccName11,
            this.ItemForAccName6,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.ItemForAccName12,
            this.ItemForAccName5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1582, 170);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // ItemForAccName3
            // 
            this.ItemForAccName3.Control = this.InvoType;
            this.ItemForAccName3.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName3.Location = new System.Drawing.Point(1040, 0);
            this.ItemForAccName3.Name = "ItemForAccName3";
            this.ItemForAccName3.Size = new System.Drawing.Size(522, 38);
            this.ItemForAccName3.Text = "نوع الفاتورة:";
            this.ItemForAccName3.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName4
            // 
            this.ItemForAccName4.Control = this.PayMethod;
            this.ItemForAccName4.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName4.Location = new System.Drawing.Point(522, 0);
            this.ItemForAccName4.Name = "ItemForAccName4";
            this.ItemForAccName4.Size = new System.Drawing.Size(518, 38);
            this.ItemForAccName4.Text = "طريقة الدفع:";
            this.ItemForAccName4.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName1
            // 
            this.ItemForAccName1.Control = this.CustLookup;
            this.ItemForAccName1.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName1.Location = new System.Drawing.Point(1040, 66);
            this.ItemForAccName1.Name = "ItemForAccName1";
            this.ItemForAccName1.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName1.Text = "العملاء:";
            this.ItemForAccName1.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName2
            // 
            this.ItemForAccName2.Control = this.SuppLookup;
            this.ItemForAccName2.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName2.Location = new System.Drawing.Point(522, 66);
            this.ItemForAccName2.Name = "ItemForAccName2";
            this.ItemForAccName2.Size = new System.Drawing.Size(518, 28);
            this.ItemForAccName2.Text = "الموردين:";
            this.ItemForAccName2.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName9
            // 
            this.ItemForAccName9.Control = this.BoxLookup;
            this.ItemForAccName9.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName9.Location = new System.Drawing.Point(1040, 94);
            this.ItemForAccName9.Name = "ItemForAccName9";
            this.ItemForAccName9.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName9.Text = "الصناديق:";
            this.ItemForAccName9.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName8
            // 
            this.ItemForAccName8.Control = this.UserLookup;
            this.ItemForAccName8.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName8.Location = new System.Drawing.Point(0, 66);
            this.ItemForAccName8.Name = "ItemForAccName8";
            this.ItemForAccName8.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName8.Text = "المستخدمين:";
            this.ItemForAccName8.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName10
            // 
            this.ItemForAccName10.Control = this.BankLookup;
            this.ItemForAccName10.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName10.Location = new System.Drawing.Point(522, 94);
            this.ItemForAccName10.Name = "ItemForAccName10";
            this.ItemForAccName10.Size = new System.Drawing.Size(518, 28);
            this.ItemForAccName10.Text = "البنوك:";
            this.ItemForAccName10.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName7
            // 
            this.ItemForAccName7.Control = this.StoreLookup;
            this.ItemForAccName7.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName7.Location = new System.Drawing.Point(0, 94);
            this.ItemForAccName7.Name = "ItemForAccName7";
            this.ItemForAccName7.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName7.Text = "المجموعات المخزنية:";
            this.ItemForAccName7.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName11
            // 
            this.ItemForAccName11.Control = this.ReportType;
            this.ItemForAccName11.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName11.Location = new System.Drawing.Point(0, 0);
            this.ItemForAccName11.Name = "ItemForAccName11";
            this.ItemForAccName11.Size = new System.Drawing.Size(522, 38);
            this.ItemForAccName11.Text = "نوع التقرير:";
            this.ItemForAccName11.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName6
            // 
            this.ItemForAccName6.Control = this.CurruncyLookup;
            this.ItemForAccName6.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName6.Location = new System.Drawing.Point(0, 38);
            this.ItemForAccName6.Name = "ItemForAccName6";
            this.ItemForAccName6.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName6.Text = "العملات:";
            this.ItemForAccName6.TextSize = new System.Drawing.Size(129, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.dtime_Start;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.Location = new System.Drawing.Point(1040, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(522, 28);
            this.layoutControlItem3.Text = "من تاريخ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(129, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.dtime_End;
            this.layoutControlItem2.Location = new System.Drawing.Point(522, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(518, 28);
            this.layoutControlItem2.Text = "الى تاريخ:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName12
            // 
            this.ItemForAccName12.Control = this.BranchLookup;
            this.ItemForAccName12.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName12.CustomizationFormText = "المستخدمين:";
            this.ItemForAccName12.Location = new System.Drawing.Point(0, 122);
            this.ItemForAccName12.Name = "ItemForAccName12";
            this.ItemForAccName12.Size = new System.Drawing.Size(522, 28);
            this.ItemForAccName12.Text = "الفروع:";
            this.ItemForAccName12.TextSize = new System.Drawing.Size(129, 18);
            // 
            // ItemForAccName5
            // 
            this.ItemForAccName5.Control = this.ReportModel;
            this.ItemForAccName5.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.ItemForAccName5.CustomizationFormText = "نوع التقرير:";
            this.ItemForAccName5.Location = new System.Drawing.Point(522, 122);
            this.ItemForAccName5.Name = "ItemForAccName5";
            this.ItemForAccName5.Size = new System.Drawing.Size(1040, 28);
            this.ItemForAccName5.Text = "نموذج التقرير :";
            this.ItemForAccName5.TextSize = new System.Drawing.Size(129, 18);
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // FormReportInvoiceFromTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 806);
            this.Controls.Add(this.dataLayout);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FormReportInvoiceFromTo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير المبيعات والمشتريات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraFormAccountsFromTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).EndInit();
            this.dataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtime_End.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_Start.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtime_Start.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuppLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurruncyLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurruncyLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupStrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBranchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchLookupView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccName5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayout;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExportPDF;
        private DevExpress.XtraEditors.SimpleButton btnRefreash;
        private DevExpress.XtraEditors.DateEdit dtime_End;
        private DevExpress.XtraGrid.GridControl gcInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.DateEdit dtime_Start;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.GridLookUpEdit CustLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView CustLookupView;
        private DevExpress.XtraEditors.GridLookUpEdit SuppLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView SuppLookupView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraEditors.CheckedComboBoxEdit InvoType;
        private DevExpress.XtraEditors.RadioGroup PayMethod;
        private DevExpress.XtraEditors.GridLookUpEdit CurruncyLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView CurruncyLookupView;
        private DevExpress.XtraEditors.GridLookUpEdit StoreLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView StoreLookupView;
        private DevExpress.XtraEditors.GridLookUpEdit UserLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView UserLookupView;
        private DevExpress.XtraEditors.GridLookUpEdit BoxLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView BoxLookupView;
        private DevExpress.XtraEditors.GridLookUpEdit BankLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView BankLookupView;
        private DevExpress.XtraEditors.RadioGroup ReportType;
        private System.Windows.Forms.BindingSource supplyMainBindingSource;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private System.Windows.Forms.BindingSource GroupStrBindingSource;
        private System.Windows.Forms.BindingSource userTblBindingSource;
        private System.Windows.Forms.BindingSource boxBindingSource;
        private System.Windows.Forms.BindingSource bankBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuanMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsupSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDscntPercent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colsupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCash;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFrgn;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyChng;
        private DevExpress.XtraGrid.Columns.GridColumn colStrId;
        private DevExpress.XtraGrid.Columns.GridColumn colDscntAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNet;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAfterDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colBoxId;
        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
        private DevExpress.XtraGrid.Columns.GridColumn colpaidCash;
        private DevExpress.XtraGrid.Columns.GridColumn colBankAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCustId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName4;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName9;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName8;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName10;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName6;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxType;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colDscntPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPaid;
        private DevExpress.XtraGrid.Columns.GridColumn colRemin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.RadioGroup ReportModel;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName5;
        private DevExpress.XtraEditors.GridLookUpEdit BranchLookup;
        private System.Windows.Forms.BindingSource tblBranchBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView BranchLookupView;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccName12;
    }
}