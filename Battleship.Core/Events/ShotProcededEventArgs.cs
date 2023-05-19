namespace Battleship.Core.Events;

public class ShotProcededEventArgs : EventArgs
{
    public ShotProcededEventArgs(ShotStatus status, Coordinate coordinate, IEnumerable<Coordinate> shipCoordinates = null)
    {
        ShotStatus = status;
        Coordinate = coordinate;
        ShipCoordinates = shipCoordinates;
    }
    public Coordinate Coordinate { get; set; }
    public ShotStatus ShotStatus { get; set; }
    public IEnumerable<Coordinate> ShipCoordinates { get; set; }
}