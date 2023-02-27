namespace AccountingMS
{
    partial class UCsupplyVocher
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupMsur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupQuanMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsupNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupAccName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsupUserId = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colsupAccNo,
            this.colsupAccName,
            this.gridColumn2,
            this.colsupPrdNo,
            this.colsupPrdName,
            this.colsupMsur,
            this.colsupQuanMain,
            this.colsupPrice,
            this.colsupDebit,
            this.colsupCredit,
            this.gridColumn3});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "رقم التوريد";
            this.gridColumn1.FieldName = "supNo";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 87;
            // 
            // colsupAccNo
            // 
            this.colsupAccNo.Caption = "رقم الحساب";
            this.colsupAccNo.FieldName = "supAccNo";
            this.colsupAccNo.MinWidth = 23;
            this.colsupAccNo.Name = "colsupAccNo";
            this.colsupAccNo.Width = 87;
            // 
            // colsupAccName
            // 
            this.colsupAccName.Caption = "إسم الحساب";
            this.colsupAccName.FieldName = "supAccName";
            this.colsupAccName.MinWidth = 23;
            this.colsupAccName.Name = "colsupAccName";
            this.colsupAccName.Visible = true;
            this.colsupAccName.VisibleIndex = 0;
            this.colsupAccName.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "البيان";
            this.gridColumn2.FieldName = "supDesc";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 87;
            // 
            // colsupPrdNo
            // 
            this.colsupPrdNo.Caption = "رقم الصنف";
            this.colsupPrdNo.FieldName = "supPrdNo";
            this.colsupPrdNo.MinWidth = 23;
            this.colsupPrdNo.Name = "colsupPrdNo";
            this.colsupPrdNo.Visible = true;
            this.colsupPrdNo.VisibleIndex = 2;
            this.colsupPrdNo.Width = 87;
            // 
            // colsupPrdName
            // 
            this.colsupPrdName.Caption = "إسم الصنف";
            this.colsupPrdName.FieldName = "supPrdName";
            this.colsupPrdName.MinWidth = 23;
            this.colsupPrdName.Name = "colsupPrdName";
            this.colsupPrdName.Visible = true;
            this.colsupPrdName.VisibleIndex = 3;
            this.colsupPrdName.Width = 87;
            // 
            // colsupMsur
            // 
            this.colsupMsur.AppearanceCell.Options.UseTextOptions = true;
            this.colsupMsur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsupMsur.Caption = "وحدة القياس";
            this.colsupMsur.FieldName = "supMsur";
            this.colsupMsur.MinWidth = 23;
            this.colsupMsur.Name = "colsupMsur";
            this.colsupMsur.Visible = true;
            this.colsupMsur.VisibleIndex = 4;
            this.colsupMsur.Width = 87;
            // 
            // colsupQuanMain
            // 
            this.colsupQuanMain.Caption = "الكمية";
            this.colsupQuanMain.FieldName = "supQuanMain";
            this.colsupQuanMain.MinWidth = 23;
            this.colsupQuanMain.Name = "colsupQuanMain";
            this.colsupQuanMain.Visible = true;
            this.colsupQuanMain.VisibleIndex = 5;
            this.colsupQuanMain.Width = 87;
            // 
            // colsupPrice
            // 
            this.colsupPrice.Caption = "المبلغ";
            this.colsupPrice.FieldName = "supPrice";
            this.colsupPrice.MinWidth = 23;
            this.colsupPrice.Name = "colsupPrice";
            this.colsupPrice.Visible = true;
            this.colsupPrice.VisibleIndex = 6;
            this.colsupPrice.Width = 87;
            // 
            // colsupDebit
            // 
            this.colsupDebit.Caption = "المجموع";
            this.colsupDebit.FieldName = "supCredit";
            this.colsupDebit.MinWidth = 23;
            this.colsupDebit.Name = "colsupDebit";
            this.colsupDebit.Visible = true;
            this.colsupDebit.VisibleIndex = 7;
            this.colsupDebit.Width = 87;
            // 
            // colsupCredit
            // 
            this.colsupCredit.Caption = "دائن";
            this.colsupCredit.FieldName = "supCredit";
            this.colsupCredit.MinWidth = 23;
            this.colsupCredit.Name = "colsupCredit";
            this.colsupCredit.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "التاريخ";
            this.gridColumn3.FieldName = "supDate";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 87;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 136);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(933, 510);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AccountingMS.tblEntryMain);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsupNo,
            this.colsupAccNo1,
            this.colsupAccName1,
            this.colsupRefNo,
            this.colsupDesc,
            this.colsupTotal,
            this.colsupDate,
            this.colsupUserId});
            this.gridView.DetailHeight = 377;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            // 
            // colsupNo
            // 
            this.colsupNo.Caption = "رقم التوريد";
            this.colsupNo.FieldName = "supNo";
            this.colsupNo.MinWidth = 23;
            this.colsupNo.Name = "colsupNo";
            this.colsupNo.Visible = true;
            this.colsupNo.VisibleIndex = 0;
            this.colsupNo.Width = 87;
            // 
            // colsupAccNo1
            // 
            this.colsupAccNo1.FieldName = "supAccNo";
            this.colsupAccNo1.MinWidth = 23;
            this.colsupAccNo1.Name = "colsupAccNo1";
            this.colsupAccNo1.Width = 87;
            // 
            // colsupAccName1
            // 
            this.colsupAccName1.Caption = "إسم الحساب";
            this.colsupAccName1.FieldName = "supAccName";
            this.colsupAccName1.MinWidth = 23;
            this.colsupAccName1.Name = "colsupAccName1";
            this.colsupAccName1.Visible = true;
            this.colsupAccName1.VisibleIndex = 1;
            this.colsupAccName1.Width = 87;
            // 
            // colsupRefNo
            // 
            this.colsupRefNo.Caption = "رقم المرجع";
            this.colsupRefNo.FieldName = "supRefNo";
            this.colsupRefNo.MinWidth = 23;
            this.colsupRefNo.Name = "colsupRefNo";
            this.colsupRefNo.Visible = true;
            this.colsupRefNo.VisibleIndex = 2;
            this.colsupRefNo.Width = 87;
            // 
            // colsupDesc
            // 
            this.colsupDesc.Caption = "البيان";
            this.colsupDesc.FieldName = "supDesc";
            this.colsupDesc.MinWidth = 23;
            this.colsupDesc.Name = "colsupDesc";
            this.colsupDesc.Visible = true;
            this.colsupDesc.VisibleIndex = 3;
            this.colsupDesc.Width = 87;
            // 
            // colsupTotal
            // 
            this.colsupTotal.Caption = "المبلغ";
            this.colsupTotal.FieldName = "supTotal";
            this.colsupTotal.MinWidth = 23;
            this.colsupTotal.Name = "colsupTotal";
            this.colsupTotal.Visible = true;
            this.colsupTotal.VisibleIndex = 4;
            this.colsupTotal.Width = 87;
            // 
            // colsupDate
            // 
            this.colsupDate.Caption = "التاريخ";
            this.colsupDate.FieldName = "supDate";
            this.colsupDate.MinWidth = 23;
            this.colsupDate.Name = "colsupDate";
            this.colsupDate.Visible = true;
            this.colsupDate.VisibleIndex = 5;
            this.colsupDate.Width = 87;
            // 
            // colsupUserId
            // 
            this.colsupUserId.FieldName = "supUserId";
            this.colsupUserId.MinWidth = 23;
            this.colsupUserId.Name = "colsupUserId";
            this.colsupUserId.Width = 87;
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
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(933, 136);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
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
            this.bbiNew.Caption = "إنشاء صرف مخزني";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.add;
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
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
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 620);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(933, 26);
            // 
            // UCsupplyVocher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCsupplyVocher";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(933, 646);
            this.Load += new System.EventHandler(this.UCstoreVocher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrdName;
        private DevExpress.XtraGrid.Columns.GridColumn colsupMsur;
        private DevExpress.XtraGrid.Columns.GridColumn colsupQuanMain;
        private DevExpress.XtraGrid.Columns.GridColumn colsupPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colsupCredit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colsupNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccNo1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupAccName1;
        private DevExpress.XtraGrid.Columns.GridColumn colsupRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colsupTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colsupDate;
        private DevExpress.XtraGrid.Columns.GridColumn colsupUserId;
    }
}
