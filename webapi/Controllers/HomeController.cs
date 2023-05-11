namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.BooksFromGenre;
using webapi.Application.Query.Catalogue.Genre;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase {
    IGenreQuery genreQuery;
    IBooksFromGenreQuery booksFromGenreQuery;

    public HomeController(IGenreQuery genreQuery, IBooksFromGenreQuery booksFromGenreQuery) {
        this.genreQuery = genreQuery;
        this.booksFromGenreQuery = booksFromGenreQuery;
    }

    [HttpGet]
    public IActionResult Get() {
        var genreResult = genreQuery.Execute();
        var booksFromGenreResult = booksFromGenreQuery.Execute("Fantasy");
        // if(booksFromGenreResult.Books != null) {
        //     foreach(var book in booksFromGenreResult.Books) {
        //         if(book.ThumbnailInfo?.Exists) {
        //         PhysicalFile(book.ThumbnailInfo?.PhysicalPath, "image/jpeg");
        //         }
        //     }
        // }

        var data = new { Genre = genreResult, BooksFromGenre = booksFromGenreResult };
        return Ok(data);
    }
}
