
namespace AccountingMS.Forms
{
    partial class FrmRepCommission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepCommission));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.repCommissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colisActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DisplayNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.commissionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NotesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.isActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDisplayName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcommission = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNotes = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForisActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCommissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isActiveCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDisplayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForisActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl1.Size = new System.Drawing.Size(758, 162);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "جديد";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "حفظ";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "تحديث";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "حذف";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "طباعة";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem5.ImageOptions.SvgImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "اغلاق";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem6.ImageOptions.SvgImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "حفظ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "طباعة";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DisplayNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.commissionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NotesTextEdit);
            this.dataLayoutControl1.Controls.Add(this.isActiveCheckEdit);
            this.dataLayoutControl1.DataSource = this.repCommissionBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 162);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 249, 650, 400);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(758, 318);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.CausesValidation = false;
            this.gridControl1.DataSource = this.repCommissionBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 84);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 222);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // repCommissionBindingSource
            // 
            this.repCommissionBindingSource.DataSource = typeof(AccountingMS.RepCommission);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colDisplayName,
            this.colcommission,
            this.colNotes,
            this.colisActive});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colid
            // 
            this.colid.Caption = "الكود";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colDisplayName
            // 
            this.colDisplayName.Caption = "اسم العرض";
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 1;
            // 
            // colcommission
            // 
            this.colcommission.Caption = "نسبة العمولة";
            this.colcommission.FieldName = "commission";
            this.colcommission.Name = "colcommission";
            this.colcommission.Visible = true;
            this.colcommission.VisibleIndex = 2;
            // 
            // colNotes
            // 
            this.colNotes.Caption = "ملاحظات";
            this.colNotes.FieldName = "Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.Visible = true;
            this.colNotes.VisibleIndex = 3;
            // 
            // colisActive
            // 
            this.colisActive.Caption = "تفعيل العرض";
            this.colisActive.FieldName = "isActive";
            this.colisActive.Name = "colisActive";
            this.colisActive.Visible = true;
            this.colisActive.VisibleIndex = 4;
            // 
            // idTextEdit
            // 
            this.idTextEdit.CausesValidation = false;
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.repCommissionBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(551, 12);
            this.idTextEdit.MenuManager = this.ribbonControl1;
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.idTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.idTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.idTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.idTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.idTextEdit.Properties.ReadOnly = true;
            this.idTextEdit.Size = new System.Drawing.Size(118, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // DisplayNameTextEdit
            // 
            this.DisplayNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.repCommissionBindingSource, "DisplayName", true));
            this.DisplayNameTextEdit.Location = new System.Drawing.Point(268, 36);
            this.DisplayNameTextEdit.MenuManager = this.ribbonControl1;
            this.DisplayNameTextEdit.Name = "DisplayNameTextEdit";
            this.DisplayNameTextEdit.Size = new System.Drawing.Size(401, 20);
            this.DisplayNameTextEdit.StyleController = this.dataLayoutControl1;
            this.DisplayNameTextEdit.TabIndex = 9;
            // 
            // commissionTextEdit
            // 
            this.commissionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.repCommissionBindingSource, "commission", true));
            this.commissionTextEdit.EditValue = "0";
            this.commissionTextEdit.Location = new System.Drawing.Point(12, 36);
            this.commissionTextEdit.MenuManager = this.ribbonControl1;
            this.commissionTextEdit.Name = "commissionTextEdit";
            this.commissionTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.commissionTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.commissionTextEdit.Properties.BeepOnError = false;
            this.commissionTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.commissionTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.commissionTextEdit.Properties.MaskSettings.Set("mask", "p");
            this.commissionTextEdit.Size = new System.Drawing.Size(175, 20);
            this.commissionTextEdit.StyleController = this.dataLayoutControl1;
            this.commissionTextEdit.TabIndex = 10;
            // 
            // NotesTextEdit
            // 
            this.NotesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.repCommissionBindingSource, "Notes", true));
            this.NotesTextEdit.Location = new System.Drawing.Point(177, 60);
            this.NotesTextEdit.MenuManager = this.ribbonControl1;
            this.NotesTextEdit.Name = "NotesTextEdit";
            this.NotesTextEdit.Size = new System.Drawing.Size(492, 20);
            this.NotesTextEdit.StyleController = this.dataLayoutControl1;
            this.NotesTextEdit.TabIndex = 11;
            // 
            // isActiveCheckEdit
            // 
            this.isActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.repCommissionBindingSource, "isActive", true));
            this.isActiveCheckEdit.EditValue = true;
            this.isActiveCheckEdit.Location = new System.Drawing.Point(12, 60);
            this.isActiveCheckEdit.MenuManager = this.ribbonControl1;
            this.isActiveCheckEdit.Name = "isActiveCheckEdit";
            this.isActiveCheckEdit.Properties.Caption = "تفعيل العرض";
            this.isActiveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.isActiveCheckEdit.Size = new System.Drawing.Size(161, 20);
            this.isActiveCheckEdit.StyleController = this.dataLayoutControl1;
            this.isActiveCheckEdit.TabIndex = 12;
            this.isActiveCheckEdit.CheckedChanged += new System.EventHandler(this.isActiveCheckEdit_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(758, 318);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.layoutControlItem1,
            this.ItemForDisplayName,
            this.ItemForcommission,
            this.ItemForNotes,
            this.ItemForisActive,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(738, 298);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(539, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(199, 24);
            this.ItemForid.Text = "id";
            this.ItemForid.TextSize = new System.Drawing.Size(65, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(738, 226);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForDisplayName
            // 
            this.ItemForDisplayName.Control = this.DisplayNameTextEdit;
            this.ItemForDisplayName.Location = new System.Drawing.Point(256, 24);
            this.ItemForDisplayName.Name = "ItemForDisplayName";
            this.ItemForDisplayName.Size = new System.Drawing.Size(482, 24);
            this.ItemForDisplayName.Text = "اسم العرض";
            this.ItemForDisplayName.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForcommission
            // 
            this.ItemForcommission.Control = this.commissionTextEdit;
            this.ItemForcommission.Location = new System.Drawing.Point(0, 24);
            this.ItemForcommission.Name = "ItemForcommission";
            this.ItemForcommission.Size = new System.Drawing.Size(256, 24);
            this.ItemForcommission.Text = "نسبة العمولة";
            this.ItemForcommission.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForNotes
            // 
            this.ItemForNotes.Control = this.NotesTextEdit;
            this.ItemForNotes.Location = new System.Drawing.Point(165, 48);
            this.ItemForNotes.Name = "ItemForNotes";
            this.ItemForNotes.Size = new System.Drawing.Size(573, 24);
            this.ItemForNotes.Text = "ملاحظات";
            this.ItemForNotes.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForisActive
            // 
            this.ItemForisActive.Control = this.isActiveCheckEdit;
            this.ItemForisActive.Location = new System.Drawing.Point(0, 48);
            this.ItemForisActive.Name = "ItemForisActive";
            this.ItemForisActive.Size = new System.Drawing.Size(165, 24);
            this.ItemForisActive.Text = "is Active";
            this.ItemForisActive.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForisActive.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(539, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmRepCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 480);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRepCommission";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حساب العمولة على المنتج";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCommissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isActiveCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDisplayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForisActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource repCommissionBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit DisplayNameTextEdit;
        private DevExpress.XtraEditors.TextEdit commissionTextEdit;
        private DevExpress.XtraEditors.TextEdit NotesTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDisplayName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcommission;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNotes;
        private DevExpress.XtraEditors.CheckEdit isActiveCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForisActive;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colcommission;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colisActive;
    }
}