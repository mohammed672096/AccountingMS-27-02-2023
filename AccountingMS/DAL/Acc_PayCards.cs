namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_PayCards
    {
        public int ID { get; set; }

        public int BankID { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public double Commission { get; set; }

        public int CommissionAccount { get; set; }

        public int LinkedToBranch { get; set; }
    }
}
