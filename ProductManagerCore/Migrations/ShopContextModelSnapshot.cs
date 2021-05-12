﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManager.Model.Entities;

namespace ProductManagerCore.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ProductManager.Model.Entities.ECustomer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("street")
                        .HasColumnType("TEXT");

                    b.Property<string>("zip")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EIllustration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EProductID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("path")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("EProductID");

                    b.ToTable("EIllustration");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.ELineOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContentID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EOrderID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ContentID");

                    b.HasIndex("EOrderID");

                    b.ToTable("LineOrders");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PriceRuler")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EIllustration", b =>
                {
                    b.HasOne("ProductManager.Model.Entities.EProduct", null)
                        .WithMany("Illustrations")
                        .HasForeignKey("EProductID");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.ELineOrder", b =>
                {
                    b.HasOne("ProductManager.Model.Entities.EProduct", "Content")
                        .WithMany()
                        .HasForeignKey("ContentID");

                    b.HasOne("ProductManager.Model.Entities.EOrder", null)
                        .WithMany("Lines")
                        .HasForeignKey("EOrderID");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EOrder", b =>
                {
                    b.HasOne("ProductManager.Model.Entities.ECustomer", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EOrder", b =>
                {
                    b.Navigation("Lines");
                });

            modelBuilder.Entity("ProductManager.Model.Entities.EProduct", b =>
                {
                    b.Navigation("Illustrations");
                });
#pragma warning restore 612, 618
        }
    }
}
