using BookArchiveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookArchiveAPI.Services
{
    public class BookService(BookArchiveDbContext context)
    {
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }
    }
}
