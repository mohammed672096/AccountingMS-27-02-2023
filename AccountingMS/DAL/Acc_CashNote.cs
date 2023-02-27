namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_CashNote
    {
        public int ID { get; set; }

        public bool IsCashNote { get; set; }

        public int Code { get; set; }

        public int StoreID { get; set; }

        public int? CCenter { get; set; }

        public byte PartType { get; set; }

        public int PartID { get; set; }

        public double Amount { get; set; }

        public double DiscountValue { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public byte LinkType { get; set; }

        public int? LinkID { get; set; }

        public int UserID { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
