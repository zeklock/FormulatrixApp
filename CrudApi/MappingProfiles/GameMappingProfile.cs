using AutoMapper;
using CrudApi.Dtos.Games;
using CrudApi.Entities;

namespace CrudApi.MappingProfiles;

public class GameMappingProfiles : Profile
{
    public GameMappingProfiles()
    {
        CreateMap<Game, GameDto>();
        CreateMap<GameDto, Game>();
        CreateMap<CreateGameDto, Game>();
        CreateMap<UpdateGameDto, Game>();
    }
}
