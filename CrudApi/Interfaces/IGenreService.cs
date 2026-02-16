using CrudApi.Dtos.Genres;
using CrudApi.Services;

namespace CrudApi.Interfaces;

public interface IGenreService
{
    public Task<ServiceResult<IEnumerable<GenreDto>>> GetAllGenresAsync();
    public Task<ServiceResult<GenreDto?>> GetGenreByIdAsync(Guid id);
    public Task<ServiceResult<GenreDto>> CreateGenreAsync(GenreCreateDto Genre);
    public Task<ServiceResult<GenreDto?>> UpdateGenreAsync(Guid id, GenreUpdateDto Genre);
    public Task<ServiceResult<bool>> DeleteGenreAsync(Guid id);
    public Task<bool> TitleExistsAsync(string title, Guid? exceptId = null);
}
