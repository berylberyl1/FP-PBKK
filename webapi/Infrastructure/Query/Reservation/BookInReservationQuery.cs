namespace webapi.Infrastructure.Payment.BookInCartQuery;

using webapi.Application.Query.Reservation.BookInReservation;
using webapi.Domain.Reservation.Model.Reservation;
using webapi.Domain.Reservation.Repository;

public class BookInReservationQuery : IBookInReservationQuery {
    IReservationRepository repository;

    public BookInReservationQuery(IReservationRepository repository) {
        this.repository = repository;
    }

    public BookInReservationDto? Execute(int userId, int id) {
        Reservation? cart = repository.GetByUserId(userId);

        if(cart == null) return null;

        foreach(Book book in cart.Books) {
            if(book.Id == id) {
                return new BookInReservationDto {
                    Id = book.Id
                };
            }
        }

        return null;
    }
}