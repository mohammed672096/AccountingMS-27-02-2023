namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pr_VendorGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        public int? ParentID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public double? Discount { get; set; }

        public string Note { get; set; }
    }
}
