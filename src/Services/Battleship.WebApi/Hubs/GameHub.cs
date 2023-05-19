using Battleship.Core;
using Battleship.Core.Abstract;
using Battleship.Core.Game.Models;
using Battleship.Core.HubModels;
using Battleship.Core.Ships;
using Battleship.WebApi.Hubs.Models;

namespace Battleship.WebApi.Hubs;

public class GameHub : Hub
{
    public Game game;
    private readonly IPlayerManager playerManager;
    private readonly IGameRoomManager gameRoomManager;
    private Player CurrentPlayer => playerManager.GetByConnectionId(Context.ConnectionId);

    public GameHub(IPlayerManager playerManager, IGameRoomManager gameRoomManager )
    {
        this.playerManager = playerManager;
        this.gameRoomManager = gameRoomManager;
    }

    public async Task CreatePlayer(CreatePlayerRequest request)
    {
        var playerId = playerManager.Create(Context.ConnectionId, request.Name);
        var response = PlayerResponse.MapFrom(CurrentPlayer);
        await Clients.Caller.SendAsync(Constants.CreatedPlayer, response);
    }

    public async Task CreateGameRoom(CreateGameRoomRequest request)
    {
        var roomId = gameRoomManager.Create(request.Name);
        var response = new GameRoomResponse{Name = request.Name, RoomId = roomId};
        await Clients.Caller.SendAsync(Constants.CreatedRoom, response);
    }

    public async Task JoinGameRoom(JoinGameRoomRequest request)
    {
        var room = gameRoomManager.GetById(request.RoomId);
        room.AddPlayer(CurrentPlayer);
        await Groups.AddToGroupAsync(CurrentPlayer.ConnectionId, room.Id.ToString());
        var response = new JoinGameRoomResponse
        {
            RoomId = room.Id, 
            Player = PlayerResponse.MapFrom(CurrentPlayer)
        };
        await Clients.Group(room.Id.ToString()).SendAsync(Constants.PlayerLeavedLobby, response);
    }

    public async Task LeaveGameRoom()
    {
        var room = CurrentPlayer.GameRoom;
        CurrentPlayer.LeaveGameRoom();
        await Groups.RemoveFromGroupAsync(CurrentPlayer.ConnectionId, room.Id.ToString());
        var response = PlayerResponse.MapFrom(CurrentPlayer);
        await Clients.Group(room.Id.ToString()).SendAsync(Constants.PlayerLeavedLobby, response);
    }

    public async Task SetupBoard(List<Ship> ships)
    {
        if(!GameBoardValidator.ValidateBoardForShips(ships))
        {
            await Clients.Caller.SendAsync("boardValidationResponse", false);
            return;
        }
        CurrentPlayer.SetShips(ships);
        await Clients.Caller.SendAsync("boardValidationResponse", true);
    }

    public async Task Ready()
    {
        if(!CurrentPlayer.AreShipsSetuped)
        {
            var response = new ActionForbidden{Action = nameof(Ready), Reason = Constants.NoShipsOnTheBoard};
            await Clients.Caller.SendAsync(Constants.ActionForbidden, response);
        }
        else
        {
            CurrentPlayer.Ready();
            var response = new PlayerReadyResponse{isReady = true, PlayerResponse = PlayerResponse.MapFrom(CurrentPlayer)};
            await Clients.Group(CurrentPlayer.GameRoom.Id.ToString()).SendAsync(Constants.PlayerIsReady, response);
        }
    } 

    public async Task NotReady()
    {
        CurrentPlayer.NotReady();
        var response = new PlayerReadyResponse{isReady = false, PlayerResponse = PlayerResponse.MapFrom(CurrentPlayer)};
        await Clients.Group(CurrentPlayer.GameRoom.Id.ToString()).SendAsync(Constants.PlayerIsReady, response);
    }

    public async Task Fire(Coordinate coordinate)
    {
        var id = Context.ConnectionId;
        if(!game.PlayerIsAllowedToShoot(id, coordinate))
            await Clients.Caller.SendAsync("forbidenn");

        var args = game.EnemyPlayer.ValidateShot(coordinate);
        if(args.ShotStatus == ShotStatus.Miss)
            game.NextTurn();
        //await Clients.Group(game.GroupName).SendAsync("shotProceeded",args);
    }

}