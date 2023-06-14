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

    public async Task<Cart?> GetByUserId(int userId) {
        CartModel? cartModel = await db.Carts
            .Where(c => c.CartUserId == userId)
            .FirstOrDefaultAsync();

        if(cartModel == null) return null;

        return await GetById(new CartId(cartModel.Guid));
    }

    public async Task<Cart> GetById(CartId cartId) {
        CartModel? cartModel = await db.Carts
            .Include(c => c.Books)
            .Where(c => c.Guid == cartId.Id)
            .FirstOrDefaultAsync();

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

    public async Task Add(Cart cart) {
        CartModel cartModel = new CartModel() {
            Guid = cart.CartId.Id,
            CartUserId = cart.UserId.Id,
            User = await db.Users.Where(user => user.Id == cart.UserId.Id).FirstAsync()
        };
        foreach(Book book in cart.Books) {
            cartModel.Books.Add(
                await db.Books.Where(bookModel => bookModel.Id == book.Id).FirstAsync()
            );
        }
        await db.Carts.AddAsync(cartModel);
        db.SaveChanges();
    }

    public async Task Save(Cart cart) {
        CartModel cartModel = await db.Carts
            .Include(c => c.Books)
            .Include(c => c.User)
            .Where(c => c.Guid == cart.CartId.Id)
            .FirstAsync();

        cartModel.CartUserId = cart.UserId.Id;
        cartModel.User = await db.Users.Where(user => user.Id == cart.UserId.Id).FirstAsync();

        cartModel.Books.Clear();
        foreach(Book book in cart.Books) {
            cartModel.Books.Add(
                await db.Books.Where(bookModel => bookModel.Id == book.Id).FirstAsync()
            );
        }
        
        db.Carts.Update(cartModel);
        db.SaveChanges();
    }

    public async Task Remove(CartId cartId) {
        db.Carts.Remove(
            await db.Carts.Where(cart => cart.Guid == cartId.Id).FirstAsync()
        );
        db.SaveChanges();
    }
}
