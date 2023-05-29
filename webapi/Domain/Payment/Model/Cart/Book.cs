namespace webapi.Domain.Payment.Model.Cart;

public class Book {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Thumbnail { get; set; }
    
    public Book(
        string title, 
        string author,
        string thumbnail
    ) {
        Title = title;
        Author = author;
        Thumbnail = thumbnail;
    }
}