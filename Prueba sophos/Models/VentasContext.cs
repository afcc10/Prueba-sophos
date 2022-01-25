using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba_sophos.Models
{
    public partial class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventas> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ANDRES-PC\\SQLEXPRESS;Database=Ventas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.ToTable("venta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.ValorPagar).HasColumnName("valor_pagar");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__venta__id_client__31EC6D26");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__venta__id_produc__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
