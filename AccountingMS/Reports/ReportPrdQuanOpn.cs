using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportPrdQuanOpn : XtraReport
    {
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblProductQtyOpn clsTbPrdQuanOpn;

        private ReportPrdQuanOpn()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();
            InitDefaultData();

        }
        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
        }

        public static async Task<ReportPrdQuanOpn> CreateAsync()
        {
            var rprt = new ReportPrdQuanOpn();

            await rprt.InitObjectsAsync();
            await rprt.InitDataAsync();

            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdQuanOpn = new ClsTblProductQtyOpn()));

            await Task.WhenAll(taskList);
        }

        private async Task InitDataAsync()
        {
            var tbPrdQuanOpnList = await Task.Run(() => this.clsTbPrdQuanOpn.GetProductQtyOpnList.Select(x => new tblProductQtyOpn()
            {
                qtyPrdId = x.qtyPrdId,
                qtyPrdMsurId = x.qtyPrdMsurId,
                qtyPrice = x.qtyPrice,
                qtyQuantity = x.qtyQuantity,
                qtyDate = x.qtyDate,
                prdSalePrice = this.clsTbPrdMsur.GetPrdPriceMsurMinSalePrice(x.qtyPrdMsurId),
            }).ToList());

            tblPrdQuanOpnBindingSource.DataSource = tbPrdQuanOpnList;
        }

        private void xrtcPrdId_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbProduct.GetPrdNameById(Convert.ToInt32(cell.Value));
        }

        private void xrtcPrdMsurId_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            cell.Text = this.clsTbPrdMsur.GetPrdPriceMsurNameById(Convert.ToInt32(cell.Value));
        }
    }
}
