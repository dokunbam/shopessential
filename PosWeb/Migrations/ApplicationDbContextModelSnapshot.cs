﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PosWeb.Data;

namespace PosWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PosWeb.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

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

            modelBuilder.Entity("PosWeb.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<string>("StoreName");

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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PosWeb.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.Property<int>("StoreId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PosWeb.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<int>("StoreId");

                    b.Property<string>("email");

                    b.Property<string>("phonenumber");

                    b.Property<string>("state");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PosWeb.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.Property<int>("StoreId");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("PosWeb.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("CategoryId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerName");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductName");

                    b.Property<int>("QuantityPurchased");

                    b.Property<DateTime>("SalesDate");

                    b.Property<int?>("SalesOutputId");

                    b.Property<string>("StaffName");

                    b.Property<int>("StoreId");

                    b.Property<decimal>("TotalPrice");

                    b.Property<int>("TransactionId");

                    b.Property<int>("productId");

                    b.HasKey("SaleId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalesOutputId");

                    b.HasIndex("StoreId");

                    b.HasIndex("productId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("PosWeb.Models.SalesDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("SalesOutputId");

                    b.Property<int>("StoreId");

                    b.HasKey("ID");

                    b.HasIndex("SalesOutputId");

                    b.ToTable("SalesDetail");
                });

            modelBuilder.Entity("PosWeb.Models.SalesOutput", b =>
                {
                    b.Property<int>("SalesOutputId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<decimal>("Balance");

                    b.Property<string>("CustomersName");

                    b.Property<int?>("SaleId");

                    b.Property<DateTime>("SalesDate");

                    b.Property<int?>("SalesDetailsID");

                    b.Property<int>("StoreId");

                    b.Property<decimal>("TotalAmountDue");

                    b.Property<decimal>("TotalAmountPaid");

                    b.Property<int>("TransactionId");

                    b.Property<string>("TransactionStaff");

                    b.HasKey("SalesOutputId");

                    b.HasIndex("SaleId");

                    b.HasIndex("SalesDetailsID");

                    b.ToTable("GetSalesOutputs");
                });

            modelBuilder.Entity("PosWeb.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<string>("StaffEmail");

                    b.Property<int>("StoreId");

                    b.Property<int?>("SubStoreId");

                    b.Property<string>("Username");

                    b.Property<string>("password");

                    b.HasKey("StaffId");

                    b.HasIndex("SubStoreId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("PosWeb.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("SalesId");

                    b.Property<string>("StoreName");

                    b.Property<int>("SubStoreId");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PosWeb.Models.SubStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("StaffId");

                    b.Property<int>("StoreId");

                    b.Property<string>("SubStoreName");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("SubStores");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PosWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PosWeb.Models.Category", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationUser", "ApplicationUsers")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("PosWeb.Models.Product", b =>
                {
                    b.HasOne("PosWeb.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PosWeb.Models.Sale", b =>
                {
                    b.HasOne("PosWeb.Models.ApplicationUser")
                        .WithOne("Sales")
                        .HasForeignKey("PosWeb.Models.Sale", "ApplicationUserId");

                    b.HasOne("PosWeb.Models.Category")
                        .WithMany("Sales")
                        .HasForeignKey("CategoryId");

                    b.HasOne("PosWeb.Models.Customer", "Customer")
                        .WithMany("Sale")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PosWeb.Models.SalesOutput")
                        .WithMany("Sales")
                        .HasForeignKey("SalesOutputId");

                    b.HasOne("PosWeb.Models.Store")
                        .WithMany("Sale")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PosWeb.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PosWeb.Models.SalesDetails", b =>
                {
                    b.HasOne("PosWeb.Models.SalesOutput", "SalesOutput")
                        .WithMany()
                        .HasForeignKey("SalesOutputId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PosWeb.Models.SalesOutput", b =>
                {
                    b.HasOne("PosWeb.Models.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId");

                    b.HasOne("PosWeb.Models.SalesDetails")
                        .WithMany("Sales")
                        .HasForeignKey("SalesDetailsID");
                });

            modelBuilder.Entity("PosWeb.Models.Staff", b =>
                {
                    b.HasOne("PosWeb.Models.SubStore")
                        .WithMany("Staffs")
                        .HasForeignKey("SubStoreId");
                });

            modelBuilder.Entity("PosWeb.Models.SubStore", b =>
                {
                    b.HasOne("PosWeb.Models.Store")
                        .WithMany("SubStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
