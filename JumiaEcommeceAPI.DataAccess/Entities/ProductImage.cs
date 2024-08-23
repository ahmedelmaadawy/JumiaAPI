using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte[]? Image { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
