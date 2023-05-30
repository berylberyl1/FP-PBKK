namespace webapi.Domain.Payment.Model.Cart;

public class Cart {
    public UserId UserId { get; set; }
    public CartId CartId { get; set; }
    public List<Book> Books { get; set; }

    public Cart(
        UserId userId,
        CartId cartId, 
        List<Book> books
    ) {
        UserId = userId;
        CartId = cartId;
        Books = books;
    }

    public void AddBookToCart(Book book) {
        if(Books.Contains(book)) throw new Exception($"There is already {book} in the cart.");

        Books.Add(book);
    }

    public void RemoveBookFromCart(Book book) {
        if(!Books.Contains(book)) throw new Exception($"There is no {book} in the cart.");

        Books.Remove(book);
    }
}