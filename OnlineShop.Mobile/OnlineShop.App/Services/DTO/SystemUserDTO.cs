using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.DTO
{
    
    public class SystemUserDTO
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
    }
}
