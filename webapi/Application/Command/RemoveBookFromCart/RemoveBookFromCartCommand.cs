namespace webapi.Application.Command.RemoveBookFromCart;

using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;
using webapi.Domain.Payment.Repository;
using webapi.Domain.Payment.Service;

using PaymentBook = webapi.Domain.Payment.Model.Cart.Book;

public class RemoveBookFromCartCommand {
    IBookRepository bookRepository;
    ICartRepository cartRepository;

    public RemoveBookFromCartCommand(
        IBookRepository bookRepository,
        ICartRepository cartRepository
    ) {
        this.bookRepository = bookRepository;
        this.cartRepository = cartRepository;
    }

    public async Task Execute(RemoveBookFromCartRequest request) {
        Book book = await bookRepository.GetById(request.BookId);

        CartService cartService = new CartService(cartRepository);
        await cartService.RemoveBookFromCart(request.UserId, new PaymentBook(
            book.Id,
            book.Title,
            book.Author,
            book.ThumbnailPath ?? ""
        ));
    }
}