using eCodeShop.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopCore.Infrastructure
{
    public class ECodeShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ECodeShopContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { Id = -1, Email = "user@ds.com", UserName = "ds", Password = "1234", Phone = "0092 123 123", CreatedOnUtc = DateTime.UtcNow, UpdatedOnUtc = DateTime.UtcNow });
        }
    }
}
