using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class Reporttalselmandob : DevExpress.XtraReports.UI.XtraReport
    {
        public Reporttalselmandob()
        {
            InitializeComponent();

            new ClsReportHeaderData(this);
        }

    }
}
