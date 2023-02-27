using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportOrdersDetail : XtraReport
    {
        ClsTblProduct clsTbProduct;
        ClsTblOrderSub clsTbOrderSub;

        public ReportOrdersDetail()
        {
            InitializeComponent();
            InitObjects();

            this.BeforePrint += ReportOrdersDetail_BeforePrint;
        }

        private void InitObjects()
        {
            this.clsTbProduct = new ClsTblProduct();
            this.clsTbOrderSub = new ClsTblOrderSub();
        }

        private void ReportOrdersDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tblOrderSubBindingSource.DataSource = this.clsTbOrderSub.GetOrderListByMainId(Convert.ToInt32(parameterOrderMainId.Value));
        }

        private void xrtcOrdPrdId_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(cell.Value));
        }
    }
}
