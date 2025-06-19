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

        public async Task<List<Book>> FilterBooksByGenreAsync(BookGenre genre)
        {
            var genreBooks = await context.Books
                .Where(b => b.Genre == genre)
                .ToListAsync();

            var otherBooks = await context.Books
                .Where(b => b.Genre != genre)
                .ToListAsync();

            genreBooks.AddRange(otherBooks);
            return genreBooks;
        }

        public async Task<List<Book>> FilterBooksByFormatAsync(BookFormat format)
        {
            var formatBooks = await context.Books
                .Where(b => b.Format == format)
                .ToListAsync();

            var otherBooks = await context.Books
                .Where(b => b.Format != format)
                .ToListAsync();

            formatBooks.AddRange(otherBooks);
            return formatBooks;
        }

        public async Task<List<Book>> FilterBooksByLanguageAsync(BookLanguage language)
        {
            var languageBooks = await context.Books
                .Where(b => b.Language == language)
                .ToListAsync();

            var otherBooks = await context.Books
                .Where(b => b.Language != language)
                .ToListAsync();

            languageBooks.AddRange(otherBooks);
            return languageBooks;
        }

        public async Task<List<Book>> SortBooksByCreationDate(bool ascending)
        {
            var books = await context.Books.ToListAsync();
            if (ascending)
            {
                return [.. books.OrderBy(b => b.CreatedAt)];
            }
            else
            {
                return [.. books.OrderByDescending(b => b.CreatedAt)];
            }
        }
    }
}
