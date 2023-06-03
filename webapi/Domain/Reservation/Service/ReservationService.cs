namespace webapi.Domain.Reservation.Service;

using webapi.Domain.Reservation.Model.Reservation;
using webapi.Domain.Reservation.Repository;

public class ReservationService {
    IReservationRepository reservationRepository;

    public ReservationService(IReservationRepository reservationRepository) {
        this.reservationRepository = reservationRepository;
    }

    public void AddBooksToReservation(int userId, List<Book> books) {
        Reservation? reservation = reservationRepository.GetByUserId(userId);

        if(reservation == null)  {
            reservation = new Reservation(
                new UserId(userId),
                new ReservationId(Guid.NewGuid().ToString()), 
                new List<Book>()
            );
            reservationRepository.Add(reservation);
        }

        foreach(Book book in books) {
            reservation.AddBookToReservation(book);
        }
        
        reservationRepository.Save(reservation);
    }

    public void AddBookToReservation(int userId, Book book) {
        Reservation? reservation = reservationRepository.GetByUserId(userId);

        if(reservation == null)  {
            reservation = new Reservation(
                new UserId(userId),
                new ReservationId(Guid.NewGuid().ToString()), 
                new List<Book>()
            );
            reservationRepository.Add(reservation);
        }

        reservation.AddBookToReservation(book);
        reservationRepository.Save(reservation);
    }

    public void RemoveBookFromReservation(int userId, Book book) {
        Reservation? reservation = reservationRepository.GetByUserId(userId);

        if(reservation == null) throw new ApplicationException($"User with id: {userId} doesn't have a reservation. Can't remove {book} from reservation.");

        reservation.RemoveBookFromReservation(book);
        reservationRepository.Save(reservation);
        if(reservation.Books.Count <= 0) reservationRepository.Remove(reservation.ReservationId);
    }
}