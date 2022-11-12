using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=ProductsDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.ImageName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (50)");
            entity.Property(e => e.Price).HasColumnType("DECIMAL (10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
