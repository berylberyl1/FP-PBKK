namespace webapi.Domain.Catalogue.Repository;

using webapi.Domain.Catalogue.Model;

public interface IGenreRepository {
    Genre? GetById(int id);
    IEnumerable<Genre> GetAll();
}
