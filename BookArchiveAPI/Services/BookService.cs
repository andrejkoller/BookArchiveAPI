using BookArchiveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookArchiveAPI.Services
{
    public class BookService(BookArchiveDbContext context, IWebHostEnvironment env)
    {
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");

            if (book.File == null || book.File.Length == 0)
                throw new ArgumentException("No file uploaded.");

            var uploadsPath = Path.Combine(env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsPath);

            var fileName = Path.GetFileName(book.File.FileName);
            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await book.File.CopyToAsync(stream);

            var relativePath = Path.Combine("uploads", fileName).Replace("\\", "/");

            var bookModel = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                YearPublished = book.YearPublished,
                Summary = book.Summary,
                Note = book.Note,
                FilePath = relativePath,
                FileName = fileName,
                Publisher = book.Publisher,
                PageCount = book.PageCount,
                Format = book.Format,
                Language = book.Language,
                PreviewImage = relativePath
            };

            try
            {
                context.Books.Add(bookModel);
                await context.SaveChangesAsync();
                return bookModel;
            }
            catch (DbUpdateException ex)
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                
                throw new Exception("An error occurred while adding the book.", ex);
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                return false;

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Book> UpdateBookAsync(int id, Book updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentNullException(nameof(updatedBook), "Updated book cannot be null.");

            var book = await context.Books.FindAsync(id) ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
            
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.YearPublished = updatedBook.YearPublished;
            book.Summary = updatedBook.Summary;
            book.Note = updatedBook.Note;
            book.Publisher = updatedBook.Publisher;
            book.PageCount = updatedBook.PageCount;
            book.Format = updatedBook.Format;
            book.Language = updatedBook.Language;

            try
            {
                context.Books.Update(book);
                await context.SaveChangesAsync();
                return book;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while updating the book.", ex);
            }
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
                return [.. books.OrderBy(b => b.CreatedAt)];
            else
                return [.. books.OrderByDescending(b => b.CreatedAt)];
        }

        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllBooksAsync();

            return await context.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{searchTerm}%") ||
                            EF.Functions.Like(b.Author, $"%{searchTerm}%"))
                .ToListAsync();
        }
    }
}
