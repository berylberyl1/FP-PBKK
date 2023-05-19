namespace webapi.Infrastructure.Database.Model;

using System.ComponentModel.DataAnnotations;

public class Genre {
    [Key] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}