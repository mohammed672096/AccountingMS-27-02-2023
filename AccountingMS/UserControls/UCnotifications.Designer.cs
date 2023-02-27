
namespace AccountingMS
{
    partial class UCnotifications
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCnotifications));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblNotificationDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotSupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotAmountPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotAmountRemaning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotIsComplete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemTextEditNotIsComplete = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colnotUsrId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiShowHideSelect = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCompleted = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUnComplete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNotificationDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemTextEditNotIsComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblNotificationDetailBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 136);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemTextEditNotIsComplete});
            this.gridControl.Size = new System.Drawing.Size(933, 402);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblNotificationDetailBindingSource
            // 
            this.tblNotificationDetailBindingSource.DataSource = typeof(AccountingMS.tblNotificationDetail);
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedRow.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.GroupRow.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView.Appearance.Row.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.Row.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colnotSupId,
            this.colnotStatus,
            this.colnotNo,
            this.colnotName,
            this.colnotDesc,
            this.colnotAmount,
            this.colnotAmountPaid,
            this.colnotAmountRemaning,
            this.colnotDate,
            this.colnotIsComplete,
            this.colnotUsrId});
            this.gridView.DetailHeight = 377;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.MinWidth = 23;
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            this.colid.Width = 87;
            // 
            // colnotSupId
            // 
            this.colnotSupId.FieldName = "notSupId";
            this.colnotSupId.MinWidth = 23;
            this.colnotSupId.Name = "colnotSupId";
            this.colnotSupId.OptionsColumn.ShowInCustomizationForm = false;
            this.colnotSupId.Width = 87;
            // 
            // colnotStatus
            // 
            this.colnotStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colnotStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotStatus.Caption = "نوع الإشعار";
            this.colnotStatus.FieldName = "notStatus";
            this.colnotStatus.MinWidth = 23;
            this.colnotStatus.Name = "colnotStatus";
            this.colnotStatus.Visible = true;
            this.colnotStatus.VisibleIndex = 2;
            this.colnotStatus.Width = 87;
            // 
            // colnotNo
            // 
            this.colnotNo.AppearanceCell.Options.UseTextOptions = true;
            this.colnotNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotNo.Caption = "رقم الفاتورة";
            this.colnotNo.FieldName = "notNo";
            this.colnotNo.MinWidth = 23;
            this.colnotNo.Name = "colnotNo";
            this.colnotNo.Visible = true;
            this.colnotNo.VisibleIndex = 0;
            this.colnotNo.Width = 87;
            // 
            // colnotName
            // 
            this.colnotName.Caption = "إستحقاق";
            this.colnotName.FieldName = "notName";
            this.colnotName.MinWidth = 23;
            this.colnotName.Name = "colnotName";
            this.colnotName.Visible = true;
            this.colnotName.VisibleIndex = 1;
            this.colnotName.Width = 87;
            // 
            // colnotDesc
            // 
            this.colnotDesc.Caption = "البيان";
            this.colnotDesc.FieldName = "notDesc";
            this.colnotDesc.MinWidth = 23;
            this.colnotDesc.Name = "colnotDesc";
            this.colnotDesc.Visible = true;
            this.colnotDesc.VisibleIndex = 3;
            this.colnotDesc.Width = 87;
            // 
            // colnotAmount
            // 
            this.colnotAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colnotAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotAmount.Caption = "المبلغ";
            this.colnotAmount.DisplayFormat.FormatString = "n2";
            this.colnotAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnotAmount.FieldName = "notAmount";
            this.colnotAmount.MinWidth = 23;
            this.colnotAmount.Name = "colnotAmount";
            this.colnotAmount.Visible = true;
            this.colnotAmount.VisibleIndex = 4;
            this.colnotAmount.Width = 87;
            // 
            // colnotAmountPaid
            // 
            this.colnotAmountPaid.AppearanceCell.Options.UseTextOptions = true;
            this.colnotAmountPaid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotAmountPaid.Caption = "المدفوع";
            this.colnotAmountPaid.DisplayFormat.FormatString = "n2";
            this.colnotAmountPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnotAmountPaid.FieldName = "notAmountPaid";
            this.colnotAmountPaid.MinWidth = 23;
            this.colnotAmountPaid.Name = "colnotAmountPaid";
            this.colnotAmountPaid.Visible = true;
            this.colnotAmountPaid.VisibleIndex = 5;
            this.colnotAmountPaid.Width = 87;
            // 
            // colnotAmountRemaning
            // 
            this.colnotAmountRemaning.AppearanceCell.Options.UseTextOptions = true;
            this.colnotAmountRemaning.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotAmountRemaning.Caption = "المتبقي";
            this.colnotAmountRemaning.DisplayFormat.FormatString = "n2";
            this.colnotAmountRemaning.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnotAmountRemaning.FieldName = "notAmountRemaning";
            this.colnotAmountRemaning.MinWidth = 23;
            this.colnotAmountRemaning.Name = "colnotAmountRemaning";
            this.colnotAmountRemaning.Visible = true;
            this.colnotAmountRemaning.VisibleIndex = 6;
            this.colnotAmountRemaning.Width = 87;
            // 
            // colnotDate
            // 
            this.colnotDate.Caption = "تاريخ الإستحقاق";
            this.colnotDate.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colnotDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colnotDate.FieldName = "notDate";
            this.colnotDate.MinWidth = 23;
            this.colnotDate.Name = "colnotDate";
            this.colnotDate.Visible = true;
            this.colnotDate.VisibleIndex = 7;
            this.colnotDate.Width = 87;
            // 
            // colnotIsComplete
            // 
            this.colnotIsComplete.AppearanceCell.Options.UseTextOptions = true;
            this.colnotIsComplete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colnotIsComplete.Caption = "الحالة";
            this.colnotIsComplete.ColumnEdit = this.repoItemTextEditNotIsComplete;
            this.colnotIsComplete.FieldName = "notIsComplete";
            this.colnotIsComplete.MinWidth = 23;
            this.colnotIsComplete.Name = "colnotIsComplete";
            this.colnotIsComplete.Visible = true;
            this.colnotIsComplete.VisibleIndex = 8;
            this.colnotIsComplete.Width = 87;
            // 
            // repoItemTextEditNotIsComplete
            // 
            this.repoItemTextEditNotIsComplete.AutoHeight = false;
            this.repoItemTextEditNotIsComplete.Name = "repoItemTextEditNotIsComplete";
            // 
            // colnotUsrId
            // 
            this.colnotUsrId.FieldName = "notUsrId";
            this.colnotUsrId.MinWidth = 23;
            this.colnotUsrId.Name = "colnotUsrId";
            this.colnotUsrId.OptionsColumn.ShowInCustomizationForm = false;
            this.colnotUsrId.Width = 87;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiShowHideSelect,
            this.bbiCompleted,
            this.bbiUnComplete,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
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
            this.bbiPrintPreview.Caption = "معاينة";
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
            // bbiShowHideSelect
            // 
            this.bbiShowHideSelect.Caption = "عرض / إخفاء التحديد";
            this.bbiShowHideSelect.Id = 16;
            this.bbiShowHideSelect.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.multiplemasterfilter;
            this.bbiShowHideSelect.Name = "bbiShowHideSelect";
            this.bbiShowHideSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiShowHideSelect_ItemClick);
            // 
            // bbiCompleted
            // 
            this.bbiCompleted.Caption = "إنهاء";
            this.bbiCompleted.Id = 17;
            this.bbiCompleted.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiCompleted.ImageOptions.SvgImage")));
            this.bbiCompleted.Name = "bbiCompleted";
            this.bbiCompleted.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCompleted_ItemClick);
            // 
            // bbiUnComplete
            // 
            this.bbiUnComplete.Caption = "قيد المعالجة";
            this.bbiUnComplete.Id = 18;
            this.bbiUnComplete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiUnComplete.ImageOptions.SvgImage")));
            this.bbiUnComplete.Name = "bbiUnComplete";
            this.bbiUnComplete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUnComplete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiShowHideSelect);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiCompleted);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiUnComplete);
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
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 512);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(933, 26);
            // 
            // UCnotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCnotifications";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(933, 538);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNotificationDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemTextEditNotIsComplete)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiShowHideSelect;
        private DevExpress.XtraBars.BarButtonItem bbiCompleted;
        private DevExpress.XtraBars.BarButtonItem bbiUnComplete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource tblNotificationDetailBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colnotNo;
        private DevExpress.XtraGrid.Columns.GridColumn colnotName;
        private DevExpress.XtraGrid.Columns.GridColumn colnotDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colnotAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colnotDate;
        private DevExpress.XtraGrid.Columns.GridColumn colnotUsrId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoItemTextEditNotIsComplete;
        private DevExpress.XtraGrid.Columns.GridColumn colnotSupId;
        private DevExpress.XtraGrid.Columns.GridColumn colnotStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colnotAmountPaid;
        private DevExpress.XtraGrid.Columns.GridColumn colnotAmountRemaning;
        private DevExpress.XtraGrid.Columns.GridColumn colnotIsComplete;
    }
}
