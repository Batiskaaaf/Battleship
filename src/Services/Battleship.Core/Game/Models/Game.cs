namespace Battleship.Core.Game.Models;

public class Game
{
    public Board PlayerOne { get; }
    public Board PlayerTwo { get; }
    public Board CurrentPlayer { get; private set;}
    public Board EnemyPlayer => CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
    public Action<Board, Board> OnGameOver;
    public string GroupName { get; }
    public Game()
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
    public ShotProcessedArgs PlayerShoot(Coordinate coordinate)
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