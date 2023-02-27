
namespace AccountingMS
{
    partial class DepartmentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentView));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.IDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ParentIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.MangerNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NotesMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForParentID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMangerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNotes = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangerNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMangerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.IDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ParentIDLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.MangerNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NotesMemoEdit);
            this.dataLayoutControl1.DataSource = this.departmentBindingSource;
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.departmentBindingSource;
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleDescription");
            this.gridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleName");
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImage")));
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl1.EmbeddedNavigator.MaximumSize")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.BtnEdit});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(AccountingMS.Department);
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "name";
            this.colName.MinWidth = 23;
            this.colName.Name = "colName";
            this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // BtnEdit
            // 
            resources.ApplyResources(this.BtnEdit, "BtnEdit");
            this.BtnEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // IDTextEdit
            // 
            resources.ApplyResources(this.IDTextEdit, "IDTextEdit");
            this.IDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.departmentBindingSource, "ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IDTextEdit.Name = "IDTextEdit";
            this.IDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.IDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.IDTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.IDTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.IDTextEdit.Properties.ReadOnly = true;
            this.IDTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // NameTextEdit
            // 
            resources.ApplyResources(this.NameTextEdit, "NameTextEdit");
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.departmentBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // ParentIDLookUpEdit
            // 
            resources.ApplyResources(this.ParentIDLookUpEdit, "ParentIDLookUpEdit");
            this.ParentIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.departmentBindingSource, "ParentID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ParentIDLookUpEdit.Name = "ParentIDLookUpEdit";
            this.ParentIDLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ParentIDLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ParentIDLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ParentIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ParentIDLookUpEdit.Properties.Buttons"))))});
            this.ParentIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("ParentIDLookUpEdit.Properties.Columns"), resources.GetString("ParentIDLookUpEdit.Properties.Columns1"), ((int)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns3"))), resources.GetString("ParentIDLookUpEdit.Properties.Columns4"), ((bool)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("ParentIDLookUpEdit.Properties.Columns8"))))});
            this.ParentIDLookUpEdit.Properties.DataSource = this.departmentBindingSource;
            this.ParentIDLookUpEdit.Properties.DisplayMember = "name";
            this.ParentIDLookUpEdit.Properties.NullText = resources.GetString("ParentIDLookUpEdit.Properties.NullText");
            this.ParentIDLookUpEdit.Properties.ShowFooter = false;
            this.ParentIDLookUpEdit.Properties.ShowHeader = false;
            this.ParentIDLookUpEdit.Properties.ShowLines = false;
            this.ParentIDLookUpEdit.Properties.ValueMember = "id";
            this.ParentIDLookUpEdit.StyleController = this.dataLayoutControl1;
            // 
            // MangerNameTextEdit
            // 
            resources.ApplyResources(this.MangerNameTextEdit, "MangerNameTextEdit");
            this.MangerNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.departmentBindingSource, "MangerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MangerNameTextEdit.Name = "MangerNameTextEdit";
            this.MangerNameTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // NotesMemoEdit
            // 
            resources.ApplyResources(this.NotesMemoEdit, "NotesMemoEdit");
            this.NotesMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.departmentBindingSource, "Notes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NotesMemoEdit.Name = "NotesMemoEdit";
            this.NotesMemoEdit.StyleController = this.dataLayoutControl1;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(933, 563);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(913, 543);
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForID,
            this.ItemForName,
            this.ItemForParentID,
            this.ItemForMangerName,
            this.ItemForNotes});
            this.layoutControlGroup2.Location = new System.Drawing.Point(532, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(381, 543);
            // 
            // ItemForID
            // 
            resources.ApplyResources(this.ItemForID, "ItemForID");
            this.ItemForID.Control = this.IDTextEdit;
            this.ItemForID.Location = new System.Drawing.Point(0, 0);
            this.ItemForID.MaxSize = new System.Drawing.Size(357, 26);
            this.ItemForID.MinSize = new System.Drawing.Size(357, 26);
            this.ItemForID.Name = "ItemForID";
            this.ItemForID.Size = new System.Drawing.Size(357, 26);
            this.ItemForID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForID.TextSize = new System.Drawing.Size(101, 14);
            // 
            // ItemForName
            // 
            resources.ApplyResources(this.ItemForName, "ItemForName");
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 26);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(357, 24);
            this.ItemForName.TextSize = new System.Drawing.Size(101, 14);
            // 
            // ItemForParentID
            // 
            resources.ApplyResources(this.ItemForParentID, "ItemForParentID");
            this.ItemForParentID.Control = this.ParentIDLookUpEdit;
            this.ItemForParentID.Location = new System.Drawing.Point(0, 50);
            this.ItemForParentID.Name = "ItemForParentID";
            this.ItemForParentID.Size = new System.Drawing.Size(357, 24);
            this.ItemForParentID.TextSize = new System.Drawing.Size(101, 14);
            // 
            // ItemForMangerName
            // 
            resources.ApplyResources(this.ItemForMangerName, "ItemForMangerName");
            this.ItemForMangerName.Control = this.MangerNameTextEdit;
            this.ItemForMangerName.Location = new System.Drawing.Point(0, 74);
            this.ItemForMangerName.Name = "ItemForMangerName";
            this.ItemForMangerName.Size = new System.Drawing.Size(357, 24);
            this.ItemForMangerName.TextSize = new System.Drawing.Size(101, 14);
            // 
            // ItemForNotes
            // 
            resources.ApplyResources(this.ItemForNotes, "ItemForNotes");
            this.ItemForNotes.Control = this.NotesMemoEdit;
            this.ItemForNotes.Location = new System.Drawing.Point(0, 98);
            this.ItemForNotes.MaxSize = new System.Drawing.Size(0, 349);
            this.ItemForNotes.MinSize = new System.Drawing.Size(97, 349);
            this.ItemForNotes.Name = "ItemForNotes";
            this.ItemForNotes.Size = new System.Drawing.Size(357, 396);
            this.ItemForNotes.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForNotes.StartNewLine = true;
            this.ItemForNotes.TextSize = new System.Drawing.Size(101, 14);
            // 
            // layoutControlGroup3
            // 
            resources.ApplyResources(this.layoutControlGroup3, "layoutControlGroup3");
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(532, 543);
            // 
            // layoutControlItem1
            // 
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(121, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(508, 494);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // DepartmentView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("DepartmentView.IconOptions.Image")));
            this.Name = "DepartmentView";
            this.Load += new System.EventHandler(this.DepartmentView_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParentIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MangerNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMangerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit IDTextEdit;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.LookUpEdit ParentIDLookUpEdit;
        private DevExpress.XtraEditors.TextEdit MangerNameTextEdit;
        private DevExpress.XtraEditors.MemoEdit NotesMemoEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForParentID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMangerName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNotes;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit BtnEdit;
    }
}