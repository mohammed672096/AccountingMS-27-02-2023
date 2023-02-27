namespace AccountingMS   
{
    partial class UCstoreData
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupTasks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.strNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tblStoreObjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.strNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.strPhnNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupStoreObj = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForstrNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForstrName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForstrPhnNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreObjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strPhnNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStoreObj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrPhnNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 21;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(928, 102);
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
            this.bbiNew.Caption = "إضافة مخزن\r\nF2";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.Image = global::AccountingMS.Properties.Resources.add_32x32;
            this.bbiNew.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.add_32x32;
            this.bbiNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "تعديل\r\nF3";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_edit;
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.Image = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث\r\nF5";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.Image = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRefresh_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupTasks});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroupTasks
            // 
            this.ribbonPageGroupTasks.AllowTextClipping = false;
            this.ribbonPageGroupTasks.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroupTasks.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroupTasks.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroupTasks.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroupTasks.Name = "ribbonPageGroupTasks";
            this.ribbonPageGroupTasks.ShowCaptionButton = false;
            this.ribbonPageGroupTasks.Text = "العمليات";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 578);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(928, 22);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 102);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.dataLayoutControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitContainerControl1.Size = new System.Drawing.Size(928, 476);
            this.splitContainerControl1.SplitterPosition = 700;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblStoreBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(700, 476);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblStoreBindingSource
            // 
            this.tblStoreBindingSource.DataSource = typeof(tblStore);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colstrNo,
            this.colstrName,
            this.colstrPhnNo,
            this.colstrBrnId});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colstrNo
            // 
            this.colstrNo.AppearanceCell.Options.UseTextOptions = true;
            this.colstrNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstrNo.Caption = "رقم المخزن";
            this.colstrNo.FieldName = "strNo";
            this.colstrNo.Name = "colstrNo";
            this.colstrNo.Visible = true;
            this.colstrNo.VisibleIndex = 0;
            this.colstrNo.Width = 127;
            // 
            // colstrName
            // 
            this.colstrName.Caption = "إسم المخزن";
            this.colstrName.FieldName = "strName";
            this.colstrName.Name = "colstrName";
            this.colstrName.Visible = true;
            this.colstrName.VisibleIndex = 1;
            this.colstrName.Width = 219;
            // 
            // colstrPhnNo
            // 
            this.colstrPhnNo.Caption = "رقم الهاتف";
            this.colstrPhnNo.FieldName = "strPhnNo";
            this.colstrPhnNo.Name = "colstrPhnNo";
            this.colstrPhnNo.Visible = true;
            this.colstrPhnNo.VisibleIndex = 2;
            this.colstrPhnNo.Width = 223;
            // 
            // colstrBrnId
            // 
            this.colstrBrnId.FieldName = "strBrnId";
            this.colstrBrnId.Name = "colstrBrnId";
            this.colstrBrnId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.strNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.strNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.strPhnNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.btnSave);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.DataSource = this.tblStoreObjBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Enabled = false;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(218, 476);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // strNoTextEdit
            // 
            this.strNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblStoreObjBindingSource, "strNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.strNoTextEdit.Location = new System.Drawing.Point(4, 40);
            this.strNoTextEdit.MenuManager = this.ribbonControl;
            this.strNoTextEdit.Name = "strNoTextEdit";
            this.strNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.strNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.strNoTextEdit.Properties.Mask.EditMask = "N0";
            this.strNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.strNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.strNoTextEdit.Size = new System.Drawing.Size(138, 20);
            this.strNoTextEdit.StyleController = this.dataLayoutControl1;
            this.strNoTextEdit.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.strNoTextEdit, conditionValidationRule1);
            // 
            // tblStoreObjBindingSource
            // 
            this.tblStoreObjBindingSource.DataSource = typeof(tblStore);
            // 
            // strNameTextEdit
            // 
            this.strNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblStoreObjBindingSource, "strName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.strNameTextEdit.Location = new System.Drawing.Point(4, 64);
            this.strNameTextEdit.MenuManager = this.ribbonControl;
            this.strNameTextEdit.Name = "strNameTextEdit";
            this.strNameTextEdit.Properties.MaxLength = 50;
            this.strNameTextEdit.Size = new System.Drawing.Size(138, 20);
            this.strNameTextEdit.StyleController = this.dataLayoutControl1;
            this.strNameTextEdit.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.strNameTextEdit, conditionValidationRule2);
            // 
            // strPhnNoTextEdit
            // 
            this.strPhnNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblStoreObjBindingSource, "strPhnNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.strPhnNoTextEdit.Location = new System.Drawing.Point(4, 88);
            this.strPhnNoTextEdit.MenuManager = this.ribbonControl;
            this.strPhnNoTextEdit.Name = "strPhnNoTextEdit";
            this.strPhnNoTextEdit.Properties.MaxLength = 15;
            this.strPhnNoTextEdit.Size = new System.Drawing.Size(138, 20);
            this.strPhnNoTextEdit.StyleController = this.dataLayoutControl1;
            this.strPhnNoTextEdit.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 22);
            this.btnSave.StyleController = this.dataLayoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 22);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Root
            // 
            this.Root.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Root.AppearanceGroup.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 2;
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(218, 476);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupStoreObj});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(218, 476);
            // 
            // layoutControlGroupStoreObj
            // 
            this.layoutControlGroupStoreObj.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupStoreObj.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForstrNo,
            this.ItemForstrName,
            this.ItemForstrPhnNo,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.simpleSeparator1});
            this.layoutControlGroupStoreObj.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupStoreObj.Name = "layoutControlGroupStoreObj";
            this.layoutControlGroupStoreObj.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 10);
            this.layoutControlGroupStoreObj.Size = new System.Drawing.Size(218, 476);
            this.layoutControlGroupStoreObj.Text = "بيانات المخزن";
            // 
            // ItemForstrNo
            // 
            this.ItemForstrNo.Control = this.strNoTextEdit;
            this.ItemForstrNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForstrNo.Name = "ItemForstrNo";
            this.ItemForstrNo.Size = new System.Drawing.Size(214, 24);
            this.ItemForstrNo.Text = "رقم المخزن :";
            this.ItemForstrNo.TextSize = new System.Drawing.Size(70, 17);
            // 
            // ItemForstrName
            // 
            this.ItemForstrName.Control = this.strNameTextEdit;
            this.ItemForstrName.Location = new System.Drawing.Point(0, 24);
            this.ItemForstrName.Name = "ItemForstrName";
            this.ItemForstrName.Size = new System.Drawing.Size(214, 24);
            this.ItemForstrName.Text = "إسم المخزن :";
            this.ItemForstrName.TextSize = new System.Drawing.Size(70, 17);
            // 
            // ItemForstrPhnNo
            // 
            this.ItemForstrPhnNo.Control = this.strPhnNoTextEdit;
            this.ItemForstrPhnNo.Location = new System.Drawing.Point(0, 48);
            this.ItemForstrPhnNo.Name = "ItemForstrPhnNo";
            this.ItemForstrPhnNo.Size = new System.Drawing.Size(214, 24);
            this.ItemForstrPhnNo.Text = "رقم الهاتف :";
            this.ItemForstrPhnNo.TextSize = new System.Drawing.Size(70, 17);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(107, 88);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(107, 338);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 88);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(107, 338);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 72);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(214, 16);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 10);
            // 
            // UCstoreData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCstoreData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(928, 600);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStoreObjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strPhnNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStoreObj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForstrPhnNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTasks;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private System.Windows.Forms.BindingSource tblStoreBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colstrNo;
        private DevExpress.XtraGrid.Columns.GridColumn colstrName;
        private DevExpress.XtraGrid.Columns.GridColumn colstrPhnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colstrBrnId;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit strNoTextEdit;
        private System.Windows.Forms.BindingSource tblStoreObjBindingSource;
        private DevExpress.XtraEditors.TextEdit strNameTextEdit;
        private DevExpress.XtraEditors.TextEdit strPhnNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForstrNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForstrName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForstrPhnNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupStoreObj;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        protected internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}
