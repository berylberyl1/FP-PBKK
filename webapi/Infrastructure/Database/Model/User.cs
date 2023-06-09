namespace webapi.Infrastructure.Database.Model;

using System.ComponentModel.DataAnnotations;

public class User {
    [Key] public int Id { get; set; }
    [Required] public string? FullName { get; set; }
    [Required] public string? Email { get; set; }
    [Required] public string? Password { get; set; }
    public Cart? Cart { get; set; }
    public Reservation? Reservation { get; set; }
}