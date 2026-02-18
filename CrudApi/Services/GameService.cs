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

    public async Task<ApiResponseDto<PaginateResponseDto<GameDto>>> GetAllAsync(GameRequestDto request)
    {
        int page = request.Page <= 0 ? 1 : request.Page;
        int size = request.Size > 100 ? 100 : request.Size;
        string? search = request.Search?.Trim();
        Guid? genreId = request.GenreId;

        try
        {
            PaginateResponseDto<Game> games = await _repository.GetAllAsync(page, size, search, genreId);
            PaginateResponseDto<GameDto> results = new PaginateResponseDto<GameDto>
            {
                Items = games.Items
                    .Select(_mapper.Map<GameDto>)
                    .ToList(),
                PageNumber = games.PageNumber,
                PageSize = games.PageSize,
                TotalCount = games.TotalCount
            };

            return ApiResponseDto<PaginateResponseDto<GameDto>>.SuccessResponse(results);
        }
        catch
        {
            return ApiResponseDto<PaginateResponseDto<GameDto>>.ErrorResponse("Failed to get data.");
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

    public async Task<ApiResponseDto<GameDto>> CreateAsync(GameCreateRequestDto request)
    {
        try
        {
            bool titleExists = await _repository.IsTitleExistsAsync(request.Title);

            if (titleExists)
                return ApiResponseDto<GameDto>.ErrorResponse("Title already exists.");

            Game game = _mapper.Map<Game>(request);

            Game createdGame = await _repository.CreateAsync(game);

            GameDto result = _mapper.Map<GameDto>(createdGame);

            return ApiResponseDto<GameDto>.SuccessResponse(result, "Create game success.");
        }
        catch
        {
            return ApiResponseDto<GameDto>.ErrorResponse("Failed to create data.");
        }
    }

    public async Task<ApiResponseDto<GameDto?>> UpdateAsync(Guid id, GameUpdateRequestDto request)
    {
        try
        {
            bool titleExists = await _repository.IsTitleExistsAsync(request.Title, id);

            if (titleExists)
                return ApiResponseDto<GameDto?>.ErrorResponse("Title already exists.");

            Game? game = await _repository.GetByIdAsync(id);

            if (game is null)
                return ApiResponseDto<GameDto?>.ErrorResponse("No game found.");

            _mapper.Map(request, game);
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
