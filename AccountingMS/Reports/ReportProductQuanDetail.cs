using DevExpress.XtraReports.UI;
namespace AccountingMS
{
    public partial class ReportProductQuanDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportProductQuanDetail()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }

    }
}
