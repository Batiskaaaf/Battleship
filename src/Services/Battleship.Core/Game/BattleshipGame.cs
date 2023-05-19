namespace Battleship.Core.Game;

public class BattleshipGame
{
    public BattleshipPlayer PlayerOne { get; }
    public BattleshipPlayer PlayerTwo { get; }
    public BattleshipPlayer CurrentPlayer { get; private set;}
    public BattleshipPlayer EnemyPlayer => CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    public Action<BattleshipPlayer, BattleshipPlayer> OnGameOver;
    public string GroupName { get; }
    public BattleshipGame()
    {
        GroupName = Guid.NewGuid().ToString();
    }
    public void NextTurn()
        => CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    public bool PlayerAvailableToShoot(string connectionId, Coordinate coor)
    {
        if (!IsPlayerTurn(connectionId))
            return false;
        if (PlayerAlreadyHitSpot(coor))
            return false;
        return true;
    }
    public ShotprocessedArgs PlayerShoot(Coordinate coordinate)
    {
        var args = EnemyPlayer.ValidateShot(coordinate);
        if(args.ShotStatus == ShotStatus.Miss)
            NextTurn();
        else
        {
            if(EnemyPlayer.AreAllShipSunk)
                OnGameOver?.Invoke(CurrentPlayer,EnemyPlayer);
            CurrentPlayer.UsedCoordinates.AddRange(args.AffectedCoordinates);
        }
        return args;
    }


    private bool IsPlayerTurn(string connectionId)
        => CurrentPlayer.connectionId == connectionId;

    private bool PlayerAlreadyHitSpot(Coordinate coordinate)
        => CurrentPlayer.UsedCoordinates.Any(c => c == coordinate);



}