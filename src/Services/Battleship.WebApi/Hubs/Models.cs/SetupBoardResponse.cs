namespace Battleship.WebApi.Hubs.Models;

public class SetupBoardResponse
{
    public bool BoardIsValid { get; set; }
    public bool BoardIsSet { get; set; }
}