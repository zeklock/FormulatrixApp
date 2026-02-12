using CrudApi.Data;
using CrudApi.Dtos.Games;
using CrudApi.Entities;
using CrudApi.Helpers;
using CrudApi.Interfaces;

namespace CrudApi.Services;

public class GameService : IGameService
{
    public Result<IEnumerable<GameDto>> GetAllGames()
    {
        using (GameDbContext context = new GameDbContext())
        {
            IEnumerable<GameDto> games = context.Games.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                ReleaseYear = g.ReleaseYear,
                Genre = g.Genre,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt
            }).ToList();

            return Result<IEnumerable<GameDto>>.Success(games);
        }
    }

    public Result<GameDto?> GetGameById(Guid id)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Game? game = context.Games.FirstOrDefault(g => g.Id == id);

            if (game is null)
                return Result<GameDto?>.Failure("Game not Found.");

            GameDto result = MapGameToGameDto(game);

            return Result<GameDto?>.Success(result);
        }
    }

    public Result<GameDto> CreateGame(CreateGameDto createGameDto)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Game newGame = new Game
            {
                Title = createGameDto.Title,
                ReleaseYear = createGameDto.ReleaseYear,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (createGameDto.GenreId is not null)
            {
                Genre? genre = context.Genres.FirstOrDefault(g => g.Id == createGameDto.GenreId);

                if (genre is not null)
                    newGame.Genre = genre;
            }

            context.Games.Add(newGame);
            context.SaveChanges();

            GameDto result = MapGameToGameDto(newGame);

            return Result<GameDto>.Success(result);
        }
    }

    public Result<GameDto?> UpdateGame(Guid id, UpdateGameDto updateGameDto)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Game? game = context.Games.FirstOrDefault(g => g.Id == id);

            if (game is null)
                return Result<GameDto?>.Failure("Game not Found.");

            if (updateGameDto.GenreId is not null)
            {
                Genre? genre = context.Genres.FirstOrDefault(g => g.Id == updateGameDto.GenreId);

                if (genre is not null)
                    game.Genre = genre;
            }

            game.Title = updateGameDto.Title;
            game.ReleaseYear = updateGameDto.ReleaseYear;
            game.UpdatedAt = DateTime.Now;
            context.SaveChanges();

            GameDto result = MapGameToGameDto(game);

            return Result<GameDto?>.Success(result);
        }
    }

    public Result<GameDto> DeleteGame(Guid id)
    {
        using (GameDbContext context = new GameDbContext())
        {
            Game? game = context.Games.FirstOrDefault(g => g.Id == id);

            if (game is null)
                return Result<GameDto>.Failure("Game not Found.");

            context.Games.Remove(game);
            context.SaveChanges();

            return Result<GameDto>.Success();
        }
    }

    private GameDto MapGameToGameDto(Game game)
    {
        GameDto result = new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            ReleaseYear = game.ReleaseYear,
            Genre = game.Genre,
            CreatedAt = game.CreatedAt,
            UpdatedAt = game.UpdatedAt
        };

        return result;
    }
}
