using System.Text.Json.Serialization;
using CrudApi.Dtos.Games;

namespace CrudApi.Dtos.Genres;

public class GenreDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
