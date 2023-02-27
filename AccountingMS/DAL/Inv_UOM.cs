namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_UOM
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
