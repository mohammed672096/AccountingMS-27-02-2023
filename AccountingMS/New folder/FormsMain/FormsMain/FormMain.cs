using AccountingMS.Classes;
using AccountingMS.Forms;
using AccountingMS.Properties;
using AccountingMS.Report;
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
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingMS
{
    public partial class FormMain : RibbonForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        ClsTblNotification clsTbNotification = new ClsTblNotification();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Boolean isSale = true;
        private IOverlaySplashScreenHandle overlaySplashScreen;

        protected override FormShowMode ShowMode { get { return FormShowMode.AfterInitialization; } }

        protected override void OnShown(EventArgs e)
        {
            SplashScreenManager.CloseForm();
            base.OnShown(e);
            Root.Expanded = MySetting.GetPrivateSetting.ShowBarSideMenu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSkin();
            GetResources();
            SetOrdersBtnCapton();
            InitView();
            new ClsSystem();
            if (xtraTabControl1.TabPages.Count > 0)
            {
                xtraTabControl1.TabPages[0].Controls.Add(new ucMain(this) { Dock = DockStyle.Fill });
                xtraTabControl1.TabPages[0].Name = btnUCmain.Name;
            }

            //InitiUserPermision();
            ShowNotifications();
            SetTouchControls();

            if (Session.CurrentUser.id == 1)
                Task.Factory.StartNew(Employee);

            Task.Run(() => InitNotificationsCount());
            Task.Run(() => InitNotificationsPanel());
            SetFont();
            if (Session.CurrentUser.id != 1)
                layoutControlGroupEntry.Visibility = layoutControlGroupAccount.Visibility =
                  layoutControlGroupProduct.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
       
        //void InitiUserPermision()
        //{
        //    var _resource2 = new ComponentResourceManager(typeof(Language.Form1En));
        //    List<tblAllUserControl> userControls = new List<tblAllUserControl>();
        //    var parent = ribbonControl.Items.Where(x => (x is BarSubItem) && x.Caption != string.Empty && (x.Links[0].LinkedObject as BarSubItem) == null && (x as BarSubItem).ItemLinks.Count > 0);
        //    using (var db = new accountingEntities())
        //    {
        //        var AllUserControl = db.tblAllUserControls.ToList();
        //        foreach (BarSubItem item in parent)
        //        {
        //            var p = new tblAllUserControl
        //            {
        //                Caption = item.Caption,
        //                CaptionEn = _resource2.GetString($"{item.Name}.Caption"),
        //                Name = item.Name,
        //                ParentID = 0,
        //                ID = AllUserControl.FirstOrDefault(x => x.Name == item.Name)?.ID ?? 0
        //            };
        //            db.tblAllUserControls.AddOrUpdate(p);
        //            db.SaveChanges();

        //            var subItem = (from r in item.ItemLinks.Where(x => x.Caption != string.Empty && (x.Item is BarButtonItem))
        //                           select new tblAllUserControl
        //                           {
        //                               Caption = r.Caption,
        //                               Name = r.Item.Name,
        //                               CaptionEn = _resource2.GetString($"{r.Item.Name}.Caption"),
        //                               ParentID = p.ID
        //                           }).ToList();

        //            subItem.ForEach(x =>
        //            {
        //                x.ID = AllUserControl.FirstOrDefault(y => y.Name == x.Name)?.ID ?? 0;
        //                db.tblAllUserControls.AddOrUpdate(x);
        //            });
        //            var subParent = item.ItemLinks.Where(x => (x is BarSubItemLink) && (x.Links[0].LinkedObject as BarSubItemLink) == null && (x as BarSubItemLink).Item.ItemLinks.Count > 0).Select(x => x.Item);

        //            foreach (BarSubItem item2 in subParent)
        //            {
        //                var p2 = new tblAllUserControl
        //                {
        //                    Caption = item2.Caption,
        //                    CaptionEn = _resource2.GetString($"{item2.Name}.Caption"),
        //                    Name = item2.Name,
        //                    ParentID = p.ID,
        //                    ID = AllUserControl.FirstOrDefault(x => x.Name == item2.Name)?.ID ?? 0
        //                };
        //                db.tblAllUserControls.AddOrUpdate(p2);
        //                db.SaveChanges();

        //                var subItem2 = (from r in item2.ItemLinks.Where(x => x.Caption != string.Empty && (x.Item is BarButtonItem))
        //                                select new tblAllUserControl
        //                                {
        //                                    Caption = r.Caption,
        //                                    Name = r.Item.Name,
        //                                    CaptionEn = _resource2.GetString($"{r.Item.Name}.Caption"),
        //                                    ID = r.Item.Id,
        //                                    ParentID = p2.ID
        //                                }).ToList();
        //                subItem2.ForEach(x =>
        //                {
        //                    x.ID = AllUserControl.FirstOrDefault(y => y.Name == x.Name)?.ID ?? 0;
        //                    db.tblAllUserControls.AddOrUpdate(x);
        //                });
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //}
        public FormMain(Boolean _isSale = false)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreenMohamed));
            InitializeComponent();
            TrailRemainingDays();
            CreateFolderDirectory();
            SetStaticClassData();
            InitUserRights();
            InitTimer();
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            ribbonControl.MouseMove += RibbonControl_MouseMove;
            this.clsTbNotification.RaiseNotificationsChanged += ClsTbNotification_RaiseNotificationsChanged;
            xtraTabControl1.CloseButtonClick += XtraTabControl1_CloseButtonClick;
            xtraTabControl1.SelectedPageChanged += XtraTabControl1_SelectedPageChanged;
            ribbonPageView.Visible = false;
            bsiNavigationPage.Caption = "الرئيسية";
        }

        private void XtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            bsiNavigationPage.Caption = e.Page.Text;
        }

        private void XtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            if ((arg.Page as XtraTabPage).Name == xtraTabPageMain.Name)
                return;
            (arg.Page as XtraTabPage).Dispose();
        }


        private void SetStaticClassData()
        {
            if (!MySetting.GetPrivateSetting.restartForm) return;
            Console.WriteLine($"=======PassedStaticClassDatacondition");
            MySetting.GetPrivateSetting.restartForm = false;
            MySetting.WriterSettingXml();

            Session.CurrentUser.id = MySetting.GetPrivateSetting.tmpUsrId;
            Session.RoleId = MySetting.GetPrivateSetting.tmpRoleId;
            Session.CurrentUser.userName = MySetting.GetPrivateSetting.tmpUsrName;
            Session.CurBranch.brnId = MySetting.GetPrivateSetting.tmpBrnId;
            Session.CurBranch.brnName = MySetting.GetPrivateSetting.tmpBrnName;
            Session.CurrentYear.fyId = MySetting.GetPrivateSetting.tmpFyId;
            Session.CurrentYear.fyDateStart = MySetting.GetPrivateSetting.tmpFyDtStart;
            Session.CurrentYear.fyDateEnd = MySetting.GetPrivateSetting.tmpFyDtEnd;
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
        private void InitView()
        {
            bsiVersion.Caption = $"v.{ClsVersion.Current}" + "  " + Session.CurBranch.brnName;
            bbiCompactMode.Checked = MySetting.GetPrivateSetting.compactMode;
            SetCompactMode();
            InitMenuCaption();
        }
        private void InitUserRights()
        {
            bsiUserName.Caption = Session.CurrentUser.userName;
            if (Session.CurrentUser.id == 1) return;

            new ClsUserRoleValidation(this);
            barButtonItemPurchaseDel.Visibility = BarItemVisibility.Never;
            barButtonItemPurchaseRtrnDel.Visibility = BarItemVisibility.Never;
            barButtonItemSaleDel.Visibility = BarItemVisibility.Never;
            barButtonItemSaleRtrnDel.Visibility = BarItemVisibility.Never;
            barButtonItemSalePriceOffer.Visibility = BarItemVisibility.Never;
        }

        private void CreateFolderDirectory()
        {
            if (!Directory.Exists(ClsPath.pathLayoutToXml))
                Directory.CreateDirectory(ClsPath.pathLayoutToXml);
            if (Directory.Exists(ClsDrive.Path + @":\") == false) return;
            Directory.CreateDirectory(@$"{ClsDrive.Path}:\B-Tech\DB");
            Directory.CreateDirectory(@$"{ClsDrive.Path}:\B-Tech\Layout");
            Directory.CreateDirectory(@$"{ClsDrive.Path}:\B-Tech\TempSupplyRcpt{Session.CurrentYear.fyName}");
            Directory.CreateDirectory(ClsPath.ReportSupplyCustomFolder);
        }

        accountingEntities db = new accountingEntities();
        Task Employee()
        {
            var Insurance = db.tblEmployees.Where(x => x.expirationInsurance.HasValue).ToList();
            var expirationInsurance = Insurance.Select(x => new
            {
                x.empName,
                reminder = x.reminderInsurance.HasValue ? x.reminderInsurance : 30,
                expiration = (int)x.expirationInsurance.Value.Date.Subtract(DateTime.Now).TotalDays
            }).ToList();
            var Residence = db.tblEmployees.Where(x => x.expirationResidence.HasValue).ToList();
            var expirationResidence = Residence.Select(x => new
            {
                x.empName,
                reminder = x.reminderResidence.HasValue ? x.reminderResidence : 30,
                expiration = (int)x.expirationResidence.Value.Date.Subtract(DateTime.Now).TotalDays
            }).ToList();

            foreach (var item in expirationInsurance)
            {
                if (item.expiration > item.reminder) continue;
                var toasts = new DevExpress.XtraBars.ToastNotifications.ToastNotification(item.empName, null, "انتهاء مدة التأمين", $"تبقي علي تاريخ انتهاء مدة التأمين الموظف {item.empName} {item.expiration} يوم", null, ToastNotificationTemplate.ImageAndText02);
                toastNotificationsManager1.ShowNotification(toasts);
            }

            foreach (var item in expirationResidence)
            {
                if (item.expiration > item.reminder) continue;
                var toasts = new DevExpress.XtraBars.ToastNotifications.ToastNotification(item.empName, null, "انتهاء مدة الإقامة", $"تبقي علي تاريخ انتهاء مدة إقامة الموظف {item.empName} {item.expiration} يوم", null, ToastNotificationTemplate.ImageAndText02);
                toastNotificationsManager1.ShowNotification(toasts);
            }
            System.Threading.Thread.Sleep(1200000);
            Employee().Start();
            return default;
        }
        private void SetTouchControls()
        {
            bbiTouchUI.Checked = MySetting.GetPrivateSetting.touchUI;
            bbiTouchScaleFactor.EditValue = MySetting.GetPrivateSetting.touchScaleFactor;
        }

        private void ShowNotifications()
        {
            if (MySetting.GetPrivateSetting.showErrorMssg)
            {
                toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[1]);
                MySetting.GetPrivateSetting.showErrorMssg = false;
                MySetting.WriterSettingXml();
            }

            if (MySetting.DefaultSetting.defaultBox == 0 || MySetting.DefaultSetting.defaultBank == 0 ||
                MySetting.DefaultSetting.defaultStrId == 0 || string.IsNullOrWhiteSpace(MySetting.DefaultSetting.defaultPrinterSettings))
                toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
        }

        private void SetOrdersBtnCapton()
        {
            barButtonItemOrderVoucher.Caption = ClsOrderStatus.GetStringPlural(1);
            barButtonItemOrderExecute.Caption = ClsOrderStatus.GetStringPlural(2);
            barButtonItemOrderReceipt.Caption = ClsOrderStatus.GetStringPlural(3);
        }

        private void toastNotificationsManager1_Activated(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
            if (e.NotificationID.ToString() != "2b686632-166d-4870-84e4-1c83b3c452f1") return;

            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            using var form = new formDefaultSettings1();
            this.overlaySplashScreen.Close();
            form.ShowDialog();
        }


        UserControl Master;
        XtraTabPage tabpage;
        ComponentFlyoutDialog flyDailog = new ComponentFlyoutDialog();
        public void SetUserControl(string name)
        {
            try
            {
                switch (name)
                {
                    case "btnCalculater":
                        this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
                        System.Diagnostics.Process.Start("calc");
                        this.overlaySplashScreen.Close();
                        return;
                    case "btnUCmain":
                        Master = new ucMain(this);
                        tabpage = new XtraTabPage() { Text = (!MySetting.GetPrivateSetting.LangEng) ? "الرئيسية" : "Home", Name = name };
                        break;
                    case "btnRefreshAllData":
                        Task.Run(() => Program.InitObjects());
                        return;
                    case "barButtonItemBranches":
                        Master = new UCbranch();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemUserRIght":
                        Master = new UCuserRight(this);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        //Master = new UC_Permission();
                        //tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };

                        break;
                    case "barButtonItemAccount":
                        Master = new UC_Account();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name }; 
                        break;
                    case "barButtonItemCurrency":
                        Master = new UCcurrency();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemBox":
                        Master = new UCaccBox();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemBank":
                        Master = new UCaccBanks();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemCustomer":
                        Master = new UCcustomers();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSupplier":
                        Master = new UCsupplier();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonOpenBoxDaily":
                        //فتح يومية صندوق
                        Master = new UC_DrawerPeriod(true);
                        tabpage = new XtraTabPage() { Text = "فتح يومية صندوق", Name = name };
                        break;
                    //frm = new frmDrawerPeriod(true);
                    //frm.ShowDialog();
                    //return;
                    case "barButtonCloseBoxDaily":
                        //اغلاق يومية صندوق
                        Master = new UC_DrawerPeriod(false);
                        tabpage = new XtraTabPage() { Text = "اغلاق يومية صندوق", Name = name };
                        break;
                    //frm = new frmDrawerPeriod(false);
                    //frm.ShowDialog();
                    //return;
                    case "barButtonReviewBoxDaily":
                        //مراجعة يومية صندوق
                        frm = new FormViewDrawer();
                        frm.ShowDialog();
                        return;
                    case "barButtonItemRepresentative":
                        Master = new UCrepresentative();
                        tabpage = new XtraTabPage() { Text = "المندوبين", Name = name };
                        break;
                    case "barButtonItemAccountOpening":
                        Master = new UCaccOpening();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemAccountsBalance":
                        Master = new UCaccountsBalance();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemTaxDeclaration":
                        Master = new UCtaxDeclaration();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEmployee":
                        Master = new UCemployees();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEmployeeVocher":
                        Master = new UCemployeesVchr(EntryType.EmpVoucher);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEmpVchrTip":
                        Master = new UCempVchrExtra(EntryType.EmpVoucherTip);
                        tabpage = new XtraTabPage() { Text = "إكراميات الموظفين", Name = name };
                        break;
                    case "barButtonItemRprtAdminReport":
                        Master = new uc_Administrative_Report();
                        tabpage = new XtraTabPage() { Text = "المراقبه الاداريه", Name = name };
                        break;
                    case "barButtonItemEmpVchrOvrTm":
                        Master = new UCempVchrExtra(EntryType.EmpVoucherOvrTm);
                        tabpage = new XtraTabPage() { Text = "إضافي مرتبات الموظفين", Name = name };
                        break;
                    case "barButtonItemEmoVchrPhased":
                        Master = new UCemployeesVchr(EntryType.EmpVoucherPhasedAll);
                        tabpage = new XtraTabPage() { Text = "سندات الموظفين المرحلة", Name = name };
                        break;
                    case "barButtonItemEntry":
                        Master = new UCentry(1);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEntryVocher":
                        Master = new UCentryVocher();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEntryRecipt":
                        Master = new UCentryRecipt();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEntryTarhel":
                        Master = new UCentry(4);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemEntryAll":
                        Master = new UCentryAll();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemStore":
                        Master = new UCstore(this);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemProductQuantity":
                        Master = new UCproductQuant();
                        tabpage = new XtraTabPage() { Text = "جرد المخازن", Name = name };
                        break;
                    case "barButtonItemPrdQuanTracking":
                        Master = new UCprdQuanTracking();
                        tabpage = new XtraTabPage() { Text = "كمية حركة الأصناف", Name = name };
                        break;
                    case "bbiStoreProducts":
                        Master = new ucStoreProducts();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "bbiStoreProductsData":
                        Master = new ucProductData();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "bbiStockTrans":
                        Master = new UCstockTrans();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemPrdExpirate":
                        Master = new UCprdExpirate();
                        tabpage = new XtraTabPage() { Text = "تاريخ إنتهاء الأصناف", Name = name };
                        break;
                    case "barButtonItemPrdExpirateQuan":
                        Master = new UCprdExpirateQuan();
                        tabpage = new XtraTabPage() { Text = "الأصناف التالفه", Name = name };
                        break;
                    case "barButtonItemInvStoreManual":
                        Master = new ucInvStore(InvType.Manual);
                        tabpage = new XtraTabPage() { Text = "الجرد اليدوي", Name = name };
                        break;
                    case "barButtonItemInvStoreDirect":
                        Master = new ucInvStore(InvType.Direct);
                        tabpage = new XtraTabPage() { Text = "الجرد الفوري", Name = name };
                        break;
                    case "barButtonItemInvStoreSettlement":
                        Master = new ucInvStore(InvType.Settlement);
                        tabpage = new XtraTabPage() { Text = "التسوية المخزنيه", Name = name };
                        break;
                    case "barButtonItemPurchase":
                        Master = new UCpurchases(SupplyType.Purchase);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemPurchaseOrders":
                        Master = new ucOrders(OrderType.Purchase);
                        tabpage = new XtraTabPage() { Text = "طلبيات المشتريات", Name = name };
                        break;
                    case "barButtonItemPurchaseRtrn":
                        Master = new UCpurchases(SupplyType.PurchaseRtrn);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemPurchaseAll":
                        Master = new UCpurchases(SupplyType.PurchasePhaseAll);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemPurchaseDel":
                        Master = new UCpurchases(SupplyType.PurchaseDel);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemPurchaseRtrnDel":
                        Master = new UCpurchases(SupplyType.PurchaseRtrnDel);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSale":
                        Master = new UCsalesInstantFeedBack(SupplyType.Sales);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSaleRtrn":
                        Master = new UCsalesInstantFeedBack(SupplyType.SalesRtrn);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSaleAll":
                        Master = new UCsalesInstantFeedBack(SupplyType.SalesPhaseAll);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSaleDel":
                        Master = new UCsales(SupplyType.SalesDel);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSaleRtrnDel":
                        Master = new UCsales(SupplyType.SalesRtrnDel);
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "barButtonItemSalePriceOffer":
                        Master = new ucOrders(OrderType.PriceOffer);
                        tabpage = new XtraTabPage() { Text = ClsOrderStatus.GetStringPlural((byte)OrderType.PriceOffer), Name = name };
                        break;
                    case "barButtonItemOrderVoucher":
                        Master = new ucOrders(OrderType.Voucher);
                        tabpage = new XtraTabPage() { Text = ClsOrderStatus.GetStringPlural(1), Name = name };
                        break;
                    case "barButtonItemOrderExecute":
                        Master = new ucOrders(OrderType.Execution);
                        tabpage = new XtraTabPage() { Text = ClsOrderStatus.GetStringPlural(2), Name = name };
                        break;
                    case "barButtonItemOrderReceipt":
                        Master = new ucOrders(OrderType.Receipt);
                        tabpage = new XtraTabPage() { Text = ClsOrderStatus.GetStringPlural(3), Name = name };
                        break;
                    case "barButtonItemControlPanel":
                        Master = new UCDashboardEF();
                        tabpage = new XtraTabPage() { Text = _resource.GetString($"{name}.Caption"), Name = name };
                        break;
                    case "SetRibbonPage":
                        SetRibbonPage();
                        this.overlaySplashScreen.Close();
                        return;
                    case "barButtonItemRprtManob":   //تقرير عمولة مندوب (اجمالى الفواتير)
                        frm = new frmRepReport(); frm.ShowDialog(); return;
                    case "barButtonItemRprtManobProduct"://تقرير عمولة مندوب (اجمالى اصناف)
                        frm = new frmRepProductCommReport(); frm.Show(); return;
                    case "barButtonItemFixedAsset"://الاصول الثابتة
                        frm = new frmFixedAssets(); frm.Show(); return;
                    case "barButtonItemRprtCoupon"://تقرير قسيمة الخصم
                        frm = new frmCouponReportFatora(); frm.Show(); return;
                    case "barButtonItem12"://عروض الاصناف
                        frm = new FormProductPriceOffers(); frm.Show(); return;
                    case "barButtonItemRprtProdMove":

                        frm = new Report.FrmRptMoveProductQuantity();
                        frm.Show();
                        return;
                    case "barButReportAllSale":
                        frm = new Report.FormReportInvoiceFromTo(2);
                        frm.Show(); return;
                    //case "barButtonItemRprtPurchase"://تقرير المشتريات
                    //    frm = new ReportForm(ReportType.SalePurchase, status: 1);
                    //    frm.Show(); return;
                    case "barButtonItemRprtPurchase":
                        frm = new Report.FormReportInvoiceFromTo(1);
                        frm.Show(); return;
                    case "barButtonItemRprtSale"://تقرير المبيعات
                        frm = new ReportForm(ReportType.SalePurchase, status: 2);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleDetail"://تقرير المبيعات تفصيلي
                        frm = new ReportForm(ReportType.SaleDetail);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleGroup":
                        frm = new ReportForm(ReportType.SaleGroup);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleGroupWithout":
                        frm = new ReportForm(ReportType.SaleGroupWithoutProfit);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleUserWithout":
                        frm = new ReportForm(ReportType.SaleUserWithoutProfit);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleGroupRoll":
                        frm = new ReportForm(ReportType.SaleGroupRoll);
                        frm.Show(); return;
                    case "barButtonItemRprtSaleCashier":
                        frm = new ReportForm(ReportType.SaleCashier);
                        frm.Show(); return;
                    case "barButtonItem_SalesReportWithTax":
                        frm = new ReportForm(ReportType.SalesWithTax);
                        frm.Show(); return;
                    case "barButtonItem_PurchaseReportWithTax":
                        frm = new ReportForm(ReportType.PurchaseWithTax);
                        frm.Show(); return;
                    case "barButtonItemRprtEntryVoucher":
                        frm = new ReportForm(ReportType.EntryVoucherInv);
                        frm.Show(); return;
                    case "barButtonItemRprtEntryReceipt":
                        frm = new ReportForm(ReportType.EntryReceiptInv);
                        frm.Show(); return;
                    case "barButtonItemRprtStore":
                        frm = new ReportForm(ReportType.Store);
                        frm.Show(); return;
                    case "barButtonItemRprtStoreProducts":
                        frm = new ReportForm(ReportType.StoreProducts);
                        frm.Show(); return;
                    case "barButtonItemRprtProduct":
                        frm = new ReportForm(ReportType.Product);
                        frm.Show(); return;
                    case "barButtonItemRprtPrdQuanTracking":
                        frm = new ReportForm(ReportType.PrdQuanTrack);
                        frm.Show(); return;
                    case "barButtonItemRprtProductData":
                        frm = new ReportForm(ReportType.ProductsData);
                        frm.Show(); return;
                    case "barButtonItemRprtProductdQuanPr":
                        frm = new ReportForm(ReportType.ProductQuan);
                        frm.Show(); return;
                    case "barButtonItemRprtProductdQuanAvPr":
                        frm = new ReportForm(ReportType.ProductQuanAndAvPr);
                        frm.Show(); return;
                    case "barButtonItemRprtPrdQuanOpn":
                        frm = new ReportForm(ReportType.PrdQuanOpn);
                        frm.Show(); return;
                    case "barButtonItemRprtAccountBill":
                        frm = new ReportForm(ReportType.AccountBill);
                        frm.Show(); return;
                    case "barButtonItemRprtAccountBill1":
                        frm = new FormReportAccFromTo();
                        frm.Show(); return;
                    case "barButtonItemRprtBalanceSheet":
                        frm = new ReportForm(ReportType.BalanceSheet1);
                        frm.Show(); return;
                    case "barButtonItemRprtProfitLoss":
                        frm = new ReportForm(ReportType.BalanceSheet2);
                        frm.Show(); return;
                    case "barButtonItemRprtDailyEntry":
                        frm = new ReportForm(ReportType.DailyEntry);
                        frm.Show(); return;
                    case "barButtonItemRprtDailyEntryDetail":
                        frm = new ReportForm(ReportType.DailyEntryDetail);
                        frm.Show(); return;
                    case "barButtonItemRprtEmpSalAll":
                        frm = new ReportForm(ReportType.EmpSalary);
                        frm.Show(); return;
                    case "barButtonItemRprtEmpSal":
                        frm = new ReportForm(ReportType.EmpSalaryDetail);
                        frm.Show(); return;
                    case "barButtonItemRprtEmpOvrTm":
                        frm = new ReportForm(ReportType.EmpVchrOvrTm);
                        frm.Show(); return;
                    case "barButtonItemRprtEmpVchrTip":
                        frm = new ReportForm(ReportType.EmpVchrTip);
                        frm.Show(); return;
                    case "barButtonItemRprtTaxDeclaration":
                        frm = new ReportForm(ReportType.TaxDeclaration);
                        frm.Show(); return;
                    case "barButtonItemRprtSuppliers":
                        frm = new ReportForm(ReportType.Suppliers);
                        frm.Show(); return;
                    case "barButtonItemRprtSupplierInvoice":
                        frm = new ReportForm(ReportType.CustomerSupplierInvDetail, status: 1);
                        frm.Show(); return;
                    case "barButtonItemRprtCustomerInvoice":
                        frm = new ReportForm(ReportType.CustomerSupplierInvDetail, status: 2);
                        frm.Show(); return;
                    case "barButtonItemRprtSupplierBalance":
                        frm = new ReportForm(ReportType.CustomerSupplierBalance, status: 2);
                        frm.Show(); return;
                    case "barButtonItemRprtSuppliersBalance":
                        frm = new ReportForm(ReportType.CustomerSupplierBalanceBatch, status: 2);
                        frm.Show(); return;
                    case "barButtonItemRprtSuppliersBalanceFy":
                        frm = new ReportForm(ReportType.CustomerSupplierBalanceBatchFy, status: 2);
                        frm.Show(); return;
                    case "barButtonItemRprtCustomersBalanceFy":
                        frm = new ReportForm(ReportType.CustomerSupplierBalanceBatchFy, status: 1);
                        frm.Show(); return;
                    case "barButtonItemRprtCustomerBalance":
                        frm = new ReportForm(ReportType.CustomerSupplierBalance, status: 1);
                        frm.Show(); return;
                    case "barButtonItemRprtCustomersBalance":
                        frm = new ReportForm(ReportType.CustomerSupplierBalanceBatch, status: 1);
                        frm.Show(); return;
                    case "barButtonItemRprtCustomerDailyEntry":
                        frm = new ReportForm(ReportType.CustomerDailyEntryDetail);
                        frm.Show(); return;
                    case "barButtonItemRprtOrders":
                        frm = new ReportForm(ReportType.Orders);
                        frm.Show(); return;
                    case "barButtonItemRprtTrailBalance":
                        frm= new frm_TrialBalance();
                        frm.Show(); return;
                    case "barButtonItemRprtGeneralLedger":
                        frm = new ReportForm(ReportType.GeneralLedger);
                        frm.Show(); return;
                    default:
                        Master = null;
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
                var rib = (Master.Controls.Cast<object>()).FirstOrDefault(x => x is RibbonControl ribbon) as RibbonControl;
                if (rib == null) return;
                rib.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
                rib.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;
            }
            catch (Exception ex)
            {
                return;
                //XtraMessageBox.Show(ex.Message);
            }
        }

        Form frm;
        private void RibbonControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            flyDailog.WaitForm(this, 1);
            SetUserControl(e.Item.Name);
            if (frm != null)
                flyDailog.WaitForm(this, 0, frm);
            else flyDailog.WaitForm(this, 0);
        }


        private void SetRibbonPage()
        {
            ribbonPageView.Visible = false;
            //ribbonPageMain.Visible = true;
            //  ribbonControl.SelectedPage = ribbonPageMain;
        }

        private void ShowFormDialog(dynamic form)
        {
            using (form) { form.ShowDialog(); }
        }

        private void barButtonItemFinancialYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            formFinancialYear form = new formFinancialYear();
            this.overlaySplashScreen.Close();
            this.overlaySplashScreen.QueueFocus(form);
            ShowFormDialog(form);
        }

        private void barButtonItemDefaultSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            formDefaultSettings1 form = new formDefaultSettings1();
            this.overlaySplashScreen.Close();
            ShowFormDialog(form);
        }

        private void ribbonControl_Merge(object sender, RibbonMergeEventArgs e)
        {
            RibbonControl parentRibbon = sender as RibbonControl;
            RibbonControl childRibbon = e.MergedChild;
            parentRibbon?.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClsForceApplicationExit.ForceExit) return;
            FlyoutCommand flyoutCommandYes = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "نعم" : "Yes",
                Result = DialogResult.Yes,
            };
            FlyoutCommand flyoutCommandNo = new FlyoutCommand()
            {
                Text = (!MySetting.GetPrivateSetting.LangEng) ? "لا" : "No",
                Result = DialogResult.No,
            };
            FlyoutAction flyoutAction = new FlyoutAction()
            {
                Caption = (!MySetting.GetPrivateSetting.LangEng) ? "إغلاق النظام" : "Close Application",
                Description = _resource.GetString("ApplicationCloseMssg")
            };
            flyoutAction.Commands.Add(flyoutCommandNo);
            flyoutAction.Commands.Add(flyoutCommandYes);

            if (new FlyoutDialog(this, flyoutAction).ShowDialog() != DialogResult.Yes) e.Cancel = true;
        }
        private void InitSkin()
        {
            string skinName = MySetting.GetPrivateSetting.ApplicationSkinName;

            if (skinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(skinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteBezier);
            else if (skinName == "Office 2019 Colorful")
                UserLookAndFeel.Default.SetSkinStyle(skinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteOffice);
            else
                UserLookAndFeel.Default.SetSkinStyle(skinName);
        }

        private void skinPaletteRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                MySetting.GetPrivateSetting.ApplicationSkinPaletteBezier = e.Item.Caption;
            else
                MySetting.GetPrivateSetting.ApplicationSkinPaletteOffice = e.Item.Caption;
            MySetting.WriterSettingXml();
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            if (UserLookAndFeel.Default.ActiveSkinName == "The Bezier")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteBezier);
            else if (UserLookAndFeel.Default.ActiveSkinName == "Office 2019 Colorful")
                UserLookAndFeel.Default.SetSkinStyle(UserLookAndFeel.Default.ActiveSkinName, MySetting.GetPrivateSetting.ApplicationSkinPaletteOffice);

            SaveSkinName();
        }

        private void SaveSkinName()
        {
            MySetting.GetPrivateSetting.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            MySetting.WriterSettingXml();
        }

        private void InitMenuCaption()
        {
            ribbonControl.ShowItemCaptionsInQAT = MySetting.GetPrivateSetting.hideMenuCaption;
            bbiHideMenuCaption.Checked = !MySetting.GetPrivateSetting.hideMenuCaption;
        }

        private void bbiHideMenuCaption_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ribbonControl.ShowItemCaptionsInQAT = !bbiHideMenuCaption.Checked;
            MySetting.GetPrivateSetting.hideMenuCaption = !bbiHideMenuCaption.Checked;
            MySetting.WriterSettingXml();
        }

        private void BbiCompactMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            SetCompactMode();
            MySetting.GetPrivateSetting.compactMode = bbiCompactMode.Checked;
            MySetting.WriterSettingXml();
            this.overlaySplashScreen.Close();
        }



        private void SetCompactMode()
        {
            WindowsFormsSettings.CompactUIMode = (bbiCompactMode.Checked) ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void bbiTouchUI_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            MySetting.GetPrivateSetting.touchUI = bbiTouchUI.Checked;
            MySetting.WriterSettingXml();
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

            MySetting.GetPrivateSetting.touchScaleFactor = (float)Convert.ToDouble(editor.EditValue);
            MySetting.WriterSettingXml();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void repoItemSpinEditTouchScaleFactor_MouseUp(object sender, MouseEventArgs e)
        {
            (bbiTouchScaleFactor.Links[0] as BarEditItemLink).PostEditor();
            float scaleFactor = (float)Convert.ToDouble(bbiTouchScaleFactor.EditValue);

            if (scaleFactor == MySetting.GetPrivateSetting.touchScaleFactor) return;
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);

            MySetting.GetPrivateSetting.touchScaleFactor = scaleFactor;
            MySetting.WriterSettingXml();
            SetTouchScaleFactor();

            this.overlaySplashScreen.Close();
        }

        private void SetTouchUI()
        {
            WindowsFormsSettings.TouchUIMode = (MySetting.GetPrivateSetting.touchUI) ? TouchUIMode.True : TouchUIMode.False;
            SetTouchScaleFactor();
        }

        private void SetTouchScaleFactor()
        {
            WindowsFormsSettings.TouchScaleFactor = MySetting.GetPrivateSetting.touchScaleFactor;
        }

        private void RibbonControl_ShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.ShowCustomizationMenu = false;
        }

        private void InitNotificationsCount()
        {
            try
            {
                badgeNotifications.Properties.Text = $"{this.clsTbNotification.GetNotCountUnCompleteByDate:n0}";
            }
            catch (Exception)
            {
                return;
            }
        }

        private void InitNotificationsPanel()
        {
            try
            {
                flyoutPanelControlNotifications.Controls.Add(new UCnotificationsPeekView(this.clsTbNotification));
            }
            catch (Exception)
            {
                return;
            }
           
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


        private void TrailRemainingDays()
        {
            //return;
            try
            {
                ClsEncryption clsEncrp = new ClsEncryption();
                string flagStr = clsEncrp.DecryptString(ConnSetting.GetConnSetting.accountingConnectionFlag);
                int flag = Convert.ToInt32(flagStr.Substring(flagStr.Length - 1, 1));
                barListItem2.Visibility = BarItemVisibility.Never;
                if (flag == 1) return;

                string conValStr = clsEncrp.DecryptString(ConnSetting.GetConnSetting.accountingConnectionVal);
                int conVal = Convert.ToInt32(conValStr.Substring(0, conValStr.IndexOf("-")));
                string days = (conVal) switch
                {
                    1 => "يوم واحد",
                    2 => "يومين",
                    _ when conVal <= 10 => $"{conVal} ايام",
                    _ => $"{conVal} يوم"
                };

                barListItem2.Caption = $"نسخة تجريبية: متبقي {days} حتى إنتها النسخة";
                barListItem2.Visibility = BarItemVisibility.Always;
            }
            catch (Exception)
            {


            }
        }

        private void GetResources()
        {
            //if (MySetting.GetPrivateSetting.LangEng)
            //{
            //    _ci = new CultureInfo("en");
            //    _resource = new ComponentResourceManager(typeof(Language.Form1En));
            //}
            //else
            //{
            //    _ci = new CultureInfo("ar");
            //    _resource = new ComponentResourceManager(typeof(Language.Form1Ar));
            //}
            _resource = new ComponentResourceManager(typeof(FormMain));

            if (MySetting.GetPrivateSetting.LangEng) EnglishResources();
        }

        private void EnglishResources()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (var control in ribbonControl.Items)
            {
                if (control is BarSubItem c1)
                {

                    _resource.ApplyResources(c1, c1.Name, _ci);
                    c1.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F);
                }
                else if (control is BarButtonItem c2)
                    _resource.ApplyResources(c2, c2.Name, _ci);
            }
        }

      
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = WindowsFormsSettings.DefaultFont;
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    MySetting.GetPrivateSetting.SystemFont = myFunaction.converter.ConvertToString(dialog.Font);
                    MySetting.WriterSettingXml();
                    SetFont();
                }
            }
        }
        Classe.MyFunaction myFunaction = new Classe.MyFunaction();
        public void SetFont()
        {
            Font font= myFunaction.SystemFontConverter();
            WindowsFormsSettings.DefaultFont =
                AppearanceObject.DefaultFont =
                AppearanceObject.DefaultMenuFont =
                WindowsFormsSettings.DefaultFont =
                AppearanceObject.DefaultFont = font;
            ribbonControl.Items.Where(x => x is BarItem bbi).ToList().ForEach(x => x.ItemAppearance.SetFont(font));
        }

        public void simpleButtonSales_Click(object sender, EventArgs e)
        {
              try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formSupply && formSupply.supplyType == SupplyType.Sales);
                if (f != null && f is formSupplyMain formSupply)
                    formSupply.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    frm = new formSupplyMain(null, null, SupplyType.Sales, this);
                    frm.Show(); flyDialog.WaitForm(this, 0, frm);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void simpleButtonSaleRtrn_Click(object sender, EventArgs e)
        {
            try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain SupplyVoucher && SupplyVoucher.supplyType == SupplyType.SalesRtrn);
                if (f != null && f is formSupplyMain SupplyVoucher)
                    SupplyVoucher.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    frm = new formSupplyMain(null, null, SupplyType.SalesRtrn, this);
                    frm.Show();
                    flyDialog.WaitForm(this, 0, frm);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void simpleButtonPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formSupply && formSupply.supplyType == SupplyType.Purchase);
                if (f != null && f is formSupplyMain formSupply)
                    formSupply.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    frm = new formSupplyMain(null, null, SupplyType.Purchase, this);
                    frm.ResetAppearance();
                    frm.Show();
                    flyDialog.WaitForm(this, 0, frm);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        ComponentFlyoutDialog flyDialog = new ComponentFlyoutDialog();
        public void simpleButtonPurchaseRtrn_Click(object sender, EventArgs e)
        {
            try
            {
                var f = (Application.OpenForms.Cast<object>())?.FirstOrDefault(x => x is formSupplyMain formAddSupplyRcpt && formAddSupplyRcpt.supplyType == SupplyType.PurchaseRtrn);
                if (f != null && f is formSupplyMain formAddSupplyRcpt)
                    formAddSupplyRcpt.Activate();
                else
                {
                    flyDialog.WaitForm(this, 1);
                    frm = new formSupplyMain(null, null, SupplyType.PurchaseRtrn, this);
                    frm.Show();
                    flyDialog.WaitForm(this, 0, frm);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonEntryRecipt_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            frm = new formAddEntryRecipt(null, null, null, new ClsTblEntryMain(EntryType.EntryReceipt));
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void simpleButtonEntryVocher_Click(object sender, EventArgs e)
        {
            flyDialog.WaitForm(this, 1);
            frm = new formAddEntryVocher(null, null, null, new ClsTblEntryMain(EntryType.EntryVoucher));
            frm.Show();
            flyDialog.WaitForm(this, 0, frm);
        }

        private void simpleButtonEntry_Click(object sender, EventArgs e)
        {
            new formAddEntry(null, null, null, new ClsTblEntryMain(EntryType.DailyEntry)).Show();
        }

        private void simpleButtonAccountsBalance_Click(object sender, EventArgs e)
        {
            //new ReportForm(ReportType.AccountBill).Show();
            SetUserControl("barButtonItemAccountsBalance");
        }


        private void simButRprtDailyEntry_Click(object sender, EventArgs e)
        {
            new ReportForm(ReportType.DailyEntry).Show();
        }

        private void simButRprtBalanceSheet_Click(object sender, EventArgs e)
        {
            new ReportForm(ReportType.BalanceSheet1).Show();
        }

        private void simButStore_Click(object sender, EventArgs e)
        {
            SetUserControl("barButtonItemStore");
            //openWindow(navigationPageStore, "barButtonItemStore", 4);
        }


        private void simButRprtStoreProducts_Click(object sender, EventArgs e)
        {
            barButtonItem11.PerformClick();
        }

        private void simButRprtProduct_Click(object sender, EventArgs e)
        {
            new ReportForm(ReportType.Product).Show();
        }

        private void Root_Hidden(object sender, EventArgs e)
        {
            if (ribbonControl.IsHandleCreated)
            {
                MySetting.GetPrivateSetting.ShowBarSideMenu = false;
                MySetting.WriterSettingXml();
            }
        }

        private void Root_Shown(object sender, EventArgs e)
        {
            if (ribbonControl.IsHandleCreated)
            {
                MySetting.GetPrivateSetting.ShowBarSideMenu = true;
                MySetting.WriterSettingXml();
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new ReportForm(new Reports.InventoryBalanceingsReport()).ShowDialog();
        }

        private void barButtonItemDefaultAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.overlaySplashScreen = SplashScreenManager.ShowOverlayForm(this);
            formDefaultAccount form = new formDefaultAccount();
            this.overlaySplashScreen.Close();
            form.Show();
        }


    }
}