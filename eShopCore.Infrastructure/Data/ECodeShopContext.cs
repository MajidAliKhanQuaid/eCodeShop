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
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ECodeShopContext(DbContextOptions options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
