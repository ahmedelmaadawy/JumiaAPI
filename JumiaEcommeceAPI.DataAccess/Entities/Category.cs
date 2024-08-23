using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ParentCategoryId { get; set; }
        public int Level { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
