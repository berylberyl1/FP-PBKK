namespace webapi.Domain.Catalogue.Repository;

using webapi.Domain.Catalogue.Model.Book;

public interface IBookRepository {
    Task<Book> GetById(int id);
    IAsyncEnumerable<Book> GetAll();
}
