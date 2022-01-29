using Aranda.ComponenteAutorizacion.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

#nullable disable

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public MainContext()
        {
        }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<PermisosPorRol> PermisosPorRols { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Sobrecarga del Contructor para recibir connectionString
        /// </summary>
        /// <param name="connectionString">Cadena de Conexion a la base de datos</param>
        public MainContext(string connectionString) : base(GetOptions(connectionString, null)) { }

        public MainContext(string connectionString, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction) : base(GetOptions(connectionString, sqlServerOptionsAction)) { }

        private static DbContextOptions GetOptions(string connectionString, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString, sqlServerOptionsAction).Options;
        }
        /// <summary>
        /// Configuracion de la cadena de conexion
        /// </summary>
        /// <param name="connectionString">Cadena de Conexion a la base de datos</param>
        /// <returns>Opciones de Configuracion de la conexion a la base de datos</returns>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<PermisosPorRol>(entity =>
            {
                entity.HasOne(d => d.Permiso)
                    .WithMany()
                    .HasForeignKey(d => d.PermisoId)
                    .HasConstraintName("FK_PermisosPorRolPermiso");

                entity.HasOne(d => d.Rol)
                    .WithMany()
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_PermisosPorRol");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Contrasena).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany()
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_PersonaUsuario");

                entity.HasOne(d => d.Rol)
                    .WithOne()
                    .HasForeignKey<Usuario>(d => d.RolId)
                    .HasConstraintName("FK_RolUsusario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
