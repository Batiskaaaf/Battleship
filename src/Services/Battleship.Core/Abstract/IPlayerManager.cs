using Battleship.Core.HubModels;

namespace Battleship.Core.Abstract;

public interface IPlayerManager
{
    Player GetByConnectionId(string id);
    Player GetById(Guid id);
    Guid Create(string id, string name);
}