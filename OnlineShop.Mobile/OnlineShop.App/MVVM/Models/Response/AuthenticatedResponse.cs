using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.MVVM.Models.Response
{
    public class AuthenticatedResponse
    {
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
