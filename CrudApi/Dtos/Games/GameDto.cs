using CrudApi.Dtos.Genres;

namespace CrudApi.Dtos.Games;

public class GameDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public int ReleaseYear { get; set; } = DateTime.Now.Year;
    public GenreDto? Genre { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
