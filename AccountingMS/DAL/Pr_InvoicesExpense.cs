namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pr_InvoicesExpense
    {
        public int ID { get; set; }

        public int? InID { get; set; }

        public int? AccID { get; set; }

        public double? Amount { get; set; }
    }
}
