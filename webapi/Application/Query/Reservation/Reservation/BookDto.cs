namespace webapi.Application.Query.Reservation.Reservation;

public class BookDto {
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public string Author { get; init; } = "";
    public string ThumbnailUrl { get; init; } = "";
}