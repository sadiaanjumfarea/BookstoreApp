using Microsoft.AspNetCore.Mvc;
using BookstoreApp.API.Generators;
using BookstoreApp.API.Models;

namespace BookstoreApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        // GET: api/books
        [HttpGet]
        public IActionResult GetBooks(
            [FromQuery] string locale = "en",
            [FromQuery] int seed = 42,
            [FromQuery] int page = 1,
            [FromQuery] double avgLikes = 1.2,
            [FromQuery] double avgReviews = 2.5,
            [FromQuery] int pageSize = 20)
        {
            var books = BookGenerator.GenerateBooks(locale, seed, page, avgLikes, avgReviews, pageSize);
            return Ok(books); // returns JSON automatically
        }
    }
}
