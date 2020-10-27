namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        public int discountId { get; set; }

        [Required]
        [StringLength(100)]
        public string discountName { get; set; }

        public int value { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        [StringLength(10)]
        public string applyType { get; set; }

        public int limit { get; set; }

        [StringLength(20)]
        public string customerId { get; set; }

        [StringLength(20)]
        public string categoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string type { get; set; }

        public bool? status { get; set; }
    }
}
