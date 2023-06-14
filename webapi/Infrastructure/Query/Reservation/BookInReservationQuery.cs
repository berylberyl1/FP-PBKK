namespace webapi.Infrastructure.Payment.BookInCartQuery;

using webapi.Application.Query.Reservation.BookInReservation;
using webapi.Domain.Reservation.Model.Reservation;
using webapi.Domain.Reservation.Repository;

public class BookInReservationQuery : IBookInReservationQuery {
    IReservationRepository repository;

    public BookInReservationQuery(IReservationRepository repository) {
        this.repository = repository;
    }

    public async Task<BookInReservationDto?> Execute(int userId, int id) {
        Reservation? reservation = await repository.GetByUserId(userId);

        if(reservation == null) return null;

        foreach(Book book in reservation.Books) {
            if(book.Id == id) {
                return new BookInReservationDto {
                    Id = book.Id
                };
            }
        }

        return null;
    }
}