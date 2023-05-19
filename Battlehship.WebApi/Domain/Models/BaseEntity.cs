namespace Battlehship.WebApi.Domain.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.Now;
}