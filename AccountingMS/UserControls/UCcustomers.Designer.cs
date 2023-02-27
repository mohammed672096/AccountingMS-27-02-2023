namespace AccountingMS
{
    partial class UCcustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCcustomers));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.tblCustomersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcustNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustAccName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustPhnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcustCellingCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblCustomersBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 119);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(933, 527);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblCustomersBindingSource
            // 
            this.tblCustomersBindingSource.DataSource = typeof(AccountingMS.tblCustomer);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcustNo,
            this.colcustAccNo,
            this.colcustAccName,
            this.colcustName,
            this.colcustCurrency,
            this.colcustPhnNo,
            this.colcustSalePrice,
            this.colcustCountry,
            this.colcustCity,
            this.colcustAddress,
            this.colcustEmail,
            this.colcustCellingCredit,
            this.colid});
            this.gridView.DetailHeight = 377;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colcustNo
            // 
            this.colcustNo.AppearanceCell.Options.UseTextOptions = true;
            this.colcustNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustNo.Caption = "رقم العميل";
            this.colcustNo.FieldName = "custNo";
            this.colcustNo.MinWidth = 23;
            this.colcustNo.Name = "colcustNo";
            this.colcustNo.OptionsColumn.ReadOnly = true;
            this.colcustNo.Visible = true;
            this.colcustNo.VisibleIndex = 2;
            this.colcustNo.Width = 140;
            // 
            // colcustAccNo
            // 
            this.colcustAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colcustAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustAccNo.Caption = "رقم حساب العميل";
            this.colcustAccNo.FieldName = "custAccNo";
            this.colcustAccNo.MinWidth = 23;
            this.colcustAccNo.Name = "colcustAccNo";
            this.colcustAccNo.OptionsColumn.ReadOnly = true;
            this.colcustAccNo.Visible = true;
            this.colcustAccNo.VisibleIndex = 1;
            this.colcustAccNo.Width = 140;
            // 
            // colcustAccName
            // 
            this.colcustAccName.Caption = "إسم الحساب";
            this.colcustAccName.FieldName = "custAccName";
            this.colcustAccName.MinWidth = 23;
            this.colcustAccName.Name = "colcustAccName";
            this.colcustAccName.OptionsColumn.ReadOnly = true;
            this.colcustAccName.OptionsColumn.ShowInCustomizationForm = false;
            this.colcustAccName.Width = 87;
            // 
            // colcustName
            // 
            this.colcustName.Caption = "إسم العميل";
            this.colcustName.FieldName = "custName";
            this.colcustName.MinWidth = 23;
            this.colcustName.Name = "colcustName";
            this.colcustName.OptionsColumn.ReadOnly = true;
            this.colcustName.Visible = true;
            this.colcustName.VisibleIndex = 3;
            this.colcustName.Width = 140;
            // 
            // colcustCurrency
            // 
            this.colcustCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colcustCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustCurrency.Caption = "العملة";
            this.colcustCurrency.FieldName = "custCurrency";
            this.colcustCurrency.MinWidth = 23;
            this.colcustCurrency.Name = "colcustCurrency";
            this.colcustCurrency.OptionsColumn.ReadOnly = true;
            this.colcustCurrency.Visible = true;
            this.colcustCurrency.VisibleIndex = 4;
            this.colcustCurrency.Width = 140;
            // 
            // colcustPhnNo
            // 
            this.colcustPhnNo.Caption = "رقم الهاتف";
            this.colcustPhnNo.FieldName = "custPhnNo";
            this.colcustPhnNo.MinWidth = 23;
            this.colcustPhnNo.Name = "colcustPhnNo";
            this.colcustPhnNo.OptionsColumn.ReadOnly = true;
            this.colcustPhnNo.Visible = true;
            this.colcustPhnNo.VisibleIndex = 5;
            this.colcustPhnNo.Width = 140;
            // 
            // colcustSalePrice
            // 
            this.colcustSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colcustSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustSalePrice.Caption = "سعر البيع";
            this.colcustSalePrice.FieldName = "custSalePrice";
            this.colcustSalePrice.MinWidth = 23;
            this.colcustSalePrice.Name = "colcustSalePrice";
            this.colcustSalePrice.OptionsColumn.ReadOnly = true;
            this.colcustSalePrice.Visible = true;
            this.colcustSalePrice.VisibleIndex = 6;
            this.colcustSalePrice.Width = 140;
            // 
            // colcustCountry
            // 
            this.colcustCountry.Caption = "الدولة";
            this.colcustCountry.FieldName = "custCountry";
            this.colcustCountry.MinWidth = 23;
            this.colcustCountry.Name = "colcustCountry";
            this.colcustCountry.OptionsColumn.ReadOnly = true;
            this.colcustCountry.Visible = true;
            this.colcustCountry.VisibleIndex = 7;
            this.colcustCountry.Width = 140;
            // 
            // colcustCity
            // 
            this.colcustCity.Caption = "المدينة";
            this.colcustCity.FieldName = "custCity";
            this.colcustCity.MinWidth = 23;
            this.colcustCity.Name = "colcustCity";
            this.colcustCity.OptionsColumn.ReadOnly = true;
            this.colcustCity.Visible = true;
            this.colcustCity.VisibleIndex = 8;
            this.colcustCity.Width = 140;
            // 
            // colcustAddress
            // 
            this.colcustAddress.Caption = "العنوان";
            this.colcustAddress.FieldName = "custAddress";
            this.colcustAddress.MinWidth = 23;
            this.colcustAddress.Name = "colcustAddress";
            this.colcustAddress.OptionsColumn.ReadOnly = true;
            this.colcustAddress.Visible = true;
            this.colcustAddress.VisibleIndex = 9;
            this.colcustAddress.Width = 140;
            // 
            // colcustEmail
            // 
            this.colcustEmail.Caption = "البريد الإلكتروني";
            this.colcustEmail.FieldName = "custEmail";
            this.colcustEmail.MinWidth = 23;
            this.colcustEmail.Name = "colcustEmail";
            this.colcustEmail.OptionsColumn.ReadOnly = true;
            this.colcustEmail.Visible = true;
            this.colcustEmail.VisibleIndex = 10;
            this.colcustEmail.Width = 140;
            // 
            // colcustCellingCredit
            // 
            this.colcustCellingCredit.AppearanceCell.Options.UseTextOptions = true;
            this.colcustCellingCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colcustCellingCredit.Caption = "سقف الحساب";
            this.colcustCellingCredit.FieldName = "custCellingCredit";
            this.colcustCellingCredit.MinWidth = 23;
            this.colcustCellingCredit.Name = "colcustCellingCredit";
            this.colcustCellingCredit.OptionsColumn.ReadOnly = true;
            this.colcustCellingCredit.Visible = true;
            this.colcustCellingCredit.VisibleIndex = 11;
            this.colcustCellingCredit.Width = 157;
            // 
            // colid
            // 
            this.colid.Caption = "colid";
            this.colid.FieldName = "id";
            this.colid.MinWidth = 23;
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            this.colid.Width = 87;
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(26, 23, 26, 23);
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
            this.barButtonGroup1,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 22;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 385;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(933, 119);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "طباعة\r\nF7";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
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
            this.bbiNew.Caption = "إضافة عميل\r\nF2";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.newcustomer;
            this.bbiNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "تعديل\r\nF3";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.customers;
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف\r\nF6";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "تحديث\r\nF5";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.refresh_32x32;
            this.bbiRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "ارشيف الفواتير";
            this.barButtonGroup1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonGroup1.Id = 20;
            this.barButtonGroup1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonGroup1.ImageOptions.SvgImage")));
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ارشيف الفواتيرf8";
            this.barButtonItem1.Id = 21;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
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
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "الارشيف";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 622);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(933, 24);
            // 
            // UCcustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "UCcustomers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(933, 646);
            this.Load += new System.EventHandler(this.UCcustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
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
        private System.Windows.Forms.BindingSource tblCustomersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcustNo;
        private DevExpress.XtraGrid.Columns.GridColumn colcustAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colcustAccName;
        private DevExpress.XtraGrid.Columns.GridColumn colcustName;
        private DevExpress.XtraGrid.Columns.GridColumn colcustPhnNo;
        private DevExpress.XtraGrid.Columns.GridColumn colcustCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colcustCity;
        private DevExpress.XtraGrid.Columns.GridColumn colcustAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colcustEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colcustCellingCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraGrid.Columns.GridColumn colcustCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colcustSalePrice;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView;
    }
}
