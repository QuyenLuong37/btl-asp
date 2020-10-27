namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giay")]
    public partial class Giay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        

        [Key]
        public int shoeId { get; set; }

        public int categoryId { get; set; }

        [StringLength(20)]
        public string shoeName { get; set; }

        [StringLength(20)]
        public string color { get; set; }

        [StringLength(20)]
        public string size { get; set; }

        [Column(TypeName = "money")]
        [UIHint("Currency")]
        public decimal? price { get; set; }

        [Column(TypeName = "money")]
        [UIHint("Currency")]
        public decimal? comparePrice { get; set; }

        [Required]
        [StringLength(10)]
        public string type { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        public int? viewCount { get; set; }

        public bool? userManual { get; set; }

        public int? quantitySold { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        [Column(TypeName = "xml")]
        public string moreImages { get; set; }

        [StringLength(20)]
        public string seoTitile { get; set; }

        public DateTime? createdAt { get; set; }
        public DateTime? minifyDate { get; set; }

        [StringLength(20)]
        public string createdBy { get; set; }

        public int? inventory { get; set; }

        public bool? status { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public int? warranty { get; set; }


        [StringLength(20)]
        public string material { get; set; }

        [StringLength(20)]
        public string categoryName { get; set; }

        public bool isActive { get; set; }

        [StringLength(20)]
        public string promotion { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
