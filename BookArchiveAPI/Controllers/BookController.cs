using BookArchiveAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookArchiveAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(BookService service) : Controller
    {
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
    }
}
