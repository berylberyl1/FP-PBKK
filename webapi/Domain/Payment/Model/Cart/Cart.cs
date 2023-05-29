namespace webapi.Domain.Payment.Model.Cart;

public class Cart {
    public CartId Id { get; set; }
    public List<Book> Books { get; set; }

    public Cart(
        CartId id, 
        List<Book> books
    ) {
        Id = id;
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