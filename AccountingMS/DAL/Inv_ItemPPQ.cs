namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemPPQ
    {
        public int ID { get; set; }

        public int? ItemID { get; set; }

        public double? FromQty { get; set; }

        public double? ToQty { get; set; }

        public double? Price { get; set; }
    }
}
