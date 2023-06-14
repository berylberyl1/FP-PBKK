namespace webapi.Application.Query.Payment.BookInCart;

public interface IBookInCartQuery {
    Task<BookInCartDto?> Execute(int userId, int id);    
}