namespace CrudApi.Dtos.Games;

public class GameRequestDto : PaginateRequestDto
{
    public Guid? GenreId { get; set; }
}
