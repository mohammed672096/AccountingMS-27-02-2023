namespace AccountingMS
{
    partial class FormPrdBarcodeDuplicate
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblPrdMsurDuplicateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colppmId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmMsurName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbarcodeDuplicate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmBarcode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmBarcode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmBarcode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bsiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdMsurDuplicateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblPrdMsurDuplicateBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 115);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(958, 429);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblPrdMsurDuplicateBindingSource
            // 
            this.tblPrdMsurDuplicateBindingSource.DataSource = typeof(AccountingMS.tblPrdMsurDuplicate);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colppmId,
            this.colppmPrdId,
            this.colppmMsurName,
            this.colppmPrice,
            this.colppmSalePrice,
            this.colbarcodeDuplicate,
            this.colppmBarcode1,
            this.colppmBarcode2,
            this.colppmBarcode3,
            this.colppmStatus});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colbarcodeDuplicate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colppmId
            // 
            this.colppmId.FieldName = "ppmId";
            this.colppmId.MinWidth = 23;
            this.colppmId.Name = "colppmId";
            this.colppmId.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmId.Width = 87;
            // 
            // colppmPrdId
            // 
            this.colppmPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colppmPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colppmPrdId.Caption = "الصنف";
            this.colppmPrdId.FieldName = "ppmPrdId";
            this.colppmPrdId.MinWidth = 23;
            this.colppmPrdId.Name = "colppmPrdId";
            this.colppmPrdId.OptionsColumn.AllowEdit = false;
            this.colppmPrdId.OptionsColumn.AllowFocus = false;
            this.colppmPrdId.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmPrdId.OptionsColumn.TabStop = false;
            this.colppmPrdId.Visible = true;
            this.colppmPrdId.VisibleIndex = 0;
            this.colppmPrdId.Width = 87;
            // 
            // colppmMsurName
            // 
            this.colppmMsurName.Caption = "الوحدة";
            this.colppmMsurName.FieldName = "ppmMsurName";
            this.colppmMsurName.MinWidth = 23;
            this.colppmMsurName.Name = "colppmMsurName";
            this.colppmMsurName.OptionsColumn.AllowEdit = false;
            this.colppmMsurName.OptionsColumn.AllowFocus = false;
            this.colppmMsurName.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmMsurName.OptionsColumn.TabStop = false;
            this.colppmMsurName.Visible = true;
            this.colppmMsurName.VisibleIndex = 1;
            this.colppmMsurName.Width = 87;
            // 
            // colppmPrice
            // 
            this.colppmPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colppmPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colppmPrice.Caption = "سعر الشراء";
            this.colppmPrice.FieldName = "ppmPrice";
            this.colppmPrice.MinWidth = 23;
            this.colppmPrice.Name = "colppmPrice";
            this.colppmPrice.OptionsColumn.AllowEdit = false;
            this.colppmPrice.OptionsColumn.AllowFocus = false;
            this.colppmPrice.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmPrice.OptionsColumn.TabStop = false;
            this.colppmPrice.Visible = true;
            this.colppmPrice.VisibleIndex = 5;
            this.colppmPrice.Width = 87;
            // 
            // colppmSalePrice
            // 
            this.colppmSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colppmSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colppmSalePrice.Caption = "سعر البيع";
            this.colppmSalePrice.FieldName = "ppmSalePrice";
            this.colppmSalePrice.MinWidth = 23;
            this.colppmSalePrice.Name = "colppmSalePrice";
            this.colppmSalePrice.OptionsColumn.AllowEdit = false;
            this.colppmSalePrice.OptionsColumn.AllowFocus = false;
            this.colppmSalePrice.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmSalePrice.OptionsColumn.TabStop = false;
            this.colppmSalePrice.Visible = true;
            this.colppmSalePrice.VisibleIndex = 6;
            this.colppmSalePrice.Width = 87;
            // 
            // colbarcodeDuplicate
            // 
            this.colbarcodeDuplicate.Caption = "الباركود";
            this.colbarcodeDuplicate.FieldName = "barcodeDuplicate";
            this.colbarcodeDuplicate.MinWidth = 23;
            this.colbarcodeDuplicate.Name = "colbarcodeDuplicate";
            this.colbarcodeDuplicate.OptionsColumn.AllowEdit = false;
            this.colbarcodeDuplicate.OptionsColumn.AllowFocus = false;
            this.colbarcodeDuplicate.OptionsColumn.ShowInCustomizationForm = false;
            this.colbarcodeDuplicate.OptionsColumn.TabStop = false;
            this.colbarcodeDuplicate.Visible = true;
            this.colbarcodeDuplicate.VisibleIndex = 2;
            this.colbarcodeDuplicate.Width = 87;
            // 
            // colppmBarcode1
            // 
            this.colppmBarcode1.Caption = "الباركود 1";
            this.colppmBarcode1.FieldName = "ppmBarcode1";
            this.colppmBarcode1.MinWidth = 23;
            this.colppmBarcode1.Name = "colppmBarcode1";
            this.colppmBarcode1.Visible = true;
            this.colppmBarcode1.VisibleIndex = 2;
            this.colppmBarcode1.Width = 87;
            // 
            // colppmBarcode2
            // 
            this.colppmBarcode2.Caption = "الباركود 2";
            this.colppmBarcode2.FieldName = "ppmBarcode2";
            this.colppmBarcode2.MinWidth = 23;
            this.colppmBarcode2.Name = "colppmBarcode2";
            this.colppmBarcode2.Visible = true;
            this.colppmBarcode2.VisibleIndex = 3;
            this.colppmBarcode2.Width = 87;
            // 
            // colppmBarcode3
            // 
            this.colppmBarcode3.Caption = "الباركود 3";
            this.colppmBarcode3.FieldName = "ppmBarcode3";
            this.colppmBarcode3.MinWidth = 23;
            this.colppmBarcode3.Name = "colppmBarcode3";
            this.colppmBarcode3.Visible = true;
            this.colppmBarcode3.VisibleIndex = 4;
            this.colppmBarcode3.Width = 87;
            // 
            // colppmStatus
            // 
            this.colppmStatus.FieldName = "ppmStatus";
            this.colppmStatus.MinWidth = 23;
            this.colppmStatus.Name = "colppmStatus";
            this.colppmStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.colppmStatus.Width = 87;
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bsiPrint});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(958, 115);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bsiPrint
            // 
            this.bsiPrint.Caption = "طباعة";
            this.bsiPrint.Id = 2;
            this.bsiPrint.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.print;
            this.bsiPrint.Name = "bsiPrint";
            this.bsiPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiPrint_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bsiPrint);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // FormPrdBarcodeDuplicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 544);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FormPrdBarcodeDuplicate";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الباركود المتكرر";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdMsurDuplicateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colppmId;
        private DevExpress.XtraGrid.Columns.GridColumn colppmPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colppmMsurName;
        private DevExpress.XtraGrid.Columns.GridColumn colppmPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colppmSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colppmBarcode1;
        private DevExpress.XtraGrid.Columns.GridColumn colppmBarcode2;
        private DevExpress.XtraGrid.Columns.GridColumn colppmBarcode3;
        private DevExpress.XtraGrid.Columns.GridColumn colppmStatus;
        private System.Windows.Forms.BindingSource tblPrdMsurDuplicateBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colbarcodeDuplicate;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bsiPrint;
    }
}