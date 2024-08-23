using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ShopName { get; set; }
        [Required]
        public string? Description { get; set; }
        public int? Rating { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
