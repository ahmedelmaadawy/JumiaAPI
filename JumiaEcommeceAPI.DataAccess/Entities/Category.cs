using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; } = null;
        public int Level { get; set; }
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
