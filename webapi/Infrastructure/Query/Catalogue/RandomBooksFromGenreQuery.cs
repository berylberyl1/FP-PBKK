namespace webapi.Infrastructure.Query.Catalogue;

using HeyRed.Mime;
using webapi.Application.Query.Catalogue.RandomBooksFromGenre;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.Model;

public class RandomBooksFromGenreQuery : IRandomBooksFromGenreQuery {
    IRepository<Book> repository;
    IWebHostEnvironment environment;
    ILogger<RandomBooksFromGenreQuery> logger;

    public RandomBooksFromGenreQuery(IRepository<Book> repository, IWebHostEnvironment environment, ILogger<RandomBooksFromGenreQuery> logger) {
        this.repository = repository;
        this.environment = environment;
        this.logger = logger;
    }

    public RandomBooksFromGenreDto Execute(string genre, int number) {
        logger.LogInformation(environment.WebRootPath);

        List<BooksDto> booksDtos = new List<BooksDto>();
        
        foreach(Book book in GetRandomBooks(number)) {
            var path = Path.Combine(environment.WebRootPath, "Images", "0-not-found");
            if(book.ThumbnailPath != null) {
                path = Path.Combine(environment.WebRootPath, book.ThumbnailPath);
            }
            logger.LogInformation(path);
            var thumbnail = File.ReadAllBytes(path);
            string mimeType = MimeTypesMap.GetMimeType(path);
            logger.LogInformation(mimeType);
            BooksDto booksDto = new BooksDto() {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Thumbnail = thumbnail,
                MimeType = mimeType
            };
            booksDtos.Add(booksDto);
        }

        return new RandomBooksFromGenreDto() {
            Genre = genre,
            Books = booksDtos
        };
    }

    IEnumerable<Book> GetRandomBooks(int number) {
        List<Book> books = repository.GetAll().ToList();
        Random random = new Random();
        for(int i = 0; i < number; i++) {
            Book randomBook = books[random.Next(0, books.Count-1)];
            books.Remove(randomBook);
            yield return randomBook;
        }
    }
}