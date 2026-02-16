using CrudApi.Data;
using CrudApi.Entities;
using CrudApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly GameDbContext _context;

    public GenreRepository(GameDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        IEnumerable<Genre> data = await _context.Genres
            .Include(g => g.Games)
            .ToListAsync();

        return data;
    }

    public async Task<Genre?> GetGenreByIdAsync(Guid id)
    {
        Genre? data = await _context.Genres
            .Include(g => g.Games)
            .FirstOrDefaultAsync(g => g.Id == id);

        return data;
    }

    public async Task<Genre> CreateGenreAsync(Genre genre)
    {
        try
        {
            genre.CreatedAt = DateTime.Now;
            genre.UpdatedAt = DateTime.Now;

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return genre;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Genre?> UpdateGenreAsync(Guid id, Genre genre)
    {
        try
        {
            Genre? data = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (data is null)
                return data;

            data.Name = genre.Name;
            data.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return data;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> DeleteGenreAsync(Guid id)
    {
        try
        {
            Genre? data = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (data is null)
                return false;

            _context.Genres.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> NameExistsAsync(string name, Guid? exceptId = null)
    {
        bool result = await _context.Genres
            .Where(g => g.Id != exceptId)
            .AnyAsync(g => string.Equals(g.Name.ToLower(), name.ToLower()));

        return result;
    }
}
