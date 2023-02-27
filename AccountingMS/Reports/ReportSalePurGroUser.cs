using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using AccountingMS.Classes;
using System.Linq;

namespace AccountingMS.Report
{
    public partial class ReportSalePurGroUser : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        byte status = 1;
        public ReportSalePurGroUser(DateTime fromDate, DateTime toDate, byte type)
        {
            InitializeComponent();
            status = type;
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
            this.xrSubRprt.ReportSource = new ReportHeader(status == 1 ? LableP : LableS);
            xrSubreport1.ReportSource = this.xrSubRprt.ReportSource;
            totalCaption2.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"من تاريخ :{fromDate:yyyy/MM/dd hh:mm tt}       الى تاريخ :{toDate:yyyy/MM/dd hh:mm tt}" : $"From Date :{fromDate:yyyy/MM/dd hh:mm tt} To Date :{toDate:hh:mm tt dd/MM/yyyy}");
        }
        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            SetStatus();
        }
        private void SetStatus()
        {
            byte status = Convert.ToByte(GetCurrentColumnValue("supStatus")), isCash = Convert.ToByte(GetCurrentColumnValue("supIsCash"));
            xrTableCellSupStatus.Text = ClsSupplyStatus.GetString(status, isCash);
            //xrTableCellCurrency.Text = clsCurrency.CurrName(this.currencyId);
        }
        private void InitText(byte status)
        {
            if (status == 2)
                xrTableCellMain.Text = (!MySetting.GetPrivateSetting.LangEng) ? "كشف فواتير المبيعات" : "Sales Statement";
            string Userpurchases = MySetting.GetPrivateSetting.LangEng ? "User purchases" : "مشتريات المستخدم";
            string UserSales = MySetting.GetPrivateSetting.LangEng ? "UserSales" : "مبيعات المستخدم";

            xrtcUserSalePurchase.Text = status == 1 ? Userpurchases : UserSales;
            xrtcUserSalePurchase.WidthF = status == 1 ? 180F : 170F;

            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
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


