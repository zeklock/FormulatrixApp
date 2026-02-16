using CrudApi.Data;
using CrudApi.Entities;
using CrudApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameDbContext _context;

    public GameRepository(GameDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        IEnumerable<Game> data = await _context.Games
            .Include(g => g.Genre)
            .ToListAsync();

        return data;
    }

    public async Task<Game?> GetGameByIdAsync(Guid id)
    {
        Game? data = await _context.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        return data;
    }

    public async Task<Game> CreateGameAsync(Game game)
    {
        try
        {
            game.CreatedAt = DateTime.Now;
            game.UpdatedAt = DateTime.Now;

            if (game.GenreId is not null)
            {
                Genre? genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Id == game.GenreId);

                if (genre is not null)
                {
                    game.Genre = genre;
                }
                else
                {
                    game.GenreId = null;
                }
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Game?> UpdateGameAsync(Guid id, Game game)
    {
        try
        {
            Game? data = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (data is null)
                return data;

            if (game.GenreId is not null)
            {
                Genre? genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Id == game.GenreId);

                if (genre is not null)
                {
                    data.GenreId = genre.Id;
                    data.Genre = genre;
                }
                else
                {
                    data.GenreId = null;
                }
            }

            data.Title = game.Title;
            data.ReleaseYear = game.ReleaseYear;
            data.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return data;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> DeleteGameAsync(Guid id)
    {
        try
        {
            Game? data = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (data is null)
                return false;

            _context.Games.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> TitleExistsAsync(string title, Guid? exceptId = null)
    {
        bool result = await _context.Games
            .Where(g => g.Id != exceptId)
            .AnyAsync(g => string.Equals(g.Title.ToLower(), title.ToLower()));

        return result;
    }
}
