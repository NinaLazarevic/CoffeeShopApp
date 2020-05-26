using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopApp.Data.Migrations
{
    public partial class SeedAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d595e861-62f6-48c9-90c5-376f635cc26d"), "9818628a-dfcf-47d6-b44c-dc84ca7e9231", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7995a0b7-b149-480c-965e-9e5be525ec56"), "25b2bf9e-2957-419e-b250-6492896d8866", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d595e861-62f6-48c9-90c5-376f635cc26d", "9818628a-dfcf-47d6-b44c-dc84ca7e9231", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7995a0b7-b149-480c-965e-9e5be525ec56", "25b2bf9e-2957-419e-b250-6492896d8866", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "JMBG", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), 0, "145a79bd-7bbe-4492-a2c6-810b24ddcbbf", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@coffeeshop.app", true, "Master", "0101980563922", "Admin", false, null, "ADMIN@COFFEESHOP.APP", "ADMIN", "54de7f606f2523cba8efac173fab42fb7f59d56ceff974c8fdb7342cf2cfe345", null, true, "00000000-0000-0000-0000-000000000000", false, "admin" });

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56");

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d");

            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), "145a79bd-7bbe-4492-a2c6-810b24ddcbbf" });
        }
    }
}
