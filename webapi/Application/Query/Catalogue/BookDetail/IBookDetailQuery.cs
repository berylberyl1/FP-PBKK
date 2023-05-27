namespace webapi.Application.Query.Catalogue.BookDetail;

public interface IBookDetailQuery {
    BookDetailDto Execute(int id);    
}