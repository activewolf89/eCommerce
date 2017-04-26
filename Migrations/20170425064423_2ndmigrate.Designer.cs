using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eCommerce.Models;

namespace eCommerce.Migrations
{
    [DbContext(typeof(eCommerceContext))]
    [Migration("20170425064423_2ndmigrate")]
    partial class _2ndmigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("eCommerce.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("CustomerName");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("eCommerce.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<int>("CustomerId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("eCommerce.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Description");

                    b.Property<string>("ImgSrc");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("eCommerce.Models.Order", b =>
                {
                    b.HasOne("eCommerce.Models.Customer", "Customer")
                        .WithMany("OrderList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eCommerce.Models.Product", "Product")
                        .WithMany("OrderList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
