namespace webapi.Domain.Catalogue.Service;

using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;

public class BookFinder {
    IBookRepository bookRepository;

    public BookFinder(IBookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }

    public IEnumerable<Book> RandomByGenre(int id, string genre, int limit) {
        Random random = new Random();
        List<Book> books = ByGenre(id, genre).ToList();
        for(int i = 0; i < limit; i++) {
            int index = random.Next(0, books.Count-1);
            yield return books[index];
            books.RemoveAt(index);
        }
    }

    public IEnumerable<Book> ByGenre(int id, string genre, int limit) {
        foreach(Book book in ByGenre(id, genre)) {
            yield return book;
            if(--limit <= 0) yield break;
        }
    }

    public IEnumerable<Book> ByGenre(int id, string genre) {
        foreach(Book book in bookRepository.GetAll()) {
            if (book.Id == id) continue;
            if (book.Genres.Contains(genre)) {
                yield return book;
            }
        }
    }
}