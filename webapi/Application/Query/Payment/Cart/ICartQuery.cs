namespace webapi.Application.Query.Payment.Cart;

public interface ICartQuery {
    public Task<CartDto?> Execute(int userId);
}