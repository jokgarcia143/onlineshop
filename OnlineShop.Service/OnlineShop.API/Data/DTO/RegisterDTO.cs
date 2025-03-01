using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Data.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
    }
}
