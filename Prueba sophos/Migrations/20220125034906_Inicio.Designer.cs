﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba_sophos.Models;

namespace Prueba_sophos.Migrations
{
    [DbContext(typeof(VentasContext))]
    [Migration("20220125034906_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prueba_sophos.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("descripcion");

                    b.Property<int?>("Valor")
                        .HasColumnType("int")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("Prueba_sophos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido");

                    b.Property<int?>("Documento")
                        .HasColumnType("int")
                        .HasColumnName("documento");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Prueba_sophos.Models.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("id_cliente");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int")
                        .HasColumnName("id_producto");

                    b.Property<int?>("ValorPagar")
                        .HasColumnType("int")
                        .HasColumnName("valor_pagar");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProducto");

                    b.ToTable("venta");
                });

            modelBuilder.Entity("Prueba_sophos.Models.Ventas", b =>
                {
                    b.HasOne("Prueba_sophos.Models.Usuario", "IdClienteNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__venta__id_client__31EC6D26");

                    b.HasOne("Prueba_sophos.Models.Producto", "IdProductoNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK__venta__id_produc__32E0915F");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("Prueba_sophos.Models.Producto", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Prueba_sophos.Models.Usuario", b =>
                {
                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
