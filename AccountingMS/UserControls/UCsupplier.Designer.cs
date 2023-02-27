namespace AccountingMS
{
    partial class UCsupplier
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplTaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsplEmail = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(0, 170);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1066, 661);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AccountingMS.tblSupplier);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colsplNo,
            this.colsplAccNo,
            this.colsplName,
            this.colsplCurrency,
            this.colsplPhnNo,
            this.colsplTaxNo,
            this.colsplCountry,
            this.colsplCity,
            this.colsplAddress,
            this.colsplEmail});
            this.gridView.DetailHeight = 485;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.MinWidth = 26;
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            this.colid.Width = 99;
            // 
            // colsplNo
            // 
            this.colsplNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsplNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsplNo.Caption = "رقم المورد";
            this.colsplNo.FieldName = "splNo";
            this.colsplNo.MinWidth = 26;
            this.colsplNo.Name = "colsplNo";
            this.colsplNo.Visible = true;
            this.colsplNo.VisibleIndex = 1;
            this.colsplNo.Width = 99;
            // 
            // colsplAccNo
            // 
            this.colsplAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colsplAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsplAccNo.Caption = "رقم حساب المورد";
            this.colsplAccNo.FieldName = "splAccNo";
            this.colsplAccNo.MinWidth = 26;
            this.colsplAccNo.Name = "colsplAccNo";
            this.colsplAccNo.Visible = true;
            this.colsplAccNo.VisibleIndex = 0;
            this.colsplAccNo.Width = 99;
            // 
            // colsplName
            // 
            this.colsplName.Caption = "إسم المورد";
            this.colsplName.FieldName = "splName";
            this.colsplName.MinWidth = 26;
            this.colsplName.Name = "colsplName";
            this.colsplName.Visible = true;
            this.colsplName.VisibleIndex = 2;
            this.colsplName.Width = 99;
            // 
            // colsplCurrency
            // 
            this.colsplCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colsplCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colsplCurrency.Caption = "العملة";
            this.colsplCurrency.FieldName = "splCurrency";
            this.colsplCurrency.MinWidth = 26;
            this.colsplCurrency.Name = "colsplCurrency";
            this.colsplCurrency.Visible = true;
            this.colsplCurrency.VisibleIndex = 3;
            this.colsplCurrency.Width = 99;
            // 
            // colsplPhnNo
            // 
            this.colsplPhnNo.Caption = "رقم التلفون";
            this.colsplPhnNo.FieldName = "splPhnNo";
            this.colsplPhnNo.MinWidth = 26;
            this.colsplPhnNo.Name = "colsplPhnNo";
            this.colsplPhnNo.Visible = true;
            this.colsplPhnNo.VisibleIndex = 4;
            this.colsplPhnNo.Width = 99;
            // 
            // colsplTaxNo
            // 
            this.colsplTaxNo.Caption = "الرقم الضريبي";
            this.colsplTaxNo.FieldName = "splTaxNo";
            this.colsplTaxNo.MinWidth = 26;
            this.colsplTaxNo.Name = "colsplTaxNo";
            this.colsplTaxNo.Visible = true;
            this.colsplTaxNo.VisibleIndex = 5;
            this.colsplTaxNo.Width = 99;
            // 
            // colsplCountry
            // 
            this.colsplCountry.Caption = "الدولة";
            this.colsplCountry.FieldName = "splCountry";
            this.colsplCountry.MinWidth = 26;
            this.colsplCountry.Name = "colsplCountry";
            this.colsplCountry.Visible = true;
            this.colsplCountry.VisibleIndex = 6;
            this.colsplCountry.Width = 99;
            // 
            // colsplCity
            // 
            this.colsplCity.Caption = "المدينه";
            this.colsplCity.FieldName = "splCity";
            this.colsplCity.MinWidth = 26;
            this.colsplCity.Name = "colsplCity";
            this.colsplCity.Visible = true;
            this.colsplCity.VisibleIndex = 7;
            this.colsplCity.Width = 99;
            // 
            // colsplAddress
            // 
            this.colsplAddress.Caption = "العنوان";
            this.colsplAddress.FieldName = "splAddress";
            this.colsplAddress.MinWidth = 26;
            this.colsplAddress.Name = "colsplAddress";
            this.colsplAddress.Visible = true;
            this.colsplAddress.VisibleIndex = 8;
            this.colsplAddress.Width = 99;
            // 
            // colsplEmail
            // 
            this.colsplEmail.Caption = "البريد الإلكتروني";
            this.colsplEmail.FieldName = "splEmail";
            this.colsplEmail.MinWidth = 26;
            this.colsplEmail.Name = "colsplEmail";
            this.colsplEmail.Visible = true;
            this.colsplEmail.VisibleIndex = 9;
            this.colsplEmail.Width = 99;
            // 
            // ribbonControl
            // 
          //  this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 39, 34, 39);
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
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 377;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1066, 170);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة\r\nF7";
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
            this.bbiNew.Caption = "إضافة مورد\r\nF2";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.add_32x32;
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "تعديل\r\nF4";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.edit_32x32;
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف\r\nF6";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث\r\nF5";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
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
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew, "F2");
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit, "F4");
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete, "F6");
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh, "F5");
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview, "F7");
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "الطباعة والتصدير";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 799);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1066, 32);
            // 
            // UCsupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCsupplier";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1066, 831);
            this.Load += new System.EventHandler(this.UCsupplier_Load);
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
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colsplNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsplAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsplName;
        private DevExpress.XtraGrid.Columns.GridColumn colsplPhnNo;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraGrid.Columns.GridColumn colsplTaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsplCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colsplCity;
        private DevExpress.XtraGrid.Columns.GridColumn colsplAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colsplEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colsplCurrency;
    }
}
