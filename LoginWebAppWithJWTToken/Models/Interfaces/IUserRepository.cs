namespace LoginWebAppWithJWTToken.Models.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<User> GetUserAsync(string email);
    Task AddUserAsync(User user);
    Task SaveChangesAsync();
    Task DeleteUserAsync(User user);
    Task <User> GetPredicateUserAsync(Func<User, bool> predicate);
}