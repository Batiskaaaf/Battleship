namespace Battlehship.WebApi.Data.DataAcess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<GameModel> Games { get; set; }
}