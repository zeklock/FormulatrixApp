using CrudApi.Entities;

namespace CrudApi.Interfaces;

public interface IGameRepository
{
    public Task<List<Game>> GetAllAsync();
    public Task<Game?> GetByIdAsync(Guid id);
    public Task<Game> CreateAsync(Game game);
    public Task<Game?> UpdateAsync(Game game);
    public Task DeleteAsync(Game game);
    public Task<bool> IsTitleExistsAsync(string title, Guid? exceptId = null);
}
