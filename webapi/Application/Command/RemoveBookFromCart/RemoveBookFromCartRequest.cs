namespace webapi.Application.Command.RemoveBookFromCart;

public class RemoveBookFromCartRequest {
    public int UserId { get; set; }
    public int BookId { get; set; }
}