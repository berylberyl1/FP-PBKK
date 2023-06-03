namespace webapi.Domain.Reservation.Model.Reservation;

public class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Thumbnail { get; set; }
    
    public Book(
        int id,
        string title, 
        string author,
        string thumbnail
    ) {
        Id = id;
        Title = title;
        Author = author;
        Thumbnail = thumbnail;
    }

    public override int GetHashCode() {
        return Id;
    }

    public override bool Equals(object? obj) {
        if (obj == null) return false;
        Book? book= obj as Book;
        if (book == null) return false;
        return Equals(book);
    }

    public bool Equals(Book other) {
        if (other == null) return false;
        return (Id == other.Id);
    }
}