namespace Battleship.Core.Game.Models;

public abstract class BattleshipPlayer
{
    public bool AreAllShipSunk => Ships.All(s => s.isSunk);
    public List<Coordinate> UsedCoordinates { get; set; }
    protected IEnumerable<Ship> Ships;

    public ShotProcessedArgs ValidateShot(Coordinate coordinate)
    {
        var ship = Ships.FirstOrDefault(s => s.Coordinates.Any(c => c == coordinate));

        if(ship == null)
            return ShotProcessedArgs.Miss(coordinate);

        if(ship.isSunk)
            //TODO Calculate affected coordinates
            return ShotProcessedArgs.Hit(coordinate);

        return ShotProcessedArgs.Hit(coordinate);
    }

}