using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace AccountingMS.Reports
{
    public partial class rpt_ProductsSoldWithPriceLowerThanCost : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_ProductsSoldWithPriceLowerThanCost()
        {
            InitializeComponent();
            //SetRTL();
            new ClsReportHeaderData(this);

            // this.DataSource = GetItemsReachedReorderLevelList();
            // this.DataMember = "";
            // this.DetailReport.DataSource = this.DataSource;
            // this.DetailReport.DataMember = "Products";
            //  
            //

        }

        internal static void ShowReport(List<Model.ItemsSoldWithLowerPrice> ds)
        {
            rpt_ProductsSoldWithPriceLowerThanCost rpt = new rpt_ProductsSoldWithPriceLowerThanCost();
            rpt.DataSource = ds;
            rpt.DataMember = "";
            rpt.ShowRibbonPreview();
        }
    }
}
