namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using webapi.Infrastructure.Database.Model;
using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;

using Book = webapi.Domain.Catalogue.Model.Book.Book;
using BookModel = webapi.Infrastructure.Database.Model.Book;
using System.Globalization;

public class BookRepository : IBookRepository {
    readonly ApplicationDbContext db;

    public BookRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public void Add(Book entity) {
        // BookModel bookModel = new BookModel() {

        // }
        // if(db.Books.Contains()) return;

        // db.Books.Add(entity);
        // db.SaveChanges();
    }

    public void Delete(Book entity) {
        // if (!db.Books.Contains(entity)) return;

        // db.Books.Remove(entity);
        // db.SaveChanges();
    }

    public IEnumerable<Book> GetAll() {
        foreach(BookModel bookModel in db.Books.ToList()) {
            Book? book = GetById(bookModel.Id);
            if(book == null) continue;

            yield return book;
        }
    }

    public Book? GetById(int id) {
        BookModel? bookModel = db.Books.Find(id);

        if(bookModel == null) return null;

        List<string> genres = new List<string>();
        foreach(Genre genre in bookModel.Genres) {
            if(genre.Name == null) continue;

            genres.Add(genre.Name);
        }

        DateTime publicationDate = new DateTime(
            bookModel.PublicationYear,
            DateTime.ParseExact(bookModel.PublicationMonth ?? "January", "MMMM", CultureInfo.CurrentCulture).Month,
            bookModel.PublicationDay
        );

        Franchise? franchise = bookModel.Series != null? new Franchise() {
            Name = bookModel.Series,
            Number = bookModel.SeriesNumber
        } : null;
        
        return new Book(
            bookModel.Id,
            bookModel.Title,
            bookModel.Author,
            bookModel.Summary,
            bookModel.ThumbnailPath,
            bookModel.Page,
            bookModel.Edition,
            publicationDate,
            franchise,
            genres
        );
    }

    public void Update(Book entity) {
        // db.Books.Update(entity);
    }
}
