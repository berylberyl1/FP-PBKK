namespace webapi.Domain.Payment.Model.Cart;

public class CartId {
    public string Id { get; set; }

    public CartId(
        string id
    ) {
        Id = id;
    }
}