namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemBarcodes
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public int UnitID { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }
    }
}
