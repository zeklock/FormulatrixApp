using CrudApi.Data;
using CrudApi.Dtos;
using CrudApi.Interfaces;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameDbContext _context;

    public GameRepository(GameDbContext context)
    {
        _context = context;
    }

    public async Task<PaginateResponseDto<Game>> GetAllAsync(
        int page = 1,
        int size = 10,
        string? search = null,
        Guid? genreId = null
    )
    {
        List<Game> items = await _context.Games
            .Where(g => string.IsNullOrEmpty(search) || g.Title.ToLower().Contains(search.ToLower()))
            .Where(g => genreId == null || g.GenreId == genreId)
            .Include(g => g.Genre)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        int totalCount = await _context.Games.CountAsync();

        PaginateResponseDto<Game> result = new PaginateResponseDto<Game>
        {
            Items = items,
            PageNumber = page,
            PageSize = size,
            TotalCount = totalCount
        };

        return result;
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        Game? data = await _context.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        return data;
    }

    public async Task<Game> CreateAsync(Game game)
    {
        if (game.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == game.GenreId);

            if (genre is not null)
            {
                game.GenreId = genre.Id;
                game.Genre = genre;
            }
            else
            {
                game.GenreId = null;
                game.Genre = null;
            }
        }

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<Game?> UpdateAsync(Game game)
    {
        if (game.GenreId is not null)
        {
            Genre? genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == game.GenreId);

            if (genre is not null)
            {
                game.GenreId = genre.Id;
                game.Genre = genre;
            }
            else
            {
                game.GenreId = null;
                game.Genre = null;
            }
        }

        _context.Games.Update(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task DeleteAsync(Game game)
    {
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsTitleExistsAsync(string title, Guid? exceptId = null)
    {
        bool result = await _context.Games
            .Where(g => g.Id != exceptId)
            .AnyAsync(g => string.Equals(g.Title.ToLower(), title.ToLower()));

        return result;
    }
}
