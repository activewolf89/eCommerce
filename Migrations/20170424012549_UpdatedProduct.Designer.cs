using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eCommerce.Models;

namespace eCommerce.Migrations
{
    [DbContext(typeof(eCommerceContext))]
    [Migration("20170424012549_UpdatedProduct")]
    partial class UpdatedProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

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

            modelBuilder.Entity("eCommerce.Models.ProductOrder", b =>
                {
                    b.Property<int>("ProductOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("ProductOrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("eCommerce.Models.ProductOrder", b =>
                {
                    b.HasOne("eCommerce.Models.Product")
                        .WithMany("ProductOrderList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
