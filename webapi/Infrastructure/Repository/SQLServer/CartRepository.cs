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
                books.Add(new Book(book.Title, book.Author, book.ThumbnailPath));
            }
        }

        Cart cart = new Cart(new CartId(cartId.Id), books);

        return cart;
    }

    public void Save(Cart cart) {
        throw new NotImplementedException();
    }
}
