using CrudApi.Dtos.Genres;
using CrudApi.Services;

namespace CrudApi.Interfaces;

public interface IGenreService
{
    public Task<ServiceResult<IEnumerable<GenreDto>>> GetAllGenresAsync();
    public Task<ServiceResult<GenreDto?>> GetGenreByIdAsync(Guid id);
    public Task<ServiceResult<GenreDto>> CreateGenreAsync(GenreCreateDto genreCreateDto);
    public Task<ServiceResult<GenreDto?>> UpdateGenreAsync(Guid id, GenreUpdateDto genreUpdateDto);
    public Task<ServiceResult<bool>> DeleteGenreAsync(Guid id);
}
