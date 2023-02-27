using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace AccountingMS
{
    public partial class ReportProExpirte : XtraReport
    {
        ClsTblStore clsTbStore = new ClsTblStore();
        ClsTblProduct clsTbProduct = new ClsTblProduct();
        ClsTblPrdPriceMeasurment clsTbPrdMsur = new ClsTblPrdPriceMeasurment();

        public ReportProExpirte(tblPrdexpirateQuanMain tbPrdexpirateQuanMain, IEnumerable<tblPrdExpirateQuan> tbPrdexpirateQuanSubList)
        {
            InitializeComponent();
            InitData(tbPrdexpirateQuanMain, tbPrdexpirateQuanSubList);
            InitDefaultData();
            new ClsReportHeaderData(this);

            GroupHeader1.BeforePrint += GroupHeader1_BeforePrint;
            DetailPrdexpirateSub.BeforePrint += DetailPrdexpirateQuanTransSub_BeforePrint;
        }

        private void InitData(tblPrdexpirateQuanMain tbPrdexpirateQuanMain, IEnumerable<tblPrdExpirateQuan> tbPrdexpirateQuanSubList)
        {
            tblPrdexpirateQuanMainBindingSource.DataSource = tbPrdexpirateQuanMain;
            tblPrdexpirateQuanBindingSource.DataSource = tbPrdexpirateQuanSubList;
            expMainStrid.Text = this.clsTbStore.GetStoreNameById(tbPrdexpirateQuanMain.expMainStrid);
            MainId.Text = tbPrdexpirateQuanMain.expMainId.ToString();
            expMainDate.Text = tbPrdexpirateQuanMain.expMainDate.ToString();
        }

        private void InitDefaultData()
        {
            xrtcDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? $"التاريح : {DateTime.Now:yyyy/MM/dd}" : $"Date : {DateTime.Now:dd/MM/yyyy}";
        }

        private void GroupHeader1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // SetStoreData();
        }

        private void DetailPrdexpirateQuanTransSub_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetProductData(Convert.ToInt32(DetailReport.GetCurrentColumnValue("expPrdId")));
            SetPrdMsurData(Convert.ToInt32(DetailReport.GetCurrentColumnValue("expPrdMsurId")));
        }

        private void SetStoreData()
        {
            string strFrom = this.clsTbStore.GetStoreNameById(Convert.ToInt16(GetCurrentColumnValue("expMainStrid")));
            expMainStrid.Text = strFrom;
        }

        private void SetProductData(int prdId)
        {
            tblProduct tbProduct = this.clsTbProduct.GetPrdObjByPrdId(prdId);
            xrtcPrdNo.Text = tbProduct?.prdNo;
            xrtcPrdName.Text = tbProduct?.prdName;
        }

        private void SetPrdMsurData(int msurId)
        {
            xrtcMsurName.Text = this.clsTbPrdMsur.GetPrdPriceMsurNameById(msurId);
            xrtcBarcode.Text = this.clsTbPrdMsur.GetPrdPriceMsurBarcodeById(msurId);
        }
    }
}
