namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Activity
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int? CostCEnter { get; set; }

        public string Note { get; set; }

        public int? StoreID { get; set; }

        [Required]
        [StringLength(250)]
        public string Type { get; set; }

        [Required]
        [StringLength(250)]
        public string TypeID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? InsertDate { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
