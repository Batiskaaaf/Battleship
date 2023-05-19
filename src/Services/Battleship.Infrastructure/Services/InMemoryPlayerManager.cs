using Battleship.Core.Game.Models;

namespace Battleship.Infrastructure.Services;

public class InMemoryPlayerManager : IPlayerManager
{
    private readonly List<Player> players;
    public InMemoryPlayerManager()
    {
        players = new List<Player>();
    }
    public void Create(string id, string name)   
        => players.Add(new Player(id, name));
    
    public Player GetPlayerById(string id)
        => players.FirstOrDefault(p => p.ConnectionId == id);
    
}