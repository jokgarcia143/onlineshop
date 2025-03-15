using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Data;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OnlineShopContext _context;
        public ProductController(OnlineShopContext context)
        {
            _context = context;
        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
