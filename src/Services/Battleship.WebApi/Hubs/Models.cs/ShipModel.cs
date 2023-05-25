using Battleship.Core;
using Battleship.Core.Ships;

namespace Battleship.WebApi.Hubs.Models;

public class ShipModel
{
    public ShipType Type { get; set; }
    public IEnumerable<Coordinate> Coordinates { get; set; }

    public Ship MapToShip()
        => new Ship(Type, Coordinates);
}