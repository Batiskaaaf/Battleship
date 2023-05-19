

namespace Battlehship.WebApi.Services;

public class BattleshipGameService
{
    private readonly IHubContext context;

    private readonly ConcurrentDictionary<string, BattleshipGame> Games
        = new();

    public BattleshipGameService(IHubContext context)
    {
        this.context = context;
    }


}