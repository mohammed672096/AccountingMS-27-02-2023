using DevExpress.XtraReports.UI;
using System;

namespace AccountingMS
{
    public partial class ReportProductsData : XtraReport
    {
        ClsTblStore clsTbStore = new ClsTblStore();
        ClsTblGroupStr clsTbGroupStr = new ClsTblGroupStr();
        ClsTblProductData clsPrdData = new ClsTblProductData();

        public ReportProductsData()
        {
            InitializeComponent();
            InitData();

            xrtcStoreNo.BeforePrint += XrtcStoreNo_BeforePrint;
            xrtcGroupNo.BeforePrint += XrtcGroupNo_BeforePrint;
            xrtcQuantity.BeforePrint += XrtcQuantity_BeforePrint;
            xrtcBarcode1.BeforePrint += XrtcBarcode1_BeforePrint;
            xrtcBarcode2.BeforePrint += XrtcBarcode2_BeforePrint;
            xrtcBarcode3.BeforePrint += XrtcBarcode3_BeforePrint;
        }

        private void InitData()
        {
            new ClsReportHeaderData(this);
            tblProductDataBindingSource.DataSource = this.clsPrdData.GetProductDataList;
        }

        private void XrtcQuantity_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int quant1 = Convert.ToInt32(GetCurrentColumnValue("prdQuantity")), quant2 = Convert.ToInt32(GetCurrentColumnValue("prdSubQuantity")), quant3 = Convert.ToInt32(GetCurrentColumnValue("prdSubQuantity3"));
            string msurName1 = Convert.ToString(GetCurrentColumnValue("ppmMsurName1")), msurName2 = Convert.ToString(GetCurrentColumnValue("ppmMsurName2")), msurName3 = Convert.ToString(GetCurrentColumnValue("ppmMsurName3"));

            xrtcQuantity.Text = null;
            xrtcQuantity.Text = $"{quant1:#,#} {msurName1}";
            if (!string.IsNullOrEmpty(msurName2)) xrtcQuantity.Text += $" - {quant2:#,#} {msurName2}";
            if (!string.IsNullOrEmpty(msurName3)) xrtcQuantity.Text += $" - {quant3:#,#} {msurName3}";
        }

        private void XrtcBarcode1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearXrtcBarcodeText(xrtcBarcode1);
            InitBarcodeData(xrtcBarcode1, "ppmBarcode11", "ppmBarcode12", "ppmBarcode13");
        }

        private void XrtcBarcode2_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearXrtcBarcodeText(xrtcBarcode2);
            InitBarcodeData(xrtcBarcode2, "ppmBarcode21", "ppmBarcode22", "ppmBarcode23");
        }

        private void XrtcBarcode3_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClearXrtcBarcodeText(xrtcBarcode3);
            InitBarcodeData(xrtcBarcode3, "ppmBarcode31", "ppmBarcode32", "ppmBarcode33");
        }

        private void XrtcStoreNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbStore.GetStoreNameByNo(Convert.ToInt32(cell.Value));
        }

        private void XrtcGroupNo_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbGroupStr.GetGroupNameById(Convert.ToInt32(cell.Value));
        }

        private void InitBarcodeData(XRTableCell xrtcBarcode, string colBarcode1, string colBarcode2, string colBarcode3)
        {
            string barcode1 = Convert.ToString(GetCurrentColumnValue(colBarcode1)), barcode2 = Convert.ToString(GetCurrentColumnValue(colBarcode2)), barcode3 = Convert.ToString(GetCurrentColumnValue(colBarcode3));

            if (!string.IsNullOrEmpty(barcode1)) xrtcBarcode.Text = barcode1;
            if (!string.IsNullOrEmpty(barcode2)) xrtcBarcode.Text += $" - {barcode2}";
            if (!string.IsNullOrEmpty(barcode3)) xrtcBarcode.Text += $" - {barcode3}";
        }

        private void ClearXrtcBarcodeText(XRTableCell xrtcBarcode)
        {
            xrtcBarcode.Text = null;
        }
    }
}
