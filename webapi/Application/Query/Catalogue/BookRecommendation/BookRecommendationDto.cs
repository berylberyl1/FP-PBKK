namespace webapi.Application.Query.Catalogue.BookRecommendation;

public class BookRecommendationDto {
    public List<BooksDto> Books { get; set; } = new List<BooksDto>();
}