namespace webapi.Application.Query.Reservation.Reservation;

public interface IReservationQuery {
    public Task<ReservationDto?> Execute(int userId);
}