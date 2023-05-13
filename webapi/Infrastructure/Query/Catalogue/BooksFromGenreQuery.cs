namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.BooksFromGenre;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.Model;

public class BooksFromGenreQuery : IBooksFromGenreQuery {
    IRepository<Book> repository;
    IWebHostEnvironment environment;
    ILogger<BooksFromGenreQuery> logger;

    public BooksFromGenreQuery(IRepository<Book> repository, IWebHostEnvironment environment, ILogger<BooksFromGenreQuery> logger) {
        this.repository = repository;
        this.environment = environment;
        this.logger = logger;
    }

    public BooksFromGenreDto Execute(string genre) {
        logger.LogInformation(environment.WebRootPath);

        List<BooksDto> booksDtos = new List<BooksDto>();
        foreach(Book book in repository.GetAll()) {
            var path = Path.Combine(environment.WebRootPath, "Images", "0-not-found");
            if(book.ThumbnailPath != null) {
                path = Path.Combine(environment.WebRootPath, book.ThumbnailPath);
            }
            logger.LogInformation(path);
            var thumbnail = File.ReadAllBytes(path);
            BooksDto booksDto = new BooksDto() {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Thumbnail = thumbnail
            };
            booksDtos.Add(booksDto);
        }

        return new BooksFromGenreDto() {
            Genre = "Fantasy",
            Books = booksDtos
        };
    }
}