using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class ReportCashingEmployee : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportCashingEmployee()
        {
            InitializeComponent();
            new ClsReportHeaderData(this);
        }

    }
}
