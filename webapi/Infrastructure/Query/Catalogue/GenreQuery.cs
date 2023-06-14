namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.Genre;
using webapi.Domain.Catalogue.Model;
using webapi.Domain.Catalogue.Repository;

public class GenreQuery : IGenreQuery {
    IGenreRepository repository;

    public GenreQuery(IGenreRepository repository) {
        this.repository = repository;
    }

    public async IAsyncEnumerable<GenreDto> Execute() {
        await foreach(Genre genre in repository.GetAll()) {
            yield return new GenreDto() { Genre = genre.Name, Description = genre.Description };
        }
    }
}
