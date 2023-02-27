namespace AccountingMS
{
    partial class UCprdExpirateQuan
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colexpPrdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblPrdexpirateQuanMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colexpMainDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpMainId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpMainStrid = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tblPrdExpirateQuanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdexpirateQuanMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateQuanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colexpPrdNo,
            this.colexpPrdId,
            this.colexpPrdMsurId,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.DetailHeight = 485;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colexpPrdNo
            // 
            this.colexpPrdNo.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdNo.Caption = "رقم الصنف";
            this.colexpPrdNo.FieldName = "expPrdId";
            this.colexpPrdNo.MinWidth = 25;
            this.colexpPrdNo.Name = "colexpPrdNo";
            this.colexpPrdNo.Visible = true;
            this.colexpPrdNo.VisibleIndex = 0;
            this.colexpPrdNo.Width = 94;
            // 
            // colexpPrdId
            // 
            this.colexpPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdId.Caption = "الصنف";
            this.colexpPrdId.FieldName = "expPrdId";
            this.colexpPrdId.MinWidth = 27;
            this.colexpPrdId.Name = "colexpPrdId";
            this.colexpPrdId.Visible = true;
            this.colexpPrdId.VisibleIndex = 1;
            this.colexpPrdId.Width = 100;
            // 
            // colexpPrdMsurId
            // 
            this.colexpPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdMsurId.Caption = "الوحدة";
            this.colexpPrdMsurId.FieldName = "expPrdMsurId";
            this.colexpPrdMsurId.MinWidth = 27;
            this.colexpPrdMsurId.Name = "colexpPrdMsurId";
            this.colexpPrdMsurId.Visible = true;
            this.colexpPrdMsurId.VisibleIndex = 2;
            this.colexpPrdMsurId.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn5.Caption = "تكلفة الصنف";
            this.gridColumn5.FieldName = "expPrdPrice";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.Caption = "الكمية المتلفة";
            this.gridColumn3.FieldName = "expQuan";
            this.gridColumn3.MinWidth = 27;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn4.Caption = "تاريخ الانتهاء";
            this.gridColumn4.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "expPrdDate";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 94;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblPrdexpirateQuanMainBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 170);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1067, 661);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colexpMainDate,
            this.colexpBrnId,
            this.colexpMainId,
            this.colexpMainStrid});
            this.gridView.DetailHeight = 485;
            this.gridView.FixedLineWidth = 1;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colexpMainDate
            // 
            this.colexpMainDate.AppearanceCell.Options.UseTextOptions = true;
            this.colexpMainDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpMainDate.Caption = "التاريخ";
            this.colexpMainDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colexpMainDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colexpMainDate.FieldName = "expMainDate";
            this.colexpMainDate.MinWidth = 27;
            this.colexpMainDate.Name = "colexpMainDate";
            this.colexpMainDate.Visible = true;
            this.colexpMainDate.VisibleIndex = 2;
            this.colexpMainDate.Width = 100;
            // 
            // colexpBrnId
            // 
            this.colexpBrnId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpBrnId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpBrnId.FieldName = "expMainBrnId";
            this.colexpBrnId.MinWidth = 27;
            this.colexpBrnId.Name = "colexpBrnId";
            this.colexpBrnId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpBrnId.Width = 100;
            // 
            // colexpMainId
            // 
            this.colexpMainId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpMainId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpMainId.Caption = "الرقم";
            this.colexpMainId.FieldName = "expMainId";
            this.colexpMainId.MinWidth = 27;
            this.colexpMainId.Name = "colexpMainId";
            this.colexpMainId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpMainId.Visible = true;
            this.colexpMainId.VisibleIndex = 0;
            this.colexpMainId.Width = 100;
            // 
            // colexpMainStrid
            // 
            this.colexpMainStrid.AppearanceCell.Options.UseTextOptions = true;
            this.colexpMainStrid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpMainStrid.Caption = "المخزن";
            this.colexpMainStrid.FieldName = "expMainStrid";
            this.colexpMainStrid.MinWidth = 25;
            this.colexpMainStrid.Name = "colexpMainStrid";
            this.colexpMainStrid.Visible = true;
            this.colexpMainStrid.VisibleIndex = 1;
            this.colexpMainStrid.Width = 100;
            // 
            // ribbonControl
            // 
            //this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 42, 40, 42);
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
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 440;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1067, 170);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.print;
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
            this.bbiNew.Caption = "جديد";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_add;
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "تعديل";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_edit;
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.del;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.changeview;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
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
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "الطباعه والتصدير";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 799);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1067, 32);
            // 
            // UCprdExpirateQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCprdExpirateQuan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1067, 831);
            this.Load += new System.EventHandler(this.UCprdExpirateQuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdexpirateQuanMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateQuanBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tblPrdExpirateQuanBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colexpMainDate;
        private DevExpress.XtraGrid.Columns.GridColumn colexpBrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpMainId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpMainStrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.BindingSource tblPrdexpirateQuanMainBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdNo;
        protected internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}
