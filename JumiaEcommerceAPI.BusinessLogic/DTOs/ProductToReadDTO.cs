namespace JumiaEcommerceAPI.BusinessLogic.DTOs
{
    public class ProductToReadDTO
    {
        public string? Name { get; set; }
        public string? Details { get; set; }
        public string? Specifications { get; set; }

        public string? KeyFeatures { get; set; }
        public string? Color { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; } = 0;

        public string? CategoryName { get; set; }
    }
}
