namespace Battleship.WebApi.Hubs.Models;

public class JoinGameRoomResponse
{
    public Guid RoomId { get; set; }
    public PlayerResponse Player { get; set; }
}