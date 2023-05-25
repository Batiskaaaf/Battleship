namespace Battleship.Core.Game.Models;

public abstract class BattleshipGame
{
    private BattleshipPlayer playerOne;
    private BattleshipPlayer playerTwo;
    public BattleshipPlayer CurrentPlayer => isPlayerOneTurn ? playerOne : playerTwo;
    public BattleshipPlayer EnemyPlayer => isPlayerOneTurn ? playerTwo : playerOne;
    public Action<BattleshipPlayer, BattleshipPlayer> OnGameOver;
    private bool isPlayerOneTurn { get; set; }
    public BattleshipGame(BattleshipPlayer playerOne, BattleshipPlayer playerTwo)
    {
        this.playerOne = playerOne;
        this.playerTwo = playerTwo;
    }

    public bool PlayerIsAllowedToShoot(BattleshipPlayer player, Coordinate coor)
    {
        if (player != CurrentPlayer)
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

    private void NextTurn()
        => isPlayerOneTurn = !isPlayerOneTurn; 

    private bool PlayerAlreadyHitSpot(Coordinate coordinate)
        => CurrentPlayer.UsedCoordinates.Any(c => c == coordinate);



}