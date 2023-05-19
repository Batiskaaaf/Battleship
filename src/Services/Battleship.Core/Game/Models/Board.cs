namespace Battleship.Core.Game.Models;

public class Board
{
    public string Name { get; set; }   
    public string connectionId { get; set; }
    public bool AreAllShipSunk => Ships.All(s => s.isSunk);
    public List<Coordinate> UsedCoordinates { get; set; }
    private IEnumerable<Ship> Ships;
    public Board(string name, IEnumerable<Ship> ships)
    {
        Name = name;
        Ships = ships;
    }

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