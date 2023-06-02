namespace webapi.Application.Query.Payment.BookInCart;

public interface IBookInCartQuery {
    BookInCartDto? Execute(int userId, int id);    
}