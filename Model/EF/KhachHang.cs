namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        public int? age { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public bool? typeCustomer { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? modifyDate { get; set; }

        public bool? status { get; set; }

        [Key]
        public int userId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
