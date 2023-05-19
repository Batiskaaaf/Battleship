namespace Battleship.Core.Game;

public class BattleshipPlayer
{
    public GameStage gameStage { get;set; }
    public string Name { get; set; }   
    public string connectionId { get; set; }
    public List<Coordinate> UsedCoordinates { get; set; }
    public IEnumerable<Ship> Ships;
    public BattleshipPlayer(string name, IEnumerable<Ship> ships)
    {
        Name = name;
        Ships = ships;
    }

    public ShotProcededEventArgs ValidateShot(Coordinate coordinate)
    {
        var ship = Ships.FirstOrDefault(s => s.Coordinates.Any(c => c == coordinate));

        if(ship == null)
            return new ShotProcededEventArgs(ShotStatus.Miss, coordinate);

        if(ship.isSunk)
            return new ShotProcededEventArgs(ShotStatus.Sunk, coordinate, ship.Coordinates);

        return new ShotProcededEventArgs(ShotStatus.Hit, coordinate);
    }

}