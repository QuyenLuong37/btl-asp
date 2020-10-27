


namespace WebApplication3.Server.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public int orderId { get; set; }

        public int customerId { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public int? discountId { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}