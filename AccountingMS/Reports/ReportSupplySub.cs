using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportSupplySub : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblSupplySub clsTbSupplySub;

        private bool showProfit;

        public ReportSupplySub(ClsTblSupplySub clsTbSupplySub, byte status)
        {
            InitializeComponent();
            InitObjects(clsTbSupplySub);
            SetSuplierPriceBinding(status);

            this.BeforePrint += ReportSupplySub_BeforePrint;
            this.Detail.BeforePrint += Detail_BeforePrint;
        }

        private void InitObjects(ClsTblSupplySub clsTbSupplySub)
        {
            this.clsTbSupplySub = clsTbSupplySub;
        }

        private void SetSuplierPriceBinding(byte status)
        {
            string priceBinding = status == 1 ? "[supSalePrice]" : "[supPrice]";
            ExpressionBinding expBinding = new ExpressionBinding("BeforePrint", "Text", priceBinding);

            xrtcPrice.ExpressionBindings.Add(expBinding);
        }

        private void ReportSupplySub_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.showProfit = Convert.ToBoolean(parameterShowProfit.Value);
            if (IsEntryRecord(Convert.ToByte(parameterSupStatus.Value))) return;

            InitData();
            SwtColumns();
        }

        private bool IsEntryRecord(byte supStatus)
        {
            bool isEntryRecord = (supStatus <= 2) ? true : false;
            this.Visible = !isEntryRecord;
            return isEntryRecord;
        }

        private void InitData()
        {
            tblSupplySubBindingSource.DataSource = this.clsTbSupplySub.GetSupplySubListBySupId(Convert.ToInt32(parameterSupId.Value));
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetProfit();
        }

        private void SwtColumns()
        {
            SetColumns(xrTableRowH, xrtcProfitH);
            SetColumns(xrTableRowV, xrtcProfitV);
        }

        private void SetColumns(XRTableRow xrTableRow, XRTableCell xrtcProfit)
        {
            xrTableRow.DeleteCell(xrtcProfit);
            if (!this.showProfit) return;

            xrTableRow.Cells.Add(xrtcProfit);
        }

        private void SetProfit()
        {
            if (!this.showProfit) return;
            xrtcProfitV.Text = $"{this.clsTbSupplySub.GetSupplySubProfitById(Convert.ToInt32(GetCurrentColumnValue("id"))):n2}";
        }
    }
}
