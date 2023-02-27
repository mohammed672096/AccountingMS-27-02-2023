namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_RevExpEntryDetails
    {
        public int ID { get; set; }

        public int RevExpEntryID { get; set; }

        public int RevExpAccountId { get; set; }

        public string Notes { get; set; }

        public double Amount { get; set; }
    }
}
