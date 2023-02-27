namespace AccountingMS
{
    partial class formAddPrdQtyOpnBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddPrdQtyOpnBatch));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.teStoreDate = new DevExpress.XtraEditors.TextEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bsCount = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.teGroupStr = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForStoreDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForGroupStr = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblProductQtyOpnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colqtyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdBarcodeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colqtyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyBranchId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqtyStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpLookUpEditPrdMsur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teStoreDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teGroupStr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGroupStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpLookUpEditPrdMsur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            resources.ApplyResources(this.ribbonPage2, "ribbonPage2");
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.teStoreDate);
            this.layoutControl1.Controls.Add(this.teGroupStr);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // teStoreDate
            // 
            resources.ApplyResources(this.teStoreDate, "teStoreDate");
            this.teStoreDate.MenuManager = this.ribbonControl1;
            this.teStoreDate.Name = "teStoreDate";
            this.teStoreDate.Properties.Mask.EditMask = resources.GetString("teStoreDate.Properties.Mask.EditMask");
            this.teStoreDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("teStoreDate.Properties.Mask.MaskType")));
            this.teStoreDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("teStoreDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.teStoreDate.StyleController = this.layoutControl1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.teStoreDate, conditionValidationRule1);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bbiSaveAndNew,
            this.bbiClose,
            this.bsCount});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiSave
            // 
            resources.ApplyResources(this.bbiSave, "bbiSave");
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            resources.ApplyResources(this.bbiSaveAndNew, "bbiSaveAndNew");
            this.bbiSaveAndNew.Id = 2;
            this.bbiSaveAndNew.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.saveas;
            this.bbiSaveAndNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndNew_ItemClick);
            // 
            // bbiClose
            // 
            resources.ApplyResources(this.bbiClose, "bbiClose");
            this.bbiClose.Id = 3;
            this.bbiClose.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bsCount
            // 
            this.bsCount.Id = 4;
            this.bsCount.Name = "bsCount";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSaveAndNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsCount);
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // teGroupStr
            // 
            resources.ApplyResources(this.teGroupStr, "teGroupStr");
            this.teGroupStr.MenuManager = this.ribbonControl1;
            this.teGroupStr.Name = "teGroupStr";
            this.teGroupStr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("teGroupStr.Properties.Buttons"))))});
            this.teGroupStr.Properties.NullText = resources.GetString("teGroupStr.Properties.NullText");
            this.teGroupStr.StyleController = this.layoutControl1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.teGroupStr, conditionValidationRule2);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup1.AppearanceGroup.Font")));
            this.layoutControlGroup1.AppearanceGroup.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceGroup.Options.UseForeColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup1.AppearanceItemCaption.Font")));
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(933, 108);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForStoreDate,
            this.ItemForGroupStr});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(933, 108);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            // 
            // ItemForStoreDate
            // 
            this.ItemForStoreDate.Control = this.teStoreDate;
            this.ItemForStoreDate.Location = new System.Drawing.Point(0, 0);
            this.ItemForStoreDate.Name = "ItemForStoreDate";
            this.ItemForStoreDate.Size = new System.Drawing.Size(913, 24);
            resources.ApplyResources(this.ItemForStoreDate, "ItemForStoreDate");
            this.ItemForStoreDate.TextSize = new System.Drawing.Size(74, 17);
            // 
            // ItemForGroupStr
            // 
            this.ItemForGroupStr.Control = this.teGroupStr;
            this.ItemForGroupStr.Location = new System.Drawing.Point(0, 24);
            this.ItemForGroupStr.Name = "ItemForGroupStr";
            this.ItemForGroupStr.Size = new System.Drawing.Size(913, 39);
            resources.ApplyResources(this.ItemForGroupStr, "ItemForGroupStr");
            this.ItemForGroupStr.TextSize = new System.Drawing.Size(74, 17);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblProductQtyOpnBindingSource;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpLookUpEditPrdMsur,
            this.repositoryItemSpinEditQuantity});
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblProductQtyOpnBindingSource
            // 
            this.tblProductQtyOpnBindingSource.DataSource = typeof(AccountingMS.tblProductQtyOpn);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(227)))));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colqtyId,
            this.colprdBarcodeNo,
            this.colqtyPrdId,
            this.colqtyPrdMsurId,
            this.colqtyPrice,
            this.colprdSalePrice,
            this.colqtyQuantity,
            this.colqtyDate,
            this.colqtyBranchId,
            this.colqtyStatus});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colqtyId
            // 
            this.colqtyId.FieldName = "qtyId";
            this.colqtyId.MinWidth = 23;
            this.colqtyId.Name = "colqtyId";
            resources.ApplyResources(this.colqtyId, "colqtyId");
            // 
            // colprdBarcodeNo
            // 
            resources.ApplyResources(this.colprdBarcodeNo, "colprdBarcodeNo");
            this.colprdBarcodeNo.FieldName = "prdBarcodeNo";
            this.colprdBarcodeNo.MinWidth = 23;
            this.colprdBarcodeNo.Name = "colprdBarcodeNo";
            // 
            // colqtyPrdId
            // 
            this.colqtyPrdId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colqtyPrdId, "colqtyPrdId");
            this.colqtyPrdId.FieldName = "qtyPrdId";
            this.colqtyPrdId.MinWidth = 23;
            this.colqtyPrdId.Name = "colqtyPrdId";
            this.colqtyPrdId.OptionsColumn.AllowEdit = false;
            this.colqtyPrdId.OptionsColumn.AllowFocus = false;
            this.colqtyPrdId.OptionsColumn.ReadOnly = true;
            // 
            // colqtyPrdMsurId
            // 
            this.colqtyPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colqtyPrdMsurId, "colqtyPrdMsurId");
            this.colqtyPrdMsurId.FieldName = "qtyPrdMsurId";
            this.colqtyPrdMsurId.MinWidth = 23;
            this.colqtyPrdMsurId.Name = "colqtyPrdMsurId";
            // 
            // colqtyPrice
            // 
            this.colqtyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colqtyPrice, "colqtyPrice");
            this.colqtyPrice.DisplayFormat.FormatString = "n3";
            this.colqtyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colqtyPrice.FieldName = "qtyPrice";
            this.colqtyPrice.MinWidth = 23;
            this.colqtyPrice.Name = "colqtyPrice";
            // 
            // colprdSalePrice
            // 
            this.colprdSalePrice.AppearanceCell.Options.UseTextOptions = true;
            this.colprdSalePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colprdSalePrice, "colprdSalePrice");
            this.colprdSalePrice.DisplayFormat.FormatString = "n2";
            this.colprdSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colprdSalePrice.FieldName = "prdSalePrice";
            this.colprdSalePrice.MinWidth = 23;
            this.colprdSalePrice.Name = "colprdSalePrice";
            this.colprdSalePrice.OptionsColumn.AllowEdit = false;
            this.colprdSalePrice.OptionsColumn.AllowFocus = false;
            this.colprdSalePrice.OptionsColumn.TabStop = false;
            // 
            // colqtyQuantity
            // 
            this.colqtyQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colqtyQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colqtyQuantity, "colqtyQuantity");
            this.colqtyQuantity.ColumnEdit = this.repositoryItemSpinEditQuantity;
            this.colqtyQuantity.FieldName = "qtyQuantity";
            this.colqtyQuantity.MinWidth = 23;
            this.colqtyQuantity.Name = "colqtyQuantity";
            // 
            // repositoryItemSpinEditQuantity
            // 
            resources.ApplyResources(this.repositoryItemSpinEditQuantity, "repositoryItemSpinEditQuantity");
            this.repositoryItemSpinEditQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemSpinEditQuantity.Buttons"))))});
            this.repositoryItemSpinEditQuantity.Mask.EditMask = resources.GetString("repositoryItemSpinEditQuantity.Mask.EditMask");
            this.repositoryItemSpinEditQuantity.Name = "repositoryItemSpinEditQuantity";
            // 
            // colqtyDate
            // 
            this.colqtyDate.FieldName = "qtyDate";
            this.colqtyDate.MinWidth = 23;
            this.colqtyDate.Name = "colqtyDate";
            resources.ApplyResources(this.colqtyDate, "colqtyDate");
            // 
            // colqtyBranchId
            // 
            this.colqtyBranchId.FieldName = "qtyBranchId";
            this.colqtyBranchId.MinWidth = 23;
            this.colqtyBranchId.Name = "colqtyBranchId";
            resources.ApplyResources(this.colqtyBranchId, "colqtyBranchId");
            // 
            // colqtyStatus
            // 
            this.colqtyStatus.FieldName = "qtyStatus";
            this.colqtyStatus.MinWidth = 23;
            this.colqtyStatus.Name = "colqtyStatus";
            resources.ApplyResources(this.colqtyStatus, "colqtyStatus");
            // 
            // rpLookUpEditPrdMsur
            // 
            resources.ApplyResources(this.rpLookUpEditPrdMsur, "rpLookUpEditPrdMsur");
            this.rpLookUpEditPrdMsur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rpLookUpEditPrdMsur.Buttons"))))});
            this.rpLookUpEditPrdMsur.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("rpLookUpEditPrdMsur.Columns"), resources.GetString("rpLookUpEditPrdMsur.Columns1"))});
            this.rpLookUpEditPrdMsur.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.rpLookUpEditPrdMsur.DisplayMember = "ppmMsurName";
            this.rpLookUpEditPrdMsur.Name = "rpLookUpEditPrdMsur";
            this.rpLookUpEditPrdMsur.ValueMember = "ppmId";
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // formAddPrdQtyOpnBatch
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "formAddPrdQtyOpnBatch";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teStoreDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teGroupStr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGroupStr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductQtyOpnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpLookUpEditPrdMsur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarStaticItem bsCount;
        private DevExpress.XtraEditors.TextEdit teStoreDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGroupStr;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreDate;
        private System.Windows.Forms.BindingSource tblProductQtyOpnBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrdMsurId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyBranchId;
        private DevExpress.XtraGrid.Columns.GridColumn colqtyStatus;
        private DevExpress.XtraEditors.LookUpEdit teGroupStr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpLookUpEditPrdMsur;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colprdBarcodeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colprdSalePrice;
    }
}