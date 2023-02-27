using DevExpress.XtraReports.UI;
using System;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportOrdersMaster : XtraReport
    {
        ClsTblOrderMain clsTbOrderMain;
        ReportOrdersDetail rprtOrdersDetail;
        GroupField groupFiled;

        private byte orderType;
        private bool orderDetail;
        private DateTime dtStart, dtEnd;

        public ReportOrdersMaster(ClsTblOrderMain clsTbOrderMain)
        {
            InitializeComponent();
            InitObjects(clsTbOrderMain);
            InitSubReport();
            InitDefaultData();

            this.BeforePrint += ReportOrdersMaster_BeforePrint;
        }

        private void InitObjects(ClsTblOrderMain clsTbOrderMain)
        {
            this.clsTbOrderMain = clsTbOrderMain;
        }

        private void InitDefaultData()
        {
            this.groupFiled = new GroupField("ordNo", XRColumnSortOrder.None);
        }

        private void InitSubReport()
        {
            this.rprtOrdersDetail = new ReportOrdersDetail();
            xrSubreportOrderDetail.ReportSource = this.rprtOrdersDetail;
            xrSubreportOrderDetail.ParameterBindings.Add(new ParameterBinding("parameterOrderMainId", tblOrderMainBindingSource, "ordId"));
            xrSubreportOrderDetail.ParameterBindings.Add(new ParameterBinding("parameterOrderDetail", parameterOrderDetail));

        }

        private void ReportOrdersMaster_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.orderType = Convert.ToByte(parameterOrderType.Value);
            this.orderDetail = Convert.ToBoolean(parameterOrderDetail.Value);
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            InitData();
            SetSubReport();
            SetTableStyle();
            SetRepeatGroupHeader();
        }

        private void InitData()
        {
            tblOrderMainBindingSource.DataSource = this.clsTbOrderMain.GetOrderListByStatusNdDtStartEnd(this.orderType, this.dtStart, this.dtEnd);
        }

        private void SetSubReport()
        {
            this.xrSubreportOrderDetail.Visible = this.orderDetail;
            this.xrSubreportOrderDetail.ReportSource = (this.orderDetail) ? this.rprtOrdersDetail : null;
        }

        private void SetTableStyle()
        {
            SetTableBorders();
            xrTable1.StyleName = (!this.orderDetail) ? "HeaderStyle" : "HeaderDetailStyle";
            xrTable2.StyleName = (!this.orderDetail) ? null : "tableDetailStyle";
            xrTable2.OddStyleName = (!this.orderDetail) ? "OddStyle" : null;
            xrTable2.EvenStyleName = (!this.orderDetail) ? "EvenStyle" : null;
        }

        private void SetTableBorders()
        {
            xrtcOrdNoVal.StylePriority.UseBorders = true;
            xrtcOrdDateVal.StylePriority.UseBorders = true;
        }

        private void SetRepeatGroupHeader()
        {
            if (this.orderDetail) GroupHeader1.GroupFields.Add(this.groupFiled);
            else foreach (var groupFiled in GroupHeader1.GroupFields.ToList()) GroupHeader1.GroupFields.Remove(this.groupFiled);
        }
    }
}
