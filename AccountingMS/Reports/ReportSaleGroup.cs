using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSaleGroup : XtraReport
    {
        ReportSaleGroupMaster reportSaleGroupMaster;
        ClsTblUser clsTbUser = new ClsTblUser();
        ClsTblGroupStr clsTbGroup = new ClsTblGroupStr();
        ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub(SupplyType.SalesAll);
        List<tblPrdSaleDetail> tbPrdSaleGrpList;
        ICollection<tblUser> tbUserList;
        IEnumerable<tblPrdSaleDetail> tbPrdSaleDetailTmpList;

        private DateTime dtStart, dtEnd;

        public ReportSaleGroup()
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
            InitDefaultData();
            InitSubReport();
            new ClsReportHeaderData(this);

            xrSubReportSaleGroupMaster.BeforePrint += XrSubReportSaleGroupMaster_BeforePrint;
        }

        private void InitDefaultData()
        {
            tblUserBindingSource.DataSource = this.clsTbUser.GetUserList;
            tblGroupStrBindingSource.DataSource = this.clsTbGroup.GetGroupList;

            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void InitSubReport()
        {
            this.reportSaleGroupMaster = new ReportSaleGroupMaster(this.clsTbUser, this.clsTbGroup);
            xrSubReportSaleGroupMaster.ReportSource = this.reportSaleGroupMaster;
            xrSubReportSaleGroupMaster.ParameterBindings.Add(new ParameterBinding("parameterGrpAccNo", parameterGrpAccNo));
            xrSubReportSaleGroupMaster.ParameterBindings.Add(new ParameterBinding("parameterUserId", tblUserDataSource, "id"));
            xrSubReportSaleGroupMaster.ParameterBindings.Add(new ParameterBinding("parameterShowDetail", parameterShowDetail));
        }

        private void ReportSaleGroup_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            InitLists();
            InitData();
            CalculateTotalProfit();
            SetUserTableVisibility();
            SetSubReportLocation();
            SetReportFooterVisibility();
        }

        private void InitLists()
        {
            this.tbUserList = new Collection<tblUser>();
            this.tbPrdSaleGrpList = new List<tblPrdSaleDetail>();
        }

        private void InitData()
        {
            foreach (var userId in parameterUserId.Value as short[])
                this.tbUserList.Add(new tblUser() { id = userId });

            foreach (var grpAccNo in parameterGrpAccNo.Value as long[])
                InitPrdSaleGrpList(grpAccNo);

            tblUserDataSource.DataSource = this.tbUserList;
        }

        private void InitPrdSaleGrpList(long grpAccNo)
        {
            InitPrdSaleDetailTmpList(grpAccNo);
            this.tbPrdSaleGrpList.AddRange(this.tbPrdSaleDetailTmpList);
        }

        private void InitPrdSaleDetailTmpList(long grpAccNo)
        {
            this.tbPrdSaleDetailTmpList = this.clsTbSupplySub.GetSupplySubByAccNoNdDtStartEnd(grpAccNo, this.dtStart, this.dtEnd)
                .GroupBy(x => new { x.supUserId, x.supMsur,x.supPrdId }, (key, grp) => new tblPrdSaleDetail()
                {
                    grpAccNo = grpAccNo,
                    userId = Convert.ToInt16(key.supUserId),
                    prdMsur = Convert.ToInt32(key.supMsur),
                    prdName = grp.Select(x => x.supPrdName).FirstOrDefault(),
                    prdQuant = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supQuanMain)),
                    prdPrice = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                    prdSalePrice = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                    prdDscntAmount = grp.Where(x => x.supStatus <= 8 && Convert.ToDouble(x.supDscntPercent) > 0).Sum(x => (Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble((x.supDscntPercent / 100))),
                    prdTax = grp.Where(x => x.supStatus <= 8).Sum(x => Convert.ToDouble(x.supTaxPrice)),
                    prdQuantRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supQuanMain)),
                    prdPriceRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                    prdSalePriceRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                    prdDscntAmountRtrn = grp.Where(x => x.supStatus >= 11 && Convert.ToDouble(x.supDscntPercent) > 0).Sum(x => (Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)) * Convert.ToDouble((x.supDscntPercent / 100))),
                    prdTaxRtrn = grp.Where(x => x.supStatus >= 11).Sum(x => Convert.ToDouble(x.supTaxPrice)),
                }).ToList();

            CalculateProfit();
        }

        private void CalculateProfit()
        {
            foreach (var tbPrdSale in this.tbPrdSaleDetailTmpList)
            {
                tbPrdSale.prdQuant -= tbPrdSale.prdQuantRtrn;
                tbPrdSale.prdTax -= tbPrdSale.prdTaxRtrn;
                tbPrdSale.prdPrice -= tbPrdSale.prdPriceRtrn;
                tbPrdSale.prdSalePrice -= tbPrdSale.prdSalePriceRtrn;
                tbPrdSale.prdDscntAmount -= tbPrdSale.prdDscntAmountRtrn;
                tbPrdSale.prdSaleProfit = (tbPrdSale.prdSalePrice - tbPrdSale.prdDscntAmount) - tbPrdSale.prdPrice;
                tbPrdSale.prdSaleProfitPercent = $"{ ((tbPrdSale.prdSaleProfit == 0) ? 0 : ((tbPrdSale.prdPrice != 0) ? (tbPrdSale.prdSaleProfit * 100) / tbPrdSale.prdPrice : 100)):n2}%";
            }
        }

        private void CalculateTotalProfit()
        {
            if (this.tbUserList.Count <= 1) return;
            var tbPrdSaleTotal = new tblPrdSaleDetail();

            foreach (var tbPrdSale in this.tbPrdSaleGrpList)
            {
                tbPrdSaleTotal.prdTax += tbPrdSale.prdTax;
                tbPrdSaleTotal.prdPrice += tbPrdSale.prdPrice;
                tbPrdSaleTotal.prdSalePrice += tbPrdSale.prdSalePrice;
                tbPrdSaleTotal.prdDscntAmount += tbPrdSale.prdDscntAmount;
                tbPrdSaleTotal.prdSaleProfit += tbPrdSale.prdSaleProfit;
            }
            tbPrdSaleTotal.prdSaleTotal = (tbPrdSaleTotal.prdSalePrice - tbPrdSaleTotal.prdDscntAmount) + tbPrdSaleTotal.prdTax;
            tbPrdSaleTotal.prdSaleProfitPercent = $"{ ((tbPrdSaleTotal.prdSaleProfit == 0) ? 0 : ((tbPrdSaleTotal.prdPrice != 0) ? (tbPrdSaleTotal.prdSaleProfit * 100) / tbPrdSaleTotal.prdPrice : 100)):n2}%";

            SetTotalText(tbPrdSaleTotal);
        }

        private void SetTotalText(tblPrdSaleDetail tbPrdSaleTotal)
        {
            xrtcTotalFianlPrice.Text = $"{tbPrdSaleTotal.prdPrice:n3}";
            xrtcTotalFianlSalePrice.Text = $"{tbPrdSaleTotal.prdSalePrice:n2}";
            xrtcTotalFianlSaleTotal.Text = $"{tbPrdSaleTotal.prdSaleTotal:n2}";
            xrtcTotalFianlDiscount.Text = $"{tbPrdSaleTotal.prdDscntAmount:n2}";
            xrtcTotalFinalPrdTax.Text = $"{tbPrdSaleTotal.prdTax:n2}";
            xrtcTotalFianlProfit.Text = $"{tbPrdSaleTotal.prdSaleProfit:n2}";
            xrtcTotalFinalProfitPercent.Text = $"{tbPrdSaleTotal.prdSaleProfitPercent:n2}";
        }

        private void SetUserTableVisibility()
        {
            xrTableUser.Visible = (this.tbUserList.Count > 0) ? true : false;
        }

        private void SetSubReportLocation()
        {
            xrSubReportSaleGroupMaster.LocationF = new System.Drawing.PointF(10, (this.tbUserList.Count > 0) ? 55 : 10);
        }

        private void XrSubReportSaleGroupMaster_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.reportSaleGroupMaster.DataSource = this.tbPrdSaleGrpList;
        }

        private void XrTableCell4_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbUser.GetUserNameById(Convert.ToInt16(cell.Value));
        }

        private void SetReportFooterVisibility()
        {
            ReportFooter.Visible = (this.tbUserList.Count > 1) ? true : false;
        }
    }
}