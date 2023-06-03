namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.EntityFramework;

using Reservation = webapi.Domain.Reservation.Model.Reservation.Reservation;
using ReservationModel = webapi.Infrastructure.Database.Model.Reservation;
using webapi.Domain.Reservation.Model.Reservation;
using webapi.Domain.Reservation.Repository;

public class ReservationRepository : IReservationRepository {
    readonly ApplicationDbContext db;

    public ReservationRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public Reservation? GetByUserId(int userId) {
        ReservationModel? reservationModel = db.Reservations
            .Where(c => c.ReservationUserId == userId)
            .FirstOrDefault();

        if(reservationModel == null) return null;

        return GetById(new ReservationId(reservationModel.Guid));
    }

    public Reservation GetById(ReservationId reservationId) {
        ReservationModel? reservationModel = db.Reservations
            .Include(c => c.Books)
            .Where(c => c.Guid == reservationId.Id)
            .FirstOrDefault();

        if(reservationModel == null) throw new ApplicationException($"Cart with id: {reservationId} doesnt exist.");

        List<Book> books = new List<Book>();
        foreach(var book in reservationModel.Books) {
            if(book.ThumbnailPath != null) {
                books.Add(new Book(book.Id, book.Title, book.Author, book.ThumbnailPath));
            }
        }

        Reservation reservation = new Reservation(new UserId(reservationModel.ReservationUserId), new ReservationId(reservationId.Id), books);

        return reservation;
    }

    public void Add(Reservation reservation) {
        ReservationModel reservationModel = new ReservationModel() {
            Guid = reservation.ReservationId.Id,
            ReservationUserId = reservation.UserId.Id,
            User = db.Users.Where(user => user.Id == reservation.UserId.Id).First()
        };
        foreach(Book book in reservation.Books) {
            reservationModel.Books.Add(
                db.Books.Where(bookModel => bookModel.Id == book.Id).First()
            );
        }
        db.Reservations.Add(reservationModel);
        db.SaveChanges();
    }

    public void Save(Reservation reservation) {
        ReservationModel reservationModel = db.Reservations
            .Include(c => c.Books)
            .Include(c => c.User)
            .Where(c => c.Guid == reservation.ReservationId.Id)
            .First();

        reservationModel.ReservationUserId = reservation.UserId.Id;
        reservationModel.User = db.Users.Where(user => user.Id == reservation.UserId.Id).First();

        reservationModel.Books.Clear();
        foreach(Book book in reservation.Books) {
            reservationModel.Books.Add(
                db.Books.Where(bookModel => bookModel.Id == book.Id).First()
            );
        }
        
        db.Reservations.Update(reservationModel);
        db.SaveChanges();
    }

    public void Remove(ReservationId reservationId) {
        db.Carts.Remove(
            db.Carts.Where(cart => cart.Guid == reservationId.Id).First()
        );
        db.SaveChanges();
    }
}
