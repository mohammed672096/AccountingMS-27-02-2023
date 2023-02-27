namespace AccountingMS
{
    partial class UCDashboardEF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDashboardEF));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.BarGrowUpAnimation barGrowUpAnimation1 = new DevExpress.XtraCharts.BarGrowUpAnimation();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.tblAssetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiBackupData = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ReCalculatCostInSales = new DevExpress.XtraBars.BarButtonItem();
            this.barFromDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barToDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ribbonPageMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblAssetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tblAssetBindingSource
            // 
            this.tblAssetBindingSource.DataSource = typeof(AccountingMS.tblAsset);
            // 
            // ribbonControl1
            // 
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 39, 34, 39);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage")));
            this.ribbonControl1.ExpandCollapseItem.SearchTags = resources.GetString("ribbonControl1.ExpandCollapseItem.SearchTags");
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiBackupData,
            this.bbiRefresh,
            this.barButtonItem1,
            this.ReCalculatCostInSales,
            this.barFromDate,
            this.barToDate});
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 377;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageMain});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiBackupData
            // 
            resources.ApplyResources(this.bbiBackupData, "bbiBackupData");
            this.bbiBackupData.Id = 1;
            this.bbiBackupData.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiBackupData.ImageOptions.ImageIndex")));
            this.bbiBackupData.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiBackupData.ImageOptions.LargeImageIndex")));
            this.bbiBackupData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiBackupData.ImageOptions.SvgImage")));
            this.bbiBackupData.Name = "bbiBackupData";
            this.bbiBackupData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiBackupData_ItemClick);
            // 
            // bbiRefresh
            // 
            resources.ApplyResources(this.bbiRefresh, "bbiRefresh");
            this.bbiRefresh.Id = 2;
            this.bbiRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.ImageIndex")));
            this.bbiRefresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.LargeImageIndex")));
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRefresh_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.ImageIndex")));
            this.barButtonItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.LargeImageIndex")));
            this.barButtonItem1.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.update;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ReCalculatCostInSales
            // 
            resources.ApplyResources(this.ReCalculatCostInSales, "ReCalculatCostInSales");
            this.ReCalculatCostInSales.Id = 4;
            this.ReCalculatCostInSales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ReCalculatCostInSales.ImageOptions.Image")));
            this.ReCalculatCostInSales.ImageOptions.ImageIndex = ((int)(resources.GetObject("ReCalculatCostInSales.ImageOptions.ImageIndex")));
            this.ReCalculatCostInSales.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ReCalculatCostInSales.ImageOptions.LargeImage")));
            this.ReCalculatCostInSales.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ReCalculatCostInSales.ImageOptions.LargeImageIndex")));
            this.ReCalculatCostInSales.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ReCalculatCostInSales.ImageOptions.SvgImage")));
            this.ReCalculatCostInSales.Name = "ReCalculatCostInSales";
            // 
            // barFromDate
            // 
            resources.ApplyResources(this.barFromDate, "barFromDate");
            this.barFromDate.Edit = this.repositoryItemDateEdit1;
            this.barFromDate.Id = 5;
            this.barFromDate.ImageOptions.ImageIndex = ((int)(resources.GetObject("barFromDate.ImageOptions.ImageIndex")));
            this.barFromDate.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barFromDate.ImageOptions.LargeImageIndex")));
            this.barFromDate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barFromDate.ImageOptions.SvgImage")));
            this.barFromDate.Name = "barFromDate";
            // 
            // repositoryItemDateEdit1
            // 
            resources.ApplyResources(this.repositoryItemDateEdit1, "repositoryItemDateEdit1");
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.Buttons"))))});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.CalendarTimeProperties.Buttons"))))});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barToDate
            // 
            resources.ApplyResources(this.barToDate, "barToDate");
            this.barToDate.Edit = this.repositoryItemDateEdit2;
            this.barToDate.Id = 6;
            this.barToDate.ImageOptions.ImageIndex = ((int)(resources.GetObject("barToDate.ImageOptions.ImageIndex")));
            this.barToDate.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barToDate.ImageOptions.LargeImageIndex")));
            this.barToDate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barToDate.ImageOptions.SvgImage")));
            this.barToDate.Name = "barToDate";
            // 
            // repositoryItemDateEdit2
            // 
            resources.ApplyResources(this.repositoryItemDateEdit2, "repositoryItemDateEdit2");
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit2.Buttons"))))});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit2.CalendarTimeProperties.Buttons"))))});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // ribbonPageMain
            // 
            this.ribbonPageMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageMain.Name = "ribbonPageMain";
            resources.ApplyResources(this.ribbonPageMain, "ribbonPageMain");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiBackupData);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.ReCalculatCostInSales);
            this.ribbonPageGroup1.ItemLinks.Add(this.barFromDate);
            this.ribbonPageGroup1.ItemLinks.Add(this.barToDate);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // chartControl1
            // 
            resources.ApplyResources(this.chartControl1, "chartControl1");
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.CrosshairOptions.ShowArgumentLabels = true;
            this.chartControl1.CrosshairOptions.ShowValueLabels = true;
            this.chartControl1.CrosshairOptions.ShowValueLine = true;
            this.chartControl1.DataSource = this.tblAssetBindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.MinorCount = 4;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.AlignmentHorizontal = ((DevExpress.XtraCharts.LegendAlignmentHorizontal)(resources.GetObject("chartControl1.Legend.AlignmentHorizontal")));
            this.chartControl1.Legend.AlignmentVertical = ((DevExpress.XtraCharts.LegendAlignmentVertical)(resources.GetObject("chartControl1.Legend.AlignmentVertical")));
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Office 2013";
            this.chartControl1.SelectionMode = DevExpress.XtraCharts.ElementSelectionMode.Single;
            series1.ArgumentDataMember = "asAccName";
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.LegendName = "Default Legend";
            series1.LegendTextPattern = "{A}: {V}";
            resources.ApplyResources(series1, "series1");
            series1.ValueDataMembersSerializable = "asDebit";
            barGrowUpAnimation1.BeginTime = System.TimeSpan.Parse("00:00:00.5000000");
            barGrowUpAnimation1.Duration = System.TimeSpan.Parse("00:00:01");
            barGrowUpAnimation1.PointDelay = System.TimeSpan.Parse("00:00:00.5000000");
            sideBySideBarSeriesView1.Animation = barGrowUpAnimation1;
            sideBySideBarSeriesView1.ColorEach = true;
            sideBySideBarSeriesView1.RangeControlOptions.ViewType = DevExpress.XtraCharts.RangeControlViewType.Area;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            resources.ApplyResources(chartTitle1, "chartTitle1");
            chartTitle1.TextColor = System.Drawing.Color.Black;
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.chartControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChartControl1_KeyDown);
            // 
            // flyoutPanel1
            // 
            resources.ApplyResources(this.flyoutPanel1, "flyoutPanel1");
            this.flyoutPanel1.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.flyoutPanel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flyoutPanel1.Appearance.Options.UseBackColor = true;
            this.flyoutPanel1.Appearance.Options.UseForeColor = true;
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
            this.flyoutPanel1.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyoutPanel1.OptionsBeakPanel.BackColor = System.Drawing.Color.Lavender;
            this.flyoutPanel1.OptionsBeakPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 41;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Top;
            this.flyoutPanel1.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton(resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons"), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons1"))), buttonImageOptions1, ((DevExpress.XtraBars.Docking2010.ButtonStyle)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons2"))), resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons3"), ((int)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons4"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons5"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons6"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons7"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons8"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons9"))), resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons10"), ((int)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons11"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons12")))),
            new DevExpress.Utils.PeekFormButton(resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons13"), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons14"))), buttonImageOptions2, ((DevExpress.XtraBars.Docking2010.ButtonStyle)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons15"))), resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons16"), ((int)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons17"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons18"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons19"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons20"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons21"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons22"))), resources.GetString("flyoutPanel1.OptionsButtonPanel.Buttons23"), ((int)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons24"))), ((bool)(resources.GetObject("flyoutPanel1.OptionsButtonPanel.Buttons25"))))});
            this.flyoutPanel1.OptionsButtonPanel.ShowButtonPanel = true;
            this.flyoutPanel1.OwnerControl = this;
            // 
            // flyoutPanelControl1
            // 
            resources.ApplyResources(this.flyoutPanelControl1, "flyoutPanelControl1");
            this.flyoutPanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.flyoutPanelControl1.Appearance.Options.UseBackColor = true;
            this.flyoutPanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.flyoutPanelControl1.Controls.Add(this.progressBarControl1);
            this.flyoutPanelControl1.Controls.Add(this.label1);
            this.flyoutPanelControl1.Controls.Add(this.lblStatus);
            this.flyoutPanelControl1.Controls.Add(this.lblPercent);
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            // 
            // progressBarControl1
            // 
            resources.ApplyResources(this.progressBarControl1, "progressBarControl1");
            this.progressBarControl1.MenuManager = this.ribbonControl1;
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.AutoHeight = ((bool)(resources.GetObject("progressBarControl1.Properties.AutoHeight")));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Name = "label1";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblStatus.Name = "lblStatus";
            // 
            // lblPercent
            // 
            resources.ApplyResources(this.lblPercent, "lblPercent");
            this.lblPercent.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblPercent.Name = "lblPercent";
            // 
            // UCDashboardEF
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flyoutPanel1);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "UCDashboardEF";
            ((System.ComponentModel.ISupportInitialize)(this.tblAssetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            this.flyoutPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource tblAssetBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPercent;
        private DevExpress.XtraBars.BarButtonItem bbiBackupData;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem ReCalculatCostInSales;
        private DevExpress.XtraBars.BarEditItem barFromDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem barToDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
    }
}
