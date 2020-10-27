namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [StringLength(20)]
        public string maKH { get; set; }

        [Key]
        public int commentId { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        public int? like { get; set; }

        public int newsId { get; set; }

        public virtual TinTuc TinTuc { get; set; }
    }
}
