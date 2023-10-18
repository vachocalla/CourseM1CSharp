﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppConsolaVentasEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CompraProducto", b =>
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

            modelBuilder.Entity("Producto", b =>
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

            modelBuilder.Entity("Venta", b =>
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

            modelBuilder.Entity("CompraProducto", b =>
                {
                    b.HasOne("Venta", null)
                        .WithMany("compraProductos")
                        .HasForeignKey("Ventaid");

                    b.HasOne("Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("Venta", b =>
                {
                    b.HasOne("Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("Venta", b =>
                {
                    b.Navigation("compraProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
