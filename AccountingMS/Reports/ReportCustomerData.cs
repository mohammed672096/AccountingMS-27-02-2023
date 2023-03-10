using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportCustomerData : XtraReport
    {
        ClsTblCurrency clsTbCustomer = new ClsTblCurrency();

        public ReportCustomerData()
        {
            InitializeComponent();
        }

        public void InitData(tblCustomer tbCustomer)
        {
            tblCustomerBindingSource.DataSource = tbCustomer;
        }

        private void xrTableCell18_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = this.clsTbCustomer.GetCurrencyNameById(Convert.ToByte(cell.Value));
        }
    }
}
