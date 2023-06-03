namespace webapi.Domain.Reservation.Model.Reservation;

public class ReservationId {
    public string Id { get; set; }

    public ReservationId(
        string id
    ) {
        Id = id;
    }
}