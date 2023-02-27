namespace PosFinalCost.Forms
{
    partial class UC_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Master));
            this.bindingNavigator11 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.Movefirst = new System.Windows.Forms.ToolStripButton();
            this.Moveprevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox7 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.Movenext = new System.Windows.Forms.ToolStripButton();
            this.Movelast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnUpdatePermission = new System.Windows.Forms.ToolStripButton();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).BeginInit();
            this.bindingNavigator11.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator11
            // 
            this.bindingNavigator11.AddNewItem = this.btnAddNew;
            this.bindingNavigator11.AutoSize = false;
            this.bindingNavigator11.CountItem = this.toolStripLabel7;
            this.bindingNavigator11.DeleteItem = null;
            this.bindingNavigator11.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Movefirst,
            this.Moveprevious,
            this.toolStripSeparator19,
            this.toolStripTextBox7,
            this.toolStripLabel7,
            this.toolStripSeparator20,
            this.Movenext,
            this.Movelast,
            this.toolStripSeparator21,
            this.btnAddNew,
            this.btnSave,
            this.btnUpdatePermission,
            this.btnReset,
            this.btnUpdate,
            this.btnPrint,
            this.btnDelete,
            this.btnRefresh,
            this.btnClose});
            this.bindingNavigator11.Location = new System.Drawing.Point(5, 5);
            this.bindingNavigator11.MaximumSize = new System.Drawing.Size(0, 50);
            this.bindingNavigator11.MinimumSize = new System.Drawing.Size(0, 45);
            this.bindingNavigator11.MoveFirstItem = this.Movefirst;
            this.bindingNavigator11.MoveLastItem = this.Movelast;
            this.bindingNavigator11.MoveNextItem = this.Movenext;
            this.bindingNavigator11.MovePreviousItem = this.Moveprevious;
            this.bindingNavigator11.Name = "bindingNavigator11";
            this.bindingNavigator11.PositionItem = this.toolStripTextBox7;
            this.bindingNavigator11.Size = new System.Drawing.Size(1379, 50);
            this.bindingNavigator11.TabIndex = 5;
            this.bindingNavigator11.Text = "bindingNavigator2";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNew.ForeColor = System.Drawing.Color.Black;
            this.btnAddNew.Image = global::PosFinalCost.Properties.Resources.add_32x32;
            this.btnAddNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.RightToLeftAutoMirrorImage = true;
            this.btnAddNew.Size = new System.Drawing.Size(100, 60);
            this.btnAddNew.Text = "Add New(F2)";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(45, 57);
            this.toolStripLabel7.Text = "of {0}";
            this.toolStripLabel7.ToolTipText = "Total number of items";
            // 
            // Movefirst
            // 
            this.Movefirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Movefirst.Image = ((System.Drawing.Image)(resources.GetObject("Movefirst.Image")));
            this.Movefirst.Name = "Movefirst";
            this.Movefirst.RightToLeftAutoMirrorImage = true;
            this.Movefirst.Size = new System.Drawing.Size(29, 47);
            this.Movefirst.Text = "Move first";
            // 
            // Moveprevious
            // 
            this.Moveprevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Moveprevious.Image = ((System.Drawing.Image)(resources.GetObject("Moveprevious.Image")));
            this.Moveprevious.Name = "Moveprevious";
            this.Moveprevious.RightToLeftAutoMirrorImage = true;
            this.Moveprevious.Size = new System.Drawing.Size(29, 57);
            this.Moveprevious.Text = "Move previous";
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 60);
            // 
            // toolStripTextBox7
            // 
            this.toolStripTextBox7.AccessibleName = "Position";
            this.toolStripTextBox7.AutoSize = false;
            this.toolStripTextBox7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox7.Name = "toolStripTextBox7";
            this.toolStripTextBox7.Size = new System.Drawing.Size(111, 79);
            this.toolStripTextBox7.Text = "0";
            this.toolStripTextBox7.ToolTipText = "Current position";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 60);
            // 
            // Movenext
            // 
            this.Movenext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Movenext.Image = ((System.Drawing.Image)(resources.GetObject("Movenext.Image")));
            this.Movenext.Name = "Movenext";
            this.Movenext.RightToLeftAutoMirrorImage = true;
            this.Movenext.Size = new System.Drawing.Size(29, 57);
            this.Movenext.Text = "Move next";
            // 
            // Movelast
            // 
            this.Movelast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Movelast.Image = ((System.Drawing.Image)(resources.GetObject("Movelast.Image")));
            this.Movelast.Name = "Movelast";
            this.Movelast.RightToLeftAutoMirrorImage = true;
            this.Movelast.Size = new System.Drawing.Size(29, 57);
            this.Movelast.Text = "Move last";
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 60);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 60);
            this.btnSave.Text = "Save(F3)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdatePermission.Enabled = false;
            this.btnUpdatePermission.ForeColor = System.Drawing.Color.Black;
            this.btnUpdatePermission.Image = global::PosFinalCost.Properties.Resources.bopermission_32x32;
            this.btnUpdatePermission.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdatePermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdatePermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.Size = new System.Drawing.Size(166, 60);
            this.btnUpdatePermission.Text = "تعديل اذونات الصلاحيات";
            this.btnUpdatePermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpdatePermission.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Enabled = false;
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Image = global::PosFinalCost.Properties.Resources.reset_32x32;
            this.btnReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 60);
            this.btnReset.Text = "Reset(F5)";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Image = global::PosFinalCost.Properties.Resources.editcontact_32x32;
            this.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RightToLeftAutoMirrorImage = true;
            this.btnUpdate.Size = new System.Drawing.Size(87, 60);
            this.btnUpdate.Text = "Update(F4)";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 60);
            this.btnPrint.Text = "Print(F7)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeftAutoMirrorImage = true;
            this.btnDelete.Size = new System.Drawing.Size(82, 60);
            this.btnDelete.Text = "Delete(F6)";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 60);
            this.btnRefresh.Text = "Refresh(F1)";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::PosFinalCost.Properties.Resources.close_32x32;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeftAutoMirrorImage = true;
            this.btnClose.Size = new System.Drawing.Size(49, 60);
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UC_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bindingNavigator11);
            this.Name = "UC_Master";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1389, 729);
            this.Load += new System.EventHandler(this.UC_Master_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator11)).EndInit();
            this.bindingNavigator11.ResumeLayout(false);
            this.bindingNavigator11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingNavigator bindingNavigator11;
        public System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        public System.Windows.Forms.ToolStripButton btnSave;
        public System.Windows.Forms.ToolStripButton btnUpdatePermission;
        public System.Windows.Forms.ToolStripButton btnReset;
        public System.Windows.Forms.ToolStripButton btnUpdate;
        public System.Windows.Forms.ToolStripButton btnPrint;
        public System.Windows.Forms.ToolStripButton btnDelete;
        public System.Windows.Forms.ToolStripButton btnRefresh;
        public System.Windows.Forms.ToolStripButton btnClose;
        public System.Windows.Forms.ToolStripLabel toolStripLabel7;
        public System.Windows.Forms.ToolStripButton Movefirst;
        public System.Windows.Forms.ToolStripButton Moveprevious;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBox7;
        public System.Windows.Forms.ToolStripButton Movenext;
        public System.Windows.Forms.ToolStripButton Movelast;
    }
}
