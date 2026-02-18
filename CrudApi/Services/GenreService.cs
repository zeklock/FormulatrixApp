using AutoMapper;
using CrudApi.Dtos;
using CrudApi.Dtos.Genres;
using CrudApi.Interfaces;
using CrudApi.Models;

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

    public async Task<ApiResponseDto<PaginateResponseDto<GenreDto>>> GetAllAsync(GenreRequestDto request)
    {
        int page = request.Page <= 0 ? 1 : request.Page;
        int size = request.Size > 100 ? 100 : request.Size;
        string? search = request.Search?.Trim();

        try
        {
            PaginateResponseDto<Genre> genres = await _repository.GetAllAsync(page, size, search);
            PaginateResponseDto<GenreDto> results = new PaginateResponseDto<GenreDto>
            {
                Items = genres.Items
                    .Select(_mapper.Map<GenreDto>)
                    .ToList(),
                PageNumber = genres.PageNumber,
                PageSize = genres.PageSize,
                TotalCount = genres.TotalCount
            };

            return ApiResponseDto<PaginateResponseDto<GenreDto>>.SuccessResponse(results);
        }
        catch
        {
            return ApiResponseDto<PaginateResponseDto<GenreDto>>.ErrorResponse("Failed to get data.");
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

    public async Task<ApiResponseDto<GenreDto>> CreateAsync(GenreCreateRequestDto request)
    {
        try
        {
            bool nameExists = await _repository.IsNameExistsAsync(request.Name);

            if (nameExists)
                return ApiResponseDto<GenreDto>.ErrorResponse("Name already exists.");

            Genre genre = _mapper.Map<Genre>(request);

            Genre createdGenre = await _repository.CreateAsync(genre);

            GenreDto result = _mapper.Map<GenreDto>(createdGenre);

            return ApiResponseDto<GenreDto>.SuccessResponse(result, "Create genre success.");
        }
        catch
        {
            return ApiResponseDto<GenreDto>.ErrorResponse("Failed to create data.");
        }
    }

    public async Task<ApiResponseDto<GenreDto?>> UpdateAsync(Guid id, GenreUpdateRequestDto request)
    {
        try
        {
            bool nameExists = await _repository.IsNameExistsAsync(request.Name);

            if (nameExists)
                return ApiResponseDto<GenreDto?>.ErrorResponse("Name already exists.");

            Genre? genre = await _repository.GetByIdAsync(id);

            if (genre is null)
                return ApiResponseDto<GenreDto?>.ErrorResponse("No genre found.");

            _mapper.Map(request, genre);
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
