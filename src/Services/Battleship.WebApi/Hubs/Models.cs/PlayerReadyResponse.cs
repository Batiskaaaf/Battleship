namespace Battleship.WebApi.Hubs.Models;

public class PlayerReadyResponse
{
    public bool isReady { get; set; }
    public PlayerResponse PlayerResponse { get; set; }
}