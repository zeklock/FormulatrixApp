using AutoMapper;
using CrudApi.Dtos.Genres;
using CrudApi.Entities;

namespace CrudApi.MappingProfiles;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile()
    {
        CreateMap<Genre, GenreDto>();
        CreateMap<GenreDto, Genre>();
        CreateMap<CreateGenreDto, Genre>();
        CreateMap<UpdateGenreDto, Genre>();
    }
}
