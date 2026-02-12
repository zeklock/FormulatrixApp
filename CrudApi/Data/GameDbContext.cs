using CrudApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data;

public class GameDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Games.db");
    }
}
