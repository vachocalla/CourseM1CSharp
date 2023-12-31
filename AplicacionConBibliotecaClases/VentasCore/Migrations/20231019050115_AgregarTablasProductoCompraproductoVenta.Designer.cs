﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VentasCore;

#nullable disable

namespace VentasCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231019050115_AgregarTablasProductoCompraproductoVenta")]
    partial class AgregarTablasProductoCompraproductoVenta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VentasCore.Cliente", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("VentasCore.CompraProducto", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long?>("Ventaid")
                        .HasColumnType("bigint");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<long>("productoid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("Ventaid");

                    b.HasIndex("productoid");

                    b.ToTable("CompraProductos");
                });

            modelBuilder.Entity("VentasCore.Producto", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("VentasCore.Venta", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long>("clienteid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("fechaVenta")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("VentasCore.CompraProducto", b =>
                {
                    b.HasOne("VentasCore.Venta", null)
                        .WithMany("compraProductos")
                        .HasForeignKey("Ventaid");

                    b.HasOne("VentasCore.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("VentasCore.Venta", b =>
                {
                    b.HasOne("VentasCore.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("VentasCore.Venta", b =>
                {
                    b.Navigation("compraProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
