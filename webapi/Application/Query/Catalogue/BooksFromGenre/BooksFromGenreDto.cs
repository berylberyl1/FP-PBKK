namespace webapi.Application.Query.Catalogue.BooksFromGenre;

public class BooksFromGenreDto {
    public string? Genre { get; init; }
    public List<BooksDto>? Books { get; init; }
}