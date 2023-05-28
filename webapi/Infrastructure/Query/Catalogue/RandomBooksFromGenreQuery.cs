namespace webapi.Infrastructure.Query.Catalogue;

using HeyRed.Mime;
using webapi.Application.Query.Catalogue.RandomBooksFromGenre;
using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;
using webapi.Domain.Catalogue.Service;

public class RandomBooksFromGenreQuery : IRandomBooksFromGenreQuery {
    IBookRepository repository;
    IWebHostEnvironment environment;
    ILogger<RandomBooksFromGenreQuery> logger;

    public RandomBooksFromGenreQuery(IBookRepository repository, IWebHostEnvironment environment, ILogger<RandomBooksFromGenreQuery> logger) {
        this.repository = repository;
        this.environment = environment;
        this.logger = logger;
    }

    public RandomBooksFromGenreDto Execute(string genre, int number) {
        logger.LogInformation(environment.WebRootPath);

        List<BooksDto> booksDtos = new List<BooksDto>();
        BookFinder bookFinder = new BookFinder(repository);
        bookFinder.RandomByGenre(genre, number);

        foreach(Book book in bookFinder.RandomByGenre(genre, number)) {
            BooksDto booksDto = new BooksDto() {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ThumbnailUrl = "/api/book/image/" + book.ThumbnailPath?.Split('\\')[1],
            };
            booksDtos.Add(booksDto);
        }

        return new RandomBooksFromGenreDto() {
            Genre = genre,
            Books = booksDtos
        };
    }
}