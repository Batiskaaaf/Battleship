
namespace Battlehship.WebApi.Domain.Models;

public class GameModel
{
    [Required]
    public Guid RoomId { get; set; }
    public bool IsStarted { get; set; } = false;
}