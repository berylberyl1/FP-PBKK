namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Account.Repository;
using webapi.Infrastructure.Database.EntityFramework;

using User = webapi.Domain.Account.Model.User;
using UserModel = webapi.Infrastructure.Database.Model.User;

public class UserRepository : IUserRepository {
    readonly ApplicationDbContext db;

    public UserRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public void Add(User entity) {
        UserModel userModel = new UserModel() {
            FullName = entity.FullName,
            Email = entity.Email,
            Password = entity.Password
        };

        db.Users.Add(userModel);
        db.SaveChanges();
    }

    public void Delete(User entity) {
        // if (!db.Genres.Contains(entity)) return;

        // db.Genres.Remove(entity);
        // db.SaveChanges();
    }

    public IEnumerable<User> GetAll() {
        foreach(UserModel userModel in db.Users.ToList()) {
            User? user = GetById(userModel.Id);
            if(user == null) continue;

            yield return user;
        }
    }

    public User? GetFirst(string email, string password) {
        var query = db.Users.Where(user => 
            user.Email == email && user.Password == password
        );

        foreach(UserModel userModel in query) {
            return new User() {
                Id = userModel.Id,
                FullName = userModel.FullName,
                Email = userModel.Email,
                Password = userModel.Password
            };
        }
        return null;
    }

    public User? GetById(int id) {
        UserModel? userModel = db.Users.Find(id);

        if(userModel == null) return null;
        
        return new User() {
            Id = userModel.Id,
            FullName = userModel.FullName,
            Email = userModel.Email,
            Password = userModel.Password
        };
    }

    public void Update(User entity) {
        // db.Genres.Update(entity);
    }
}
