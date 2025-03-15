using Microsoft.IdentityModel.Tokens;
using OnlineShop.API.Models;
using OnlineShop.API.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.API.Services
{
    public class AuthenticationService
    {
        private readonly string _secretKey;
        public AuthenticationService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public AuthenticatedResponse Authenticate(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[] 
                    {
                        new Claim(ClaimTypes.Email, customer.Email)
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticatedResponse { Token = tokenHandler.WriteToken(token), RefreshToken = tokenHandler.WriteToken(token) };
        }
    }
}
