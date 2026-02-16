using CrudApi.Entities;

namespace CrudApi.Interfaces;

public interface IGameRepository
{
    public Task<IEnumerable<Game>> GetAllGamesAsync();
    public Task<Game?> GetGameByIdAsync(Guid id);
    public Task<Game> CreateGameAsync(Game game);
    public Task<Game?> UpdateGameAsync(Guid id, Game game);
    public Task<bool> DeleteGameAsync(Guid id);
    public Task<bool> TitleExistsAsync(string title, Guid? exceptId = null);
}
