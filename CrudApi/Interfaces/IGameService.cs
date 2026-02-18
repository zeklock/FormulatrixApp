using CrudApi.Dtos;
using CrudApi.Dtos.Games;

namespace CrudApi.Interfaces;

public interface IGameService
{
    public Task<ApiResponseDto<PaginateResponseDto<GameDto>>> GetAllAsync(GameRequestDto request);
    public Task<ApiResponseDto<GameDto?>> GetByIdAsync(Guid id);
    public Task<ApiResponseDto<GameDto>> CreateAsync(GameCreateRequestDto request);
    public Task<ApiResponseDto<GameDto?>> UpdateAsync(Guid id, GameUpdateRequestDto request);
    public Task<ApiResponseDto<bool>> DeleteAsync(Guid id);
}
