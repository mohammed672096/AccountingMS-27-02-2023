using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;

namespace AccountingMS.Reports
{
    public partial class ReportRepresentativeSum : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportRepresentativeSum()
        {
            InitializeComponent();
            new ClsReportHeaderData(this);

          

        }

    }
}
