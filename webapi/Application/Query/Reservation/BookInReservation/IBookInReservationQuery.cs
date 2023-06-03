namespace webapi.Application.Query.Reservation.BookInReservation;

public interface IBookInReservationQuery {
    BookInReservationDto? Execute(int userId, int id);    
}