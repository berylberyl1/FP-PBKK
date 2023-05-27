namespace webapi.Controllers;

using HeyRed.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.BookDetail;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase {
    IBookDetailQuery bookDetailQuery;
    IWebHostEnvironment environment;

    public BookController(
        IBookDetailQuery bookDetailQuery,
        IWebHostEnvironment environment
    ) {
        this.bookDetailQuery = bookDetailQuery;
        this.environment = environment;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public BookDetailDto Get(int id) {
        return bookDetailQuery.Execute(id);
    }

    [AllowAnonymous]
    [HttpGet("Image/{filename}")]
    public IActionResult Get(string filename) {
        var imagePath = Path.Combine(environment.WebRootPath, "Images", filename);;
        var imageBytes = System.IO.File.ReadAllBytes(imagePath);
        return File(imageBytes, MimeTypesMap.GetMimeType(imagePath));
    }
}
