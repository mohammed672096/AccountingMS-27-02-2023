namespace AccountingMS
{
    partial class UCstockTrans
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCstockTrans));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colstcPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblStockTransMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colstcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcStrIdFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcStrIdTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstcUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStockTransMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colstcPrdId,
            this.colstcMsurId,
            this.colstcQuantity});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colstcPrdId
            // 
            this.colstcPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colstcPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcPrdId.Caption = "الصنف";
            this.colstcPrdId.FieldName = "stcPrdId";
            this.colstcPrdId.Name = "colstcPrdId";
            this.colstcPrdId.Visible = true;
            this.colstcPrdId.VisibleIndex = 0;
            // 
            // colstcMsurId
            // 
            this.colstcMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colstcMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcMsurId.Caption = "الوحدة";
            this.colstcMsurId.FieldName = "stcMsurId";
            this.colstcMsurId.Name = "colstcMsurId";
            this.colstcMsurId.Visible = true;
            this.colstcMsurId.VisibleIndex = 1;
            // 
            // colstcQuantity
            // 
            this.colstcQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colstcQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcQuantity.Caption = "الكمية";
            this.colstcQuantity.FieldName = "stcQuantity";
            this.colstcQuantity.Name = "colstcQuantity";
            this.colstcQuantity.Visible = true;
            this.colstcQuantity.VisibleIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblStockTransMainBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 132);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 268);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // tblStockTransMainBindingSource
            // 
            this.tblStockTransMainBindingSource.DataSource = typeof(tblStockTransMain);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colstcId,
            this.colstcNo,
            this.colstcRefNo,
            this.colstcStrIdFrom,
            this.colstcStrIdTo,
            this.colstcDesc,
            this.colstcDate,
            this.colstcBrnId,
            this.colstcUserId});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colstcId
            // 
            this.colstcId.FieldName = "stcId";
            this.colstcId.Name = "colstcId";
            this.colstcId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colstcNo
            // 
            this.colstcNo.AppearanceCell.Options.UseTextOptions = true;
            this.colstcNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcNo.Caption = "رقم التحويل";
            this.colstcNo.FieldName = "stcNo";
            this.colstcNo.Name = "colstcNo";
            this.colstcNo.Visible = true;
            this.colstcNo.VisibleIndex = 0;
            // 
            // colstcRefNo
            // 
            this.colstcRefNo.FieldName = "stcRefNo";
            this.colstcRefNo.Name = "colstcRefNo";
            // 
            // colstcStrIdFrom
            // 
            this.colstcStrIdFrom.AppearanceCell.Options.UseTextOptions = true;
            this.colstcStrIdFrom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcStrIdFrom.Caption = "من مخزن";
            this.colstcStrIdFrom.FieldName = "stcStrIdFrom";
            this.colstcStrIdFrom.Name = "colstcStrIdFrom";
            this.colstcStrIdFrom.Visible = true;
            this.colstcStrIdFrom.VisibleIndex = 1;
            // 
            // colstcStrIdTo
            // 
            this.colstcStrIdTo.AppearanceCell.Options.UseTextOptions = true;
            this.colstcStrIdTo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colstcStrIdTo.Caption = "إلى مخزن";
            this.colstcStrIdTo.FieldName = "stcStrIdTo";
            this.colstcStrIdTo.Name = "colstcStrIdTo";
            this.colstcStrIdTo.Visible = true;
            this.colstcStrIdTo.VisibleIndex = 2;
            // 
            // colstcDesc
            // 
            this.colstcDesc.Caption = "البيان";
            this.colstcDesc.FieldName = "stcDesc";
            this.colstcDesc.Name = "colstcDesc";
            this.colstcDesc.Visible = true;
            this.colstcDesc.VisibleIndex = 3;
            // 
            // colstcDate
            // 
            this.colstcDate.Caption = "التاريخ";
            this.colstcDate.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
            this.colstcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colstcDate.FieldName = "stcDate";
            this.colstcDate.Name = "colstcDate";
            this.colstcDate.Visible = true;
            this.colstcDate.VisibleIndex = 4;
            // 
            // colstcBrnId
            // 
            this.colstcBrnId.FieldName = "stcBrnId";
            this.colstcBrnId.Name = "colstcBrnId";
            this.colstcBrnId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colstcUserId
            // 
            this.colstcUserId.FieldName = "stcUserId";
            this.colstcUserId.Name = "colstcUserId";
            this.colstcUserId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(800, 132);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة الفاتورة\r\nF7";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            this.bbiPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "تحويل مخزني\r\nF2";
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
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف\r\nF4";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            this.bbiDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث\r\nF5";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            this.bbiRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRefresh_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "الطباعة والتصدير";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 374);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(800, 26);
            // 
            // UCstockTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCstockTrans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(800, 400);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStockTransMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource tblStockTransMainBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colstcPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colstcMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colstcQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colstcId;
        private DevExpress.XtraGrid.Columns.GridColumn colstcNo;
        private DevExpress.XtraGrid.Columns.GridColumn colstcRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colstcStrIdFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colstcStrIdTo;
        private DevExpress.XtraGrid.Columns.GridColumn colstcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colstcDate;
        private DevExpress.XtraGrid.Columns.GridColumn colstcBrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colstcUserId;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}
