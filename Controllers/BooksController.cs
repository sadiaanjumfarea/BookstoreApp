using Microsoft.AspNetCore.Mvc;
using BookstoreApp.API.Generators;

namespace BookstoreApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks(
        [FromQuery] string region = "en_US",
        [FromQuery] int seed = 42,
        [FromQuery] int page = 1,
        [FromQuery] double avgLikes = 3.7,
        [FromQuery] double avgReviews = 4.7)
    {
        var books = BookGenerator.GenerateBooks(region, seed, page, avgLikes, avgReviews);
        return Ok(books);
    }
}
