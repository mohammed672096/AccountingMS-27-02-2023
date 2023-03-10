using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using AccountingMS.Classes;
using System.Linq;

namespace AccountingMS.Report
{
    public partial class ReportSalePurBranch : DevExpress.XtraReports.UI.XtraReport
    {
        byte status = 1;
        public ReportSalePurBranch(DateTime fromDate, DateTime toDate, byte type)
        {
            InitializeComponent();
            status = type;
            xrTableSale2.Visible= xrTableSaleH.Visible= xrTableSaleLast.Visible= xrTableSale1.Visible  = (status == 2);
            xrTablePur2.Visible= xrTablePurH.Visible= xrTablePurLast.Visible = xrTablePur1.Visible = (status == 1);
         
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitText(status);
            InitDefaultData(fromDate, toDate);
        }
        private void InitDefaultData(DateTime fromDate, DateTime toDate)
        {
            string LableP = MySetting.GetPrivateSetting.LangEng ? "Branch purchases report" : "تقرير مشتريات الفروع";
            string LableS = MySetting.GetPrivateSetting.LangEng ? "Branch sales report" : "تقرير مبيعات الفروع";
            this.xrSubRprt.ReportSource = new ReportHeader(status == 1 ? LableP : LableS);
            xrSubreport1.ReportSource = this.xrSubRprt.ReportSource;
            totalCaption2.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"من تاريخ :{fromDate:yyyy/MM/dd hh:mm tt}       الى تاريخ :{toDate:yyyy/MM/dd hh:mm tt}" : $"From Date :{fromDate:yyyy/MM/dd hh:mm tt} To Date :{toDate:hh:mm tt dd/MM/yyyy}");
        }
      
        private void InitText(byte status)
        {
            if (status == 1)
            {
                xrTableCellMain.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCellMain.Text.Replace("Sale", "Purchase") : xrTableCellMain.Text.Replace("مبيعات", "مشتريات");
                xrTableCell18.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCell18.Text.Replace("Sale", "Purchase") : xrTableCell18.Text.Replace("مبيعات", "مشتريات");
                xrLabel1.Text = MySetting.GetPrivateSetting.LangEng ? xrLabel1.Text.Replace("Sale", "Purchase") : xrLabel1.Text.Replace("مبيعات", "مشتريات");
            }
            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
        }
        private short BranchId;
        private void xrtcBranchId_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            this.BranchId = Convert.ToInt16(cell.Value);
            cell.Text = BranchName;
        }
        string BranchName=> Session.Branches?.FirstOrDefault(x => x.brnId == this.BranchId)?.brnName;
        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
        private void xrtcTotalFinalProfitPercent_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal totalPrice = Convert.ToDecimal(xrtcTotalFianlPrice.Summary.GetResult());
            decimal totalProfit = Convert.ToDecimal(xrtcTotalFianlProfit.Summary.GetResult());
            xrtcTotalFinalProfitPercent.Text = $"{((totalProfit == 0) ? 0 : (totalPrice != 0) ? (totalProfit * 100) / totalPrice : 100):n2}%";
        }
       
    }
}


