using AutoMapper;
using CrudApi.Dtos;
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

    public async Task<ApiResponseDto<List<GenreDto>>> GetAllAsync()
    {
        try
        {
            List<Genre> genres = await _repository.GetAllAsync();
            List<GenreDto> results = genres
                .Select(_mapper.Map<GenreDto>)
                .ToList();

            return ApiResponseDto<List<GenreDto>>.SuccessResponse(results);
        }
        catch
        {
            return ApiResponseDto<List<GenreDto>>.ErrorResponse("Failed to get data.");
        }
    }

    public async Task<ApiResponseDto<GenreDto?>> GetByIdAsync(Guid id)
    {
        try
        {
            Genre? genre = await _repository.GetByIdAsync(id);

            if (genre is null)
                return ApiResponseDto<GenreDto?>.ErrorResponse("No genre found.");

            GenreDto result = _mapper.Map<GenreDto>(genre);

            return ApiResponseDto<GenreDto?>.SuccessResponse(result);
        }
        catch
        {
            return ApiResponseDto<GenreDto?>.ErrorResponse("Failed to get data.");
        }
    }

    public async Task<ApiResponseDto<GenreDto>> CreateAsync(GenreCreateDto genreCreateDto)
    {
        try
        {
            bool nameExists = await _repository.IsNameExistsAsync(genreCreateDto.Name);

            if (nameExists)
                return ApiResponseDto<GenreDto>.ErrorResponse("Name already exists.");

            Genre genre = _mapper.Map<Genre>(genreCreateDto);

            Genre createdGenre = await _repository.CreateAsync(genre);

            GenreDto result = _mapper.Map<GenreDto>(createdGenre);

            return ApiResponseDto<GenreDto>.SuccessResponse(result, "Create genre success.");
        }
        catch
        {
            return ApiResponseDto<GenreDto>.ErrorResponse("Failed to create data.");
        }
    }

    public async Task<ApiResponseDto<GenreDto?>> UpdateAsync(Guid id, GenreUpdateDto genreUpdateDto)
    {
        try
        {
            bool nameExists = await _repository.IsNameExistsAsync(genreUpdateDto.Name);

            if (nameExists)
                return ApiResponseDto<GenreDto?>.ErrorResponse("Name already exists.");

            Genre? genre = await _repository.GetByIdAsync(id);

            if (genre is null)
                return ApiResponseDto<GenreDto?>.ErrorResponse("No genre found.");

            _mapper.Map(genreUpdateDto, genre);
            Genre? updatedGenre = await _repository.UpdateAsync(genre);

            GenreDto result = _mapper.Map<GenreDto>(updatedGenre);

            return ApiResponseDto<GenreDto?>.SuccessResponse(result, "Update genre success.");
        }
        catch
        {
            return ApiResponseDto<GenreDto?>.ErrorResponse("Failed to update data.");
        }
    }

    public async Task<ApiResponseDto<bool>> DeleteAsync(Guid id)
    {
        try
        {
            Genre? genre = await _repository.GetByIdAsync(id);

            if (genre is null)
                return ApiResponseDto<bool>.ErrorResponse("No genre found.");

            await _repository.DeleteAsync(genre);

            return ApiResponseDto<bool>.SuccessResponse(true, "Delete genre success.");
        }
        catch
        {
            return ApiResponseDto<bool>.ErrorResponse("Failed to delete data.");
        }
    }
}
