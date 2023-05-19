using Battleship.Core.HubModels;

namespace Battleship.Infrastructure.Services;

public class InMemoryGameRoomManager : IGameRoomManager
{
    public List<GameRoom> GameRooms { get; }
    public InMemoryGameRoomManager()
    {
        GameRooms = new List<GameRoom>();
    }
    public Guid Create(string name)  
    {
        var gameRoom = new GameRoom(name);
        GameRooms.Add(gameRoom);
        return gameRoom.Id;
    } 
       
    public GameRoom GetById(Guid id)
        => GameRooms.FirstOrDefault(gr => gr.Id == id);
    
}