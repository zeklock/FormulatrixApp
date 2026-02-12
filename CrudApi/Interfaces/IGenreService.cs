using CrudApi.Dtos.Genres;
using CrudApi.Helpers;

namespace CrudApi.Interfaces;

public interface IGenreService
{
    public Result<IEnumerable<GenreDto>> GetAllGenres();
    public Result<GenreDto?> GetGenreById(Guid id);
    public Result<GenreDto> CreateGenre(CreateGenreDto Genre);
    public Result<GenreDto?> UpdateGenre(Guid id, UpdateGenreDto Genre);
    public Result<GenreDto> DeleteGenre(Guid id);
}
