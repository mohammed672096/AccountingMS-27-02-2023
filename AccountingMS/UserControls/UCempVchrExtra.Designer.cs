namespace AccountingMS
{
    partial class UCempVchrExtra
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
            this.tblEntryMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentBoxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCurChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentBrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiShowPhase = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhase = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupPrint = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTarhel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntryMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblEntryMainBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 132);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 468);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblEntryMainBindingSource
            // 
            this.tblEntryMainBindingSource.DataSource = typeof(AccountingMS.tblEntryMain);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colentNo,
            this.colentBoxNo,
            this.colentDesc,
            this.colentAmount,
            this.colentCurrency,
            this.colentDate,
            this.colentTotalTax,
            this.colentRefNo,
            this.colentCurChange,
            this.colentStatus,
            this.colentUserId,
            this.colentBrnId});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colentNo
            // 
            this.colentNo.AppearanceCell.Options.UseTextOptions = true;
            this.colentNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentNo.Caption = "رقم السند";
            this.colentNo.FieldName = "entNo";
            this.colentNo.Name = "colentNo";
            this.colentNo.Visible = true;
            this.colentNo.VisibleIndex = 0;
            // 
            // colentBoxNo
            // 
            this.colentBoxNo.AppearanceCell.Options.UseTextOptions = true;
            this.colentBoxNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentBoxNo.Caption = "الصندوق";
            this.colentBoxNo.FieldName = "entBoxNo";
            this.colentBoxNo.Name = "colentBoxNo";
            this.colentBoxNo.Visible = true;
            this.colentBoxNo.VisibleIndex = 1;
            // 
            // colentDesc
            // 
            this.colentDesc.Caption = "البيان";
            this.colentDesc.FieldName = "entDesc";
            this.colentDesc.Name = "colentDesc";
            this.colentDesc.Visible = true;
            this.colentDesc.VisibleIndex = 2;
            // 
            // colentAmount
            // 
            this.colentAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colentAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentAmount.Caption = "المبلغ";
            this.colentAmount.DisplayFormat.FormatString = "n2";
            this.colentAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colentAmount.FieldName = "entAmount";
            this.colentAmount.Name = "colentAmount";
            this.colentAmount.Visible = true;
            this.colentAmount.VisibleIndex = 3;
            // 
            // colentCurrency
            // 
            this.colentCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colentCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCurrency.Caption = "العملة";
            this.colentCurrency.FieldName = "entCurrency";
            this.colentCurrency.Name = "colentCurrency";
            this.colentCurrency.Visible = true;
            this.colentCurrency.VisibleIndex = 4;
            // 
            // colentDate
            // 
            this.colentDate.Caption = "التاريخ";
            this.colentDate.DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
            this.colentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colentDate.FieldName = "entDate";
            this.colentDate.Name = "colentDate";
            this.colentDate.Visible = true;
            this.colentDate.VisibleIndex = 6;
            // 
            // colentTotalTax
            // 
            this.colentTotalTax.FieldName = "entTotalTax";
            this.colentTotalTax.Name = "colentTotalTax";
            this.colentTotalTax.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colentRefNo
            // 
            this.colentRefNo.FieldName = "entRefNo";
            this.colentRefNo.Name = "colentRefNo";
            this.colentRefNo.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colentCurChange
            // 
            this.colentCurChange.FieldName = "entCurChange";
            this.colentCurChange.Name = "colentCurChange";
            this.colentCurChange.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colentStatus
            // 
            this.colentStatus.FieldName = "entStatus";
            this.colentStatus.Name = "colentStatus";
            this.colentStatus.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colentUserId
            // 
            this.colentUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colentUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentUserId.Caption = "المستخدم";
            this.colentUserId.FieldName = "entUserId";
            this.colentUserId.Name = "colentUserId";
            this.colentUserId.Visible = true;
            this.colentUserId.VisibleIndex = 5;
            // 
            // colentBrnId
            // 
            this.colentBrnId.FieldName = "entBrnId";
            this.colentBrnId.Name = "colentBrnId";
            this.colentBrnId.OptionsColumn.ShowInCustomizationForm = false;
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
            this.bbiShowPhase,
            this.bbiPhase});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 22;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(800, 132);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة السند";
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
            // bbiShowPhase
            // 
            this.bbiShowPhase.Caption = "عرض/إخفاء الترحيل";
            this.bbiShowPhase.Id = 20;
            this.bbiShowPhase.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.multiplemasterfilter;
            this.bbiShowPhase.Name = "bbiShowPhase";
            this.bbiShowPhase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiShowPhase_ItemClick);
            // 
            // bbiPhase
            // 
            this.bbiPhase.Caption = "ترحيل";
            this.bbiPhase.Id = 21;
            this.bbiPhase.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.export;
            this.bbiPhase.Name = "bbiPhase";
            this.bbiPhase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPhase_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupMain,
            this.ribbonPageGroupPrint,
            this.ribbonPageGroupTarhel});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroupMain
            // 
            this.ribbonPageGroupMain.AllowTextClipping = false;
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroupMain.Name = "ribbonPageGroupMain";
            this.ribbonPageGroupMain.ShowCaptionButton = false;
            this.ribbonPageGroupMain.Text = "العمليات";
            // 
            // ribbonPageGroupPrint
            // 
            this.ribbonPageGroupPrint.AllowTextClipping = false;
            this.ribbonPageGroupPrint.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroupPrint.Name = "ribbonPageGroupPrint";
            this.ribbonPageGroupPrint.ShowCaptionButton = false;
            this.ribbonPageGroupPrint.Text = "الطباعة والتصدير";
            // 
            // ribbonPageGroupTarhel
            // 
            this.ribbonPageGroupTarhel.AllowTextClipping = false;
            this.ribbonPageGroupTarhel.ItemLinks.Add(this.bbiShowPhase);
            this.ribbonPageGroupTarhel.ItemLinks.Add(this.bbiPhase);
            this.ribbonPageGroupTarhel.Name = "ribbonPageGroupTarhel";
            this.ribbonPageGroupTarhel.ShowCaptionButton = false;
            this.ribbonPageGroupTarhel.Text = "الترحيل";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 574);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(800, 26);
            // 
            // UCempVchrTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCempVchrTip";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEntryMainBindingSource)).EndInit();
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupMain;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupPrint;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource tblEntryMainBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colentNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentBoxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colentCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colentTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colentRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentCurChange;
        private DevExpress.XtraGrid.Columns.GridColumn colentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colentUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colentBrnId;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTarhel;
        private DevExpress.XtraBars.BarButtonItem bbiShowPhase;
        private DevExpress.XtraBars.BarButtonItem bbiPhase;
    }
}
