using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.API.Data;
using Test.API.Models;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        OnlineShopContext OnlineShopContext { get; set; }
        public UserController()
        {
                OnlineShopContext = new OnlineShopContext();
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] SystemUser user)
        {
            var userExists = OnlineShopContext.SystemUsers.FirstOrDefault(u => u.UserName == user.UserName);
            if (userExists != null)
            {
                return BadRequest("User with same email already exists");
            }
            OnlineShopContext.SystemUsers.Add(user);
            OnlineShopContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
