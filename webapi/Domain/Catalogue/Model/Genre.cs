namespace webapi.Domain.Catalogue.Model;

public class Genre {
    public int Id { get; private init; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    public Genre(
        int id,
        string? name,
        string? description
    ) {
        Id = id;
        Name = name;
        Description = description;
    }
}