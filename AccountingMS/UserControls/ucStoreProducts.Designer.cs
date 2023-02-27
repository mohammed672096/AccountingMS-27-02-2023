namespace AccountingMS
{
    partial class ucStoreProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoreProducts));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecord = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewBatch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblProductQtyOpnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colqtyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdBarcodeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage")));
            this.ribbonControl1.ExpandCollapseItem.SearchTags = resources.GetString("ribbonControl1.ExpandCollapseItem.SearchTags");
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bsiRecord,
            this.bbiNew,
            this.bbiNewBatch,
            this.bbiEdit,
            this.bbiRefresh,
            this.bbiDelete});
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // bsiRecord
            // 
            resources.ApplyResources(this.bsiRecord, "bsiRecord");
            this.bsiRecord.Id = 1;
            this.bsiRecord.ImageOptions.ImageIndex = ((int)(resources.GetObject("bsiRecord.ImageOptions.ImageIndex")));
            this.bsiRecord.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bsiRecord.ImageOptions.LargeImageIndex")));
            this.bsiRecord.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiRecord.ImageOptions.SvgImage")));
            this.bsiRecord.Name = "bsiRecord";
            // 
            // bbiNew
            // 
            resources.ApplyResources(this.bbiNew, "bbiNew");
            this.bbiNew.Id = 2;
            this.bbiNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNew.ImageOptions.Image")));
            this.bbiNew.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiNew.ImageOptions.ImageIndex")));
            this.bbiNew.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.add_32x32;
            this.bbiNew.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiNew.ImageOptions.LargeImageIndex")));
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            this.bbiNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiNewBatch
            // 
            resources.ApplyResources(this.bbiNewBatch, "bbiNewBatch");
            this.bbiNewBatch.Id = 3;
            this.bbiNewBatch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNewBatch.ImageOptions.Image")));
            this.bbiNewBatch.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiNewBatch.ImageOptions.ImageIndex")));
            this.bbiNewBatch.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiNewBatch.ImageOptions.LargeImage")));
            this.bbiNewBatch.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiNewBatch.ImageOptions.LargeImageIndex")));
            this.bbiNewBatch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNewBatch.ImageOptions.SvgImage")));
            this.bbiNewBatch.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bbiNewBatch.Name = "bbiNewBatch";
            this.bbiNewBatch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNewBatch_ItemClick);
            // 
            // bbiEdit
            // 
            resources.ApplyResources(this.bbiEdit, "bbiEdit");
            this.bbiEdit.Id = 4;
            this.bbiEdit.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiEdit.ImageOptions.ImageIndex")));
            this.bbiEdit.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.edit_32x32;
            this.bbiEdit.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiEdit.ImageOptions.LargeImageIndex")));
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiRefresh
            // 
            resources.ApplyResources(this.bbiRefresh, "bbiRefresh");
            this.bbiRefresh.Id = 5;
            this.bbiRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.ImageIndex")));
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.LargeImageIndex")));
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            this.bbiRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiDelete
            // 
            resources.ApplyResources(this.bbiDelete, "bbiDelete");
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiDelete.ImageOptions.ImageIndex")));
            this.bbiDelete.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiDelete.ImageOptions.LargeImageIndex")));
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            this.bbiDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup,
            this.ribbonPageGroup1});
            this.mainRibbonPage.Name = "mainRibbonPage";
            resources.ApplyResources(this.mainRibbonPage, "mainRibbonPage");
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiEdit);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiRefresh);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            resources.ApplyResources(this.mainRibbonPageGroup, "mainRibbonPageGroup");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNewBatch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonStatusBar1
            // 
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiRecord);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.tblProductQtyOpnBindingSource;
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
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblProductQtyOpnBindingSource
            // 
            this.tblProductQtyOpnBindingSource.DataSource = typeof(AccountingMS.tblProductQtyOpn);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colqtyId,
            this.colprdBarcodeNo,
            this.colqtyPrdId,
            this.colqtyPrdMsurId,
            this.colqtyPrice,
            this.colqtyQuantity,
            this.colqtyDate,
            this.colqtyStatus});
            this.gridView1.DetailHeight = 377;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colqtyId
            // 
            resources.ApplyResources(this.colqtyId, "colqtyId");
            this.colqtyId.FieldName = "qtyId";
            this.colqtyId.MinWidth = 23;
            this.colqtyId.Name = "colqtyId";
            // 
            // colprdBarcodeNo
            // 
            resources.ApplyResources(this.colprdBarcodeNo, "colprdBarcodeNo");
            this.colprdBarcodeNo.FieldName = "prdBarcodeNo";
            this.colprdBarcodeNo.MinWidth = 23;
            this.colprdBarcodeNo.Name = "colprdBarcodeNo";
            // 
            // colqtyPrdId
            // 
            resources.ApplyResources(this.colqtyPrdId, "colqtyPrdId");
            this.colqtyPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrdId.FieldName = "qtyPrdId";
            this.colqtyPrdId.MinWidth = 23;
            this.colqtyPrdId.Name = "colqtyPrdId";
            // 
            // colqtyPrdMsurId
            // 
            resources.ApplyResources(this.colqtyPrdMsurId, "colqtyPrdMsurId");
            this.colqtyPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrdMsurId.FieldName = "qtyPrdMsurId";
            this.colqtyPrdMsurId.MinWidth = 23;
            this.colqtyPrdMsurId.Name = "colqtyPrdMsurId";
            // 
            // colqtyPrice
            // 
            resources.ApplyResources(this.colqtyPrice, "colqtyPrice");
            this.colqtyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrice.DisplayFormat.FormatString = "n2";
            this.colqtyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colqtyPrice.FieldName = "qtyPrice";
            this.colqtyPrice.MinWidth = 23;
            this.colqtyPrice.Name = "colqtyPrice";
            // 
            // colqtyQuantity
            // 
            resources.ApplyResources(this.colqtyQuantity, "colqtyQuantity");
            this.colqtyQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyQuantity.FieldName = "qtyQuantity";
            this.colqtyQuantity.MinWidth = 23;
            this.colqtyQuantity.Name = "colqtyQuantity";
            // 
            // colqtyDate
            // 
            resources.ApplyResources(this.colqtyDate, "colqtyDate");
            this.colqtyDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colqtyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colqtyDate.FieldName = "qtyDate";
            this.colqtyDate.MinWidth = 23;
            this.colqtyDate.Name = "colqtyDate";
            // 
            // colqtyStatus
            // 
            resources.ApplyResources(this.colqtyStatus, "colqtyStatus");
            this.colqtyStatus.FieldName = "qtyStatus";
            this.colqtyStatus.MinWidth = 23;
            this.colqtyStatus.Name = "colqtyStatus";
            // 
            // ucStoreProducts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ucStoreProducts";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarStaticItem bsiRecord;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiNewBatch;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private System.Windows.Forms.BindingSource tblProductQtyOpnBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyStatus;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colprdBarcodeNo;
    }
}
