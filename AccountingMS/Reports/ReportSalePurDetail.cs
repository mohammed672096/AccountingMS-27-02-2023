using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using AccountingMS.Classes;
using System.Linq;
using static AccountingMS.Report.FormReportInvoiceFromTo;
using System.Collections.Generic;

namespace AccountingMS.Report
{
    public partial class ReportSalePurDetail : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        byte status = 1;
        List<totals> total;
        public ReportSalePurDetail(DateTime fromDate, DateTime toDate, byte type,List<totals> _total)
        {
            InitializeComponent();
            status = type;
            total = _total;
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitText(status);
            //xrTableCellCurrency.Text = clsCurrency.CurrName(this.currencyId);
          
            InitDefaultData(fromDate, toDate);
        }
        private void InitDefaultData(DateTime fromDate, DateTime toDate)
        {
            string LableP = MySetting.GetPrivateSetting.LangEng ? "Purchase Invoices Report" : "تقرير فواتير المشتريات";
            string LableS = MySetting.GetPrivateSetting.LangEng ? "Sales Invoice Report" : "تقرير فواتير المبيعات";
            this.xrSubRprt.ReportSource = new ReportHeaderWidth(status == 1 ? LableP : LableS);
            xrSubreport1.ReportSource = this.xrSubRprt.ReportSource;
            xrTableCell22.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"من تاريخ :{fromDate:yyyy/MM/dd hh:mm tt}       الى تاريخ :{toDate:yyyy/MM/dd hh:mm tt}" : $"From Date :{fromDate:yyyy/MM/dd hh:mm tt} To Date :{toDate:hh:mm tt dd/MM/yyyy}");
        }
        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            InitTotalValues(total.FirstOrDefault(x=>x.supAccNo== Convert.ToInt64(GetCurrentColumnValue("supAccNo"))));
        }
        private void InitTotalValues(totals total1)
        {
            if (total1 == null) return;
            xrtcTotalPrdPrice.Text = $"{total1.totalPrdPrice:n2}";
            xrtcTotalSalePrice.Text = $"{total1.totalPrdSalePrice:n2}";
            xrtcTotalDiscount.Text = $"{total1.totalDscntAmount:n2}";
            xrtcTotalTaxPrice.Text = $"{total1.totalTaxPrice:n2}";
            xrtcTotalFinal.Text = $"{total1.totalFinal:n2}";
            xrtcTotalPaidCash.Text = $"{total1.totalPaidCash:n2}";
            xrtcTotalPaidCredit.Text = $"{total1.totalPaidCredit:n2}";
            xrtcTotalPaidBank.Text = $"{total1.totalPaidBank:n2}";
            xrtcTotalPrice.Text = $"{total1.totalPrice:n2}";
            xrtcTotalProfit.Text = $"{total1.totalProfit:n2}";
        }
        private void xrtcSupStatus_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsSupplyStatus.GetString(Convert.ToByte(GetCurrentColumnValue("supStatus")), Convert.ToByte(GetCurrentColumnValue("supIsCash")));
        }
        private void InitText(byte status)
        {
            //if (status == 2)
            //    xrTableCellMain.Text = (!MySetting.GetPrivateSetting.LangEng) ? "كشف فواتير المبيعات" : "Sales Statement";
            //string Userpurchases = MySetting.GetPrivateSetting.LangEng ? "User purchases" : "مشتريات المستخدم";
            //string UserSales = MySetting.GetPrivateSetting.LangEng ? "UserSales" : "مبيعات المستخدم";

            //xrtcUserSalePurchase.Text = status == 1 ? Userpurchases : UserSales;
            //xrtcUserSalePurchase.WidthF = status == 1 ? 180F : 170F;

           xrtcDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
        }

        private void xrtcUserId_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbUser.GetUserNameById(Convert.ToInt16(cell.Value));
        }



        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }

      
    }
}


