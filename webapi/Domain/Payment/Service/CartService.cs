namespace webapi.Domain.Payment.Service;

using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;

public class CartService {
    ICartRepository cartRepository;

    public CartService(ICartRepository cartRepository) {
        this.cartRepository = cartRepository;
    }

    public void AddBookToCart(int userId, Book book) {
        Cart? cart = cartRepository.GetByUserId(userId);

        if(cart == null) cart = new Cart(
            new CartId(Guid.NewGuid().ToString()), 
            new List<Book>()
        );

        cart.AddBookToCart(book);
        cartRepository.Save(cart);
    }

    public void RemoveBookFromCart(int userId, Book book) {
        Cart? cart = cartRepository.GetByUserId(userId);

        if(cart == null) throw new ApplicationException($"User with id: {userId} doesn't have a cart. Can't remove {book} from cart.");

        cart.RemoveBookFromCart(book);
        cartRepository.Save(cart);
    }
}