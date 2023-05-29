namespace webapi.Application.Command.AddBookToCart;

public class AddBookToCartRequest {
    public int UserId { get; set; }
    public int BookId { get; set; }
}