using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportOrderInvoice : XtraReport
    {
        private OrderType ordType;
        public ReportOrderInvoice(tblOrderMain tbOrderMain, IEnumerable<tblOrderSub> tbOrdSubList)
        {
            this.ordType = (OrderType)tbOrderMain.ordStatus;

            InitializeComponent();
            InitData(tbOrderMain, tbOrdSubList);
            InitDefaultData(tbOrderMain.ordStatus);
            InitText(tbOrderMain.ordStatus);
            InitProperties(tbOrderMain.ordStatus);
            SeDetailBandVisibility();
        }

        private void SeDetailBandVisibility()
        {
            //if (this.ordType != OrderType.Purchase || this.ordType != OrderType.PriceOffer) return;
            if ((byte)this.ordType < (byte)OrderType.Purchase) return;

            xrlDesc.Text = "البيان:";
            DetailReport.Visible = false;
            DetailReportPurchase.Visible = true;
        }

        private void InitDefaultData(byte orderStatus)
        {
            new ClsReportHeaderData(this);
            xrlHeader.Text = $" {ClsOrderStatus.GetString(orderStatus)}";
        }

        private void InitData(tblOrderMain tbOrderMain, IEnumerable<tblOrderSub> tbOrdSubList)
        {
            tblOrderMainBindingSource.DataSource = tbOrderMain;
            tblOrderSubBindingSource.DataSource = tbOrdSubList;
        }

        private void InitText(byte ordStatus)
        {
            if (ordStatus == (byte)OrderType.Receipt) xrlReceiptSign.Text = "توقيع المستلم";

            if (ordStatus == (byte)OrderType.PriceOffer) xrlOrderNo.TextFormatString = "NO: {0}";
        }

        private void InitProperties(byte ordStatus)
        {
            if (ordStatus != (byte)OrderType.PriceOffer) return;

            xrtcPrice.ExpressionBindings.Clear();
            xrtcTotalPrice.ExpressionBindings.Clear();

            xrtcPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[ordPriceSale]"));
            xrtcTotalPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "sumSum([ordPriceSale] * [ordQuantity])"));
        }

        private void xrtcPrdId_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            tblProduct product= Session.Products.FirstOrDefault(x => x.id == Convert.ToInt32(cell.Value));
            cell.Text = (product != null ? product.prdName + " - " + product.prdNameEng:"");
        }

        private void xrtcMsurIrd_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = Session.tblPrdPriceMeasurment.FirstOrDefault(x => x.ppmId == Convert.ToInt32(cell.Value))?.ppmMsurName;
        }

        private void GroupFooter2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.ordType != OrderType.Purchase) return;

            decimal totalPrice = Convert.ToDecimal(xrtcTotalPrice.Summary.GetResult());
            decimal totalTax = Convert.ToDecimal(xrtcTotalTax.Summary.GetResult());

            xrtcTotalFinal.Text = $"{totalPrice + totalTax:n2}";
        }
    }
}
