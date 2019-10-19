using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HMWeb.Biblioteca.Modelos
{
    public partial class HMContext : DbContext, IHMContext
    {
        public HMContext()
        {
        }

        public HMContext(DbContextOptions<HMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Centros> Centros { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Maquinarias> Maquinarias { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-MN3APRR1\\SQLEXPRESS;Initial Catalog=hm_prueba;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centros>(entity =>
            {
                entity.HasKey(e => e.IdCentro)
                    .HasName("PK_CENTROS");

                entity.Property(e => e.IdCentro).HasColumnName("Id_centro");

                entity.Property(e => e.DesfaseMinutosTurno).HasColumnName("Desfase_minutos_turno");

                entity.Property(e => e.EmailPlanesAccion)
                    .HasColumnName("Email_planes_accion")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmailRrhh)
                    .HasColumnName("Email_rrhh")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_empresa");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaRrhh)
                    .HasColumnName("Referencia_rrhh")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Centros)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_CENTROS_FK_CENTRO_EMPRESAS");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK_EMPRESAS");

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_empresa");

                entity.Property(e => e.IdEmisor).HasColumnName("Id_emisor");

                entity.Property(e => e.Logotipo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaRrhh)
                    .HasColumnName("Referencia_rrhh")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maquinarias>(entity =>
            {
                entity.HasKey(e => e.IdMaquinaria)
                    .HasName("PK_MAQUINARIAS");

                entity.Property(e => e.IdMaquinaria).HasColumnName("Id_maquinaria");

                entity.Property(e => e.Activa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("Fecha_alta")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("Fecha_baja")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCentro).HasColumnName("Id_centro");

                entity.Property(e => e.IdEmpresa).HasColumnName("Id_empresa");

                entity.Property(e => e.IdServicio).HasColumnName("Id_servicio");

                entity.Property(e => e.IndicaKH)
                    .HasColumnName("Indica_K_H")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasColumnName("Numero_serie")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaLecturaHoras)
                    .HasColumnName("Ultima_lectura_horas")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.UltimaLecturaKms)
                    .HasColumnName("Ultima_lectura_kms")
                    .HasColumnType("numeric(12, 2)");

                entity.HasOne(d => d.IdCentroNavigation)
                    .WithMany(p => p.Maquinarias)
                    .HasForeignKey(d => d.IdCentro)
                    .HasConstraintName("Maquinarias_fk2");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Maquinarias)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("Maquinarias_fk");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Maquinarias)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("Maquinarias_fk3");
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK_SERVICIOS");

                entity.ToTable("servicios");

                entity.Property(e => e.IdServicio).HasColumnName("Id_servicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
