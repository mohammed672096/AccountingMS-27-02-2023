
namespace AccountingMS.Forms.HR
{
    partial class FormalHoliday
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormalHoliday));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.holidayEmpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holidayNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dateAncestorDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.reasonTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.empIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.balanceTextEdit = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForholidayName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemFordateAncestor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForreason = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForbalance = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForempID = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldateAncestor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colempID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayEmpBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForholidayName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.holidayNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.dateAncestorDateEdit);
            this.dataLayoutControl1.Controls.Add(this.reasonTextEdit);
            this.dataLayoutControl1.Controls.Add(this.empIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.balanceTextEdit);
            this.dataLayoutControl1.DataSource = this.holidayEmpBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(357, 565);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(12, 12);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.idTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.idTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.idTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.idTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.idTextEdit.Properties.ReadOnly = true;
            this.idTextEdit.Size = new System.Drawing.Size(256, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // holidayEmpBindingSource
            // 
            this.holidayEmpBindingSource.DataSource = typeof(AccountingMS.HolidayEmp);
            // 
            // holidayNameTextEdit
            // 
            this.holidayNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "holidayName", true));
            this.holidayNameTextEdit.Location = new System.Drawing.Point(12, 60);
            this.holidayNameTextEdit.Name = "holidayNameTextEdit";
            this.holidayNameTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.holidayNameTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.holidayNameTextEdit.Size = new System.Drawing.Size(256, 20);
            this.holidayNameTextEdit.StyleController = this.dataLayoutControl1;
            this.holidayNameTextEdit.TabIndex = 5;
            // 
            // dateAncestorDateEdit
            // 
            this.dateAncestorDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "dateAncestor", true));
            this.dateAncestorDateEdit.EditValue = null;
            this.dateAncestorDateEdit.Location = new System.Drawing.Point(12, 84);
            this.dateAncestorDateEdit.Name = "dateAncestorDateEdit";
            this.dateAncestorDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateAncestorDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAncestorDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAncestorDateEdit.Size = new System.Drawing.Size(256, 20);
            this.dateAncestorDateEdit.StyleController = this.dataLayoutControl1;
            this.dateAncestorDateEdit.TabIndex = 6;
            // 
            // reasonTextEdit
            // 
            this.reasonTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "reason", true));
            this.reasonTextEdit.Location = new System.Drawing.Point(12, 108);
            this.reasonTextEdit.Name = "reasonTextEdit";
            this.reasonTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.reasonTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.reasonTextEdit.Size = new System.Drawing.Size(256, 20);
            this.reasonTextEdit.StyleController = this.dataLayoutControl1;
            this.reasonTextEdit.TabIndex = 7;
            // 
            // empIDTextEdit
            // 
            this.empIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "empID", true));
            this.empIDTextEdit.Location = new System.Drawing.Point(12, 36);
            this.empIDTextEdit.Name = "empIDTextEdit";
            this.empIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.empIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.empIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.empIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.empIDTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("empName", "emp Name", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.empIDTextEdit.Properties.DataSource = this.tblEmployeeBindingSource;
            this.empIDTextEdit.Properties.DisplayMember = "empName";
            this.empIDTextEdit.Properties.NullText = "";
            this.empIDTextEdit.Properties.ShowFooter = false;
            this.empIDTextEdit.Properties.ShowHeader = false;
            this.empIDTextEdit.Properties.ShowLines = false;
            this.empIDTextEdit.Properties.ValueMember = "id";
            this.empIDTextEdit.Size = new System.Drawing.Size(256, 20);
            this.empIDTextEdit.StyleController = this.dataLayoutControl1;
            this.empIDTextEdit.TabIndex = 8;
            this.empIDTextEdit.EditValueChanged += new System.EventHandler(this.empIDTextEdit_EditValueChanged);
            // 
            // tblEmployeeBindingSource
            // 
            this.tblEmployeeBindingSource.DataSource = typeof(AccountingMS.tblEmployee);
            // 
            // balanceTextEdit
            // 
            this.balanceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.holidayEmpBindingSource, "balance", true));
            this.balanceTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.balanceTextEdit.Location = new System.Drawing.Point(12, 132);
            this.balanceTextEdit.Name = "balanceTextEdit";
            this.balanceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.balanceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.balanceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.balanceTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.balanceTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.balanceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.balanceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.balanceTextEdit.Properties.MaskSettings.Set("mask", "N0");
            this.balanceTextEdit.Properties.ReadOnly = true;
            this.balanceTextEdit.Size = new System.Drawing.Size(256, 20);
            this.balanceTextEdit.StyleController = this.dataLayoutControl1;
            this.balanceTextEdit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(357, 565);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForholidayName,
            this.ItemFordateAncestor,
            this.ItemForreason,
            this.ItemForbalance,
            this.ItemForempID});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(337, 545);
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(337, 24);
            this.ItemForid.Text = "الكود";
            this.ItemForid.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForholidayName
            // 
            this.ItemForholidayName.Control = this.holidayNameTextEdit;
            this.ItemForholidayName.Location = new System.Drawing.Point(0, 48);
            this.ItemForholidayName.Name = "ItemForholidayName";
            this.ItemForholidayName.Size = new System.Drawing.Size(337, 24);
            this.ItemForholidayName.Text = "اسم الاجازه";
            this.ItemForholidayName.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemFordateAncestor
            // 
            this.ItemFordateAncestor.Control = this.dateAncestorDateEdit;
            this.ItemFordateAncestor.Location = new System.Drawing.Point(0, 72);
            this.ItemFordateAncestor.Name = "ItemFordateAncestor";
            this.ItemFordateAncestor.Size = new System.Drawing.Size(337, 24);
            this.ItemFordateAncestor.Text = "التاريخ";
            this.ItemFordateAncestor.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForreason
            // 
            this.ItemForreason.Control = this.reasonTextEdit;
            this.ItemForreason.Location = new System.Drawing.Point(0, 96);
            this.ItemForreason.Name = "ItemForreason";
            this.ItemForreason.Size = new System.Drawing.Size(337, 24);
            this.ItemForreason.Text = "السبب";
            this.ItemForreason.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForbalance
            // 
            this.ItemForbalance.Control = this.balanceTextEdit;
            this.ItemForbalance.Location = new System.Drawing.Point(0, 120);
            this.ItemForbalance.Name = "ItemForbalance";
            this.ItemForbalance.Size = new System.Drawing.Size(337, 425);
            this.ItemForbalance.Text = "رصيد الموظف";
            this.ItemForbalance.TextSize = new System.Drawing.Size(65, 14);
            // 
            // ItemForempID
            // 
            this.ItemForempID.Control = this.empIDTextEdit;
            this.ItemForempID.Location = new System.Drawing.Point(0, 24);
            this.ItemForempID.Name = "ItemForempID";
            this.ItemForempID.Size = new System.Drawing.Size(337, 24);
            this.ItemForempID.Text = "اسم الموظف";
            this.ItemForempID.TextSize = new System.Drawing.Size(65, 14);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.holidayEmpBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(357, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(582, 565);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.coldateAncestor,
            this.colempID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colid
            // 
            this.colid.Caption = "الكود";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // coldateAncestor
            // 
            this.coldateAncestor.Caption = "التاريخ";
            this.coldateAncestor.FieldName = "dateAncestor";
            this.coldateAncestor.Name = "coldateAncestor";
            this.coldateAncestor.Visible = true;
            this.coldateAncestor.VisibleIndex = 1;
            // 
            // colempID
            // 
            this.colempID.Caption = "اسم الموظف";
            this.colempID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colempID.FieldName = "empID";
            this.colempID.Name = "colempID";
            this.colempID.Visible = true;
            this.colempID.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, false, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("empName", "emp Name", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.tblEmployeeBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "empName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ShowLines = false;
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // FormalHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 616);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FormalHoliday.IconOptions.Image")));
            this.Name = "FormalHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاجازات السنوية";
            this.Load += new System.EventHandler(this.FormalHoliday_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayEmpBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAncestorDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reasonTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForholidayName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemFordateAncestor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForreason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForbalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForempID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource holidayEmpBindingSource;
        private DevExpress.XtraEditors.TextEdit holidayNameTextEdit;
        private DevExpress.XtraEditors.DateEdit dateAncestorDateEdit;
        private DevExpress.XtraEditors.TextEdit reasonTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForholidayName;
        private DevExpress.XtraLayout.LayoutControlItem ItemFordateAncestor;
        private DevExpress.XtraLayout.LayoutControlItem ItemForreason;
        private DevExpress.XtraLayout.LayoutControlItem ItemForempID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForbalance;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn coldateAncestor;
        private DevExpress.XtraGrid.Columns.GridColumn colempID;
        private DevExpress.XtraEditors.LookUpEdit empIDTextEdit;
        private System.Windows.Forms.BindingSource tblEmployeeBindingSource;
        private DevExpress.XtraEditors.SpinEdit balanceTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}