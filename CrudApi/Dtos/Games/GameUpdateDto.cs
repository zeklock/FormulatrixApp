namespace CrudApi.Dtos.Games;

public class GameUpdateDto
{
    public required string Title { get; set; }
    public int ReleaseYear { get; set; } = DateTime.Now.Year;
    public Guid? GenreId { get; set; }
}
