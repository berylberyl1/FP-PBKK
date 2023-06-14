namespace webapi.Infrastructure.Payment.BookInCartQuery;

using webapi.Application.Query.Payment.BookInCart;
using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;

public class BookInCartQuery : IBookInCartQuery {
    ICartRepository repository;

    public BookInCartQuery(ICartRepository repository) {
        this.repository = repository;
    }

    public async Task<BookInCartDto?> Execute(int userId, int id) {
        Cart? cart = await repository.GetByUserId(userId);

        if(cart == null) return null;

        foreach(Book book in cart.Books) {
            if(book.Id == id) {
                return new BookInCartDto {
                    Id = book.Id
                };
            }
        }

        return null;
    }
}