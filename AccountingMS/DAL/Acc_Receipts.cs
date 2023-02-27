namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Receipts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        public string RefNumber { get; set; }

        public bool IsIn { get; set; }

        public byte Source { get; set; }

        public int SourceID { get; set; }

        public double Amount { get; set; }

        public int? DrawerAccountID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateCollected { get; set; }

        public int CollectedBy { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
