namespace webapi.Domain.Catalogue.Repository;

using webapi.Domain.Catalogue.Model;

public interface IBookRepository {
    Book? GetById(int id);
    IEnumerable<Book> GetAll();
}
