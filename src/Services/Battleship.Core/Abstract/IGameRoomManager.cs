using Battleship.Core.HubModels;

namespace Battleship.Core.Abstract;

public interface IGameRoomManager
{
    GameRoom GetById(Guid id);
    Guid Create(string name);
}