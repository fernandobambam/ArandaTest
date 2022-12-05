using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public partial class ArandaContext : DbContext, IArandaContext
{
    public ArandaContext()
    {
    }

    public ArandaContext(DbContextOptions<ArandaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_Producto");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
