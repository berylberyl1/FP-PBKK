namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapi.Domain.Account.Repository;
using webapi.Domain.Payment.Model.Cart;
using webapi.Domain.Payment.Repository;
using webapi.Infrastructure.Database.EntityFramework;

using Cart = webapi.Domain.Payment.Model.Cart.Cart;
using CartModel = webapi.Infrastructure.Database.Model.Cart;
using BookModel = webapi.Infrastructure.Database.Model.Book;

public class CartRepository : ICartRepository {
    readonly ApplicationDbContext db;

    public CartRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public Cart? GetByUserId(int userId) {
        CartModel? cartModel = db.Carts
            .Where(c => c.CartUserId == userId)
            .FirstOrDefault();

        if(cartModel == null) return null;

        return GetById(new CartId(cartModel.Guid));
    }

    public Cart GetById(CartId cartId) {
        CartModel? cartModel = db.Carts
            .Include(c => c.Books)
            .Where(c => c.Guid == cartId.Id)
            .FirstOrDefault();

        if(cartModel == null) throw new ApplicationException($"Cart with id: {cartId} doesnt exist.");

        List<Book> books = new List<Book>();
        foreach(var book in cartModel.Books) {
            if(book.ThumbnailPath != null) {
                books.Add(new Book(book.Id, book.Title, book.Author, book.ThumbnailPath));
            }
        }

        Cart cart = new Cart(new UserId(cartModel.CartUserId), new CartId(cartId.Id), books);

        return cart;
    }

    public void Add(Cart cart) {
        CartModel cartModel = new CartModel() {
            Guid = cart.CartId.Id,
            CartUserId = cart.UserId.Id,
            User = db.Users.Where(user => user.Id == cart.UserId.Id).First()
        };
        foreach(Book book in cart.Books) {
            cartModel.Books.Add(
                db.Books.Where(bookModel => bookModel.Id == book.Id).First()
            );
        }
        db.Carts.Add(cartModel);
        db.SaveChanges();
    }

    public void Save(Cart cart) {
        CartModel cartModel = db.Carts
            .Include(c => c.Books)
            .Include(c => c.User)
            .Where(c => c.Guid == cart.CartId.Id)
            .First();

        cartModel.CartUserId = cart.UserId.Id;
        cartModel.User = db.Users.Where(user => user.Id == cart.UserId.Id).First();

        cartModel.Books.Clear();
        foreach(Book book in cart.Books) {
            cartModel.Books.Add(
                db.Books.Where(bookModel => bookModel.Id == book.Id).First()
            );
        }
        
        db.Carts.Update(cartModel);
        db.SaveChanges();
    }

    public void Remove(CartId cartId) {
        db.Carts.Remove(
            db.Carts
                .Include(c => c.User)
                .Include(c => c.Books)
                .Where(cart => cart.Guid == cartId.Id).First()
        );
        db.SaveChanges();
    }
}
