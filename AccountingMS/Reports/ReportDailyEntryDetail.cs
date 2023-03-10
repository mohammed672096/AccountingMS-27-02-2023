using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportDailyEntryDetail : XtraReport
    {
        ReportSupplyDetail reportSupplySale;
        ReportSupplyDetail reportSupplyPurchase;
        ClsTblAccount clsTbAccount = new ClsTblAccount();
        //ClsTblBox clsTbBox = new ClsTblBox();
        ClsTblEntryMain clsTbEntryMain = new ClsTblEntryMain();
        ClsTblSupplyMain clsTbSupplyMain = new ClsTblSupplyMain(true);
        ClsTblSupplySub clsTbSupplySub = new ClsTblSupplySub(true);
        IEnumerable<tblEntryMain> tbEntryMainList;
        IEnumerable<ItblSupplyMainDetail> tbSupplyMainDetailList;
        IEnumerable<ItblSupplyMainDetail> tbSupplyPurchaseDetailList;
        IEnumerable<ItblSupplyMainDetail> tbSupplySaleDetailList;

        private readonly ReportType reportType;
        private DateTime dtStart, dtEnd;
        private double totalEntAmount, totalEntTax;
        private double supPrdPrice, supPrdSalePrice;

        public ReportDailyEntryDetail(ReportType reportType)
        {
            this.reportType = reportType;
            InitializeComponent();
            InitData();
            InitDefaultData();
            InitDailyEntrySubRprt();
            InitCustomerDailyEntry();
            new ClsReportHeaderData(this);

            xrSubreportSale.BeforePrint += XrSubreportSale_BeforePrint;
            xrSubreportPurchase.BeforePrint += XrSubreportPurchase_BeforePrint;
        }

        private void InitDefaultData()
        {
            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrLabelDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void InitDailyEntrySubRprt()
        {
            if (this.reportType != ReportType.DailyEntryDetail) return;
            InitSubReportSale();
            InitSubReportPurchase();
        }

        private void InitSubReportPurchase()
        {
            this.reportSupplyPurchase = new ReportSupplyDetail(SupplyType.Purchase);
            xrSubreportPurchase.ReportSource = this.reportSupplyPurchase;

            xrSubreportPurchase.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubreportPurchase.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
        }

        private void InitSubReportSale()
        {
            this.reportSupplySale = new ReportSupplyDetail(reportType: this.reportType);
            xrSubreportSale.ReportSource = this.reportSupplySale;

            xrSubreportSale.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubreportSale.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
        }

        private void InitCustomerDailyEntry()
        {
            if (this.reportType != ReportType.CustomerDailyEntryDetail) return;

            InitSubReportSale();
            DetailBandEntry.Visible = false;
            DetailBandPurchase.Visible = false;
            xrLabelHeaderSale.Text = "تقرير فواتير العملاء التفصيلي";
            xrtcBalanceName.Text = "كشف فواتير العملاء التفصيلي للفترة [Parameters.parameterDtStart!yyyy/MM/dd] إلى [Parameters.parameterDtEnd!yyyy/MM/dd]";
        }

        private void InitData()
        {
            this.tbSupplyMainDetailList = this.clsTbSupplyMain.GetSupplyMainListPurchaseNdSale().ConvertAll(item => item as ItblSupplyMainDetail);

            //foreach (ItblSupplyMainDetail itbSupplyMain in this.tbSupplyMainDetailList)
            //{
            //    if (itbSupplyMain.supTotal == 0) continue;
            //    CalculateSupplySubData(itbSupplyMain.id);

            //    itbSupplyMain.supPrdPrice = this.supPrdPrice;
            //    itbSupplyMain.supPrdSalePrice = this.supPrdSalePrice;
            //    itbSupplyMain.supTotal -= Convert.ToDouble(itbSupplyMain.supDscntAmount);
            //    itbSupplyMain.supProfit = (itbSupplyMain.supTotal - this.supPrdPrice);
            //    itbSupplyMain.supProfitPercent = (this.supPrdPrice != 0) ? (float)Math.Round(((itbSupplyMain.supProfit * 100) / this.supPrdPrice), 2, MidpointRounding.AwayFromZero) : 100;
            //    itbSupplyMain.supTaxPrice = (itbSupplyMain.supTaxPrice > 0) ? itbSupplyMain.supTaxPrice : 0;
            //    itbSupplyMain.supTaxPercent = (itbSupplyMain.supTaxPercent > 0) ? itbSupplyMain.supTaxPercent : 0;
            //    itbSupplyMain.supTotalFinal = Convert.ToDouble(itbSupplyMain.supTotal + itbSupplyMain.supTaxPrice);
            //    itbSupplyMain.supPaidCash = (itbSupplyMain.supBankAmount > 0) ? itbSupplyMain.supTotalFinal - Convert.ToDouble(itbSupplyMain.supBankAmount) : itbSupplyMain.supTotalFinal;

            //    if (itbSupplyMain.supIsCash != 2) continue;
            //    itbSupplyMain.supPaidCredit = itbSupplyMain.supPaidCash;
            //    itbSupplyMain.supPaidCash = 0;
            //}
        }
        accountingEntities db = new accountingEntities();
        private void CalculateSupplySubData(int supId)
        {
            this.supPrdPrice = 0; this.supPrdSalePrice = 0;
            var supSup = db.tblSupplySubs.Where(x => x.supBrnId == Session.CurBranch.brnId && x.supNo == supId).ToList();
            foreach (var tbSupplySub in supSup)// this.clsTbSupplySub.GetSupplySubListBySupId(supId))
            {
                this.supPrdPrice += Convert.ToDouble(tbSupplySub.supPrice) * Convert.ToDouble(tbSupplySub.supQuanMain);
                this.supPrdSalePrice += Convert.ToDouble(tbSupplySub.supSalePrice) * Convert.ToDouble(tbSupplySub.supQuanMain);
            }
        }

        private void ReportDailyEntryDetail_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            foreach (var info in e.ParametersInformation)
                if (info.Parameter.Name == parameterDtStart.Name || info.Parameter.Name == parameterDtEnd.Name) info.Editor = InitDateEdit();
        }

        private DateEdit InitDateEdit()
        {
            DateEdit dateEdit = new DateEdit();
            dateEdit.Properties.Mask.EditMask = "yyyy/MM/dd h:mm tt";
            dateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            return dateEdit;
        }

        private void GetParameterData()
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value);
            this.dtEnd = Convert.ToDateTime(parameterDtEnd.Value);
        }

        private void ReportDailyEntryDetail_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            GetParameterData();
            InitEntryData();
            InitSupplyData();
            SetBandVisibility();
        }

        private void InitEntryData()
        {
            if (this.reportType != ReportType.DailyEntryDetail) return;
            GetEmtryData();
            CalculateEntryTotalValues();
            SetEntryTotalText();
        }

        private void GetEmtryData()
        {
            this.tbEntryMainList = this.clsTbEntryMain.GetEntMainVoucherNdRecieptList().Where(x => x.entDate >= this.dtStart && x.entDate <= this.dtEnd);
            tblEntryMainBindingSource.DataSource = this.tbEntryMainList;
        }

        private void CalculateEntryTotalValues()
        {
            this.totalEntAmount = 0; this.totalEntTax = 0;

            foreach (var tbEntMain in this.tbEntryMainList)
                if (tbEntMain.entStatus % 3 == 0) IncreaseEntryTotal(tbEntMain.entAmount, tbEntMain.entTotalTax);
                else DecreaseEntryTotal(tbEntMain.entAmount, tbEntMain.entTotalTax);
        }

        private void IncreaseEntryTotal(double entAmount, double? entTotalTax)
        {
            this.totalEntAmount += entAmount;
            this.totalEntTax += Convert.ToDouble(entTotalTax);
        }

        private void DecreaseEntryTotal(double entAmount, double? entTotalTax)
        {
            this.totalEntAmount -= entAmount;
            this.totalEntTax -= Convert.ToDouble(entTotalTax);
        }

        private void SetEntryTotalText()
        {
            xrtcTotalEntryAmount.Text = $"{this.totalEntAmount:n2}";
            xrtcTotalEntryTax.Text = $"{this.totalEntTax:n2}";
            xrtcTotalEntryFinal.Text = $"{this.totalEntAmount + this.totalEntTax:n2}";
        }

        private void InitSupplyData()
        {
            if (this.reportType == ReportType.DailyEntryDetail) InitSupplyDataDailyEntry();
            else if (this.reportType == ReportType.CustomerDailyEntryDetail) InitSupplyDataCustomer();
        }

        private void InitSupplyDataCustomer()
        {
            var list = InitSupplyData((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesRtrn,
                (byte)SupplyType.SalesPhaseRtrn).Where(x => Convert.ToInt32(x.supCustSplId) > 0);
            //this.tbSupplySaleDetailList = InitSupplyData((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesRtrn,
            //    (byte)SupplyType.SalesPhaseRtrn).Where(x => Convert.ToInt32(x.supCustSplId) > 0);
            //foreach (var itbSupplyMain in list)
            //{
            //    if (itbSupplyMain.supTotal == 0) continue;
            //    itbSupplyMain.supPrdPrice = db.tblSupplySubs.Where(x => x.supNo == itbSupplyMain.id).ToList().Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain));
            //    itbSupplyMain.supPrdSalePrice = db.tblSupplySubs.Where(x => x.supNo == itbSupplyMain.id).ToList().Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain));
            //    itbSupplyMain.supTotal -= Convert.ToDouble(itbSupplyMain.supDscntAmount);
            //    itbSupplyMain.supProfit = (itbSupplyMain.supTotal - this.supPrdPrice);
            //    itbSupplyMain.supProfitPercent = (this.supPrdPrice != 0) ? (float)Math.Round(((itbSupplyMain.supProfit * 100) / this.supPrdPrice), 2, MidpointRounding.AwayFromZero) : 100;
            //    itbSupplyMain.supTaxPrice = (itbSupplyMain.supTaxPrice > 0) ? itbSupplyMain.supTaxPrice : 0;
            //    itbSupplyMain.supTaxPercent = (itbSupplyMain.supTaxPercent > 0) ? itbSupplyMain.supTaxPercent : 0;
            //    itbSupplyMain.supTotalFinal = Convert.ToDouble(itbSupplyMain.supTotal + itbSupplyMain.supTaxPrice);
            //    itbSupplyMain.supPaidCash = (itbSupplyMain.supBankAmount > 0) ? itbSupplyMain.supTotalFinal - Convert.ToDouble(itbSupplyMain.supBankAmount) : itbSupplyMain.supTotalFinal;

            //    if (itbSupplyMain.supIsCash != 2) continue;
            //    itbSupplyMain.supPaidCredit = itbSupplyMain.supPaidCash;
            //    itbSupplyMain.supPaidCash = 0;

            //}
            this.tbSupplySaleDetailList = list;



        }

        private void InitSupplyDataDailyEntry()
        {
            this.tbSupplyPurchaseDetailList = InitSupplyData((byte)SupplyType.Purchase, (byte)SupplyType.PurchasePhase, (byte)SupplyType.PurchaseRtrn, (byte)SupplyType.PurchasePhaseRtrn);
            this.tbSupplySaleDetailList = InitSupplyData((byte)SupplyType.Sales, (byte)SupplyType.SalesPhase, (byte)SupplyType.SalesRtrn, (byte)SupplyType.SalesPhaseRtrn);
        }

        private IEnumerable<ItblSupplyMainDetail> InitSupplyData(byte status1, byte status2, byte statusRtrn1, byte statusRtrn2)
        {
            accountingEntities db1 = new accountingEntities();

            var listinv = this.tbSupplyMainDetailList.Where(x => x.supDate >= this.dtStart && x.supDate <= this.dtEnd &&
                  (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == statusRtrn1 || x.supStatus == statusRtrn2));

            IEnumerable<ItblSupplyMainDetail> cloneList = new List<ItblSupplyMainDetail>();

            foreach (ItblSupplyMainDetail itbSupplyMain in listinv)
            {
                if (itbSupplyMain.supTotal == 0) continue;
                CalculateSupplySubData(itbSupplyMain.id);

                //  itbSupplyMain.supTotal = db1.tblSupplyMains.Find(itbSupplyMain.id).supTotal*100;

                itbSupplyMain.supPrdPrice = this.supPrdPrice;
                itbSupplyMain.supPrdSalePrice = this.supPrdSalePrice;
                itbSupplyMain.supTotal -= Convert.ToDouble(itbSupplyMain.supDscntAmount);
                itbSupplyMain.supProfit = (itbSupplyMain.supTotal - this.supPrdPrice);
                itbSupplyMain.supProfitPercent = (this.supPrdPrice != 0) ? (float)Math.Round(((itbSupplyMain.supProfit * 100) / this.supPrdPrice), 2, MidpointRounding.AwayFromZero) : 100;
                itbSupplyMain.supTaxPrice = (itbSupplyMain.supTaxPrice > 0) ? itbSupplyMain.supTaxPrice : 0;
                itbSupplyMain.supTaxPercent = (itbSupplyMain.supTaxPercent > 0) ? itbSupplyMain.supTaxPercent : 0;
                itbSupplyMain.supTotalFinal = Convert.ToDouble(itbSupplyMain.supTotal + itbSupplyMain.supTaxPrice);
                itbSupplyMain.supPaidCash = (itbSupplyMain.supBankAmount > 0) ? itbSupplyMain.supTotalFinal - Convert.ToDouble(itbSupplyMain.supBankAmount) : itbSupplyMain.supTotalFinal;

                if (itbSupplyMain.supIsCash != 2) continue;
                itbSupplyMain.supPaidCredit = itbSupplyMain.supPaidCash;
                itbSupplyMain.supPaidCash = 0;
            }

            return listinv;

            //return this.tbSupplyMainDetailList.Where(x => x.supDate >= this.dtStart && x.supDate <= this.dtEnd &&
            //    (x.supStatus == status1 || x.supStatus == status2 || x.supStatus == statusRtrn1 || x.supStatus == statusRtrn2));
        }

        private void SetBandVisibility()
        {
            if (this.reportType != ReportType.DailyEntryDetail) return;
            DetailBandEntry.Visible = (this.tbEntryMainList.Count() >= 1) ? true : false;
            DetailBandPurchase.Visible = (this.tbSupplyPurchaseDetailList.Count() >= 1) ? true : false;
            DetailBandSale.Visible = (this.tbSupplySaleDetailList.Count() >= 1) ? true : false;
        }

        private void XrSubreportPurchase_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.reportSupplyPurchase.DataSource = this.tbSupplyPurchaseDetailList;
        }

        private void XrSubreportSale_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.reportSupplySale.DataSource = this.tbSupplySaleDetailList;
        }

        private void XrtcEntStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsEntryStatus.GetString(Convert.ToByte(cell.Value));
        }

        private void XrtcEntBoxNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbAccount.GetAccountNameByNo(Convert.ToInt64(cell.Value));
            //cell.Text = this.clsTbBox.GetBoxNameByAccNo(Convert.ToInt64(cell.Value));
        }
    }
}
