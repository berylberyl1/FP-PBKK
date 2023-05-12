namespace webapi.Infrastructure.Database.Model;

using System.ComponentModel.DataAnnotations;

public class Book {
    [Key] public int Id { get; set; }
    [Required] public string? Title { get; set; }
    [Required] public string? Author { get; set; }
    public string? ThumbnailPath { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}