using AutoMapper;
using CrudApi.Dtos.Games;
using CrudApi.Entities;
using CrudApi.Interfaces;

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

    public async Task<ServiceResult<IEnumerable<GameDto>>> GetAllGamesAsync()
    {
        IEnumerable<Game> games = await _repository.GetAllGamesAsync();
        IEnumerable<GameDto> results = games
            .Select(_mapper.Map<GameDto>)
            .ToList();

        return ServiceResult<IEnumerable<GameDto>>.Success(results);
    }

    public async Task<ServiceResult<GameDto?>> GetGameByIdAsync(Guid id)
    {
        Game? game = await _repository.GetGameByIdAsync(id);

        if (game is null)
            return ServiceResult<GameDto?>.Failure("No game found.");

        GameDto result = _mapper.Map<GameDto>(game);

        return ServiceResult<GameDto?>.Success(result);
    }

    public async Task<ServiceResult<GameDto>> CreateGameAsync(GameCreateDto gameCreateDto)
    {
        bool titleExists = await _repository.TitleExistsAsync(gameCreateDto.Title);

        if (titleExists)
            return ServiceResult<GameDto>.Failure("Title already exists.");

        Game newGame = await _repository.CreateGameAsync(_mapper.Map<Game>(gameCreateDto));

        GameDto result = _mapper.Map<GameDto>(newGame);

        return ServiceResult<GameDto>.Success(result);
    }

    public async Task<ServiceResult<GameDto?>> UpdateGameAsync(Guid id, GameUpdateDto gameUpdateDto)
    {
        bool titleExists = await _repository.TitleExistsAsync(gameUpdateDto.Title, id);

        if (titleExists)
            return ServiceResult<GameDto?>.Failure("Title already exists.");

        Game? game = await _repository.UpdateGameAsync(id, _mapper.Map<Game>(gameUpdateDto));

        if (game is null)
            return ServiceResult<GameDto?>.Failure("No game found.");

        GameDto result = _mapper.Map<GameDto>(game);

        return ServiceResult<GameDto?>.Success(result);
    }

    public async Task<ServiceResult<bool>> DeleteGameAsync(Guid id)
    {
        bool result = await _repository.DeleteGameAsync(id);

        if (!result)
            return ServiceResult<bool>.Failure("No game found.");

        return ServiceResult<bool>.Success(true);
    }
}
