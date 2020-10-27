namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(20)]
        public string maKH { get; set; }

        [Key]
        [Column(Order = 1)]
        public int commentId { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        public int? like { get; set; }

        public virtual TinTuc TinTuc { get; set; }
    }
}
