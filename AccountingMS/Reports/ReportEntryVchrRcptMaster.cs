using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportEntryVchrRcptMaster : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblBox clsTbBox;
        ClsTblBank clsTblBank;
        ClsTblEntryMain clsTbEntryMain;
        ReportEntryVchrRcptDetail rprtEntryVchrRcptDetail;

        private ReportType reportType;
        private EntryType entryType1, entryType2;
        private DateTime dtStart, dtEnd;

        public ReportEntryVchrRcptMaster(ReportType reportType)
        {
            this.reportType = reportType;
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterBox.Description = "Box";
                parameterDtStart.Description = "Date From";
                parameterDtEnd.Description = "Date To";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            SetEntryStatus();
            InitDefaultData();
            InitText();
            InitObjects();
            InitBindingSourceData();

            this.ParametersRequestSubmit += ReportEntryVchrRcptInv_ParametersRequestSubmit;
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            parameterDtStart.Value = DateTime.Now;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
        }

        private void InitText()
        {
            xrlHeader.Text += (this.reportType == ReportType.EntryVoucherInv) ? "الصرف" : "القبض";
            xrtcEntryType.Text += (this.reportType == ReportType.EntryVoucherInv) ? "الصرف" : "القبض";
            xrlDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void InitSubReport()
        {
            this.rprtEntryVchrRcptDetail = new ReportEntryVchrRcptDetail(this.clsTbEntryMain);
            xrSubreport.ReportSource = this.rprtEntryVchrRcptDetail;

            xrSubreport.ParameterBindings.Add(new ParameterBinding("parameterBoxNo", tblBoxBindingSource, "boxAccNo"));
            xrSubreport.ParameterBindings.Add(new ParameterBinding("parameterBankNo", tblBankBindingSource, "bankAccNo"));
            xrSubreport.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubreport.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
        }

        private void InitObjects()
        {
            this.clsTbBox = new ClsTblBox();
            clsTblBank = new ClsTblBank();
        }

        public async Task InitRprtAsync()
        {
            await InitObjectsAsync();
            InitSubReport();
        }

        private async Task InitObjectsAsync()
        {
            await Task.Run(() => this.clsTbEntryMain = new ClsTblEntryMain(this.entryType1, this.entryType2));
        }

        private void InitBindingSourceData()
        {
            tblBoxParmBindingSource.DataSource = this.clsTbBox.GetBoxList;
            tblBankParmBindingSource.DataSource = this.clsTblBank.GetTblBankList;
        }

        private void ReportEntryVchrRcptInv_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            InitData();
        }

        private void InitData()
        {
            IList<tblAccountBox> tbBoxList = new List<tblAccountBox>();
           
            foreach (var boxAccNo in (long[])parameterBox.Value)
                if (this.clsTbEntryMain.IsEntryMainFound(boxAccNo, this.dtStart, this.dtEnd))
                    tbBoxList.Add(this.clsTbBox.GetBoxObjByAccNo(boxAccNo));
            tblBoxBindingSource.DataSource = tbBoxList;

            List<tblAccountBank> tbBankList = new List<tblAccountBank>();
            foreach (var BankAccNo in (long[])parameterBank.Value)
                if (this.clsTbEntryMain.IsEntryMainFound(BankAccNo, this.dtStart, this.dtEnd))
                    tbBankList.Add(Session.Banks.FirstOrDefault(x => x.bankAccNo == BankAccNo));
            tblBankBindingSource.DataSource = tbBankList;
        }

        private void SetEntryStatus()
        {
            switch (this.reportType)
            {
                case ReportType.EntryVoucherInv:
                    this.entryType1 = EntryType.EntryVoucher;
                    this.entryType2 = EntryType.EntryVoucherPhased;
                    break;
                case ReportType.EntryReceiptInv:
                    this.entryType1 = EntryType.EntryReceipt;
                    this.entryType2 = EntryType.EntryReceiptPhased;
                    break;
            }
        }
    }
}
