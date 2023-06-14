namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.BookRecommendation;
using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;
using webapi.Domain.Catalogue.Service;

public class BookRecommendationQuery : IBookRecommendationQuery{
    IBookRepository repository;

    public BookRecommendationQuery(IBookRepository repository) {
        this.repository = repository;
    }

    public async Task<BookRecommendationDto> Execute(int id, int limit) {
        Book book = await repository.GetById(id);

        var recommendation = new BookRecommendationDto();

        Random random = new Random();
        string genre = book.Genres[random.Next(0, book.Genres.Count-1)];
        BookFinder bookFinder = new BookFinder(repository);
        await foreach(Book recBook in bookFinder.RandomByGenre(id, genre, limit)) {
            recommendation.Books.Add(new BooksDto() {
                Id = recBook.Id,
                Title = recBook.Title,
                Author = recBook.Author,
                ThumbnailUrl = "/api/book/image/" + recBook.ThumbnailPath?.Split('\\')[1],
            });
        }

        return recommendation;
    }
}