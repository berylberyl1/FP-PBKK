namespace webapi.Domain.Catalogue.Model.Book;

public class Book {
    public int Id { get; private init; }
    public string? Title { get; private set; }
    public string? Author { get; private set; }
    public string? Summary { get; private set; }
    public string? ThumbnailPath { get; private set; }
    public int Page { get; private set; }
    public string? Edition { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public Franchise? Franchise { get; set; }
    public List<string>? Genres { get; private set; }

    public Book(
        int id,
        string? title,
        string? author,
        string? summary,
        string? thumbnailPath,
        int page,
        string? edition,
        DateTime publicationDate,
        Franchise? franchise,
        List<string>? genres
    ) {
        Id = id;
        Title = title;
        Author = author;
        Summary = summary;
        ThumbnailPath = thumbnailPath;
        Page = page;
        Edition = edition;
        PublicationDate = publicationDate;
        Franchise = franchise;
        Genres = genres;
    }
}
