namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemLocation
    {
        public int ID { get; set; }

        public int? StoreID { get; set; }

        public int? ItemID { get; set; }

        [StringLength(50)]
        public string ItemLocation { get; set; }

        public double? Min { get; set; }

        public double? Max { get; set; }
    }
}
