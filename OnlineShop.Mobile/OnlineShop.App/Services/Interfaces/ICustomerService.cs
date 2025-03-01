using OnlineShop.App.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<SystemUserDTO>> GetCustomers();
        Task<SystemUserDTO> GetCustomerById(int id);
        Task AddCustomer(SystemUserDTO systemUserDTO);
        Task UpdateCustomer(SystemUserDTO systemUserDTO);
        Task DeleteCustomer(int id);
    }
}
