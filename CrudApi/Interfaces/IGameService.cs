using CrudApi.Dtos.Games;
using CrudApi.Services;

namespace CrudApi.Interfaces;

public interface IGameService
{
    public Task<ServiceResult<IEnumerable<GameDto>>> GetAllGamesAsync();
    public Task<ServiceResult<GameDto?>> GetGameByIdAsync(Guid id);
    public Task<ServiceResult<GameDto>> CreateGameAsync(GameCreateDto gameCreateDto);
    public Task<ServiceResult<GameDto?>> UpdateGameAsync(Guid id, GameUpdateDto gameUpdateDto);
    public Task<ServiceResult<bool>> DeleteGameAsync(Guid id);
}
