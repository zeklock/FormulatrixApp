using CrudApi.Dtos;
using CrudApi.Models;

namespace CrudApi.Interfaces;

public interface IGameRepository
{
    public Task<PaginateResponseDto<Game>> GetAllAsync(int page = 1, int size = 10, string? search = null, Guid? genreId = null);
    public Task<Game?> GetByIdAsync(Guid id);
    public Task<Game> CreateAsync(Game game);
    public Task<Game?> UpdateAsync(Game game);
    public Task DeleteAsync(Game game);
    public Task<bool> IsTitleExistsAsync(string title, Guid? exceptId = null);
}
