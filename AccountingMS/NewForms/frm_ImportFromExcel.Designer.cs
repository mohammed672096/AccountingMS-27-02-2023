namespace ERP.Forms
{
    partial class frm_ImportFromExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ImportFromExcel));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.cb_Sheets = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cb_Balance = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_Barcode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_SellPrice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_BuyPrice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_UOM = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_Group = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_Name = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cb_Company = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.spn_Start = new DevExpress.XtraEditors.SpinEdit();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Sheets.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Balance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Barcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_SellPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_BuyPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_UOM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Company.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Start.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleDescription");
            this.gridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("gridControl1.EmbeddedNavigator.AccessibleName");
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImage")));
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl1.EmbeddedNavigator.Margin")));
            this.gridControl1.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl1.EmbeddedNavigator.MaximumSize")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Name = "groupControl1";
            // 
            // groupControl2
            // 
            resources.ApplyResources(this.groupControl2, "groupControl2");
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Controls.Add(this.textEdit1);
            this.groupControl2.Controls.Add(this.cb_Sheets);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Name = "groupControl2";
            // 
            // simpleButton2
            // 
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.ImageOptions.ImageIndex = ((int)(resources.GetObject("simpleButton2.ImageOptions.ImageIndex")));
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
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
            this.textEdit1.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // cb_Sheets
            // 
            resources.ApplyResources(this.cb_Sheets, "cb_Sheets");
            this.cb_Sheets.Name = "cb_Sheets";
            this.cb_Sheets.Properties.AccessibleDescription = resources.GetString("cb_Sheets.Properties.AccessibleDescription");
            this.cb_Sheets.Properties.AccessibleName = resources.GetString("cb_Sheets.Properties.AccessibleName");
            this.cb_Sheets.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Sheets.Properties.AutoHeight")));
            this.cb_Sheets.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Sheets.Properties.Buttons"))))});
            this.cb_Sheets.Properties.NullValuePrompt = resources.GetString("cb_Sheets.Properties.NullValuePrompt");
            this.cb_Sheets.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Sheets.Properties.NullValuePromptShowForEmptyValue")));
            this.cb_Sheets.SelectedIndexChanged += new System.EventHandler(this.cb_Sheets_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // groupControl3
            // 
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.Controls.Add(this.labelControl10);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.labelControl9);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.cb_Balance);
            this.groupControl3.Controls.Add(this.cb_Barcode);
            this.groupControl3.Controls.Add(this.cb_SellPrice);
            this.groupControl3.Controls.Add(this.cb_BuyPrice);
            this.groupControl3.Controls.Add(this.cb_UOM);
            this.groupControl3.Controls.Add(this.cb_Group);
            this.groupControl3.Controls.Add(this.cb_Name);
            this.groupControl3.Controls.Add(this.cb_Company);
            this.groupControl3.Controls.Add(this.simpleButton1);
            this.groupControl3.Controls.Add(this.spn_Start);
            this.groupControl3.Name = "groupControl3";
            // 
            // labelControl10
            // 
            resources.ApplyResources(this.labelControl10, "labelControl10");
            this.labelControl10.Name = "labelControl10";
            // 
            // labelControl8
            // 
            resources.ApplyResources(this.labelControl8, "labelControl8");
            this.labelControl8.Name = "labelControl8";
            // 
            // labelControl4
            // 
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Name = "labelControl4";
            // 
            // labelControl7
            // 
            resources.ApplyResources(this.labelControl7, "labelControl7");
            this.labelControl7.Name = "labelControl7";
            // 
            // labelControl6
            // 
            resources.ApplyResources(this.labelControl6, "labelControl6");
            this.labelControl6.Name = "labelControl6";
            // 
            // labelControl9
            // 
            resources.ApplyResources(this.labelControl9, "labelControl9");
            this.labelControl9.Name = "labelControl9";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl5
            // 
            resources.ApplyResources(this.labelControl5, "labelControl5");
            this.labelControl5.Name = "labelControl5";
            // 
            // labelControl3
            // 
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Name = "labelControl3";
            // 
            // cb_Balance
            // 
            resources.ApplyResources(this.cb_Balance, "cb_Balance");
            this.cb_Balance.Name = "cb_Balance";
            this.cb_Balance.Properties.AccessibleDescription = resources.GetString("cb_Balance.Properties.AccessibleDescription");
            this.cb_Balance.Properties.AccessibleName = resources.GetString("cb_Balance.Properties.AccessibleName");
            this.cb_Balance.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Balance.Properties.AutoHeight")));
            this.cb_Balance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Balance.Properties.Buttons"))))});
            this.cb_Balance.Properties.NullValuePrompt = resources.GetString("cb_Balance.Properties.NullValuePrompt");
            this.cb_Balance.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Balance.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_Barcode
            // 
            resources.ApplyResources(this.cb_Barcode, "cb_Barcode");
            this.cb_Barcode.Name = "cb_Barcode";
            this.cb_Barcode.Properties.AccessibleDescription = resources.GetString("cb_Barcode.Properties.AccessibleDescription");
            this.cb_Barcode.Properties.AccessibleName = resources.GetString("cb_Barcode.Properties.AccessibleName");
            this.cb_Barcode.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Barcode.Properties.AutoHeight")));
            this.cb_Barcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Barcode.Properties.Buttons"))))});
            this.cb_Barcode.Properties.NullValuePrompt = resources.GetString("cb_Barcode.Properties.NullValuePrompt");
            this.cb_Barcode.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Barcode.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_SellPrice
            // 
            resources.ApplyResources(this.cb_SellPrice, "cb_SellPrice");
            this.cb_SellPrice.Name = "cb_SellPrice";
            this.cb_SellPrice.Properties.AccessibleDescription = resources.GetString("cb_SellPrice.Properties.AccessibleDescription");
            this.cb_SellPrice.Properties.AccessibleName = resources.GetString("cb_SellPrice.Properties.AccessibleName");
            this.cb_SellPrice.Properties.AutoHeight = ((bool)(resources.GetObject("cb_SellPrice.Properties.AutoHeight")));
            this.cb_SellPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_SellPrice.Properties.Buttons"))))});
            this.cb_SellPrice.Properties.NullValuePrompt = resources.GetString("cb_SellPrice.Properties.NullValuePrompt");
            this.cb_SellPrice.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_SellPrice.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_BuyPrice
            // 
            resources.ApplyResources(this.cb_BuyPrice, "cb_BuyPrice");
            this.cb_BuyPrice.Name = "cb_BuyPrice";
            this.cb_BuyPrice.Properties.AccessibleDescription = resources.GetString("cb_BuyPrice.Properties.AccessibleDescription");
            this.cb_BuyPrice.Properties.AccessibleName = resources.GetString("cb_BuyPrice.Properties.AccessibleName");
            this.cb_BuyPrice.Properties.AutoHeight = ((bool)(resources.GetObject("cb_BuyPrice.Properties.AutoHeight")));
            this.cb_BuyPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_BuyPrice.Properties.Buttons"))))});
            this.cb_BuyPrice.Properties.NullValuePrompt = resources.GetString("cb_BuyPrice.Properties.NullValuePrompt");
            this.cb_BuyPrice.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_BuyPrice.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_UOM
            // 
            resources.ApplyResources(this.cb_UOM, "cb_UOM");
            this.cb_UOM.Name = "cb_UOM";
            this.cb_UOM.Properties.AccessibleDescription = resources.GetString("cb_UOM.Properties.AccessibleDescription");
            this.cb_UOM.Properties.AccessibleName = resources.GetString("cb_UOM.Properties.AccessibleName");
            this.cb_UOM.Properties.AutoHeight = ((bool)(resources.GetObject("cb_UOM.Properties.AutoHeight")));
            this.cb_UOM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_UOM.Properties.Buttons"))))});
            this.cb_UOM.Properties.NullValuePrompt = resources.GetString("cb_UOM.Properties.NullValuePrompt");
            this.cb_UOM.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_UOM.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_Group
            // 
            resources.ApplyResources(this.cb_Group, "cb_Group");
            this.cb_Group.Name = "cb_Group";
            this.cb_Group.Properties.AccessibleDescription = resources.GetString("cb_Group.Properties.AccessibleDescription");
            this.cb_Group.Properties.AccessibleName = resources.GetString("cb_Group.Properties.AccessibleName");
            this.cb_Group.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Group.Properties.AutoHeight")));
            this.cb_Group.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Group.Properties.Buttons"))))});
            this.cb_Group.Properties.NullValuePrompt = resources.GetString("cb_Group.Properties.NullValuePrompt");
            this.cb_Group.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Group.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_Name
            // 
            resources.ApplyResources(this.cb_Name, "cb_Name");
            this.cb_Name.Name = "cb_Name";
            this.cb_Name.Properties.AccessibleDescription = resources.GetString("cb_Name.Properties.AccessibleDescription");
            this.cb_Name.Properties.AccessibleName = resources.GetString("cb_Name.Properties.AccessibleName");
            this.cb_Name.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Name.Properties.AutoHeight")));
            this.cb_Name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Name.Properties.Buttons"))))});
            this.cb_Name.Properties.NullValuePrompt = resources.GetString("cb_Name.Properties.NullValuePrompt");
            this.cb_Name.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Name.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cb_Company
            // 
            resources.ApplyResources(this.cb_Company, "cb_Company");
            this.cb_Company.Name = "cb_Company";
            this.cb_Company.Properties.AccessibleDescription = resources.GetString("cb_Company.Properties.AccessibleDescription");
            this.cb_Company.Properties.AccessibleName = resources.GetString("cb_Company.Properties.AccessibleName");
            this.cb_Company.Properties.AutoHeight = ((bool)(resources.GetObject("cb_Company.Properties.AutoHeight")));
            this.cb_Company.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cb_Company.Properties.Buttons"))))});
            this.cb_Company.Properties.NullValuePrompt = resources.GetString("cb_Company.Properties.NullValuePrompt");
            this.cb_Company.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cb_Company.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // simpleButton1
            // 
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.ImageOptions.ImageIndex = ((int)(resources.GetObject("simpleButton1.ImageOptions.ImageIndex")));
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // spn_Start
            // 
            resources.ApplyResources(this.spn_Start, "spn_Start");
            this.spn_Start.Name = "spn_Start";
            this.spn_Start.Properties.AccessibleDescription = resources.GetString("spn_Start.Properties.AccessibleDescription");
            this.spn_Start.Properties.AccessibleName = resources.GetString("spn_Start.Properties.AccessibleName");
            this.spn_Start.Properties.AutoHeight = ((bool)(resources.GetObject("spn_Start.Properties.AutoHeight")));
            this.spn_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("spn_Start.Properties.Buttons"))))});
            this.spn_Start.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spn_Start.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spn_Start.Properties.Mask.AutoComplete")));
            this.spn_Start.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spn_Start.Properties.Mask.BeepOnError")));
            this.spn_Start.Properties.Mask.EditMask = resources.GetString("spn_Start.Properties.Mask.EditMask");
            this.spn_Start.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spn_Start.Properties.Mask.IgnoreMaskBlank")));
            this.spn_Start.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spn_Start.Properties.Mask.MaskType")));
            this.spn_Start.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spn_Start.Properties.Mask.PlaceHolder")));
            this.spn_Start.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spn_Start.Properties.Mask.SaveLiteral")));
            this.spn_Start.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spn_Start.Properties.Mask.ShowPlaceHolders")));
            this.spn_Start.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spn_Start.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spn_Start.Properties.NullValuePrompt = resources.GetString("spn_Start.Properties.NullValuePrompt");
            this.spn_Start.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spn_Start.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // xtraOpenFileDialog1
            // 
            resources.ApplyResources(this.xtraOpenFileDialog1, "xtraOpenFileDialog1");
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // frm_ImportFromExcel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_ImportFromExcel";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Sheets.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Balance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Barcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_SellPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_BuyPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_UOM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Company.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn_Start.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit cb_BuyPrice;
        private DevExpress.XtraEditors.ComboBoxEdit cb_UOM;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Group;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Company;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Sheets;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Barcode;
        private DevExpress.XtraEditors.ComboBoxEdit cb_SellPrice;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Balance;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Name;
        private DevExpress.XtraEditors.SpinEdit spn_Start;
    }
}