using CrudApi.Dtos.Games;
using CrudApi.Helpers;

namespace CrudApi.Interfaces;

public interface IGameService
{
    public Result<IEnumerable<GameDto>> GetAllGames();
    public Result<GameDto?> GetGameById(Guid id);
    public Result<GameDto> CreateGame(CreateGameDto game);
    public Result<GameDto?> UpdateGame(Guid id, UpdateGameDto game);
    public Result<GameDto> DeleteGame(Guid id);
}
