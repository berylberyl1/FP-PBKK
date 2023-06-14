namespace webapi.Domain.Reservation.Service;

using webapi.Domain.Reservation.Model.Reservation;
using webapi.Domain.Reservation.Repository;

public class ReservationService {
    IReservationRepository reservationRepository;

    public ReservationService(IReservationRepository reservationRepository) {
        this.reservationRepository = reservationRepository;
    }

    public async Task AddBooksToReservation(int userId, List<Book> books) {
        Reservation? reservation = await reservationRepository.GetByUserId(userId);

        if(reservation == null)  {
            reservation = new Reservation(
                new UserId(userId),
                new ReservationId(Guid.NewGuid().ToString()), 
                new List<Book>()
            );
            await reservationRepository.Add(reservation);
        }

        foreach(Book book in books) {
            reservation.AddBookToReservation(book);
        }
        
        await reservationRepository.Save(reservation);
    }

    public async Task AddBookToReservation(int userId, Book book) {
        Reservation? reservation = await reservationRepository.GetByUserId(userId);

        if(reservation == null)  {
            reservation = new Reservation(
                new UserId(userId),
                new ReservationId(Guid.NewGuid().ToString()), 
                new List<Book>()
            );
            await reservationRepository.Add(reservation);
        }

        reservation.AddBookToReservation(book);
        await reservationRepository.Save(reservation);
    }

    public async Task RemoveBookFromReservation(int userId, Book book) {
        Reservation? reservation = await reservationRepository.GetByUserId(userId);

        if(reservation == null) throw new ApplicationException($"User with id: {userId} doesn't have a reservation. Can't remove {book} from reservation.");

        reservation.RemoveBookFromReservation(book);
        await reservationRepository.Save(reservation);
        if(reservation.Books.Count <= 0) await reservationRepository.Remove(reservation.ReservationId);
    }
}