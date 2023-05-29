namespace webapi.Domain.Payment.Repository;

using webapi.Domain.Payment.Model.Cart;

public interface ICartRepository {
    void Save(Cart cart);
    Cart? GetByUserId(int userId);
    Cart GetById(CartId id);
}