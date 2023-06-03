namespace webapi.Domain.Reservation.Model.Reservation;

public class Reservation {
    public UserId UserId { get; set; }
    public ReservationId ReservationId { get; set; }
    public List<Book> Books { get; set; }

    public Reservation(
        UserId userId,
        ReservationId reservationId, 
        List<Book> books
    ) {
        UserId = userId;
        ReservationId = reservationId;
        Books = books;
    }

    public void AddBookToReservation(Book book) {
        if(Books.Contains(book)) throw new Exception($"There is already {book} in the reservation.");

        Books.Add(book);
    }

    public void RemoveBookFromReservation(Book book) {
        if(!Books.Contains(book)) throw new Exception($"There is no {book} in the reservation.");

        Books.Remove(book);
    }
}