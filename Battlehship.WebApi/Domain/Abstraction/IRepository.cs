namespace Battlehship.WebApi.Domain.Abstraion;

public interface IRepository<T>
{
    Task<Guid> CreateAsync();
    Task DeleteAsync(); 
    Task FirstOrDefaultAsync();
}