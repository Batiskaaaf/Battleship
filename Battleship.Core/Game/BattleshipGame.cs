namespace Battleship.Core.Game;

public class BattleshipGame
{
    public BattleshipPlayer PlayerOne { get; }
    public BattleshipPlayer PlayerTwo { get; }
    public BattleshipPlayer CurrentPlayer { get; private set;}
    public BattleshipPlayer EnemyPlayer => CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    public string GroupName { get; }
    public BattleshipGame()
    {
        GroupName = Guid.NewGuid().ToString();
    }

    public void NextTurn()
        => CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    public bool IsPlayerTurn(string connectionId)
        => CurrentPlayer.connectionId == connectionId;

    public bool PlayerAlreadyHitSpot(Coordinate coordinate)
        => CurrentPlayer.UsedCoordinates.Any(c => c == coordinate);

    public BattleshipPlayer GetPlayerById(string id)
        => PlayerOne.connectionId == id ? PlayerTwo : PlayerOne;

}