namespace webapi.Domain.Catalogue.Service;

using webapi.Domain.Catalogue.Model.Book;
using webapi.Domain.Catalogue.Repository;

public class BookFinder {
    IBookRepository bookRepository;

    public BookFinder(IBookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }

    public IAsyncEnumerable<Book> RandomByGenre(string genre, int limit) {
        return RandomByGenre(-1, genre, limit);
    }

    public async IAsyncEnumerable<Book> RandomByGenre(int id, string genre, int limit) {
        Random random = new Random();
        List<Book> books = await ByGenre(id, genre).ToListAsync();
        for(int i = 0; i < limit; i++) {
            int index = random.Next(0, books.Count-1);
            yield return books[index];
            books.RemoveAt(index);
        }
    }

    public async IAsyncEnumerable<Book> ByGenre(int id, string genre, int limit) {
        await foreach(Book book in ByGenre(id, genre)) {
            yield return book;
            if(--limit <= 0) yield break;
        }
    }

    public async IAsyncEnumerable<Book> ByGenre(int id, string genre) {
        await foreach(Book book in ByGenre(genre)) {
            if (book.Id == id) continue;
            yield return book;
        }
    }

    public async IAsyncEnumerable<Book> ByGenre(string genre) {
        await foreach(Book book in bookRepository.GetAll()) {
            if (book.Genres.Contains(genre)) {
                yield return book;
            }
        }
    }
}