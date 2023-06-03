namespace webapi.Domain.Reservation.Repository;

using webapi.Domain.Reservation.Model.Reservation;

public interface IReservationRepository {
    void Add(Reservation reservation);
    void Save(Reservation reservation);
    void Remove(ReservationId reservationId);
    Reservation? GetByUserId(int userId);
    Reservation GetById(ReservationId id);
}