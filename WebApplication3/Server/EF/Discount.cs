namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public int discountId { get; set; }

        [Required]
        [StringLength(100)]
        public string discountName { get; set; }

        public int value { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        public DateTime? createdAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? endDate { get; set; }

        public int applyToProduct { get; set; }

        public int limit { get; set; }

        public int applyToCustomer { get; set; }

        [Required]
        [StringLength(15)]
        public string type { get; set; }

        public bool? status { get; set; }

        [StringLength(20)]
        public string customerName { get; set; }

        [StringLength(20)]
        public string productName { get; set; }
    }
}
