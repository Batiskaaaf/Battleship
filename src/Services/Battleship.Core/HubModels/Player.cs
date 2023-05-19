namespace Battleship.Core.HubModels;

public class Player : BattleshipPlayer
{
    public string ConnectionId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GameRoom GameRoom { get; private set; }
    public bool AreShipsSetuped => Ships != null;
    public bool IsReady { get; private set; }
    public Player(string connectionId, string name)
    {
        Id = Guid.NewGuid();
        ConnectionId = connectionId;
        Name = name;
    }

    public void Ready()
        => IsReady = true;
    
    public void NotReady()
        => IsReady = false;

    public void JoinGameRoom(GameRoom gameRoom)
        => GameRoom = gameRoom;

    public void LeaveGameRoom()
        => GameRoom = null;

    public void SetShips(IEnumerable<Ship> ships)
        => Ships = ships;

}