namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemOpenBalanceDetails
    {
        public int ID { get; set; }

        public int ItemOpenBalanceID { get; set; }

        public int ItemID { get; set; }

        public int ItemUnitID { get; set; }

        public double ItemeQty { get; set; }

        public int BranchID { get; set; }

        public double SellPrice { get; set; }

        public double TotalSellPrice { get; set; }

        public double PurchasePrice { get; set; }

        public double TotalPurchasePrice { get; set; }

        public virtual Inv_ItemOpenBalance Inv_ItemOpenBalance { get; set; }
    }
}
