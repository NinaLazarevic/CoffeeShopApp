using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopApp.Data.Migrations
{
    public partial class SeedTestAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56",
                column: "ConcurrencyStamp",
                value: "e560fb8f-9056-467f-8b46-c4e6ac23f174");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d",
                column: "ConcurrencyStamp",
                value: "0a95eb6b-c558-4471-a074-10524af526b0");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateDeleted", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "JMBG", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), 0, "05a9392e-7a91-45a0-bd57-d2145c34689a", null, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@coffeeshop.app", true, "Master", "0101980563922", "Admin", false, null, "ADMIN@COFFEESHOP.APP", "ADMIN", "AQAAAAEAACcQAAAAEORt9VwAa7DVDbKqsl9MQMWvSKgvLveBBBOFZ5Yw3Jjw7ZNRSXNpXetWjeMspq4x3w==", null, true, "00000000-0000-0000-0000-000000000000", false, "admin" });

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("0cc1a9e2-41ea-4c5c-af13-9053a449fd19"), new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateDeleted", "DateofBirth", "Email", "EmailConfirmed", "FirstName", "JMBG", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), 0, "5cbfbeec-5360-4f71-a65b-2b2f796db4fc", null, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testadmin@coffeeshop.app", true, "Test", "0101980563922", "Admin", false, null, "TESTADMIN@COFFEESHOP.APP", "TESTADMIN", "AQAAAAEAACcQAAAAEPHQMV7Sq7KZ+/MvASqhLe0qvaVgzaGAVhmQNGnfZreypME++cMbM+zf74lFC0uYbw==", null, true, "00000000-0000-0000-0000-000000000000", false, "testadmin" });

            migrationBuilder.InsertData(
                table: "EmployeeUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), "5cbfbeec-5360-4f71-a65b-2b2f796db4fc" });

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56",
                column: "ConcurrencyStamp",
                value: "b111f86b-4186-4f6f-89d4-09814ca2772c");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d",
                column: "ConcurrencyStamp",
                value: "4b5d0a62-fd74-4424-9439-74962d497c74");

        }
    }
}
