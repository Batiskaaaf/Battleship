namespace Battleship.WebApi.Hubs.Models;

public class ActionForbidden
{
    public string Action { get; set; }
    public string Reason { get; set; }
}