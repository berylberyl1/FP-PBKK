namespace webapi.Application.Query.Catalogue.RandomBooksFromGenre;

public interface IRandomBooksFromGenreQuery {
    Task<RandomBooksFromGenreDto> Execute(string genre, int number);
}