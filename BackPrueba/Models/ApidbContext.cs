using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackPrueba.Models;

public partial class ApidbContext : DbContext
{
    public ApidbContext()
    {
    }

    public ApidbContext(DbContextOptions<ApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //=> optionsBuilder.UseSqlServer("Server=localhost; Database= APIDB; Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personas__3213E83FCFBC3116");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_paterno");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Eliminado)
                .HasDefaultValueSql("((0))")
                .HasColumnName("eliminado");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
