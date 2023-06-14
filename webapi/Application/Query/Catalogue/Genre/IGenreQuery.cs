namespace webapi.Application.Query.Catalogue.Genre;

public interface IGenreQuery {
    IAsyncEnumerable<GenreDto> Execute();
}
