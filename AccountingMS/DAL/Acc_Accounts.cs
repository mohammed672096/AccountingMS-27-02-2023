namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Accounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public int Level { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        public string Note { get; set; }

        public int Secrecy { get; set; }

        public bool CanEdit { get; set; }

        public int? InsertUser { get; set; }

        public DateTime? InsertDate { get; set; }

        public int? LastUpdateUserID { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string LastUpdateData { get; set; }

        public byte AccountType { get; set; }
    }
}
