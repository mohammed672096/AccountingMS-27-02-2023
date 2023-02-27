namespace AccountingMS
{
    partial class UCaccBanks
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
            this.tblAccountBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankAccNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankCelling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankAccIBAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccNoInBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankSwiftCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbankNameEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.tblAccountBanksBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gridControl.Location = new System.Drawing.Point(0, 149);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1067, 682);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // tblAccountBanksBindingSource
            // 
            this.tblAccountBanksBindingSource.DataSource = typeof(AccountingMS.tblAccountBank);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbankNo,
            this.colbankAccNo,
            this.colbankName,
            this.colbankCurrency,
            this.colbankCelling,
            this.colbankAccIBAN,
            this.colAccNoInBank,
            this.colbankSwiftCode,
            this.colbankNameEn});
            this.gridView.DetailHeight = 485;
            this.gridView.FixedLineWidth = 1;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            // 
            // colbankNo
            // 
            this.colbankNo.AppearanceCell.Options.UseTextOptions = true;
            this.colbankNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbankNo.Caption = "رقم البنك";
            this.colbankNo.FieldName = "bankNo";
            this.colbankNo.MinWidth = 27;
            this.colbankNo.Name = "colbankNo";
            this.colbankNo.Visible = true;
            this.colbankNo.VisibleIndex = 1;
            this.colbankNo.Width = 99;
            // 
            // colbankAccNo
            // 
            this.colbankAccNo.AppearanceCell.Options.UseTextOptions = true;
            this.colbankAccNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbankAccNo.Caption = "رقم حساب البنك";
            this.colbankAccNo.FieldName = "bankAccNo";
            this.colbankAccNo.MinWidth = 27;
            this.colbankAccNo.Name = "colbankAccNo";
            this.colbankAccNo.Visible = true;
            this.colbankAccNo.VisibleIndex = 0;
            this.colbankAccNo.Width = 99;
            // 
            // colbankName
            // 
            this.colbankName.Caption = "إسم البنك";
            this.colbankName.FieldName = "bankName";
            this.colbankName.MinWidth = 27;
            this.colbankName.Name = "colbankName";
            this.colbankName.Visible = true;
            this.colbankName.VisibleIndex = 2;
            this.colbankName.Width = 99;
            // 
            // colbankCurrency
            // 
            this.colbankCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colbankCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbankCurrency.Caption = "العملة";
            this.colbankCurrency.FieldName = "bankCurrency";
            this.colbankCurrency.MinWidth = 27;
            this.colbankCurrency.Name = "colbankCurrency";
            this.colbankCurrency.Visible = true;
            this.colbankCurrency.VisibleIndex = 4;
            this.colbankCurrency.Width = 99;
            // 
            // colbankCelling
            // 
            this.colbankCelling.AppearanceCell.Options.UseTextOptions = true;
            this.colbankCelling.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colbankCelling.Caption = "الحد الأدنى";
            this.colbankCelling.DisplayFormat.FormatString = "n2";
            this.colbankCelling.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colbankCelling.FieldName = "bankCelling";
            this.colbankCelling.MinWidth = 27;
            this.colbankCelling.Name = "colbankCelling";
            this.colbankCelling.Visible = true;
            this.colbankCelling.VisibleIndex = 5;
            this.colbankCelling.Width = 99;
            // 
            // colbankAccIBAN
            // 
            this.colbankAccIBAN.Caption = "IBAN";
            this.colbankAccIBAN.FieldName = "bankAccIBAN";
            this.colbankAccIBAN.MinWidth = 25;
            this.colbankAccIBAN.Name = "colbankAccIBAN";
            this.colbankAccIBAN.Visible = true;
            this.colbankAccIBAN.VisibleIndex = 7;
            this.colbankAccIBAN.Width = 99;
            // 
            // colAccNoInBank
            // 
            this.colAccNoInBank.Caption = "رقم الحساب البنكي";
            this.colAccNoInBank.DisplayFormat.FormatString = "d";
            this.colAccNoInBank.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAccNoInBank.FieldName = "AccNoInBank";
            this.colAccNoInBank.MinWidth = 25;
            this.colAccNoInBank.Name = "colAccNoInBank";
            this.colAccNoInBank.Visible = true;
            this.colAccNoInBank.VisibleIndex = 6;
            this.colAccNoInBank.Width = 99;
            // 
            // colbankSwiftCode
            // 
            this.colbankSwiftCode.Caption = "Swift Code";
            this.colbankSwiftCode.FieldName = "bankSwiftCode";
            this.colbankSwiftCode.MinWidth = 25;
            this.colbankSwiftCode.Name = "colbankSwiftCode";
            this.colbankSwiftCode.Visible = true;
            this.colbankSwiftCode.VisibleIndex = 8;
            this.colbankSwiftCode.Width = 99;
            // 
            // colbankNameEn
            // 
            this.colbankNameEn.Caption = "اسم البنك انجليزي";
            this.colbankNameEn.FieldName = "bankNameEn";
            this.colbankNameEn.MinWidth = 25;
            this.colbankNameEn.Name = "colbankNameEn";
            this.colbankNameEn.Visible = true;
            this.colbankNameEn.VisibleIndex = 3;
            this.colbankNameEn.Width = 94;
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(34, 39, 34, 39);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiRefresh,
            this.bbiDelete});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonControl.MaxItemId = 21;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 440;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1067, 149);
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
            this.bbiNew.Caption = "إضافة بنك\r\nF2";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.add_32x32;
            this.bbiNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "تعديل\r\nF4";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.Image = global::AccountingMS.Properties.Resources.edit_16x161;
            this.bbiEdit.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.edit_32x321;
            this.bbiEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
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
            // bbiDelete
            // 
            this.bbiDelete.Caption = "حذف\r\nF6";
            this.bbiDelete.Id = 20;
            this.bbiDelete.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.delete_32x32;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
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
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 803);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1067, 28);
            // 
            // UCaccBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UCaccBanks";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1067, 831);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountBanksBindingSource)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource tblAccountBanksBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colbankNo;
        private DevExpress.XtraGrid.Columns.GridColumn colbankAccNo;
        private DevExpress.XtraGrid.Columns.GridColumn colbankName;
        private DevExpress.XtraGrid.Columns.GridColumn colbankCelling;
        internal DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colbankCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colbankAccIBAN;
        private DevExpress.XtraGrid.Columns.GridColumn colAccNoInBank;
        private DevExpress.XtraGrid.Columns.GridColumn colbankSwiftCode;
        private DevExpress.XtraGrid.Columns.GridColumn colbankNameEn;
    }
}
