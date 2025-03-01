using OnlineShop.App.Services.DTO;
using OnlineShop.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        public Task AddCustomer(SystemUserDTO systemUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SystemUserDTO> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SystemUserDTO>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(SystemUserDTO systemUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
