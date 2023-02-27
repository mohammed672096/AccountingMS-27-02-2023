using AccountingMS.Reports;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.IO;

namespace AccountingMS
{
    public partial class formReportDesigner : DevExpress.XtraEditors.XtraForm
    {
        private rtp_Barcode rprt;
        private BarcodeTemplates row;
        public formReportDesigner(rtp_Barcode rprt, BarcodeTemplates row)
        {
            InitializeComponent();

            this.rprt = rprt;
            this.row = row;

            this.Load += FormReportDesigner_Load;
            reportDesigner1.DesignPanelLoaded += ReportDesigner1_DesignPanelLoaded;
        }

        private void FormReportDesigner_Load(object sender, EventArgs e)
        {
            reportDesigner1.OpenReport(this.rprt);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void ReportDesigner1_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel, this.rprt, this.row));
        }

        #region SaveCommandHandler
        private class SaveCommandHandler : ICommandHandler
        {
            XRDesignPanel panel;
            private rtp_Barcode rprt;
            private BarcodeTemplates row;

            public SaveCommandHandler(XRDesignPanel panel, rtp_Barcode rprt, BarcodeTemplates row)
            {
                this.rprt = rprt;
                this.row = row;
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
            {
                // Write your custom saving here.
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        this.rprt.SaveLayout(stream);
                        this.row.Template = stream.ToArray();
                    };
                }
                catch (Exception exception)
                {
                    ClsXtraMssgBox.ShowError(exception.Message);
                    string errorLog = $"StartThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n ExceptionInnerException => {exception.InnerException} \n ExceptionMessage => {exception.Message} " +
                        $"\n Exception.Source => {exception.Source} \n ExceptionStackTrace =>{exception.StackTrace} \n Exception.StackTrace.ToString() => {exception.StackTrace.ToString()} \n ExceptionToString =>{exception.ToString()} " +
                        $"\n ExceptionTargetSite => {exception.TargetSite} \n BaseException() => {exception.GetBaseException()} \nEndThreadExcptionEventHandler Date : {DateTime.Now:dd-MM-yyyy HH:mm:ss} \n";
                    LogHelper.GetLogger().Error(errorLog);
                }

                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;
            }
        }
        #endregion SaveCommandHandler
    }
}