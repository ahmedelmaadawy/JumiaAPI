using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(5, 50)]
        public string? Name { get; set; }
        [Required, MaxLength(1500)]
        public string? Details { get; set; }
        [Required, MaxLength(1500)]
        public string? Specifications { get; set; }
        [Required, MaxLength(1500)]

        public string? KeyFeatures { get; set; }
        public string? Color { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Range(0, 100)]
        public int? Discount { get; set; } = 0;

        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<ProductImage>? Images { get; set; }
        public virtual Seller? Seller { get; set; }
        public virtual Category? Category { get; set; }
    }
}
