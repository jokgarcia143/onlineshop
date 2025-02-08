using System.ComponentModel.DataAnnotations;

namespace Test.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
