namespace ERP.Forms
{
    partial class frm_CustomerGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CustomerGroup));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.textEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement9 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement11 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement10 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement12 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lkp_List
            // 
            resources.ApplyResources(this.lkp_List, "lkp_List");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // 
            // treeList1
            // 
            resources.ApplyResources(this.treeList1, "treeList1");
            this.treeList1.DataSource = null;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
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
            // spinEdit1
            // 
            resources.ApplyResources(this.spinEdit1, "spinEdit1");
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AccessibleDescription = resources.GetString("spinEdit1.Properties.AccessibleDescription");
            this.spinEdit1.Properties.AccessibleName = resources.GetString("spinEdit1.Properties.AccessibleName");
            this.spinEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("spinEdit1.Properties.AutoHeight")));
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("spinEdit1.Properties.Buttons"))))});
            this.spinEdit1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spinEdit1.Properties.Mask.AutoComplete")));
            this.spinEdit1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spinEdit1.Properties.Mask.BeepOnError")));
            this.spinEdit1.Properties.Mask.EditMask = resources.GetString("spinEdit1.Properties.Mask.EditMask");
            this.spinEdit1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spinEdit1.Properties.Mask.IgnoreMaskBlank")));
            this.spinEdit1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spinEdit1.Properties.Mask.MaskType")));
            this.spinEdit1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spinEdit1.Properties.Mask.PlaceHolder")));
            this.spinEdit1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spinEdit1.Properties.Mask.SaveLiteral")));
            this.spinEdit1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spinEdit1.Properties.Mask.ShowPlaceHolders")));
            this.spinEdit1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spinEdit1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spinEdit1.Properties.NullValuePrompt = resources.GetString("spinEdit1.Properties.NullValuePrompt");
            this.spinEdit1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spinEdit1.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // accordionControl1
            // 
            resources.ApplyResources(this.accordionControl1, "accordionControl1");
            this.accordionControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2});
            this.accordionControl1.Name = "accordionControl1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement9,
            this.accordionControlElement10});
            resources.ApplyResources(this.accordionControlElement2, "accordionControlElement2");
            this.accordionControlElement2.Name = "accordionControlElement2";
            // 
            // accordionControlElement9
            // 
            this.accordionControlElement9.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement11});
            resources.ApplyResources(this.accordionControlElement9, "accordionControlElement9");
            this.accordionControlElement9.Name = "accordionControlElement9";
            // 
            // accordionControlElement11
            // 
            resources.ApplyResources(this.accordionControlElement11, "accordionControlElement11");
            this.accordionControlElement11.Name = "accordionControlElement11";
            this.accordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // accordionControlElement10
            // 
            this.accordionControlElement10.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement12});
            resources.ApplyResources(this.accordionControlElement10, "accordionControlElement10");
            this.accordionControlElement10.Name = "accordionControlElement10";
            // 
            // accordionControlElement12
            // 
            resources.ApplyResources(this.accordionControlElement12, "accordionControlElement12");
            this.accordionControlElement12.Name = "accordionControlElement12";
            this.accordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.spinEdit1);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.treeList1);
            this.groupControl1.Controls.Add(this.textEdit2);
            this.groupControl1.Name = "groupControl1";
            // 
            // frm_CustomerGroup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.accordionControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_CustomerGroup";
            this.Controls.SetChildIndex(this.accordionControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lkp_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.LookUpEdit textEdit2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement11;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement10;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement12;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}