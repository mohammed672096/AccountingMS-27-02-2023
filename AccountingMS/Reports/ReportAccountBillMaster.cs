using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportAccountBillMaster : XtraReport
    {
        ClsTblAsset clsTbAsset;
        ClsTblAccount clsTbAccount;
        ClsTblCurrency clsTbCurrency;
        ReportAccountBillDetail rprtAccBillDetail;
        ClsGridLookupEdit clsGridEdit;
        IList<tblAccount> tbAccountList = new List<tblAccount>();

        public ReportAccountBillMaster()
        {
            SetLanguage();
            InitializeComponent();
            SetRTL();
            InitDefaultData();
            InitClsGridLookUpEdit();

            this.ParametersRequestBeforeShow += ReportAccountBillMaster_ParametersRequestBeforeShow;
        }

        public static async Task<ReportAccountBillMaster> CreateAsync()
        {
            var rprt = new ReportAccountBillMaster();

            await rprt.InitObjectsAsync();

            rprt.InitObjectsData();
            rprt.InitSubReport();

            return rprt;
        }

        public async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbAsset = new ClsTblAsset(0)));
            taskList.Add(Task.Run(() => this.clsTbAccount = new ClsTblAccount()));
            taskList.Add(Task.Run(() => this.clsTbCurrency = new ClsTblCurrency()));

            await Task.WhenAll(taskList);
        }

        private void InitObjectsData()
        {
            tblAccountParmBindingSource.DataSource = this.clsTbAccount.GetAccountListType2();
        }

        private void InitSubReport()
        {
            this.rprtAccBillDetail = new ReportAccountBillDetail(this.clsTbAsset);
            xrSubRprt.ReportSource = this.rprtAccBillDetail;

            xrSubRprt.ParameterBindings.Add(new ParameterBinding("parameterAccNo", tblAccountBindingSource, "accNo"));
            xrSubRprt.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubRprt.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            parameterDtStart.Value = DateTime.Now;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrtcDate.Text += string.Format((!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd hh:mm tt}" : $"{DateTime.Now:hh:mm tt dd/MM/yyyy}");
        }

        private void InitClsGridLookUpEdit()
        {
            IList<GridColumn> gridColumnList = new List<GridColumn> {
                new GridColumn() { FieldName = "accNo", Caption = "رقم الحساب" },
                new GridColumn() { FieldName = "accName", Caption = "إسم الحساب" }
            };

            this.clsGridEdit = new ClsGridLookupEdit(gridColumnList, tblAccountParmBindingSource);

            this.clsGridEdit.gridEdit.Closed += GridEdit_Closed;
            this.clsGridEdit.gridView.SelectionChanged += GridView_SelectionChanged;
        }

        private void GridEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (this.tbAccountList.Count == 0) return;
            this.clsGridEdit.gridEdit.EditValue = string.Join(", ", this.tbAccountList.Select(x => x.accName).ToList());
        }

        private void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView;

            this.tbAccountList = new List<tblAccount>();

            foreach (var row in view.GetSelectedRows())
                this.tbAccountList.Add(view.GetRow(row) as tblAccount);
        }

        private void ReportAccountBillMaster_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (var info in e.ParametersInformation)
                if (info.Parameter.Name == parameterAccNo.Name)
                    info.Editor = this.clsGridEdit.gridEdit;
        }

        private void ReportAccountBill_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            InitData();
            SetGroupRcrds();
        }

        private void InitData()
        {
            tblAccountBindingSource.DataSource = this.tbAccountList;
            //IList<tblAccount> tbAccountList = new List<tblAccount>();

            //foreach (long accNo in (long[])parameterAccNo.Value) 
            //    tbAccountList.Add(this.clsTbAccount.GetAccountObjByNo(accNo));


            //tblAccountBindingSource.DataSource = tbAccountList;
        }

        private void SetGroupRcrds()
        {
            this.Detail.PageBreak = Convert.ToBoolean(parameterGroupRcrds.Value) ? PageBreak.None : PageBreak.AfterBand;
        }

        private void XrTableCell19_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = this.clsTbCurrency.GetCurrencyNameById(Convert.ToByte(cell.Value));
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

            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = RightToLeftLayout.No;
        }
    }
}
