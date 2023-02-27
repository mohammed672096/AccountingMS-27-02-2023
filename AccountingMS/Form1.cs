using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars;
using System.Globalization;
using DevExpress.XtraBars.Ribbon;

namespace accounting_1._0
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        CultureInfo _ci;
        ComponentResourceManager _resource;
        private NavigationPage navPageAccount;
        private NavigationPage navPageEmployee;
        private NavigationPage navPageEntry;
        private NavigationPage navPageStore;
        private NavigationPage navPagePurchase;
        private NavigationPage navPageSale;
        private string navCaptionAccount;
        private string navCaptionEmployee;
        private string navCaptionEntry;
        private string navCaptionStore;
        private string navCaptionPurchase;
        private string navCaptionSale;

        public Form1()
        {
            InitializeComponent();
            TrailRemainingDays();
            Console.WriteLine($"ClsFinancialYear.fyId : {ClsFinancialYear.FyId}, ClsFinancialYear.fyDateStart : {ClsFinancialYear.FyDtStart}, ClsFinancialYear.fyDateEnd : {ClsFinancialYear.FyDtEnd} ");

            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Bezier, DevExpress.LookAndFeel.SkinSvgPalette.Bezier.Default);
            new UserRight.ClsUserRoleValidation(this);
            navigationFrame.TransitionAnimationProperties.FrameInterval = 7000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetResources();
            accountsNavigationPage.Controls.Add(new UCaccounts(ribbonControl) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageCurrency.Controls.Add(new UCcurrency() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageBox.Controls.Add(new UCaccBox() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageBanks.Controls.Add(new UCaccBanks() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageAccOpening.Controls.Add(new UCaccOpening() { Dock = System.Windows.Forms.DockStyle.Fill });
            controlPanelNavigationPage.Controls.Add(new UCdashboardViewer(this) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEntry.Controls.Add(new UCentry(1) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEntryVocher.Controls.Add(new UCentryVocher() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEntryRecipt.Controls.Add(new UCentryRecipt() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageCustomers.Controls.Add(new UCcustomers() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEntryAll.Controls.Add(new UCentryAll() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageAccountsBalance.Controls.Add(new UCaccountsBalance() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageStore.Controls.Add(new UCstore() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageProductQuant.Controls.Add(new UCproductQuant() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageStoreProducts.Controls.Add(new ucStoreProducts() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageSupplyRcpt1.Controls.Add(new UCsupplyRcpt() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageSupplyVocher.Controls.Add(new UCsupplyVocher() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPagePurchases.Controls.Add(new UCpurchases(3) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageSales.Controls.Add(new UCsales(4) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageSupplier.Controls.Add(new UCsupplier() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPagePurchaseAll.Controls.Add(new UCpurchases(7) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageRetrivedPurchase.Controls.Add(new UCpurchases(9) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageSalesAll.Controls.Add(new UCsales(8) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageRetrivedSales.Controls.Add(new UCsales(11) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEntryTarhel.Controls.Add(new UCentry(4) { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEmployees.Controls.Add(new UCemployees() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageEmployeesVchr.Controls.Add(new UCemployeesVchr() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageTaxDeclaration.Controls.Add(new UCtaxDeclaration() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageUserRight.Controls.Add(new UCuserRight() { Dock = System.Windows.Forms.DockStyle.Fill });
            navigationPageBranches.Controls.Add(new UCbranch() { Dock = System.Windows.Forms.DockStyle.Fill });
            //navigationFrame.SelectedPage = controlPanelNavigationPage;
        }

        private void TrailRemainingDays()
        {
            if (Properties.Settings.Default.accountingConnectionFlag != 1)
            {
                int val = 8 - Properties.Settings.Default.accountingConnectionVal;
                if (val == 1)
                    barListItem2.Caption = "نسخة تجريبية: متبقي يوم واحد حتى إنتها النسخة";
                else
                    barListItem2.Caption = "نسخة تجريبية: " + val.ToString() + " ايام حتى إنتها النسخة";
            }
            else
                barListItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            if (e.Group == navBarGroupAccounts)
            {
                if (navPageAccount == null)
                {
                    navigationFrame.SelectedPage = accountsNavigationPage;
                    barListItem1.Caption = "الدليل المحاسبي";
                }
                else
                {
                    navigationFrame.SelectedPage = navPageAccount;
                    barListItem1.Caption = navCaptionAccount;
                }
            }
            else if (e.Group == navBarGroupTaxDeclaration)
            {
                navigationFrame.SelectedPage = navigationPageTaxDeclaration;
                barListItem1.Caption = "الإقرار الضريبي";
            }
            else if (e.Group == navBarGroupEmployees)
            {
                if (navPageEmployee == null)
                {
                    navigationFrame.SelectedPage = navigationPageEmployees;
                    barListItem1.Caption = "الموظفين";
                }
                else
                {
                    navigationFrame.SelectedPage = navPageEmployee;
                    barListItem1.Caption = navCaptionEmployee;
                }
            }
            else if (e.Group == navBarGroupStore)
            {
                if (navPageStore == null)
                {
                    navigationFrame.SelectedPage = navigationPageStore;
                    barListItem1.Caption = "الموظفين";
                }
                else
                {
                    navigationFrame.SelectedPage = navPageStore;
                    barListItem1.Caption = navCaptionStore;
                }
            }
            else if (e.Group == navBarGroupEntry)
            {
                if (navPageEmployee == null)
                {
                    navigationFrame.SelectedPage = navigationPageEntry;
                    barListItem1.Caption = "القيود اليومية";
                }
                else
                {
                    navigationFrame.SelectedPage = navPageEntry;
                    barListItem1.Caption = navCaptionEntry;
                }
            }
            else if (e.Group == navBarGroupPurchases)
            {
                if (navPagePurchase == null)
                {
                    navigationFrame.SelectedPage = navigationPagePurchases;
                    barListItem1.Caption = "المشتريات";
                }
                else
                {
                    navigationFrame.SelectedPage = navPagePurchase;
                    barListItem1.Caption = navCaptionPurchase;
                }
            }
            else if (e.Group == navBarGroupSales)
            {
                if (navPageSale == null)
                {
                    navigationFrame.SelectedPage = navigationPageSales;
                    barListItem1.Caption = "المبيعات";
                }
                else
                {
                    navigationFrame.SelectedPage = navPageSale;
                    barListItem1.Caption = navCaptionSale;
                }
            }
            else if (e.Group == navBarGroupControlPanel)
            {
                navigationFrame.SelectedPage = controlPanelNavigationPage;
                barListItem1.Caption = "لوحة التحكم";
            }
        }

        private void navigationFrame_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            //splashScreenManager1.CloseWaitForm();
        }

        private void navigationFrame_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();   
        }

        private void navBarAccounts_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = accountsNavigationPage;
            navPageAccount = accountsNavigationPage;
            navCaptionAccount = "الدليل المحاسبي";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarBox_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageBox;
            navPageAccount = navigationPageBox;
            navCaptionAccount = "الصناديق";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarBanks_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageBanks;
            navPageAccount = navigationPageBanks;
            navCaptionAccount = "البنوك";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarCurrency_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageCurrency;
            navPageAccount = navigationPageCurrency;
            navCaptionAccount = "العملات";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarAccOpening_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageAccOpening;
            navPageAccount = navigationPageAccOpening;
            navCaptionAccount = "الأرصدة الإفتتاحية";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarCustomers_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageCustomers;
            navPageAccount = navigationPageCustomers;
            navCaptionAccount = "العملاء";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarItemSupplier_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageSupplier;
            navPageAccount = navigationPageSupplier;
            navCaptionAccount = "الموردين";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarAccountsBalance_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageAccountsBalance;
            navPageAccount = navigationPageAccountsBalance;
            navCaptionAccount = "أرصدة الحسابات";
            barListItem1.Caption = navCaptionAccount;
        }

        private void navBarEntry_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEntry;
            navPageEntry = navigationPageEntry;
            navCaptionEntry = "القيود اليوميه";
            barListItem1.Caption = navCaptionEntry;
        }

        private void navBarEntryVocher_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEntryVocher;
            navPageEntry = navigationPageEntryVocher;
            navCaptionEntry = "سندات الصرف";
            barListItem1.Caption = navCaptionEntry;
        }

        private void navBarEntryRecipt_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEntryRecipt;
            navPageEntry = navigationPageEntryRecipt;
            navCaptionEntry = "سندات القبض";
            barListItem1.Caption = navCaptionEntry;
        }

        private void navBarEntryAll_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEntryAll;
            navPageEntry = navigationPageEntryAll;
            navCaptionEntry = "الحركة اليومية";
            barListItem1.Caption = navCaptionEntry;
        }

        private void navBarItemEntryTarhel_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEntryTarhel;
            navPageEntry = navigationPageEntryTarhel;
            navCaptionEntry = "السندات المرحلة";
            barListItem1.Caption = navCaptionEntry;
        }

        private void navBarItemStore_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageStore;
            navPageStore = navigationPageStore;
            navCaptionStore = "المخازن";
            barListItem1.Caption = navCaptionStore;
        }

        private void navBarItemProductQuant_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageProductQuant;
            navPageStore = navigationPageProductQuant;
            navCaptionStore = "كمية الأصناف";
            barListItem1.Caption = navCaptionStore;
        }

        private void navBarPurchases_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPagePurchases;
            navPagePurchase = navigationPagePurchases;
            navCaptionPurchase = "المشتريات";
            barListItem1.Caption = navCaptionPurchase;
        }

        private void navBarRetrivedPurchase_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageRetrivedPurchase;
            navPagePurchase = navigationPageRetrivedPurchase;
            navCaptionPurchase = "مردود المشتريات";
            barListItem1.Caption = navCaptionPurchase;
        }

        private void navBarPurchaseAll_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPagePurchaseAll;
            navPagePurchase = navigationPagePurchaseAll;
            navCaptionPurchase = "فواتير المشتريات المرحلة";
            barListItem1.Caption = navCaptionPurchase;
        }

        private void navBarSales_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageSales;
            navPageSale = navigationPageSales;
            navCaptionSale = "المبيعات";
            barListItem1.Caption = navCaptionSale;
        }

        private void navBarRetrivedSales_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageRetrivedSales;
            navPageSale = navigationPageRetrivedSales;
            navCaptionSale = "مردود المبيعات";
            barListItem1.Caption = navCaptionSale;
        }

        private void navBarSalesAll_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageSalesAll;
            navPageSale = navigationPageSalesAll;
            navCaptionSale = "فواتير المبيعات المرحلة";
            barListItem1.Caption = navCaptionSale;
        }

        private void navBarItemEmployees_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEmployees;
            navPageEmployee = navigationPageEmployees;
            navCaptionEmployee = "الموظفين";
            barListItem1.Caption = navCaptionEmployee;
        }

        private void navBarItemُEmployeesVchr_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageEmployeesVchr;
            navPageEmployee = navigationPageEmployeesVchr;
            navCaptionEmployee = "صرف مرتبات الموظفين";
            barListItem1.Caption = navCaptionEmployee;
        }

        private void navBarItemSupplyRcpt_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageSupplyRcpt1;
            //barListItem1.Caption = "إدارة المشتريات";
        }

        private void navBarItemSupplySub_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame.SelectedPage = navigationPageSupplyVocher;
            //barListItem1.Caption = "إدارة المبيعات";
        }

        private void officeNavigationBar_SelectedItemChanging(object sender, DevExpress.XtraBars.Navigation.SelectedItemChangingEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
        }

        private void officeNavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            //splashScreenManager1.CloseWaitForm();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarItem barItem = e.Item;
            splashScreenManager1.ShowWaitForm();

            switch (barItem.Name)
            {
                case "barButtonItemBranches":
                    navigationFrame.SelectedPage = navigationPageBranches;
                    barListItem1.Caption = _resource.GetString("barButtonItemBranches.Caption");
                    break;
                case "barButtonItemUserRIght":
                    navigationFrame.SelectedPage = navigationPageUserRight;
                    barListItem1.Caption = _resource.GetString("barButtonItemUserRIght.Caption");
                    break;
                case "barButtonItemAccount":
                    navigationFrame.SelectedPage = accountsNavigationPage;
                    barListItem1.Caption = _resource.GetString("barButtonItemAccount.Caption");
                    break;
                case "barButtonItemCurrency":
                    navigationFrame.SelectedPage = navigationPageCurrency;
                    barListItem1.Caption = _resource.GetString("barButtonItemCurrency.Caption");
                    break;
                case "barButtonItemBox":
                    navigationFrame.SelectedPage = navigationPageBox;
                    barListItem1.Caption = _resource.GetString("barButtonItemBox.Caption");
                    break;
                case "barButtonItemBank":
                    navigationFrame.SelectedPage = navigationPageBanks;
                    barListItem1.Caption = _resource.GetString("barButtonItemBank.Caption");
                    break;
                case "barButtonItemCustomer":
                    navigationFrame.SelectedPage = navigationPageCustomers;
                    barListItem1.Caption = _resource.GetString("barButtonItemCustomer.Caption");
                    break;
                case "barButtonItemSupplier":
                    navigationFrame.SelectedPage = navigationPageSupplier;
                    barListItem1.Caption = _resource.GetString("barButtonItemSupplier.Caption");
                    break;
                case "barButtonItemAccountOpening":
                    navigationFrame.SelectedPage = navigationPageAccOpening;
                    barListItem1.Caption = _resource.GetString("barButtonItemAccountOpening.Caption");
                    break;
                case "barButtonItemAccountsBalance":
                    navigationFrame.SelectedPage = navigationPageAccountsBalance;
                    barListItem1.Caption = _resource.GetString("barButtonItemAccountsBalance.Caption");
                    break;
                case "barButtonItemTaxDeclaration":
                    navigationFrame.SelectedPage = navigationPageTaxDeclaration;
                    barListItem1.Caption = _resource.GetString("barButtonItemTaxDeclaration.Caption");
                    break;
                case "barButtonItemEmployee":
                    navigationFrame.SelectedPage = navigationPageEmployees;
                    barListItem1.Caption = _resource.GetString("barButtonItemEmployee.Caption");
                    break;
                case "barButtonItemEmployeeVocher":
                    navigationFrame.SelectedPage = navigationPageEmployeesVchr;
                    barListItem1.Caption = _resource.GetString("barButtonItemEmployeeVocher.Caption");
                    break;
                case "barButtonItemEntry":
                    navigationFrame.SelectedPage = navigationPageEntry;
                    barListItem1.Caption = _resource.GetString("barButtonItemEntry.Caption");
                    break;
                case "barButtonItemEntryVocher":
                    navigationFrame.SelectedPage = navigationPageEntryVocher;
                    barListItem1.Caption = _resource.GetString("barButtonItemEntryVocher.Caption");
                    break;
                case "barButtonItemEntryRecipt":
                    navigationFrame.SelectedPage = navigationPageEntryRecipt;
                    barListItem1.Caption = _resource.GetString("barButtonItemEntryRecipt.Caption");
                    break;
                case "barButtonItemEntryTarhel":
                    navigationFrame.SelectedPage = navigationPageEntryTarhel;
                    barListItem1.Caption = _resource.GetString("barButtonItemEntryTarhel.Caption");
                    break;
                case "barButtonItemEntryAll":
                    navigationFrame.SelectedPage = navigationPageEntryAll;
                    barListItem1.Caption = _resource.GetString("barButtonItemEntryAll.Caption");
                    break;
                case "barButtonItemStore":
                    navigationFrame.SelectedPage = navigationPageStore;
                    barListItem1.Caption = _resource.GetString("barButtonItemStore.Caption");
                    break;
                case "barButtonItemProductQuantity":
                    navigationFrame.SelectedPage = navigationPageProductQuant;
                    barListItem1.Caption = _resource.GetString("barButtonItemProductQuantity.Caption");
                    break;
                case "bbiStoreProducts":
                    navigationFrame.SelectedPage = navigationPageStoreProducts;
                    barListItem1.Caption = _resource.GetString("bbiStoreProducts.Caption");
                    break;
                case "barButtonItemPurchase":
                    navigationFrame.SelectedPage = navigationPagePurchases;
                    barListItem1.Caption = _resource.GetString("barButtonItemPurchase.Caption");
                    break;
                case "barButtonItemPurchaseRtrn":
                    navigationFrame.SelectedPage = navigationPageRetrivedPurchase;
                    barListItem1.Caption = _resource.GetString("barButtonItemPurchaseRtrn.Caption");
                    break;
                case "barButtonItemPurchaseAll":
                    navigationFrame.SelectedPage = navigationPagePurchaseAll;
                    barListItem1.Caption = _resource.GetString("barButtonItemPurchaseAll.Caption");
                    break;
                case "barButtonItemSale":
                    navigationFrame.SelectedPage = navigationPageSales;
                    barListItem1.Caption = _resource.GetString("barButtonItemSale.Caption");
                    break;
                case "barButtonItemSaleRtrn":
                    navigationFrame.SelectedPage = navigationPageRetrivedSales;
                    barListItem1.Caption = _resource.GetString("barButtonItemSaleRtrn.Caption");
                    break;
                case "barButtonItemSaleAll":
                    navigationFrame.SelectedPage = navigationPageSalesAll;
                    barListItem1.Caption = _resource.GetString("barButtonItemSaleAll.Caption");
                    break;
                case "barButtonItemControlPanel":
                    navigationFrame.SelectedPage = controlPanelNavigationPage;
                    barListItem1.Caption = _resource.GetString("barButtonItemControlPanel.Caption");
                    break;
                case "barButtonItemRprtPurchase":
                    new ReporrtForm(16, purchaseSaleStatus: 1).Show();
                    break;
                case "barButtonItemRprtSale":
                    new ReporrtForm(16, purchaseSaleStatus: 2).Show();
                    break;
                case "barButtonItemRprtStore":
                    new ReporrtForm(11).Show();
                    break;
                case "barButtonItemRprtProduct":
                    new ReporrtForm(17).Show();
                    break;
                case "barButtonItemRprtAccountBill":
                    new ReporrtForm(6).Show();
                    break;
                case "barButtonItemRprtTrailBalance":
                    //new ReporrtForm().Show();
                    break;
                case "barButtonItemRprtBalanceSheet":
                    new ReporrtForm(9).Show();
                    break;
                case "barButtonItemRprtProfitLoss":
                    new ReporrtForm(10).Show();
                    break;
                case "barButtonItemRprtDailyEntry":
                    new ReporrtForm(12).Show();
                    break;
                case "barButtonItemRprtEmpSalAll":
                    new ReporrtForm(14).Show();
                    break;
                case "barButtonItemRprtEmpSal":
                    new ReporrtForm(15).Show();
                    break;
                case "barButtonItemRprtTaxDeclaration":
                    new ReporrtForm(18).Show();
                    break;
                case "barButtonItemRprtSuppliers":
                    new ReporrtForm(7).Show();
                    break;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItemFinancialYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            using (formFinancialYear frm = new formFinancialYear())
            {
                splashScreenManager1.CloseWaitForm();
                frm.ShowDialog();
            }
        }

        private void GetResources()
        {
            if (Properties.Settings.Default.langEng)
            {
                _ci = new CultureInfo("en");
                _resource = new ComponentResourceManager(typeof(accounting_1._0.Language.Form1En));
            }
            else
            {
                _ci = new CultureInfo("ar");
                _resource = new ComponentResourceManager(typeof(accounting_1._0.Language.Form1Ar));
            }

            if (Properties.Settings.Default.langEng) EnglishResources();
        }

        private void EnglishResources()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            foreach (var control in barManager1.Items)
            {
                if (control is BarSubItem c1)
                {
                    _resource.ApplyResources(c1, c1.Name, _ci);
                    c1.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F);
                }
                else if (control is BarButtonItem c2)
                    _resource.ApplyResources(c2, c2.Name, _ci);
            }

            ribbonPageMain.Text = _resource.GetString("ribbonPageMain", _ci);
            ribbonPageView.Text = _resource.GetString("ribbonPageView", _ci);
            barListItem1.Caption = _resource.GetString("barButtonItemAccount.Caption", _ci);
        }

        private void ribbonControl_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            RibbonControl parentRibbon = sender as RibbonControl;
            RibbonControl childRibbon = e.MergedChild;
            parentRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }
    }
}