using Battleship.Core;
using Battleship.Core.Abstract;
using Battleship.Core.Game.Models;
using Battleship.Core.Models;

namespace Battleship.WebApi.Hubs;

public class GameHub : Hub
{
    public Game game;
    private readonly IPlayerManager playerManager;
    
    public GameHub(IPlayerManager playerManager)
    {
        this.playerManager = playerManager;
    }
    public async Task JoinRoom(string RoomId, string username)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, RoomId);
    }

    public async Task Fire(Coordinate coordinate)
    {
        var id = Context.ConnectionId;
        if(!game.PlayerAvailableToShoot(id, coordinate))
            await Clients.Caller.SendAsync("forbidenn");

        var args = game.EnemyPlayer.ValidateShot(coordinate);
        if(args.ShotStatus == ShotStatus.Miss)
            game.NextTurn();
        await Clients.Group(game.GroupName).SendAsync("shotProceeded",args);
    }

}