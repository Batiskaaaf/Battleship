namespace Battleship.Core.Events;

public class GameOverEventArgs : EventArgs
{
    public BattleshipPlayer Winner { get; set; }
    public BattleshipPlayer Loser { get; set; }
}