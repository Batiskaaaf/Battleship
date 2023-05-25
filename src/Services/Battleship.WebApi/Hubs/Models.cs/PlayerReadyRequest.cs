namespace Battleship.WebApi.Hubs.Models;

public class PlayerReadyRequest
{
    public bool isReady { get; set; }
    public IEnumerable<ShipModel> Ships { get; set; }
}