namespace webapi.Domain.Reservation.Repository;

using webapi.Domain.Reservation.Model.Reservation;

public interface IReservationRepository {
    Task Add(Reservation reservation);
    Task Save(Reservation reservation);
    Task Remove(ReservationId reservationId);
    Task<Reservation?> GetByUserId(int userId);
    Task<Reservation> GetById(ReservationId id);
}