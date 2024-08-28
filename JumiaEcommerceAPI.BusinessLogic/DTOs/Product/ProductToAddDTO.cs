using System.ComponentModel.DataAnnotations;

namespace JumiaEcommerceAPI.BusinessLogic.DTOs.Product
{
    public class ProductToAddDTO
    {
        [Required(ErrorMessage = "Product Name Is required")]
        [Length(5, 50, ErrorMessage = "Product Name must be between 5 and 50 characters")]
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

    }
}
