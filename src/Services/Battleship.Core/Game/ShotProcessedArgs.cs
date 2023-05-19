namespace Battleship.Core.Game;

public class ShotProcessedArgs
{
    public ShotStatus ShotStatus { get; set; }
    public IEnumerable<Coordinate> AffectedCoordinates { get; set; }
    private ShotProcessedArgs(ShotStatus status, Coordinate coordinate) : this(status, new List<Coordinate>{coordinate})
    {

    }
    private ShotProcessedArgs(ShotStatus status, IEnumerable<Coordinate> affectedCoordinates)
    {
        ShotStatus = status;
        AffectedCoordinates = affectedCoordinates;
    }
    public static ShotProcessedArgs Miss(Coordinate coordinate)
        => new ShotProcessedArgs(ShotStatus.Miss, coordinate);
    public static ShotProcessedArgs Hit(Coordinate coordinate)
        => new ShotProcessedArgs(ShotStatus.Hit, coordinate);
    public static ShotProcessedArgs Sunk(IEnumerable<Coordinate> coordinates)
        => new ShotProcessedArgs(ShotStatus.Sunk, coordinates);

}