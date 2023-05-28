namespace webapi.Application.Query.Catalogue.BookRecommendation;

public interface IBookRecommendationQuery {
    BookRecommendationDto Execute(int id, int limit);
}