using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class rpt_TrialBalance : XtraReport
    {

        public rpt_TrialBalance(object dataSource, bool IsBeforeBalanced, bool IsTransBalnced, bool IsBalanceBalanced)
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            new ClsReportHeaderData(this);
            this.DataSource = dataSource;
            this.DataMember = "";
            this.DetailReport.DataSource = dataSource;
            this.DetailReport.DataMember = "Data";
            cell_Account.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Name]"));
            //xrTableCell7.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[BeforeCredit]"));
            //xrTableCell8.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[BeforeDebit]"));
            xrTableCell9.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Credit]"));
            xrTableCell10.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Debit]"));
            xrTableCell11.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[TotalCredit]"));
            xrTableCell12.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[TotalDebit]"));
            xrTableCell13.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[BalanceCredit]"));
            xrTableCell14.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[BalanceDebit]"));


            //xrTableCell30.Text = IsBeforeBalanced ? "متزن" : "غير متزن";
            //xrTableCell30.ForeColor = IsBeforeBalanced ? Color.Green : Color.Red;
            xrTableCell31.Text = IsTransBalnced ? "متزن" : "غير متزن";
            xrTableCell31.ForeColor = IsTransBalnced ? Color.Green : Color.Red;
            xrTableCell32.Text = IsBalanceBalanced ? "متزن" : "غير متزن";
            xrTableCell32.ForeColor = IsBalanceBalanced ? Color.Green : Color.Red;



        }








        private void SetHeaderVisibility(byte supStatus)
        {
            if ((MySetting.DefaultSetting.showRprtPurchaseHeader && (supStatus == 3 || supStatus == 7 || supStatus == 9 || supStatus == 10)) ||
                (MySetting.DefaultSetting.showRprtSaleHeader && (supStatus == 4 || supStatus == 8 || supStatus == 11 || supStatus == 12))) return;

            foreach (var control in TopMargin.Controls)
                if (control is XRLabel xrlabel && xrlabel.Name != "xrlHeader") xrlabel.Visible = false;

            xrPictureBoxBranch.Visible = false;
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
