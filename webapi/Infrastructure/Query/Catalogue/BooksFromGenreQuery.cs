namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.BooksFromGenre;

public class BooksFromGenreQuery : IBooksFromGenreQuery {
    IWebHostEnvironment environment;
    ILogger<BooksFromGenreQuery> logger;

    public BooksFromGenreQuery(IWebHostEnvironment environment, ILogger<BooksFromGenreQuery> logger) {
        this.environment = environment;
        this.logger = logger;
    }

    public BooksFromGenreDto Execute(string genre) {
        logger.LogInformation(environment.WebRootPath);

        var thumbnail = File.ReadAllBytes(Path.Combine(environment.WebRootPath, "Images", "images.png"));

        return new BooksFromGenreDto() {
            Genre = "Fantasy",
            Books = new List<BooksDto>() {
                new BooksDto() { Id = 0, Title = "Avatar", Author = "Dodi", Thumbnail = thumbnail },
                new BooksDto() { Id = 1, Title = "Naruto", Author = "Masashi Kishimoto", Thumbnail = thumbnail },
                new BooksDto() { Id = 2, Title = "One Piece", Author = "Budi", Thumbnail = thumbnail }
            }
        };
    }
}