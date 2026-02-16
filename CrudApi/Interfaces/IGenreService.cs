using CrudApi.Dtos;
using CrudApi.Dtos.Genres;

namespace CrudApi.Interfaces;

public interface IGenreService
{
    public Task<ApiResponseDto<List<GenreDto>>> GetAllAsync();
    public Task<ApiResponseDto<GenreDto?>> GetByIdAsync(Guid id);
    public Task<ApiResponseDto<GenreDto>> CreateAsync(GenreCreateDto genreCreateDto);
    public Task<ApiResponseDto<GenreDto?>> UpdateAsync(Guid id, GenreUpdateDto genreUpdateDto);
    public Task<ApiResponseDto<bool>> DeleteAsync(Guid id);
}
