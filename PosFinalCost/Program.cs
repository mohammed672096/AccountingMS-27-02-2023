using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PosFinalCost.Classe;
using PosFinalCost.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosFinalCost
{
    static class Program
    {
        public static string ConnectionString = "";
        public static bool LogInUser = false;
        public static bool ForceExit { get; set; } = false;
        public static string pathLayoutToXml = Environment.CurrentDirectory + "\\LayoutToXml";
        public static MySetting My_Setting=new MySetting();
        public static string Version { get; } = "1.2.0";
        public static string NameProgram { get; } = "نظام نقاط البيع POS";
        public static List<string> ListPrinter=new List<string>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreenManager.ShowForm(typeof(SplashScreenBTech));
            MyFunaction myfunaction = new MyFunaction();
            MySetting.ReadWriterSettingXml(true);
            ListPrinter = MyTools.GetListPrinter;
            ConnectionString = myfunaction.ConnectionString_DB();
            try
            {
                InitBranch();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                //Application.Run(new FormConncetionPosDB());
                InitBranch();
            }
            WindowsFormsSettings.FormThickBorder = true;
            WindowsFormsSettings.EnableMdiFormSkins();
            WindowsFormsSettings.MdiFormThickBorder = true;
            WindowsFormsSettings.AllowDpiScale = true;
            WindowsFormsSettings.AnimationMode = AnimationMode.EnableAll;
            WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.True;
            SplashScreenManager.CloseForm(true);
            Application.Run(new Forms.FormLogin());
            if (LogInUser)
            {
                SplashScreenManager.ShowForm(typeof(SplashScreenBTech));
                Session.RefreshCurrSettings();
                GetData();
                Application.Run(new FormMain());
            }
        }
        public static void Localization()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(My_Setting.LangEng ? "en" : "ar");
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
        private static void InitBranch()
        {
            if (Database.Exists(ConnectionString))
            {
                Session.GetDataBranches();
                Session.GetDataUserSettingsProfile();
                Session.GetDataFinancialYears();
            }
            //else Application.Run(new FormConncetionPosDB());
        }
        public async static void GetData()
        {
            await InitObjects();
        }
        public async static Task InitObjects()
        {
            IList<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => Session.GetDataBanks()));
            taskList.Add(Task.Run(() => Session.GetDataBoxes()));
            taskList.Add(Task.Run(() => Session.GetDataBarcodes()));
            taskList.Add(Task.Run(() => Session.GetColNameForTable("UserSettingsProfile")));
            taskList.Add(Task.Run(() => Session.GetDataCurrencies()));
            taskList.Add(Task.Run(() => Session.GetDataCustomers()));
            taskList.Add(Task.Run(() => Session.GetDataBuyPrices()));
            taskList.Add(Task.Run(() => Session.GetDataProductQunatities()));
            taskList.Add(Task.Run(() => Session.GetDataGroupStrs()));
            taskList.Add(Task.Run(() => Session.GetDataUserSettingsProfile()));
            taskList.Add(Task.Run(() => Session.GetDataStores()));
            taskList.Add(Task.Run(() => Session.GetDataProducts()));
            taskList.Add(Task.Run(() => Session.GetDataProductColors()));
            taskList.Add(Task.Run(() => Session.GetDataPrdMeasurments()));
            //taskList.Add(Task.Run(() => Session.GetDataProductPrices()));
            taskList.Add(Task.Run(() => Session.GetMaxNoInv()));
            taskList.Add(Task.Run(() => Session.GetDataUserTbls()));
            taskList.Add(Task.Run(() => Session.GetDataCountries()));
            taskList.Add(Task.Run(() => Session.GetDataRoleControlTbls()));
            taskList.Add(Task.Run(() => Session.GetDataRoleTbls()));
            taskList.Add(Task.Run(() => Session.GetDataUserControlTbls()));
            taskList.Add(Task.Run(() => Session.GetDataControlDatas()));
            taskList.Add(Task.Run(() => Session.GetDataControlTbls()));
            await Task.WhenAll(taskList);
      
        }
    }
}
