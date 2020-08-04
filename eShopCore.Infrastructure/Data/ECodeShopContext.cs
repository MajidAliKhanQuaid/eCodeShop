using eCodeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopCore.Infrastructure.Data
{
    public class ECodeShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ECodeShopContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { Id = -1, Email = "user@ds.com", UserName = "ds", Password = "1234", Phone = "0092 123 123", CreatedOnUtc = DateTime.UtcNow, UpdatedOnUtc = DateTime.UtcNow });
            //
            modelBuilder.Entity<Product>().HasData(new Product() { Id = -3, Name = "Apple", Description = "Apply Granny Smith", ImageUrl = "", Price = 12.44M });
            modelBuilder.Entity<Product>().HasData(new Product() { Id = -2, Name = "Mango", Description = "Mango From Multan", ImageUrl = "", Price = 14.44M });
            modelBuilder.Entity<Product>().HasData(new Product() { Id = -1, Name = "Orange", Description = "Orange From Peshawar", ImageUrl = "", Price = 155.44M });
        }
    }
}
