﻿// <auto-generated />
using System;
using Dolce_Vita.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dolce_Vita.Migrations
{
    [DbContext(typeof(DolceVitaContext))]
    [Migration("20181106092902_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dolce_Vita.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Dolce_Vita.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("Name");

                    b.Property<int>("OrdersID");

                    b.Property<string>("Phone");

                    b.Property<string>("Properties");

                    b.HasKey("Id");

                    b.HasIndex("OrdersID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Dolce_Vita.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Properties");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Dolce_Vita.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DishID");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("DishID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Dolce_Vita.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Dolce_Vita.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dolce_Vita.Models.Customer", b =>
                {
                    b.HasOne("Dolce_Vita.Models.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dolce_Vita.Models.Dish", b =>
                {
                    b.HasOne("Dolce_Vita.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dolce_Vita.Models.Order", b =>
                {
                    b.HasOne("Dolce_Vita.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dolce_Vita.Models.User", b =>
                {
                    b.HasOne("Dolce_Vita.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
