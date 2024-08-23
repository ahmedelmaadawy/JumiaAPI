using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public string? ShippingAddress { get; set; }
        public virtual ICollection<OrderItem>? Items { get; set; }
    }
}
