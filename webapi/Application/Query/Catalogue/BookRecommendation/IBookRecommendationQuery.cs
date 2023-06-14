namespace webapi.Application.Query.Catalogue.BookRecommendation;

public interface IBookRecommendationQuery {
    Task<BookRecommendationDto> Execute(int id, int limit);
}