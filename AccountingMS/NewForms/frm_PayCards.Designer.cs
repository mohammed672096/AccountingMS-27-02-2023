namespace ERP.Forms.MAIN
{
    partial class frm_PayCards
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PayCards));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.TextEdit_ID = new DevExpress.XtraEditors.TextEdit();
            this.LookUpEdit_BankID = new DevExpress.XtraEditors.LookUpEdit();
            this.TextEdit_Number = new DevExpress.XtraEditors.TextEdit();
            this.SpinEdit_Commission = new DevExpress.XtraEditors.SpinEdit();
            this.LookUpEdit_CommissionAccount = new DevExpress.XtraEditors.LookUpEdit();
            this.LookUpEdit_LinkedToBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_BankID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit_Commission.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_CommissionAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_LinkedToBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // lkp_List
            // 
            resources.ApplyResources(this.lkp_List, "lkp_List");
            // 
            // SubItem_ConvertTo
            // 
            resources.ApplyResources(this.SubItem_ConvertTo, "SubItem_ConvertTo");
            this.SubItem_ConvertTo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_ConvertTo.ImageOptions.Image")));
            this.SubItem_ConvertTo.ImageOptions.ImageIndex = ((int)(resources.GetObject("SubItem_ConvertTo.ImageOptions.ImageIndex")));
            this.SubItem_ConvertTo.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("SubItem_ConvertTo.ImageOptions.LargeImageIndex")));
            this.SubItem_ConvertTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubItem_ConvertTo.ImageOptions.SvgImage")));
            // 
            // SubItem_Printbills
            // 
            resources.ApplyResources(this.SubItem_Printbills, "SubItem_Printbills");
            this.SubItem_Printbills.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_Printbills.ImageOptions.Image")));
            this.SubItem_Printbills.ImageOptions.ImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.ImageIndex")));
            this.SubItem_Printbills.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.LargeImageIndex")));
            this.SubItem_Printbills.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubItem_Printbills.ImageOptions.SvgImage")));
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Controls.Add(this.TextEdit_ID);
            this.layoutControl1.Controls.Add(this.LookUpEdit_BankID);
            this.layoutControl1.Controls.Add(this.TextEdit_Number);
            this.layoutControl1.Controls.Add(this.SpinEdit_Commission);
            this.layoutControl1.Controls.Add(this.LookUpEdit_CommissionAccount);
            this.layoutControl1.Controls.Add(this.LookUpEdit_LinkedToBranch);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.Root;
            // 
            // TextEdit_ID
            // 
            resources.ApplyResources(this.TextEdit_ID, "TextEdit_ID");
            this.TextEdit_ID.Name = "TextEdit_ID";
            this.TextEdit_ID.Properties.ReadOnly = true;
            this.TextEdit_ID.StyleController = this.layoutControl1;
            // 
            // LookUpEdit_BankID
            // 
            resources.ApplyResources(this.LookUpEdit_BankID, "LookUpEdit_BankID");
            this.LookUpEdit_BankID.Name = "LookUpEdit_BankID";
            this.LookUpEdit_BankID.Properties.NullText = resources.GetString("LookUpEdit_BankID.Properties.NullText");
            this.LookUpEdit_BankID.StyleController = this.layoutControl1;
            // 
            // TextEdit_Number
            // 
            resources.ApplyResources(this.TextEdit_Number, "TextEdit_Number");
            this.TextEdit_Number.Name = "TextEdit_Number";
            this.TextEdit_Number.StyleController = this.layoutControl1;
            // 
            // SpinEdit_Commission
            // 
            resources.ApplyResources(this.SpinEdit_Commission, "SpinEdit_Commission");
            this.SpinEdit_Commission.Name = "SpinEdit_Commission";
            this.SpinEdit_Commission.StyleController = this.layoutControl1;
            // 
            // LookUpEdit_CommissionAccount
            // 
            resources.ApplyResources(this.LookUpEdit_CommissionAccount, "LookUpEdit_CommissionAccount");
            this.LookUpEdit_CommissionAccount.Name = "LookUpEdit_CommissionAccount";
            this.LookUpEdit_CommissionAccount.Properties.NullText = resources.GetString("LookUpEdit_CommissionAccount.Properties.NullText");
            this.LookUpEdit_CommissionAccount.StyleController = this.layoutControl1;
            // 
            // LookUpEdit_LinkedToBranch
            // 
            resources.ApplyResources(this.LookUpEdit_LinkedToBranch, "LookUpEdit_LinkedToBranch");
            this.LookUpEdit_LinkedToBranch.Name = "LookUpEdit_LinkedToBranch";
            this.LookUpEdit_LinkedToBranch.Properties.NullText = resources.GetString("LookUpEdit_LinkedToBranch.Properties.NullText");
            this.LookUpEdit_LinkedToBranch.StyleController = this.layoutControl1;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 50D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            columnDefinition2.Width = 264D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 50D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 22.222222222222221D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 189D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition3.Height = 77.777777777777786D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3});
            this.Root.Size = new System.Drawing.Size(289, 217);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(2, 2);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlGroup1.OptionsTableLayoutItem.RowIndex = 1;
            this.layoutControlGroup1.Size = new System.Drawing.Size(264, 189);
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            // 
            // layoutControlItem1
            // 
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Control = this.TextEdit_ID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(350, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(240, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem2
            // 
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Control = this.LookUpEdit_LinkedToBranch;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem3
            // 
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Control = this.LookUpEdit_CommissionAccount;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem4
            // 
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Control = this.SpinEdit_Commission;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem5
            // 
            resources.ApplyResources(this.layoutControlItem5, "layoutControlItem5");
            this.layoutControlItem5.Control = this.TextEdit_Number;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem6
            // 
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Control = this.LookUpEdit_BankID;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(67, 13);
            // 
            // frm_PayCards
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.layoutControl1);
            this.Name = "frm_PayCards";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_BankID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit_Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEdit_Commission.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_CommissionAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit_LinkedToBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit TextEdit_ID;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_BankID;
        private DevExpress.XtraEditors.TextEdit TextEdit_Number;
        private DevExpress.XtraEditors.SpinEdit SpinEdit_Commission;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_CommissionAccount;
        private DevExpress.XtraEditors.LookUpEdit LookUpEdit_LinkedToBranch;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}