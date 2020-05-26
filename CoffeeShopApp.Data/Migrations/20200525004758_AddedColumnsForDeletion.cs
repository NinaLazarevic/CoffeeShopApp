using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopApp.Data.Migrations
{
    public partial class AddedColumnsForDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Employees",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "7995a0b7-b149-480c-965e-9e5be525ec56",
                column: "ConcurrencyStamp",
                value: "25b2bf9e-2957-419e-b250-6492896d8866");

            migrationBuilder.UpdateData(
                table: "EmployeeRoles",
                keyColumn: "Id",
                keyValue: "d595e861-62f6-48c9-90c5-376f635cc26d",
                column: "ConcurrencyStamp",
                value: "9818628a-dfcf-47d6-b44c-dc84ca7e9231");

        }
    }
}
