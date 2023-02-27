namespace ERP.Forms
{
    partial class frm_ItemGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ItemGroup));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
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
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_ConvertTo.MenuAppearance.HeaderItemAppearance.Image")));
            // 
            // SubItem_Printbills
            // 
            resources.ApplyResources(this.SubItem_Printbills, "SubItem_Printbills");
            this.SubItem_Printbills.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_Printbills.ImageOptions.Image")));
            this.SubItem_Printbills.ImageOptions.ImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.ImageIndex")));
            this.SubItem_Printbills.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("SubItem_Printbills.ImageOptions.LargeImageIndex")));
            this.SubItem_Printbills.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SubItem_Printbills.ImageOptions.SvgImage")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.SubItem_Printbills.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("SubItem_Printbills.MenuAppearance.HeaderItemAppearance.Image")));
            // 
            // treeList1
            // 
            resources.ApplyResources(this.treeList1, "treeList1");
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // textEdit1
            // 
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AccessibleDescription = resources.GetString("textEdit1.Properties.AccessibleDescription");
            this.textEdit1.Properties.AccessibleName = resources.GetString("textEdit1.Properties.AccessibleName");
            this.textEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit1.Properties.AutoHeight")));
            this.textEdit1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("textEdit1.Properties.Mask.AutoComplete")));
            this.textEdit1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("textEdit1.Properties.Mask.BeepOnError")));
            this.textEdit1.Properties.Mask.EditMask = resources.GetString("textEdit1.Properties.Mask.EditMask");
            this.textEdit1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("textEdit1.Properties.Mask.IgnoreMaskBlank")));
            this.textEdit1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("textEdit1.Properties.Mask.MaskType")));
            this.textEdit1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("textEdit1.Properties.Mask.PlaceHolder")));
            this.textEdit1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("textEdit1.Properties.Mask.SaveLiteral")));
            this.textEdit1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("textEdit1.Properties.Mask.ShowPlaceHolders")));
            this.textEdit1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("textEdit1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.textEdit1.Properties.NullValuePrompt = resources.GetString("textEdit1.Properties.NullValuePrompt");
            this.textEdit1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit1.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textEdit2
            // 
            resources.ApplyResources(this.textEdit2, "textEdit2");
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AccessibleDescription = resources.GetString("textEdit2.Properties.AccessibleDescription");
            this.textEdit2.Properties.AccessibleName = resources.GetString("textEdit2.Properties.AccessibleName");
            this.textEdit2.Properties.AutoHeight = ((bool)(resources.GetObject("textEdit2.Properties.AutoHeight")));
            this.textEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("textEdit2.Properties.Buttons"))))});
            this.textEdit2.Properties.NullText = resources.GetString("textEdit2.Properties.NullText");
            this.textEdit2.Properties.NullValuePrompt = resources.GetString("textEdit2.Properties.NullValuePrompt");
            this.textEdit2.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("textEdit2.Properties.NullValuePromptShowForEmptyValue")));
            this.textEdit2.Properties.ReadOnly = true;
            // 
            // frm_ItemGroup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.textEdit2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ItemGroup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.frm_ItemGroup_Load);
            this.Controls.SetChildIndex(this.textEdit2, 0);
            this.Controls.SetChildIndex(this.treeList1, 0);
            this.Controls.SetChildIndex(this.textEdit1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit textEdit2;
    }
}