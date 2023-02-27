namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_RevExpEntry
    {
        public int ID { get; set; }

        public bool IsRevenue { get; set; }

        public int Code { get; set; }

        public int StoreID { get; set; }

        public long DrawerAccountId { get; set; }

        public DateTime EntryDate { get; set; }

        public double Total { get; set; }

        public string Notes { get; set; }

        public int? CostCenter { get; set; }

        public int UserID { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
