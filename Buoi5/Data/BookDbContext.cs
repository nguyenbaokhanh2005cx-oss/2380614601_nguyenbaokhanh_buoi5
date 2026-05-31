using Buoi5.Models;
using Microsoft.EntityFrameworkCore;

namespace Buoi5.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Title).IsUnicode(true).HasColumnType("nvarchar(150)");
            entity.Property(e => e.Author).IsUnicode(true).HasColumnType("nvarchar(150)");
            entity.Property(e => e.Description).IsUnicode(true).HasColumnType("nvarchar(max)");
            entity.Property(e => e.Image).HasColumnType("nvarchar(300)");
            entity.Property(e => e.Price).HasColumnType("decimal(18,0)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName).IsUnicode(true).HasColumnType("nvarchar(150)");
        });
    }
}
