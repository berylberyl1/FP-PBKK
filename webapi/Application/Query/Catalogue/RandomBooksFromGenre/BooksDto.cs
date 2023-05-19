namespace webapi.Application.Query.Catalogue.RandomBooksFromGenre;

public class BooksDto {
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }
    public byte[]? Thumbnail { get; init; }
    public string? MimeType { get; init; }
}