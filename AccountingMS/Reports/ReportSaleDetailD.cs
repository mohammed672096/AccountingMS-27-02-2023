using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportSaleDetailD : XtraReport
    {
        private readonly ReportSaleDetailM rprtSaleDetailM;
        private string boxName;

        public ReportSaleDetailD(ReportSaleDetailM rprtSaleDetailM)
        {
            InitializeComponent();
            InitResources();

            this.rprtSaleDetailM = rprtSaleDetailM;
            this.BeforePrint += ReportSaleDetailD_BeforePrint;
        }

        protected internal void SetBoxName(string boxName)
        {
            this.boxName = boxName;
        }

        private void ReportSaleDetailD_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InitBoxName();
            InitTotalValues();
        }

        private void InitBoxName()
        {
            xrlBoxName.Text = $"مبيعات {(!string.IsNullOrEmpty(boxName) ? boxName : "فواتير العملاء الآجل")}";
        }

        private void InitTotalValues()
        {
            xrtcTotalPrdPrice.Text = $"{this.rprtSaleDetailM.totalPrdPrice:n2}";
            xrtcTotalSalePrice.Text = $"{this.rprtSaleDetailM.totalPrdSalePrice:n2}";
            xrtcTotalDiscount.Text = $"{this.rprtSaleDetailM.totalDscntAmount:n2}";
            xrtcTotalTaxPrice.Text = $"{this.rprtSaleDetailM.totalTaxPrice:n2}";
            xrtcTotalFinal.Text = $"{this.rprtSaleDetailM.totalFinal:n2}";
            xrtcTotalPaidCash.Text = $"{this.rprtSaleDetailM.totalPaidCash:n2}";
            xrtcTotalPaidCredit.Text = $"{this.rprtSaleDetailM.totalPaidCredit:n2}";
            xrtcTotalPaidBank.Text = $"{this.rprtSaleDetailM.totalPaidBank:n2}";
            xrtcTotalPrice.Text = $"{this.rprtSaleDetailM.totalPrice:n2}";
            xrtcTotalProfit.Text = $"{this.rprtSaleDetailM.totalProfit:n2}";
        }

        private void xrtcSupStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = ClsSupplyStatus.GetString(Convert.ToByte(cell.Value), Convert.ToByte(GetCurrentColumnValue("supIsCash")));
        }

        private void xrtcDscntPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void xrtcTaxPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void xrtcProfitPercent_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddPercentage(sender);
        }

        private void AddPercentage(object sender)
        {
            ((XRTableCell)sender).Text += "%";
        }

        private void InitResources()
        {
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
    }
}
