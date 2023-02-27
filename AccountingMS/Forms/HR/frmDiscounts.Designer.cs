
namespace AccountingMS.Forms.HR
{
    partial class frmDiscounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscounts));
            this.discountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.date_ancestorDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.amountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.reasonTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.empIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForempID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFordate_ancestor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForamount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForreason = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colempID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ancestorDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ancestorDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordate_ancestor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // discountBindingSource
            // 
            this.discountBindingSource.DataSource = typeof(AccountingMS.Discount);
            // 
            // dataLayoutControl1
            // 
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.date_ancestorDateEdit);
            this.dataLayoutControl1.Controls.Add(this.amountTextEdit);
            this.dataLayoutControl1.Controls.Add(this.reasonTextEdit);
            this.dataLayoutControl1.Controls.Add(this.empIDTextEdit);
            this.dataLayoutControl1.DataSource = this.discountBindingSource;
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            // 
            // idTextEdit
            // 
            resources.ApplyResources(this.idTextEdit, "idTextEdit");
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.discountBindingSource, "id", true));
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.idTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.idTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("idTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.idTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.idTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // date_ancestorDateEdit
            // 
            resources.ApplyResources(this.date_ancestorDateEdit, "date_ancestorDateEdit");
            this.date_ancestorDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.discountBindingSource, "date_ancestor", true));
            this.date_ancestorDateEdit.Name = "date_ancestorDateEdit";
            this.date_ancestorDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.date_ancestorDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("date_ancestorDateEdit.Properties.Buttons"))))});
            this.date_ancestorDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("date_ancestorDateEdit.Properties.CalendarTimeProperties.Buttons"))))});
            this.date_ancestorDateEdit.StyleController = this.dataLayoutControl1;
            // 
            // amountTextEdit
            // 
            resources.ApplyResources(this.amountTextEdit, "amountTextEdit");
            this.amountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.discountBindingSource, "amount", true));
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
            this.reasonTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.discountBindingSource, "reason", true));
            this.reasonTextEdit.Name = "reasonTextEdit";
            this.reasonTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // empIDTextEdit
            // 
            resources.ApplyResources(this.empIDTextEdit, "empIDTextEdit");
            this.empIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.discountBindingSource, "empID", true));
            this.empIDTextEdit.Name = "empIDTextEdit";
            this.empIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.empIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.empIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("empIDTextEdit.Properties.Buttons"))))});
            this.empIDTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("empIDTextEdit.Properties.Columns"), resources.GetString("empIDTextEdit.Properties.Columns1"), ((int)(resources.GetObject("empIDTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("empIDTextEdit.Properties.Columns3"))), resources.GetString("empIDTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("empIDTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("empIDTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("empIDTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("empIDTextEdit.Properties.Columns8"))))});
            this.empIDTextEdit.Properties.DataSource = this.tblEmployeeBindingSource;
            this.empIDTextEdit.Properties.DisplayMember = "empName";
            this.empIDTextEdit.Properties.KeyMember = "id";
            this.empIDTextEdit.Properties.NullText = resources.GetString("empIDTextEdit.Properties.NullText");
            this.empIDTextEdit.Properties.ShowFooter = false;
            this.empIDTextEdit.Properties.ShowHeader = false;
            this.empIDTextEdit.Properties.ShowLines = false;
            this.empIDTextEdit.Properties.ValueMember = "id";
            this.empIDTextEdit.StyleController = this.dataLayoutControl1;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(296, 563);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForempID,
            this.ItemFordate_ancestor,
            this.ItemForamount,
            this.ItemForreason});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(276, 543);
            // 
            // ItemForid
            // 
            resources.ApplyResources(this.ItemForid, "ItemForid");
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(276, 24);
            this.ItemForid.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForempID
            // 
            resources.ApplyResources(this.ItemForempID, "ItemForempID");
            this.ItemForempID.Control = this.empIDTextEdit;
            this.ItemForempID.Location = new System.Drawing.Point(0, 24);
            this.ItemForempID.Name = "ItemForempID";
            this.ItemForempID.Size = new System.Drawing.Size(276, 24);
            this.ItemForempID.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemFordate_ancestor
            // 
            resources.ApplyResources(this.ItemFordate_ancestor, "ItemFordate_ancestor");
            this.ItemFordate_ancestor.Control = this.date_ancestorDateEdit;
            this.ItemFordate_ancestor.Location = new System.Drawing.Point(0, 48);
            this.ItemFordate_ancestor.Name = "ItemFordate_ancestor";
            this.ItemFordate_ancestor.Size = new System.Drawing.Size(276, 24);
            this.ItemFordate_ancestor.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForamount
            // 
            resources.ApplyResources(this.ItemForamount, "ItemForamount");
            this.ItemForamount.Control = this.amountTextEdit;
            this.ItemForamount.Location = new System.Drawing.Point(0, 72);
            this.ItemForamount.Name = "ItemForamount";
            this.ItemForamount.Size = new System.Drawing.Size(276, 24);
            this.ItemForamount.TextSize = new System.Drawing.Size(44, 14);
            // 
            // ItemForreason
            // 
            resources.ApplyResources(this.ItemForreason, "ItemForreason");
            this.ItemForreason.Control = this.reasonTextEdit;
            this.ItemForreason.Location = new System.Drawing.Point(0, 96);
            this.ItemForreason.Name = "ItemForreason";
            this.ItemForreason.Size = new System.Drawing.Size(276, 447);
            this.ItemForreason.TextSize = new System.Drawing.Size(44, 14);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.discountBindingSource;
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
            this.colempID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colempID
            // 
            resources.ApplyResources(this.colempID, "colempID");
            this.colempID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colempID.FieldName = "empID";
            this.colempID.Name = "colempID";
            this.colempID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
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
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ShowLines = false;
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // frmDiscounts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmDiscounts.IconOptions.Image")));
            this.Name = "frmDiscounts";
            this.Load += new System.EventHandler(this.frmDiscounts_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ancestorDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ancestorDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordate_ancestor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource discountBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraEditors.DateEdit date_ancestorDateEdit;
        private DevExpress.XtraEditors.TextEdit amountTextEdit;
        private DevExpress.XtraEditors.TextEdit reasonTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForempID;
        private DevExpress.XtraLayout.LayoutControlItem ItemFordate_ancestor;
        private DevExpress.XtraLayout.LayoutControlItem ItemForamount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForreason;
        private DevExpress.XtraGrid.Columns.GridColumn colempID;
        private DevExpress.XtraEditors.LookUpEdit empIDTextEdit;
        private System.Windows.Forms.BindingSource tblEmployeeBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}