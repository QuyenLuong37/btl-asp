namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        public int? age { get; set; }

        [StringLength(200)]
        public string address { get; set; }
        [StringLength(20)]
        public string province { get; set; }
        [StringLength(20)]
        public string district { get; set; }
        [StringLength(20)]
        public string commune { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }


        [StringLength(11)]
        public string phone { get; set; }

        public bool? isAdmin { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu ít nhất 8 kí tự")]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        [Compare("password", ErrorMessage = "Xác nhận mật khẩu không khớp. Nhập lại!")]
        public string confirmPassword { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? modifyDate { get; set; }

        public bool? status { get; set; }

        [Key]
        public int userId { get; set; }
    }
}
