namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Pays
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Refrence { get; set; }

        public int SourceType { get; set; }

        public int SourceID { get; set; }

        public int PayType { get; set; }

        public int PayID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PayDate { get; set; }

        public double Amount { get; set; }

        public int CurrancyID { get; set; }

        public double CurrancyRate { get; set; }

        public string Notes { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime InsertDate { get; set; }
    }
}
