namespace AccountingMS
{
    partial class UCrepresentative
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCrepresentative));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblRepresentativeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrepValuRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRepresentativeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblRepresentativeBindingSource;
            resources.ApplyResources(this.gridControl, "gridControl");
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblRepresentativeBindingSource
            // 
            this.tblRepresentativeBindingSource.DataSource = typeof(AccountingMS.tblRepresentative);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView.Appearance.HeaderPanel.Font")));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colrepNo,
            this.colrepName,
            this.colrepAccNo,
            this.colrepPhnNo,
            this.colrepCurrency,
            this.colrepAddress,
            this.colrepEmail,
            this.colrepBrnId,
            this.colrepStatus,
            this.colrepRate,
            this.colrepValuRate});
            this.gridView.DetailHeight = 377;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.MinWidth = 23;
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.colid, "colid");
            // 
            // colrepNo
            // 
            this.colrepNo.AppearanceCell.Options.UseTextOptions = true;
            this.colrepNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colrepNo, "colrepNo");
            this.colrepNo.FieldName = "repNo";
            this.colrepNo.MinWidth = 23;
            this.colrepNo.Name = "colrepNo";
            // 
            // colrepName
            // 
            resources.ApplyResources(this.colrepName, "colrepName");
            this.colrepName.FieldName = "repName";
            this.colrepName.MinWidth = 23;
            this.colrepName.Name = "colrepName";
            // 
            // colrepAccNo
            // 
            this.colrepAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colrepAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colrepAccNo, "colrepAccNo");
            this.colrepAccNo.FieldName = "repAccNo";
            this.colrepAccNo.MinWidth = 23;
            this.colrepAccNo.Name = "colrepAccNo";
            // 
            // colrepPhnNo
            // 
            resources.ApplyResources(this.colrepPhnNo, "colrepPhnNo");
            this.colrepPhnNo.FieldName = "repPhnNo";
            this.colrepPhnNo.MinWidth = 23;
            this.colrepPhnNo.Name = "colrepPhnNo";
            // 
            // colrepCurrency
            // 
            this.colrepCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colrepCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colrepCurrency, "colrepCurrency");
            this.colrepCurrency.FieldName = "repCurrency";
            this.colrepCurrency.MinWidth = 23;
            this.colrepCurrency.Name = "colrepCurrency";
            // 
            // colrepAddress
            // 
            resources.ApplyResources(this.colrepAddress, "colrepAddress");
            this.colrepAddress.FieldName = "repAddress";
            this.colrepAddress.MinWidth = 23;
            this.colrepAddress.Name = "colrepAddress";
            // 
            // colrepEmail
            // 
            resources.ApplyResources(this.colrepEmail, "colrepEmail");
            this.colrepEmail.FieldName = "repEmail";
            this.colrepEmail.MinWidth = 23;
            this.colrepEmail.Name = "colrepEmail";
            // 
            // colrepBrnId
            // 
            this.colrepBrnId.FieldName = "repBrnId";
            this.colrepBrnId.MinWidth = 23;
            this.colrepBrnId.Name = "colrepBrnId";
            this.colrepBrnId.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.colrepBrnId, "colrepBrnId");
            // 
            // colrepStatus
            // 
            this.colrepStatus.FieldName = "repStatus";
            this.colrepStatus.MinWidth = 23;
            this.colrepStatus.Name = "colrepStatus";
            this.colrepStatus.OptionsColumn.ShowInCustomizationForm = false;
            resources.ApplyResources(this.colrepStatus, "colrepStatus");
            // 
            // colrepRate
            // 
            resources.ApplyResources(this.colrepRate, "colrepRate");
            this.colrepRate.FieldName = "repRate";
            this.colrepRate.Name = "colrepRate";
            // 
            // colrepValuRate
            // 
            resources.ApplyResources(this.colrepValuRate, "colrepValuRate");
            this.colrepValuRate.FieldName = "repValuRate";
            this.colrepValuRate.Name = "colrepValuRate";
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
            this.bbiRefresh,
            this.barButtonItem1,
            this.barButtonItem2});
            resources.ApplyResources(this.ribbonControl, "ribbonControl");
            this.ribbonControl.MaxItemId = 22;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 385;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            resources.ApplyResources(this.bbiPrintPreview, "bbiPrintPreview");
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            resources.ApplyResources(this.bsiRecordsCount, "bsiRecordsCount");
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            resources.ApplyResources(this.bbiNew, "bbiNew");
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_add;
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            resources.ApplyResources(this.bbiEdit, "bbiEdit");
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.actions_edit;
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            resources.ApplyResources(this.bbiDelete, "bbiDelete");
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            resources.ApplyResources(this.bbiRefresh, "bbiRefresh");
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.changeview;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 21;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
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
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            resources.ApplyResources(this.ribbonPageGroup2, "ribbonPageGroup2");
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            resources.ApplyResources(this.ribbonPageGroup3, "ribbonPageGroup3");
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            resources.ApplyResources(this.ribbonPageGroup4, "ribbonPageGroup4");
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            // 
            // UCrepresentative
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCrepresentative";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRepresentativeBindingSource)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colrepNo;
        private DevExpress.XtraGrid.Columns.GridColumn colrepName;
        private DevExpress.XtraGrid.Columns.GridColumn colrepAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colrepPhnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colrepAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colrepEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colrepBrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colrepStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colrepCurrency;
        private System.Windows.Forms.BindingSource tblRepresentativeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colrepRate;
        private DevExpress.XtraGrid.Columns.GridColumn colrepValuRate;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}
