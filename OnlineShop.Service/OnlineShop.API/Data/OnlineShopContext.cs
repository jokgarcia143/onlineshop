using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Models;

namespace OnlineShop.API.Data
{
    public class OnlineShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0PV91DC;Database=BeviOnlineDB;Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}
