using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AccountingMS.Reports
{
    public partial class XtraReportMostActiveSuppliers : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportMostActiveSuppliers()
        {
            InitializeComponent();

            new ClsReportHeaderData(this);
        }

    }
}
