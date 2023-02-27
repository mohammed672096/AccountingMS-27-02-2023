namespace AccountingMS
{
    partial class formRoleControl
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
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition1 = new DevExpress.Utils.Animation.SlideFadeTransition();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tblRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.textEditRoleId = new DevExpress.XtraEditors.LookUpEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRoleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiClose});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 12;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.mainRibbonControl.ShowQatLocationSelector = false;
            this.mainRibbonControl.ShowToolbarCustomizeItem = false;
            this.mainRibbonControl.Size = new System.Drawing.Size(820, 113);
            this.mainRibbonControl.Toolbar.ShowCustomizeItem = false;
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.LargeImage = global::AccountingMS.Properties.Resources.close_32x32;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "الرئيسية";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "العمليات";
            // 
            // tblRoleBindingSource
            // 
            this.tblRoleBindingSource.DataSource = typeof(tblRole);
            // 
            // textEditRoleId
            // 
            this.textEditRoleId.Location = new System.Drawing.Point(19, 45);
            this.textEditRoleId.MenuManager = this.mainRibbonControl;
            this.textEditRoleId.Name = "textEditRoleId";
            this.textEditRoleId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditRoleId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("rolName", "إسم الصلاحية")});
            this.textEditRoleId.Properties.DataSource = this.tblRoleBindingSource;
            this.textEditRoleId.Properties.DisplayMember = "rolName";
            this.textEditRoleId.Properties.NullText = "";
            this.textEditRoleId.Properties.ShowHeader = false;
            this.textEditRoleId.Properties.ValueMember = "rolId";
            this.textEditRoleId.Size = new System.Drawing.Size(733, 20);
            this.textEditRoleId.StyleController = this.dataLayoutControl1;
            this.textEditRoleId.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "يجب إدخال هذا الحقل!";
            this.dxValidationProvider1.SetValidationRule(this.textEditRoleId, conditionValidationRule1);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.textEditRoleId);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 113);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(820, 517);
            this.dataLayoutControl1.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.MoveFocusRightToLeft = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(820, 517);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 10);
            this.layoutControlGroup2.Size = new System.Drawing.Size(800, 69);
            this.layoutControlGroup2.Text = "إسم الصلاحية";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.textEditRoleId;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(786, 24);
            this.layoutControlItem1.Text = "الصلاحية";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 17);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 69);
            this.layoutControlGroup3.MoveFocusRightToLeft = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 10);
            this.layoutControlGroup3.Size = new System.Drawing.Size(800, 428);
            this.layoutControlGroup3.Text = "إذن الصلاحية";
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.AllowHide = false;
            this.tabbedControlGroup1.AppearanceTabPage.Header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedControlGroup1.AppearanceTabPage.Header.ForeColor = System.Drawing.Color.Black;
            this.tabbedControlGroup1.AppearanceTabPage.Header.Options.UseFont = true;
            this.tabbedControlGroup1.AppearanceTabPage.Header.Options.UseForeColor = true;
            this.tabbedControlGroup1.AppearanceTabPage.Header.Options.UseTextOptions = true;
            this.tabbedControlGroup1.AppearanceTabPage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.ForeColor = System.Drawing.Color.Blue;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseForeColor = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.Options.UseTextOptions = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseForeColor = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseTextOptions = true;
            this.tabbedControlGroup1.AppearanceTabPage.HeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tabbedControlGroup1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = null;
            this.tabbedControlGroup1.ShowInCustomizationForm = false;
            this.tabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(796, 378);
            this.tabbedControlGroup1.StartNewLine = true;
            this.tabbedControlGroup1.TextLocation = DevExpress.Utils.Locations.Right;
            this.tabbedControlGroup1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True;
            this.tabbedControlGroup1.Transition.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
            this.tabbedControlGroup1.Transition.TransitionType = slideFadeTransition1;
            // 
            // formRoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(820, 630);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "formRoleControl";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إذن الصلاحيات";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRoleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.BindingSource tblRoleBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LookUpEdit textEditRoleId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
    }
}