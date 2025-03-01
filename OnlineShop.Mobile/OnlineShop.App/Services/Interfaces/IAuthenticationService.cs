using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> Authenticate(string username, string password);
    }
}
