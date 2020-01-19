using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookSection>()
                .HasKey(t => new { t.BookId, t.SectionId });

            modelBuilder.Entity<BookSection>()
                .HasOne(sc => sc.Book)
                .WithMany(s => s.BookSection)
                .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<BookSection>()
                .HasOne(sc => sc.Section)
                .WithMany(c => c.BookSection)
                .HasForeignKey(sc => sc.SectionId);
        }
    }
}