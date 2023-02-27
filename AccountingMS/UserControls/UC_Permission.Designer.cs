using System.Windows.Forms;

namespace AccountingMS
{
    partial class UC_Permission
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Permission));
            this.userSettingsProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tblAllUserControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCaptionEn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).BeginInit();
            this.dataLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAllUserControlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayout
            // 
            resources.ApplyResources(this.dataLayout, "dataLayout");
            this.dataLayout.Appearance.Control.Options.UseTextOptions = true;
            this.dataLayout.Appearance.Control.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.dataLayout.Controls.Add(this.treeList1);
            this.dataLayout.Name = "dataLayout";
            this.dataLayout.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayout.Root = this.Root;
            // 
            // treeList1
            // 
            resources.ApplyResources(this.treeList1, "treeList1");
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colParentID,
            this.colName,
            this.colCaption,
            this.colCaptionEn});
            this.treeList1.DataSource = this.tblAllUserControlBindingSource;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsFind.ExpandNodesOnIncrementalSearch = true;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Large;
            this.treeList1.Load += new System.EventHandler(this.treeList1_Load);
            // 
            // treeListName
            // 
            resources.ApplyResources(this.treeListName, "treeListName");
            this.treeListName.FieldName = "Name";
            this.treeListName.Name = "treeListName";
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 5, 10);
            this.Root.Size = new System.Drawing.Size(1383, 662);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1363, 647);
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.AppearanceGroup.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.layoutControlGroup2.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1363, 647);
            // 
            // layoutControlItem1
            // 
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Control = this.treeList1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1339, 598);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // tblAllUserControlBindingSource
            // 
            //this.tblAllUserControlBindingSource.DataSource = typeof(AccountingMS.tblAllUserControl);
            // 
            // colID
            // 
            resources.ApplyResources(this.colID, "colID");
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colParentID
            // 
            resources.ApplyResources(this.colParentID, "colParentID");
            this.colParentID.FieldName = "ParentID";
            this.colParentID.Name = "colParentID";
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colCaption
            // 
            resources.ApplyResources(this.colCaption, "colCaption");
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            // 
            // colCaptionEn
            // 
            resources.ApplyResources(this.colCaptionEn, "colCaptionEn");
            this.colCaptionEn.FieldName = "CaptionEn";
            this.colCaptionEn.Name = "colCaptionEn";
            // 
            // UC_Permission
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayout);
            this.Name = "UC_Permission";
            this.Load += new System.EventHandler(this.UC_Master_Load);
            this.Controls.SetChildIndex(this.dataLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.userSettingsProfileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayout)).EndInit();
            this.dataLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAllUserControlBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource userSettingsProfileBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayout;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCaptionEn;
        private BindingSource tblAllUserControlBindingSource;
    }
}
