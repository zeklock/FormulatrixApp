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

    public async Task<List<Genre>> GetAllAsync()
    {
        List<Genre> data = await _context.Genres
            .Include(g => g.Games)
            .ToListAsync();

        return data;
    }

    public async Task<Genre?> GetByIdAsync(Guid id)
    {
        Genre? data = await _context.Genres
            .Include(g => g.Games)
            .FirstOrDefaultAsync(g => g.Id == id);

        return data;
    }

    public async Task<Genre> CreateAsync(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();

        return genre;
    }

    public async Task<Genre?> UpdateAsync(Genre genre)
    {
        genre.UpdatedAt = DateTime.Now;
        _context.Genres.Update(genre);
        await _context.SaveChangesAsync();

        return genre;
    }

    public async Task DeleteAsync(Genre genre)
    {
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsNameExistsAsync(string name, Guid? exceptId = null)
    {
        bool result = await _context.Genres
            .Where(g => g.Id != exceptId)
            .AnyAsync(g => string.Equals(g.Name.ToLower(), name.ToLower()));

        return result;
    }
}
