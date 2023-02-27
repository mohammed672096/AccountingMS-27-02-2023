using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace AccountingMS
{
    public partial class ReportEmpVchrExtra : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblEmployee clsTbEmployee;
        ClsTblEntrySub clsTbEntrySub;
        IList<tblEmployee> tbEmployeeList;

        private ReportType reportType;
        private DateTime dtStart, dtEnd;
        private EntryType entryType1, entryType2;
        private bool isGroupUnion;

        public ReportEmpVchrExtra(ReportType reportType)
        {
            InitializeComponent();
            InitReportType(reportType);
            InitObjects();
            InitDefaultData();
            InitSubReport();

            this.ParametersRequestSubmit += ReportEmpVchrExtra_ParametersRequestSubmit;
        }

        private void InitObjects()
        {
            this.clsTbEmployee = new ClsTblEmployee();
            this.clsTbEntrySub = new ClsTblEntrySub(this.entryType1, this.entryType2);
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            tblEmployeeParmBindingSource.DataSource = this.clsTbEmployee.GetEmployeeList;
            //parameterDtStart.Value = DateTime.Now;
            parameterDtStart.Value = Session.CurrentYear.fyDateStart;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;

            xrlHeader.Text += ClsEntryStatus.GetString((byte)this.entryType1);
            xrtcReportType.Text += ClsEntryStatus.GetString((byte)this.entryType1);
            xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void InitSubReport()
        {
            xrSubRprtEmpVchrExtraDetail.ReportSource = new ReportEmpVchrExtraDetail(this.clsTbEntrySub); ;
            xrSubRprtEmpVchrExtraDetail.ParameterBindings.Add(new ParameterBinding("parameterEmpId", tblEmployeeBindingSource, "id"));
            xrSubRprtEmpVchrExtraDetail.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubRprtEmpVchrExtraDetail.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
        }

        private void ReportEmpVchrExtra_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);
            this.isGroupUnion = Convert.ToBoolean(parameterGroup.Value);

            InitData();
            SetGroupUnion();
            SetBandVisibility();
        }

        private void InitData()
        {
            this.tbEmployeeList = new List<tblEmployee>();

            foreach (var empId in (int[])parameterEmployee.Value)
                if (this.clsTbEntrySub.IsCustNoFoundByDtStartNdEnd(empId, this.dtStart, this.dtEnd))
                    this.tbEmployeeList.Add(this.clsTbEmployee.GetEmployeeObjById(empId));

            tblEmployeeBindingSource.DataSource = this.tbEmployeeList;
        }

        private void SetGroupUnion()
        {
            Detail.PageBreak = (this.isGroupUnion) ? PageBreak.None : PageBreak.AfterBand;
        }

        private void SetBandVisibility()
        {
            Detail.Visible = (this.tbEmployeeList.Count > 0) ? true : false;
        }

        private void InitReportType(ReportType reportType)
        {
            this.reportType = reportType;
            this.entryType1 = (this.reportType == ReportType.EmpVchrTip) ? EntryType.EmpVoucherTip : EntryType.EmpVoucherOvrTm;
            this.entryType2 = (this.reportType == ReportType.EmpVchrTip) ? EntryType.EmpVoucherTipPhased : EntryType.EmpVoucherOvrTmPhased;
        }
    }
}
