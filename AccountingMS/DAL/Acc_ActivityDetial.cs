namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_ActivityDetial
    {
        public int ID { get; set; }

        public int AcivityID { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public int ACCID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public double Debit { get; set; }

        public double Credit { get; set; }

        public int? CostCenter { get; set; }

        public int CurrencyID { get; set; }

        public double CurrencyRate { get; set; }
    }
}
