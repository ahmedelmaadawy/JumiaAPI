﻿using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
    }
}
