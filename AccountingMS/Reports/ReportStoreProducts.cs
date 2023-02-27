using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportStoreProducts : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblStore clsTbStore;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblProductQunatity clsTbPrdQuan;

        private short strId;

        private ReportStoreProducts()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterStore.Description = "Stores:";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            this.ParametersRequestSubmit += ReportStoreProducts_ParametersRequestSubmit;
        }

        public static async Task<ReportStoreProducts> CreateAsync()
        {
            var rprt = new ReportStoreProducts();

            await rprt.InitDataAsync();
            await Task.Run(() => rprt.InitDefaultData());

            return rprt;
        }

        private async Task InitDataAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdQuan = new ClsTblProductQunatity()));

            await Task.WhenAll(taskList);
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }

        private void ReportStoreProducts_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            this.strId = Convert.ToInt16(parameterStore.Value);

            InitData();
            SetText();
            SetBandVisibility();
        }

        private void InitData()
        {
            var tbProductList = (from prdQuan in this.clsTbPrdQuan.GetPrdQuantityListReportStore
                                 where prdQuan.prdStrId == this.strId && prdQuan.prdStatus != 2
                                 join prd in this.clsTbProduct.GetProductList on prdQuan.prdId equals prd.id
                                 join prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList on prdQuan.prdId equals prdMsur.ppmPrdId into prdMsurGrp
                                 where (prdQuan.prdQuantity != 0 | prdQuan.prdSubQuantity != 0 | prdQuan.prdSubQuantity3 != 0)
                                 select new tblPrdQuanPr
                                 {
                                     prdNo = prd.prdNo,
                                     prdName = prd.prdName,
                                     prdNQuan = (prdMsurGrp.Count()) switch
                                     {
                                         1 => $"{prdQuan.prdQuantity} ({prdMsurGrp.ElementAt(0).ppmMsurName})",
                                         2 => $"{prdQuan.prdQuantity} ({prdMsurGrp.ElementAt(0).ppmMsurName}) | {prdQuan.prdSubQuantity} ({prdMsurGrp.ElementAt(1).ppmMsurName})",
                                         3 => $"{prdQuan.prdQuantity} ({prdMsurGrp.ElementAt(0).ppmMsurName}) | {prdQuan.prdSubQuantity} ({prdMsurGrp.ElementAt(1).ppmMsurName}) | {prdQuan.prdSubQuantity} ({prdMsurGrp.ElementAt(2).ppmMsurName})",
                                         _ => null
                                     }
                                 }).ToList();

            tblPrdQuanBindingSource.DataSource = tbProductList;
        }

        private void SetText()
        {
            xrtcStore.Text = this.clsTbStore.GetStoreNameById(this.strId);
        }

        private void SetBandVisibility()
        {
            bool isVisible = (tblPrdQuanBindingSource.Count >= 1) ? true : false;

            GroupHeader1.Visible = isVisible;
            Detail.Visible = isVisible;
            GroupFooter1.Visible = isVisible;
        }
    }
}
