namespace AccountingMS
{
    partial class formAddPrdExpirate
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblPrdExpirateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colexpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSupMainId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSupSubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdPrcQuanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdMsurStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditSupMainId = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.tblSupplyMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SleSupMainIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSupNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSupMainId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SleSupMainIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bbiReset,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1010, 135);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "إعادة التهيئه";
            this.bbiReset.Id = 2;
            this.bbiReset.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_rollback;
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 3;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiReset);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblPrdExpirateBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 241);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1010, 333);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblPrdExpirateBindingSource
            // 
            this.tblPrdExpirateBindingSource.DataSource = typeof(AccountingMS.tblPrdExpirate);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colexpId,
            this.colexpSupMainId,
            this.colexpSupSubId,
            this.colexpPrdPrcQuanId,
            this.colexpSupNo,
            this.colexpPrdId,
            this.colexpPrdMsurId,
            this.colexpQuan,
            this.colexpPrdMsurStatus,
            this.colexpPrdDate,
            this.colexpDate,
            this.colexpBrnId,
            this.colexpStatus});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colexpId
            // 
            this.colexpId.FieldName = "expId";
            this.colexpId.MinWidth = 23;
            this.colexpId.Name = "colexpId";
            this.colexpId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpId.Width = 87;
            // 
            // colexpSupMainId
            // 
            this.colexpSupMainId.FieldName = "expSupMainId";
            this.colexpSupMainId.MinWidth = 23;
            this.colexpSupMainId.Name = "colexpSupMainId";
            this.colexpSupMainId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpSupMainId.Width = 87;
            // 
            // colexpSupSubId
            // 
            this.colexpSupSubId.FieldName = "expSupSubId";
            this.colexpSupSubId.MinWidth = 23;
            this.colexpSupSubId.Name = "colexpSupSubId";
            this.colexpSupSubId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpSupSubId.Width = 87;
            // 
            // colexpPrdPrcQuanId
            // 
            this.colexpPrdPrcQuanId.FieldName = "expPrdPrcQuanId";
            this.colexpPrdPrcQuanId.MinWidth = 23;
            this.colexpPrdPrcQuanId.Name = "colexpPrdPrcQuanId";
            this.colexpPrdPrcQuanId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpPrdPrcQuanId.Width = 87;
            // 
            // colexpSupNo
            // 
            this.colexpSupNo.FieldName = "expSupNo";
            this.colexpSupNo.MinWidth = 23;
            this.colexpSupNo.Name = "colexpSupNo";
            this.colexpSupNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpSupNo.Width = 87;
            // 
            // colexpPrdId
            // 
            this.colexpPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdId.Caption = "الصنف";
            this.colexpPrdId.FieldName = "expPrdId";
            this.colexpPrdId.MinWidth = 23;
            this.colexpPrdId.Name = "colexpPrdId";
            this.colexpPrdId.OptionsColumn.AllowEdit = false;
            this.colexpPrdId.OptionsColumn.TabStop = false;
            this.colexpPrdId.Visible = true;
            this.colexpPrdId.VisibleIndex = 1;
            this.colexpPrdId.Width = 87;
            // 
            // colexpPrdMsurId
            // 
            this.colexpPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdMsurId.Caption = "وحدة القياس";
            this.colexpPrdMsurId.FieldName = "expPrdMsurId";
            this.colexpPrdMsurId.MinWidth = 23;
            this.colexpPrdMsurId.Name = "colexpPrdMsurId";
            this.colexpPrdMsurId.OptionsColumn.AllowEdit = false;
            this.colexpPrdMsurId.OptionsColumn.TabStop = false;
            this.colexpPrdMsurId.Visible = true;
            this.colexpPrdMsurId.VisibleIndex = 2;
            this.colexpPrdMsurId.Width = 87;
            // 
            // colexpQuan
            // 
            this.colexpQuan.AppearanceCell.Options.UseTextOptions = true;
            this.colexpQuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpQuan.Caption = "كمية الشراء";
            this.colexpQuan.FieldName = "expQuan";
            this.colexpQuan.MinWidth = 23;
            this.colexpQuan.Name = "colexpQuan";
            this.colexpQuan.OptionsColumn.AllowEdit = false;
            this.colexpQuan.OptionsColumn.TabStop = false;
            this.colexpQuan.Visible = true;
            this.colexpQuan.VisibleIndex = 3;
            this.colexpQuan.Width = 87;
            // 
            // colexpPrdMsurStatus
            // 
            this.colexpPrdMsurStatus.FieldName = "expPrdMsurStatus";
            this.colexpPrdMsurStatus.MinWidth = 23;
            this.colexpPrdMsurStatus.Name = "colexpPrdMsurStatus";
            this.colexpPrdMsurStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpPrdMsurStatus.Width = 87;
            // 
            // colexpPrdDate
            // 
            this.colexpPrdDate.Caption = "تاريخ الإنتهاء";
            this.colexpPrdDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colexpPrdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colexpPrdDate.FieldName = "expPrdDate";
            this.colexpPrdDate.MinWidth = 23;
            this.colexpPrdDate.Name = "colexpPrdDate";
            this.colexpPrdDate.Visible = true;
            this.colexpPrdDate.VisibleIndex = 4;
            this.colexpPrdDate.Width = 87;
            // 
            // colexpDate
            // 
            this.colexpDate.FieldName = "expDate";
            this.colexpDate.MinWidth = 23;
            this.colexpDate.Name = "colexpDate";
            this.colexpDate.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpDate.Width = 87;
            // 
            // colexpBrnId
            // 
            this.colexpBrnId.FieldName = "expBrnId";
            this.colexpBrnId.MinWidth = 23;
            this.colexpBrnId.Name = "colexpBrnId";
            this.colexpBrnId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpBrnId.Width = 87;
            // 
            // colexpStatus
            // 
            this.colexpStatus.FieldName = "expStatus";
            this.colexpStatus.MinWidth = 23;
            this.colexpStatus.Name = "colexpStatus";
            this.colexpStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpStatus.Width = 87;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditSupMainId);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 135);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1010, 106);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEditSupMainId
            // 
            this.textEditSupMainId.Location = new System.Drawing.Point(16, 46);
            this.textEditSupMainId.MenuManager = this.ribbonControl1;
            this.textEditSupMainId.Name = "textEditSupMainId";
            this.textEditSupMainId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textEditSupMainId.Properties.Appearance.Options.UseFont = true;
            this.textEditSupMainId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditSupMainId.Properties.DataSource = this.tblSupplyMainBindingSource;
            this.textEditSupMainId.Properties.DisplayMember = "supNo";
            this.textEditSupMainId.Properties.NullText = "";
            this.textEditSupMainId.Properties.PopupView = this.SleSupMainIdView;
            this.textEditSupMainId.Properties.ValueMember = "id";
            this.textEditSupMainId.Size = new System.Drawing.Size(978, 24);
            this.textEditSupMainId.StyleController = this.layoutControl1;
            this.textEditSupMainId.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.textEditSupMainId, conditionValidationRule1);
            // 
            // tblSupplyMainBindingSource
            // 
            this.tblSupplyMainBindingSource.DataSource = typeof(AccountingMS.tblSupplyMain);
            // 
            // SleSupMainIdView
            // 
            this.SleSupMainIdView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.SleSupMainIdView.Appearance.HeaderPanel.Options.UseFont = true;
            this.SleSupMainIdView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupNo,
            this.colsupAccName,
            this.colsupDesc,
            this.colsupTotal,
            this.colsupTaxPrice,
            this.colsupDate});
            this.SleSupMainIdView.DetailHeight = 377;
            this.SleSupMainIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SleSupMainIdView.Name = "SleSupMainIdView";
            this.SleSupMainIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SleSupMainIdView.OptionsView.ShowGroupPanel = false;
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
            this.colsupNo.VisibleIndex = 0;
            this.colsupNo.Width = 87;
            // 
            // colsupAccName
            // 
            this.colsupAccName.Caption = "إسم الحساب";
            this.colsupAccName.FieldName = "supAccName";
            this.colsupAccName.MinWidth = 23;
            this.colsupAccName.Name = "colsupAccName";
            this.colsupAccName.Visible = true;
            this.colsupAccName.VisibleIndex = 1;
            this.colsupAccName.Width = 87;
            // 
            // colsupDesc
            // 
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.FieldName = "supDesc";
            this.colsupDesc.MinWidth = 23;
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Visible = true;
            this.colsupDesc.VisibleIndex = 2;
            this.colsupDesc.Width = 87;
            // 
            // colsupTotal
            // 
            this.colsupTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTotal.Caption = "المبلغ";
            this.colsupTotal.DisplayFormat.FormatString = "n2";
            this.colsupTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTotal.FieldName = "supTotal";
            this.colsupTotal.MinWidth = 23;
            this.colsupTotal.Name = "colsupTotal";
            this.colsupTotal.Visible = true;
            this.colsupTotal.VisibleIndex = 3;
            this.colsupTotal.Width = 87;
            // 
            // colsupTaxPrice
            // 
            this.colsupTaxPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colsupTaxPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupTaxPrice.Caption = "الضريبة";
            this.colsupTaxPrice.DisplayFormat.FormatString = "n2";
            this.colsupTaxPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colsupTaxPrice.FieldName = "supTaxPrice";
            this.colsupTaxPrice.MinWidth = 23;
            this.colsupTaxPrice.Name = "colsupTaxPrice";
            this.colsupTaxPrice.Visible = true;
            this.colsupTaxPrice.VisibleIndex = 4;
            this.colsupTaxPrice.Width = 87;
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
            this.colsupDate.VisibleIndex = 5;
            this.colsupDate.Width = 87;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.simpleSeparator1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1010, 106);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSupNo});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(986, 68);
            this.layoutControlGroup1.Text = "رقم فاتورة المشتريات";
            // 
            // ItemForSupNo
            // 
            this.ItemForSupNo.Control = this.textEditSupMainId;
            this.ItemForSupNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForSupNo.Name = "ItemForSupNo";
            this.ItemForSupNo.Size = new System.Drawing.Size(982, 28);
            this.ItemForSupNo.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForSupNo.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 68);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(986, 16);
            this.simpleSeparator1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 2, 6);
            // 
            // formAddPrdExpirate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 574);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "formAddPrdExpirate";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة تاريخ إنتهاء الأصناف";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditSupMainId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplyMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SleSupMainIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblPrdExpirateBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colexpId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSupMainId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSupSubId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdPrcQuanId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpQuan;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdMsurStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdDate;
        private DevExpress.XtraGrid.Columns.GridColumn colexpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colexpBrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpStatus;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit textEditSupMainId;
        private DevExpress.XtraGrid.Views.Grid.GridView SleSupMainIdView;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource tblSupplyMainBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colsupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSupNo;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
    }
}