using CrudApi.Dtos;
using CrudApi.Models;

namespace CrudApi.Interfaces;

public interface IGenreRepository
{
    public Task<PaginateResponseDto<Genre>> GetAllAsync(int page = 1, int size = 10, string? search = null);
    public Task<Genre?> GetByIdAsync(Guid id);
    public Task<Genre> CreateAsync(Genre genre);
    public Task<Genre?> UpdateAsync(Genre genre);
    public Task DeleteAsync(Genre genre);
    public Task<bool> IsNameExistsAsync(string name, Guid? exceptId = null);
}
