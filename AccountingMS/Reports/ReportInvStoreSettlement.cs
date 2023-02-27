using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingMS
{
    public partial class ReportInvStoreSettlement : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblStore clsTbStore;
        ClsTblAsset clsTbAsset;

        public ReportInvStoreSettlement()
        {
            InitializeComponent();
            InitDefaultData();
            this.ApplyLocalization(System.Threading.Thread.CurrentThread.CurrentCulture);
            if (MySetting.GetPrivateSetting.LangEng)
            {
                this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.No;
                this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.No;
            }
        }

        public static async Task<ReportInvStoreSettlement> CreateAsync(tblInvStoreMain tbInvMain)
        {
            var rprt = new ReportInvStoreSettlement();

            await rprt.InitObjectsAsync();
            rprt.IniitDataObjects(tbInvMain);

            return rprt;
        }

        private async Task InitObjectsAsync()
        {
            IList<Task> taskList = new List<Task>();

            taskList.Add(Task.Run(() => this.clsTbStore = new ClsTblStore()));
            taskList.Add(Task.Run(() => this.clsTbAsset = new ClsTblAsset()));

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
            tblAssetBindingSource.DataSource = this.clsTbAsset.GetAssetListByEntIdAndStatus(tbInvMain.id, (byte)AssetType.InvSettlement);

            xrlStore.Text += this.clsTbStore.GetStoreNameById(tbInvMain.invStrId);
        }
    }
}