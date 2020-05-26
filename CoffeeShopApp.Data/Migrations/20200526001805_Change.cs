using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopApp.Data.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(Guid));

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5cbfbeec-5360-4f71-a65b-2b2f796db4fc", "AQAAAAEAACcQAAAAEPHQMV7Sq7KZ+/MvASqhLe0qvaVgzaGAVhmQNGnfZreypME++cMbM+zf74lFC0uYbw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
