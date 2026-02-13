using AutoMapper;
using CrudApi.Data;
using CrudApi.Dtos.Genres;
using CrudApi.Entities;
using CrudApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Services;

public class GenreService : IGenreService
{
    private readonly GameDbContext _context;
    private readonly IMapper _mapper;

    public GenreService(GameDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<GenreDto>>> GetAllGenresAsync()
    {
        IEnumerable<GenreDto> genres = await _context.Genres
            .Select(g => _mapper.Map<GenreDto>(g))
            .ToListAsync();

        return ServiceResult<IEnumerable<GenreDto>>.Success(genres);
    }

    public async Task<ServiceResult<GenreDto?>> GetGenreByIdAsync(Guid id)
    {
        Genre? genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre is null)
            return ServiceResult<GenreDto?>.Failure("No genre found.");

        GenreDto result = _mapper.Map<GenreDto>(genre);

        return ServiceResult<GenreDto?>.Success(result);
    }

    public async Task<ServiceResult<GenreDto>> CreateGenreAsync(GenreCreateDto genreCreateDto)
    {
        Genre newGenre = _mapper.Map<Genre>(genreCreateDto);
        newGenre.CreatedAt = DateTime.Now;
        newGenre.UpdatedAt = DateTime.Now;

        _context.Genres.Add(newGenre);
        await _context.SaveChangesAsync();

        GenreDto result = _mapper.Map<GenreDto>(newGenre);

        return ServiceResult<GenreDto>.Success(result);
    }

    public async Task<ServiceResult<GenreDto?>> UpdateGenreAsync(Guid id, GenreUpdateDto genreUpdateDto)
    {
        Genre? genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre is null)
            return ServiceResult<GenreDto?>.Failure("No genre found.");

        _mapper.Map(genreUpdateDto, genre);
        genre.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        GenreDto result = _mapper.Map<GenreDto>(genre);

        return ServiceResult<GenreDto?>.Success(result);
    }

    public async Task<ServiceResult<bool>> DeleteGenreAsync(Guid id)
    {
        Genre? genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

        if (genre is null)
            return ServiceResult<bool>.Failure("No genre found.");

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }
}
