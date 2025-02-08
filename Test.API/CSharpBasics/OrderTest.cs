using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class OrderTest //Inheritance
    {
        public int id;
        public int Quantity { get; set; } 

        public decimal ComputeTotalOrder(decimal price)
        {
            var total = price * Quantity;
            return total;
        }
    }
}
