namespace webapi.Application.Command.Checkout;

using webapi.Domain.Payment.Repository;
using webapi.Domain.Payment.Service;
using webapi.Domain.Reservation.Repository;
using webapi.Domain.Reservation.Service;

using CartBook = webapi.Domain.Payment.Model.Cart.Book;
using ReservationBook = webapi.Domain.Reservation.Model.Reservation.Book;

public class CheckoutCommand {
    ICartRepository cartRepository;
    IReservationRepository reservationRepository;

    public CheckoutCommand(
        ICartRepository cartRepository,
        IReservationRepository reservationRepository
    ) {
        this.cartRepository = cartRepository;
        this.reservationRepository = reservationRepository;
    }

    public async Task Execute(CheckoutRequest request) {
        CartService cartService = new CartService(cartRepository);
        List<CartBook> cartBooks = await cartService.Checkout(request.UserId);

        ReservationService reservationService = new ReservationService(reservationRepository);
        List<ReservationBook> reservedBooks = new List<ReservationBook>();

        foreach(CartBook cartBook in cartBooks) {
            reservedBooks.Add(new ReservationBook(
                cartBook.Id,
                cartBook.Title,
                cartBook.Author,
                cartBook.Thumbnail
            ));
        }

        await reservationService.AddBooksToReservation(request.UserId, reservedBooks);
    }
}