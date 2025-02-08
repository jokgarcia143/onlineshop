using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.API.Models;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product {Id = 1, Name = "Kojic Soap", Description = "Beauty Soap", Price = 100.45m, SKU = "SKU1", Stock = 50},
            new Product {Id = 2, Name = "Scent Therapy", Description = "Fragrance", Price = 96.23m, SKU = "SKU2", Stock = 10},
            new Product {Id = 3, Name = "DreamWhite", Description = "Beauty Soap", Price = 250.94m, SKU = "SKU3", Stock = 20}
        };
        private readonly ILogger<ProductController> _logger;
        
        //Constructor
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                //return _products.ToArray();
                return _products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }
    }
}
