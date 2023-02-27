namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemUnits
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public int UnitID { get; set; }

        public double BuyPrice { get; set; }

        public double SellPrice { get; set; }

        public double SellDiscount { get; set; }

        public double Factor { get; set; }

        public bool DefualtBuy { get; set; }

        public bool DefualtSell { get; set; }

        public virtual Inv_Items Inv_Items { get; set; }
    }
}
