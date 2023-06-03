namespace webapi.Application.Query.Reservation.Reservation;

public interface IReservationQuery {
    public ReservationDto? Execute(int userId);
}