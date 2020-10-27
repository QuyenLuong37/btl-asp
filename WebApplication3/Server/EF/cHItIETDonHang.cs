namespace WebApplication3.Server.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int shoeId { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public virtual Giay Giay { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
