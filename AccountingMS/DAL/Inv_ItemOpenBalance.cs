namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_ItemOpenBalance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inv_ItemOpenBalance()
        {
            Inv_ItemOpenBalanceDetails = new HashSet<Inv_ItemOpenBalanceDetails>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public int BranchID { get; set; }

        public string Notes { get; set; }

        public double TotalPurchasePrice { get; set; }

        public double TotalSalePrice { get; set; }

        public int? UserID { get; set; }

        public int? LastUpdateUserID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastUpdateUserDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inv_ItemOpenBalanceDetails> Inv_ItemOpenBalanceDetails { get; set; }
    }
}
