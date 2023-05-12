namespace webapi.Infrastructure.Database.EntityFramework;

using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.Model;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }

    public DbSet<Book> Books { get; set; }
}