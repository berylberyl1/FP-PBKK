namespace webapi.Domain.Catalogue.Repository;

using webapi.Domain.Catalogue.Model;

public interface IGenreRepository {
    Task<Genre?> GetById(int id);
    IAsyncEnumerable<Genre> GetAll();
}
