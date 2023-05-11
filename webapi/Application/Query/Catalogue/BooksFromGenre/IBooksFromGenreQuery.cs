namespace webapi.Application.Query.Catalogue.BooksFromGenre;

public interface IBooksFromGenreQuery {
    BooksFromGenreDto Execute(string genre);
}