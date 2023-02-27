using System;

namespace AccountingMS
{
    public partial class ReportEmpVchrExtraDetail : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblEntrySub clsTbEntrySub;

        private int empId;
        private DateTime dtStart, dtEnd;

        public ReportEmpVchrExtraDetail(ClsTblEntrySub clsTbEntrySub)
        {
            InitializeComponent();
            this.clsTbEntrySub = clsTbEntrySub;
            this.BeforePrint += ReportEmpVchrExtraDetail_BeforePrint;
        }

        private void ReportEmpVchrExtraDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.empId = Convert.ToInt32(parameterEmpId.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);
            this.DataSource = this.clsTbEntrySub.GetEntrySubListByCustNoDtStartNdDtEnd(this.empId, this.dtStart, this.dtEnd);
        }
    }
}
