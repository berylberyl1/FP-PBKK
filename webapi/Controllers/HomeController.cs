namespace webapi.Controllers;

using Microsoft.AspNetCore.Mvc;
using webapi.Application.Query.Catalogue.RandomBooksFromGenre;
using webapi.Application.Query.Catalogue.Genre;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase {
    IGenreQuery genreQuery;
    IRandomBooksFromGenreQuery booksFromGenreQuery;

    public HomeController(IGenreQuery genreQuery, IRandomBooksFromGenreQuery booksFromGenreQuery) {
        this.genreQuery = genreQuery;
        this.booksFromGenreQuery = booksFromGenreQuery;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Get() {
        var genreResult = genreQuery.Execute();
        var booksFromGenreResults = new List<RandomBooksFromGenreDto>();
        await foreach(GenreDto genreDto in genreResult) {
            if(genreDto.Genre == null) continue;
            booksFromGenreResults.Add(await booksFromGenreQuery.Execute(genreDto.Genre, 9));
        }
        var data = new { Genre = genreResult, RandomBooksFromGenre = booksFromGenreResults };
        return Ok(data);
    }
}
