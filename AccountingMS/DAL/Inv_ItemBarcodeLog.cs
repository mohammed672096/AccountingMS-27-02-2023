namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemBarcodeLog
    {
        [Key]
        public int Barcode { get; set; }

        public int ItemID { get; set; }

        public int UnitID { get; set; }

        public int StoreID { get; set; }

        public double BuyPrice { get; set; }

        public int Type { get; set; }

        public int TypeID { get; set; }

        public DateTime? ExpDate { get; set; }

        [StringLength(150)]
        public string Serial { get; set; }

        public int? Color { get; set; }

        public int? Size { get; set; }

        [StringLength(25)]
        public string Batch { get; set; }
    }
}
