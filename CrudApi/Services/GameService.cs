using AutoMapper;
using CrudApi.Dtos;
using CrudApi.Dtos.Games;
using CrudApi.Interfaces;
using CrudApi.Models;

namespace CrudApi.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponseDto<List<GameDto>>> GetAllAsync()
    {
        try
        {
            List<Game> games = await _repository.GetAllAsync();
            List<GameDto> results = games
                .Select(_mapper.Map<GameDto>)
                .ToList();

            return ApiResponseDto<List<GameDto>>.SuccessResponse(results);
        }
        catch
        {
            return ApiResponseDto<List<GameDto>>.ErrorResponse("Failed to get data.");
        }
    }

    public async Task<ApiResponseDto<GameDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            Game? game = await _repository.GetByIdAsync(id);

            if (game is null)
                return ApiResponseDto<GameDto?>.ErrorResponse("No game found.");

            GameDto result = _mapper.Map<GameDto>(game);

            return ApiResponseDto<GameDto?>.SuccessResponse(result);
        }
        catch
        {
            return ApiResponseDto<GameDto?>.ErrorResponse("Failed to get data.");
        }
    }

    public async Task<ApiResponseDto<GameDto>> CreateAsync(GameCreateDto gameCreateDto)
    {
        try
        {
            bool titleExists = await _repository.IsTitleExistsAsync(gameCreateDto.Title);

            if (titleExists)
                return ApiResponseDto<GameDto>.ErrorResponse("Title already exists.");

            Game game = _mapper.Map<Game>(gameCreateDto);

            Game createdGame = await _repository.CreateAsync(game);

            GameDto result = _mapper.Map<GameDto>(createdGame);

            return ApiResponseDto<GameDto>.SuccessResponse(result, "Create game success.");
        }
        catch
        {
            return ApiResponseDto<GameDto>.ErrorResponse("Failed to create data.");
        }
    }

    public async Task<ApiResponseDto<GameDto?>> UpdateAsync(Guid id, GameUpdateDto gameUpdateDto)
    {
        try
        {
            bool titleExists = await _repository.IsTitleExistsAsync(gameUpdateDto.Title, id);

            if (titleExists)
                return ApiResponseDto<GameDto?>.ErrorResponse("Title already exists.");

            Game? game = await _repository.GetByIdAsync(id);

            if (game is null)
                return ApiResponseDto<GameDto?>.ErrorResponse("No game found.");

            _mapper.Map(gameUpdateDto, game);
            Game? updatedGame = await _repository.UpdateAsync(game);

            GameDto result = _mapper.Map<GameDto>(updatedGame);

            return ApiResponseDto<GameDto?>.SuccessResponse(result, "Update game success.");
        }
        catch
        {
            return ApiResponseDto<GameDto?>.ErrorResponse("Failed to update data.");
        }
    }

    public async Task<ApiResponseDto<bool>> DeleteAsync(Guid id)
    {
        try
        {
            Game? game = await _repository.GetByIdAsync(id);

            if (game is null)
                return ApiResponseDto<bool>.ErrorResponse("No game found.");

            await _repository.DeleteAsync(game);

            return ApiResponseDto<bool>.SuccessResponse(true, "Delete game success.");
        }
        catch
        {
            return ApiResponseDto<bool>.ErrorResponse("Failed to delete data.");
        }
    }
}
