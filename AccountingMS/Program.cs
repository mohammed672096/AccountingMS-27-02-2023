using AccountingMS.Classes;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace AccountingMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Cls_UserSettingDefult();
                Localization();
                BarSetting.ReadBarSettingXml();
                ConnSetting.ReadSettingXml();
                MySetting.ReadSettingXml();
                MySetting.GetDatatblSetting();
                InitBranch();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                //Application.Run(new formDBConnection());
                //return;
            }

            WindowsFormsSettings.FormThickBorder = true;
            WindowsFormsSettings.EnableMdiFormSkins();
            WindowsFormsSettings.MdiFormThickBorder = true;
            WindowsFormsSettings.AllowDpiScale = true;
            WindowsFormsSettings.AnimationMode = AnimationMode.EnableAll;
            WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.True;
            if ((DateTime.Now > (new DateTime(2020, 7, 1, 0, 0, 1))) && MySetting.GetPrivateSetting.taxDefault == 5)
            {
                MySetting.GetPrivateSetting.taxDefault = 15;
                MySetting.WriterSettingXml();
            }
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
            }
            //RunFormMain();
        }
        public static void Cls_UserSettingDefult()
        {
            try
            {
                string path_config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                if (File.Exists(path_config))
                    File.Delete(path_config);
            }
            catch (ConfigurationErrorsException ex)
            {
                try
                {
                    string filename = ((ConfigurationErrorsException)ex.InnerException).Filename;
                    File.Delete(filename);
                }
                catch
                {
                }
            }
        }
        public static void Localization()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(MySetting.GetPrivateSetting.LangEng ? "en" : "ar-EG");
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
        private static void Login()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["ApplicationFirstRun"]))
            {
                Application.Run(new formDBConnection());
                return;
            }
            try
            {
                if (MySetting.GetPrivateSetting.restartForm)
                    Application.Run(new FormMain());
                else
                    Application.Run(new FormLogin());
                if (Session.CurrentUser != null) GetData();
            }
            catch (Exception ex)
            {
                ClsXtraMssgBox.ShowError(ex.Message);
                return;
            }
        }

        private static void InitBranch()
        {
            Session.GetDataBranches();
            //Session.GetDataUserSettingsProfile();
            Session.GetDataFinancialYears();
        }
        public async static void GetData()
        {
            await InitObjects();
        }
        public async static Task InitObjects()
        {
            IList<Task> taskList = new List<Task>();
            //taskList.Add(Task.Run(() => Session.GetDataSupplySubs()));
            taskList.Add(Task.Run(() => Session.GetDataBuyPrices()));
            taskList.Add(Task.Run(() => Session.GetDataAccounts()));
            taskList.Add(Task.Run(() => Session.GetDataBanks()));
            taskList.Add(Task.Run(() => Session.GetDataBoxes()));
            taskList.Add(Task.Run(() => Session.GetDataCustomrtWhithBalances()));
            taskList.Add(Task.Run(() => Session.GetListPrinter()));
            taskList.Add(Task.Run(() => Session.GetDataCurrencies()));
            taskList.Add(Task.Run(() => Session.GetDataCustomers()));
            taskList.Add(Task.Run(() => Session.GetDataStore()));
            taskList.Add(Task.Run(() => Session.GetDataProductQunatities()));
            taskList.Add(Task.Run(() => Session.CalculatePrdQuan()));
            taskList.Add(Task.Run(() => Session.GetDataGroupStr()));
            taskList.Add(Task.Run(() => Session.GetDataPrdMeasurments()));
            taskList.Add(Task.Run(() => Session.GetDataBarcodes()));
            taskList.Add(Task.Run(() => Session.GetDataProducts()));
            taskList.Add(Task.Run(() => Session.GetDataPrdManufacture()));
            taskList.Add(Task.Run(() => Session.GetDataSuppliers()));
            taskList.Add(Task.Run(() => Session.GetDataProductPrices()));
            taskList.Add(Task.Run(() => Session.GetMaxNoInv()));
            taskList.Add(Task.Run(() => Session.GetDataUserTbls()));
            taskList.Add(Task.Run(() => Session.GetDataCountries()));
            taskList.Add(Task.Run(() => Session.GetDataRoleControlTbls()));
            taskList.Add(Task.Run(() => Session.GetDataRoleTbls()));
            taskList.Add(Task.Run(() => Session.GetDataUserControlTbls()));
            taskList.Add(Task.Run(() => Session.GetDataControlTbls()));
            await Task.WhenAll(taskList);

        }
        private static void ThreadExceptions()
        {
            Application.ThreadException += Application_ThreadException;
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledExceptionEventHandler);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            new ExceptionLogger(e.Exception, "Application_ThreadException");
            //new ExceptionLogger(e.Exception);
            //ClsForceApplicationExit.ForceExit = true;
            //Application.Exit();
        }

        private static void AppDomain_UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            new ExceptionLogger(((Exception)e.ExceptionObject), "AppDomain_UnhandledExceptionEventHandler");
        }

//        public static void CheckForDBUpdate()
//        {

//            var db = new accountingEntities();
//            try
//            {
//                if (db.Database.Exists() == false)
//                    return;
//            }
//            catch (Exception)
//            {

//                return;
//            }

//            try
//            {
//                string _cmd = @" BEGIN
//DECLARE @TYPENAME varchar(50);

//    SELECT @TYPENAME=TYPE_NAME(system_type_id) FROM sys.columns 
//	WHERE name = 'ppmConversion' AND [object_id] = OBJECT_ID('[dbo].[tblPrdPriceMeasurment]')
//IF @TYPENAME ='decimal'
// THROW 60000, '', 0;  

//END";
//                int result = db.Database.ExecuteSqlCommand(_cmd, new object[0]);
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\ppmConversion.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            catch (Exception)
//            {

//            }


//            try
//            {
//                string _cmd = @" BEGIN
//DECLARE @TYPENAME varchar(50);

//    SELECT @TYPENAME=TYPE_NAME(system_type_id) FROM sys.columns 
//	WHERE name = 'asDate' AND [object_id] = OBJECT_ID('[dbo].[tblAsset]')
//IF @TYPENAME='datetime'
// THROW 60000, '', 0;  

//END";
//                int result = db.Database.ExecuteSqlCommand(_cmd, new object[0]);
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblAsset.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            catch (Exception)
//            {

//            }
//            try
//            {

//                var x = db.tblEmployees.Select(x => x.expirationInsurance).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblEmployee.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.InventoryBalanceings.Select(x => x.ID).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\InventoryBalanceing.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.InventoryBalancingDetails.Select(x => x.ID).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\InventoryBalancingDetails.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.InventoryBalanceings.Select(x => x.TotalShortageValueSale).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\InventoryBalanceingSQLQuery.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblProducts.Select(x => x.ReorderLevel).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblProduct Add Reorder Level Column.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }

//            try
//            {
//                var x = db.tblProducts.Select(x => x.MaxLevel).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\ProductMaxLevel.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblSupplyMains.Select(x => x.CarType).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\CarSupply.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblEntrySubs.Select(x => x.invoNum).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblEntrySub.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblInvStoreMains.Select(x => x.invNo).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblInvStoreMain_Create.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblInvStoreSubs.Select(x => x.invMainId).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblInvStoreSub_Create.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblInvStoreSubs.Select(x => x.invPriceTotal).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblInvStoreSub_addedPriceTotal.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblEntrySubs.Select(x => x.entInvoDate).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblEntrySub_addedEntInvoDate.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblInvStoreSubs.Select(x => x.invBarcode).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblInvStoreSub_addedBarcode.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblDscntPermissions.Select(x => x.id).FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblDscntPermission_Create.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblOrderSubs.Select(x => x.ordPrice).FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblOrderSub_addedOrdPrices.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblNotifications.Select(x => x.id).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblNotification_Create.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblNotifications.Select(x => x.notEntId).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblNotification_addedEntIdAmountPaidNdIsPaid.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblNotifications.Select(x => x.notIsComplete).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblNotification_updateRmvNotIsPaidNdRenaimNotStatusToIsCompleteNdTypeToStatus.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                string script = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}\\DBUpdate\\ppmConversionWithCondition.sql");
//                db.Database.ExecuteSqlCommand(script, new object[0]);
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//            try
//            {
//                var x = db.tblProductQtyOpns.Select(x => x.qtyStrId).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblProductQtyOpn_addedStrId.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblPrdExpirateQuans.Select(x => x.expStrid).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblPrdExpirateQuan_addedStrId.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                var x = db.tblOrderSubs.Select(x => x.ordPriceSale).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\DBUpdate\\tblOrderSub_addedOrdPriceSale.sql");
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }
//            try
//            {
//                string script = System.IO.File.ReadAllText($"{Environment.CurrentDirectory}\\DBUpdate\\tblOrderSub_updateQuanFromIntToFloat.sql");
//                db.Database.ExecuteSqlCommand(script, new object[0]);
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message);
//            }
//            try
//            {
//                var x = db.InventoryBalanceings.Select(x => x.ID).FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                string cmd = @"
//USE [accounting]

//CREATE TABLE [dbo].[InventoryBalanceing](
//	[ID] [int] IDENTITY(1,1) NOT NULL,
//[Name] [nvarchar](150) NULL,
//	[Date] [datetime] NOT NULL,
//	[BranchID] [int] NOT NULL,
//	[EmployeeName] [nvarchar](250) NOT NULL,
//	[TotalShortageQty] [float] NOT NULL,
//	[TotalSurplusQty] [float] NOT NULL,
//	[TotalShortageValue] [float] NOT NULL,
//	[TotalSurplusValue] [float] NOT NULL,
//	[NetProfitOrLoses] [float] NOT NULL,
//	[Notes] [nvarchar](max)  NULL,
//	[IsPosted] [bit] NOT NULL,
// CONSTRAINT [PK_InventoryBalanceing] PRIMARY KEY CLUSTERED 
//(
//	[ID] ASC
//)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

//CREATE TABLE [dbo].[InventoryBalancingDetails](
//	[ID] [int] IDENTITY(1,1) NOT NULL,
//    [MainID] [int] NOT NULL,
//	[ProductID] [int] NOT NULL,
//	[UnitID] [int] NOT NULL,
//	[Qty] [float] NOT NULL,
//	[RealQty] [float] NOT NULL,
//	[Shotage] [float] NOT NULL,
//	[Surplus] [float] NOT NULL,
//	[Price] [float] NOT NULL,
//	[TotalCost] [float] NOT NULL,
// CONSTRAINT [PK_InventoryBalancingDetails] PRIMARY KEY CLUSTERED 
//(
//	[ID] ASC
//)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
//) ON [PRIMARY]



//";
//                db.Database.ExecuteSqlCommand(cmd, new object[0]);
//            }






//            try
//            {
//                //      accNo   accName accCat  accParent accLevel    accType accCurrency accBrnId accStatus
//                //    323101  مشتريات المخزون السلعي  3   3231    5   1   1   1   0
//                //    323201  مردود مشتريات المخزون السلعي    3   3232    5   1   1   1   0
//                var AccountBuy = db.tblAccounts.FirstOrDefault(x => x.accNo == 323101 && x.accBrnId == Session.CurBranch.brnId);
//                if (AccountBuy == null)
//                {
//                    db.tblAccounts.Add(new tblAccount()
//                    {
//                        accParent = 3231,
//                        accNo = 323101,
//                        accName = "مشتريات المخزون السلعي",
//                        accCurrency = 1,
//                        accCat = 3,
//                        accLevel = 5,
//                        accType = 1,
//                        accBrnId = Session.CurBranch.brnId,
//                        accStatus = 0
//                    });
//                }
//                var AccountRetarnBuy = db.tblAccounts.FirstOrDefault(x => x.accNo == 323201 && x.accBrnId == Session.CurBranch.brnId);
//                if (AccountRetarnBuy == null)
//                {
//                    db.tblAccounts.Add(new tblAccount()
//                    {
//                        accParent = 3232,
//                        accNo = 323201,
//                        accName = "مردود مشتريات المخزون السلعي",
//                        accCurrency = 1,
//                        accCat = 3,
//                        accLevel = 5,
//                        accType = 1,
//                        accBrnId = Session.CurBranch.brnId,
//                        accStatus = 0
//                    });
//                }
//                db.SaveChanges();
//            }
//            catch (Exception)
//            {
//            }
//            try
//            {
//                var barButtonItem4 = db.tblControls.FirstOrDefault(x => x.cntucNo == 17 && x.cntName == "barButtonItem4");
//                var barButtonItem6 = db.tblControls.FirstOrDefault(x => x.cntucNo == 17 && x.cntName == "barButtonItem6");
//                if (barButtonItem4 == null) db.tblControls.Add(new tblControl
//                {
//                    cntucNo = 17,
//                    cntName = "barButtonItem4",
//                    cntCaptionEn = "View barcode samples",
//                    cntCaption = "عرض نماذج الباركود",
//                });
//                if (barButtonItem6 == null) db.tblControls.Add(new tblControl
//                {
//                    cntucNo = 17,
//                    cntName = "barButtonItem6",
//                    cntCaptionEn = "Print barcode items",
//                    cntCaption = "طباعه باركود الاصناف",
//                });
//                db.SaveChanges();
//            }
//            catch (Exception)
//            {
//            }
//        }
    }
}