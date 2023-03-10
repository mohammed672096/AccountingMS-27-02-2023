using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportProductQuan : XtraReport
    {
        ClsTblGroupStr clsTbGroup;
        ClsTblProduct clsTbProduct;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        ClsTblBarcode clsTblBarcode;
        ReportProductQuanDetail rprtPrdQuanDetail;

        private ReportProductQuan()
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

        public static async Task<ReportProductQuan> CreateAsync()
        {
            var rprt = new ReportProductQuan();

            List<Task> taskList = new List<Task>()
            {
                Task.Run(() => rprt.InitDataAsync()),
                Task.Run(() => {using(var db=new accountingEntities()) db.CalculatePrdQuan();}),
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
            this.rprtPrdQuanDetail = new ReportProductQuanDetail();
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
                Task.Run(() => this.clsTblBarcode = new ClsTblBarcode()),
            };

            await Task.WhenAll(taskList);

            tblGroupStrParmBindingSource.DataSource = this.clsTbGroup.GetGroupList;
        }

        private void ReportProductQuan_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            IList<tblGroupStr> tbGroupList = new List<tblGroupStr>();
            var paramGrp = (from p in (parameterGrp.Value as Int32[]).Cast<object>() select p).ToList();
            tblGroupStrBindingSource.DataSource = Session.tblGroupStr.Where(x=> paramGrp.Contains(x.id)).ToList();
            //foreach (var grpId in parameterGrp.Value as Int32[])
            //    if (InitQuery(grpId).Count > 0)
            //        tbGroupList.Add(this.clsTbGroup.GetGroupObjById(grpId));
            
            //tblGroupStrBindingSource.DataSource = tbGroupList;
        }

        private void XrSubRprtPrdQuanDetail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.rprtPrdQuanDetail.DataSource = InitQuery(Convert.ToInt32(GetCurrentColumnValue("id")));
        }
        double q1, q2, q3;
        string GetQuantityString(double prdQuan1,List<tblPrdPriceMeasurment> tblPrdPrices)
        {
            var PrdPrice1 = tblPrdPrices.FirstOrDefault(x => x.ppmStatus == 1);
            var PrdPrice2 = tblPrdPrices.FirstOrDefault(x => x.ppmStatus == 2);
            if (PrdPrice2 == null|| PrdPrice1 == null) return "";
            switch (tblPrdPrices.Count)
            {
                case 2:
                    q1 = prdQuan1 % (PrdPrice2.ppmConversion ?? 1);
                    q2 = (prdQuan1 - q1) / (PrdPrice2.ppmConversion ?? 1);
                    return $"{q2:n2} ({PrdPrice2.ppmMsurName})    {q1:n2} ({PrdPrice1.ppmMsurName})";
                case 3:
                    var PrdPrice3 = tblPrdPrices.FirstOrDefault(x => x.ppmStatus == 3);
                    var q = prdQuan1 % (PrdPrice3.ppmConversion ?? 1);
                    q3 = (prdQuan1 - q) / (PrdPrice3.ppmConversion ?? 1);
                    q1 = q % (PrdPrice2.ppmConversion ?? 1);
                    q2 = (q - q1) / (PrdPrice2.ppmConversion ?? 1);
                    return $"{q3:n2} ({PrdPrice3.ppmMsurName})     {q2:n2} ({PrdPrice2.ppmMsurName})     {q1:n2} ({PrdPrice1.ppmMsurName})";
                default:
                    return "";
            }
        }
        private IList<tblPrdQuanPrDetailted> InitQuery(int grpId)
        {
            using (var db = new accountingEntities())
            {
                var p = db.tblProductQunatities.AsNoTracking().Where(x => x.prdQuantity != 0 && x.prdQuantity != null).ToList();
                var tbPrdQuanPrList = (from prdQuan in p
                                       group prdQuan by prdQuan.prdId into prdQuanGrp
                                       join product in this.clsTbProduct.GetProductList on prdQuanGrp.Key equals product.id
                                       where product.prdGrpNo == grpId
                                       select new
                                       {
                                           prd = product,
                                           prdId = prdQuanGrp.Key,
                                           prdQuan1 = prdQuanGrp.Sum(x => (x.prdQuantity ?? 0)),
                                       }).ToList();


                return (from prdQuan in tbPrdQuanPrList
                                        join prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList on prdQuan.prd.id equals prdMsur.ppmPrdId into prdMsurGrp
                                        select new tblPrdQuanPrDetailted()
                                        {
                                            prdId = prdQuan.prd.id,
                                            prdNo = prdQuan.prd.prdNo,
                                            Barcode = this.clsTblBarcode.GetBarcodeNoByPrdMsurId(prdMsurGrp.FirstOrDefault()?.ppmId ?? 0),
                                            prdName = prdQuan.prd.prdName,
                                            prdNQuan =(prdMsurGrp.Count()==1 ? $"{prdQuan.prdQuan1:n2} ({prdMsurGrp.FirstOrDefault().ppmMsurName})": GetQuantityString(prdQuan.prdQuan1, prdMsurGrp.ToList())),
                                        }).ToList();
            }
        }
    }
}
