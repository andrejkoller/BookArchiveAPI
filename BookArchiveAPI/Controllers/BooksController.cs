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
    }
}
