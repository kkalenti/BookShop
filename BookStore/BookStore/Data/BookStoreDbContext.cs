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
    }
}