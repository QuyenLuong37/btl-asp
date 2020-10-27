namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingMethod")]
    public partial class ShippingMethod
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }
    }
}
