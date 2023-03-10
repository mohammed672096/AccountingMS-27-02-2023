using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSaleGroupDetail : XtraReport
    {
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();
        ClsTblBarcode clsTblBarcode = new ClsTblBarcode();
        IEnumerable<tblPrdSaleDetail> tbPrdSaleDetailList;

        private long grpAccNo;

        public ReportSaleGroupDetail()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterGrpAccNo.Description = "Group:";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            this.BeforePrint += ReportSaleGroupDetail_BeforePrint;
        }

        private void ReportSaleGroupDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grpAccNo = Convert.ToInt64(parameterGrpAccNo.Value);
            this.tbPrdSaleDetailList = this.DataSource as IEnumerable<tblPrdSaleDetail>;

            InitData();
            SetReportVisibility();
        }

        private void InitData()
        {
            this.tbPrdSaleDetailList = this.tbPrdSaleDetailList.Where(x => x.grpAccNo == this.grpAccNo);
            this.DataSource = this.tbPrdSaleDetailList;
        }

        private void SetReportVisibility()
        {
            this.Visible = (this.tbPrdSaleDetailList.Count() >= 1) ? true : false;
        }

        private void XrtcPrdQuantString_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = $"{GetCurrentColumnValue("prdQuant")} {this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(GetCurrentColumnValue("prdMsur")))}";
        }

        private void xrTableCell13_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = $"{this.clsTblBarcode.GetBarcodeListByPrdMsurId(Convert.ToInt32(GetCurrentColumnValue("prdMsur"))).FirstOrDefault()?.brcNo}";

        }
    }
}