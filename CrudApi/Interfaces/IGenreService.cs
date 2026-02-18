using CrudApi.Dtos;
using CrudApi.Dtos.Genres;

namespace CrudApi.Interfaces;

public interface IGenreService
{
    public Task<ApiResponseDto<PaginateResponseDto<GenreDto>>> GetAllAsync(GenreRequestDto request);
    public Task<ApiResponseDto<GenreDto?>> GetByIdAsync(Guid id);
    public Task<ApiResponseDto<GenreDto>> CreateAsync(GenreCreateRequestDto request);
    public Task<ApiResponseDto<GenreDto?>> UpdateAsync(Guid id, GenreUpdateRequestDto request);
    public Task<ApiResponseDto<bool>> DeleteAsync(Guid id);
}
