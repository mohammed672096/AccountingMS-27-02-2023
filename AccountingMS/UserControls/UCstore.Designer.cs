namespace AccountingMS
{
    partial class UCstore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCstore));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colprdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNameEng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblGroupStrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colgrpNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpSalesAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpCostAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpSalesRtrnAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpCostRtrnAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpDscntAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBarcodeNo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEditBarcodeNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bsiBarcodeNo = new DevExpress.XtraBars.BarStaticItem();
            this.bbiReplicatedBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSearchBarcode = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tblStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroupStrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditBarcodeNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Chocolate;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.Moccasin;
            this.gridView2.Appearance.Row.BackColor2 = System.Drawing.Color.PaleTurquoise;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colprdNo,
            this.colprdName,
            this.colprdNameEng,
            this.colprdDesc,
            this.colprdStatus,
            this.gridColumn1,
            this.colUnitName});
            this.gridView2.DetailHeight = 485;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colprdNo
            // 
            this.colprdNo.Caption = "رقم الصنف";
            this.colprdNo.FieldName = "prdNo";
            this.colprdNo.MinWidth = 26;
            this.colprdNo.Name = "colprdNo";
            this.colprdNo.Visible = true;
            this.colprdNo.VisibleIndex = 0;
            this.colprdNo.Width = 99;
            // 
            // colprdName
            // 
            this.colprdName.Caption = "إسم الصنف";
            this.colprdName.FieldName = "prdName";
            this.colprdName.MinWidth = 26;
            this.colprdName.Name = "colprdName";
            this.colprdName.Visible = true;
            this.colprdName.VisibleIndex = 1;
            this.colprdName.Width = 99;
            // 
            // colprdNameEng
            // 
            this.colprdNameEng.Caption = "إسم الصنف بلانجليزي";
            this.colprdNameEng.FieldName = "prdNameEng";
            this.colprdNameEng.MinWidth = 26;
            this.colprdNameEng.Name = "colprdNameEng";
            this.colprdNameEng.Visible = true;
            this.colprdNameEng.VisibleIndex = 2;
            this.colprdNameEng.Width = 99;
            // 
            // colprdDesc
            // 
            this.colprdDesc.Caption = "المواصفات";
            this.colprdDesc.FieldName = "prdDesc";
            this.colprdDesc.MinWidth = 26;
            this.colprdDesc.Name = "colprdDesc";
            this.colprdDesc.Width = 99;
            // 
            // colprdStatus
            // 
            this.colprdStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colprdStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colprdStatus.Caption = "نوع الصنف";
            this.colprdStatus.FieldName = "prdStatus";
            this.colprdStatus.MinWidth = 26;
            this.colprdStatus.Name = "colprdStatus";
            this.colprdStatus.Visible = true;
            this.colprdStatus.VisibleIndex = 3;
            this.colprdStatus.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "باركود";
            this.gridColumn1.FieldName = "Barcode";
            this.gridColumn1.MinWidth = 26;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 99;
            // 
            // colUnitName
            // 
            this.colUnitName.Caption = "وحدة القياس";
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MinWidth = 25;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Width = 86;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblGroupStrBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 149);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1243, 654);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView2});
            // 
            // tblGroupStrBindingSource
            // 
            this.tblGroupStrBindingSource.DataSource = typeof(AccountingMS.tblGroupStr);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colgrpNo,
            this.colgrpName,
            this.colgrpAccNo,
            this.colgrpSalesAccNo,
            this.colgrpCostAccNo,
            this.colgrpSalesRtrnAccNo,
            this.colgrpCostRtrnAccNo,
            this.colgrpDscntAccNo,
            this.colgrpId});
            this.gridView.DetailHeight = 485;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colgrpNo
            // 
            this.colgrpNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpNo.Caption = "رقم المجموعة";
            this.colgrpNo.FieldName = "grpNo";
            this.colgrpNo.MinWidth = 26;
            this.colgrpNo.Name = "colgrpNo";
            this.colgrpNo.Visible = true;
            this.colgrpNo.VisibleIndex = 0;
            this.colgrpNo.Width = 99;
            // 
            // colgrpName
            // 
            this.colgrpName.Caption = "إسم المجموعة";
            this.colgrpName.FieldName = "grpName";
            this.colgrpName.MinWidth = 26;
            this.colgrpName.Name = "colgrpName";
            this.colgrpName.Visible = true;
            this.colgrpName.VisibleIndex = 1;
            this.colgrpName.Width = 99;
            // 
            // colgrpAccNo
            // 
            this.colgrpAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpAccNo.Caption = "رقم حساب المجموعة";
            this.colgrpAccNo.FieldName = "grpAccNo";
            this.colgrpAccNo.MinWidth = 26;
            this.colgrpAccNo.Name = "colgrpAccNo";
            this.colgrpAccNo.Visible = true;
            this.colgrpAccNo.VisibleIndex = 2;
            this.colgrpAccNo.Width = 99;
            // 
            // colgrpSalesAccNo
            // 
            this.colgrpSalesAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpSalesAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpSalesAccNo.Caption = "رقم حساب المبيعات";
            this.colgrpSalesAccNo.FieldName = "grpSalesAccNo";
            this.colgrpSalesAccNo.MinWidth = 26;
            this.colgrpSalesAccNo.Name = "colgrpSalesAccNo";
            this.colgrpSalesAccNo.Visible = true;
            this.colgrpSalesAccNo.VisibleIndex = 3;
            this.colgrpSalesAccNo.Width = 99;
            // 
            // colgrpCostAccNo
            // 
            this.colgrpCostAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpCostAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpCostAccNo.Caption = "رقم حساب تكلفة المبيعات";
            this.colgrpCostAccNo.FieldName = "grpCostAccNo";
            this.colgrpCostAccNo.MinWidth = 26;
            this.colgrpCostAccNo.Name = "colgrpCostAccNo";
            this.colgrpCostAccNo.Visible = true;
            this.colgrpCostAccNo.VisibleIndex = 4;
            this.colgrpCostAccNo.Width = 99;
            // 
            // colgrpSalesRtrnAccNo
            // 
            this.colgrpSalesRtrnAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpSalesRtrnAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpSalesRtrnAccNo.Caption = "رقم حساب مردود المبيعات";
            this.colgrpSalesRtrnAccNo.FieldName = "grpSalesRtrnAccNo";
            this.colgrpSalesRtrnAccNo.MinWidth = 26;
            this.colgrpSalesRtrnAccNo.Name = "colgrpSalesRtrnAccNo";
            this.colgrpSalesRtrnAccNo.Visible = true;
            this.colgrpSalesRtrnAccNo.VisibleIndex = 5;
            this.colgrpSalesRtrnAccNo.Width = 99;
            // 
            // colgrpCostRtrnAccNo
            // 
            this.colgrpCostRtrnAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpCostRtrnAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpCostRtrnAccNo.Caption = "رقم حساب تكلفة مردود المبيعات";
            this.colgrpCostRtrnAccNo.FieldName = "grpCostRtrnAccNo";
            this.colgrpCostRtrnAccNo.MinWidth = 26;
            this.colgrpCostRtrnAccNo.Name = "colgrpCostRtrnAccNo";
            this.colgrpCostRtrnAccNo.Visible = true;
            this.colgrpCostRtrnAccNo.VisibleIndex = 6;
            this.colgrpCostRtrnAccNo.Width = 99;
            // 
            // colgrpDscntAccNo
            // 
            this.colgrpDscntAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colgrpDscntAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colgrpDscntAccNo.Caption = "رقم حساب الخصوم";
            this.colgrpDscntAccNo.FieldName = "grpDscntAccNo";
            this.colgrpDscntAccNo.MinWidth = 26;
            this.colgrpDscntAccNo.Name = "colgrpDscntAccNo";
            this.colgrpDscntAccNo.Width = 99;
            // 
            // colgrpId
            // 
            this.colgrpId.Caption = "colgrpId";
            this.colgrpId.FieldName = "id";
            this.colgrpId.MinWidth = 26;
            this.colgrpId.Name = "colgrpId";
            this.colgrpId.Width = 99;
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 39, 34, 39);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bsiRecordsCount,
            this.bbiNew,
            this.barButtonItem1,
            this.barButtonItem2,
            this.bbiRefresh,
            this.barButtonItem5,
            this.bbiBarcodeNo,
            this.bsiBarcodeNo,
            this.bbiReplicatedBarcode,
            this.barButtonItem4,
            this.barButtonItem6,
            this.barButtonItem3});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 34;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 377;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditBarcodeNo});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1243, 149);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "المخازن\r\nF1";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            this.bbiNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "إنشاء مجموعة\r\nF2";
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "إنشاء صنف\r\nF3";
            this.barButtonItem2.Id = 21;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث\r\nF5";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "تقرير المخازن\r\nF7";
            this.barButtonItem5.Id = 24;
            this.barButtonItem5.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.report_32x32;
            this.barButtonItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bbiBarcodeNo
            // 
            this.bbiBarcodeNo.Edit = this.repositoryItemTextEditBarcodeNo;
            this.bbiBarcodeNo.EditValue = "";
            this.bbiBarcodeNo.EditWidth = 100;
            this.bbiBarcodeNo.Id = 28;
            this.bbiBarcodeNo.Name = "bbiBarcodeNo";
            // 
            // repositoryItemTextEditBarcodeNo
            // 
            this.repositoryItemTextEditBarcodeNo.AutoHeight = false;
            this.repositoryItemTextEditBarcodeNo.Name = "repositoryItemTextEditBarcodeNo";
            // 
            // bsiBarcodeNo
            // 
            this.bsiBarcodeNo.Caption = "رقم الباركود";
            this.bsiBarcodeNo.Id = 29;
            this.bsiBarcodeNo.Name = "bsiBarcodeNo";
            // 
            // bbiReplicatedBarcode
            // 
            this.bbiReplicatedBarcode.Caption = "البراكود المتكرر";
            this.bbiReplicatedBarcode.Id = 30;
            this.bbiReplicatedBarcode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiReplicatedBarcode.ImageOptions.SvgImage")));
            this.bbiReplicatedBarcode.Name = "bbiReplicatedBarcode";
            this.bbiReplicatedBarcode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReplicatedBarcode_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "عرض نماذج الباركود";
            this.barButtonItem4.Id = 31;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "طباعه باركود الاصناف";
            this.barButtonItem6.Id = 32;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "الباركود";
            this.barButtonItem3.Id = 33;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroupSearchBarcode,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew, "F1");
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1, "F2");
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2, "F3");
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiRefresh, "F5");
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5, "F7");
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "الطباعة والتصدير";
            // 
            // ribbonPageGroupSearchBarcode
            // 
            this.ribbonPageGroupSearchBarcode.AllowTextClipping = false;
            this.ribbonPageGroupSearchBarcode.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupSearchBarcode.ItemLinks.Add(this.bsiBarcodeNo);
            this.ribbonPageGroupSearchBarcode.ItemLinks.Add(this.bbiBarcodeNo);
            this.ribbonPageGroupSearchBarcode.Name = "ribbonPageGroupSearchBarcode";
            this.ribbonPageGroupSearchBarcode.Text = "بحث الصنف";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiReplicatedBarcode);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "نماذج الباركود";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 803);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1243, 28);
            // 
            // tblStoreBindingSource
            // 
            this.tblStoreBindingSource.DataSource = typeof(AccountingMS.tblStore);
            // 
            // UCstore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCstore";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1243, 831);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroupStrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditBarcodeNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.BindingSource tblStoreBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName;
        private DevExpress.XtraGrid.Columns.GridColumn colprdDesc;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNameEng;
        private DevExpress.XtraBars.BarEditItem bbiBarcodeNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditBarcodeNo;
        private DevExpress.XtraBars.BarStaticItem bsiBarcodeNo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSearchBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpName;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpSalesAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpCostAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpSalesRtrnAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpCostRtrnAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpDscntAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colgrpId;
        private System.Windows.Forms.BindingSource tblGroupStrBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colprdStatus;
        private DevExpress.XtraBars.BarButtonItem bbiReplicatedBarcode;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
    }
}
