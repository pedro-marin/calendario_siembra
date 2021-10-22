using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace calendario.Models
{
    public partial class innodbContext : DbContext
    {
        public innodbContext()
        {
        }

        public innodbContext(DbContextOptions<innodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Categoriacultivo> Categoriacultivos { get; set; }
        public virtual DbSet<Cultivo> Cultivos { get; set; }
        public virtual DbSet<Detallecultivo> Detallecultivos { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Tiporecurso> Tiporecursos { get; set; }
        public virtual DbSet<Tiporiego> Tiporiegos { get; set; }
        public virtual DbSet<Tiposuelo> Tiposuelos { get; set; }
        public virtual DbSet<Tipotecnica> Tipotecnicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=database-1.c7n0wczozya6.sa-east-1.rds.amazonaws.com;port=3306;user=admin;password=calendario;database=innodb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.12-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
            });

            modelBuilder.Entity<Categoriacultivo>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaCultivo)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Cultivo>(entity =>
            {
                entity.HasKey(e => e.IdCultivo)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasOne(d => d.IdCategoriaCultivoNavigation)
                    .WithMany(p => p.Cultivos)
                    .HasForeignKey(d => d.IdCategoriaCultivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cultivo_CategoriaCultivo");

                entity.HasOne(d => d.IdDetalleCultivoNavigation)
                    .WithMany(p => p.Cultivos)
                    .HasForeignKey(d => d.IdDetalleCultivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cultivo_DetalleCultivo");
            });

            modelBuilder.Entity<Detallecultivo>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCultivo)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasOne(d => d.IdTipoRiegoNavigation)
                    .WithMany(p => p.Detallecultivos)
                    .HasForeignKey(d => d.IdTipoRiego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCultivo_TipoRiego");

                entity.HasOne(d => d.IdTipoSueloNavigation)
                    .WithMany(p => p.Detallecultivos)
                    .HasForeignKey(d => d.IdTipoSuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCultivo_TipoSuelo");

                entity.HasOne(d => d.IdTipoTecnicaNavigation)
                    .WithMany(p => p.Detallecultivos)
                    .HasForeignKey(d => d.IdTipoTecnica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCultivo_TipoTecnica");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.HasKey(e => e.IdRecurso)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasOne(d => d.IdCultivoNavigation)
                    .WithMany(p => p.Recursos)
                    .HasForeignKey(d => d.IdCultivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recurso_Cultivo");

                entity.HasOne(d => d.IdTipoRecursoNavigation)
                    .WithMany(p => p.Recursos)
                    .HasForeignKey(d => d.IdTipoRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recurso_TipoRecurso");
            });

            modelBuilder.Entity<Tiporecurso>(entity =>
            {
                entity.HasKey(e => e.IdTipoRecurso)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Tiporiego>(entity =>
            {
                entity.HasKey(e => e.IdTipoRiego)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Tiposuelo>(entity =>
            {
                entity.HasKey(e => e.IdTipoSuelo)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Tipotecnica>(entity =>
            {
                entity.HasKey(e => e.IdTipoTecnica)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
