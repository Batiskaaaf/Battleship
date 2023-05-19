using Battleship.Core.Models;

namespace Battleship.Core.Abstract;

public interface IPlayerManager
{
    Player GetPlayerById(string id);
    void Create(string id, string name);
}