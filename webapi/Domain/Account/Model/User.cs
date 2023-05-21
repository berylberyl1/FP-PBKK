namespace webapi.Domain.Account.Model;

public class User {
    public int Id { get; init; }
    public string? FullName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
}
