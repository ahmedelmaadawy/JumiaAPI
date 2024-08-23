using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public int CartId { get; set; }
        public ShoppingCart? Cart { get; set; }

    }
}
