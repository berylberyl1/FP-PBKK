namespace webapi.Domain.Payment.Service;

using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;

public class CartService {
    ICartRepository cartRepository;

    public CartService(ICartRepository cartRepository) {
        this.cartRepository = cartRepository;
    }

    public async Task AddBookToCart(int userId, Book book) {
        Cart? cart = await cartRepository.GetByUserId(userId);

        if(cart == null)  {
            cart = new Cart(
                new UserId(userId),
                new CartId(Guid.NewGuid().ToString()), 
                new List<Book>()
            );
            await cartRepository.Add(cart);
        }

        cart.AddBookToCart(book);
        await cartRepository.Save(cart);
    }

    public async Task RemoveBookFromCart(int userId, Book book) {
        Cart? cart = await cartRepository.GetByUserId(userId);

        if(cart == null) throw new ApplicationException($"User with id: {userId} doesn't have a cart. Can't remove {book} from cart.");

        cart.RemoveBookFromCart(book);
        await cartRepository.Save(cart);
        if(cart.Books.Count <= 0) await cartRepository.Remove(cart.CartId);
    }

    public async Task<List<Book>> Checkout(int userId) {
        Cart? cart = await cartRepository.GetByUserId(userId);

        if(cart == null) throw new ApplicationException($"User with id: {userId} doesn't have a cart. Can't checkout.");
        await cartRepository.Remove(cart.CartId);
        return cart.Books;
    }
}