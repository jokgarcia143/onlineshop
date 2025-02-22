using OnlineShop.App.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Interfaces
{
    public interface IUserService
    {
        Task <IEnumerable<SystemUserDTO>> GetUsers();
        Task<SystemUserDTO> GetUserById(int id);
        Task AddUser(SystemUserDTO systemUserDTO);
        Task UpdateUser(SystemUserDTO systemUserDTO);
        Task DeleteUser(int id);
    }
}
