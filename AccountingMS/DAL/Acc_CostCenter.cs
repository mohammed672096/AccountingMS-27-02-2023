namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_CostCenter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(150)]
        public string Number { get; set; }

        public int ParentID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Notes { get; set; }
    }
}
