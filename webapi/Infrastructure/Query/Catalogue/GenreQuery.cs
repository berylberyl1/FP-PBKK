namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.Genre;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.Model;

public class GenreQuery : IGenreQuery {
    IRepository<Genre> repository;

    public GenreQuery(IRepository<Genre> repository) {
        this.repository = repository;
    }

    public List<GenreDto> Execute() {
        List<GenreDto> genres = new List<GenreDto>();
        foreach(Genre genre in repository.GetAll()) {
            genres.Add(new GenreDto() { Genre = genre.Name, Description = genre.Description });
        }

        return genres;
    }
}
