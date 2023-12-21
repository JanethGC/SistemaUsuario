using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaUsuario.Models
{
    public partial class AgendaPruebaTecnicaReactContext : DbContext
    {
        public AgendaPruebaTecnicaReactContext()
        {
        }

        public AgendaPruebaTecnicaReactContext(DbContextOptions<AgendaPruebaTecnicaReactContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.HasKey(e => e.IdAgenda)
                    .HasName("PK__Agenda__61ED01614E90385E");

                entity.ToTable("Agenda", "Negocio");

                entity.Property(e => e.IdAgenda).HasColumnName("ID_Agenda");

                entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agenda__ID_Perso__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agenda__ID_Usuar__4D94879B");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__E9916EC10DEC272D");

                entity.ToTable("Persona", "Negocio");

                entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__DE4431C50716D6D2");

                entity.ToTable("Usuario", "Auditoria");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__ID_Pers__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
