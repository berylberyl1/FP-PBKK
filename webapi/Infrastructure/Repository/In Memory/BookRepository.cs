namespace webapi.Infrastructure.Repository.InMemory;

using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Catalogue.Model;
using webapi.Domain.Catalogue.Repository;

public class BookRepository : IRepository<Book> {
    readonly List<Book> books = new() {
        new Book { Id = 1, Title = "Book1", Author = "Author1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2" },
        new Book { Id = 3, Title = "Book3", Author = "Author3" },
        new Book { Id = 4, Title = "Book4", Author = "Author4" }
    };

    public void Add(Book entity) {
        if (books.Contains(entity)) return;

        books.Add(entity);
    }

    public void Delete(Book entity) {
        if (!books.Contains(entity)) return;

        books.Remove(entity);
    }

    public IEnumerable<Book> GetAll() {
        return books;
    }

    public Book GetById(int id) {
#pragma warning disable CS8603 // Possible null reference return.
        return books.Where(book => book.Id == id).SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void Update(Book entity) {

    }
}
