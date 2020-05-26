using CoffeeShopApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopApp.Data
{
    public class CoffeeShopDbContext : IdentityDbContext<EmployeeModel, IdentityRole<Guid>, Guid>
    {
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<OrderedProducts> OrderedProducts { get; set; }

        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeModel>(b =>
            {
                b.ToTable("Employees");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.ToTable("EmployeeClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.ToTable("EmployeeLogins");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.ToTable("EmployeeTokens");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("EmployeeRoles");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.ToTable("EmployeeRoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.ToTable("EmployeeUserRoles");
            });

            modelBuilder.Entity<EmployeeModel>()
                .HasMany(o => o.Orders)
                .WithOne(e => e.Employee);

            modelBuilder.Entity<OrderedProducts>().HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.SeedAdminData();

        }
    }
}
