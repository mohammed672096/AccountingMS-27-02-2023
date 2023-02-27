namespace AccountingMS
{
    partial class UCbranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCbranch));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bsCount = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblBranchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbrnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnNameEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnAddressEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnFaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnMailBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBranchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbSave,
            this.bbEdit,
            this.bbRefresh,
            this.bsCount,
            this.ribbonControl.SearchEditItem});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl1";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(813, 132);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbSave
            // 
            this.bbSave.Caption = "إضافة فرع\r\nF2";
            this.bbSave.Id = 1;
            this.bbSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbSave.ImageOptions.LargeImage")));
            this.bbSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbSave.Name = "bbSave";
            this.bbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSave_ItemClick);
            // 
            // bbEdit
            // 
            this.bbEdit.Caption = "تعديل\r\nF4";
            this.bbEdit.Id = 2;
            this.bbEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbEdit.ImageOptions.LargeImage")));
            this.bbEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbEdit.Name = "bbEdit";
            this.bbEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEdit_ItemClick);
            // 
            // bbRefresh
            // 
            this.bbRefresh.Caption = "تحديث\r\nF5";
            this.bbRefresh.Id = 3;
            this.bbRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbRefresh.ImageOptions.LargeImage")));
            this.bbRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbRefresh.Name = "bbRefresh";
            this.bbRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRefresh_ItemClick);
            // 
            // bsCount
            // 
            this.bsCount.Caption = "bsCount";
            this.bsCount.Id = 4;
            this.bsCount.Name = "bsCount";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsCount);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 475);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(813, 26);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblBranchBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 132);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(813, 343);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblBranchBindingSource
            // 
            this.tblBranchBindingSource.DataSource = typeof(tblBranch);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbrnId,
            this.colbrnNo,
            this.colbrnName,
            this.colbrnNameEn,
            this.colbrnAddress,
            this.colbrnAddressEn,
            this.colbrnPhnNo,
            this.colbrnFaxNo,
            this.colbrnEmail,
            this.colbrnMailBox,
            this.colbrnStatus});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // colbrnId
            // 
            this.colbrnId.FieldName = "brnId";
            this.colbrnId.Name = "colbrnId";
            // 
            // colbrnNo
            // 
            this.colbrnNo.AppearanceCell.Options.UseTextOptions = true;
            this.colbrnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbrnNo.Caption = "رقم الفرع";
            this.colbrnNo.FieldName = "brnNo";
            this.colbrnNo.Name = "colbrnNo";
            this.colbrnNo.Visible = true;
            this.colbrnNo.VisibleIndex = 0;
            // 
            // colbrnName
            // 
            this.colbrnName.Caption = "إسم الفرع";
            this.colbrnName.FieldName = "brnName";
            this.colbrnName.Name = "colbrnName";
            this.colbrnName.Visible = true;
            this.colbrnName.VisibleIndex = 1;
            // 
            // colbrnNameEn
            // 
            this.colbrnNameEn.Caption = "Branch Name";
            this.colbrnNameEn.FieldName = "brnNameEn";
            this.colbrnNameEn.Name = "colbrnNameEn";
            // 
            // colbrnAddress
            // 
            this.colbrnAddress.Caption = "العنوان";
            this.colbrnAddress.FieldName = "brnAddress";
            this.colbrnAddress.Name = "colbrnAddress";
            this.colbrnAddress.Visible = true;
            this.colbrnAddress.VisibleIndex = 2;
            // 
            // colbrnAddressEn
            // 
            this.colbrnAddressEn.Caption = "BranchAddress";
            this.colbrnAddressEn.FieldName = "brnAddressEn";
            this.colbrnAddressEn.Name = "colbrnAddressEn";
            // 
            // colbrnPhnNo
            // 
            this.colbrnPhnNo.Caption = "رقم الهاتف";
            this.colbrnPhnNo.FieldName = "brnPhnNo";
            this.colbrnPhnNo.Name = "colbrnPhnNo";
            this.colbrnPhnNo.Visible = true;
            this.colbrnPhnNo.VisibleIndex = 3;
            // 
            // colbrnFaxNo
            // 
            this.colbrnFaxNo.Caption = "الفاكس";
            this.colbrnFaxNo.FieldName = "brnFaxNo";
            this.colbrnFaxNo.Name = "colbrnFaxNo";
            this.colbrnFaxNo.Visible = true;
            this.colbrnFaxNo.VisibleIndex = 4;
            // 
            // colbrnEmail
            // 
            this.colbrnEmail.Caption = "البريد الإلكتروني";
            this.colbrnEmail.FieldName = "brnEmail";
            this.colbrnEmail.Name = "colbrnEmail";
            this.colbrnEmail.Visible = true;
            this.colbrnEmail.VisibleIndex = 5;
            // 
            // colbrnMailBox
            // 
            this.colbrnMailBox.Caption = "صندوق البريد";
            this.colbrnMailBox.FieldName = "brnMailBox";
            this.colbrnMailBox.Name = "colbrnMailBox";
            this.colbrnMailBox.Visible = true;
            this.colbrnMailBox.VisibleIndex = 6;
            // 
            // colbrnStatus
            // 
            this.colbrnStatus.FieldName = "brnStatus";
            this.colbrnStatus.Name = "colbrnStatus";
            // 
            // UCbranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCbranch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(813, 501);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBranchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bbSave;
        private DevExpress.XtraBars.BarButtonItem bbEdit;
        private DevExpress.XtraBars.BarButtonItem bbRefresh;
        private DevExpress.XtraBars.BarStaticItem bsCount;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblBranchBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnId;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnName;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnNameEn;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnAddressEn;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnPhnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnFaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colbrnMailBox;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
    }
}
