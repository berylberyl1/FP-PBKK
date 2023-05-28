namespace webapi.Application.Query.Catalogue.BookRecommendation;

public class BooksDto {
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public string Author { get; init; } = "";
    public string ThumbnailUrl { get; init; } = "";
}