using DevExpress.XtraReports.UI;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportEntry : XtraReport
    {
        public ReportEntry()
        {
            SetLanguage();
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            SetRTL();
            new ClsReportHeaderData(this);
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
            if (MySetting.GetPrivateSetting.LangEng)
            {

                this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }

        public void EntMainData(ArrayList list)
        {
            ClsRprtEntryData tbEntryMain = new ClsRprtEntryData();
            ClsRprtEntryData entry = new ClsRprtEntryData();
            entry = (ClsRprtEntryData)list[0];

            tbEntryMain.entNo = entry.entNo;
            tbEntryMain.entDesc = entry.entDesc;
            tbEntryMain.entAmount = entry.entAmount;
            tbEntryMain.entRefNo = entry.entRefNo;
            tbEntryMain.entDate = entry.entDate;
            tbEntryMain.entType = entry.entType;
            tbEntryMain.entReverseConstraint = entry.entReverseConstraint;
            tbEntryMain.entReverseConstraintDate = entry.entReverseConstraintDate;


            bindingSource1.Add(tbEntryMain);
            list.Clear();
        }

        public void EntSubData(ArrayList list)
        {
            ClsEntryList entry = new ClsEntryList();
            ClsTblCurrency curData = new ClsTblCurrency();

            for (short i = 0; i < list.Count; i++)
            {
                tblEntrySub tbEntrySub = new tblEntrySub();
                entry = (ClsEntryList)list[i];

                tbEntrySub.id = entry.id;
                tbEntrySub.entAccNo = entry.accNo;
                tbEntrySub.entAccName = entry.accName;
                tbEntrySub.entDesc = entry.desc;
                tbEntrySub.entDebit = entry.debit;
                tbEntrySub.entCredit = entry.credit;
                tbEntrySub.entDebitFrgn = entry.debitFrgn;
                tbEntrySub.entCreditFrgn = entry.creditFrgn;
                tbEntrySub.entCusName = entry.cusName;
                tbEntrySub.entTaxNumber = entry.entTaxNumber;
                tbEntrySub.invoNum = entry.invoNum;
                bindingSource2.Add(tbEntrySub);
            }
            list.Clear();
        }

    }
}
