namespace webapi.Domain.Account.Repository;

using webapi.Domain.Account.Model;

public interface IUserRepository {
    void Add(User entity);
    User? GetFirst(string email, string password);
    User? GetById(int id);
    IEnumerable<User> GetAll();
}
