using CrudApi.Dtos;
using CrudApi.Dtos.Games;

namespace CrudApi.Interfaces;

public interface IGameService
{
    public Task<ApiResponseDto<List<GameDto>>> GetAllAsync();
    public Task<ApiResponseDto<GameDto?>> GetByIdAsync(Guid id);
    public Task<ApiResponseDto<GameDto>> CreateAsync(GameCreateDto gameCreateDto);
    public Task<ApiResponseDto<GameDto?>> UpdateAsync(Guid id, GameUpdateDto gameUpdateDto);
    public Task<ApiResponseDto<bool>> DeleteAsync(Guid id);
}
