namespace webapi.Domain.Payment.Repository;

using webapi.Domain.Payment.Model.Cart;

public interface ICartRepository {
    void Add(Cart cart);
    void Save(Cart cart);
    void Remove(CartId cartId);
    Cart? GetByUserId(int userId);
    Cart GetById(CartId id);
}