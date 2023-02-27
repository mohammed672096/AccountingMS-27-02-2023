using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace AccountingMS
{
    public partial class ReportCustSuplAllBalanceBatch : DevExpress.XtraReports.UI.XtraReport
    {
        ClsCustomerBalanceData clsCustBalanceData;
        ClsSupplierBalanceData clsSplBalanceData;
        ClsTblCustomer clsTbCustomer;
        ClsTblSupplier clsTbSupplier;
        ICollection<ClsBalanceDetailColumnsData> balanceDetailList;

        private readonly byte status;
        private DateTime dtStart;
        private DateTime dtEnd;

        public ReportCustSuplAllBalanceBatch(byte status)
        {
            this.status = status;
            InitializeComponent();
            InitDefaultData();
            InitData();
            new ClsReportHeaderData(this);
            this.dtStart = Session.CurrentYear.fyDateStart.Date;
            this.dtEnd = Session.CurrentYear.fyDateEnd.Date;

            InitRprtData();
        }

        private void InitDefaultData()
        {
            SetSupplieText();
            
           
        }

        private void SetSupplieText()
        {
            if (this.status != 2) return;
            xrlHeader.Text = (!MySetting.GetPrivateSetting.LangEng) ? "تقرير أرصدة الموردين" : "Suppliers Balance Report";
            xrtcBalanceName.Text = (!MySetting.GetPrivateSetting.LangEng) ? "كشف أرصدة الموردين" : "Suppliers Balance Statement";
           
        }

        private void InitData()
        {
            switch (this.status)
            {
                case 1:
                    this.clsCustBalanceData = new ClsCustomerBalanceData();
                    this.clsTbCustomer = new ClsTblCustomer();
                    xrTable1.DeleteColumn(xrtcTaxNoHeader, false);
                    xrTable2.DeleteColumn(xrtcTaxNo, false);
                    break;
                case 2:
                    this.clsSplBalanceData = new ClsSupplierBalanceData();
                    this.clsTbSupplier = new ClsTblSupplier();
                    break;
            }
        }

        private void ReportCustomerSupplierBatchBalance_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Session.CurrentYear.fyDateStart.Date;
            this.dtEnd = Session.CurrentYear.fyDateEnd.Date;

            InitRprtData();
        }

        private void InitRprtData()
        {
            this.balanceDetailList = new Collection<ClsBalanceDetailColumnsData>();

            switch (this.status)
            {
                case 1:
                    InitCustomersBalance();

                    break;
                case 2:
                    InitSuppliersBalance();
                    break;
            }

            tblBalanceDetailBindingSource1.DataSource = this.balanceDetailList;
        }

        private void InitCustomersBalance()
        {
            IEnumerable<tblCustomer> tbCustomerList = this.clsTbCustomer.GetCustomersList();
            string currentBalanceString = null;

            foreach (var tbCustomer in tbCustomerList)
            {
                this.clsCustBalanceData.CalculatePeriodBalance(tbCustomer.custAccNo, this.dtStart, this.dtEnd);
                currentBalanceString = GetCurrentBalanceString(this.clsCustBalanceData.DebitPeriod, this.clsCustBalanceData.CreditPeriod);
                if (this.clsCustBalanceData.DebitPeriod == 0 && this.clsCustBalanceData.CreditPeriod == 0) continue;
                else
                {
                    this.balanceDetailList.Add(ClsBalanceDetailColumnsData.CreateDetailBalance(tbCustomer.custAccNo, tbCustomer.custName,
                                            tbCustomer.custPhnNo, tbCustomer.custAddress, null, this.clsCustBalanceData.DebitPeriod,
                                            this.clsCustBalanceData.CreditPeriod, currentBalanceString));
                }
            }
        }

        private void InitSuppliersBalance()
        {
            IEnumerable<tblSupplier> tbSupplierList = this.clsTbSupplier.GetSuppliersList();
            string currentBalanceString = null;

            foreach (var tbSupplier in tbSupplierList)
            {
                this.clsSplBalanceData.CalculatePeriodBalance(tbSupplier.splAccNo, this.dtStart, this.dtEnd);
                currentBalanceString = GetCurrentBalanceString(this.clsSplBalanceData.DebitPeriod, this.clsSplBalanceData.CreditPeriod);
                if (this.clsSplBalanceData.DebitPeriod == 0 && this.clsSplBalanceData.CreditPeriod == 0) continue;
                else
                {
                    this.balanceDetailList.Add(ClsBalanceDetailColumnsData.CreateDetailBalance(tbSupplier.splAccNo, tbSupplier.splName,
                                            tbSupplier.splPhnNo, tbSupplier.splAddress, tbSupplier.splTaxNo, this.clsSplBalanceData.DebitPeriod,
                                            this.clsSplBalanceData.CreditPeriod, currentBalanceString));
                }
               
            }
        }

        private string GetCurrentBalanceString(double debitPeriod, double creditPeriod)
        {
            double total = creditPeriod - debitPeriod;

            if (total > 0)
                return $"{total:#,#.##} دائن";
            else if (total < 0)
                return $"{-total:#,#.##} مدين";
            else
                return "0.00";
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double currentBalance = Convert.ToDouble(xrtcCreditSummary.Summary.GetResult()) - Convert.ToDouble(xrtcDebitSummary.Summary.GetResult());
            SetCustomerFooterCellWidth();
            SetCurrentBalance(currentBalance);
        }

        private void SetCustomerFooterCellWidth()
        {
            if (this.status != 1) return;
            xrtcTotalString.WidthF = 307.71F;
            xrtcDebitSummary.WidthF = 111.01F;
            xrtcCreditSummary.WidthF = 111.01F;
        }

        private void SetCurrentBalance(double currentBalance)
        {
            if (currentBalance > 0)
            {
                xrtcCurrentBalance.Text = $"{currentBalance:#,#.##} دائن";
                xrtcCurrentBalance.ForeColor = Color.Green;
            }
            else if (currentBalance < 0)
            {
                xrtcCurrentBalance.Text = $"{-currentBalance:#,#.##} مدين";
                xrtcCurrentBalance.ForeColor = Color.Red;
            }
            else if (currentBalance == 0)
            {
                xrtcCurrentBalance.Text = "0.00";
                xrtcCurrentBalance.ForeColor = Color.Green;
            }
        }
    }
}
