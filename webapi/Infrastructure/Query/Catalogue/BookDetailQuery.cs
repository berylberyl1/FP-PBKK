namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.BookDetail;
using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;

public class BookDetailQuery : IBookDetailQuery {
    IBookRepository repository;

    public BookDetailQuery(IBookRepository repository) {
        this.repository = repository;
    }

    public BookDetailDto Execute(int id) {
        Book? book = repository.GetById(id);

        if(book == null) throw new ApplicationException($"Book with id: {id} doesn't exist.");

        return new BookDetailDto {
            Title = book.Title,
            Author = book.Author,
            Edition = book.Edition,
            PublicationDate = book.PublicationDate.ToString("dd/MM/yyyy"),
            SeriesName = book.Franchise?.Name,
            SeriesNumber = book.Franchise?.Number ?? 0,
            Page = book.Page,
            ImageUrl = "/api/book/image/" + book.ThumbnailPath?.Split('\\')[1],
            Summary = book.Summary
        };
    }
}