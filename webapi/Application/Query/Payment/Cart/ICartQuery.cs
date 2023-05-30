namespace webapi.Application.Query.Payment.Cart;

public interface ICartQuery {
    public CartDto? Execute(int userId);
}