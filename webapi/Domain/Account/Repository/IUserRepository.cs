namespace webapi.Domain.Account.Repository;

using webapi.Domain.Account.Model;

public interface IUserRepository {
    Task Add(User entity);
    Task<User?> GetFirst(string email, string password);
    Task<User?> GetById(int id);
    IAsyncEnumerable<User> GetAll();
}
