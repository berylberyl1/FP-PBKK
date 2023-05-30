namespace webapi.Infrastructure.Query.Payment;

using webapi.Application.Query.Payment.Cart;
using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;

public class CartQuery : ICartQuery {
    ICartRepository cartRepository;

    public CartQuery(
        ICartRepository cartRepository
    ) {
        this.cartRepository = cartRepository;
    }

    public CartDto? Execute(int userId) {
        Cart? cart = cartRepository.GetByUserId(userId);
        if(cart == null) return null;

        CartDto cartDto = new CartDto();
        foreach(Book book in cart.Books) {
            cartDto.Books.Add(new BookDto() {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ThumbnailUrl = "/api/book/image/" + book.Thumbnail?.Split('\\')[1]
            });
        }

        return cartDto;
    }
}