namespace webapi.Controllers;

using System.Security.Claims;
using HeyRed.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.BookDetail;
using webapi.Application.Query.Catalogue.BookRecommendation;
using webapi.Application.Query.Reservation.BookInReservation;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase {
    IBookDetailQuery bookDetailQuery;
    IBookRecommendationQuery bookRecommendationQuery;
    IBookInReservationQuery bookInReservationQuery;
    IWebHostEnvironment environment;

    public BookController(
        IBookDetailQuery bookDetailQuery,
        IBookRecommendationQuery bookRecommendationQuery,
        IBookInReservationQuery bookInReservationQuery,
        IWebHostEnvironment environment
    ) {
        this.bookDetailQuery = bookDetailQuery;
        this.bookRecommendationQuery = bookRecommendationQuery;
        this.bookInReservationQuery = bookInReservationQuery;
        this.environment = environment;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        BookDetailDto book = await bookDetailQuery.Execute(id);
        BookRecommendationDto recommendation = await bookRecommendationQuery.Execute(id, 4);
        return Ok(new {
            Book = book,
            Recommendation = recommendation
        });
    }

    [AllowAnonymous]
    [HttpGet("Test")]
    public IActionResult Get() {
        return Ok(new {
           Test = "Test doang" 
        });
    }

    [AllowAnonymous]
    [HttpGet("Image/{filename}")]
    public async Task<IActionResult> Get(string filename) {
        var imagePath = Path.Combine(environment.WebRootPath, "Images", filename);
        var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);
        return File(imageBytes, MimeTypesMap.GetMimeType(imagePath));
    }

    [Authorize]
    [HttpGet("{id}/Read/file.epub")]
    public async Task<IActionResult> GetBookContent(int id) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }
        
        BookInReservationDto? book = await bookInReservationQuery.Execute(Int32.Parse(userId), id);
        if(book == null) return BadRequest("Book hasn't been reserved");

        var bookPath = Path.Combine(environment.WebRootPath, "Books", "64-foundation.epub");
        var bookBytes = await System.IO.File.ReadAllBytesAsync(bookPath);
        return File(bookBytes, MimeTypesMap.GetMimeType(bookPath));
    }
}
