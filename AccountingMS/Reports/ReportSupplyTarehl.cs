using System;
using System.Linq;

namespace AccountingMS
{
    public partial class ReportSupplyTarehl : DevExpress.XtraReports.UI.XtraReport
    {
        ClsTblAsset clsTbAsset = new ClsTblAsset();

        private tblSupplyMain tbSupplyMain;

        public ReportSupplyTarehl(tblSupplyMain tbSupplyMain)
        {
            InitializeComponent();
            this.tbSupplyMain = tbSupplyMain;

            InitDefaultData();
            InitSupplyData();
            InitAssetData();
        }

        private void InitDefaultData()
        {
            new ClsReportHeaderData(this);
            xrtcDate.Text = (!MySetting.GetPrivateSetting.LangEng) ? $"{DateTime.Now:yyyy/MM/dd h:MM tt}" : $"{DateTime.Now:dd/MM/yyy h:MM tt}";
        }

        private void InitSupplyData()
        {
            xrtcInvNo.Text = this.tbSupplyMain.supNo.ToString();
            xrtcInvStatus.Text = ClsSupplyStatus.GetString(this.tbSupplyMain.supStatus, Convert.ToByte(this.tbSupplyMain.supIsCash));
            xrtcInvAmount.Text = $"{(this.tbSupplyMain.supTotal + Convert.ToDouble(this.tbSupplyMain.supTaxPrice)) - Convert.ToDouble(this.tbSupplyMain.supDscntAmount):n2}";
            xrtcDateInv.Text = $"{this.tbSupplyMain.supDate:yyyy/MM/dd h:mm tt}";
        }

        private void InitAssetData()
        {
            var tbAssetList = this.clsTbAsset.GetAssetSupplyListByEntId(this.tbSupplyMain.id);
            xrtcDateTarhel.Text = $"{tbAssetList.Select(x => x.asDate).FirstOrDefault():yyyy/MM/dd}";

            tblAssetBindingSource.DataSource = tbAssetList;
        }
    }
}
