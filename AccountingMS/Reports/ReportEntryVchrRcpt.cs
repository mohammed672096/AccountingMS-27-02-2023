using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace AccountingMS
{
    public partial class ReportEntryVchrRcpt : XtraReport
    {
        ClsTblCurrency clsTbCurrency = new ClsTblCurrency();

        public ReportEntryVchrRcpt()
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

        public void EntMainData(ArrayList list, bool isRecipt)
        {

            xrTable1.Visible = false;
            xrTable2.Visible = false;
            xrTable3.Visible = true;
            xrTable4.Visible = true;
            if (isRecipt)
            {
                xrLabel2.Visible = false;
                xrLabel5.Visible = false;
                xrLabel1.Visible = true;
                xrLabel3.Visible = true;
                xrLabel7.Visible = true;
                xrLabel13.Visible = false;
                xrLine4.Visible = false;
            }
            ClsRprtEntryData entry = new ClsRprtEntryData();
            entry = (ClsRprtEntryData)list[0];

            ClsRprtEntryData tbEntryMain = new ClsRprtEntryData()
            {
                entNo = entry.entNo,
                boxName = entry.boxName,
                entDesc = entry.entDesc,
                entAmount = entry.entAmount,
                entRefNo = entry.entRefNo,
                entDate = entry.entDate,
                entType = entry.entType
            };
            xrLabel8.Visible = (tbEntryMain.entRefNo == 0) ? false : true;
            bindingSource1.DataSource = tbEntryMain;
            list.Clear();
        }

        public void EntSubData(ArrayList list)
        {
            BindingList<tblEntrySub> tbEntSubList = new BindingList<tblEntrySub>();
            ClsEntryList entry = new ClsEntryList();

            for (short i = 0; i < list.Count; i++)
            {
                tblEntrySub tbEntrySub = new tblEntrySub();
                entry = (ClsEntryList)list[i];

                tbEntrySub.entAccNo = entry.accNo;
                tbEntrySub.entAccName = entry.accName;
                tbEntrySub.entDesc = entry.desc;
                tbEntrySub.entDebit = entry.debit;
                tbEntrySub.entCurrency = entry.curreny;
                Console.WriteLine($"tbEntrySub.entCurrency : {tbEntrySub.entCurrency }, {entry.curreny}");
                tbEntSubList.Add(tbEntrySub);
            }
            list.Clear();
            bindingSource2.DataSource = tbEntSubList;
        }

        public void EntMainEmpVchr(tblEntryMain tbEntMain)
        {
            xrLabel2.Visible = false;
            xrLabel5.Visible = false;
            xrLabel8.Visible = false;
            xrLabel13.Visible = false;
            xrLine4.Visible = false;
            xrLabel17.Visible = true;
            xrLabel19.Visible = true;
            xrLabel20.Visible = true;
            xrLabel21.Visible = true;
            xrLabel20.Text = new ClsTblBox().GetBoxNameByNo(Convert.ToInt32(tbEntMain.entBoxNo));
            bindingSource1.DataSource = tbEntMain;
        }

        public void EntSubEmpVchr(BindingList<tblEntrySub> tbEntSubList)
        {
            bindingSource2.DataSource = tbEntSubList;
        }

        private void SetLanguage()
        {
            if (!MySetting.GetPrivateSetting.LangEng)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        }

        private void xrtcCurrency_BeforePrint(object sender, CancelEventArgs e)
        {
            xrtcCurrency.Text = this.clsTbCurrency.GetCurrencySignById(Convert.ToByte(DetailReport.GetCurrentColumnValue("entCurrency")));
        }
        private void xrtcCurrency1_BeforePrint(object sender, CancelEventArgs e)
        {
            xrtcCurrency1.Text = this.clsTbCurrency.GetCurrencySignById(Convert.ToByte(DetailReport.GetCurrentColumnValue("entCurrency")));
        }

        private void SetRTL()
        {
            if (!MySetting.GetPrivateSetting.LangEng) return;

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
