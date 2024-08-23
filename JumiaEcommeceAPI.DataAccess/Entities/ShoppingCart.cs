namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
