namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_InvoiceDetail
    {
        public int ID { get; set; }

        public int InvoiceID { get; set; }

        public int ItemID { get; set; }

        public int ItemUnitID { get; set; }

        public double ItemQty { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public double CostValue { get; set; }

        public double TotalCostValue { get; set; }

        public double Discount { get; set; }

        public double DiscountValue { get; set; }

        public int? StoreID { get; set; }

        public DateTime? ExpDate { get; set; }

        [StringLength(150)]
        public string Serial { get; set; }

        public int? Color { get; set; }

        public int? Size { get; set; }

        [StringLength(25)]
        public string Batch { get; set; }
    }
}
