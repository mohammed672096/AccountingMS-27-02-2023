namespace AccountingMS
{
    partial class formDBConnection
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDBConnection));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetServerName = new DevExpress.XtraEditors.SimpleButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.txtSqlUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtSqlPassword = new DevExpress.XtraEditors.TextEdit();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.ServersComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DataBaseComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupConnectDB = new DevExpress.XtraLayout.LayoutControlGroup();
            this.itemForServerName1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemForServerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSqlUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSqlPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServersComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupConnectDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForServerName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnTestConnection);
            this.layoutControl1.Controls.Add(this.btnResetServerName);
            this.layoutControl1.Controls.Add(this.rbWindows);
            this.layoutControl1.Controls.Add(this.txtSqlUserName);
            this.layoutControl1.Controls.Add(this.txtSqlPassword);
            this.layoutControl1.Controls.Add(this.rbSQL);
            this.layoutControl1.Controls.Add(this.ServersComboBox);
            this.layoutControl1.Controls.Add(this.DataBaseComboBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 30);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(487, 336);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(167, 273);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 38);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnTestConnection.Appearance.Options.UseFont = true;
            this.btnTestConnection.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTestConnection.ImageOptions.SvgImage")));
            this.btnTestConnection.Location = new System.Drawing.Point(316, 273);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(160, 38);
            this.btnTestConnection.StyleController = this.layoutControl1;
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "الإتصال بلسرفر";
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // btnResetServerName
            // 
            this.btnResetServerName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnResetServerName.Appearance.Options.UseFont = true;
            this.btnResetServerName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnResetServerName.ImageOptions.SvgImage")));
            this.btnResetServerName.Location = new System.Drawing.Point(11, 273);
            this.btnResetServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetServerName.Name = "btnResetServerName";
            this.btnResetServerName.Size = new System.Drawing.Size(152, 38);
            this.btnResetServerName.StyleController = this.layoutControl1;
            this.btnResetServerName.TabIndex = 7;
            this.btnResetServerName.Text = "السرفر الإفتراضي";
            this.btnResetServerName.Click += new System.EventHandler(this.BtnResetServerName_Click);
            // 
            // rbWindows
            // 
            this.rbWindows.Checked = true;
            this.rbWindows.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.rbWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbWindows.Location = new System.Drawing.Point(244, 140);
            this.rbWindows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(221, 25);
            this.rbWindows.TabIndex = 19;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Windows Authentication";
            this.rbWindows.UseVisualStyleBackColor = true;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbSQL_CheckedChanged);
            // 
            // txtSqlUserName
            // 
            this.txtSqlUserName.Location = new System.Drawing.Point(33, 205);
            this.txtSqlUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSqlUserName.Name = "txtSqlUserName";
            this.txtSqlUserName.Size = new System.Drawing.Size(315, 20);
            this.txtSqlUserName.StyleController = this.layoutControl1;
            this.txtSqlUserName.TabIndex = 4;
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(33, 229);
            this.txtSqlPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Properties.PasswordChar = '*';
            this.txtSqlPassword.Properties.UseSystemPasswordChar = true;
            this.txtSqlPassword.Size = new System.Drawing.Size(315, 20);
            this.txtSqlPassword.StyleController = this.layoutControl1;
            this.txtSqlPassword.TabIndex = 4;
            // 
            // rbSQL
            // 
            this.rbSQL.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.rbSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbSQL.Location = new System.Drawing.Point(22, 140);
            this.rbSQL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSQL.Name = "rbSQL";
            this.rbSQL.Size = new System.Drawing.Size(218, 25);
            this.rbSQL.TabIndex = 20;
            this.rbSQL.TabStop = true;
            this.rbSQL.Text = "SQL Server Authentication";
            this.rbSQL.UseVisualStyleBackColor = true;
            // 
            // ServersComboBox
            // 
            this.ServersComboBox.Location = new System.Drawing.Point(22, 46);
            this.ServersComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ServersComboBox.Name = "ServersComboBox";
            this.ServersComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ServersComboBox.Size = new System.Drawing.Size(337, 20);
            this.ServersComboBox.StyleController = this.layoutControl1;
            this.ServersComboBox.TabIndex = 4;
            // 
            // DataBaseComboBox
            // 
            this.DataBaseComboBox.Location = new System.Drawing.Point(22, 70);
            this.DataBaseComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataBaseComboBox.Name = "DataBaseComboBox";
            this.DataBaseComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataBaseComboBox.Size = new System.Drawing.Size(337, 20);
            this.DataBaseComboBox.StyleController = this.layoutControl1;
            this.DataBaseComboBox.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Root.AppearanceGroup.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupConnectDB,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlGroup4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(487, 336);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroupConnectDB
            // 
            this.layoutControlGroupConnectDB.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itemForServerName1,
            this.itemForServerName});
            this.layoutControlGroupConnectDB.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupConnectDB.Name = "layoutControlGroupConnectDB";
            this.layoutControlGroupConnectDB.Size = new System.Drawing.Size(469, 94);
            this.layoutControlGroupConnectDB.Text = "إسم السرفر وقاعدة البيانات";
            // 
            // itemForServerName1
            // 
            this.itemForServerName1.Control = this.DataBaseComboBox;
            this.itemForServerName1.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.itemForServerName1.CustomizationFormText = "إسم السرفر :";
            this.itemForServerName1.Location = new System.Drawing.Point(0, 24);
            this.itemForServerName1.Name = "itemForServerName1";
            this.itemForServerName1.Size = new System.Drawing.Size(447, 24);
            this.itemForServerName1.Text = "اسم قاعدة البيانات:";
            this.itemForServerName1.TextSize = new System.Drawing.Size(102, 17);
            // 
            // itemForServerName
            // 
            this.itemForServerName.Control = this.ServersComboBox;
            this.itemForServerName.Location = new System.Drawing.Point(0, 0);
            this.itemForServerName.Name = "itemForServerName";
            this.itemForServerName.Size = new System.Drawing.Size(447, 24);
            this.itemForServerName.Text = "إسم السرفر :";
            this.itemForServerName.TextSize = new System.Drawing.Size(102, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnTestConnection;
            this.layoutControlItem2.Location = new System.Drawing.Point(305, 263);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(164, 57);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(156, 263);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(149, 57);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnResetServerName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 263);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(156, 57);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = ":(Server) طريقة الدخول الى الخادم";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlGroup5,
            this.layoutControlItem12});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 94);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.OptionsItemText.TextToControlDistance = 3;
            this.layoutControlGroup4.Size = new System.Drawing.Size(469, 169);
            this.layoutControlGroup4.Text = ":(Server) طريقة الدخول الى الخادم";
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.rbWindows;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(222, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(225, 29);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "SQL SERVER الدخول بحساب ";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 29);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.OptionsItemText.TextToControlDistance = 3;
            this.layoutControlGroup5.Size = new System.Drawing.Size(447, 94);
            this.layoutControlGroup5.Text = "SQL SERVER الدخول بحساب ";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSqlUserName;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(425, 24);
            this.layoutControlItem4.Text = "اسم المستخدم:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(102, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtSqlPassword;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(425, 24);
            this.layoutControlItem5.Text = "كلمة المرور:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(102, 17);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.rbSQL;
            this.layoutControlItem12.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(222, 29);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 256;
            this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
            this.ribbonControl1.OptionsTouch.TouchUI = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(487, 30);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // formDBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 366);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("formDBConnection.IconOptions.Icon")));
            this.IconOptions.Image = global::AccountingMS.Properties.Resources.iconICOMultiSize;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formDBConnection";
            this.Ribbon = this.ribbonControl1;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ربط فاعدة البيانات";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSqlUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSqlPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServersComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupConnectDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForServerName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemForServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupConnectDB;
        private DevExpress.XtraLayout.LayoutControlItem itemForServerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnResetServerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraLayout.LayoutControlItem itemForServerName1;
        private System.Windows.Forms.RadioButton rbWindows;
        private DevExpress.XtraEditors.TextEdit txtSqlUserName;
        private DevExpress.XtraEditors.TextEdit txtSqlPassword;
        private System.Windows.Forms.RadioButton rbSQL;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.ComboBoxEdit ServersComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit DataBaseComboBox;
    }
}