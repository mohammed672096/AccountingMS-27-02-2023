using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace AccountingMS
{
    public partial class ReportOrders : XtraReport
    {
        ClsTblOrderMain clsTbOrderMain;
        ReportOrdersMaster rprtOrdersMaster;
        IList<tblOrderType> tbOrderTypeList;

        private DateTime dtStart, dtEnd;

        public ReportOrders()
        {
            InitializeComponent();
            InitObjects();
            InitSubReport();
            InitDefaultData();

            this.ParametersRequestSubmit += ReportOrders_ParametersRequestSubmit;
        }

        private void InitObjects()
        {
            this.clsTbOrderMain = new ClsTblOrderMain();
            tblOrderTypeBindingSourceParameter.DataSource = tblOrderType.GetData();

        }

        private void InitSubReport()
        {
            this.rprtOrdersMaster = new ReportOrdersMaster(this.clsTbOrderMain);
            xrSubreportOrderaMaster.ReportSource = this.rprtOrdersMaster;
            xrSubreportOrderaMaster.ParameterBindings.Add(new ParameterBinding("parameterOrderType", tblOrderTypeBindingSource, "ordStatus"));
            xrSubreportOrderaMaster.ParameterBindings.Add(new ParameterBinding("parameterDtStart", parameterDtStart));
            xrSubreportOrderaMaster.ParameterBindings.Add(new ParameterBinding("parameterDtEnd", parameterDtEnd));
            xrSubreportOrderaMaster.ParameterBindings.Add(new ParameterBinding("parameterOrderDetail", parameterOrderDetail));
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            parameterDtStart.Value = DateTime.Now.Date;
            parameterDtEnd.Value = Session.CurrentYear.fyDateEnd;
            xrlDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void ReportOrders_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.dtStart = Convert.ToDateTime(parameterDtStart.Value).Date;
            this.dtEnd = ClsDateConverter.ConvertTime(parameterDtEnd.Value);

            InitData();
            SetDetailVisibility();
        }

        private void InitData()
        {
            this.tbOrderTypeList = new List<tblOrderType>();
            foreach (var orderId in (short[])parameterOrderType.Value)
                if (this.clsTbOrderMain.IsInvoicesFound((byte)orderId, this.dtStart, this.dtEnd))
                    this.tbOrderTypeList.Add(new tblOrderType() { ordStatus = (byte)orderId, ordCaption = ClsOrderStatus.GetStringPlural((byte)orderId) });

            tblOrderTypeBindingSource.DataSource = this.tbOrderTypeList;
        }

        private void SetDetailVisibility()
        {
            Detail.Visible = (tblOrderTypeBindingSource.Count > 0) ? true : false;
        }
    }
}
