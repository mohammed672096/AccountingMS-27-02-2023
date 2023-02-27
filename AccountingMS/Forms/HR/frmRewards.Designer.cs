
namespace AccountingMS.Forms.HR
{
    partial class frmRewards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRewards));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.rewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateAncestorDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.amountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.reasonTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.empidTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForempid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFordateAncestor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForamount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForreason = new DevExpress.XtraLayout.LayoutControlItem();
            this.tblAccountBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colempid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empidTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.dateAncestorDateEdit);
            this.dataLayoutControl1.Controls.Add(this.amountTextEdit);
            this.dataLayoutControl1.Controls.Add(this.reasonTextEdit);
            this.dataLayoutControl1.Controls.Add(this.empidTextEdit);
            this.dataLayoutControl1.DataSource = this.rewardBindingSource;
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            // 
            // idTextEdit
            // 
            resources.ApplyResources(this.idTextEdit, "idTextEdit");
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rewardBindingSource, "id", true));
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.idTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.idTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("idTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.idTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.idTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.idTextEdit.Properties.ReadOnly = true;
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // rewardBindingSource
            // 
            this.rewardBindingSource.DataSource = typeof(AccountingMS.Reward);
            // 
            // dateAncestorDateEdit
            // 
            resources.ApplyResources(this.dateAncestorDateEdit, "dateAncestorDateEdit");
            this.dateAncestorDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rewardBindingSource, "dateAncestor", true));
            this.dateAncestorDateEdit.Name = "dateAncestorDateEdit";
            this.dateAncestorDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateAncestorDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dateAncestorDateEdit.Properties.Buttons"))))});
            this.dateAncestorDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dateAncestorDateEdit.Properties.CalendarTimeProperties.Buttons"))))});
            this.dateAncestorDateEdit.StyleController = this.dataLayoutControl1;
            // 
            // amountTextEdit
            // 
            resources.ApplyResources(this.amountTextEdit, "amountTextEdit");
            this.amountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rewardBindingSource, "amount", true));
            this.amountTextEdit.Name = "amountTextEdit";
            this.amountTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.amountTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.amountTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.amountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("amountTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.amountTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.amountTextEdit.Properties.MaskSettings.Set("mask", "F");
            this.amountTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // reasonTextEdit
            // 
            resources.ApplyResources(this.reasonTextEdit, "reasonTextEdit");
            this.reasonTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rewardBindingSource, "reason", true));
            this.reasonTextEdit.Name = "reasonTextEdit";
            this.reasonTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // empidTextEdit
            // 
            resources.ApplyResources(this.empidTextEdit, "empidTextEdit");
            this.empidTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.rewardBindingSource, "empid", true));
            this.empidTextEdit.Name = "empidTextEdit";
            this.empidTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.empidTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.empidTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.empidTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("empidTextEdit.Properties.Buttons"))))});
            this.empidTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("empidTextEdit.Properties.Columns"), resources.GetString("empidTextEdit.Properties.Columns1"), ((int)(resources.GetObject("empidTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("empidTextEdit.Properties.Columns3"))), resources.GetString("empidTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("empidTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("empidTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("empidTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("empidTextEdit.Properties.Columns8"))))});
            this.empidTextEdit.Properties.DataSource = this.tblEmployeeBindingSource;
            this.empidTextEdit.Properties.DisplayMember = "empName";
            this.empidTextEdit.Properties.NullText = resources.GetString("empidTextEdit.Properties.NullText");
            this.empidTextEdit.Properties.ShowFooter = false;
            this.empidTextEdit.Properties.ShowHeader = false;
            this.empidTextEdit.Properties.ShowLines = false;
            this.empidTextEdit.Properties.ValueMember = "id";
            this.empidTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // tblEmployeeBindingSource
            // 
            this.tblEmployeeBindingSource.DataSource = typeof(AccountingMS.tblEmployee);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(303, 563);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForempid,
            this.ItemFordateAncestor,
            this.ItemForamount,
            this.ItemForreason});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(283, 543);
            // 
            // ItemForid
            // 
            resources.ApplyResources(this.ItemForid, "ItemForid");
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(283, 24);
            this.ItemForid.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForempid
            // 
            resources.ApplyResources(this.ItemForempid, "ItemForempid");
            this.ItemForempid.Control = this.empidTextEdit;
            this.ItemForempid.Location = new System.Drawing.Point(0, 24);
            this.ItemForempid.Name = "ItemForempid";
            this.ItemForempid.Size = new System.Drawing.Size(283, 24);
            this.ItemForempid.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemFordateAncestor
            // 
            resources.ApplyResources(this.ItemFordateAncestor, "ItemFordateAncestor");
            this.ItemFordateAncestor.Control = this.dateAncestorDateEdit;
            this.ItemFordateAncestor.Location = new System.Drawing.Point(0, 48);
            this.ItemFordateAncestor.Name = "ItemFordateAncestor";
            this.ItemFordateAncestor.Size = new System.Drawing.Size(283, 24);
            this.ItemFordateAncestor.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForamount
            // 
            resources.ApplyResources(this.ItemForamount, "ItemForamount");
            this.ItemForamount.Control = this.amountTextEdit;
            this.ItemForamount.Location = new System.Drawing.Point(0, 72);
            this.ItemForamount.Name = "ItemForamount";
            this.ItemForamount.Size = new System.Drawing.Size(283, 24);
            this.ItemForamount.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForreason
            // 
            resources.ApplyResources(this.ItemForreason, "ItemForreason");
            this.ItemForreason.Control = this.reasonTextEdit;
            this.ItemForreason.Location = new System.Drawing.Point(0, 96);
            this.ItemForreason.Name = "ItemForreason";
            this.ItemForreason.Size = new System.Drawing.Size(283, 447);
            this.ItemForreason.TextSize = new System.Drawing.Size(44, 14);
            // 
            // tblAccountBoxBindingSource
            // 
            this.tblAccountBoxBindingSource.DataSource = typeof(AccountingMS.tblAccountBox);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.rewardBindingSource;
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
            this.repositoryItemLookUpEdit1});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colempid});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colempid
            // 
            resources.ApplyResources(this.colempid, "colempid");
            this.colempid.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colempid.FieldName = "empid";
            this.colempid.Name = "colempid";
            // 
            // repositoryItemLookUpEdit1
            // 
            resources.ApplyResources(this.repositoryItemLookUpEdit1, "repositoryItemLookUpEdit1");
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit1.Buttons"))))});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("repositoryItemLookUpEdit1.Columns"), resources.GetString("repositoryItemLookUpEdit1.Columns1"), ((int)(resources.GetObject("repositoryItemLookUpEdit1.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("repositoryItemLookUpEdit1.Columns3"))), resources.GetString("repositoryItemLookUpEdit1.Columns4"), ((bool)(resources.GetObject("repositoryItemLookUpEdit1.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("repositoryItemLookUpEdit1.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("repositoryItemLookUpEdit1.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("repositoryItemLookUpEdit1.Columns8"))))});
            this.repositoryItemLookUpEdit1.DataSource = this.tblEmployeeBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "empName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ReadOnly = true;
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // frmRewards
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmRewards.IconOptions.Image")));
            this.Name = "frmRewards";
            this.Load += new System.EventHandler(this.frmRewards_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empidTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource rewardBindingSource;
        private DevExpress.XtraEditors.DateEdit dateAncestorDateEdit;
        private DevExpress.XtraEditors.TextEdit amountTextEdit;
        private DevExpress.XtraEditors.TextEdit reasonTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForempid;
        private DevExpress.XtraLayout.LayoutControlItem ItemFordateAncestor;
        private DevExpress.XtraLayout.LayoutControlItem ItemForamount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForreason;
        private DevExpress.XtraGrid.Columns.GridColumn colempid;
        private DevExpress.XtraEditors.LookUpEdit empidTextEdit;
        private System.Windows.Forms.BindingSource tblEmployeeBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource tblAccountBoxBindingSource;
    }
}