namespace Battleship.Core.Ships;

public class Ship
{
    public ShipType Type { get; set; }
    private int Length { get; set; }
    private int hits;
    public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
    public bool isSunk => hits >= Length;
    public void Hit(Coordinate coordinate)
        => hits++;
        
}