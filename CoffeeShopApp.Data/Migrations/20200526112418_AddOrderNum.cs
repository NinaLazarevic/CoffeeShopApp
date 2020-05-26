using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopApp.Data.Migrations
{
    public partial class AddOrderNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56",
                column: "ConcurrencyStamp",
                value: "62ec9180-c274-4e98-b515-d0a696f22598");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d",
                column: "ConcurrencyStamp",
                value: "7f26dce9-a665-41e2-b272-e52a3e7a7696");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3ebe175-1557-494e-9b93-84ca82b53be8", "AQAAAAEAACcQAAAAEMb9/0pf+EkGT/J+zsbRi6ivhQzH6alrC1JFz4v/0axv03JSKxJK7W3rLXT5/mu/vw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56",
                column: "ConcurrencyStamp",
                value: "e4c3c083-c439-46ee-83d1-d8946265bbb6");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d",
                column: "ConcurrencyStamp",
                value: "2d7e6af1-36c1-44ab-a0f2-dfc823a62c3c");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45a1b1e8-138b-40b7-8ce9-df42f7689ed2", "AQAAAAEAACcQAAAAEGcjhUoxby+MHp5V1E5ioOV60KTqcvVA/BWv5cU71i8A1oWWG02kJmS9YZRj+IsLmA==" });
        }
    }
}
