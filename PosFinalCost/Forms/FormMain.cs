using PosFinalCost.Classe;
using PosFinalCost.Forms;
using PosFinalCost.Properties;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTab;
using static PosFinalCost.SelectReportInvoiceLayout;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts.Native;

namespace PosFinalCost
{
    public partial class FormMain : RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        //ClsTblNotification clsTbNotification = new ClsTblNotification();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Boolean isSale = true;
        private IOverlaySplashScreenHandle overlaySplashScreen;

        protected override FormShowMode ShowMode { get { return FormShowMode.AfterInitialization; } }

        protected override void OnShown(EventArgs e)
        {
            SplashScreenManager.CloseForm();
            base.OnShown(e);
            Root.Expanded = Program.My_Setting.ShowBarSideMenu;
            ribbonControl.SelectedPage = ribbonPage1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSkin();
            GetResources();
            InitView();
            ShowNotifications();
            SetTouchControls();
            Task.Run(() => InitNotificationsCount());
            Task.Run(() => InitNotificationsPanel());
            SetFont();
            xtraTabControl1.CloseButtonClick += XtraTabControl1_CloseButtonClick;
        }
     
        public FormMain(Boolean _isSale = false)
        {
            InitializeComponent();
         this.Text = Program.NameProgram;
            CreateFolderDirectory();
            //SetStaticClassData();
            InitUserRights();
            SetMainNavigationPage();
            InitTimer();
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            ribbonControl.MouseMove += RibbonControl_MouseMove;
        }
        private void XtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            if ((arg.Page as XtraTabPage).Name == xtraTabPageMain.Name)
                return;
            (arg.Page as XtraTabPage).Dispose();
        }
      
        private void InitTimer()
        {
            this.timer.Interval = 1000;
            this.timer.Tick += OnTick;
            this.timer.Start();
        }
        private void OnTick(object sender, EventArgs e)
        {
            bsiClock.Caption = $"{DateTime.Now:F}";
        }

        private void SetMainNavigationPage()
        {
            bsiNavigationPage.Caption = "الرئيسية";
        }

        private void InitView()
        {
            bsiVersion.Caption =// $"v.{ClsVersion.Current}" + "  " +
                Session.CurrentBranch.Name;
            bbiCompactMode.Checked = Program.My_Setting.compactMode;
            SetCompactMode();
            InitMenuCaption();
        }

        private void InitUserRights()
        {
            bsiUserName.Caption = Session.CurrentUser.Name;
            if (Session.CurrentUser.ID == 1) return;
            new ClsUserRoleValidation(this);
        }

        private void CreateFolderDirectory()
        {
            if (!Directory.Exists(Program.pathLayoutToXml))
                Directory.CreateDirectory(Program.pathLayoutToXml);
            if (!Directory.Exists(ClsPath.ReportSupplyCustomFolder))
                Directory.CreateDirectory(ClsPath.ReportSupplyCustomFolder);
        }

   
        private void SetTouchControls()
        {
            bbiTouchUI.Checked = Program.My_Setting.touchUI;
            bbiTouchScaleFactor.EditValue = Program.My_Setting.touchScaleFactor;
        }

        private void ShowNotifications()
        {
            if (Program.My_Setting.showErrorMssg)
            {
                toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[1]);
                Program.My_Setting.showErrorMssg = false;
                //Program.My_Setting.Save();
            }

            if (Session.CurrSettings.DefaultBox == 0 || Session.CurrSettings.DefaultBank == 0 ||
                Session.CurrSettings.DefaultStore == 0 || string.IsNullOrWhiteSpace(Session.CurrSettings.DefaultSalesPrinterName))
                toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
        }

    

        private void toastNotificationsManager1_Activated(object sender,ToastNotificationEventArgs e)
        {
            //if (e.NotificationID.ToString() != "2b686632-166d-4870-84e4-1c83b3c452f1") return;

            //this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            //using var form = new formDefaultSettings();
            //this.overlaySplashScreen.Close();
            //form.ShowDialog();
        }

        private void NavigationFrame_SelectedPageChanging(object sender, SelectedPageChangingEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
        }

        private void SetRibbonPage()
        {
            ribbonPageView.Visible = false;
        }

        private void ShowFormDialog(dynamic form)
        {
            using (form) { form.ShowDialog(); }
        }

       
        private void ribbonControl_Merge(object sender, RibbonMergeEventArgs e)
        {
           
               RibbonControl parentRibbon = sender as RibbonControl;
            RibbonControl childRibbon = e.MergedChild;
            parentRibbon?.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ForceExit) return;
            FlyoutCommand flyoutCommandYes = new FlyoutCommand()
            {
                Text = (!Program.My_Setting.LangEng) ? "نعم" : "Yes",
                Result = DialogResult.Yes,
            };
            FlyoutCommand flyoutCommandNo = new FlyoutCommand()
            {
                Text = (!Program.My_Setting.LangEng) ? "لا" : "No",
                Result = DialogResult.No,
            };
            FlyoutAction flyoutAction = new FlyoutAction()
            {
                Caption = (!Program.My_Setting.LangEng) ? "إغلاق النظام" : "Close Application",
                Description = _resource.GetString("ApplicationCloseMssg")
            };
            flyoutAction.Commands.Add(flyoutCommandNo);
            flyoutAction.Commands.Add(flyoutCommandYes);

            if (new FlyoutDialog(this, flyoutAction).ShowDialog() != DialogResult.Yes) e.Cancel = true;
        }

        private void InitSkin()
        {
            string skinName = Program.My_Setting.ApplicationSkinName;

            if (skinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(skinName, Program.My_Setting.ApplicationSkinPaletteBezier);
            else if (skinName == "Office 2019 Colorful")
                UserLookAndFeel.Default.SetSkinStyle(skinName, Program.My_Setting.ApplicationSkinPaletteOffice);
            else
                UserLookAndFeel.Default.SetSkinStyle(skinName);
        }

        private void skinPaletteRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                Program.My_Setting.ApplicationSkinPaletteBezier = e.Item.Caption;
            else
                Program.My_Setting.ApplicationSkinPaletteOffice = e.Item.Caption;
            MySetting.ReadWriterSettingXml();
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, Program.My_Setting.ApplicationSkinPaletteBezier);
            else if (UserLookAndFeel.Default.ActiveSkinName == "Office 2019 Colorful")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, Program.My_Setting.ApplicationSkinPaletteOffice);

            SaveSkinName();
        }

        private void SaveSkinName()
        {
            Program.My_Setting.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            MySetting.ReadWriterSettingXml();
        }

        private void InitMenuCaption()
        {
            ribbonControl.ShowItemCaptionsInQAT = Program.My_Setting.hideMenuCaption;
            bbiHideMenuCaption.Checked = !Program.My_Setting.hideMenuCaption;
        }

        private void bbiHideMenuCaption_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ribbonControl.ShowItemCaptionsInQAT = !bbiHideMenuCaption.Checked;
            Program.My_Setting.hideMenuCaption = !bbiHideMenuCaption.Checked;
            MySetting.ReadWriterSettingXml();
        }

        private void BbiCompactMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            SetCompactMode();
            Program.My_Setting.compactMode = bbiCompactMode.Checked;
            MySetting.ReadWriterSettingXml();
            this.overlaySplashScreen.Close();
        }

        private void SetCompactMode()
        {
            WindowsFormsSettings.CompactUIMode = (bbiCompactMode.Checked) ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void bbiTouchUI_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            Program.My_Setting.touchUI = bbiTouchUI.Checked;
            MySetting.ReadWriterSettingXml();
            SetTouchUI();

            this.overlaySplashScreen.Close();
        }

        private void repoItemSpinEditTouchScaleFactor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            SpinEdit editor = sender as SpinEdit;
            if (editor?.EditValue == null) return;

            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            (bbiTouchScaleFactor.Links[0] as BarEditItemLink).PostEditor();
            Program.My_Setting.touchScaleFactor = (float)Convert.ToDouble(editor.EditValue);
            MySetting.ReadWriterSettingXml(); //Program.My_Setting.Save();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void repoItemSpinEditTouchScaleFactor_MouseUp(object sender, MouseEventArgs e)
        {
            (bbiTouchScaleFactor.Links[0] as BarEditItemLink).PostEditor();
            float scaleFactor = (float)Convert.ToDouble(bbiTouchScaleFactor.EditValue);

            if (scaleFactor == Program.My_Setting.touchScaleFactor) return;
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            Program.My_Setting.touchScaleFactor = scaleFactor;
            MySetting.ReadWriterSettingXml();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void SetTouchUI()
        {
            WindowsFormsSettings.TouchUIMode = (Program.My_Setting.touchUI) ? TouchUIMode.True : TouchUIMode.False;
            SetTouchScaleFactor();
        }

        private void SetTouchScaleFactor()
        {
            WindowsFormsSettings.TouchScaleFactor = Program.My_Setting.touchScaleFactor;
        }

        private void RibbonControl_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.ShowCustomizationMenu = false;
        }

        private void InitNotificationsCount()
        {
          //  badgeNotifications.Properties.Text = $"{this.clsTbNotification.GetNotCountUnCompleteByDate:n0}";
        }

        private void InitNotificationsPanel()
        {
            //flyoutPanelControlNotifications.Controls.Add(new UCnotificationsPeekView(this.clsTbNotification));
        }

        private void ClsTbNotification_RaiseNotificationsChanged(object sender, EventArgs e)
        {
            Task.Run(() => InitNotificationsCount());
        }

        private void RibbonControl_MouseMove(object sender, MouseEventArgs e)
        {
            RibbonHitInfo hitInfo = ribbonControl.CalcHitInfo(e.Location);
            if (hitInfo.InItem == false || hitInfo.Item == null) return;

            if (hitInfo.Item == btnUCnotifications.Links[0]) ShowNotificationsBeakView();
            else HideNotificationsBeakView();
        }

        private void ShowNotificationsBeakView()
        {
            flyoutPanelNotifications.Size = new Size(260, 450);

            int x = btnUCnotifications.Links[0].ScreenBounds.X + (btnUCnotifications.Links[0].ScreenBounds.Width / 2);
            int y = btnUCnotifications.Links[0].ScreenBounds.Y + (btnUCnotifications.Links[0].ScreenBounds.Height / 2) + 20;

            flyoutPanelNotifications.ShowBeakForm(new Point(x, y));
        }

        private void HideNotificationsBeakView()
        {
            if (flyoutPanelNotifications.IsPopupOpen) flyoutPanelNotifications.HideBeakForm();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      
        private void GetResources()
        {
            _resource = new ComponentResourceManager(typeof(FormMain));

            if (Program.My_Setting.LangEng) EnglishResources();
        }

        private void EnglishResources()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
            ribbonControl.Items.Where(x => x is BarSubItem).ForEach(c1 =>
            {
                _resource.ApplyResources(c1, c1.Name, _ci);
                c1.ItemAppearance.Normal.Font = new Font("Segoe UI", 9F);
            });
            ribbonControl.Items.Where(x => x is BarButtonItem).ForEach(c2 =>_resource.ApplyResources(c2, c2.Name, _ci));
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = WindowsFormsSettings.DefaultFont;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Program.My_Setting.SystemFont = converter.ConvertToString(dialog.Font);
                    MySetting.ReadWriterSettingXml();
                }
                SetFont();
            }
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
        public void SetFont()
        {
            Font fontConverter = (Font)converter.ConvertFromString(Program.My_Setting.SystemFont);
            WindowsFormsSettings.DefaultFont = fontConverter;
            AppearanceObject.DefaultFont = fontConverter;
            AppearanceObject.DefaultMenuFont = fontConverter;
            WindowsFormsSettings.DefaultFont = fontConverter;
            AppearanceObject.DefaultFont = fontConverter;
            ribbonControl.Items.Where(x => x is BarItem).ForEach(x => x.ItemAppearance.SetFont(fontConverter));
            //foreach (var item in ribbonControl.Items)
            //    if (item is BarItem bbi)
            //        bbi.ItemAppearance.SetFont(fontConverter);
        }
      

        private void simpleButtonSales_Click(object sender, EventArgs e)
        {
           new FormEntryMain(null, null, UserControls.Sale, this).Show();
            //new formSupplyMain(null,null,SupplyType.Sales,this).Show();
        }
      
        private void simpleButtonSaleRtrn_Click(object sender, EventArgs e)
        {
            TextEdit editor = new TextEdit();
            editor.Properties.UseSystemPasswordChar = true;
            XtraInputBoxArgs inputBoxArgs = new XtraInputBoxArgs();
            inputBoxArgs.Editor = editor;
            inputBoxArgs.Caption = "تأكيد";
            inputBoxArgs.Prompt = "يرجى إدخال الرقم السري:";
            var result = XtraInputBox.Show(inputBoxArgs)?.ToString();
            if (result != "134589")
            {
                ClsXtraMssgBox.ShowError("عذراً الرقم السري غير صحيح");
                return;
            }
            new FormEntryMain(null, null, UserControls.SaleRtrn, this).Show();
        }
        private void simpleButtonEntryRecipt_Click(object sender, EventArgs e)
        {
            new FormEntryMain(null, null, UserControls.EntryRcpt, this).Show();
        }
        private void Root_Hidden(object sender, EventArgs e)
        {
            if (ribbonControl.IsHandleCreated)
            {
                Program.My_Setting.ShowBarSideMenu = false;
                MySetting.ReadWriterSettingXml();
            }
        }

        private void Root_Shown(object sender, EventArgs e)
        {
            if (ribbonControl.IsHandleCreated)
            {
                Program.My_Setting.ShowBarSideMenu = true;
                MySetting.ReadWriterSettingXml();
            }
        }
       
        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            try
            {
                await Program.InitObjects();
            }
            catch (Exception)
            {
                flyDailog.WaitForm(this, 0);
                return;
            }
            flyDailog.WaitForm(this, 0);
        }
        UserControl Master;
        XtraTabPage tabpage;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        protected internal void SetUserControl(string name)
        {
            try
            {
                switch (name)
                {
                    case "barButDefaultSettings":
                        Master = new UC_Setting();
                        tabpage = new XtraTabPage() { Text = "ادارة الاعدادات", Name = name };
                        break;
                    case "barButUserRole":
                        Session.GetColNameForTable(name);
                        Master = new UC_User();
                        tabpage = new XtraTabPage() { Text = "ربط صلاحيات المستخدمين", Name = name };
                        break;
                    case "barButSales":
                        Master = new UC_MasterInvoice(SupplyType.Sales);
                        tabpage = new XtraTabPage() { Text = "فواتير المبيعات", Name = name };
                        break;
                    case "BtnDrawerPeriodOpen":
                        Master = new UC_DrawerPeriod(true);
                        tabpage = new XtraTabPage() { Text = "فتح يومية صندوق", Name = name };
                        break;
                    case "BtnDrawerPeriodView":
                        frm = new FormViewDrawer();
                        frm.Show();
                        return;
                    case "BtnDrawerPeriodClose":
                        Master = new UC_DrawerPeriod(false);
                        tabpage = new XtraTabPage() { Text = "اغلاق يومية صندوق", Name = name };
                        break;
                    case "BtnPrdExpirate":
      Master = new UC_ShowPrdExpirate();
                        tabpage = new XtraTabPage() { Text = "الاصناف التالفة", Name = name };
                        break;
                    case "barButGapth":
                        Master = new UC_MasterEntry(EntryType.EntryReceipt);
                        tabpage = new XtraTabPage() { Text = "سندات القبض", Name = name };
                        break;
                    case "barButReturnSales":
                        Master = new UC_MasterInvoice(SupplyType.SalesRtrn);
                        tabpage = new XtraTabPage() { Text = "فواتير مردودات المبيعات", Name = name };
                        break;
                    case "barButRole":
                        Master = new UCuserRight();
                        tabpage = new XtraTabPage() { Text = "ادارة الصلاحيات", Name = name };
                        break;
                    case "barButUploadData":
                        frm = Application.OpenForms["FormSynData"];
                        if (frm == null)
                        {
                            frm = new FormSynData();
                            frm.Show();
                        }
                        else frm.Activate();
                        return;
                    case "barButtonConnAccDB":
                        frm = Application.OpenForms["FormConncetionAccDB"];
                        if (frm == null)
                        {
                            frm = new FormConncetionAccDB();
                            frm.Show();
                        }
                        else frm.Activate();
                        return;
                    case "barButConnectionDB":
                        frm = Application.OpenForms["FormConncetionPosDB"];
                        if (frm == null)
                        {
                            frm = new FormConncetionPosDB();
                            frm.Show();
                        }
                        else frm.Activate();
                        return;
                    case "barButDesignReportCasher":
                            frm = new ReportEndUserForm(PrintPaperType.Cashier) { Text = "تصميم فاتورة كاشير" };
                            frm.Show();
                        return;
                    case "barButDesignReportA4":
                            frm = new ReportEndUserForm(PrintPaperType.A4) { Text = "تصميم فاتورة A4"};
                            frm.Show();
                        return;
                    case "BtnPrintBarcode":
                        frm = new formBarcode();
                        frm.Show();
                        return;
                    case "btnCalculater":
                        this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
                        System.Diagnostics.Process.Start("calc");
                        this.overlaySplashScreen.Close();
                        return;
                    case "btnUCmain":
                        xtraTabControl1.SelectedTabPage = xtraTabPageMain;
                        return;
                    default:
                        break;
                }
                if (Master == null)
                    return;
                if (xtraTabControl1.TabPages.Where(x => x.Name == tabpage.Name).Count() <= 0)
                {
                    tabpage.Controls.Add(Master);
                    Master.Dock = DockStyle.Fill;
                    xtraTabControl1.TabPages.Add(tabpage);
                    xtraTabControl1.SelectedTabPage = tabpage;
                }
                else
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.FirstOrDefault(x => x.Name == tabpage.Name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        Form frm;
        private void ribbonControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            SetUserControl(e.Item.Name);
            if(frm!=null)
            flyDailog.WaitForm(this, 0, frm);
            else flyDailog.WaitForm(this, 0);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(xtraTabControl1.SelectedTabPage.Controls[0] is UC_Master userControl)
                userControl.UC_Master_KeyDown(null,e);
          
        }

        
    }
}