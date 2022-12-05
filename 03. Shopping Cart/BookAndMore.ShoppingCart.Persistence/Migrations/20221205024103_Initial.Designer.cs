﻿// <auto-generated />
using System;
using BookAndMore.ShoppingCart.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookAndMore.ShoppingCart.Persistence.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20221205024103_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAndMore.ShoppingCart.Domain.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shopping_cart_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.HasKey("Id");

                    b.ToTable("Shopping_Carts", (string)null);
                });

            modelBuilder.Entity("BookAndMore.ShoppingCart.Domain.Models.ShoppingCartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shopping_cart_detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AggregationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("aggregation_date");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("SelectedProductId")
                        .HasColumnType("int")
                        .HasColumnName("selected_product_id");

                    b.Property<int>("ShoppingCartDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int")
                        .HasColumnName("shopping_cart_id");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Shopping_Cart_Details", (string)null);
                });

            modelBuilder.Entity("BookAndMore.ShoppingCart.Domain.Models.ShoppingCartDetail", b =>
                {
                    b.HasOne("BookAndMore.ShoppingCart.Domain.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartDetails")
                        .HasForeignKey("ShoppingCartId")
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("BookAndMore.ShoppingCart.Domain.Models.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
