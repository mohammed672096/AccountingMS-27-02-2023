using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportInvStoreDirect : XtraReport
    {
        ClsTblStore clsTbStore;
        public ReportInvStoreDirect()
        {
            InitializeComponent();
            InitDefaultData();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = RightToLeftLayout.No;
            }
        }

        public static async Task<ReportInvStoreDirect> CreateAsync(tblInvStoreMain tbInvMain)
        {
            var rprt = new ReportInvStoreDirect();

            await rprt.InitObjectsAsync();
            rprt.IniitDataObjects(tbInvMain);
            var rprtInvDirect =new ReportInvStoreDirect();
            rprtInvDirect.CreateDocument();
            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() =>   new ClsTblProduct()));
            taskList.Add(Task.Run(() =>  new ClsTblPrdPriceMeasurment()));
            await Task.WhenAll(taskList);
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            xrlDate.Text += (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:f}" : $"{DateTime.Now:f}";
        }

        private void IniitDataObjects(tblInvStoreMain tbInvMain)
        {
            tblInvStoreMainBindingSource.DataSource = tbInvMain;
            using (var db = new accountingEntities())
            {
              var tbInvSubList = (from i in db.tblInvStoreSubs.AsNoTracking().Where(x=>x.invMainId== tbInvMain.id).ToList()
                           join p in Session.Products on i.invPrdId equals p.id
                           join m in Session.tblPrdPriceMeasurment on i.invPrdMsurId equals m.ppmId
                                     select new 
                                     {
                                 i.id,
                                 i.invBarcode,
                                 i.invMainId,
                                 i.invPrdGrpId,
                                 invPrdId=p.prdName,
                                 invPrdMsurId=  m.ppmMsurName,
                                 i.invPriceAvrg,
                                 i.invPriceDefr,
                                 i.invPriceTotal,
                                 i.invQuanAvl,
                                 i.invQuanDefr,
                                 i.invQuanStr,
                                 i.invSalePrice,
                                 i.invSalePriceTotal,
                                     }).ToList();

                double totalInc = tbInvSubList.Where(x => x.invPriceDefr > 0)?.Sum(x => x.invPriceDefr)??0;
                double totalDec = tbInvSubList.Where(x => x.invPriceDefr <= 0)?.Sum(x => x.invPriceDefr)??0;
                xrtcTotalIncrease.Text = $"{totalInc:n3}";
                xrtcTotalDecrease.Text = $"{totalDec:n3}";
                xrtcTotalFianl.Text = $"{totalDec + totalInc:n3}";
                tblInvStoreSubBindingSource.DataSource = tbInvSubList;
            }
            xrlStore.Text += this.clsTbStore.GetStoreNameById(tbInvMain.invStrId);
        }

    }
}
