using CrudApi.Interfaces;

namespace CrudApi.Models;

public class Game : ITimestamp, ISoftDelete
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public int ReleaseYear { get; set; } = DateTime.Now.Year;
    public Guid? GenreId { get; set; }
    public Genre? Genre { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}
