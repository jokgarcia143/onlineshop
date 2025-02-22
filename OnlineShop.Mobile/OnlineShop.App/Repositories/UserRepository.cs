using OnlineShop.App.Configuration;
using OnlineShop.App.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.App.Repositories
{
    public class UserRepository
    {
        readonly SQLiteAsyncConnection _connection;
        public string statusMessage { get; set; }
        public UserRepository()
        {
             _connection = new SQLiteAsyncConnection(DBConfig.DatabasePath);
            _connection.CreateTableAsync<SystemUser>();
        }
        //C>R>U>D
        public async Task Add(SystemUser user)
        {
            int result = 0;
            try
            {
                
                result = await _connection.InsertAsync(user);
                statusMessage = $"{result} row(s) added";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
            }
        }
        public async Task AddOrUpdate(SystemUser user)
        {
            int result = 0;
            try
            {
                if(user.Id != 0)
                {
                    result = await _connection.UpdateAsync(user);
                    statusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = await _connection.InsertAsync(user);
                    statusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
            }
        }
        public async Task<List<SystemUser>> GetUsers() 
        {
            try
            {
                return await _connection.Table<SystemUser>().ToListAsync();
            }
            catch (Exception ex )
            {
                statusMessage = $"Error {ex.Message}";
                return null;
            }
        }
        public async Task<SystemUser> GetUserById(int id) 
        {
            try
            {
                return await _connection.Table<SystemUser>().FirstOrDefaultAsync( u =>  u.Id == id);
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
                return null;
            }
        }
        public async Task DeleteUser(int userId) 
        {
            try
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    _connection.DeleteAsync(user);
                }
                else 
                {
                    statusMessage = $"{user.Result.UserName} does not exist";
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
            }
        }
    }
}
