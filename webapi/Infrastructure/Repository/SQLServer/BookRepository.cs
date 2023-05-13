namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using webapi.Infrastructure.Database.Model;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;

public class BookRepository : IRepository<Book> {
    readonly ApplicationDbContext db;

    public BookRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public void Add(Book entity) {
        if(db.Books.Contains(entity)) return;

        db.Books.Add(entity);
        db.SaveChanges();
    }

    public void Delete(Book entity) {
        if (!db.Books.Contains(entity)) return;

        db.Books.Remove(entity);
        db.SaveChanges();
    }

    public IEnumerable<Book> GetAll() {
        return db.Books.ToList();
    }

    public Book? GetById(int id) {
        Book? book = db.Books.Find(id);
        
        return book;
    }

    public void Update(Book entity) {
        db.Books.Update(entity);
    }
}
