namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using webapi.Infrastructure.Database.Model;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;

public class GenreRepository : IRepository<Genre> {
    readonly ApplicationDbContext db;

    public GenreRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public void Add(Genre entity) {
        if(db.Genres.Contains(entity)) return;

        db.Genres.Add(entity);
        db.SaveChanges();
    }

    public void Delete(Genre entity) {
        if (!db.Genres.Contains(entity)) return;

        db.Genres.Remove(entity);
        db.SaveChanges();
    }

    public IEnumerable<Genre> GetAll() {
        return db.Genres.ToList();
    }

    public Genre? GetById(int id) {
        Genre? book = db.Genres.Find(id);
        
        return book;
    }

    public void Update(Genre entity) {
        db.Genres.Update(entity);
    }
}
