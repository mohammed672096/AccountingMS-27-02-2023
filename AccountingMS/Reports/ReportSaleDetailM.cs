using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportSaleDetailM : XtraReport
    {
        ClsTblBox clsTbBox;
        ClsTblSupplyMain clsTbSupplyMain;
        ClsTblSupplySub clsTbSupplySub;
        ReportSaleDetailD rprtSaleDetailD;

        private DateTime dtStart, dtEnd;
        protected internal double totalPrdPrice, totalPrdSalePrice, totalTaxPrice, totalPrice;
        protected internal double totalFinal, totalPaidCash, totalPaidCredit, totalPaidBank, totalDscntAmount, totalProfit;

        private ReportSaleDetailM()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitDefaultData();
            InitSubReport();
            new ClsReportHeaderData(this);
        }

        public static async Task<ReportSaleDetailM> CreateAsync()
        {
            var rprt = new ReportSaleDetailM();
            await rprt.InitObjectsAsync();

            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbBox = new ClsTblBox()));
            taskList.Add(Task.Run(() => this.clsTbSupplyMain = new ClsTblSupplyMain(true)));
            taskList.Add(Task.Run(() => this.clsTbSupplySub = new ClsTblSupplySub(true)));

            await Task.WhenAll(taskList);
            tblBoxParmBindingSource.DataSource = this.clsTbBox.GetBoxList;
        }

        private void InitDefaultData()
        {
            parameterDateStart.Value = DateTime.Now.Date;
            parameterDateEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void InitSubReport()
        {
            this.rprtSaleDetailD = new ReportSaleDetailD(this);
            xrsRprtSaleDetailD.ReportSource = this.rprtSaleDetailD;
            xrsRprtSaleDetailD.BeforePrint += XrsRprtSaleDetailD_BeforePrint;
        }

        private void ReportSaleDetail_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            foreach (var info in e.ParametersInformation)
                if (info.Parameter.Name == parameterDateStart.Name || info.Parameter.Name == parameterDateEnd.Name) info.Editor = InitDateEdit();
        }

        private DateEdit InitDateEdit()
        {
            DateEdit dateEdit = new DateEdit();
            dateEdit.Properties.Mask.EditMask = "yyyy/MM/dd HH:mm";
            dateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            dateEdit.Properties.CalendarTimeProperties.EditMask = "HH:mm";
            return dateEdit;
        }

        private void ReportPurchaseSaleDetail_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDateStart.Value);
            this.dtEnd = Convert.ToDateTime(parameterDateEnd.Value);

            InitData();
            SetBandVisibility();
        }

        private void InitData()
        {
            IList<tblAccountBox> tbBoxList = new List<tblAccountBox>();
            foreach (var boxAccNo in parameterBox.Value as long[])
                if (InitDataJoin(boxAccNo).Count > 0) tbBoxList.Add(this.clsTbBox.GetBoxObjByAccNo(boxAccNo));

            if ((Convert.ToBoolean(parameterCredit.Value)) && InitDataJoin(0).Count > 0)
                tbBoxList.Add(new tblAccountBox() { boxAccNo = 0, boxName = "فواتير العملاء الآجل" });

            tblBoxBindingSource.DataSource = tbBoxList;
        }

        private void XrsRprtSaleDetailD_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ResetTotalValues();
            this.rprtSaleDetailD.DataSource = InitDataJoin(Convert.ToInt64(GetCurrentColumnValue("boxAccNo")));
            this.rprtSaleDetailD.SetBoxName(Convert.ToString(GetCurrentColumnValue("boxName")));
        }

        accountingEntities db = new accountingEntities();
        private IList<ItblSupplyMainDetail> InitDataJoin(long accNo)
        {
            var tbSupplyMainDetailList = (from tbSupplyMain in this.clsTbSupplyMain.GetSupplyMainListSaleByDtStartEnd(this.dtStart, this.dtEnd)
                                          where (accNo != 0 ? tbSupplyMain.supAccNo == accNo : tbSupplyMain.supIsCash == 2)
                                          join tbSupplySub in db.tblSupplySubs
                                          on tbSupplyMain.id equals tbSupplySub.supNo into tbSupplyMainDetail1
                                          select new
                                          {
                                             
                                              itbSupplyMain = tbSupplyMain as ItblSupplyMainDetail,
                                              prdPrice = tbSupplyMainDetail1.Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)),
                                              sPrice = tbSupplyMainDetail1.Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)),
                                          }).ToList();

            var itbSupplyMainDetailList = new List<ItblSupplyMainDetail>();

            foreach (var tbSupply in tbSupplyMainDetailList)
            {
                if (tbSupply.itbSupplyMain.supTotal == 0) continue;
                itbSupplyMainDetailList.Add(InitDetailData(tbSupply.itbSupplyMain,  tbSupply.prdPrice, tbSupply.sPrice));
            }

            return itbSupplyMainDetailList;
        }

        private ItblSupplyMainDetail InitDetailData(ItblSupplyMainDetail itbSupplyMain, double prdPrice, double sprdPrice)
        {
            itbSupplyMain.supPrdPrice = prdPrice;
            itbSupplyMain.supPrdSalePrice = sprdPrice;
            itbSupplyMain.supTotal = itbSupplyMain.supPrdSalePrice - Convert.ToDouble(itbSupplyMain.supDscntAmount);
            itbSupplyMain.supProfit = (itbSupplyMain.supTotal - prdPrice);
            itbSupplyMain.supProfitPercent = (prdPrice != 0) ? (float)((itbSupplyMain.supProfit * 100) / prdPrice) : 100;
            itbSupplyMain.supTaxPrice = (itbSupplyMain.supTaxPrice > 0) ? itbSupplyMain.supTaxPrice : 0;
            itbSupplyMain.supTaxPercent = (itbSupplyMain.supTaxPercent > 0) ? itbSupplyMain.supTaxPercent : 0;
            itbSupplyMain.supTotalFinal = Convert.ToDouble(itbSupplyMain.supTotal + itbSupplyMain.supTaxPrice);
            itbSupplyMain.supPaidCash = (itbSupplyMain.supBankAmount > 0) ? itbSupplyMain.supTotalFinal - Convert.ToDouble(itbSupplyMain.supBankAmount) : itbSupplyMain.supTotalFinal;

            if (itbSupplyMain.supIsCash == 2)
            {
                itbSupplyMain.supPaidCredit = itbSupplyMain.supPaidCash;
                itbSupplyMain.supPaidCash =Convert.ToDouble(itbSupplyMain.paidCash);
            }

            CalcualteTotalValues(itbSupplyMain);
            return itbSupplyMain;
        }

        private void CalcualteTotalValues(ItblSupplyMainDetail itbSupplyMainDetail)
        {
            switch ((SupplyType)itbSupplyMainDetail.supStatus)
            {
                case SupplyType.Sales:
                case SupplyType.SalesPhase:
                    IncreaseTotal(itbSupplyMainDetail);
                    break;
                case SupplyType.SalesRtrn:
                case SupplyType.SalesPhaseRtrn:
                    DecreaseTotal(itbSupplyMainDetail);
                    break;
            }
        }

        private void IncreaseTotal(ItblSupplyMainDetail itbSupplyMainDetail)
        {
            this.totalPrdPrice += itbSupplyMainDetail.supPrdPrice;
            this.totalPrdSalePrice += itbSupplyMainDetail.supPrdSalePrice;
            this.totalTaxPrice += Convert.ToDouble(itbSupplyMainDetail.supTaxPrice);
            this.totalPrice += itbSupplyMainDetail.supTotal;
            this.totalFinal += itbSupplyMainDetail.supTotalFinal;
            this.totalPaidCash += itbSupplyMainDetail.supPaidCash;
            this.totalPaidCredit += itbSupplyMainDetail.supPaidCredit;
            this.totalPaidBank += Convert.ToDouble(itbSupplyMainDetail.supBankAmount);
            this.totalDscntAmount += Convert.ToDouble(itbSupplyMainDetail.supDscntAmount);
            this.totalProfit += itbSupplyMainDetail.supProfit;
        }

        private void DecreaseTotal(ItblSupplyMainDetail itbSupplyMainDetail)
        {
            this.totalPrdPrice -= itbSupplyMainDetail.supPrdPrice;
            this.totalPrdSalePrice -= itbSupplyMainDetail.supPrdSalePrice;
            this.totalTaxPrice -= Convert.ToDouble(itbSupplyMainDetail.supTaxPrice);
            this.totalPrice -= itbSupplyMainDetail.supTotal;
            this.totalFinal -= itbSupplyMainDetail.supTotalFinal;
            this.totalPaidCash -= itbSupplyMainDetail.supPaidCash;
            this.totalPaidCredit -= itbSupplyMainDetail.supPaidCredit;
            this.totalPaidBank -= Convert.ToDouble(itbSupplyMainDetail.supBankAmount);
            this.totalDscntAmount -= Convert.ToDouble(itbSupplyMainDetail.supDscntAmount);
            this.totalProfit -= itbSupplyMainDetail.supProfit;
        }

        private void ResetTotalValues()
        {
            this.totalPrdPrice = 0;
            this.totalPrdSalePrice = 0;
            this.totalTaxPrice = 0;
            this.totalPrice = 0;
            this.totalFinal = 0;
            this.totalPaidCash = 0;
            this.totalPaidCredit = 0;
            this.totalPaidBank = 0;
            this.totalDscntAmount = 0;
            this.totalProfit = 0;
        }

        private void SetBandVisibility()
        {
            Detail.Visible = (tblBoxBindingSource.Count > 0 ? true : false);
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;
            parameterBox.Description = "Box";
            parameterDateStart.Description = "Date From";
            parameterDateEnd.Description = "Date To";
            parameterCredit.Description = "View credit bills:";

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
