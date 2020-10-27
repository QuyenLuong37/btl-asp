namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [Column(Order = 0)]
        public int shoeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userId { get; set; }

        public int quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string discountId { get; set; }

        [Required]
        [StringLength(20)]
        public string status { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        public virtual Giay Giay { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
