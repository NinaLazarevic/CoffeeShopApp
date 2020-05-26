﻿// <auto-generated />
using System;
using CoffeeShopApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeShopApp.Data.Migrations
{
    [DbContext(typeof(CoffeeShopDbContext))]
    partial class CoffeeShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeShopApp.Data.Models.EmployeeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateofBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("JMBG");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Employees");

                    b.HasData(
                        new { Id = new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), AccessFailedCount = 0, ConcurrencyStamp = "a3ebe175-1557-494e-9b93-84ca82b53be8", DateofBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "testadmin@coffeeshop.app", EmailConfirmed = true, FirstName = "Test", JMBG = "0101980563922", LastName = "Admin", LockoutEnabled = false, NormalizedEmail = "TESTADMIN@COFFEESHOP.APP", NormalizedUserName = "TESTADMIN", PasswordHash = "AQAAAAEAACcQAAAAEMb9/0pf+EkGT/J+zsbRi6ivhQzH6alrC1JFz4v/0axv03JSKxJK7W3rLXT5/mu/vw==", PhoneNumberConfirmed = true, SecurityStamp = "00000000-0000-0000-0000-000000000000", TwoFactorEnabled = false, UserName = "testadmin" }
                    );
                });

            modelBuilder.Entity("CoffeeShopApp.Data.Models.OrderedProducts", b =>
                {
                    b.Property<Guid>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedProducts");
                });

            modelBuilder.Entity("CoffeeShopApp.Data.Models.OrderModel", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateofOrder");

                    b.Property<Guid>("EmployeeId");

                    b.Property<int>("OrderNumber");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CoffeeShopApp.Data.Models.ProductModel", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<float>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");

                    b.HasData(
                        new { Id = "d595e861-62f6-48c9-90c5-376f635cc26d", ConcurrencyStamp = "7f26dce9-a665-41e2-b272-e52a3e7a7696", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "7995a0b7-b149-480c-965e-9e5be525ec56", ConcurrencyStamp = "62ec9180-c274-4e98-b515-d0a696f22598", Name = "Employee", NormalizedName = "EMPLOYEE" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmployeeClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("EmployeeLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeUserRoles");

                    b.HasData(
                        new { UserId = new Guid("978663d3-d310-455f-94c4-3c7a58868c5f"), RoleId = new Guid("d595e861-62f6-48c9-90c5-376f635cc26d") }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("EmployeeTokens");
                });

            modelBuilder.Entity("CoffeeShopApp.Data.Models.OrderedProducts", b =>
                {
                    b.HasOne("CoffeeShopApp.Data.Models.OrderModel", "Order")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoffeeShopApp.Data.Models.ProductModel", "Product")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoffeeShopApp.Data.Models.OrderModel", b =>
                {
                    b.HasOne("CoffeeShopApp.Data.Models.EmployeeModel", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CoffeeShopApp.Data.Models.EmployeeModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CoffeeShopApp.Data.Models.EmployeeModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoffeeShopApp.Data.Models.EmployeeModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CoffeeShopApp.Data.Models.EmployeeModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
