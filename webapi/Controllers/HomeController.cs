namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.RandomBooksFromGenre;
using webapi.Application.Query.Catalogue.Genre;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase {
    IGenreQuery genreQuery;
    IRandomBooksFromGenreQuery booksFromGenreQuery;

    public HomeController(IGenreQuery genreQuery, IRandomBooksFromGenreQuery booksFromGenreQuery) {
        this.genreQuery = genreQuery;
        this.booksFromGenreQuery = booksFromGenreQuery;
    }

    [HttpGet]
    public IActionResult Get() {
        var genreResult = genreQuery.Execute();
        var booksFromGenreResults = new List<RandomBooksFromGenreDto>();
        foreach(GenreDto genreDto in genreResult) {
            if(genreDto.Genre == null) continue;
            booksFromGenreResults.Add(booksFromGenreQuery.Execute(genreDto.Genre, 5));
        }
        var data = new { Genre = genreResult, RandomBooksFromGenre = booksFromGenreResults };
        return Ok(data);
    }
}
