namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_CurrencyChangeLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int CurrencyID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public double Rate { get; set; }
    }
}
