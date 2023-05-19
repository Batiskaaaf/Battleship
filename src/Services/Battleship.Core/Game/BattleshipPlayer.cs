namespace Battleship.Core.Game;

public class BattleshipPlayer
{
    public GameStage gameStage { get;set; }
    public string Name { get; set; }   
    public string connectionId { get; set; }
    public bool AreAllShipSunk => Ships.All(s => s.isSunk);
    public List<Coordinate> UsedCoordinates { get; set; }
    private IEnumerable<Ship> Ships;
    public BattleshipPlayer(string name, IEnumerable<Ship> ships)
    {
        Name = name;
        Ships = ships;
    }

    public ShotprocessedArgs ValidateShot(Coordinate coordinate)
    {
        var ship = Ships.FirstOrDefault(s => s.Coordinates.Any(c => c == coordinate));

        if(ship == null)
            return ShotprocessedArgs.Miss(coordinate);

        if(ship.isSunk)
            //TODO Calculate affected coordinates
            return ShotprocessedArgs.Hit(coordinate);

        return ShotprocessedArgs.Hit(coordinate);
    }

}