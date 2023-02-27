using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
namespace PosFinalCost
{
    public partial class ReportHeaderWidth : XtraReport
    {
        public ReportHeaderWidth(string LabelReport)
        {
            InitializeComponent();
            BranchbindingSource.DataSource = Session.CurrentBranch;
            SetRTL();
            xrLabelReport.Text = LabelReport;
        }
        private void SetRTL()
        {
            if (!Program.My_Setting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
