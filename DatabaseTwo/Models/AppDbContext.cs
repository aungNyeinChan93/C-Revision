using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTwo.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.Author)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Despcription).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
