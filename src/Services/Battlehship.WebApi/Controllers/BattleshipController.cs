namespace Battlehship.WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class BattleshipController : ControllerBase
{
    private readonly ILogger<BattleshipController> logger;
    private readonly IHubContext<GameHub> gameHub;
    private readonly AppDbContext context;

    public BattleshipController(
        ILogger<BattleshipController> logger,
        IHubContext<GameHub> gameHub,
        AppDbContext context
        )
    {
        this.logger = logger;
        this.gameHub = gameHub;
        this.context = context;
    }

    [HttpPost]
    public async Task<ActionResult<CreateGameRoomResponce>> CreateGameRoomAsync()
    {
        var game = new GameModel();
        game.RoomId = Guid.NewGuid();
        context.Games.Add(game);
        await context.SaveChangesAsync();
        return new CreateGameRoomResponce(){RoomId = game.RoomId.ToString()};
    }
}