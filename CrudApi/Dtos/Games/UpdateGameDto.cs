namespace CrudApi.Dtos.Games;

public class UpdateGameDto
{
    public required string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Guid? GenreId { get; set; }
}
