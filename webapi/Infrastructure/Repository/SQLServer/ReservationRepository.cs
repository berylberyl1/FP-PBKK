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

    public async Task<Reservation?> GetByUserId(int userId) {
        ReservationModel? reservationModel = await db.Reservations
            .Where(c => c.ReservationUserId == userId)
            .FirstOrDefaultAsync();

        if(reservationModel == null) return null;

        return await GetById(new ReservationId(reservationModel.Guid));
    }

    public async Task<Reservation> GetById(ReservationId reservationId) {
        ReservationModel? reservationModel = await db.Reservations
            .Include(c => c.Books)
            .Where(c => c.Guid == reservationId.Id)
            .FirstOrDefaultAsync();

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

    public async Task Add(Reservation reservation) {
        ReservationModel reservationModel = new ReservationModel() {
            Guid = reservation.ReservationId.Id,
            ReservationUserId = reservation.UserId.Id,
            User = await db.Users.Where(user => user.Id == reservation.UserId.Id).FirstAsync()
        };
        foreach(Book book in reservation.Books) {
            reservationModel.Books.Add(
                await db.Books.Where(bookModel => bookModel.Id == book.Id).FirstAsync()
            );
        }
        await db.Reservations.AddAsync(reservationModel);
        db.SaveChanges();
    }

    public async Task Save(Reservation reservation) {
        ReservationModel reservationModel = await db.Reservations
            .Include(c => c.Books)
            .Include(c => c.User)
            .Where(c => c.Guid == reservation.ReservationId.Id)
            .FirstAsync();

        reservationModel.ReservationUserId = reservation.UserId.Id;
        reservationModel.User = await db.Users.Where(user => user.Id == reservation.UserId.Id).FirstAsync();

        reservationModel.Books.Clear();
        foreach(Book book in reservation.Books) {
            reservationModel.Books.Add(
                await db.Books.Where(bookModel => bookModel.Id == book.Id).FirstAsync()
            );
        }
        
        db.Reservations.Update(reservationModel);
        db.SaveChanges();
    }

    public async Task Remove(ReservationId reservationId) {
        db.Carts.Remove(
            await db.Carts.Where(cart => cart.Guid == reservationId.Id).FirstAsync()
        );
        db.SaveChanges();
    }
}
