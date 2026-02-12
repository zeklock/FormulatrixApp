using CrudApi.Data;
using CrudApi.Dtos.Genres;
using CrudApi.Entities;
using CrudApi.Helpers;
using CrudApi.Interfaces;

namespace CrudApi.Services;

public class GenreService : IGenreService
{
    public Result<IEnumerable<GenreDto>> GetAllGenres()
    {
        using (GameDbContext context = new GameDbContext())
        {
            IEnumerable<GenreDto> genres = context.Genres.Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt
            }).ToList();

            return Result<IEnumerable<GenreDto>>.Success(genres);
        }
    }

    public Result<GenreDto?> GetGenreById(Guid id)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Genre? genre = context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre is null)
                return Result<GenreDto?>.Failure("Genre not Found.");

            GenreDto result = MapGenreToGenreDto(genre);

            return Result<GenreDto?>.Success(result);
        }
    }

    public Result<GenreDto> CreateGenre(CreateGenreDto createGenreDto)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Genre newGenre = new Genre
            {
                Name = createGenreDto.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            context.Genres.Add(newGenre);
            context.SaveChanges();

            GenreDto result = MapGenreToGenreDto(newGenre);

            return Result<GenreDto>.Success(result);
        }
    }

    public Result<GenreDto?> UpdateGenre(Guid id, UpdateGenreDto updateGenreDto)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Genre? genre = context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre is null)
                return Result<GenreDto?>.Failure("Genre not Found.");

            genre.Name = updateGenreDto.Name;
            genre.UpdatedAt = DateTime.Now;
            context.SaveChanges();

            GenreDto result = MapGenreToGenreDto(genre);

            return Result<GenreDto?>.Success(result);
        }
    }

    public Result<GenreDto> DeleteGenre(Guid id)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Genre? genre = context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre is null)
                return Result<GenreDto>.Failure("Genre not Found.");

            context.Genres.Remove(genre);
            context.SaveChanges();

            return Result<GenreDto>.Success();
        }
    }

    private GenreDto MapGenreToGenreDto(Genre genre)
    {
        GenreDto result = new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name,
            CreatedAt = genre.CreatedAt,
            UpdatedAt = genre.UpdatedAt
        };

        return result;
    }
}
