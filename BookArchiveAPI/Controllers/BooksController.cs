using BookArchiveAPI.Models;
using BookArchiveAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookArchiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(BookService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await service.GetAllBooksAsync();

            if (books == null || books.Count == 0)
            {
                return NotFound("No books found.");
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await service.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            return Ok(book);
        }

        [HttpGet("bygenre")]
        public async Task<IActionResult> GetBooksByGenre([FromQuery] BookGenre genre)
        {
            var books = await service.FilterBooksByGenreAsync(genre);

            if (books == null || books.Count == 0)
            {
                return NotFound($"No books found for genre {genre}.");
            }

            return Ok(books);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortBooks([FromQuery] bool ascending)
        {
            try
            {
                var sortedBooks = await service.SortBooksByCreationDate(ascending);
                return Ok(sortedBooks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
