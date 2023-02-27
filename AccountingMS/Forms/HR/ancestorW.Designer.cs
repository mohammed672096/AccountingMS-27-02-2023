
namespace AccountingMS.Forms.HR
{
    partial class ancestorW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ancestorW));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ancestorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateAncestorDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.amountTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.reasonTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.empIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFordateAncestor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForamount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForreason = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForempID = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colempID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ancestorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            resources.ApplyResources(this.dataLayoutControl1, "dataLayoutControl1");
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.dateAncestorDateEdit);
            this.dataLayoutControl1.Controls.Add(this.amountTextEdit);
            this.dataLayoutControl1.Controls.Add(this.reasonTextEdit);
            this.dataLayoutControl1.Controls.Add(this.empIDTextEdit);
            this.dataLayoutControl1.DataSource = this.ancestorBindingSource;
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            // 
            // idTextEdit
            // 
            resources.ApplyResources(this.idTextEdit, "idTextEdit");
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ancestorBindingSource, "id", true));
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.idTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.idTextEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("idTextEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.idTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.idTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // ancestorBindingSource
            // 
            this.ancestorBindingSource.DataSource = typeof(AccountingMS.ancestor);
            // 
            // dateAncestorDateEdit
            // 
            resources.ApplyResources(this.dateAncestorDateEdit, "dateAncestorDateEdit");
            this.dateAncestorDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ancestorBindingSource, "dateAncestor", true));
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
            this.amountTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ancestorBindingSource, "amount", true));
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
            this.reasonTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ancestorBindingSource, "reason", true));
            this.reasonTextEdit.Name = "reasonTextEdit";
            this.reasonTextEdit.StyleController = this.dataLayoutControl1;
            // 
            // empIDTextEdit
            // 
            resources.ApplyResources(this.empIDTextEdit, "empIDTextEdit");
            this.empIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ancestorBindingSource, "empID", true));
            this.empIDTextEdit.Name = "empIDTextEdit";
            this.empIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.empIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.empIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("empIDTextEdit.Properties.Buttons"))))});
            this.empIDTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("empIDTextEdit.Properties.Columns"), resources.GetString("empIDTextEdit.Properties.Columns1"), ((int)(resources.GetObject("empIDTextEdit.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("empIDTextEdit.Properties.Columns3"))), resources.GetString("empIDTextEdit.Properties.Columns4"), ((bool)(resources.GetObject("empIDTextEdit.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("empIDTextEdit.Properties.Columns6"))), ((DevExpress.Data.ColumnSortOrder)(resources.GetObject("empIDTextEdit.Properties.Columns7"))), ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("empIDTextEdit.Properties.Columns8"))))});
            this.empIDTextEdit.Properties.DataSource = this.tblEmployeeBindingSource;
            this.empIDTextEdit.Properties.DisplayMember = "empName";
            this.empIDTextEdit.Properties.NullText = resources.GetString("empIDTextEdit.Properties.NullText");
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(352, 563);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemFordateAncestor,
            this.ItemForamount,
            this.ItemForreason,
            this.ItemForempID});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(332, 543);
            // 
            // ItemForid
            // 
            resources.ApplyResources(this.ItemForid, "ItemForid");
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(332, 24);
            this.ItemForid.TextSize = new System.Drawing.Size(42, 14);
            // 
            // ItemFordateAncestor
            // 
            resources.ApplyResources(this.ItemFordateAncestor, "ItemFordateAncestor");
            this.ItemFordateAncestor.Control = this.dateAncestorDateEdit;
            this.ItemFordateAncestor.Location = new System.Drawing.Point(0, 48);
            this.ItemFordateAncestor.Name = "ItemFordateAncestor";
            this.ItemFordateAncestor.Size = new System.Drawing.Size(332, 24);
            this.ItemFordateAncestor.TextSize = new System.Drawing.Size(42, 14);
            // 
            // ItemForamount
            // 
            resources.ApplyResources(this.ItemForamount, "ItemForamount");
            this.ItemForamount.Control = this.amountTextEdit;
            this.ItemForamount.Location = new System.Drawing.Point(0, 72);
            this.ItemForamount.Name = "ItemForamount";
            this.ItemForamount.Size = new System.Drawing.Size(332, 24);
            this.ItemForamount.TextSize = new System.Drawing.Size(42, 14);
            // 
            // ItemForreason
            // 
            resources.ApplyResources(this.ItemForreason, "ItemForreason");
            this.ItemForreason.Control = this.reasonTextEdit;
            this.ItemForreason.Location = new System.Drawing.Point(0, 96);
            this.ItemForreason.Name = "ItemForreason";
            this.ItemForreason.Size = new System.Drawing.Size(332, 447);
            this.ItemForreason.TextSize = new System.Drawing.Size(42, 14);
            // 
            // ItemForempID
            // 
            resources.ApplyResources(this.ItemForempID, "ItemForempID");
            this.ItemForempID.Control = this.empIDTextEdit;
            this.ItemForempID.Location = new System.Drawing.Point(0, 24);
            this.ItemForempID.Name = "ItemForempID";
            this.ItemForempID.Size = new System.Drawing.Size(332, 24);
            this.ItemForempID.TextSize = new System.Drawing.Size(42, 14);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.ancestorBindingSource;
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colempID
            // 
            resources.ApplyResources(this.colempID, "colempID");
            this.colempID.FieldName = "empID";
            this.colempID.Name = "colempID";
            this.colempID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // ancestorW
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ancestorW.IconOptions.Image")));
            this.Name = "ancestorW";
            this.Load += new System.EventHandler(this.ancestorW_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ancestorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource ancestorBindingSource;
        private DevExpress.XtraEditors.DateEdit dateAncestorDateEdit;
        private DevExpress.XtraEditors.TextEdit amountTextEdit;
        private DevExpress.XtraEditors.TextEdit reasonTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemFordateAncestor;
        private DevExpress.XtraLayout.LayoutControlItem ItemForamount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForreason;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colempID;
        private System.Windows.Forms.BindingSource tblEmployeeBindingSource;
        private DevExpress.XtraEditors.LookUpEdit empIDTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForempID;
    }
}