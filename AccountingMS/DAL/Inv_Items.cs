namespace AccountingMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inv_Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inv_Items()
        {
            Inv_ItemUnits = new HashSet<Inv_ItemUnits>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Descreption { get; set; }

        public int? GroupID { get; set; }

        public int? Company { get; set; }

        public bool Suspended { get; set; }

        public bool Expier { get; set; }

        public bool Serial { get; set; }

        public bool Warranty { get; set; }

        public int ShelfLife { get; set; }

        public int WarntyDuration { get; set; }

        public bool Color { get; set; }

        public bool Size { get; set; }

        public int SecracyLevel { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inv_ItemUnits> Inv_ItemUnits { get; set; }
    }
}
