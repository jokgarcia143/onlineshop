using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Data.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? FullName { get; set; }
        public string? Role { get; set; }
    }
}
