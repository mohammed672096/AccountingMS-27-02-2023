namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_Store
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public int? PurchaseAccountID { get; set; }

        public int? PurchaseReturnAccountID { get; set; }

        public int? SellAccountID { get; set; }

        public int? SellReturnAccountID { get; set; }

        public int? PurchaseDiscountAccountID { get; set; }

        public int? SalesDiscountAccountID { get; set; }

        public int? ParentStoreID { get; set; }

        public int? OpenInventoryAccount { get; set; }

        public int? CloseInventoryAccount { get; set; }

        public int? CostMethod { get; set; }

        public int? CostCenter { get; set; }

        public int? CostOfSoldGoodsAcc { get; set; }

        public int? InventoryAccount { get; set; }
    }
}
