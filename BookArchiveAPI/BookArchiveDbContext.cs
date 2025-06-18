using BookArchiveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookArchiveAPI
{
    public class BookArchiveDbContext(DbContextOptions<BookArchiveDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
        }
    }
}
