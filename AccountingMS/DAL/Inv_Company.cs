namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_Company
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
