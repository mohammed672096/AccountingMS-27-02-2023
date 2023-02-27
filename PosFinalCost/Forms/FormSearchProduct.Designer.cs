namespace PosFinalCost.Forms
{
    partial class FormSearchProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchProduct));
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlSrchPrd = new DevExpress.XtraGrid.GridControl();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewSrchPrd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colprdId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrdSalePrice2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNameEng2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdGrpNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemButEditSelectPro = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.BtnClosSearchPro = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSrchPrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSrchPrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemButEditSelectPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.gridControlSrchPrd);
            this.layoutControl3.Controls.Add(this.BtnClosSearchPro);
            resources.ApplyResources(this.layoutControl3, "layoutControl3");
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl3.Root = this.Root;
            // 
            // gridControlSrchPrd
            // 
            this.gridControlSrchPrd.DataSource = this.productBindingSource;
            this.gridControlSrchPrd.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControlSrchPrd.EmbeddedNavigator.Margin")));
            resources.ApplyResources(this.gridControlSrchPrd, "gridControlSrchPrd");
            this.gridControlSrchPrd.MainView = this.gridViewSrchPrd;
            this.gridControlSrchPrd.Name = "gridControlSrchPrd";
            this.gridControlSrchPrd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemButEditSelectPro});
            this.gridControlSrchPrd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSrchPrd});
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(PosFinalCost.Product);
            // 
            // gridViewSrchPrd
            // 
            this.gridViewSrchPrd.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridViewSrchPrd.Appearance.HeaderPanel.Font")));
            this.gridViewSrchPrd.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewSrchPrd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colprdId2,
            this.colprdNo2,
            this.colprdName2,
            this.colPrdSalePrice2,
            this.colprdNameEng2,
            this.colprdGrpNo2,
            this.gridColumn1});
            this.gridViewSrchPrd.DetailHeight = 624;
            this.gridViewSrchPrd.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewSrchPrd.GridControl = this.gridControlSrchPrd;
            this.gridViewSrchPrd.Name = "gridViewSrchPrd";
            this.gridViewSrchPrd.OptionsFind.AlwaysVisible = true;
            this.gridViewSrchPrd.OptionsFind.FindNullPrompt = "...ادخل نص للبحث";
            this.gridViewSrchPrd.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewSrchPrd.OptionsView.ShowIndicator = false;
            // 
            // colprdId2
            // 
            this.colprdId2.FieldName = "ID";
            this.colprdId2.MinWidth = 30;
            this.colprdId2.Name = "colprdId2";
            this.colprdId2.OptionsColumn.AllowEdit = false;
            resources.ApplyResources(this.colprdId2, "colprdId2");
            // 
            // colprdNo2
            // 
            resources.ApplyResources(this.colprdNo2, "colprdNo2");
            this.colprdNo2.FieldName = "No";
            this.colprdNo2.MaxWidth = 229;
            this.colprdNo2.MinWidth = 30;
            this.colprdNo2.Name = "colprdNo2";
            this.colprdNo2.OptionsColumn.AllowEdit = false;
            // 
            // colprdName2
            // 
            resources.ApplyResources(this.colprdName2, "colprdName2");
            this.colprdName2.FieldName = "Name";
            this.colprdName2.MinWidth = 30;
            this.colprdName2.Name = "colprdName2";
            this.colprdName2.OptionsColumn.AllowEdit = false;
            // 
            // colPrdSalePrice2
            // 
            this.colPrdSalePrice2.AppearanceCell.Options.UseTextOptions = true;
            this.colPrdSalePrice2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colPrdSalePrice2, "colPrdSalePrice2");
            this.colPrdSalePrice2.DisplayFormat.FormatString = "n2";
            this.colPrdSalePrice2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrdSalePrice2.FieldName = "colPrdSalePrice";
            this.colPrdSalePrice2.MaxWidth = 304;
            this.colPrdSalePrice2.MinWidth = 30;
            this.colPrdSalePrice2.Name = "colPrdSalePrice2";
            this.colPrdSalePrice2.OptionsColumn.AllowEdit = false;
            this.colPrdSalePrice2.OptionsColumn.AllowIncrementalSearch = false;
            this.colPrdSalePrice2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colprdNameEng2
            // 
            this.colprdNameEng2.FieldName = "NameEng";
            this.colprdNameEng2.MinWidth = 30;
            this.colprdNameEng2.Name = "colprdNameEng2";
            this.colprdNameEng2.OptionsColumn.AllowEdit = false;
            resources.ApplyResources(this.colprdNameEng2, "colprdNameEng2");
            // 
            // colprdGrpNo2
            // 
            this.colprdGrpNo2.FieldName = "GrpNo";
            this.colprdGrpNo2.MinWidth = 30;
            this.colprdGrpNo2.Name = "colprdGrpNo2";
            this.colprdGrpNo2.OptionsColumn.AllowEdit = false;
            resources.ApplyResources(this.colprdGrpNo2, "colprdGrpNo2");
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.ColumnEdit = this.repItemButEditSelectPro;
            this.gridColumn1.MinWidth = 29;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // repItemButEditSelectPro
            // 
            this.repItemButEditSelectPro.AllowFocused = false;
            resources.ApplyResources(this.repItemButEditSelectPro, "repItemButEditSelectPro");
            this.repItemButEditSelectPro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repItemButEditSelectPro.Buttons"))))});
            this.repItemButEditSelectPro.Name = "repItemButEditSelectPro";
            this.repItemButEditSelectPro.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // BtnClosSearchPro
            // 
            this.BtnClosSearchPro.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("BtnClosSearchPro.Appearance.Font")));
            this.BtnClosSearchPro.Appearance.Options.UseFont = true;
            this.BtnClosSearchPro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnClosSearchPro.ImageOptions.SvgImage")));
            resources.ApplyResources(this.BtnClosSearchPro, "BtnClosSearchPro");
            this.BtnClosSearchPro.Name = "BtnClosSearchPro";
            this.BtnClosSearchPro.StyleController = this.layoutControl3;
            this.BtnClosSearchPro.Click += new System.EventHandler(this.BtnClosSearchPro_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem16,
            this.emptySpaceItem4});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 0, 13);
            this.Root.Size = new System.Drawing.Size(783, 496);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.gridControlSrchPrd;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(777, 435);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.BtnClosSearchPro;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 435);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(163, 48);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(163, 435);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(614, 48);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormSearchProduct
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchProduct";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSrchPrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSrchPrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemButEditSelectPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colprdId2;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNo2;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName2;
        private DevExpress.XtraGrid.Columns.GridColumn colPrdSalePrice2;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNameEng2;
        private DevExpress.XtraGrid.Columns.GridColumn colprdGrpNo2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton BtnClosSearchPro;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        public DevExpress.XtraGrid.GridControl gridControlSrchPrd;
        public DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repItemButEditSelectPro;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewSrchPrd;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}