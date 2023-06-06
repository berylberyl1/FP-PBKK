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
    public IActionResult Get(int id) {
        BookDetailDto book = bookDetailQuery.Execute(id);
        BookRecommendationDto recommendation = bookRecommendationQuery.Execute(id, 4);
        return Ok(new {
            Book = book,
            Recommendation = recommendation
        });
    }

    [AllowAnonymous]
    [HttpGet("Image/{filename}")]
    public IActionResult Get(string filename) {
        var imagePath = Path.Combine(environment.WebRootPath, "Images", filename);
        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, MimeTypesMap.GetMimeType(imagePath));
    }

    [Authorize]
    [HttpGet("{id}/Read/file.epub")]
    public IActionResult GetBookContent(int id) {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)  {
            return BadRequest("User is not authorized");
        }
        
        BookInReservationDto? book = bookInReservationQuery.Execute(Int32.Parse(userId), id);
        if(book == null) return BadRequest("Book hasn't been reserved");

        var bookPath = Path.Combine(environment.WebRootPath, "Books", "64-foundation.epub");
        var bookBytes = System.IO.File.ReadAllBytes(bookPath);
        return File(bookBytes, MimeTypesMap.GetMimeType(bookPath));
    }
}
