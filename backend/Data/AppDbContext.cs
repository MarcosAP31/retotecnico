using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(eb =>
            {
                eb.HasKey(b => b.Id);

                eb.Property(b => b.Title)
                  .IsRequired()
                  .HasMaxLength(250);

                eb.Property(b => b.Author)
                  .IsRequired()
                  .HasMaxLength(200);

                eb.Property(b => b.Year)
                  .IsRequired();

                eb.Property(b => b.Publisher)
                  .IsRequired()
                  .HasMaxLength(200);

                eb.Property(b => b.Pages)
                  .IsRequired();

                eb.Property(b => b.Category)
                  .IsRequired()
                  .HasMaxLength(100);

                eb.Property(b => b.Isbn)
                  .HasMaxLength(50);
            });
        }
    }
}
