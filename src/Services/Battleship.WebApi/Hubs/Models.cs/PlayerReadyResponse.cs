namespace Battleship.WebApi.Hubs.Models;

public class PlayerReadyResponce
{
    public PlayerResponse Player { get; set; }
    public bool IsReady { get; set; }
}