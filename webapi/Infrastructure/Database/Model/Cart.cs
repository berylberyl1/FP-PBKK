namespace webapi.Infrastructure.Database.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cart {
    [Key] public string Guid { get; set; } = "";
    public ICollection<Book> Books { get; set; } = new List<Book>();
    [ForeignKey("User")] public int CartUserId { get; set; }
    public User? User { get; set; }
}