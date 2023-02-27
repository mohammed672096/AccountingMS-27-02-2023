namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_Currencys
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Pound1 { get; set; }

        [StringLength(50)]
        public string Pound2 { get; set; }

        [StringLength(50)]
        public string Pound3 { get; set; }

        [StringLength(50)]
        public string Piaster1 { get; set; }

        [StringLength(50)]
        public string Piaster2 { get; set; }

        [StringLength(50)]
        public string Piaster3 { get; set; }

        public double LastRate { get; set; }
    }
}
