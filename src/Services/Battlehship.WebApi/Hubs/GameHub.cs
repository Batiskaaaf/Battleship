using Battleship.Core;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Battlehship.WebApi.Hubs;

public class GameHub : Hub
{
    private readonly AppDbContext dbContext;
    public BattleshipGame game;

    public GameHub(AppDbContext context)
    {
        this.dbContext = context;
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