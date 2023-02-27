namespace AccountingMS
{
    partial class formDeleteProducts0
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblProductDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colppmBarcode11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colppmSalePrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchPrdPrice0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearhcPrdSalePrice0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelCount = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnSearchPrdPrice0);
            this.layoutControl1.Controls.Add(this.btnSearhcPrdSalePrice0);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(749, 652);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblProductDataBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gridControl1.Location = new System.Drawing.Point(16, 116);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(717, 462);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblProductDataBindingSource
            // 
            this.tblProductDataBindingSource.DataSource = typeof(AccountingMS.tblProductData);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colppmBarcode11,
            this.colprdName,
            this.colppmPrice1,
            this.colppmSalePrice1});
            this.gridView1.DetailHeight = 485;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colppmBarcode11
            // 
            this.colppmBarcode11.Caption = "الباركود";
            this.colppmBarcode11.FieldName = "ppmBarcode11";
            this.colppmBarcode11.MaxWidth = 147;
            this.colppmBarcode11.MinWidth = 27;
            this.colppmBarcode11.Name = "colppmBarcode11";
            this.colppmBarcode11.Visible = true;
            this.colppmBarcode11.VisibleIndex = 0;
            this.colppmBarcode11.Width = 100;
            // 
            // colprdName
            // 
            this.colprdName.Caption = "إسم الصنف";
            this.colprdName.FieldName = "prdName";
            this.colprdName.MinWidth = 27;
            this.colprdName.Name = "colprdName";
            this.colprdName.Visible = true;
            this.colprdName.VisibleIndex = 1;
            this.colprdName.Width = 100;
            // 
            // colppmPrice1
            // 
            this.colppmPrice1.AppearanceCell.Options.UseTextOptions = true;
            this.colppmPrice1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colppmPrice1.Caption = "سعر الشارء";
            this.colppmPrice1.FieldName = "ppmPrice1";
            this.colppmPrice1.MaxWidth = 100;
            this.colppmPrice1.MinWidth = 27;
            this.colppmPrice1.Name = "colppmPrice1";
            this.colppmPrice1.Visible = true;
            this.colppmPrice1.VisibleIndex = 2;
            this.colppmPrice1.Width = 100;
            // 
            // colppmSalePrice1
            // 
            this.colppmSalePrice1.AppearanceCell.Options.UseTextOptions = true;
            this.colppmSalePrice1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colppmSalePrice1.Caption = "سعر البيع";
            this.colppmSalePrice1.FieldName = "ppmSalePrice1";
            this.colppmSalePrice1.MaxWidth = 100;
            this.colppmSalePrice1.MinWidth = 27;
            this.colppmSalePrice1.Name = "colppmSalePrice1";
            this.colppmSalePrice1.Visible = true;
            this.colppmSalePrice1.VisibleIndex = 3;
            this.colppmSalePrice1.Width = 100;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(16, 17);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(717, 27);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "بحث الاصناف سعر الشارء = 0 سعر البيع = 0";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(16, 608);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(355, 27);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSearchPrdPrice0
            // 
            this.btnSearchPrdPrice0.Location = new System.Drawing.Point(16, 50);
            this.btnSearchPrdPrice0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchPrdPrice0.Name = "btnSearchPrdPrice0";
            this.btnSearchPrdPrice0.Size = new System.Drawing.Size(717, 27);
            this.btnSearchPrdPrice0.StyleController = this.layoutControl1;
            this.btnSearchPrdPrice0.TabIndex = 8;
            this.btnSearchPrdPrice0.Text = "بحث الاصناف سعر الشراء = 0";
            this.btnSearchPrdPrice0.Click += new System.EventHandler(this.BtnSearchPrdPrice0_Click);
            // 
            // btnSearhcPrdSalePrice0
            // 
            this.btnSearhcPrdSalePrice0.Location = new System.Drawing.Point(16, 83);
            this.btnSearhcPrdSalePrice0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearhcPrdSalePrice0.Name = "btnSearhcPrdSalePrice0";
            this.btnSearhcPrdSalePrice0.Size = new System.Drawing.Size(717, 27);
            this.btnSearhcPrdSalePrice0.StyleController = this.layoutControl1;
            this.btnSearhcPrdSalePrice0.TabIndex = 9;
            this.btnSearhcPrdSalePrice0.Text = "بحث الاصناف سعر البيع = 0";
            this.btnSearhcPrdSalePrice0.Click += new System.EventHandler(this.BtnSearhcPrdSalePrice0_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(377, 608);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(356, 27);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.labelCount,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(749, 652);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSearch;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(723, 33);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnDelete;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 591);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(361, 33);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 99);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(723, 468);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // labelCount
            // 
            this.labelCount.AllowHotTrack = false;
            this.labelCount.Location = new System.Drawing.Point(0, 567);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(723, 24);
            this.labelCount.TextSize = new System.Drawing.Size(99, 18);
            this.labelCount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSearchPrdPrice0;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(723, 33);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSearhcPrdSalePrice0;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(723, 33);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnPrint;
            this.layoutControlItem6.Location = new System.Drawing.Point(361, 591);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(362, 33);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // formDeleteProducts0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 652);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formDeleteProducts0";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDeleteProducts0";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource tblProductDataBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colppmBarcode11;
        private DevExpress.XtraGrid.Columns.GridColumn colprdName;
        private DevExpress.XtraGrid.Columns.GridColumn colppmPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colppmSalePrice1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleLabelItem labelCount;
        private DevExpress.XtraEditors.SimpleButton btnSearchPrdPrice0;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnSearhcPrdSalePrice0;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}