using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class ReportFixedAssets : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportFixedAssets()
        {
            InitializeComponent();
            new ClsReportHeaderData(this);
        }

    }
}
