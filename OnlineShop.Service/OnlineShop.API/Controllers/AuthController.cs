using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.API.Data.DTO;
using OnlineShop.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<SystemUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        public AuthController(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var user = new SystemUser { UserName = model.UserName, Email = model.Email };
            var result = await  _userManager.CreateAsync(user, model.UserPassword);

            if (result.Succeeded) 
            {
                if (!await _roleManager.RoleExistsAsync(model.Role.ToString()))
                {
                    //Add to Roles Table
                    await _roleManager.CreateAsync(new IdentityRole(model.Role.ToString()));
                }
                //Add Role to User Table
                await _userManager.AddToRoleAsync(user, model.Role);

                return Ok(new { Message = $"{model.UserName} registered successfully" });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.UserPassword))
            {
                //var token =
                return Ok(new { message = "Success!" });
            }

            return Unauthorized();  
        }
    }
}
