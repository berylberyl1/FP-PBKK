namespace webapi.Application.Query.Catalogue.BookDetail;

public interface IBookDetailQuery {
    Task<BookDetailDto> Execute(int id);    
}