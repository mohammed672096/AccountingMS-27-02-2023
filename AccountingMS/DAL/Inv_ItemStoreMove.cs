namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemStoreMove
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public DateTime Date { get; set; }

        public int FromBranchID { get; set; }

        public int ToBranchID { get; set; }

        public string Notes { get; set; }

        public double TotalPurchasePrice { get; set; }

        public double TotalSalePrice { get; set; }

        public int UserID { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateUserDate { get; set; }
    }
}
