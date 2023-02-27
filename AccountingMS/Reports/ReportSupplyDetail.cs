using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
namespace AccountingMS
{
    public partial class ReportSupplyDetail : XtraReport
    {
        ClsTblCustomer clsTbCustomer;
        private SupplyType supplyType;
        private ReportType reportType;
        private double totalPrdPrice, totalPrdSalePrice, totalTaxPrice, totalPrice;
        private double totalFinal, totalPaidCash, totalPaidCredit, totalPaidBank, totalDscntAmount, totalProfit;

        public ReportSupplyDetail(SupplyType supplyType = SupplyType.Sales, ReportType reportType = ReportType.DailyEntryDetail)
        {
            this.supplyType = supplyType;
            this.reportType = reportType;
            InitializeComponent();
            this.ShowPrintMarginsWarning = false;

            InitPurchaseLayout();
            InitCustomerProperties();
        }

        private void InitCustomerProperties()
        {
            if (this.reportType != ReportType.CustomerDailyEntryDetail) return;
            this.clsTbCustomer = new ClsTblCustomer();

            GroupHeader2.Visible = false;
            xrtcStatusH.Text = "إسم العميل";
            xrtcSupStatusV.ExpressionBindings.Clear();
            xrtcSupStatusV.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[supCustSplId]"));
        }

        private void InitPurchaseLayout()
        {
            if (this.supplyType != SupplyType.Purchase) return;

            DeleteTableColumn(xrTable1, xrtcPrdSalePrice, xrtcProfit, xrtcProfitPercent);
            DeleteTableColumn(xrTable2, xrtcPrdSalePriceValue, xrtcProfitValue, xrtcProfitPercentValue);

            xrTable3.DeleteColumn(xrtcTotalSalePrice);
            xrtcTotalProfit.WidthF = 80.71F;
            xrTable3.WidthF = 1129;
            xrtcTotalPaidCredit.WidthF += (xrtcProfit.WidthF + xrtcProfitPercent.WidthF + xrtcDate.WidthF);
        }

        private void DeleteTableColumn(XRTable xrTable, XRTableCell xrtcColumn1, XRTableCell xrtcColumn2, XRTableCell xrtcColumn3)
        {
            xrTable.DeleteColumn(xrtcColumn1);
            xrTable.DeleteColumn(xrtcColumn2);
            xrTable.DeleteColumn(xrtcColumn3);
            xrTable1.WidthF = 1129;
        }

        private void ReportSupplyDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetReportHeader();
            CalculateTotal();
            SetTotalText();
        }

        private void SetReportHeader()
        {
            if (this.reportType == ReportType.CustomerDailyEntryDetail) return;
            xrtcReportHeader.Text = $"كشف فواتير {((this.supplyType == SupplyType.Purchase) ? "المشتريات" : "المبيعات")} للفترة [Parameters.parameterDtStart!yyyy/MM/dd] إلى [Parameters.parameterDtEnd!yyyy/MM/dd]";
        }

        private void CalculateTotal()
        {
            ResetTotal();

            foreach (var tbSupplyDetail in this.DataSource as IEnumerable<ItblSupplyMainDetail>)

            {
                //var supsub = db.tblSupplySubs.Where(x => x.supNo == tbSupplyDetail.id).ToList();
                //tbSupplyDetail.supPrdSalePrice = supsub.Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain));
                //tbSupplyDetail.supPrdPrice= supsub.Sum(x => Convert.ToDouble(x.supPrice) * Convert.ToDouble(x.supQuanMain)); 
                if (tbSupplyDetail.supStatus <= 8) IncreaseTotal(tbSupplyDetail);
                else DecreaseTotal(tbSupplyDetail);
            }
        }

        private void ResetTotal()
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



        private void IncreaseTotal(ItblSupplyMainDetail tbSupplyDetail)
        {
            this.totalPrdPrice += tbSupplyDetail.supPrdPrice;
            this.totalPrdSalePrice += tbSupplyDetail.supPrdSalePrice;
            this.totalTaxPrice += Convert.ToDouble(tbSupplyDetail.supTaxPrice);
            this.totalPrice += tbSupplyDetail.supTotal;
            this.totalFinal += tbSupplyDetail.supTotalFinal;
            this.totalPaidCash += tbSupplyDetail.supPaidCash;
            this.totalPaidCredit += tbSupplyDetail.supPaidCredit;
            this.totalPaidBank += Convert.ToDouble(tbSupplyDetail.supBankAmount);
            this.totalDscntAmount += Convert.ToDouble(tbSupplyDetail.supDscntAmount);
            this.totalProfit += tbSupplyDetail.supProfit;
        }

        private void DecreaseTotal(ItblSupplyMainDetail tbSupplyDetail)
        {
            this.totalPrdPrice -= tbSupplyDetail.supPrdPrice;
            this.totalPrdSalePrice -= tbSupplyDetail.supPrdSalePrice;
            this.totalTaxPrice -= Convert.ToDouble(tbSupplyDetail.supTaxPrice);
            this.totalPrice -= tbSupplyDetail.supTotal;
            this.totalFinal -= tbSupplyDetail.supTotalFinal;
            this.totalPaidCash -= tbSupplyDetail.supPaidCash;
            this.totalPaidCredit -= tbSupplyDetail.supPaidCredit;
            this.totalPaidBank -= Convert.ToDouble(tbSupplyDetail.supBankAmount);
            this.totalDscntAmount -= Convert.ToDouble(tbSupplyDetail.supDscntAmount);
            this.totalProfit -= tbSupplyDetail.supProfit;
        }

        private void SetTotalText()
        {
            xrtcTotalPrdPrice.Text = $"{this.totalPrdPrice:n2}";
            xrtcTotalSalePrice.Text = $"{this.totalPrdSalePrice:n2}";
            xrtcTotalDiscount.Text = $"{this.totalDscntAmount:n2}";
            xrtcTotalTaxPrice.Text = $"{this.totalTaxPrice:n2}";
            xrtcTotalFinal.Text = $"{this.totalFinal:n2}";
            xrtcTotalPaidCash.Text = $"{this.totalPaidCash:n2}";
            xrtcTotalPaidCredit.Text = $"{this.totalPaidCredit:n2}";
            xrtcTotalPaidBank.Text = $"{this.totalPaidBank:n2}";
            xrtcTotalPrice.Text = $"{this.totalPrice:n2}";
            xrtcTotalProfit.Text = $"{this.totalProfit:n2}";
        }

        private void XrtcSupStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {

            XRTableCell cell = sender as XRTableCell;
            // cell.Row.Cells[0].Text;
            cell.Text = (this.reportType == ReportType.DailyEntryDetail) ? ClsSupplyStatus.GetString(Convert.ToByte(cell.Value),
                Convert.ToByte(GetCurrentColumnValue("supIsCash"))) : this.clsTbCustomer.GetCustomerNameById(Convert.ToInt32(cell.Value));
        }
        accountingEntities db = new accountingEntities();
        private void XrTableCell23_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //XRTableCell cell = sender as XRTableCell;
            //var supMainId = int.Parse(cell.Row.Cells[1].Text);

            //var supSub = db.tblSupplySubs.Where(x => x.supNo == supMainId).ToList();
            //double supPrdPrice = 0;
            //foreach (var tbSupplySub in supSub)
            //{
            //    supPrdPrice += Convert.ToDouble(tbSupplySub.supPrice) * Convert.ToDouble(tbSupplySub.supQuanMain);
            //    //supPrdSalePrice += Convert.ToDouble(tbSupplySub.supSalePrice) * Convert.ToDouble(tbSupplySub.supQuanMain);
            //}

            //cell.Text = supPrdPrice.ToString();

        }

        private void SalePrice_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //XRTableCell cell = sender as XRTableCell;
            //var supMainId = int.Parse(cell.Row.Cells[1].Text);

            //var supSub = db.tblSupplySubs.Where(x => x.supNo == supMainId).ToList();
            //cell.Text = supSub.Sum(x => Convert.ToDouble(x.supSalePrice) * Convert.ToDouble(x.supQuanMain)).ToString();
            //double   supPrdSalePrice = 0;
            //foreach (var tbSupplySub in supSub)
            //{

            //    supPrdSalePrice += Convert.ToDouble(tbSupplySub.supSalePrice) * Convert.ToDouble(tbSupplySub.supQuanMain);
            //}

            //cell.Text = supPrdSalePrice.ToString();

        }

        private void XrtcDscntPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void XrtcTaxPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void XrtcProfitPercentValue_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void AddPercentage(object sender)
        {
            ((XRTableCell)sender).Text += "%";
        }
    }
}
