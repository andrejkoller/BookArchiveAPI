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
    }
}
