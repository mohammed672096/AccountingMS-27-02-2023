namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public byte? InvoiceType { get; set; }

        [Required]
        [StringLength(35)]
        public string Code { get; set; }

        public int? CCenter { get; set; }

        public int? SalesBookID { get; set; }

        public byte PartType { get; set; }

        public int PartID { get; set; }

        public int Source { get; set; }

        public int SourceID { get; set; }

        [StringLength(50)]
        public string AttintionMs { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int StoreID { get; set; }

        public byte PostState { get; set; }

        public int? PostAccount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OutFromStoreDate { get; set; }

        public string Notes { get; set; }

        public bool? PayType { get; set; }

        public double DiscountValue { get; set; }

        public double DiscountRatio { get; set; }

        public double Total { get; set; }

        public double AddTax { get; set; }

        public double AddTaxVal { get; set; }

        public double DeductTaxRatio { get; set; }

        public double DeductTaxValue { get; set; }

        public double TotalRevenue { get; set; }

        public double Net { get; set; }

        public int? Car { get; set; }

        public int? Driver { get; set; }

        [StringLength(50)]
        public string Destination { get; set; }

        [StringLength(250)]
        public string ShippingAddress { get; set; }

        public int? ApprovedBy { get; set; }

        public bool IsApproved { get; set; }

        public int UserID { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateDate { get; set; }

        public int? SalesRep { get; set; }

        public byte SecresyLevel { get; set; }
    }
}
