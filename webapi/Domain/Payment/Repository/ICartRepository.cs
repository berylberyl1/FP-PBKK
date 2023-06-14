namespace webapi.Domain.Payment.Repository;

using webapi.Domain.Payment.Model.Cart;

public interface ICartRepository {
    Task Add(Cart cart);
    Task Save(Cart cart);
    Task Remove(CartId cartId);
    Task<Cart?> GetByUserId(int userId);
    Task<Cart> GetById(CartId id);
}