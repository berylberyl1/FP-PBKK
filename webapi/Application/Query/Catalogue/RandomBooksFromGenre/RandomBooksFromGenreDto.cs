namespace webapi.Application.Query.Catalogue.RandomBooksFromGenre;

public class RandomBooksFromGenreDto {
    public string? Genre { get; init; }
    public List<BooksDto>? Books { get; init; }
}