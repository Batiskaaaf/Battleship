namespace Battleship.Core.Models;

public class Player
{
    public string ConnectionId { get; set; }
    public string Name { get; set; }
    public Board Board { get; private set; }
    public Player(string connectionId, string name)
    {
        ConnectionId = connectionId;
        Name = name;
    }

    public void SetBoard(Board board)
        => Board = board;

}