namespace webapi.Controllers;

using HeyRed.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.BookDetail;
using webapi.Application.Query.Catalogue.BookRecommendation;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase {
    IBookDetailQuery bookDetailQuery;
    IBookRecommendationQuery bookRecommendationQuery;
    IWebHostEnvironment environment;

    public BookController(
        IBookDetailQuery bookDetailQuery,
        IBookRecommendationQuery bookRecommendationQuery,
        IWebHostEnvironment environment
    ) {
        this.bookDetailQuery = bookDetailQuery;
        this.bookRecommendationQuery = bookRecommendationQuery;
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
        var imagePath = Path.Combine(environment.WebRootPath, "Images", filename);;
        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, MimeTypesMap.GetMimeType(imagePath));
    }
}
