namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_StoreLog
    {
        public int ID { get; set; }

        public DateTime? date { get; set; }

        public int? ItemID { get; set; }

        public int? StoreID { get; set; }

        public double? ItemQuIN { get; set; }

        public double? ItemQuOut { get; set; }

        public double? BuyPrice { get; set; }

        public double? SellPrice { get; set; }

        public int? Type { get; set; }

        public int? TypeID { get; set; }

        public DateTime? ExpDate { get; set; }

        [StringLength(150)]
        public string Serial { get; set; }

        public int? Color { get; set; }

        public int? Size { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [StringLength(25)]
        public string Batch { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? TotalOutUntillDate { get; set; }
    }
}
