using CrudApi.Interfaces;

namespace CrudApi.Entities;

public class Game : ITimestamp, ISoftDelete
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required int ReleaseYear { get; set; }
    public Guid? GenreId { get; set; }
    public Genre? Genre { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}
