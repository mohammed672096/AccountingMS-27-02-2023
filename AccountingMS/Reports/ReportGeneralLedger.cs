using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportGeneralLedger : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblAccount clsTbAccount;
        ClsTblAsset clsTbAsset;

        private byte accCategorey = 0;
        private long accNo;
        private DateTime dtStart, dtEnd;
        private decimal totalDebit, totalCredit;

        public ReportGeneralLedger()
        {
            InitializeComponent();
            IniDefaultData();

            this.ParametersRequestSubmit += ReportGeneralLedger_ParametersRequestSubmit;
        }

        public static async Task<ReportGeneralLedger> CreateAsync()
        {
            var rprt = new ReportGeneralLedger();

            await rprt.IniObjectsAsync();

            rprt.tblBindingSource.DataSource = rprt.clsTbAccount.GetAccountListType2();

            return rprt;
        }

        private async Task IniObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbAccount = new ClsTblAccount()));
            taskList.Add(Task.Run(() => this.clsTbAsset = new ClsTblAsset()));

            await Task.WhenAll(taskList);
        }

        private void IniDefaultData()
        {
            new ClsReportHeaderData(this);

            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
        }

        private void ReportGeneralLedger_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.accNo = Convert.ToInt64(parameterAccNo.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = Convert.ToDateTime(parameterDtEnd.Value).Date;

            InitAccCategorey();
            InitTableColor();
            InitAccName();
            CalculateCredit();
            InitText();
            InitCurrentBalanceColor();
        }

        private void InitAccCategorey()
        {
            this.accCategorey = Convert.ToByte(this.accNo.ToString().Substring(0, 1));
        }

        private void InitAccName()
        {
            xrtcAccName.Text = this.clsTbAccount.GetAccountNameByNo(this.accNo);
        }

        private void CalculateCredit()
        {
            var result = this.clsTbAsset.GetAssetListByAccNoNdDtStartEnd(this.accNo, this.dtStart, this.dtEnd)
                .GroupBy(x => x.asAccNo, (key, grp) => new
                {
                    totalDebit = grp.Sum(x => x.asDebit),
                    totalCrtedit = grp.Sum(x => x.asCredit)
                });

            this.totalDebit = result.Select(x => Convert.ToDecimal(x.totalDebit)).FirstOrDefault();
            this.totalCredit = result.Select(x => Convert.ToDecimal(x.totalCrtedit)).FirstOrDefault();
        }

        private void InitText()
        {
            xrtcDate.Text = $"{DateTime.Now:g}";

            xrtcTotalDebit.Text = $"{this.totalDebit:n2}";
            xrtcTotalCredit.Text = $"{this.totalCredit:n2}";

            decimal total = this.totalDebit - this.totalCredit;
            total = total > 0 ? total : -(total);

            xrtcCurrentBalance.Text = $"{total:n2} ";
            xrtcCurrentBalance.Text += this.totalDebit > this.totalCredit ? "مدين" : "دائن";
        }

        private void InitCurrentBalanceColor()
        {
            if (this.totalDebit > this.totalCredit)
                switch (this.accCategorey)
                {
                    case 1:
                    case 2:
                        InitGreenStyle(xrtcCurrentBalance, xrtcCurrentBalanceStr);
                        break;
                    case 3:
                    case 4:
                        InitRedStyle(xrtcCurrentBalance, xrtcCurrentBalanceStr);
                        break;
                }
            else
                switch (this.accCategorey)
                {
                    case 1:
                    case 2:
                        InitRedStyle(xrtcCurrentBalance, xrtcCurrentBalanceStr);
                        break;
                    case 3:
                    case 4:
                        InitGreenStyle(xrtcCurrentBalance, xrtcCurrentBalanceStr);
                        break;
                }
        }

        private void InitTableColor()
        {
            switch (this.accCategorey)
            {
                case 1:
                case 2:
                    InitGreenStyle(xrtcTotalDebit, xrtcTotalDebitStr);
                    InitRedStyle(xrtcTotalCredit, xrtcTotalCreditStr);
                    break;
                case 3:
                case 4:
                    InitGreenStyle(xrtcTotalCredit, xrtcTotalCreditStr);
                    InitRedStyle(xrtcTotalDebit, xrtcTotalDebitStr);
                    break;
            }
        }

        private void InitGreenStyle(XRTableCell xrtc, XRTableCell xrtcStr)
        {
            xrtc.ForeColor = Color.Green;
            xrtc.BackColor = Color.FromArgb(249, 255, 242);

            xrtcStr.ForeColor = Color.Green;
            xrtcStr.BackColor = Color.FromArgb(212, 223, 201);
        }

        private void InitRedStyle(XRTableCell xrtc, XRTableCell xrtcStr)
        {
            xrtc.ForeColor = Color.Red;
            xrtc.BackColor = Color.FromArgb(255, 244, 236);

            xrtcStr.ForeColor = Color.Red;
            xrtcStr.BackColor = Color.FromArgb(240, 212, 194);
        }
    }
}
