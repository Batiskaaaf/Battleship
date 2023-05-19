using Battleship.Core.HubModels;

namespace Battleship.WebApi.Hubs.Models;

public class PlayerResponse
{
    public Guid PlayerId { get; set; }
    public string Name { get; set; }

    public static PlayerResponse MapFrom(Player player)
        => new PlayerResponse{PlayerId = player.Id, Name = player.Name};
}