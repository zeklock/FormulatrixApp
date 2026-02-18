using AutoMapper;
using CrudApi.Dtos.Genres;
using CrudApi.Models;

namespace CrudApi.MappingProfiles;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile()
    {
        CreateMap<Genre, GenreDto>();
        CreateMap<GenreDto, Genre>();
        CreateMap<GenreCreateRequestDto, Genre>();
        CreateMap<GenreUpdateRequestDto, Genre>();
    }
}
