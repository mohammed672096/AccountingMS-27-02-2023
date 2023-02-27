namespace AccountingMS
{
    partial class formAddBox
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.boxNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAutoAccNo = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAutoAddAccNo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.boxNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.boxCellingTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.boxAccNoTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.boxCurrencyTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForboxNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForboxCelling = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForboxCurrency = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForboxAccountNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForboxName = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCellingTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCurrencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxCelling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxAccountNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Appearance.ControlDisabled.BackColor = System.Drawing.Color.White;
            this.dataLayoutControl1.Appearance.ControlDisabled.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseBackColor = true;
            this.dataLayoutControl1.Appearance.ControlDisabled.Options.UseForeColor = true;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.Color.DimGray;
            this.dataLayoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.dataLayoutControl1.Controls.Add(this.boxNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.boxNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.boxCellingTextEdit);
            this.dataLayoutControl1.Controls.Add(this.boxAccNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.boxCurrencyTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource1;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 135);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(663, 220);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // boxNoTextEdit
            // 
            this.boxNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "boxNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.boxNoTextEdit.Location = new System.Drawing.Point(16, 70);
            this.boxNoTextEdit.MenuManager = this.mainRibbonControl;
            this.boxNoTextEdit.Name = "boxNoTextEdit";
            this.boxNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.boxNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.boxNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.boxNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.boxNoTextEdit.Size = new System.Drawing.Size(503, 20);
            this.boxNoTextEdit.StyleController = this.dataLayoutControl1;
            this.boxNoTextEdit.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule1.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.boxNoTextEdit, conditionValidationRule1);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AccountingMS.tblAccountBox);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiClose,
            this.bbiAutoAccNo});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 13;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.mainRibbonControl.ShowQatLocationSelector = false;
            this.mainRibbonControl.ShowToolbarCustomizeItem = false;
            this.mainRibbonControl.Size = new System.Drawing.Size(663, 135);
            this.mainRibbonControl.Toolbar.ShowCustomizeItem = false;
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 10;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save1;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 11;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiAutoAccNo
            // 
            this.bbiAutoAccNo.Caption = "إضافة حساب تلقائي";
            this.bbiAutoAccNo.Id = 12;
            this.bbiAutoAccNo.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.apply_32x321;
            this.bbiAutoAccNo.LargeWidth = 110;
            this.bbiAutoAccNo.Name = "bbiAutoAccNo";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupMain,
            this.ribbonPageGroupAutoAddAccNo});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "الرئيسية";
            // 
            // ribbonPageGroupMain
            // 
            this.ribbonPageGroupMain.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupMain.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupMain.Name = "ribbonPageGroupMain";
            this.ribbonPageGroupMain.Text = "العمليات";
            // 
            // ribbonPageGroupAutoAddAccNo
            // 
            this.ribbonPageGroupAutoAddAccNo.AllowTextClipping = false;
            this.ribbonPageGroupAutoAddAccNo.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroupAutoAddAccNo.ItemLinks.Add(this.bbiAutoAccNo);
            this.ribbonPageGroupAutoAddAccNo.Name = "ribbonPageGroupAutoAddAccNo";
            this.ribbonPageGroupAutoAddAccNo.Text = "حساب الصندوق";
            this.ribbonPageGroupAutoAddAccNo.Visible = false;
            // 
            // boxNameTextEdit
            // 
            this.boxNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "boxName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.boxNameTextEdit.Location = new System.Drawing.Point(16, 94);
            this.boxNameTextEdit.MenuManager = this.mainRibbonControl;
            this.boxNameTextEdit.Name = "boxNameTextEdit";
            this.boxNameTextEdit.Properties.MaxLength = 50;
            this.boxNameTextEdit.Size = new System.Drawing.Size(503, 20);
            this.boxNameTextEdit.StyleController = this.dataLayoutControl1;
            this.boxNameTextEdit.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.boxNameTextEdit, conditionValidationRule2);
            // 
            // boxCellingTextEdit
            // 
            this.boxCellingTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "boxCelling", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.boxCellingTextEdit.Location = new System.Drawing.Point(16, 142);
            this.boxCellingTextEdit.MenuManager = this.mainRibbonControl;
            this.boxCellingTextEdit.Name = "boxCellingTextEdit";
            this.boxCellingTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.boxCellingTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.boxCellingTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.boxCellingTextEdit.Properties.Mask.EditMask = "N0";
            this.boxCellingTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.boxCellingTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.boxCellingTextEdit.Size = new System.Drawing.Size(503, 20);
            this.boxCellingTextEdit.StyleController = this.dataLayoutControl1;
            this.boxCellingTextEdit.TabIndex = 4;
            // 
            // boxAccNoTextEdit
            // 
            this.boxAccNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "boxAccNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.boxAccNoTextEdit.Location = new System.Drawing.Point(16, 46);
            this.boxAccNoTextEdit.MenuManager = this.mainRibbonControl;
            this.boxAccNoTextEdit.Name = "boxAccNoTextEdit";
            this.boxAccNoTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.boxAccNoTextEdit.Properties.NullText = "";
            this.boxAccNoTextEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            this.boxAccNoTextEdit.Size = new System.Drawing.Size(503, 20);
            this.boxAccNoTextEdit.StyleController = this.dataLayoutControl1;
            this.boxAccNoTextEdit.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule3.Value1 = 0;
            this.dxValidationProvider1.SetValidationRule(this.boxAccNoTextEdit, conditionValidationRule3);
            // 
            // boxCurrencyTextEdit
            // 
            this.boxCurrencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "boxCurrency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.boxCurrencyTextEdit.Location = new System.Drawing.Point(16, 118);
            this.boxCurrencyTextEdit.MenuManager = this.mainRibbonControl;
            this.boxCurrencyTextEdit.Name = "boxCurrencyTextEdit";
            this.boxCurrencyTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.boxCurrencyTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.boxCurrencyTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.boxCurrencyTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.boxCurrencyTextEdit.Properties.NullText = "";
            this.boxCurrencyTextEdit.Size = new System.Drawing.Size(503, 20);
            this.boxCurrencyTextEdit.StyleController = this.dataLayoutControl1;
            this.boxCurrencyTextEdit.TabIndex = 3;
            conditionValidationRule4.CaseSensitive = true;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule4.ErrorText = "يجب إدخال هذا الحقل";
            conditionValidationRule4.Value1 = ((byte)(0));
            this.dxValidationProvider1.SetValidationRule(this.boxCurrencyTextEdit, conditionValidationRule4);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowBorderColorBlending = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 11, 11);
            this.layoutControlGroup1.Size = new System.Drawing.Size(663, 220);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(651, 198);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup3.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup3.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForboxNo,
            this.ItemForboxCelling,
            this.ItemForboxCurrency,
            this.ItemForboxAccountNo,
            this.ItemForboxName});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 5, 11);
            this.layoutControlGroup3.Size = new System.Drawing.Size(651, 198);
            this.layoutControlGroup3.Text = "بيانات الصندوق";
            // 
            // ItemForboxNo
            // 
            this.ItemForboxNo.Control = this.boxNoTextEdit;
            this.ItemForboxNo.Location = new System.Drawing.Point(0, 24);
            this.ItemForboxNo.Name = "ItemForboxNo";
            this.ItemForboxNo.Size = new System.Drawing.Size(635, 24);
            this.ItemForboxNo.Text = "رقم الصندوق :";
            this.ItemForboxNo.TextSize = new System.Drawing.Size(116, 17);
            // 
            // ItemForboxCelling
            // 
            this.ItemForboxCelling.Control = this.boxCellingTextEdit;
            this.ItemForboxCelling.Location = new System.Drawing.Point(0, 96);
            this.ItemForboxCelling.Name = "ItemForboxCelling";
            this.ItemForboxCelling.Size = new System.Drawing.Size(635, 56);
            this.ItemForboxCelling.Text = "الحد الأدنى :";
            this.ItemForboxCelling.TextSize = new System.Drawing.Size(116, 17);
            // 
            // ItemForboxCurrency
            // 
            this.ItemForboxCurrency.Control = this.boxCurrencyTextEdit;
            this.ItemForboxCurrency.Location = new System.Drawing.Point(0, 72);
            this.ItemForboxCurrency.Name = "ItemForboxCurrency";
            this.ItemForboxCurrency.Size = new System.Drawing.Size(635, 24);
            this.ItemForboxCurrency.Text = "العملة :";
            this.ItemForboxCurrency.TextSize = new System.Drawing.Size(116, 17);
            this.ItemForboxCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ItemForboxAccountNo
            // 
            this.ItemForboxAccountNo.Control = this.boxAccNoTextEdit;
            this.ItemForboxAccountNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForboxAccountNo.Name = "ItemForboxAccountNo";
            this.ItemForboxAccountNo.Size = new System.Drawing.Size(635, 24);
            this.ItemForboxAccountNo.Text = "رقم حساب الصندوق :";
            this.ItemForboxAccountNo.TextSize = new System.Drawing.Size(116, 17);
            // 
            // ItemForboxName
            // 
            this.ItemForboxName.Control = this.boxNameTextEdit;
            this.ItemForboxName.Location = new System.Drawing.Point(0, 48);
            this.ItemForboxName.Name = "ItemForboxName";
            this.ItemForboxName.Size = new System.Drawing.Size(635, 24);
            this.ItemForboxName.Text = "إسم الصندوق :";
            this.ItemForboxName.TextSize = new System.Drawing.Size(116, 17);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidateHiddenControls = false;
            // 
            // formAddBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(663, 355);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "formAddBox";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة صندوق";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boxNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCellingTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxAccNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxCurrencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxCelling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxAccountNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForboxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TextEdit boxNoTextEdit;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.TextEdit boxNameTextEdit;
        private DevExpress.XtraEditors.TextEdit boxCellingTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForboxNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForboxName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForboxCelling;
        private DevExpress.XtraEditors.LookUpEdit boxAccNoTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForboxAccountNo;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAutoAddAccNo;
        private DevExpress.XtraBars.BarCheckItem bbiAutoAccNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForboxCurrency;
        private DevExpress.XtraEditors.LookUpEdit boxCurrencyTextEdit;
    }
}