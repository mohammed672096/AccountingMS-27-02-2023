using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportTrailBalance : XtraReport
    {
        accountingEntities db = new accountingEntities();
        ClsTblAccount clsTbAccount = new ClsTblAccount();
        IEnumerable<tblAccount> tbAccountList;
        IEnumerable<tblAssetFrgn> tbAccountFrgnList;

        public ReportTrailBalance(byte status)
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitData(status);
            InitText(status);
            new ClsReportHeaderData(this);
        }

        private void InitText(byte status)
        {
            if (status == 1)
                this.xrLabel1.Text = (!MySetting.GetPrivateSetting.LangEng) ? "تقرير الميزانيه العموميه" : "Balance Sheet Report";
            else if (status == 3)
                this.xrLabel1.Text = (!MySetting.GetPrivateSetting.LangEng) ? "تقرير حساب الأرباح والخسائر" : "Profit Loss Report";
        }

        private void InitData(byte status)
        {
            this.tbAccountList = (status == 1) ? this.clsTbAccount.GetAccountListCategoery1nd2() : this.clsTbAccount.GetAccountListCategoery3nd4();
            this.tbAccountFrgnList = new ClsTblAssetFrgn().GetAssetFrgnList;
        }

        private void InitData(byte status1, byte status2)
        {
            this.db.tblAccounts.Load();
            this.db.tblAssetFrgns.Load();
            var tbAccount = (from a in this.db.tblAccounts.Local
                             where a.accType == 2 && (a.accCat == status1 || a.accCat == status2)
                             select a).ToList();
            var tbAssetFrgn = (from a in this.db.tblAssetFrgns.Local
                               where a.asBrnId == Session.CurBranch.brnId
                               select a).ToList();
            var tbAsset = new ClsTblAsset().GetAssetList;

            long debit, credit, total;
            bool isFound;

            foreach (var tAccount in tbAccount)
            {
                debit = 0;
                credit = 0;
                total = 0;
                isFound = false;

                foreach (var tAsset in tbAsset)
                {
                    if (tAsset.asAccNo == tAccount.accNo)
                    {
                        if (tAsset.asDebit > 0)
                            debit += Convert.ToInt64(tAsset.asDebit);
                        else if (tAsset.asCredit > 0)
                            credit += Convert.ToInt64(tAsset.asCredit);

                        isFound = true;
                    }

                }
                foreach (var tAssetFrgn in tbAssetFrgn)
                {
                    if (tAssetFrgn.asAccNo == tAccount.accNo)
                    {
                        debit += Convert.ToInt32(tAssetFrgn.asDebit);
                        credit += Convert.ToInt32(tAssetFrgn.asCredit);
                        isFound = true;
                    }
                }
                if (isFound)
                {
                    ClsTrailBalanceFlds trailBalance = new ClsTrailBalanceFlds();

                    trailBalance.accNo = tAccount.accNo;
                    trailBalance.accName = tAccount.accName;
                    trailBalance.debit = debit;
                    trailBalance.credit = credit;

                    if (status1 == 1)
                    {
                        total = debit - credit;
                        if (total > 0)
                            trailBalance.totalDebit = total;
                        else
                            trailBalance.totalCredit = -(total);
                    }
                    else
                    {
                        total = credit - debit;
                        if (total > 0)
                            trailBalance.totalCredit = total;
                        else
                            trailBalance.totalDebit = -(total);
                    }

                    this.bindingSource1.Add(trailBalance);
                }
            }
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
