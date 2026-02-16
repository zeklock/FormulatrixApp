using CrudApi.Entities;

namespace CrudApi.Interfaces;

public interface IGenreRepository
{
    public Task<List<Genre>> GetAllAsync();
    public Task<Genre?> GetByIdAsync(Guid id);
    public Task<Genre> CreateAsync(Genre genre);
    public Task<Genre?> UpdateAsync(Genre genre);
    public Task DeleteAsync(Genre genre);
    public Task<bool> IsNameExistsAsync(string name, Guid? exceptId = null);
}
