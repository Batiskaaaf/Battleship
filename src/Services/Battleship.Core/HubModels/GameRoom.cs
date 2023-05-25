namespace Battleship.Core.HubModels;

public class GameRoom : BattleshipGame
{
    private readonly List<Player> players;
    public DateTime CreationDate { get; }
    public string Name { get; set; }
    public Guid Id { get; }
    public bool Public { get; }

    public GameRoom(string name, bool isPublic = true)
    {
        Name = name;
        Public = isPublic;
        Id = Guid.NewGuid();
        players = new List<Player>();
    }

    public void AddPlayer(Player player)
        => players.Add(player);

    public void RemovePlayer(Player player)
        => players.Remove(player);
}