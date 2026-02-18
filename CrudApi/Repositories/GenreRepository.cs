using CrudApi.Data;
using CrudApi.Dtos;
using CrudApi.Interfaces;
using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly GameDbContext _context;

    public GenreRepository(GameDbContext context)
    {
        _context = context;
    }

    public async Task<PaginateResponseDto<Genre>> GetAllAsync(
        int page = 1,
        int size = 10,
        string? search = null
    )
    {
        List<Genre> items = await _context.Genres
            .Where(g => string.IsNullOrEmpty(search) || g.Name.ToLower().Contains(search.ToLower()))
            .Include(g => g.Games)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();

        int totalCount = await _context.Genres.CountAsync();

        PaginateResponseDto<Genre> result = new PaginateResponseDto<Genre>
        {
            Items = items,
            PageNumber = page,
            PageSize = size,
            TotalCount = totalCount
        };

        return result;
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
