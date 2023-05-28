namespace webapi.Application.Query.Catalogue.BookDetail;

public class BookDetailDto {
    public string? Title { get; init; }
    public string? Author { get; init; }
    public string? Edition { get; init; }
    public string? PublicationDate { get; init; }
    public string? SeriesName { get; init; }
    public int SeriesNumber { get; init; }
    public int Page { get; init; }
    public string? Summary { get; init; }
    public string? ImageUrl { get; init; }
    public List<string>? Genre { get; init; }
}