namespace Battleship.Core.Events;

public class ShotprocessedArgs
{
    public ShotStatus ShotStatus { get; set; }
    public IEnumerable<Coordinate> AffectedCoordinates { get; set; }
    private ShotprocessedArgs(ShotStatus status, Coordinate coordinate) : this(status, new List<Coordinate>{coordinate})
    {

    }
    private ShotprocessedArgs(ShotStatus status, IEnumerable<Coordinate> affectedCoordinates)
    {
        ShotStatus = status;
        AffectedCoordinates = affectedCoordinates;
    }
    public static ShotprocessedArgs Miss(Coordinate coordinate)
        => new ShotprocessedArgs(ShotStatus.Miss, coordinate);
    public static ShotprocessedArgs Hit(Coordinate coordinate)
        => new ShotprocessedArgs(ShotStatus.Hit, coordinate);
    public static ShotprocessedArgs Sunk(IEnumerable<Coordinate> coordinates)
        => new ShotprocessedArgs(ShotStatus.Sunk, coordinates);

}