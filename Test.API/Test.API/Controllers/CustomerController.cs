using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public CustomerController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
    }
}
