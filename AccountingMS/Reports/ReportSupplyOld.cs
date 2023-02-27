using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportSupplyOld : XtraReport
    {
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;

        private string currencySign;
        private SupplyType supplyType;

        public ReportSupplyOld(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList, ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitText(tbSupplyMain.supStatus);
            InitBinding(tbSupplyMain.supStatus);
            InitObjects(clsTbProduct, clsTbPrdMsur);
            InithData(tbSupplyMain, tbSupplySubList);

            new ClsReportHeaderData(this);
            SetHeaderVisibility(tbSupplyMain.supStatus);

            this.supplyType = (SupplyType)tbSupplyMain.supStatus;
        }

        private void InitObjects(ClsTblProduct clsTbProduct, ClsTblPrdPriceMeasurment clsTbPrdMsur)
        {
            this.clsTbProduct = (clsTbProduct != null) ? clsTbProduct : new ClsTblProduct();
            this.clsTbPrdMsur = (clsTbProduct != null) ? clsTbPrdMsur : new ClsTblPrdPriceMeasurment();
        }

        private void InitText(byte supStatus)
        {
            if (supStatus == 3 || supStatus == 7)
                xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مشتريات" : "Purchase Invoice";
            else if (supStatus == 4 || supStatus == 8)
                xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مبيعات" : "Sales Invoice";
            else if (supStatus == 9 || supStatus == 10)
                xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مشتريات" : "Purchase Return Invoice";
            else if (supStatus == 11 || supStatus == 12)
                xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "فاتورة مردود مبيعات" : "Sale Return Invoice";
        }

        private void InitBinding(byte supStatus)
        {
            if (supStatus == 4 || supStatus == 8 || supStatus == 9 || supStatus == 10)
            {
                xrtcTotalRow.ExpressionBindings.Clear();
                xrtcTotalRow.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "([supSalePrice]*[supQuanMain])+supTaxPrice"));
            }
            if (supStatus == 4 || supStatus == 8 || supStatus == 11 || supStatus == 12)
            {
                xrtcPrice.ExpressionBindings.Clear();
                xrtcPrice.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[supSalePrice]"));
            }
        }

        private void InithData(tblSupplyMain tbSupplyMain, IEnumerable<tblSupplySub> tbSupplySubList)
        {
            tblSupplyMainBindingSource.DataSource = tbSupplyMain;
            tblSupplySubBindingSource.DataSource = tbSupplySubList;

            this.currencySign = new ClsTblCurrency().GetCurrencySignById(Convert.ToByte(tbSupplyMain.supCurrency));
            SetTotalAmounts(tbSupplyMain);
        }

        private void SetTotalAmounts(tblSupplyMain tbSupplyMain)
        {
            //double total = (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice));// - Convert.ToDouble(tbSupplyMain.supDscntAmount);
            double total = (tbSupplyMain.supTotal + Convert.ToDouble(tbSupplyMain.supTaxPrice)) - Convert.ToDouble(tbSupplyMain.supDscntAmount);
            xrtcAmount.Text += $"{total:n2}{this.currencySign}";

            //xrtcTotal.Text = $"{Convert.ToDouble(tbSupplyMain.supTotal) + Convert.ToDouble(tbSupplyMain.supTaxPrice) + Convert.ToDouble(tbSupplyMain.supDscntAmount):n2}";
            xrtcTotal.Text = $"{tbSupplyMain.supTotal:n2}";
            xrtcTotalTax.Text = $"{tbSupplyMain.supTaxPrice:n2}";
            xrtcTotalDiscount.Text = $"{Convert.ToDouble(tbSupplyMain.supDscntAmount):n2}";
            xrtcTotalFinal.Text = $"{total:n2}";
        }

        private void XrTable4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string prdNameEn = this.clsTbProduct.GetPrdNameEnById(Convert.ToInt32(DetailReport.GetCurrentColumnValue("supPrdId")));
            if (!string.IsNullOrWhiteSpace(prdNameEn))
            {
                xrtcPrdName.RowSpan = 1;
                xrtcPrdName.Font = new Font("Segoe UI", 8.5F);
                xrtcPrdName.TextAlignment = TextAlignment.BottomLeft;

                xrtcPrdNameEn.Text = prdNameEn;
                xrtcPrdNameEn.Font = new Font("Segoe UI", 8.5F);
                xrtcPrdNameEn.TextAlignment = TextAlignment.TopLeft;
            }
            else
            {
                xrtcPrdName.RowSpan = 2;
                xrtcPrdName.Font = new Font("Segoe UI", 10.75F);
                xrtcPrdName.TextAlignment = TextAlignment.MiddleLeft;
            }
        }

        private void xrtcSupAccName_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.supplyType == SupplyType.Sales || this.supplyType == SupplyType.SalesPhase || this.supplyType == SupplyType.SalesRtrn || this.supplyType == SupplyType.SalesPhaseRtrn)
                if (Convert.ToInt32(GetCurrentColumnValue("supCustSplId")) > 0)
                    (sender as XRTableCell).Text = new ClsTblCustomer().GetCustomerNameById(Convert.ToInt32(GetCurrentColumnValue("supCustSplId")));
                else if (Convert.ToByte(GetCurrentColumnValue("supIsCash")) == 1 && GetCurrentColumnValue("supDesc") != null)
                    (sender as XRTableCell).Text = GetCurrentColumnValue("supDesc").ToString();
        }

        private void xrLabel2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRLabel label = sender as XRLabel;

            if (Convert.ToByte(label.Value) == 1) label.Text = (!MySetting.GetPrivateSetting.LangEng) ? "طريقة الدفع : نقدا" : "Invoice Payment : Cash";
            else label.Text = (!MySetting.GetPrivateSetting.LangEng) ? "طريقة الدفع: اجل" : "Invoice Payment : Credit";
        }

        private void xrLabel6_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRLabel label = sender as XRLabel;
            label.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? "المحاسب: {0}" : "Cashier: {0}", new ClsTblUser().GetUserNameById(Convert.ToInt16(label.Value)));
        }

        private void xrTableCell21_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(cell.Value));
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //double total = (Convert.ToDouble(xrtcTotal.Summary.GetResult()) +
            //    Convert.ToDouble(xrtcTotalTax.Summary.GetResult())) - Convert.ToDouble(xrtcTotalDiscount.Summary.GetResult());
            //xrtcTotalFinal.Text = string.Format($"{total:n2}{this.currencySign}");
        }

        private void SetHeaderVisibility(byte supStatus)
        {
            if ((MySetting.DefaultSetting.showRprtPurchaseHeader && (supStatus == 3 || supStatus == 7 || supStatus == 9 || supStatus == 10)) ||
                (MySetting.DefaultSetting.showRprtSaleHeader && (supStatus == 4 || supStatus == 8 || supStatus == 11 || supStatus == 12))) return;

            foreach (var control in TopMargin.Controls)
                if (control is XRLabel xrlabel && xrlabel.Name != "xrlHeader") xrlabel.Visible = false;

            xrPictureBoxBranch.Visible = false;
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
