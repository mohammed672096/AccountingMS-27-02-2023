using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportSupplierData : XtraReport
    {
        ClsTblCurrency clsTbCustomer = new ClsTblCurrency();

        public ReportSupplierData()
        {
            InitializeComponent();
        }

        public void InitData(tblSupplier tbSupplier)
        {
            tblSupplierBindingSource.DataSource = tbSupplier;
        }

        private void xrTableCell18_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbCustomer.GetCurrencyNameById(Convert.ToByte(cell.Value));
        }
    }
}
