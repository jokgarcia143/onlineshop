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
        SQLiteConnection _connection;
        public string statusMessage { get; set; }
        
        public UserRepository()
        {
             _connection = new SQLiteConnection(DBConfig.DatabasePath, DBConfig.Flags);
            _connection.CreateTable<SystemUser>();
        }
        
        //C>R>U>D
        public void Add(SystemUser user)
        {
            try
            {
                int result = 0;
                result = _connection.Insert(user);
                statusMessage = $"{result} row(s) added";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
            }
        }
        public List<SystemUser> GetUsers() 
        {
            try
            {
                return _connection.Table<SystemUser>().ToList();
            }
            catch (Exception ex )
            {
                statusMessage = $"Error {ex.Message}";
                return null;
            }
        }
        public SystemUser GetUserById(int id) 
        {
            try
            {
                return _connection.Table<SystemUser>().FirstOrDefault( u =>  u.Id == id);
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
                return null;
            }
        }
        public void DeleteUser(int userId) 
        {
            try
            {
                var user = GetUserById(userId);
                if (user != null)
                {
                    _connection.Delete(user);
                }
                else 
                {
                    statusMessage = $"{user.UserName} does not exist";
                }
            }
            catch (Exception ex)
            {
                statusMessage = $"Error {ex.Message}";
            }
        }
    }
}
