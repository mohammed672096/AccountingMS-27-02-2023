﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using AccountingMS.Classes;
using System.Linq;

namespace AccountingMS.Report
{
    public partial class ReportSalePurGroup : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblGroupStr TblGroupStr= new ClsTblGroupStr();
        byte status = 1;
        public ReportSalePurGroup(DateTime fromDate, DateTime toDate, byte type)
        {
            InitializeComponent();
            status = type;
            xrTableSale2.Visible= xrTableSaleH.Visible= xrTableSaleLast.Visible= xrTableSale1.Visible = xrTableSale3.Visible = (status == 2);
            xrTablePur2.Visible= xrTablePurH.Visible= xrTablePurLast.Visible = xrTablePur1.Visible= xrTablePur3.Visible = (status == 1);
         
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitText(status);
            InitDefaultData(fromDate, toDate);
        }
        private void InitDefaultData(DateTime fromDate, DateTime toDate)
        {
            string LableP = MySetting.GetPrivateSetting.LangEng ? "Inventory group purchases report" : "تقرير مشتريات المجموعات المخزنية";
            string LableS = MySetting.GetPrivateSetting.LangEng ? "Store group sales report" : "تقرير مبيعات المجموعات المخزنية";
            this.xrSubRprt.ReportSource = new ReportHeader(status == 1 ? LableP : LableS);
            xrSubreport1.ReportSource = this.xrSubRprt.ReportSource;
            totalCaption2.Text = string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"من تاريخ :{fromDate:yyyy/MM/dd hh:mm tt}       الى تاريخ :{toDate:yyyy/MM/dd hh:mm tt}" : $"From Date :{fromDate:yyyy/MM/dd hh:mm tt} To Date :{toDate:hh:mm tt dd/MM/yyyy}");
        }
      
        private void XrtcGrpAccNo_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = TblGroupStr.GetGroupNameByAccNo(Convert.ToInt64(cell.Value));
        }
        private void InitText(byte status)
        {
            if (status == 1)
            {
                xrTableCellMain.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCellMain.Text.Replace("Sale", "Purchase") : xrTableCellMain.Text.Replace("مبيعات", "مشتريات");
                xrTableCell18.Text = MySetting.GetPrivateSetting.LangEng ? xrTableCell18.Text.Replace("Sale", "Purchase") : xrTableCell18.Text.Replace("مبيعات", "مشتريات");
                xrLabel1.Text = MySetting.GetPrivateSetting.LangEng ? xrLabel1.Text.Replace("Sale", "Purchase") : xrLabel1.Text.Replace("مبيعات", "مشتريات");
            }
             string Userpurchases = MySetting.GetPrivateSetting.LangEng ? "User purchases" : "مشتريات المستخدم";
            string UserSales = MySetting.GetPrivateSetting.LangEng ? "UserSales" : "مبيعات المستخدم";

            xrtcUserSalePurchase.Text = status == 1 ? Userpurchases : UserSales;
            xrtcUserSalePurchase.WidthF = status == 1 ? 180F : 170F;

            xrTableCellDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? string.Format($"{DateTime.Now:yyyy/MM/dd}") : string.Format($"{DateTime.Now:dd/MM/yyyy}");
        }
        private short userId;
        private void xrtcUserId_BeforePrint(object sender, CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            this.userId = Convert.ToInt16(cell.Value);
            cell.Text = this.clsTbUser.GetUserNameById(this.userId);
        }
        private void XrLabelTotal_BeforePrint(object sender, CancelEventArgs e)
        {
            string s= (this.userId > 0) ? $"إجمالي مبيعات المستخدم {this.clsTbUser.GetUserNameById(this.userId)}" : "الإجمالي";
            if (status == 1)
                xrLabelTotal.Text = MySetting.GetPrivateSetting.LangEng ? s.Replace("Sale", "Purchase") : s.Replace("مبيعات", "مشتريات");
            else xrLabelTotal.Text = s;
        }


        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }

        private void xrTableCell63_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal totalPrice = Convert.ToDecimal(xrtcTotalFianlPriceUser.Summary.GetResult());
            decimal totalProfit = Convert.ToDecimal(xrtcTotalFianlProfitUser.Summary.GetResult());
            xrtcTotalFinalProfitPercentUser.Text = $"{((totalProfit == 0) ? 0 : (totalPrice != 0) ? (totalProfit * 100) / totalPrice : 100):n2}%";
        }

        private void xrtcTotalFinalProfitPercent_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal totalPrice = Convert.ToDecimal(xrtcTotalFianlPrice.Summary.GetResult());
            decimal totalProfit = Convert.ToDecimal(xrtcTotalFianlProfit.Summary.GetResult());
            xrtcTotalFinalProfitPercent.Text = $"{((totalProfit == 0) ? 0 : (totalPrice != 0) ? (totalProfit * 100) / totalPrice : 100):n2}%";
        }
       
    }
}


