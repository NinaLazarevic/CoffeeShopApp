using CoffeeShopApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopApp.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdminData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = AppRoles.AdministratorRoleId,
                    Name = AppRoles.AdministratorRole,
                    NormalizedName = AppRoles.AdministratorRole.ToUpper()
                },
                new IdentityRole()
                {
                    Id = AppRoles.EmployeeRoleId,
                    Name = AppRoles.EmployeeRole,
                    NormalizedName = AppRoles.EmployeeRole.ToUpper()
                }
            );

            var testAdmin = new EmployeeModel()
            {
                Id = Guid.Parse(AppAdminData.AdminId),
                UserName = AppAdminData.Username,
                NormalizedUserName = AppAdminData.Username.ToUpper(),
                Email = AppAdminData.Email,
                NormalizedEmail = AppAdminData.Email.ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                SecurityStamp = new Guid().ToString("D"),
                FirstName = AppAdminData.FirstName,
                LastName = AppAdminData.LastName,
                DateofBirth = AppAdminData.DateofBirth,
                JMBG = AppAdminData.JMBG,
                DateDeleted = AppAdminData.DateDeleted
            };

            testAdmin.PasswordHash = PasswordGenerate(testAdmin);

            modelBuilder.Entity<EmployeeModel>().HasData(
                    testAdmin
                );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>()
                    {
                        RoleId = Guid.Parse(AppRoles.AdministratorRoleId),
                        UserId = Guid.Parse(AppAdminData.AdminId)
                    }
                );
        }

        public static string PasswordGenerate(EmployeeModel user)
        {
            var passHash = new PasswordHasher<EmployeeModel>();
            return passHash.HashPassword(user, "Test123!");
        }
    }

    public static class AppAdminData
    {
        public static string AdminId = "978663d3-d310-455f-94c4-3c7a58868c5f";

        public static string Username = "testadmin";

        public static string Email = "testadmin@coffeeshop.app";

        //public static string HashedPassword = "AQAAAAEAACcQAAAAEORt9VwAa7DVDbKqsl9MQMWvSKgvLveBBBOFZ5Yw3Jjw7ZNRSXNpXetWjeMspq4x3w==";

        public static string FirstName = "Test";

        public static string LastName = "Admin";

        public static DateTime DateofBirth = new DateTime(1980, 1, 1);

        public static Nullable<DateTime> DateDeleted = null;

        public static string JMBG = "0101980563922";
    }

    public static class AppRoles
    {
        public const string AdministratorRole = "Admin";

        public const string AdministratorRoleId = "d595e861-62f6-48c9-90c5-376f635cc26d";

        public const string EmployeeRole = "Employee";

        public const string EmployeeRoleId = "7995a0b7-b149-480c-965e-9e5be525ec56";
    }
}
