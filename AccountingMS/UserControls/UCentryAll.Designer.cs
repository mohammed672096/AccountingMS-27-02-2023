namespace AccountingMS
{
    partial class UCentryAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCentryAll));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colentAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDesc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.labelBalanceOld = new DevExpress.XtraBars.BarStaticItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.labelBalanceNew = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource1;
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
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(tblEntrySub);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.AutoFillColumn = this.colentAccName;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colentNo1,
            this.colentAccNo,
            this.colentAccName,
            this.colentDesc1,
            this.colentDebit,
            this.colentCredit,
            this.colentDate,
            this.colentStatus});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colentAccName
            // 
            this.colentAccName.Caption = "إسم الحساب";
            this.colentAccName.FieldName = "entAccName";
            this.colentAccName.Name = "colentAccName";
            this.colentAccName.Visible = true;
            this.colentAccName.VisibleIndex = 1;
            // 
            // colentNo1
            // 
            this.colentNo1.AppearanceCell.Options.UseTextOptions = true;
            this.colentNo1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentNo1.Caption = "رقم السند";
            this.colentNo1.FieldName = "entNo";
            this.colentNo1.Name = "colentNo1";
            this.colentNo1.Visible = true;
            this.colentNo1.VisibleIndex = 0;
            // 
            // colentAccNo
            // 
            this.colentAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colentAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentAccNo.Caption = "رقم الحساب";
            this.colentAccNo.FieldName = "entAccNo";
            this.colentAccNo.Name = "colentAccNo";
            // 
            // colentDesc1
            // 
            this.colentDesc1.Caption = "البيان";
            this.colentDesc1.FieldName = "entDesc";
            this.colentDesc1.Name = "colentDesc1";
            this.colentDesc1.Visible = true;
            this.colentDesc1.VisibleIndex = 2;
            // 
            // colentDebit
            // 
            this.colentDebit.AppearanceCell.Options.UseTextOptions = true;
            this.colentDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentDebit.Caption = "مدين";
            this.colentDebit.FieldName = "entDebit";
            this.colentDebit.Name = "colentDebit";
            this.colentDebit.Visible = true;
            this.colentDebit.VisibleIndex = 3;
            // 
            // colentCredit
            // 
            this.colentCredit.AppearanceCell.Options.UseTextOptions = true;
            this.colentCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentCredit.Caption = "دائن";
            this.colentCredit.FieldName = "entCredit";
            this.colentCredit.Name = "colentCredit";
            this.colentCredit.Visible = true;
            this.colentCredit.VisibleIndex = 4;
            // 
            // colentDate
            // 
            this.colentDate.Caption = "التاريخ";
            this.colentDate.FieldName = "entDate";
            this.colentDate.Name = "colentDate";
            this.colentDate.Visible = true;
            this.colentDate.VisibleIndex = 5;
            // 
            // colentStatus
            // 
            this.colentStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colentStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colentStatus.Caption = "نوع السند";
            this.colentStatus.FieldName = "entStatus";
            this.colentStatus.Name = "colentStatus";
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bsiRecordsCount,
            this.bbiRefresh,
            this.labelBalanceOld,
            this.barHeaderItem1,
            this.barHeaderItem2,
            this.barButtonItem1,
            this.labelBalanceNew,
            this.barButtonItem2});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 26;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(800, 132);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // labelBalanceOld
            // 
            this.labelBalanceOld.Caption = "الرصيد الحالي: ";
            this.labelBalanceOld.Id = 20;
            this.labelBalanceOld.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelBalanceOld.ItemAppearance.Normal.Options.UseFont = true;
            this.labelBalanceOld.Name = "labelBalanceOld";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "barHeaderItem1";
            this.barHeaderItem1.Id = 21;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "barHeaderItem2";
            this.barHeaderItem2.Id = 22;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "إقفال";
            this.barButtonItem1.Id = 23;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // labelBalanceNew
            // 
            this.labelBalanceNew.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.labelBalanceNew.Caption = "الرصيد المتوفر: ";
            this.labelBalanceNew.Id = 24;
            this.labelBalanceNew.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelBalanceNew.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(200)))));
            this.labelBalanceNew.ItemAppearance.Normal.Options.UseFont = true;
            this.labelBalanceNew.ItemAppearance.Normal.Options.UseForeColor = true;
            this.labelBalanceNew.Name = "labelBalanceNew";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "طباعة الحركة";
            this.barButtonItem2.Id = 25;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.report_32x321;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "الطباعه";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.labelBalanceOld);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.ItemLinks.Add(this.labelBalanceNew);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 574);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(800, 26);
            // 
            // UCentryAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCentryAll";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.UCentryAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colentAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colentDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colentCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colentNo1;
        private DevExpress.XtraGrid.Columns.GridColumn colentDesc1;
        private DevExpress.XtraGrid.Columns.GridColumn colentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colentStatus;
        private DevExpress.XtraBars.BarStaticItem labelBalanceOld;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarStaticItem labelBalanceNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}
