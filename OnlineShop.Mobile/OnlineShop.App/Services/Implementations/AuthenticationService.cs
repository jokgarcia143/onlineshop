using OnlineShop.App.Configuration;
using OnlineShop.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Implementations
{
    internal class AuthenticationService : IAuthenticationService
    {
        public async Task<string> Authenticate(string username, string password)
        {
			try
			{
				var client = new HttpClient();
				var response = await client.GetAsync($"http://10.0.2.2:5143/api/auth/login");

				if (response.IsSuccessStatusCode) 
				{
					var content = await response.Content.ReadAsStringAsync();
					return content;
				}
			}
			catch (Exception)
			{

				throw;
			}
			return "";
        }
		public async Task<string> Login(string username, string password)
        {
			try
			{
				var client = new HttpClient();
				
			}
			catch (Exception)
			{

				throw;
			}
			return "";
        }
    }
}
