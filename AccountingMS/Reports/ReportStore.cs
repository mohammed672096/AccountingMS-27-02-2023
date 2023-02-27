using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportStore : XtraReport
    {
        ClsTblProductData clsTbPrdData;
        ClsTblProductQtyOpn clsTbPrdQtyOpn;
        ClsTblPrdPriceMeasurment clsTbPrdMsur;
        IEnumerable<tblSupplySub> tbSupplySubList;
        //ClsTblProduct clsTbProduct;
        //ICollection<ClsStoreList> tbStoreList = new Collection<ClsStoreList>();
        //tblProductQunatity tbPrdQuantityInc;
        //tblProductQunatity tbPrdQuantityOut;

        public ReportStore()
        {
            InitializeComponent();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            SetRTL();

        }
        public static async Task<ReportStore> CreateAsync()
        {
            var rprt = new ReportStore();

            await rprt.InitDataAsync();
            await Task.Run(() => rprt.InitDefaultData());

            return rprt;
        }
        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            //tblStoreBindingSource.DataSource = this.clsTbStore.GetStoreList;
            //xrtcDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd}" : $"{DateTime.Now:dd/MM/yyyy}";
        }
        public void GetSupplySubList()
        {
            using (var db = new accountingEntities())
            {
                tbSupplySubList = db.tblSupplySubs.AsNoTracking().Where(x => x.supBrnId == Session.CurBranch.brnId).ToList();
            }
        }
        private async Task InitDataAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbPrdData = new ClsTblProductData()));
            // taskList.Add(Task.Run(() => this.clsTbProduct = new ClsTblProduct()));
            taskList.Add(Task.Run(() => GetSupplySubList()));
            taskList.Add(Task.Run(() => this.clsTbPrdMsur = new ClsTblPrdPriceMeasurment()));
            taskList.Add(Task.Run(() => this.clsTbPrdQtyOpn = new ClsTblProductQtyOpn()));

            await Task.WhenAll(taskList);
            InitData();
        }
        private void InitData()
        {
            var tbProductList = (from prdQuan in this.clsTbPrdData.GetProductDataList
                                 join prd in tbSupplySubList on prdQuan.id equals prd.supPrdId into prdQuantityGrp
                                 select new
                                 {
                                     id = prdQuan.id,
                                     prdNo = prdQuan.prdNo,
                                     prdName = prdQuan.prdName,
                                     prdQuantInit = InitPrdQuantityOpn(prdQuan),
                                     prdQuantity = prdQuantityGrp.Where(x => (x.supStatus == 3 || x.supStatus == 7 || x.supStatus == 11 || x.supStatus == 12) & x.supPrdId == prdQuan.id).Sum(x => (x.supQuanMain??0)*x.Conversion),
                                     //prdSubQuantity = prdQuantityGrp.Where(x => (x.supStatus == 3 || x.supStatus == 7 || x.supStatus == 11 || x.supStatus == 12) & x.supMsur == prdQuan.ppmId2).Sum(x => x.supQuanMain),
                                     //prdSubQuantity3 = prdQuantityGrp.Where(x => (x.supStatus == 3 || x.supStatus == 7 || x.supStatus == 11 || x.supStatus == 12) & x.supMsur == prdQuan.ppmId3).Sum(x => x.supQuanMain),
                                     prdQuantityOut = prdQuantityGrp.Where(x => (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 9 || x.supStatus == 10) & x.supPrdId == prdQuan.id).Sum(x => (x.supQuanMain ?? 0) * x.Conversion),
                                     //prdSubQuantityOut = prdQuantityGrp.Where(x => (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 9 || x.supStatus == 10) & x.supMsur == prdQuan.ppmId2).Sum(x => x.supQuanMain),
                                     //prdSubQuantity3Out = prdQuantityGrp.Where(x => (x.supStatus == 4 || x.supStatus == 8 || x.supStatus == 9 || x.supStatus == 10) & x.supMsur == prdQuan.ppmId3).Sum(x => x.supQuanMain),
                                 }).ToList();

            var tbStore = (from pro in tbProductList
                           join prdMsur in this.clsTbPrdMsur.GetPrdPriceMsurList on pro.id equals prdMsur.ppmPrdId into prdMsurGrp
                           where pro.prdQuantInit != null | (pro.prdQuantity > 0 | pro.prdQuantityOut > 0)
                           orderby pro.id
                           // join QtyOpn in this.clsTbPrdQtyOpn.GetProductQtyOpnList on pro.id equals QtyOpn.qtyPrdId into QtyOpnGrp
                           select new
                           {
                               prdNo = pro.prdNo,
                               prdName = pro.prdName,
                               prdQuantInit = pro.prdQuantInit,
                               prdQuantRecevied = $"{pro.prdQuantity} ({prdMsurGrp.ElementAt(0).ppmMsurName})",
                               prdQuantSold =  $"{pro.prdQuantityOut} ({prdMsurGrp.ElementAt(0).ppmMsurName})",
                               prdQuantRemaining =  pro.prdQuantInit == null ? $"{pro.prdQuantity - pro.prdQuantityOut} ({prdMsurGrp.ElementAt(0).ppmMsurName})" : (pro.prdQuantity + Convert.ToDouble(pro.prdQuantInit.Substring(0, pro.prdQuantInit.IndexOf("("))) - pro.prdQuantityOut).ToString() + "(" + prdMsurGrp.ElementAt(0).ppmMsurName + ")",
                           }).ToList();
            tblStoreBindingSource.DataSource = tbStore;
        }
        private string InitPrdQuantityOpn(tblProductData tbPrdData)
        {

            string quantity = null;
            var tbPrdQuantityOpn = this.clsTbPrdQtyOpn.GetPrdQuantityOpnListByPrdId(tbPrdData.id);

            if (tbPrdQuantityOpn.Count() == 1)
            {
                quantity = tbPrdQuantityOpn.ElementAt(0).qtyQuantity.ToString();
                if (tbPrdQuantityOpn.ElementAt(0).qtyPrdMsurId == tbPrdData.ppmId1) quantity += $" ({tbPrdData.ppmMsurName1})";
            }
            else if (tbPrdQuantityOpn.Count() == 2)
            {
                if (tbPrdQuantityOpn.ElementAt(0).qtyPrdMsurId == tbPrdData.ppmId1) quantity = $"{tbPrdQuantityOpn.ElementAt(0).qtyQuantity} ({tbPrdData.ppmMsurName1})";
                if (tbPrdQuantityOpn.ElementAt(1).qtyPrdMsurId == tbPrdData.ppmId2) quantity += $" | {tbPrdQuantityOpn.ElementAt(1).qtyQuantity} ({tbPrdData.ppmMsurName2})";
            }
            else if (tbPrdQuantityOpn.Count() == 3)
            {
                if (tbPrdQuantityOpn.ElementAt(0).qtyPrdMsurId == tbPrdData.ppmId1) quantity = $"{tbPrdQuantityOpn.ElementAt(0).qtyQuantity} ({tbPrdData.ppmMsurName1})";
                if (tbPrdQuantityOpn.ElementAt(1).qtyPrdMsurId == tbPrdData.ppmId2) quantity += $" | {tbPrdQuantityOpn.ElementAt(1).qtyQuantity} ({tbPrdData.ppmMsurName2})";
                if (tbPrdQuantityOpn.ElementAt(2).qtyPrdMsurId == tbPrdData.ppmId3) quantity += $" | {tbPrdQuantityOpn.ElementAt(2).qtyQuantity}({tbPrdData.ppmMsurName3})";
            }
            return quantity;
        }
        private void SetRTL()
        {
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }
    }
}
