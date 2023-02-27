namespace AccountingMS
{
    partial class UCprdExpirate
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblPrdExpirateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colexpId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSubMainId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSupSubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpSupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdPrcQuanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpPrdMsurStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexpStatus = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblPrdExpirateBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 136);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(933, 510);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblPrdExpirateBindingSource
            // 
            this.tblPrdExpirateBindingSource.DataSource = typeof(AccountingMS.tblPrdExpirate);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colexpId,
            this.colexpSubMainId,
            this.colexpSupSubId,
            this.colexpSupNo,
            this.colexpPrdId,
            this.colexpPrdMsurId,
            this.colexpQuan,
            this.colexpPrdPrcQuanId,
            this.colexpPrdDate,
            this.colexpDate,
            this.colexpPrdMsurStatus,
            this.colexpBrnId,
            this.colexpStatus});
            this.gridView.DetailHeight = 377;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colexpId
            // 
            this.colexpId.FieldName = "expId";
            this.colexpId.MinWidth = 23;
            this.colexpId.Name = "colexpId";
            this.colexpId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpId.Width = 87;
            // 
            // colexpSubMainId
            // 
            this.colexpSubMainId.FieldName = "expSubMainId";
            this.colexpSubMainId.MinWidth = 23;
            this.colexpSubMainId.Name = "colexpSubMainId";
            this.colexpSubMainId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpSubMainId.Width = 87;
            // 
            // colexpSupSubId
            // 
            this.colexpSupSubId.FieldName = "expSupSubId";
            this.colexpSupSubId.MinWidth = 23;
            this.colexpSupSubId.Name = "colexpSupSubId";
            this.colexpSupSubId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpSupSubId.Width = 87;
            // 
            // colexpSupNo
            // 
            this.colexpSupNo.AppearanceCell.Options.UseTextOptions = true;
            this.colexpSupNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpSupNo.Caption = "رقم الفاتورة";
            this.colexpSupNo.FieldName = "expSupNo";
            this.colexpSupNo.MinWidth = 23;
            this.colexpSupNo.Name = "colexpSupNo";
            this.colexpSupNo.Visible = true;
            this.colexpSupNo.VisibleIndex = 0;
            this.colexpSupNo.Width = 87;
            // 
            // colexpPrdId
            // 
            this.colexpPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdId.Caption = "الصنف";
            this.colexpPrdId.FieldName = "expPrdId";
            this.colexpPrdId.MinWidth = 23;
            this.colexpPrdId.Name = "colexpPrdId";
            this.colexpPrdId.Visible = true;
            this.colexpPrdId.VisibleIndex = 1;
            this.colexpPrdId.Width = 87;
            // 
            // colexpPrdMsurId
            // 
            this.colexpPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdMsurId.Caption = "وحدة القياس";
            this.colexpPrdMsurId.FieldName = "expPrdMsurId";
            this.colexpPrdMsurId.MinWidth = 23;
            this.colexpPrdMsurId.Name = "colexpPrdMsurId";
            this.colexpPrdMsurId.Visible = true;
            this.colexpPrdMsurId.VisibleIndex = 2;
            this.colexpPrdMsurId.Width = 87;
            // 
            // colexpQuan
            // 
            this.colexpQuan.AppearanceCell.Options.UseTextOptions = true;
            this.colexpQuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpQuan.Caption = "كمية الإنتهاء";
            this.colexpQuan.FieldName = "expQuan";
            this.colexpQuan.MinWidth = 23;
            this.colexpQuan.Name = "colexpQuan";
            this.colexpQuan.Visible = true;
            this.colexpQuan.VisibleIndex = 3;
            this.colexpQuan.Width = 87;
            // 
            // colexpPrdPrcQuanId
            // 
            this.colexpPrdPrcQuanId.AppearanceCell.Options.UseTextOptions = true;
            this.colexpPrdPrcQuanId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colexpPrdPrcQuanId.Caption = "الكمية المتبقية";
            this.colexpPrdPrcQuanId.FieldName = "expPrdPrcQuanId";
            this.colexpPrdPrcQuanId.MinWidth = 23;
            this.colexpPrdPrcQuanId.Name = "colexpPrdPrcQuanId";
            this.colexpPrdPrcQuanId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpPrdPrcQuanId.Visible = true;
            this.colexpPrdPrcQuanId.VisibleIndex = 4;
            this.colexpPrdPrcQuanId.Width = 87;
            // 
            // colexpPrdDate
            // 
            this.colexpPrdDate.Caption = "التاريخ";
            this.colexpPrdDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colexpPrdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colexpPrdDate.FieldName = "expPrdDate";
            this.colexpPrdDate.MinWidth = 23;
            this.colexpPrdDate.Name = "colexpPrdDate";
            this.colexpPrdDate.Visible = true;
            this.colexpPrdDate.VisibleIndex = 6;
            this.colexpPrdDate.Width = 87;
            // 
            // colexpDate
            // 
            this.colexpDate.Caption = "تاريخ الإنتهاء";
            this.colexpDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colexpDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colexpDate.FieldName = "expDate";
            this.colexpDate.MinWidth = 23;
            this.colexpDate.Name = "colexpDate";
            this.colexpDate.Visible = true;
            this.colexpDate.VisibleIndex = 5;
            this.colexpDate.Width = 87;
            // 
            // colexpPrdMsurStatus
            // 
            this.colexpPrdMsurStatus.FieldName = "expPrdMsurStatus";
            this.colexpPrdMsurStatus.MinWidth = 23;
            this.colexpPrdMsurStatus.Name = "colexpPrdMsurStatus";
            this.colexpPrdMsurStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpPrdMsurStatus.Width = 87;
            // 
            // colexpBrnId
            // 
            this.colexpBrnId.FieldName = "expBrnId";
            this.colexpBrnId.MinWidth = 23;
            this.colexpBrnId.Name = "colexpBrnId";
            this.colexpBrnId.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpBrnId.Width = 87;
            // 
            // colexpStatus
            // 
            this.colexpStatus.FieldName = "expStatus";
            this.colexpStatus.MinWidth = 23;
            this.colexpStatus.Name = "colexpStatus";
            this.colexpStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.colexpStatus.Width = 87;
            // 
            // ribbonControl
            // 
            //this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
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
            this.ribbonControl.OptionsMenuMinWidth = 385;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(933, 136);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
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
            this.ribbonPageGroup2.Text = "الطباعة والتصدير";
            this.ribbonPageGroup2.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 620);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(933, 26);
            // 
            // UCprdExpirate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCprdExpirate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(933, 646);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
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
        private System.Windows.Forms.BindingSource tblPrdExpirateBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colexpId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSubMainId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSupSubId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdPrcQuanId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdMsurStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colexpSupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colexpQuan;
        private DevExpress.XtraGrid.Columns.GridColumn colexpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colexpBrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colexpStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colexpPrdDate;
    }
}
