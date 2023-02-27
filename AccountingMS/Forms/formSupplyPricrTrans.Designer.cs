namespace AccountingMS
{
    partial class formSupplyPricrTrans
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
            if (disposing && (components != null)) {
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditPrice = new DevExpress.XtraEditors.TextEdit();
            this.textEditQuan = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForQuantity = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditPrice);
            this.layoutControl1.Controls.Add(this.textEditQuan);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(336, 110);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEditPrice
            // 
            this.textEditPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textEditPrice.Location = new System.Drawing.Point(12, 12);
            this.textEditPrice.Name = "textEditPrice";
            this.textEditPrice.Size = new System.Drawing.Size(241, 20);
            this.textEditPrice.StyleController = this.layoutControl1;
            this.textEditPrice.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "يجب ان لا يكون هذا الحقل فارغ أو القيمة  تساوي 0";
            conditionValidationRule1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.dxValidationProvider1.SetValidationRule(this.textEditPrice, conditionValidationRule1);
            // 
            // textEditQuan
            // 
            this.textEditQuan.EditValue = 0;
            this.textEditQuan.Location = new System.Drawing.Point(12, 36);
            this.textEditQuan.Name = "textEditQuan";
            this.textEditQuan.Size = new System.Drawing.Size(241, 20);
            this.textEditQuan.StyleController = this.layoutControl1;
            this.textEditQuan.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule2.ErrorText = "يجب ان لا يكون هذا الحقل فارغ أو القيمة  تساوي 0";
            conditionValidationRule2.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.textEditQuan, conditionValidationRule2);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(12, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(312, 24);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "موافق";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPrice,
            this.ItemForQuantity,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(336, 110);
            this.Root.TextVisible = false;
            // 
            // ItemForPrice
            // 
            this.ItemForPrice.Control = this.textEditPrice;
            this.ItemForPrice.Location = new System.Drawing.Point(0, 0);
            this.ItemForPrice.Name = "ItemForPrice";
            this.ItemForPrice.Size = new System.Drawing.Size(316, 24);
            this.ItemForPrice.Text = "السعر:";
            this.ItemForPrice.TextSize = new System.Drawing.Size(68, 15);
            // 
            // ItemForQuantity
            // 
            this.ItemForQuantity.Control = this.textEditQuan;
            this.ItemForQuantity.Location = new System.Drawing.Point(0, 24);
            this.ItemForQuantity.Name = "ItemForQuantity";
            this.ItemForQuantity.Size = new System.Drawing.Size(316, 24);
            this.ItemForQuantity.Text = "عامل التحويل:";
            this.ItemForQuantity.TextSize = new System.Drawing.Size(68, 15);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(316, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // formSupplyPricrTrans
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 110);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "formSupplyPricrTrans";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحويل السعر";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSupplyPricrTrans_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit textEditPrice;
        private DevExpress.XtraEditors.TextEdit textEditQuan;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}