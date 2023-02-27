using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using PosFinalCost.Classe;
using System;
using System.IO;

namespace PosFinalCost
{
    public partial class ReportEndUserForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        static public string CustomType1;
        PrintPaperType printPaperType;
        public ReportEndUserForm(PrintPaperType printPaper)
        {
            InitializeComponent();
            HideReportCommands();
            printPaperType = printPaper;
            CustomType1 = ClsPath.GetPathReportCustom(printPaper);
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
        dynamic rprtSupply;
        private void ReportEndUserForm_Load(object sender, EventArgs e)
        {
            if (PrintPaperType.A4 == printPaperType)
                rprtSupply = new ReportInvoiceA4();
            else
                rprtSupply = new ReportInvoiceCasher();
            if (File.Exists(CustomType1)) rprtSupply.LoadLayout(CustomType1);
            reportDesigner1.OpenReport(rprtSupply);
        }

        private void BtnOpenDefaultRprt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PrintPaperType.A4 == printPaperType)
                reportDesigner1.OpenReport(new ReportInvoiceA4());
            else if (PrintPaperType.Cashier == printPaperType)
                reportDesigner1.OpenReport(new ReportInvoiceCasher(true));
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
                    XtraMessageBox.Show((!Program.My_Setting.LangEng) ? "تم الحفظ بنجاح!" : "Report saved successfully");
            }
            public void HandleCommand(ReportCommand command, object[] args)
            {
                if (!Directory.Exists(ClsPath.ReportSupplyCustomFolder))
                    Directory.CreateDirectory(ClsPath.ReportSupplyCustomFolder);
                panel.Report.SaveLayout(CustomType1);
                panel.ReportState = ReportState.Saved;
            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

        }
        #endregion SaveCommandHandler
    }
}