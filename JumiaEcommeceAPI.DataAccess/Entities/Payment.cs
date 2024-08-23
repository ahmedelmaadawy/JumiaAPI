using System.ComponentModel.DataAnnotations;

namespace JumiaEcommeceAPI.DataAccess.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        [Required]
        public string? Status { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
