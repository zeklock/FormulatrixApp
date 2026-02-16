using AutoMapper;
using CrudApi.Dtos.Genres;
using CrudApi.Entities;
using CrudApi.Interfaces;

namespace CrudApi.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<IEnumerable<GenreDto>>> GetAllGenresAsync()
    {
        IEnumerable<Genre> genres = await _repository.GetAllGenresAsync();
        IEnumerable<GenreDto> results = genres
            .Select(_mapper.Map<GenreDto>)
            .ToList();

        return ServiceResult<IEnumerable<GenreDto>>.Success(results);
    }

    public async Task<ServiceResult<GenreDto?>> GetGenreByIdAsync(Guid id)
    {
        Genre? genre = await _repository.GetGenreByIdAsync(id);

        if (genre is null)
            return ServiceResult<GenreDto?>.Failure("No genre found.");

        GenreDto result = _mapper.Map<GenreDto>(genre);

        return ServiceResult<GenreDto?>.Success(result);
    }

    public async Task<ServiceResult<GenreDto>> CreateGenreAsync(GenreCreateDto genreCreateDto)
    {
        bool nameExists = await _repository.NameExistsAsync(genreCreateDto.Name);

        if (nameExists)
            return ServiceResult<GenreDto>.Failure("Name already exists.");

        Genre newGenre = await _repository.CreateGenreAsync(_mapper.Map<Genre>(genreCreateDto));

        GenreDto result = _mapper.Map<GenreDto>(newGenre);

        return ServiceResult<GenreDto>.Success(result);
    }

    public async Task<ServiceResult<GenreDto?>> UpdateGenreAsync(Guid id, GenreUpdateDto genreUpdateDto)
    {
        bool nameExists = await _repository.NameExistsAsync(genreUpdateDto.Name, id);

        if (nameExists)
            return ServiceResult<GenreDto?>.Failure("Name already exists.");

        Genre? genre = await _repository.UpdateGenreAsync(id, _mapper.Map<Genre>(genreUpdateDto));

        if (genre is null)
            return ServiceResult<GenreDto?>.Failure("No genre found.");

        GenreDto result = _mapper.Map<GenreDto>(genre);

        return ServiceResult<GenreDto?>.Success(result);
    }

    public async Task<ServiceResult<bool>> DeleteGenreAsync(Guid id)
    {
        bool result = await _repository.DeleteGenreAsync(id);

        if (!result)
            return ServiceResult<bool>.Failure("No genre found.");

        return ServiceResult<bool>.Success(true);
    }
}
