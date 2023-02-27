using AccountingMS.ReportCustomModels;
using System.Collections.Generic;

namespace AccountingMS.Reports
{
    public partial class rpt_Barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_Barcode(ICollection<BarcodeData> data)
        {
            InitializeComponent();
            this.DataSource = data;

        }

    }
}
