namespace AccountingMS
{
    partial class formAddPrdExpirateObj
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.expSupNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tblPrdExpirateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expPrdDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.exprPrdIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expPrdMsurIdTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tblPrdPriceMeasurmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForexprPrdId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForexpPrdMsurId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForexpSupNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForexpPrdDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expSupNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exprPrdIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdMsurIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexprPrdId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpPrdMsurId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpSupNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpPrdDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.expSupNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.expPrdDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.exprPrdIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.expPrdMsurIdTextEdit);
            this.dataLayoutControl1.DataSource = this.tblPrdExpirateBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 132);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(518, 225);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // expSupNoTextEdit
            // 
            this.expSupNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblPrdExpirateBindingSource, "expSupNo", true));
            this.expSupNoTextEdit.Location = new System.Drawing.Point(19, 45);
            this.expSupNoTextEdit.Name = "expSupNoTextEdit";
            this.expSupNoTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.expSupNoTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.expSupNoTextEdit.Properties.Mask.EditMask = "N0";
            this.expSupNoTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.expSupNoTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.expSupNoTextEdit.Size = new System.Drawing.Size(406, 20);
            this.expSupNoTextEdit.StyleController = this.dataLayoutControl1;
            this.expSupNoTextEdit.TabIndex = 6;
            // 
            // tblPrdExpirateBindingSource
            // 
            this.tblPrdExpirateBindingSource.DataSource = typeof(AccountingMS.tblPrdExpirate);
            // 
            // expPrdDateDateEdit
            // 
            this.expPrdDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblPrdExpirateBindingSource, "expPrdDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.expPrdDateDateEdit.EditValue = null;
            this.expPrdDateDateEdit.Location = new System.Drawing.Point(19, 117);
            this.expPrdDateDateEdit.Name = "expPrdDateDateEdit";
            this.expPrdDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.expPrdDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.expPrdDateDateEdit.Size = new System.Drawing.Size(406, 20);
            this.expPrdDateDateEdit.StyleController = this.dataLayoutControl1;
            this.expPrdDateDateEdit.TabIndex = 7;
            // 
            // exprPrdIdTextEdit
            // 
            this.exprPrdIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblPrdExpirateBindingSource, "exprPrdId", true));
            this.exprPrdIdTextEdit.Location = new System.Drawing.Point(19, 69);
            this.exprPrdIdTextEdit.Name = "exprPrdIdTextEdit";
            this.exprPrdIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.exprPrdIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.exprPrdIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.exprPrdIdTextEdit.Properties.DataSource = this.tblProductBindingSource;
            this.exprPrdIdTextEdit.Properties.DisplayMember = "prdName";
            this.exprPrdIdTextEdit.Properties.NullText = "";
            this.exprPrdIdTextEdit.Properties.ValueMember = "id";
            this.exprPrdIdTextEdit.Size = new System.Drawing.Size(406, 20);
            this.exprPrdIdTextEdit.StyleController = this.dataLayoutControl1;
            this.exprPrdIdTextEdit.TabIndex = 4;
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataSource = typeof(AccountingMS.tblProduct);
            // 
            // expPrdMsurIdTextEdit
            // 
            this.expPrdMsurIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblPrdExpirateBindingSource, "expPrdMsurId", true));
            this.expPrdMsurIdTextEdit.Location = new System.Drawing.Point(19, 93);
            this.expPrdMsurIdTextEdit.Name = "expPrdMsurIdTextEdit";
            this.expPrdMsurIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.expPrdMsurIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.expPrdMsurIdTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.expPrdMsurIdTextEdit.Properties.DataSource = this.tblPrdPriceMeasurmentBindingSource;
            this.expPrdMsurIdTextEdit.Properties.DisplayMember = "ppmMsurName";
            this.expPrdMsurIdTextEdit.Properties.NullText = "";
            this.expPrdMsurIdTextEdit.Properties.ValueMember = "ppmId";
            this.expPrdMsurIdTextEdit.Size = new System.Drawing.Size(406, 20);
            this.expPrdMsurIdTextEdit.StyleController = this.dataLayoutControl1;
            this.expPrdMsurIdTextEdit.TabIndex = 5;
            // 
            // tblPrdPriceMeasurmentBindingSource
            // 
            this.tblPrdPriceMeasurmentBindingSource.DataSource = typeof(AccountingMS.tblPrdPriceMeasurment);
            // 
            // Root
            // 
            this.Root.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.Root.AppearanceGroup.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 2;
            this.Root.Size = new System.Drawing.Size(518, 225);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupMain});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(498, 205);
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForexprPrdId,
            this.ItemForexpPrdMsurId,
            this.ItemForexpSupNo,
            this.ItemForexpPrdDate});
            this.layoutControlGroupMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupMain.Name = "layoutControlGroupMain";
            this.layoutControlGroupMain.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroupMain.Size = new System.Drawing.Size(498, 205);
            this.layoutControlGroupMain.Text = "تعديل تاريخ إنتهاء الصنف: ";
            // 
            // ItemForexprPrdId
            // 
            this.ItemForexprPrdId.Control = this.exprPrdIdTextEdit;
            this.ItemForexprPrdId.Enabled = false;
            this.ItemForexprPrdId.Location = new System.Drawing.Point(0, 24);
            this.ItemForexprPrdId.Name = "ItemForexprPrdId";
            this.ItemForexprPrdId.Size = new System.Drawing.Size(484, 24);
            this.ItemForexprPrdId.Text = "الصنف:";
            this.ItemForexprPrdId.TextSize = new System.Drawing.Size(72, 17);
            // 
            // ItemForexpPrdMsurId
            // 
            this.ItemForexpPrdMsurId.Control = this.expPrdMsurIdTextEdit;
            this.ItemForexpPrdMsurId.Enabled = false;
            this.ItemForexpPrdMsurId.Location = new System.Drawing.Point(0, 48);
            this.ItemForexpPrdMsurId.Name = "ItemForexpPrdMsurId";
            this.ItemForexpPrdMsurId.Size = new System.Drawing.Size(484, 24);
            this.ItemForexpPrdMsurId.Text = "وحدة القياس:";
            this.ItemForexpPrdMsurId.TextSize = new System.Drawing.Size(72, 17);
            // 
            // ItemForexpSupNo
            // 
            this.ItemForexpSupNo.Control = this.expSupNoTextEdit;
            this.ItemForexpSupNo.Enabled = false;
            this.ItemForexpSupNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForexpSupNo.Name = "ItemForexpSupNo";
            this.ItemForexpSupNo.Size = new System.Drawing.Size(484, 24);
            this.ItemForexpSupNo.Text = "رقم الفاتورة:";
            this.ItemForexpSupNo.TextSize = new System.Drawing.Size(72, 17);
            // 
            // ItemForexpPrdDate
            // 
            this.ItemForexpPrdDate.Control = this.expPrdDateDateEdit;
            this.ItemForexpPrdDate.Location = new System.Drawing.Point(0, 72);
            this.ItemForexpPrdDate.Name = "ItemForexpPrdDate";
            this.ItemForexpPrdDate.Size = new System.Drawing.Size(484, 93);
            this.ItemForexpPrdDate.Text = "تاريخ الإنتهاء:";
            this.ItemForexpPrdDate.TextSize = new System.Drawing.Size(72, 17);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSave,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(518, 132);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "حفظ";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.save;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "إغلاق";
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.SvgImage = global::AccountingMS.Properties.Resources.clearheaderandfooter;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
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
            // formAddPrdExpirateObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 357);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "formAddPrdExpirateObj";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعديل تاريخ إنتهاء الصنف: ";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expSupNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdExpirateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exprPrdIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expPrdMsurIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrdPriceMeasurmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexprPrdId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpPrdMsurId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpSupNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForexpPrdDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource tblPrdExpirateBindingSource;
        private DevExpress.XtraEditors.TextEdit expSupNoTextEdit;
        private DevExpress.XtraEditors.DateEdit expPrdDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForexprPrdId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForexpPrdMsurId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForexpSupNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForexpPrdDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraEditors.LookUpEdit exprPrdIdTextEdit;
        private DevExpress.XtraEditors.LookUpEdit expPrdMsurIdTextEdit;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private System.Windows.Forms.BindingSource tblPrdPriceMeasurmentBindingSource;
    }
}