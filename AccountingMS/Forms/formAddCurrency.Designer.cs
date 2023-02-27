namespace AccountingMS
{
    partial class formAddCurrency
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.curNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.curSignTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.curTypeRadioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.curChangeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.curCellingTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.curFloarTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForcurName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcurSign = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcurType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcurChange = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcurCelling = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForcurFloar = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curSignTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curTypeRadioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curChangeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curCellingTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.curFloarTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurCelling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurFloar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup2;
            this.dataLayoutControl1.Size = new System.Drawing.Size(670, 304);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(670, 304);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AccountingMS.tblCurrency);
            // 
            // ribbonControl1
            // 
            //this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(652, 135);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save1;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiSave_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "العمليات";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.curNameTextEdit);
            this.dataLayoutControl2.Controls.Add(this.curSignTextEdit);
            this.dataLayoutControl2.Controls.Add(this.curTypeRadioGroup);
            this.dataLayoutControl2.Controls.Add(this.curChangeTextEdit);
            this.dataLayoutControl2.Controls.Add(this.curCellingTextEdit);
            this.dataLayoutControl2.Controls.Add(this.curFloarTextEdit);
            this.dataLayoutControl2.DataSource = this.bindingSource1;
            this.dataLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl2.Location = new System.Drawing.Point(0, 135);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.OptionsFocus.EnableAutoTabOrder = false;
            this.dataLayoutControl2.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl2.Root = this.layoutControlGroup5;
            this.dataLayoutControl2.Size = new System.Drawing.Size(652, 251);
            this.dataLayoutControl2.TabIndex = 0;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // curNameTextEdit
            // 
            this.curNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curNameTextEdit.Location = new System.Drawing.Point(17, 40);
            this.curNameTextEdit.Name = "curNameTextEdit";
            this.curNameTextEdit.Properties.MaxLength = 25;
            this.curNameTextEdit.Size = new System.Drawing.Size(540, 20);
            this.curNameTextEdit.StyleController = this.dataLayoutControl2;
            this.curNameTextEdit.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.curNameTextEdit, conditionValidationRule1);
            // 
            // curSignTextEdit
            // 
            this.curSignTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curSign", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curSignTextEdit.Location = new System.Drawing.Point(17, 64);
            this.curSignTextEdit.Name = "curSignTextEdit";
            this.curSignTextEdit.Properties.MaxLength = 5;
            this.curSignTextEdit.Size = new System.Drawing.Size(540, 20);
            this.curSignTextEdit.StyleController = this.dataLayoutControl2;
            this.curSignTextEdit.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.curSignTextEdit, conditionValidationRule2);
            // 
            // curTypeRadioGroup
            // 
            this.curTypeRadioGroup.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curTypeRadioGroup.Location = new System.Drawing.Point(17, 88);
            this.curTypeRadioGroup.Name = "curTypeRadioGroup";
            this.curTypeRadioGroup.Properties.Appearance.Options.UseTextOptions = true;
            this.curTypeRadioGroup.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.curTypeRadioGroup.Properties.Columns = 2;
            this.curTypeRadioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "رئيسي"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(2)), "فرعي")});
            this.curTypeRadioGroup.Size = new System.Drawing.Size(540, 70);
            this.curTypeRadioGroup.StyleController = this.dataLayoutControl2;
            this.curTypeRadioGroup.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule3.Value1 = ((byte)(0));
            this.dxValidationProvider1.SetValidationRule(this.curTypeRadioGroup, conditionValidationRule3);
            // 
            // curChangeTextEdit
            // 
            this.curChangeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curChangeTextEdit.Location = new System.Drawing.Point(17, 162);
            this.curChangeTextEdit.Name = "curChangeTextEdit";
            this.curChangeTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.curChangeTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.curChangeTextEdit.Properties.Mask.EditMask = "N0";
            this.curChangeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.curChangeTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.curChangeTextEdit.Size = new System.Drawing.Size(540, 20);
            this.curChangeTextEdit.StyleController = this.dataLayoutControl2;
            this.curChangeTextEdit.TabIndex = 3;
            // 
            // curCellingTextEdit
            // 
            this.curCellingTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curCelling", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curCellingTextEdit.Location = new System.Drawing.Point(17, 186);
            this.curCellingTextEdit.Name = "curCellingTextEdit";
            this.curCellingTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.curCellingTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.curCellingTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.curCellingTextEdit.Properties.Mask.EditMask = "N0";
            this.curCellingTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.curCellingTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.curCellingTextEdit.Size = new System.Drawing.Size(540, 20);
            this.curCellingTextEdit.StyleController = this.dataLayoutControl2;
            this.curCellingTextEdit.TabIndex = 4;
            // 
            // curFloarTextEdit
            // 
            this.curFloarTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "curFloar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.curFloarTextEdit.Location = new System.Drawing.Point(17, 210);
            this.curFloarTextEdit.Name = "curFloarTextEdit";
            this.curFloarTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.curFloarTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.curFloarTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.curFloarTextEdit.Properties.Mask.EditMask = "N0";
            this.curFloarTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.curFloarTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.curFloarTextEdit.Size = new System.Drawing.Size(540, 20);
            this.curFloarTextEdit.StyleController = this.dataLayoutControl2;
            this.curFloarTextEdit.TabIndex = 5;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup6});
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 5, 5);
            this.layoutControlGroup5.Size = new System.Drawing.Size(652, 251);
            this.layoutControlGroup5.Text = "layoutCoسntrolGroup5";
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.AllowDrawBackground = false;
            this.layoutControlGroup6.GroupBordersVisible = false;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "autoGeneratedGroup0";
            this.layoutControlGroup6.Size = new System.Drawing.Size(640, 241);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForcurName,
            this.ItemForcurSign,
            this.ItemForcurType,
            this.ItemForcurChange,
            this.ItemForcurCelling,
            this.ItemForcurFloar});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 5, 11);
            this.layoutControlGroup1.Size = new System.Drawing.Size(640, 241);
            this.layoutControlGroup1.Text = "بيانات العملة";
            // 
            // ItemForcurName
            // 
            this.ItemForcurName.Control = this.curNameTextEdit;
            this.ItemForcurName.Location = new System.Drawing.Point(0, 0);
            this.ItemForcurName.Name = "ItemForcurName";
            this.ItemForcurName.Size = new System.Drawing.Size(622, 24);
            this.ItemForcurName.Text = "إسم العملة";
            this.ItemForcurName.TextSize = new System.Drawing.Size(64, 17);
            // 
            // ItemForcurSign
            // 
            this.ItemForcurSign.Control = this.curSignTextEdit;
            this.ItemForcurSign.Location = new System.Drawing.Point(0, 24);
            this.ItemForcurSign.Name = "ItemForcurSign";
            this.ItemForcurSign.Size = new System.Drawing.Size(622, 24);
            this.ItemForcurSign.Text = "رمز العملة";
            this.ItemForcurSign.TextSize = new System.Drawing.Size(64, 17);
            // 
            // ItemForcurType
            // 
            this.ItemForcurType.Control = this.curTypeRadioGroup;
            this.ItemForcurType.Location = new System.Drawing.Point(0, 48);
            this.ItemForcurType.Name = "ItemForcurType";
            this.ItemForcurType.Size = new System.Drawing.Size(622, 74);
            this.ItemForcurType.StartNewLine = true;
            this.ItemForcurType.Text = "نوع العملة";
            this.ItemForcurType.TextSize = new System.Drawing.Size(64, 17);
            // 
            // ItemForcurChange
            // 
            this.ItemForcurChange.Control = this.curChangeTextEdit;
            this.ItemForcurChange.Location = new System.Drawing.Point(0, 122);
            this.ItemForcurChange.Name = "ItemForcurChange";
            this.ItemForcurChange.Size = new System.Drawing.Size(622, 24);
            this.ItemForcurChange.Text = "سعر الصرف";
            this.ItemForcurChange.TextSize = new System.Drawing.Size(64, 17);
            // 
            // ItemForcurCelling
            // 
            this.ItemForcurCelling.Control = this.curCellingTextEdit;
            this.ItemForcurCelling.Location = new System.Drawing.Point(0, 146);
            this.ItemForcurCelling.Name = "ItemForcurCelling";
            this.ItemForcurCelling.Size = new System.Drawing.Size(622, 24);
            this.ItemForcurCelling.Text = "الحد الأقصى";
            this.ItemForcurCelling.TextSize = new System.Drawing.Size(64, 17);
            // 
            // ItemForcurFloar
            // 
            this.ItemForcurFloar.Control = this.curFloarTextEdit;
            this.ItemForcurFloar.Location = new System.Drawing.Point(0, 170);
            this.ItemForcurFloar.Name = "ItemForcurFloar";
            this.ItemForcurFloar.Size = new System.Drawing.Size(622, 24);
            this.ItemForcurFloar.Text = "الحد الأدنى";
            this.ItemForcurFloar.TextSize = new System.Drawing.Size(64, 17);
            // 
            // formAddCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 386);
            this.Controls.Add(this.dataLayoutControl2);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "formAddCurrency";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة عملة";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.curNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curSignTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curTypeRadioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curChangeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curCellingTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.curFloarTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurCelling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForcurFloar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraEditors.TextEdit curNameTextEdit;
        private DevExpress.XtraEditors.TextEdit curSignTextEdit;
        private DevExpress.XtraEditors.RadioGroup curTypeRadioGroup;
        private DevExpress.XtraEditors.TextEdit curChangeTextEdit;
        private DevExpress.XtraEditors.TextEdit curCellingTextEdit;
        private DevExpress.XtraEditors.TextEdit curFloarTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurSign;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurChange;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurCelling;
        private DevExpress.XtraLayout.LayoutControlItem ItemForcurFloar;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}