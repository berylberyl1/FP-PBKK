namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.BookDetail;
using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;

public class BookDetailQuery : IBookDetailQuery {
    IBookRepository repository;

    public BookDetailQuery(IBookRepository repository) {
        this.repository = repository;
    }

    public async Task<BookDetailDto> Execute(int id) {
        Book book = await repository.GetById(id);

        return new BookDetailDto {
            Title = book.Title,
            Author = book.Author,
            Edition = book.Edition,
            PublicationDate = book.PublicationDate.ToString("dd/MM/yyyy"),
            SeriesName = book.Franchise?.Name,
            SeriesNumber = book.Franchise?.Number ?? 0,
            Page = book.Page,
            ImageUrl = "/api/book/image/" + book.ThumbnailPath?.Split('\\')[1],
            Summary = book.Summary,
            Genre = book.Genres
        };
    }
}