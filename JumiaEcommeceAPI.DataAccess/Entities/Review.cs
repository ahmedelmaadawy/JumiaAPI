using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public virtual Product? Product { get; set; }
    }
}
