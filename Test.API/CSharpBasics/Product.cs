using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Product
    {
        //Access Modifier / Data Type / Name of Prop / 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Dimension { get; set; }
        public decimal Weight { get; set; } = 0.00m; //default value
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public Decimal ComputeSellingPrice(decimal markup) 
        {
            var netPrice = Price + markup;
            return netPrice;
        }

    }
}
