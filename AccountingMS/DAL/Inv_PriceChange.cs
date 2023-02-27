namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_PriceChange
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public int? UnitId { get; set; }

        public DateTime? Date { get; set; }

        public int? LastPriceDuration { get; set; }

        public int? InvoiceID { get; set; }

        public double? OldSellPrice { get; set; }

        public double? NewSellPrice { get; set; }

        public double? SellChangeRatio { get; set; }

        public double? OldBuyPrice { get; set; }

        public double? NewBuyPrice { get; set; }

        public double? BuyPriceRatio { get; set; }

        public double? BuyToSellRatio { get; set; }
    }
}
