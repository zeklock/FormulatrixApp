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
            .Include(g => g.Genre)
            .Select(g => _mapper.Map<GameDto>(g))
            .ToListAsync();

        return ServiceResult<IEnumerable<GameDto>>.Success(games);
    }

    public async Task<ServiceResult<GameDto?>> GetGameByIdAsync(Guid id)
    {
        Game? game = await _context.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
            return ServiceResult<GameDto?>.Failure("No game found.");

        GameDto result = _mapper.Map<GameDto>(game);

        return ServiceResult<GameDto?>.Success(result);
    }

    public async Task<ServiceResult<GameDto>> CreateGameAsync(GameCreateDto gameCreateDto)
    {
        bool titleExists = await TitleExistsAsync(gameCreateDto.Title);

        if (titleExists)
            return ServiceResult<GameDto>.Failure("Title already exists.");

        Game newGame = _mapper.Map<Game>(gameCreateDto);
        newGame.CreatedAt = DateTime.Now;
        newGame.UpdatedAt = DateTime.Now;

        if (gameCreateDto.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == gameCreateDto.GenreId);

            if (genre is not null)
            {
                newGame.Genre = genre;
            }
            else
            {
                newGame.GenreId = null;
            }
        }

        _context.Games.Add(newGame);
        await _context.SaveChangesAsync();

        GameDto result = _mapper.Map<GameDto>(newGame);

        return ServiceResult<GameDto>.Success(result);
    }

    public async Task<ServiceResult<GameDto?>> UpdateGameAsync(Guid id, GameUpdateDto gameUpdateDto)
    {
        bool titleExists = await TitleExistsAsync(gameUpdateDto.Title, id);

        if (titleExists)
            return ServiceResult<GameDto?>.Failure("Title already exists.");

        Game? game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
            return ServiceResult<GameDto?>.Failure("No game found.");

        if (gameUpdateDto.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == gameUpdateDto.GenreId);

            if (genre is not null)
            {
                game.Genre = genre;
            }
            else
            {
                game.GenreId = null;
            }
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
            return ServiceResult<bool>.Failure("No game found.");

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success(true);
    }

    public async Task<bool> TitleExistsAsync(string title, Guid? exceptId = null)
    {
        bool result = await _context.Games
            .Where(g => g.Id != exceptId)
            .AnyAsync(g => string.Equals(g.Title.ToLower(), title.ToLower()));

        return result;
    }
}
