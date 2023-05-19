namespace Battleship.WebApi.Hubs.Models;

public class GameRoomResponse
{
    public string Name { get; set; }
    public Guid RoomId { get; set; }
}