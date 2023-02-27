using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class ReportRepresentative : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportRepresentative()
        {
            InitializeComponent();

            new ClsReportHeaderData(this);
        }

    }
}
