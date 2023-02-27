namespace AccountingMS
{
    partial class UCprdManufacture
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
            this.tblPrdManufactureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanPrdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanPrdSubId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanPrdMsurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmanQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoItemSEmanQuan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repoItemLEprdMsur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colprdId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelProducts = new DevExpress.XtraLayout.SimpleLabelItem();
            this.labelPrdManufacture = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdManufactureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSEmanQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLEprdMsur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPrdManufacture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // tblPrdManufactureBindingSource
            // 
            this.tblPrdManufactureBindingSource.DataSource = typeof(AccountingMS.tblPrdManufacture);
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataSource = typeof(AccountingMS.tblProduct);
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(700, 400);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.tblPrdManufactureBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(12, 37);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoItemLEprdMsur,
            this.repoItemSEmanQuan});
            this.gridControl2.Size = new System.Drawing.Size(336, 323);
            this.gridControl2.TabIndex = 6;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colmanPrdId,
            this.colmanPrdSubId,
            this.colmanPrdMsurId,
            this.colmanQuan});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colmanPrdId
            // 
            this.colmanPrdId.FieldName = "manPrdId";
            this.colmanPrdId.Name = "colmanPrdId";
            this.colmanPrdId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colmanPrdSubId
            // 
            this.colmanPrdSubId.AppearanceCell.Options.UseTextOptions = true;
            this.colmanPrdSubId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colmanPrdSubId.Caption = "الصنف";
            this.colmanPrdSubId.FieldName = "manPrdSubId";
            this.colmanPrdSubId.Name = "colmanPrdSubId";
            this.colmanPrdSubId.OptionsColumn.AllowEdit = false;
            this.colmanPrdSubId.OptionsColumn.AllowFocus = false;
            this.colmanPrdSubId.OptionsColumn.TabStop = false;
            this.colmanPrdSubId.Visible = true;
            this.colmanPrdSubId.VisibleIndex = 0;
            this.colmanPrdSubId.Width = 196;
            // 
            // colmanPrdMsurId
            // 
            this.colmanPrdMsurId.AppearanceCell.Options.UseTextOptions = true;
            this.colmanPrdMsurId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colmanPrdMsurId.Caption = "الوحدة";
            this.colmanPrdMsurId.FieldName = "manPrdMsurId";
            this.colmanPrdMsurId.Name = "colmanPrdMsurId";
            this.colmanPrdMsurId.Visible = true;
            this.colmanPrdMsurId.VisibleIndex = 1;
            this.colmanPrdMsurId.Width = 88;
            // 
            // colmanQuan
            // 
            this.colmanQuan.AppearanceCell.Options.UseTextOptions = true;
            this.colmanQuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colmanQuan.Caption = "الكمية";
            this.colmanQuan.ColumnEdit = this.repoItemSEmanQuan;
            this.colmanQuan.FieldName = "manQuan";
            this.colmanQuan.Name = "colmanQuan";
            this.colmanQuan.Visible = true;
            this.colmanQuan.VisibleIndex = 2;
            // 
            // repoItemSEmanQuan
            // 
            this.repoItemSEmanQuan.AutoHeight = false;
            this.repoItemSEmanQuan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoItemSEmanQuan.Mask.BeepOnError = true;
            this.repoItemSEmanQuan.Mask.EditMask = "###.#";
            this.repoItemSEmanQuan.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            65536});
            this.repoItemSEmanQuan.Name = "repoItemSEmanQuan";
            // 
            // repoItemLEprdMsur
            // 
            this.repoItemLEprdMsur.AutoHeight = false;
            this.repoItemLEprdMsur.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoItemLEprdMsur.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ppmMsurName", "Name1")});
            this.repoItemLEprdMsur.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.repoItemLEprdMsur.DisplayMember = "ppmMsurName";
            this.repoItemLEprdMsur.Name = "repoItemLEprdMsur";
            this.repoItemLEprdMsur.NullText = "";
            this.repoItemLEprdMsur.ShowHeader = false;
            this.repoItemLEprdMsur.ValueMember = "ppmId";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblProductBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(352, 37);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(336, 323);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colprdId,
            this.colprdNo,
            this.colprdName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Search;
            this.gridView1.OptionsFind.FindNullPrompt = "البحث";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 20;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colprdId
            // 
            this.colprdId.FieldName = "id";
            this.colprdId.Name = "colprdId";
            this.colprdId.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colprdNo
            // 
            this.colprdNo.Caption = "رقم الصنف";
            this.colprdNo.FieldName = "prdNo";
            this.colprdNo.Name = "colprdNo";
            this.colprdNo.Visible = true;
            this.colprdNo.VisibleIndex = 1;
            this.colprdNo.Width = 80;
            // 
            // colprdName
            // 
            this.colprdName.Caption = "رقم الصنف";
            this.colprdName.FieldName = "prdName";
            this.colprdName.Name = "colprdName";
            this.colprdName.Visible = true;
            this.colprdName.VisibleIndex = 2;
            this.colprdName.Width = 240;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(352, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(336, 24);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(12, 364);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(336, 24);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "إغلاف";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Root.AppearanceItemCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Options.UseForeColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.labelProducts,
            this.labelPrdManufacture,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(700, 400);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(340, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(340, 327);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(340, 327);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // labelProducts
            // 
            this.labelProducts.AllowHotTrack = false;
            this.labelProducts.Location = new System.Drawing.Point(340, 0);
            this.labelProducts.Name = "labelProducts";
            this.labelProducts.Size = new System.Drawing.Size(340, 25);
            this.labelProducts.Text = "الأصناف المتوفرة";
            this.labelProducts.TextSize = new System.Drawing.Size(159, 21);
            // 
            // labelPrdManufacture
            // 
            this.labelPrdManufacture.AllowHotTrack = false;
            this.labelPrdManufacture.Location = new System.Drawing.Point(0, 0);
            this.labelPrdManufacture.Name = "labelPrdManufacture";
            this.labelPrdManufacture.Size = new System.Drawing.Size(340, 25);
            this.labelPrdManufacture.Text = "مكونات الصنف الصناعي";
            this.labelPrdManufacture.TextSize = new System.Drawing.Size(159, 21);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSave;
            this.layoutControlItem3.Location = new System.Drawing.Point(340, 352);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(340, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 352);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(340, 28);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // UCprdManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCprdManufacture";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(700, 400);
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdManufactureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemSEmanQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoItemLEprdMsur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPrdManufacture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tblPrdManufactureBindingSource;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colprdId;
        private DevExpress.XtraGrid.Columns.GridColumn colprdNo;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colmanPrdId;
        private DevExpress.XtraGrid.Columns.GridColumn colmanPrdSubId;
        private DevExpress.XtraGrid.Columns.GridColumn colmanPrdMsurId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoItemLEprdMsur;
        private DevExpress.XtraGrid.Columns.GridColumn colmanQuan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleLabelItem labelProducts;
        private DevExpress.XtraLayout.SimpleLabelItem labelPrdManufacture;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoItemSEmanQuan;
    }
}
