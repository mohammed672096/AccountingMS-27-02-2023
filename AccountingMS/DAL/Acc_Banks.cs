namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Banks
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string BankName { get; set; }

        [Required]
        [StringLength(20)]
        public string BankAccountNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone1 { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone2 { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone3 { get; set; }

        [Required]
        public string Notes { get; set; }

        public int LinkedToBranch { get; set; }

        public int AccountID { get; set; }
    }
}
