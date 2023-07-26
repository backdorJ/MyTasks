using SimpleWebAPI.Models;
namespace SimpleWebAPI.Interfaces;

public interface IUserRepository : IDisposable
{
    Task AddUserAsync(User user);
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(Guid id);
    Task DeleteUserAsync(Guid id);
    Task UpdateUserAsync(User user);
    Task SaveChangesAsync();
}