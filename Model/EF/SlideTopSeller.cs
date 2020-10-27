namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SlideTopSeller
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string shoeId { get; set; }

        public int? position { get; set; }

        public bool? status { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(150)]
        public string title { get; set; }
    }
}
