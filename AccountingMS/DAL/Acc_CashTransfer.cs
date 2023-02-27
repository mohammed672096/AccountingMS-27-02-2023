namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acc_CashTransfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int StoreID { get; set; }

        public int FromDrawerID { get; set; }

        public int ToDrawerID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }
    }
}
