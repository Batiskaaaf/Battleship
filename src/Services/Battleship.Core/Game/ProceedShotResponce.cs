namespace Battleship.Core.Game;

public class ProceedShotResponce
{
    public Coordinate Coordinate { get; set; }
    public ShotStatus ShotStatus { get; set; }
    public Ship Ship { get; set; }
}