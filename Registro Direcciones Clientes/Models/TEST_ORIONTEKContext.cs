using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Registro_Direcciones_Clientes.Models
{
    public partial class TEST_ORIONTEKContext : DbContext
    {
        public TEST_ORIONTEKContext()
        {
        }

        public TEST_ORIONTEKContext(DbContextOptions<TEST_ORIONTEKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DireccionCliente> DireccionClientes { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JA16UQ0\\SQLEXPRESS;Database=TEST_ORIONTEK;User ID=sa;password=latino005;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__CLIENTE__1EA344C23475623E");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("numeric(8, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<DireccionCliente>(entity =>
            {
                entity.HasKey(e => e.Iddircliente)
                    .HasName("PK__DIRECCIO__6363D5FC8D651411");

                entity.ToTable("DIRECCION_CLIENTE");

                entity.Property(e => e.Iddircliente)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDDIRCLIENTE");

                entity.Property(e => e.Calle)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Idsector)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("IDSECTOR");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.DireccionClientes)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__IDCLI__5812160E");

                entity.HasOne(d => d.IdsectorNavigation)
                    .WithMany(p => p.DireccionClientes)
                    .HasForeignKey(d => d.Idsector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIRECCION__IDSEC__59063A47");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.Idpais)
                    .HasName("PK__PAIS__A38A944927B7499D");

                entity.ToTable("PAIS");

                entity.Property(e => e.Idpais)
                    .HasColumnType("numeric(3, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPAIS");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.Idprovincia)
                    .HasName("PK__PROVINCI__AF1A19D1136CA693");

                entity.ToTable("PROVINCIA");

                entity.Property(e => e.Idprovincia)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPROVINCIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Idpais)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("IDPAIS");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.Idpais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROVINCIA__IDPAI__5165187F");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.Idsector)
                    .HasName("PK__SECTOR__26BAA644C03B27C5");

                entity.ToTable("SECTOR");

                entity.Property(e => e.Idsector)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDSECTOR");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Idprovincia)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("IDPROVINCIA");

                entity.HasOne(d => d.IdprovinciaNavigation)
                    .WithMany(p => p.Sectors)
                    .HasForeignKey(d => d.Idprovincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SECTOR__IDPROVIN__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
