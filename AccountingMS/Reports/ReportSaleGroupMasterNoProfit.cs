using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSaleGroupMasterNoProfit : XtraReport
    {
        ClsTblUser clsTbUser;
        ClsTblGroupStr clsTbGroup;
        ReportSaleGroupDetailTotals reportSaleGroupDetail;
        ICollection<tblPrdSaleDetail> tbPrdSaleGrpList;
        IEnumerable<tblPrdSaleDetail> tbPrdSaleDetailList;

        private short userId;
        private bool showDetail;

        public ReportSaleGroupMasterNoProfit(ClsTblUser clsTbUser, ClsTblGroupStr clsTbGroup)
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterGrpAccNo.Description = "Group:";
                parameterUserId.Description = "Users";
                parameterShowDetail.Description = "Detailed:";
                parameterDtStart.Description = "Date From";
                parameterDtEnd.Description = "Date To";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            InitObjects(clsTbUser, clsTbGroup);
            InitSubReport();

            this.BeforePrint += ReportSaleGroupMaster_BeforePrint;
            xrSubReportSaleGroupDetail.BeforePrint += XrSubReportSaleGroupDetail_BeforePrint;
        }

        private void InitObjects(ClsTblUser clsTbUser, ClsTblGroupStr clsTbGroup)
        {
            this.clsTbUser = clsTbUser;
            this.clsTbGroup = clsTbGroup;
        }

        private void InitSubReport()
        {
            this.reportSaleGroupDetail = new ReportSaleGroupDetailTotals();
            xrSubReportSaleGroupDetail.ParameterBindings.Add(new ParameterBinding("parameterGrpAccNo", tblPrdSaleDetailDataSource, "grpAccNo"));
        }

        private void ReportSaleGroupMaster_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.userId = Convert.ToInt16(parameterUserId.Value);
            this.showDetail = (bool)parameterShowDetail.Value;

            InitList();
            InitListData();
            InitReportData();
            SetSubReportSource();
            SetReportFooterVisibility();
        }

        private void InitList()
        {
            this.tbPrdSaleGrpList = new Collection<tblPrdSaleDetail>();
        }

        private void InitListData()
        {
            this.tbPrdSaleDetailList = this.DataSource as IEnumerable<tblPrdSaleDetail>;
            if (this.userId > 0) this.tbPrdSaleDetailList = this.tbPrdSaleDetailList.Where(x => x.userId == this.userId);
        }

        private void InitReportData()
        {
            foreach (var grpAccNo in parameterGrpAccNo.Value as long[])
                this.tbPrdSaleGrpList.Add(InitPrdSaleDetailObj(grpAccNo));

            this.DataSource = this.tbPrdSaleGrpList;
        }

        private tblPrdSaleDetail InitPrdSaleDetailObj(long grpAccNo)
        {
            var tbPrdSaleDetail = this.tbPrdSaleDetailList.Where(x => x.grpAccNo == grpAccNo)
                .GroupBy(x => x.grpAccNo, (key, grp) => new tblPrdSaleDetail()
                {
                    grpAccNo = key,
                    prdTax = grp.Sum(x => x.prdTax),
                    prdPrice = grp.Sum(x => x.prdPrice),
                    prdSalePrice = grp.Sum(x => x.prdSalePrice),
                    prdDscntAmount = grp.Sum(x => x.prdDscntAmount),
                    prdSaleTotal = grp.Sum(x => (x.prdSalePrice - x.prdDscntAmount) + x.prdTax)
                }).FirstOrDefault();

            return ClaculateProfit(tbPrdSaleDetail, grpAccNo);
        }

        private tblPrdSaleDetail ClaculateProfit(tblPrdSaleDetail tbPrdSaleDetail, long grpAccNo)
        {
            if (tbPrdSaleDetail == null) return new tblPrdSaleDetail() { grpAccNo = grpAccNo, prdSaleProfitPercent = "0%" };


            tbPrdSaleDetail.prdSaleProfit = (tbPrdSaleDetail.prdSalePrice - tbPrdSaleDetail.prdDscntAmount) - tbPrdSaleDetail.prdPrice;
            tbPrdSaleDetail.prdSaleProfitPercent = $"{((tbPrdSaleDetail.prdSaleProfit == 0) ? 0 : (tbPrdSaleDetail.prdPrice != 0) ? (tbPrdSaleDetail.prdSaleProfit * 100) / tbPrdSaleDetail.prdPrice : 100):n2}%";
            return tbPrdSaleDetail;
        }

        private void SetSubReportSource()
        {
            xrSubReportSaleGroupDetail.ReportSource = (this.showDetail) ? this.reportSaleGroupDetail : null;
        }

        private void XrSubReportSaleGroupDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.showDetail) this.reportSaleGroupDetail.DataSource = this.tbPrdSaleDetailList;
        }

        private void SetReportFooterVisibility()
        {
            ReportFooter.Visible = (this.tbPrdSaleGrpList.Count > 1) ? true : false;
        }

        private void XrtcGrpAccNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbGroup.GetGroupNameByAccNo(Convert.ToInt64(cell.Value));
        }

        private void XrLabelTotal_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            xrLabelTotal.Text = (this.userId > 0) ? $"إجمالي مبيعات المستخدم {this.clsTbUser.GetUserNameById(this.userId)}" : "الإجمالي";
        }

        private void XrtcTotalFinalProfitPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //decimal totalPrice = Convert.ToDecimal(xrtcTotalFianlPrice.Summary.GetResult());
           
        }
    }
}