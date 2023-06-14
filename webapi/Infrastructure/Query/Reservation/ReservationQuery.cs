namespace webapi.Infrastructure.Query.Reservation;

using webapi.Application.Query.Reservation.Reservation;
using webapi.Domain.Reservation.Repository;
using webapi.Domain.Reservation.Model.Reservation;

public class ReservationQuery : IReservationQuery {
    IReservationRepository reservationRepository;

    public ReservationQuery(
        IReservationRepository reservationRepository
    ) {
        this.reservationRepository = reservationRepository;
    }

    public async Task<ReservationDto?> Execute(int userId) {
        Reservation? reservation = await reservationRepository.GetByUserId(userId);
        if(reservation == null) return null;

        ReservationDto reservationDto = new ReservationDto();
        foreach(Book book in reservation.Books) {
            reservationDto.Books.Add(new BookDto() {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ThumbnailUrl = "/api/book/image/" + book.Thumbnail?.Split('\\')[1]
            });
        }

        return reservationDto;
    }
}