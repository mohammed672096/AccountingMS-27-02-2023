using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.IO;

namespace AccountingMS
{
    public partial class ReportEndUserForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        static public ReportCustomType CustomType1;
        public ReportEndUserForm(ReportCustomType CustomType)
        {
            InitializeComponent();
            HideReportCommands();
            CustomType1 = CustomType;
            reportDesigner1.DesignPanelLoaded += ReportDesigner1_DesignPanelLoaded;
        }
        private void HideReportCommands()
        {
            reportDesigner1.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
            reportDesigner1.SetCommandVisibility(ReportCommand.ShowScriptsTab, CommandVisibility.None);
        }

        private void ReportDesigner1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }

        private void ReportEndUserForm_Load(object sender, EventArgs e)
        {
            if (CustomType1 == ReportCustomType.A4)
            {
                Console.WriteLine($"=============dirve = {ClsDrive.Path}");
                Console.WriteLine($"=============reportType = {MySetting.DefaultSetting.rprtSupplyCustomType}");
                Console.WriteLine($"====================customReport = {ClsPath.ReportSupplyCustomFile}");
                dynamic rprtSupplyCustom = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
                {
                    2 => new ReportSupplyCustom2(),
                    3 => new ReportSupplyCustom3(),
                    _ => new ReportSupplyCustom(),
                }; 
                if (File.Exists(ClsPath.ReportSupplyCustomFile)) rprtSupplyCustom.LoadLayout(ClsPath.ReportSupplyCustomFile);
                reportDesigner1.OpenReport(rprtSupplyCustom);
                //ReportSupplyCustom reportSupplyCustom;
                //reportSupplyCustom.LoadLayoutFromXml
            }
            else if (CustomType1 == ReportCustomType.Chasier)
            {
                ReportSupplyCashierCustom rprtSupplyCashierCustom = new ReportSupplyCashierCustom();
                if (File.Exists(ClsPath.ReportSupplyCashierCustomFile)) rprtSupplyCashierCustom.LoadLayout(ClsPath.ReportSupplyCashierCustomFile);
                reportDesigner1.OpenReport(rprtSupplyCashierCustom);
            }
            else if (CustomType1 == ReportCustomType.EntryReceipt)
            {
                dynamic rprtRecipt = new ReportEntryCustom();
                if (File.Exists(ClsPath.ReportEntryReciptCustomFile)) rprtRecipt.LoadLayout(ClsPath.ReportEntryReciptCustomFile);
                reportDesigner1.OpenReport(rprtRecipt);
            }
            else if (CustomType1 == ReportCustomType.Entry)
            {
                dynamic rprtRecipt = new ReportEntryCustom();
                if (File.Exists(ClsPath.ReportDailyEntryCustomFile)) rprtRecipt.LoadLayout(ClsPath.ReportDailyEntryCustomFile);
                reportDesigner1.OpenReport(rprtRecipt);
            }
            else if (CustomType1 == ReportCustomType.EntryVoucher)
            {
                dynamic rprtRecipt = new ReportEntryCustom();
                if (File.Exists(ClsPath.ReportEntryVocherCustomFile)) rprtRecipt.LoadLayout(ClsPath.ReportEntryVocherCustomFile);
                reportDesigner1.OpenReport(rprtRecipt);
            }
        }

        private void BtnOpenDefaultRprt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CustomType1 == ReportCustomType.A4)
            {
                reportDesigner1.OpenReport(MySetting.DefaultSetting.rprtSupplyCustomType switch
                {
                    2 => new ReportSupplyCustom2(),
                    3 => new ReportSupplyCustom3(),
                    _ => new ReportSupplyCustom(),
                });
            }
            else if (CustomType1 == ReportCustomType.Chasier)
                reportDesigner1.OpenReport(new ReportSupplyCashierCustom());
            else if (CustomType1 == ReportCustomType.EntryReceipt || CustomType1 == ReportCustomType.EntryVoucher || CustomType1 == ReportCustomType.Entry)
                reportDesigner1.OpenReport(new ReportEntryCustom());
        }

        #region SaveCommandHandler
        private class SaveCommandHandler : ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
                this.panel.ReportStateChanged += Panel_ReportStateChanged;
            }

            private void Panel_ReportStateChanged(object sender, ReportStateEventArgs e)
            {
                if (e.ReportState == ReportState.Saved)
                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "تم الحفظ بنجاح!" : "Report saved successfully");
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

            void Save()
            {  // Write your custom saving here.
                if (!Directory.Exists(ClsPath.ReportSupplyCustomFolder))
                    Directory.CreateDirectory(ClsPath.ReportSupplyCustomFolder);
                if (CustomType1 == ReportCustomType.A4)
                    panel.Report.SaveLayout(ClsPath.ReportSupplyCustomFile);
                else if (CustomType1 == ReportCustomType.Chasier)
                    panel.Report.SaveLayout(ClsPath.ReportSupplyCashierCustomFile);
                else if (CustomType1 == ReportCustomType.EntryReceipt)
                    panel.Report.SaveLayout(ClsPath.ReportEntryReciptCustomFile);
                else if (CustomType1 == ReportCustomType.Entry)
                    panel.Report.SaveLayout(ClsPath.ReportDailyEntryCustomFile);
                else if (CustomType1 == ReportCustomType.EntryVoucher)
                    panel.Report.SaveLayout(ClsPath.ReportEntryVocherCustomFile);
                panel.ReportState = ReportState.Saved;

            }
        }
        #endregion SaveCommandHandler
    }
}
//using DevExpress.XtraEditors;
//using DevExpress.XtraReports.UserDesigner;
//using System;
//using System.IO;

//namespace AccountingMS
//{
//    public partial class ReportEndUserForm : DevExpress.XtraBars.Ribbon.RibbonForm
//    {

//        static public string CustomType1;
//        public ReportEndUserForm(string CustomType)
//        {
//            InitializeComponent();
//            HideReportCommands();
//            CustomType1 = CustomType;
//            reportDesigner1.DesignPanelLoaded += ReportDesigner1_DesignPanelLoaded;
//        }
//        private void HideReportCommands()
//        {
//            reportDesigner1.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
//            reportDesigner1.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
//            reportDesigner1.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
//            reportDesigner1.SetCommandVisibility(ReportCommand.ShowScriptsTab, CommandVisibility.None);
//        }

//        private void ReportDesigner1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
//        {
//            XRDesignPanel panel = (XRDesignPanel)sender;
//            panel.AddCommandHandler(new SaveCommandHandler(panel));
//        }

//        private void ReportEndUserForm_Load(object sender, EventArgs e)
//        {
//            if (CustomType1 == "1")
//            {
//                Console.WriteLine($"=============dirve = {ClsDrive.Path}");
//                Console.WriteLine($"=============reportType = {MySetting.DefaultSetting.rprtSupplyCustomType}");
//                Console.WriteLine($"====================customReport = {ClsPath.ReportSupplyCustomFile}");
//                dynamic rprtSupplyCustom = (MySetting.DefaultSetting.rprtSupplyCustomType) switch
//                {
//                    2 => new ReportSupplyCustom2(),
//                    3 => new ReportSupplyCustom3(),
//                    _ => new ReportSupplyCustom(),
//                };
//                if (File.Exists(ClsPath.ReportSupplyCustomFile)) rprtSupplyCustom.LoadLayout(ClsPath.ReportSupplyCustomFile);
//                reportDesigner1.OpenReport(rprtSupplyCustom);
//            }
//            else if (CustomType1 == "2")
//            {
//                dynamic rprtSupplyCashierCustom = new ReportSupplyCashierCustom();
//                if (File.Exists(ClsPath.ReportSupplyCashierCustomFile)) rprtSupplyCashierCustom.LoadLayout(ClsPath.ReportSupplyCashierCustomFile);
//                reportDesigner1.OpenReport(rprtSupplyCashierCustom);
//            }
//            else if (CustomType1 == "3")
//            {
//                dynamic rprtRecipt = new ReportEntryCustom();
//                if (File.Exists(ClsPath.ReportEntryReciptCustomFile)) rprtRecipt.LoadLayout(ClsPath.ReportEntryReciptCustomFile);
//                reportDesigner1.OpenReport(rprtRecipt);
//            }
//        }

//        private void BtnOpenDefaultRprt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
//        {
//            if (CustomType1 == "1")
//            {
//                reportDesigner1.OpenReport(MySetting.DefaultSetting.rprtSupplyCustomType switch
//                {
//                    2 => new ReportSupplyCustom2(),
//                    3 => new ReportSupplyCustom3(),
//                    _ => new ReportSupplyCustom(),
//                });
//            }
//            else if (CustomType1 == "2")
//                reportDesigner1.OpenReport(new ReportSupplyCashierCustom());
//            else if (CustomType1 == "3")
//                reportDesigner1.OpenReport(new ReportEntryCustom());
//        }

//        #region SaveCommandHandler
//        private class SaveCommandHandler : ICommandHandler
//        {
//            XRDesignPanel panel;

//            public SaveCommandHandler(XRDesignPanel panel)
//            {
//                this.panel = panel;
//                this.panel.ReportStateChanged += Panel_ReportStateChanged;
//            }

//            private void Panel_ReportStateChanged(object sender, ReportStateEventArgs e)
//            {
//                if (e.ReportState == ReportState.Saved)
//                    XtraMessageBox.Show((!MySetting.GetPrivateSetting.LangEng) ? "تم الحفظ بنجاح!" : "Report saved successfully");
//            }

//            public void HandleCommand(ReportCommand command, object[] args)
//            {
//                // Save the report.
//                Save();
//            }

//            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
//            {
//                useNextHandler = !(command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs);
//                return !useNextHandler;
//            }

//            void Save()
//            {  // Write your custom saving here.
//                if (!Directory.Exists(ClsPath.ReportSupplyCustomFolder))
//                    Directory.CreateDirectory(ClsPath.ReportSupplyCustomFolder);
//                if (CustomType1 == "1")
//                    panel.Report.SaveLayout(ClsPath.ReportSupplyCustomFile);
//                else if (CustomType1 == "2")
//                    panel.Report.SaveLayout(ClsPath.ReportSupplyCashierCustomFile);
//                else if (CustomType1 == "3")
//                    panel.Report.SaveLayout(ClsPath.ReportEntryReciptCustomFile);
//                panel.ReportState = ReportState.Saved;

//            }
//        }
//        #endregion SaveCommandHandler
//    }
//}