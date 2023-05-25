namespace Battleship.Core.Ships;

public class Ship
{
    public Ship(ShipType shipType, IEnumerable<Coordinate> coordinates)
    {
        this.shipType = shipType;
        this.Coordinates = coordinates;
    }
    public ShipType Type { get; set; }
    private int hits;
    private readonly ShipType shipType;
    public IEnumerable<Coordinate> Coordinates { get; }
    public bool isSunk => hits >= Coordinates.Count();
    public void Hit(Coordinate coordinate)
        => hits++;
    
}