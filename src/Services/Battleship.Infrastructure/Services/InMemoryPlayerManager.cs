using Battleship.Core.HubModels;

namespace Battleship.Infrastructure.Services;

public class InMemoryPlayerManager : IPlayerManager
{
    public List<Player> Players { get; }
    public InMemoryPlayerManager()
    {
        Players = new List<Player>();
    }
    public Guid Create(string id, string name)   
    { 
        var player = new Player(id, name);
        Players.Add(player);
        return player.Id;
    }
    public Player GetByConnectionId(string connectionId)
        => Players.FirstOrDefault(p => p.ConnectionId == connectionId);

    public Player GetById(Guid id)
        => Players.FirstOrDefault(p => p.Id == id);
    
}