using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0.00m;
        public string PaymentMethod { get; set; } //CASH / CC / GCASH
        public int Quantity { get; set; }
       
    }
}
