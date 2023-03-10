using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportProductQuanPrice : XtraReport
    {
        ClsTblGroupStr clsTbGroup;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblProductQunatity clsTbPrdQuan;
        ClsTblPrdPriceQuan clsTbPrdPriceQuan;
        ClsTblBarcode clsTblBarcode = new ClsTblBarcode();
        ReportProductQuanPriceD rprtPrdQuanDetail;

        private ReportProductQuanPrice()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                parameterGrp.Description = "Group:";
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
            InitDefaultData();
            InitSubReport();

            this.ParametersRequestSubmit += ReportProductQuan_ParametersRequestSubmit;
            xrSubRprtPrdQuanDetail.BeforePrint += XrSubRprtPrdQuanDetail_BeforePrint;
        }

        public static async Task<ReportProductQuanPrice> CreateAsync()
        {
            var rprt = new ReportProductQuanPrice();

            List<Task> taskList = new List<Task>()
            {
                Task.Run(() => rprt.InitDataAsync()),
                //Task.Run(() => new ClsResetPrdQuan().ResetQuan())
            };
            await Task.WhenAll(taskList);

            //await new ClsResetPrdPriceQuan().ResetPriceQuan();

            taskList = new List<Task>()
            {
                Task.Run(() => rprt.clsTbPrdQuan = new ClsTblProductQunatity()),
                Task.Run(() => rprt.clsTbPrdPriceQuan = new ClsTblPrdPriceQuan())
            };
            await Task.WhenAll(taskList);

            return rprt;
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
        }

        private void InitSubReport()
        {
            this.rprtPrdQuanDetail = new ReportProductQuanPriceD();
            xrSubRprtPrdQuanDetail.ReportSource = this.rprtPrdQuanDetail;
            xrSubRprtPrdQuanDetail.ParameterBindings.Add(new ParameterBinding("parameterGrp", tblGroupStrBindingSource, "id"));
        }

        public async Task InitDataAsync()
        {
            await InitObjectsAsync();
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>
            {
                Task.Run(() => this.clsTbGroup = new ClsTblGroupStr()),
                Task.Run(() => this.clsTbProduct = new ClsTblProduct()),
                Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()),
            };

            await Task.WhenAll(taskList);

            tblGroupStrParmBindingSource.DataSource = this.clsTbGroup.GetGroupList;
        }

        private void ReportProductQuan_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            IList<tblGroupStr> tbGroupList = new List<tblGroupStr>();
            foreach (var grpId in parameterGrp.Value as Int32[])
                if (InitQuery(grpId).Count > 0)
                    tbGroupList.Add(this.clsTbGroup.GetGroupObjById(grpId));

            tblGroupStrBindingSource.DataSource = tbGroupList;
        }

        private void XrSubRprtPrdQuanDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.rprtPrdQuanDetail.DataSource = InitQuery(Convert.ToInt32(GetCurrentColumnValue("id")));
        }

        private IList<tblPrdQuanPrDetailted> InitQuery(int grpId)
        {
            var tbPrdQuanPrList = (from prdQuan in this.clsTbPrdQuan.GetPrdQuantityList
                                   where prdQuan.prdQuantity != 0 || prdQuan.prdSubQuantity != 0 || prdQuan.prdSubQuantity3 != 0
                                   group prdQuan by prdQuan.prdId into prdQuanGrp
                                   join product in this.clsTbProduct.GetProductList on prdQuanGrp.Key equals product.id
                                   where product.prdGrpNo == grpId
                                   select new
                                   {
                                       prd = product,
                                       prdId = prdQuanGrp.Key,
                                       prdQuan1 = prdQuanGrp.Sum(x => Convert.ToDouble(x.prdQuantity)),
                                       prdQuan2 = prdQuanGrp.Sum(x => Convert.ToDouble(x.prdSubQuantity)),
                                       prdQuan3 = prdQuanGrp.Sum(x => Convert.ToDouble(x.prdSubQuantity3)),
                                   }).ToList();

            var tbPrdQuanPrList3 = (from prdQuan in tbPrdQuanPrList
                                    join prdPrQuan in this.clsTbPrdPriceQuan.GetPrdPiceQuanList on prdQuan.prd.id equals prdPrQuan.prPrdId into prdPrQuan
                                    join prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList on prdQuan.prd.id equals prdMsur.ppmPrdId into prdMsurGrp
                                    select new tblPrdQuanPrDetailted()
                                    {
                                        prdId = prdQuan.prd.id,
                                        prdNo = prdQuan.prd.prdNo,

                                        //   Barcode = prdMsurGrp.Select(x=>(string?) x.ppmBarcode1) .FirstOrDefault()??"" ,
                                        Barcode = this.clsTblBarcode.GetBarcodeObjByPrdMsurId(prdMsurGrp.FirstOrDefault()?.ppmId ?? 0)?.brcNo,

                                        prdName = prdQuan.prd.prdName,
                                        prdTotalPrice = prdPrQuan.Sum(x => (x.pr1 * Convert.ToDouble(x.prQuantity1)) +
                                            (x.pr2 * Convert.ToDouble(x.prQuantity2)) + (x.pr3 * Convert.ToDouble(x.prQuantity3))),
                                        prdAveTotalPrice = prdPrQuan.Sum(x => (x.pr1 * Convert.ToDouble(x.prQuantity1)) +
                                              (x.pr2 * Convert.ToDouble(x.prQuantity2)) + (x.pr3 * Convert.ToDouble(x.prQuantity3))) /
                                             (prdQuan.prdQuan1 + prdQuan.prdQuan2 + prdQuan.prdQuan3),
                                        //prdTotalSalePrice = (prdMsurGrp.Count()) switch
                                        //{
                                        //    1 => prdQuan.prdQuan1 * Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(0) ?? 0),
                                        //    2 => (prdQuan.prdQuan1 * Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(0) ?? 0)) + (prdQuan.prdQuan2 * Convert.ToDouble(Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(1) ?? 0))),
                                        //    3 => (prdQuan.prdQuan1 * Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(0) ?? 0) + (prdQuan.prdQuan2 * Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(1) ?? 0)) + (prdQuan.prdQuan3 * Convert.ToDouble(prdMsurGrp.Select(x => x.ppmSalePrice).ElementAtOrDefault(0) ?? 0))),
                                        //    0 => 0,
                                        //},
                                        prdTotalSalePrice = (prdMsurGrp.Count()) switch
                                        {
                                            1 => prdQuan.prdQuan1 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(0)),
                                            2 => (prdQuan.prdQuan1 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(0))) + (prdQuan.prdQuan2 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(1))),
                                            3 => (prdQuan.prdQuan1 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(0)) + (prdQuan.prdQuan2 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(1))) + (prdQuan.prdQuan3 * clsTbPrdMsur.GetppmSalePrice(prdQuan.prd.prdPriceTax, prdMsurGrp.ElementAtOrDefault(2)))),
                                            0 => 0,
                                        },


                                        prdNQuan = prdQuan.prdQuan1.ToString("n2"),
                                        prdNQuan2 = prdQuan.prdQuan2.ToString("n2"),
                                        prdNQuan3 = prdQuan.prdQuan3.ToString("n2"),


                                    }).ToList();


            //return tbPrdQuanPrList2;
            return tbPrdQuanPrList3;
        }
    }
}
