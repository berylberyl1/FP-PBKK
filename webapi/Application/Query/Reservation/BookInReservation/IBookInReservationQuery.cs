namespace webapi.Application.Query.Reservation.BookInReservation;

public interface IBookInReservationQuery {
    Task<BookInReservationDto?> Execute(int userId, int id);    
}