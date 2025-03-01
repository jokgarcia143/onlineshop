using Newtonsoft.Json;
using OnlineShop.App.Configuration;
using OnlineShop.App.Services.DTO;
using OnlineShop.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<SystemUserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }
        public async Task AddUser(SystemUserDTO systemUserDTO)
        {
            try
            {
                var json = JsonConvert.SerializeObject(systemUserDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync($"http://10.0.2.2:5143/" + "api/auth/register", content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemUserDTO> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(SystemUserDTO systemUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
