namespace webapi.Infrastructure.Database.EntityFramework;

using Microsoft.EntityFrameworkCore;
using webapi.Infrastructure.Database.Model;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}