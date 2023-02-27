namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? GroupID { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        public int MaxCredit { get; set; }

        [StringLength(250)]
        public string EMail { get; set; }

        public int Account { get; set; }

        public bool LinkedToAccount { get; set; }
    }
}
