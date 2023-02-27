using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace AccountingMS.Reports
{
    public partial class rpt_ItemReorderLevels : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_ItemReorderLevels()
        {
            InitializeComponent();
            //SetRTL();
            new ClsReportHeaderData(this);

            this.DataSource = GetItemsReachedReorderLevelList();
            this.DataMember = "";
            this.DetailReport.DataSource = this.DataSource;
            this.DetailReport.DataMember = "Products";

            cell_Product.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[prdName]"));
            cell_ProductCount.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Count]"));
            cell_QtyLarge.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[prdQuantity]"));
            cell_QtyMid.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[prdSubQuantity]"));
            cell_Qty_Small.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[prdSubQuantity3]"));
            cell_ReorderLevel.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[ReorderLevel]"));
            cell_Store.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[strName]"));


        }
        public static object GetItemsReachedReorderLevelList()
        {
            using (var db = new accountingEntities())
            {
                var data = from qty in db.tblProductQunatities
                           where qty.prdBrnId == Session.CurBranch.brnId
                           join pro in db.tblProducts on qty.prdId equals pro.id
                           where pro.prdBrnId == Session.CurBranch.brnId
                           join str in db.tblStores on qty.prdStrId equals str.id
                           select new
                           {

                               pro.prdName,
                               str.strName,
                               pro.ReorderLevel,
                               qty.prdQuantity,
                               qty.prdSubQuantity,
                               qty.prdSubQuantity3,
                           };

                data = data.Where(x => x.ReorderLevel > x.prdQuantity);

                return new[] { new { Count = data.Count(), Products = data.ToList() } };
            }

        }
        internal static void ShowReport()
        {
            rpt_ItemReorderLevels rpt = new rpt_ItemReorderLevels();
            rpt.ShowRibbonPreview();
        }
    }
}
