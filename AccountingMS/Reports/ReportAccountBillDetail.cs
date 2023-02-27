using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportAccountBillDetail : XtraReport
    {
        ClsTblAsset clsTbAsset;

        private long accNo;
        private DateTime dtStart, dtEnd;

        public ReportAccountBillDetail(ClsTblAsset clsTbAsset)
        {
            InitializeComponent();
            InitObjects(clsTbAsset);

            this.BeforePrint += ReportAccountBillDetail_BeforePrint;

            xrtcEntNo.BeforePrint += XrtcEntNo_BeforePrint;
            xrtcEntStatus.BeforePrint += XrtcEntStatus_BeforePrint;

            GroupFooter1.BeforePrint += GroupFooter1_BeforePrint;
        }

        private void InitObjects(ClsTblAsset clsTbAsset)
        {
            this.clsTbAsset = clsTbAsset;
        }

        private void ReportAccountBillDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.accNo = Convert.ToInt64(parameterAccNo.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            InitData();
            SetVisibility();
        }

        private void InitData()
        {
            this.tblAssetBindingSource.DataSource = this.clsTbAsset.GetAssetsByAccNoNdDtStartEnd(this.accNo, this.dtStart, this.dtEnd);
            //  this.tblAssetBindingSource.DataSource = this.clsTbAsset.GetAssetListByAccNoNdDtStartEnd(this.accNo, this.dtStart, this.dtEnd);
        }

        private void SetVisibility()
        {
            this.Visible = tblAssetBindingSource.Count > 0 ? true : false;
        }

        private void XrtcEntNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null && Convert.ToInt32(cell.Value) == 0) cell.Text = null;
        }

        private void XrtcEntStatus_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null) cell.Text = ClsAssetStatus.GetString((AssetType)Convert.ToByte(cell.Value));
        }

        private void GroupFooter1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal totalDebit = Convert.ToDecimal(xrtcTotalDebit.Summary.GetResult()), totalCredit = Convert.ToDecimal(xrtcTotalCredit.Summary.GetResult());

            if (totalDebit > totalCredit) SetTotal(totalDebit, totalCredit, "مدين");
            else if (totalCredit > totalDebit) SetTotal(totalCredit, totalDebit, "دائن");
            else SetTotal(0, 0, null);
        }

        private void SetTotal(decimal total1, decimal total2, string text)
        {
            xrtcTotal.Text = $"{total1 - total2:n2}";
            xrtcTotalStr.Text = text;
            //this.accNo = Convert.ToInt64(parameterAccNo.Value);
            //var AccountBalance = new ClsTblAccount.AccountBalance(accNo);

            //xrtcTotal.Text = AccountBalance.Balance.ToString("n2");
            //xrtcTotalStr.Text = AccountBalance.Type;
        }

    }
}