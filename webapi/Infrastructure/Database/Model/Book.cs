namespace webapi.Infrastructure.Database.Model;

using System.ComponentModel.DataAnnotations;

public class Book {
    [Key] public int Id { get; set; }
    [Required] public string Title { get; set; } = "";
    [Required] public string Author { get; set; } = "";
    public string? ThumbnailPath { get; set; }
    public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    public int Page { get; set; }
    public string? Edition { get; set; }
    public int PublicationDay { get; set; }
    public string? PublicationMonth { get; set; }
    public int PublicationYear { get; set; }
    public string? Series { get; set; }
    public int SeriesNumber { get; set; }
    public string? Summary { get; set; }
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}