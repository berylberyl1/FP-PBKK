namespace webapi.Infrastructure.Repository.SQLServer;

using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Catalogue.Repository;
using webapi.Infrastructure.Database.EntityFramework;

using Genre = webapi.Domain.Catalogue.Model.Genre;
using GenreModel = webapi.Infrastructure.Database.Model.Genre;

public class GenreRepository : IGenreRepository {
    readonly ApplicationDbContext db;

    public GenreRepository(ApplicationDbContext db) {
        this.db = db;
    }

    public void Add(Genre entity) {
        // if(db.Genres.Contains(entity)) return;

        // db.Genres.Add(entity);
        // db.SaveChanges();
    }

    public void Delete(Genre entity) {
        // if (!db.Genres.Contains(entity)) return;

        // db.Genres.Remove(entity);
        // db.SaveChanges();
    }

    public IEnumerable<Genre> GetAll() {
        foreach(GenreModel genreModel in db.Genres.ToList()) {
            Genre? genre = GetById(genreModel.Id);
            if(genre == null) continue;

            yield return genre;
        }
    }

    public Genre? GetById(int id) {
        GenreModel? genreModel = db.Genres.Find(id);

        if(genreModel == null) return null;
        
        return new Genre(
            genreModel.Id,
            genreModel.Name,
            genreModel.Description
        );
    }

    public void Update(Genre entity) {
        // db.Genres.Update(entity);
    }
}
