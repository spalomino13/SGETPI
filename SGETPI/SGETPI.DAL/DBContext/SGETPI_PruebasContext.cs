using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SGETPI.Model.Models;

namespace SGETPI.DAL.DBContext
{
    public partial class SGETPI_PruebasContext : DbContext
    {
        public SGETPI_PruebasContext()
        {
        }

        public SGETPI_PruebasContext(DbContextOptions<SGETPI_PruebasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditoriaSesiones> AuditoriaSesiones { get; set; } = null!;
        public virtual DbSet<Departamentos> Departamentos { get; set; } = null!;
        public virtual DbSet<Modulos> Modulos { get; set; } = null!;
        public virtual DbSet<Permisos> Permisos { get; set; } = null!;
        public virtual DbSet<Roles> Roles { get; set; } = null!;
        public virtual DbSet<Sesiones> Sesiones { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosDepartamentos> UsuariosDepartamentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<AuditoriaSesiones>(entity =>
            {
                entity.HasKey(e => e.IdAuditoria)
                    .HasName("auditoria_sesiones_pkey");

                entity.ToTable("auditoria_sesiones");

                entity.Property(e => e.IdAuditoria)
                    .HasColumnName("id_auditoria")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.FechaAcceso)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_acceso")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IpAcceso).HasColumnName("ip_acceso");

                entity.Property(e => e.Navegador).HasColumnName("navegador");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AuditoriaSesiones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auditoria_sesiones_id_usuario_fkey");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("departamentos_pkey");

                entity.ToTable("departamentos");

                entity.Property(e => e.IdDepartamento)
                    .HasColumnName("id_departamento")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.IdSupervisor).HasColumnName("id_supervisor");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdSupervisor)
                    .HasConstraintName("departamentos_id_supervisor_fkey");
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("modulos_pkey");

                entity.ToTable("modulos");

                entity.Property(e => e.IdModulo)
                    .HasColumnName("id_modulo")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasMany(d => d.IdPermisos)
                    .WithMany(p => p.IdModulos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ModulosPermiso",
                        l => l.HasOne<Permisos>().WithMany().HasForeignKey("IdPermiso").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("modulos_permisos_id_permiso_fkey"),
                        r => r.HasOne<Modulos>().WithMany().HasForeignKey("IdModulo").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("modulos_permisos_id_modulo_fkey"),
                        j =>
                        {
                            j.HasKey("IdModulo", "IdPermiso").HasName("modulos_permisos_pkey");

                            j.ToTable("modulos_permisos");

                            j.IndexerProperty<Guid>("IdModulo").HasColumnName("id_modulo");

                            j.IndexerProperty<Guid>("IdPermiso").HasColumnName("id_permiso");
                        });
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("permisos_pkey");

                entity.ToTable("permisos");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("id_permiso")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Nombre).HasColumnName("nombre");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("roles_pkey");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasMany(d => d.IdPermisos)
                    .WithMany(p => p.IdRols)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolesPermiso",
                        l => l.HasOne<Permisos>().WithMany().HasForeignKey("IdPermiso").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("roles_permisos_id_permiso_fkey"),
                        r => r.HasOne<Roles>().WithMany().HasForeignKey("IdRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("roles_permisos_id_rol_fkey"),
                        j =>
                        {
                            j.HasKey("IdRol", "IdPermiso").HasName("roles_permisos_pkey");

                            j.ToTable("roles_permisos");

                            j.IndexerProperty<Guid>("IdRol").HasColumnName("id_rol");

                            j.IndexerProperty<Guid>("IdPermiso").HasColumnName("id_permiso");
                        });
            });

            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.HasKey(e => e.IdSesion)
                    .HasName("sesiones_pkey");

                entity.ToTable("sesiones");

                entity.Property(e => e.IdSesion)
                    .HasColumnName("id_sesion")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_inicio")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Sesiones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sesiones_id_usuario_fkey");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("usuarios_pkey");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_registro")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.TipoUsuario).HasColumnName("tipo_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("usuarios_id_rol_fkey");
            });

            modelBuilder.Entity<UsuariosDepartamentos>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdDepartamento })
                    .HasName("usuarios_departamentos_pkey");

                entity.ToTable("usuarios_departamentos");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.FechaAsignacion)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_asignacion")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.UsuariosDepartamentos)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_departamentos_id_departamento_fkey");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosDepartamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuarios_departamentos_id_usuario_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
