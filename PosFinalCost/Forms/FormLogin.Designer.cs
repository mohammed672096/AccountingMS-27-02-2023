namespace PosFinalCost.Forms
{
    partial class FormLogin
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BtnLogIn = new DevExpress.XtraEditors.SimpleButton();
            this.textEditUserName = new DevExpress.XtraEditors.TextEdit();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.radioGroupLanguage = new DevExpress.XtraEditors.RadioGroup();
            this.textEditBranchId = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditFinancialYear = new DevExpress.XtraEditors.GridLookUpEdit();
            this.FinancialYearBindingSource = new System.Windows.Forms.BindingSource();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfyDateStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfyDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForBranchId = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForFinancialYear = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.BranchBindingSource = new System.Windows.Forms.BindingSource();
            this.colfyStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBranchId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFinancialYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinancialYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForBranchId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.labelControl1);
            this.dataLayoutControl1.Controls.Add(this.BtnLogIn);
            this.dataLayoutControl1.Controls.Add(this.textEditUserName);
            this.dataLayoutControl1.Controls.Add(this.textEditPassword);
            this.dataLayoutControl1.Controls.Add(this.radioGroupLanguage);
            this.dataLayoutControl1.Controls.Add(this.textEditBranchId);
            this.dataLayoutControl1.Controls.Add(this.textEditFinancialYear);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(529, 110, 450, 400);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(608, 319);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(206)))));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(582, 47);
            this.labelControl1.StyleController = this.dataLayoutControl1;
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "نظام نقاط البيع POS";
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BtnLogIn.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnLogIn.Appearance.Options.UseFont = true;
            this.BtnLogIn.Appearance.Options.UseForeColor = true;
            this.BtnLogIn.Location = new System.Drawing.Point(13, 276);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(582, 30);
            this.BtnLogIn.StyleController = this.dataLayoutControl1;
            this.BtnLogIn.TabIndex = 7;
            this.BtnLogIn.Text = "تسجيل الدخول";
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // textEditUserName
            // 
            this.textEditUserName.Location = new System.Drawing.Point(26, 77);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Size = new System.Drawing.Size(406, 24);
            this.textEditUserName.StyleController = this.dataLayoutControl1;
            this.textEditUserName.TabIndex = 12;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.textEditUserName, conditionValidationRule1);
            // 
            // textEditPassword
            // 
            this.textEditPassword.Location = new System.Drawing.Point(26, 105);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Properties.PasswordChar = '*';
            this.textEditPassword.Size = new System.Drawing.Size(406, 24);
            this.textEditPassword.StyleController = this.dataLayoutControl1;
            this.textEditPassword.TabIndex = 13;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.textEditPassword, conditionValidationRule2);
            // 
            // radioGroupLanguage
            // 
            this.radioGroupLanguage.Location = new System.Drawing.Point(26, 189);
            this.radioGroupLanguage.Name = "radioGroupLanguage";
            this.radioGroupLanguage.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupLanguage.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioGroupLanguage.Properties.Appearance.Options.UseFont = true;
            this.radioGroupLanguage.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroupLanguage.Properties.Columns = 2;
            this.radioGroupLanguage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "عربي"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "English")});
            this.radioGroupLanguage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroupLanguage.Size = new System.Drawing.Size(406, 70);
            this.radioGroupLanguage.StyleController = this.dataLayoutControl1;
            this.radioGroupLanguage.TabIndex = 14;
            // 
            // textEditBranchId
            // 
            this.textEditBranchId.Location = new System.Drawing.Point(26, 133);
            this.textEditBranchId.Name = "textEditBranchId";
            this.textEditBranchId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditBranchId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No", "رقم الفرع", 11, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "إسم الفرع", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.textEditBranchId.Properties.NullText = "";
            this.textEditBranchId.Properties.PopupFormMinSize = new System.Drawing.Size(26, 0);
            this.textEditBranchId.Properties.PopupWidth = 26;
            this.textEditBranchId.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.textEditBranchId.Size = new System.Drawing.Size(406, 24);
            this.textEditBranchId.StyleController = this.dataLayoutControl1;
            this.textEditBranchId.TabIndex = 15;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.textEditBranchId, conditionValidationRule3);
            // 
            // textEditFinancialYear
            // 
            this.textEditFinancialYear.Location = new System.Drawing.Point(26, 161);
            this.textEditFinancialYear.Name = "textEditFinancialYear";
            this.textEditFinancialYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditFinancialYear.Properties.DataSource = this.FinancialYearBindingSource;
            this.textEditFinancialYear.Properties.DisplayMember = "Name";
            this.textEditFinancialYear.Properties.NullText = "";
            this.textEditFinancialYear.Properties.PopupFormMinSize = new System.Drawing.Size(14, 0);
            this.textEditFinancialYear.Properties.PopupFormSize = new System.Drawing.Size(26, 28);
            this.textEditFinancialYear.Properties.PopupView = this.gridLookUpEdit1View;
            this.textEditFinancialYear.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.textEditFinancialYear.Properties.ValueMember = "ID";
            this.textEditFinancialYear.Size = new System.Drawing.Size(406, 24);
            this.textEditFinancialYear.StyleController = this.dataLayoutControl1;
            this.textEditFinancialYear.TabIndex = 16;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "يجب إدخال هذا الحقل";
            this.dxValidationProvider1.SetValidationRule(this.textEditFinancialYear, conditionValidationRule4);
            // 
            // FinancialYearBindingSource
            // 
            this.FinancialYearBindingSource.DataSource = typeof(PosFinalCost.FinancialYear);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colfyStatus,
            this.colfyName,
            this.colfyId,
            this.colfyDateStart,
            this.colfyDateEnd});
            this.gridLookUpEdit1View.DetailHeight = 450;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
            this.gridLookUpEdit1View.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colfyName
            // 
            this.colfyName.FieldName = "Name";
            this.colfyName.MinWidth = 23;
            this.colfyName.Name = "colfyName";
            this.colfyName.Visible = true;
            this.colfyName.VisibleIndex = 0;
            this.colfyName.Width = 86;
            // 
            // colfyId
            // 
            this.colfyId.Caption = "colfyId";
            this.colfyId.FieldName = "ID";
            this.colfyId.MinWidth = 23;
            this.colfyId.Name = "colfyId";
            this.colfyId.Width = 86;
            // 
            // colfyDateStart
            // 
            this.colfyDateStart.Caption = "colfyDateStart";
            this.colfyDateStart.FieldName = "DateStart";
            this.colfyDateStart.MinWidth = 23;
            this.colfyDateStart.Name = "colfyDateStart";
            this.colfyDateStart.Width = 86;
            // 
            // colfyDateEnd
            // 
            this.colfyDateEnd.Caption = "colfyDateEnd";
            this.colfyDateEnd.FieldName = "DateEnd";
            this.colfyDateEnd.MinWidth = 23;
            this.colfyDateEnd.Name = "colfyDateEnd";
            this.colfyDateEnd.Width = 86;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceGroup.Options.UseForeColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(608, 319);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnLogIn;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 263);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(586, 34);
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlItem6});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(11, 11, 0, 12);
            this.layoutControlGroup4.Size = new System.Drawing.Size(586, 263);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.itemForBranchId,
            this.itemForFinancialYear,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 51);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(586, 212);
            this.layoutControlGroup3.Text = "بيانات المستخدم";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditUserName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(560, 28);
            this.layoutControlItem1.Text = "إسم المستخدم:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(136, 23);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditPassword;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(560, 28);
            this.layoutControlItem2.Text = "كلمة المرور:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(136, 23);
            // 
            // itemForBranchId
            // 
            this.itemForBranchId.Control = this.textEditBranchId;
            this.itemForBranchId.Location = new System.Drawing.Point(0, 56);
            this.itemForBranchId.Name = "itemForBranchId";
            this.itemForBranchId.Size = new System.Drawing.Size(560, 28);
            this.itemForBranchId.Text = "الفرع:";
            this.itemForBranchId.TextSize = new System.Drawing.Size(136, 23);
            // 
            // itemForFinancialYear
            // 
            this.itemForFinancialYear.Control = this.textEditFinancialYear;
            this.itemForFinancialYear.Location = new System.Drawing.Point(0, 84);
            this.itemForFinancialYear.Name = "itemForFinancialYear";
            this.itemForFinancialYear.Size = new System.Drawing.Size(560, 28);
            this.itemForFinancialYear.Text = "السنة المالية:";
            this.itemForFinancialYear.TextSize = new System.Drawing.Size(136, 23);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.radioGroupLanguage;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 112);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(560, 74);
            this.layoutControlItem5.Text = "Language / اللغة :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(136, 23);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.labelControl1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(287, 49);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(586, 51);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // colfyStatus
            // 
            this.colfyStatus.FieldName = "Status";
            this.colfyStatus.MaxWidth = 34;
            this.colfyStatus.MinWidth = 23;
            this.colfyStatus.Name = "colfyStatus";
            this.colfyStatus.Width = 34;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 319);
            this.Controls.Add(this.dataLayoutControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FormLogin.IconOptions.Icon")));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormLogin.IconOptions.SvgImage")));
            this.KeyPreview = true;
            this.Name = "FormLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBranchId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFinancialYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinancialYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForBranchId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton BtnLogIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit textEditUserName;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.RadioGroup radioGroupLanguage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem itemForBranchId;
        private DevExpress.XtraEditors.LookUpEdit textEditBranchId;
        private System.Windows.Forms.BindingSource BranchBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem itemForFinancialYear;
        private System.Windows.Forms.BindingSource FinancialYearBindingSource;
        private DevExpress.XtraEditors.GridLookUpEdit textEditFinancialYear;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colfyStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colfyName;
        private DevExpress.XtraGrid.Columns.GridColumn colfyId;
        private DevExpress.XtraGrid.Columns.GridColumn colfyDateStart;
        private DevExpress.XtraGrid.Columns.GridColumn colfyDateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}