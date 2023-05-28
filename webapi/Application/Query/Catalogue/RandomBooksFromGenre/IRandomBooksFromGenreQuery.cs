namespace webapi.Application.Query.Catalogue.RandomBooksFromGenre;

public interface IRandomBooksFromGenreQuery {
    RandomBooksFromGenreDto Execute(string genre, int number);
}