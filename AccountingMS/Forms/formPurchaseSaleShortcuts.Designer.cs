namespace AccountingMS
{
    partial class formPurchaseSaleShortcuts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPurchaseSaleShortcuts));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditPrice = new DevExpress.XtraEditors.TextEdit();
            this.textEditQuantity = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForQuantity = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditPrice);
            this.layoutControl1.Controls.Add(this.textEditQuantity);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // textEditPrice
            // 
            resources.ApplyResources(this.textEditPrice, "textEditPrice");
            this.textEditPrice.Name = "textEditPrice";
            this.textEditPrice.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEditPrice.Properties.Mask.BeepOnError")));
            this.textEditPrice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.textEditPrice.Properties.MaskSettings.Set("mask", "n2");
            this.textEditPrice.StyleController = this.layoutControl1;
            // 
            // textEditQuantity
            // 
            resources.ApplyResources(this.textEditQuantity, "textEditQuantity");
            this.textEditQuantity.Name = "textEditQuantity";
            this.textEditQuantity.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEditQuantity.Properties.Mask.BeepOnError")));
            this.textEditQuantity.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.textEditQuantity.Properties.MaskSettings.Set("mask", "n");
            this.textEditQuantity.StyleController = this.layoutControl1;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.AppearanceHovered.Options.UseBackColor = true;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.AppearanceHovered.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.AppearanceHovered.Options.UseBackColor = true;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlGroup1.AppearanceItemCaption.Font")));
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForPrice,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.itemForQuantity});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(473, 159);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // itemForPrice
            // 
            this.itemForPrice.Control = this.textEditPrice;
            this.itemForPrice.Location = new System.Drawing.Point(0, 54);
            this.itemForPrice.Name = "itemForPrice";
            this.itemForPrice.Size = new System.Drawing.Size(453, 54);
            resources.ApplyResources(this.itemForPrice, "itemForPrice");
            this.itemForPrice.TextLocation = DevExpress.Utils.Locations.Top;
            this.itemForPrice.TextSize = new System.Drawing.Size(133, 23);
            this.itemForPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSave;
            this.layoutControlItem3.Location = new System.Drawing.Point(226, 108);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(227, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCancel;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(226, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // itemForQuantity
            // 
            this.itemForQuantity.Control = this.textEditQuantity;
            this.itemForQuantity.Location = new System.Drawing.Point(0, 0);
            this.itemForQuantity.Name = "itemForQuantity";
            this.itemForQuantity.Size = new System.Drawing.Size(453, 54);
            resources.ApplyResources(this.itemForQuantity, "itemForQuantity");
            this.itemForQuantity.TextLocation = DevExpress.Utils.Locations.Top;
            this.itemForQuantity.TextSize = new System.Drawing.Size(133, 23);
            this.itemForQuantity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // formPurchaseSaleShortcuts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "formPurchaseSaleShortcuts";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formPurchaseSaleShortcuts_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEditPrice;
        private DevExpress.XtraEditors.TextEdit textEditQuantity;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem itemForPrice;
        private DevExpress.XtraLayout.LayoutControlItem itemForQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}