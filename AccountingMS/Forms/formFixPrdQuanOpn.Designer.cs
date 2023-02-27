namespace AccountingMS
{
    partial class formFixPrdQuanOpn
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
            this.tblProductQtyOpnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colqtyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdBarcodeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemLookUpEditPrdMsur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLookUpEditPrdMsur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblProductQtyOpnBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemLookUpEditPrdMsur});
            this.gridControl1.Size = new System.Drawing.Size(809, 428);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblProductQtyOpnBindingSource
            // 
            this.tblProductQtyOpnBindingSource.DataSource = typeof(AccountingMS.tblProductQtyOpn);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colqtyId,
            this.colqtyPrdId,
            this.colqtyPrdMsurId,
            this.colqtyPrice,
            this.colqtyQuantity,
            this.colprdBarcodeNo,
            this.colqtyDate,
            this.colqtyBranchId,
            this.colqtyStatus});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colqtyId
            // 
            this.colqtyId.FieldName = "qtyId";
            this.colqtyId.MinWidth = 23;
            this.colqtyId.Name = "colqtyId";
            this.colqtyId.Width = 87;
            // 
            // colqtyPrdId
            // 
            this.colqtyPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrdId.Caption = "الصنف";
            this.colqtyPrdId.FieldName = "qtyPrdId";
            this.colqtyPrdId.MinWidth = 23;
            this.colqtyPrdId.Name = "colqtyPrdId";
            this.colqtyPrdId.OptionsColumn.AllowEdit = false;
            this.colqtyPrdId.OptionsColumn.AllowFocus = false;
            this.colqtyPrdId.OptionsColumn.ReadOnly = true;
            this.colqtyPrdId.OptionsColumn.TabStop = false;
            this.colqtyPrdId.Visible = true;
            this.colqtyPrdId.VisibleIndex = 0;
            this.colqtyPrdId.Width = 87;
            // 
            // colqtyPrdMsurId
            // 
            this.colqtyPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrdMsurId.Caption = "الوحدة";
            this.colqtyPrdMsurId.FieldName = "qtyPrdMsurId";
            this.colqtyPrdMsurId.MinWidth = 23;
            this.colqtyPrdMsurId.Name = "colqtyPrdMsurId";
            this.colqtyPrdMsurId.Visible = true;
            this.colqtyPrdMsurId.VisibleIndex = 1;
            this.colqtyPrdMsurId.Width = 87;
            // 
            // colqtyPrice
            // 
            this.colqtyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyPrice.Caption = "سعر الشراء";
            this.colqtyPrice.FieldName = "qtyPrice";
            this.colqtyPrice.MinWidth = 23;
            this.colqtyPrice.Name = "colqtyPrice";
            this.colqtyPrice.OptionsColumn.AllowEdit = false;
            this.colqtyPrice.OptionsColumn.AllowFocus = false;
            this.colqtyPrice.OptionsColumn.ReadOnly = true;
            this.colqtyPrice.OptionsColumn.TabStop = false;
            this.colqtyPrice.Visible = true;
            this.colqtyPrice.VisibleIndex = 2;
            this.colqtyPrice.Width = 87;
            // 
            // colqtyQuantity
            // 
            this.colqtyQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colqtyQuantity.Caption = "الكميه";
            this.colqtyQuantity.FieldName = "qtyQuantity";
            this.colqtyQuantity.MinWidth = 23;
            this.colqtyQuantity.Name = "colqtyQuantity";
            this.colqtyQuantity.OptionsColumn.AllowEdit = false;
            this.colqtyQuantity.OptionsColumn.AllowFocus = false;
            this.colqtyQuantity.OptionsColumn.ReadOnly = true;
            this.colqtyQuantity.OptionsColumn.TabStop = false;
            this.colqtyQuantity.Visible = true;
            this.colqtyQuantity.VisibleIndex = 3;
            this.colqtyQuantity.Width = 87;
            // 
            // colprdBarcodeNo
            // 
            this.colprdBarcodeNo.Caption = "Count";
            this.colprdBarcodeNo.FieldName = "prdBarcodeNo";
            this.colprdBarcodeNo.MinWidth = 23;
            this.colprdBarcodeNo.Name = "colprdBarcodeNo";
            this.colprdBarcodeNo.OptionsColumn.AllowEdit = false;
            this.colprdBarcodeNo.OptionsColumn.AllowFocus = false;
            this.colprdBarcodeNo.OptionsColumn.ReadOnly = true;
            this.colprdBarcodeNo.OptionsColumn.TabStop = false;
            this.colprdBarcodeNo.Visible = true;
            this.colprdBarcodeNo.VisibleIndex = 4;
            this.colprdBarcodeNo.Width = 87;
            // 
            // colqtyDate
            // 
            this.colqtyDate.FieldName = "qtyDate";
            this.colqtyDate.MinWidth = 23;
            this.colqtyDate.Name = "colqtyDate";
            this.colqtyDate.Width = 87;
            // 
            // colqtyBranchId
            // 
            this.colqtyBranchId.FieldName = "qtyBranchId";
            this.colqtyBranchId.MinWidth = 23;
            this.colqtyBranchId.Name = "colqtyBranchId";
            this.colqtyBranchId.Width = 87;
            // 
            // colqtyStatus
            // 
            this.colqtyStatus.FieldName = "qtyStatus";
            this.colqtyStatus.MinWidth = 23;
            this.colqtyStatus.Name = "colqtyStatus";
            this.colqtyStatus.Width = 87;
            // 
            // repoItemLookUpEditPrdMsur
            // 
            this.repoItemLookUpEditPrdMsur.AutoHeight = false;
            this.repoItemLookUpEditPrdMsur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoItemLookUpEditPrdMsur.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ppmMsurName", "Name1", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repoItemLookUpEditPrdMsur.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.repoItemLookUpEditPrdMsur.DisplayMember = "ppmMsurName";
            this.repoItemLookUpEditPrdMsur.Name = "repoItemLookUpEditPrdMsur";
            this.repoItemLookUpEditPrdMsur.ShowHeader = false;
            this.repoItemLookUpEditPrdMsur.ValueMember = "ppmId";
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // ribbonControl1
            // 
            //this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(809, 63);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
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
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // formFixPrdQuanOpn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 491);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "formFixPrdQuanOpn";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "formFixPrdQuanOpn";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLookUpEditPrdMsur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource tblProductQtyOpnBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colprdBarcodeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoItemLookUpEditPrdMsur;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
    }
}