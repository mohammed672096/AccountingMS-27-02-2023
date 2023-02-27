using AccountingMS.Reports;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Linq;

namespace AccountingMS
{
    public partial class uc_Administrative_Report : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_Administrative_Report()
        {
            InitializeComponent();

        }

        void RefreshTiles()
        {
            ItemsReachedReorderLevel.Text = GetItemsReachedReorderLevelCount().ToString();
            ItemsExededMaxLevel.Text = GetItemsExudedMaxLevel().ToString();
            ItemSoldWithLessPriceThanSell.Text = GetProductsSoldWithPriceLowerThanCostCount((DateTime)edit_StartDate.EditValue, (DateTime)edit_EndDate.EditValue).ToString();
        }

        public static int GetItemsReachedReorderLevelCount()
        {
            using (var db = new accountingEntities())
            {
                var data = from qty in db.tblProductQunatities
                           where qty.prdBrnId == Session.CurBranch.brnId
                           join pro in db.tblProducts on qty.prdId equals pro.id
                           select new
                           {
                               pro.prdName,
                               pro.ReorderLevel,
                               qty.prdQuantity,
                           };

                data = data.Where(x => x.ReorderLevel > x.prdQuantity);
                return data.Count();
            }

        }

        public static int GetItemsExudedMaxLevel()
        {

            using (var db = new accountingEntities())
            {
                var data = from qty in db.tblProductQunatities
                           where qty.prdBrnId == Session.CurBranch.brnId
                           join pro in db.tblProducts on qty.prdId equals pro.id
                           select new
                           {
                               pro.prdName,
                               pro.MaxLevel,
                               qty.prdQuantity,
                           };

                data = data.Where(x => x.MaxLevel < x.prdQuantity);
                return data.Count();
            }

        }
        public static int GetProductsSoldWithPriceLowerThanCostCount(DateTime fromDate, DateTime ToDate)
        {
            return GetProductsSoldWithPriceLowerThanCost(fromDate, ToDate).Count();
        }
        public static IQueryable<Model.ItemsSoldWithLowerPrice> GetProductsSoldWithPriceLowerThanCost(DateTime fromDate, DateTime ToDate)
        {
            var db = new accountingEntities();

            //using (var db = new accountingEntities())
            //{
            var data = from sld in db.tblSupplySubs
                       where sld.supBrnId == Session.CurBranch.brnId
                       join sl in db.tblSupplyMains on sld.supNo equals sl.id
                       where sl.supBrnId == Session.CurBranch.brnId
                       from unit in db.tblPrdPriceMeasurments.Where(x => x.ppmPrdId == sld.supPrdId && x.ppmBrnId == sl.supBrnId
                     && x.ppmBarcode1 == sld.supPrdBarcode || x.ppmBarcode2 == sld.supPrdBarcode || x.ppmBarcode3 == sld.supPrdBarcode)
                       where sl.supStatus == 8 && sl.supDate >= fromDate && sl.supDate <= ToDate
                       && (sld.supSalePrice ?? 0) < (sld.supPrice ?? 0)

                       select new Model.ItemsSoldWithLowerPrice
                       {
                           CostPrice = sld.supPrice ?? unit.ppmPrice ?? 0,
                           SellPrice = sld.supSalePrice ?? 0,
                           Barcode = sld.supPrdBarcode,
                           ID = sld.supPrdId.Value,
                           Invoice = sl.supNo,
                           InvoiceDate = sld.supDate,
                           Name = sld.supPrdName,
                           Quantity = sld.supQuanMain,
                           Unit = unit.ppmMsurName,
                       };

            //  data = data.Where(x => x.MaxLevel < x.prdQuantity);
            return data;
            //}
        }


        TileItemElement ItemsExededMaxLevel;
        TileItemElement ItemsReachedReorderLevel;
        TileItemElement ItemSoldWithLessPriceThanSell;
        private void uc_Administrative_Report_Load(object sender, EventArgs e)
        {
            edit_StartDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            edit_EndDate.EditValue = ((DateTime)edit_StartDate.EditValue).AddMonths(1).AddDays(-1);


            ItemsReachedReorderLevel = AddTileItem(tileGroup2, "اصناف وصلت الي حد الطلب ", "صنف", Classes.Utils.ColorFromHexa("#388E3C"),
            null, (ss, ee) => { rpt_ItemReorderLevels.ShowReport(); });

            ItemsExededMaxLevel = AddTileItem(tileGroup2, "اصناف تخطت الحد الاقصي ", "صنف", Classes.Utils.ColorFromHexa("#2196F3"), null,
                (ss, ee) => { rpt_MaxLevel.ShowReport(); });

            ItemSoldWithLessPriceThanSell = AddTileItem(tileGroup2, "اصناف ربحها بالسالب", "صنف", Classes.Utils.ColorFromHexa("#ffab00"), null,
                (ss, ee) => { rpt_ProductsSoldWithPriceLowerThanCost.ShowReport(GetProductsSoldWithPriceLowerThanCost((DateTime)edit_StartDate.EditValue, (DateTime)edit_EndDate.EditValue).ToList()); });

            RefreshTiles();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshTiles();
        }


        int tileID = 0;
        TileItemElement AddTileItem(TileGroup group, string Titel, string SubCaption, Color color, SvgImage svg, TileItemClickEventHandler args)
        {
            TileItem tile = new TileItem();
            TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            tile.AppearanceItem.Normal.BackColor = color;// System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(163)))), ((int)(((byte)(10)))));
            tile.AppearanceItem.Normal.Options.UseBackColor = true;
            tileItemElement1.AnchorIndent = 5;
            tileItemElement1.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 9F);
            tileItemElement1.Appearance.Hovered.Options.UseFont = true;
            tileItemElement1.Appearance.Hovered.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Appearance.Normal.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement1.Appearance.Selected.Font = new System.Drawing.Font("Segoe UI", 9F);
            tileItemElement1.Appearance.Selected.Options.UseFont = true;
            tileItemElement1.Appearance.Selected.Options.UseTextOptions = true;
            tileItemElement1.Appearance.Selected.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement1.Appearance.Selected.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement1.ImageOptions.ImageSize = new System.Drawing.Size(120, 120);
            tileItemElement1.ImageOptions.SvgImage = svg;
            tileItemElement1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            tileItemElement1.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement1.MaxWidth = 145;
            tileItemElement1.Text = Titel;
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileItemElement1.TextLocation = new System.Drawing.Point(5, 5);
            tileItemElement1.Width = 250;
            tileItemElement2.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI Light", 49F);
            tileItemElement2.Appearance.Hovered.Options.UseFont = true;
            tileItemElement2.Appearance.Hovered.Options.UseTextOptions = true;
            tileItemElement2.Appearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement2.Appearance.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            tileItemElement2.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Light", 49F);
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Appearance.Normal.Options.UseTextOptions = true;
            tileItemElement2.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement2.Appearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            tileItemElement2.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement2.Appearance.Selected.Font = new System.Drawing.Font("Segoe UI Light", 49F);
            tileItemElement2.Appearance.Selected.Options.UseFont = true;
            tileItemElement2.Appearance.Selected.Options.UseTextOptions = true;
            tileItemElement2.Appearance.Selected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement2.Appearance.Selected.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            tileItemElement2.Appearance.Selected.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement2.MaxWidth = 100;
            tileItemElement2.Text = "0";
            tileItemElement2.TextAlignment = TileItemContentAlignment.TopRight;
            tileItemElement2.TextLocation = new System.Drawing.Point(0, -15);
            tileItemElement3.Appearance.Hovered.Font = new System.Drawing.Font("Segoe UI", 9F);
            tileItemElement3.Appearance.Hovered.Options.UseFont = true;
            tileItemElement3.Appearance.Hovered.Options.UseTextOptions = true;
            tileItemElement3.Appearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement3.Appearance.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement3.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement3.Appearance.Normal.Font = new Font("Segoe UI", 9F);
            tileItemElement3.Appearance.Normal.Options.UseFont = true;
            tileItemElement3.Appearance.Normal.Options.UseTextOptions = true;
            tileItemElement3.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement3.Appearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement3.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement3.Appearance.Selected.Font = new System.Drawing.Font("Segoe UI", 9F);
            tileItemElement3.Appearance.Selected.Options.UseFont = true;
            tileItemElement3.Appearance.Selected.Options.UseTextOptions = true;
            tileItemElement3.Appearance.Selected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tileItemElement3.Appearance.Selected.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            tileItemElement3.Appearance.Selected.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            tileItemElement3.MaxWidth = 70;
            tileItemElement3.Text = SubCaption;
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            tileItemElement3.TextLocation = new System.Drawing.Point(-3, 15);
            tile.Elements.Add(tileItemElement1);
            tile.Elements.Add(tileItemElement2);
            tile.Elements.Add(tileItemElement3);
            tile.Id = tileID;
            tile.ItemSize = TileItemSize.Wide;
            tile.Name = "tileItem" + tileID;
            tile.ItemClick += args;

            group.Items.Add(tile);
            return tileItemElement2;


        }


    }
}
