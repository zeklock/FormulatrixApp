using CrudApi.Entities;

namespace CrudApi.Interfaces;

public interface IGenreRepository
{
    public Task<IEnumerable<Genre>> GetAllGenresAsync();
    public Task<Genre?> GetGenreByIdAsync(Guid id);
    public Task<Genre> CreateGenreAsync(Genre newGenre);
    public Task<Genre?> UpdateGenreAsync(Guid id, Genre updateGenre);
    public Task<bool> DeleteGenreAsync(Guid id);
    public Task<bool> NameExistsAsync(string name, Guid? exceptId = null);
}
