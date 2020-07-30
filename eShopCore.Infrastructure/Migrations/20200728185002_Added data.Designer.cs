﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShopCore.Infrastructure;

namespace eShopCore.Infrastructure.Migrations
{
    [DbContext(typeof(ECodeShopContext))]
    [Migration("20200728185002_Added data")]
    partial class Addeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCodeShop.Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = -3,
                            Description = "Apply Granny Smith",
                            ImageUrl = "",
                            Name = "Apple",
                            Price = 12.44m
                        },
                        new
                        {
                            Id = -2,
                            Description = "Mango From Multan",
                            ImageUrl = "",
                            Name = "Mango",
                            Price = 14.44m
                        },
                        new
                        {
                            Id = -1,
                            Description = "Orange From Peshawar",
                            ImageUrl = "",
                            Name = "Orange",
                            Price = 155.44m
                        });
                });

            modelBuilder.Entity("eCodeShop.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedOnUtc = new DateTime(2020, 7, 28, 18, 50, 1, 670, DateTimeKind.Utc).AddTicks(6316),
                            Email = "user@ds.com",
                            Password = "1234",
                            Phone = "0092 123 123",
                            UpdatedOnUtc = new DateTime(2020, 7, 28, 18, 50, 1, 670, DateTimeKind.Utc).AddTicks(7020),
                            UserName = "ds"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}