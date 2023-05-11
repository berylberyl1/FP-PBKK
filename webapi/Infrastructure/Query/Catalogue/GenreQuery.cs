namespace webapi.Infrastructure.Query.Catalogue;

using webapi.Application.Query.Catalogue.Genre;

public class GenreQuery : IGenreQuery {
    public List<GenreDto> Execute() {
        List<GenreDto> genres = new List<GenreDto>();
        foreach(string genre in new []{"Fantasy", "Horror", "Action", "Romance"}) {
            genres.Add(new GenreDto() { Genre = genre });
        }

        return genres;
    }
}
