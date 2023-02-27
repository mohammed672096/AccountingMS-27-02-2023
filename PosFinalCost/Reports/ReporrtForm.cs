using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosFinalCost
{
    public partial class ReportForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ReportForm(DevExpress.XtraReports.UI.XtraReport report)
        {
            InitializeComponent();
            this.Text = report.DisplayName;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}