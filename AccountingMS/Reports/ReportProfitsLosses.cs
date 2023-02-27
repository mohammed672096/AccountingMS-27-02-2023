using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class ReportProfitsLosses : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportProfitsLosses()
        {
            InitializeComponent();
            new ClsReportHeaderData(this);
        }

    }
}
