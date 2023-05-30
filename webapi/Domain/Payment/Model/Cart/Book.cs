namespace webapi.Domain.Payment.Model.Cart;

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
}