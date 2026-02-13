using AutoMapper;
using CrudApi.Dtos.Games;
using CrudApi.Dtos.Genres;
using CrudApi.Entities;

namespace CrudApi.MappingProfiles;

public class GameMappingProfiles : Profile
{
    public GameMappingProfiles()
    {
        CreateMap<Game, GameDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<GameDto, Game>();
        CreateMap<GameCreateDto, Game>();
        CreateMap<GameUpdateDto, Game>();
    }
}
