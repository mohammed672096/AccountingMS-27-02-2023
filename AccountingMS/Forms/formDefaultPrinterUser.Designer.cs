namespace AccountingMS
{
    partial class formDefaultPrinterUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDefaultPrinterUser));
            this.dataLayoutControl4 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coluserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrinterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemLookUpEditPrinterName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup44 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.treeListName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Save = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl4)).BeginInit();
            this.dataLayoutControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLookUpEditPrinterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl4
            // 
            this.dataLayoutControl4.Controls.Add(this.gridControl1);
            this.dataLayoutControl4.DataSource = this.tblUserBindingSource;
            this.dataLayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl4.Location = new System.Drawing.Point(0, 134);
            this.dataLayoutControl4.Name = "dataLayoutControl4";
            this.dataLayoutControl4.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl4.Root = this.layoutControlGroup44;
            this.dataLayoutControl4.Size = new System.Drawing.Size(943, 665);
            this.dataLayoutControl4.TabIndex = 46;
            this.dataLayoutControl4.Text = "dataLayoutControl4";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblUserBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(24, 50);
            this.gridControl1.MainView = this.gridView;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemLookUpEditPrinterName});
            this.gridControl1.Size = new System.Drawing.Size(894, 590);
            this.gridControl1.TabIndex = 46;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblUserBindingSource
            // 
            this.tblUserBindingSource.DataSource = typeof(AccountingMS.tblUser);
            // 
            // gridView
            // 
            this.gridView.ColumnPanelRowHeight = 35;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coluserName,
            this.colPrinterName,
            this.colId});
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 35;
            // 
            // coluserName
            // 
            this.coluserName.Caption = "اسم المستخدم";
            this.coluserName.FieldName = "userName";
            this.coluserName.MinWidth = 25;
            this.coluserName.Name = "coluserName";
            this.coluserName.OptionsColumn.AllowEdit = false;
            this.coluserName.OptionsColumn.AllowFocus = false;
            this.coluserName.OptionsColumn.ReadOnly = true;
            this.coluserName.Visible = true;
            this.coluserName.VisibleIndex = 0;
            this.coluserName.Width = 94;
            // 
            // colPrinterName
            // 
            this.colPrinterName.Caption = "اسم الطابعة";
            this.colPrinterName.ColumnEdit = this.repItemLookUpEditPrinterName;
            this.colPrinterName.FieldName = "PrinterName";
            this.colPrinterName.MinWidth = 25;
            this.colPrinterName.Name = "colPrinterName";
            this.colPrinterName.Visible = true;
            this.colPrinterName.VisibleIndex = 1;
            this.colPrinterName.Width = 94;
            // 
            // repItemLookUpEditPrinterName
            // 
            this.repItemLookUpEditPrinterName.AutoHeight = false;
            this.repItemLookUpEditPrinterName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemLookUpEditPrinterName.Name = "repItemLookUpEditPrinterName";
            this.repItemLookUpEditPrinterName.NullText = "";
            // 
            // colId
            // 
            this.colId.Caption = "id";
            this.colId.FieldName = "id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 94;
            // 
            // layoutControlGroup44
            // 
            this.layoutControlGroup44.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup44.GroupBordersVisible = false;
            this.layoutControlGroup44.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup44.Name = "Root";
            this.layoutControlGroup44.Size = new System.Drawing.Size(943, 665);
            this.layoutControlGroup44.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(923, 645);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(898, 594);
            this.layoutControlGroup1.Text = "الطابعات الافتراضية للمستخدمين";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(898, 594);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // treeListName
            // 
            this.treeListName.Caption = "الحساب الرئيسي";
            this.treeListName.FieldName = "Name";
            this.treeListName.Name = "treeListName";
            this.treeListName.Visible = true;
            this.treeListName.VisibleIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "الرتبة";
            this.treeListColumn1.FieldName = "AccountLevel";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "الحساب الرئيسي";
            this.treeListColumn2.FieldName = "Name";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "الرتبة";
            this.treeListColumn3.FieldName = "AccountLevel";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // treeListName1
            // 
            this.treeListName1.Caption = "الحساب الرئيسي";
            this.treeListName1.FieldName = "Name";
            this.treeListName1.Name = "treeListName1";
            this.treeListName1.Visible = true;
            this.treeListName1.VisibleIndex = 0;
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "الرتبة";
            this.treeListColumn11.FieldName = "AccountLevel";
            this.treeListColumn11.Name = "treeListColumn11";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupsBorderMode = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.Save,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(943, 134);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // Save
            // 
            this.Save.Caption = "حفظ";
            this.Save.Id = 1;
            this.Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Save.ImageOptions.SvgImage")));
            this.Save.LargeWidth = 70;
            this.Save.Name = "Save";
            this.Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Save_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "اغلاق";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.LargeWidth = 70;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.Save);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 799);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(943, 27);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // formDefaultPrinterUser
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 826);
            this.Controls.Add(this.dataLayoutControl4);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formDefaultPrinterUser";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "الطابعات الافتراضية للمستخدمين";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl4)).EndInit();
            this.dataLayoutControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLookUpEditPrinterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup44;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblUserBindingSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn coluserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrinterName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListName1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem Save;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemLookUpEditPrinterName;
    }
}