using Microsoft.EntityFrameworkCore;
using Test.API.Models;

namespace Test.API.Data
{
    public class OnlineShopContext : DbContext
    {
        //DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0PV91DC;Database=BeviOnlineDB;Integrated Security=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Order>().HasNoKey();
            
            modelBuilder.Entity<Product>(p => 
            {
                p.Property(p => p.Price).HasColumnType("decimal(18,2)");
                p.Property(p => p.Weight).HasColumnType("decimal(18,2)");
            });
        }
    }
}
