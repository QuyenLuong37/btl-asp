namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public DateTime? createdAt { get; set; }

        [StringLength(20)]
        public string updatedAt { get; set; }
    }
}
