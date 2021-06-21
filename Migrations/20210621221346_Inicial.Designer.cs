﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPedidosBlazor.DAL;

namespace RegistroPedidosBlazor.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210621221346_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Ordenes", b =>
                {
                    b.Property<int>("OrdenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("SuplidorID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenID");

                    b.HasIndex("SuplidorID");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.OrdenesDetalle", b =>
                {
                    b.Property<int>("OrdenDetalleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<int>("OrdenID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenDetalleID");

                    b.HasIndex("OrdenID");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Productos", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<float>("Inventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoID");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoID = 1,
                            Costo = 23000f,
                            Descripcion = "Samsung TV 50 inch",
                            Inventario = 10f
                        },
                        new
                        {
                            ProductoID = 2,
                            Costo = 50000f,
                            Descripcion = "Estufa electrica",
                            Inventario = 30f
                        },
                        new
                        {
                            ProductoID = 3,
                            Costo = 30000f,
                            Descripcion = "Microondas",
                            Inventario = 25f
                        });
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Suplidores", b =>
                {
                    b.Property<int>("SuplidorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorID");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            SuplidorID = 1,
                            Nombres = "Ricardo Estevez"
                        },
                        new
                        {
                            SuplidorID = 2,
                            Nombres = "Manuel María"
                        },
                        new
                        {
                            SuplidorID = 3,
                            Nombres = "Gilberto Gomez"
                        });
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Ordenes", b =>
                {
                    b.HasOne("RegistroPedidosBlazor.Models.Suplidores", null)
                        .WithMany("Ordenes")
                        .HasForeignKey("SuplidorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.OrdenesDetalle", b =>
                {
                    b.HasOne("RegistroPedidosBlazor.Models.Ordenes", null)
                        .WithMany("Detalle")
                        .HasForeignKey("OrdenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Ordenes", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("RegistroPedidosBlazor.Models.Suplidores", b =>
                {
                    b.Navigation("Ordenes");
                });
#pragma warning restore 612, 618
        }
    }
}
