namespace webapi.Domain.Catalogue.Model;

public class Book {
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }
    public string? ThumbnailPath { get; init; }
    public List<string>? Genres { get; init; }
}
