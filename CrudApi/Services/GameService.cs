using AutoMapper;
using CrudApi.Data;
using CrudApi.Dtos.Games;
using CrudApi.Entities;
using CrudApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Services;

public class GameService : IGameService
{
    private readonly GameDbContext _context;
    private readonly IMapper _mapper;

    public GameService(GameDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<GameDto>>> GetAllGamesAsync()
    {
        IEnumerable<GameDto> games = await _context.Games
            .Select(g => _mapper.Map<GameDto>(g))
            .ToListAsync();

        return ServiceResult<IEnumerable<GameDto>>.Success(games);
    }

    public async Task<ServiceResult<GameDto?>> GetGameByIdAsync(Guid id)
    {
        Game? game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
            return ServiceResult<GameDto?>.Failure("Game not Found.");

        GameDto result = _mapper.Map<GameDto>(game);

        return ServiceResult<GameDto?>.Success(result);
    }

    public async Task<ServiceResult<GameDto>> CreateGameAsync(GameCreateDto gameCreateDto)
    {
        Game newGame = _mapper.Map<Game>(gameCreateDto);
        newGame.CreatedAt = DateTime.Now;
        newGame.UpdatedAt = DateTime.Now;

        if (gameCreateDto.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == gameCreateDto.GenreId);

            if (genre is not null)
                newGame.Genre = genre;
        }

        _context.Games.Add(newGame);
        await _context.SaveChangesAsync();

        GameDto result = _mapper.Map<GameDto>(newGame);

        return ServiceResult<GameDto>.Success(result);
    }

    public async Task<ServiceResult<GameDto?>> UpdateGameAsync(Guid id, GameUpdateDto gameUpdateDto)
    {
        Game? game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
            return ServiceResult<GameDto?>.Failure("Game not Found.");

        if (gameUpdateDto.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == gameUpdateDto.GenreId);

            if (genre is not null)
                game.Genre = genre;
        }

        _mapper.Map(gameUpdateDto, game);
        game.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        GameDto result = _mapper.Map<GameDto>(game);

        return ServiceResult<GameDto?>.Success(result);
    }

    public async Task<ServiceResult<bool>> DeleteGameAsync(Guid id)
    {
        Game? game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
            return ServiceResult<bool>.Failure("Game not Found.");

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }
}
