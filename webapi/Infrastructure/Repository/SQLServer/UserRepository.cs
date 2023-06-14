namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using webapi.Domain.Account.Repository;
using webapi.Infrastructure.Database.EntityFramework;

using User = webapi.Domain.Account.Model.User;
using UserModel = webapi.Infrastructure.Database.Model.User;

public class UserRepository : IUserRepository {
    readonly ApplicationDbContext db;

    public UserRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public async Task Add(User entity) {
        UserModel userModel = new UserModel() {
            FullName = entity.FullName,
            Email = entity.Email,
            Password = entity.Password
        };

        await db.Users.AddAsync(userModel);
        db.SaveChanges();
    }

    public void Delete(User entity) {
        // if (!db.Genres.Contains(entity)) return;

        // db.Genres.Remove(entity);
        // db.SaveChanges();
    }

    public async IAsyncEnumerable<User> GetAll() {
        foreach(UserModel userModel in db.Users.ToList()) {
            User? user = await GetById(userModel.Id);
            if(user == null) continue;

            yield return user;
        }
    }

    public async Task<User?> GetFirst(string email, string password) {
        UserModel? userModel = await db.Users.Where(user => 
            user.Email == email && user.Password == password
        ).FirstOrDefaultAsync();

        if(userModel == null) return null;

        return new User() {
            Id = userModel.Id,
            FullName = userModel.FullName,
            Email = userModel.Email,
            Password = userModel.Password
        };
    }

    public async Task<User?> GetById(int id) {
        UserModel? userModel = await db.Users.FindAsync(id);

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
