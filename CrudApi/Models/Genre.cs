using System.Text.Json.Serialization;
using CrudApi.Interfaces;

namespace CrudApi.Models;

public class Genre : ITimestamp, ISoftDelete
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    [JsonIgnore]
    public ICollection<Game> Games { get; set; } = new List<Game>();
}
