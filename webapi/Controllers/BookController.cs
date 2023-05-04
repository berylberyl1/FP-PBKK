using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Catalogue.Model;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private static readonly string[] Titles = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Authors = new[]
    {
        "Elthan", "Dede", "Bima"
    };

    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBook")]
    public IEnumerable<Book> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Book
        {
            Id = index,
            Title = Titles[Random.Shared.Next(Titles.Length)],
            Author = Authors[Random.Shared.Next(Authors.Length)]
        })
        .ToArray();
    }
}
