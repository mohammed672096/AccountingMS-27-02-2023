using DevExpress.XtraReports.UI;
using System;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportCustomerInfo : XtraReport
    {
        ClsTblCurrency clsTblCurrency = new ClsTblCurrency();


        public ReportCustomerInfo(long supAccNo)
        {
            InitializeComponent();
            this.TopMargin.Visible = false;

            accountingEntities db = new accountingEntities();
            tblCustomerBindingSource.DataSource = db.tblCustomers.FirstOrDefault(x => x.custAccNo == supAccNo);
        }


        private void xrTableCell18_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = this.clsTblCurrency.GetCurrencyNameById(Convert.ToByte(cell.Value));
        }
    }
}
