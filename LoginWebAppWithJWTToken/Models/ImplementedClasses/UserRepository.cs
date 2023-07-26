using LoginWebAppWithJWTToken.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppContext = LoginWebAppWithJWTToken.Database.AppContext;

namespace LoginWebAppWithJWTToken.Models.Implementashions;

public class UserRepository : IUserRepository
{
    private AppContext _context;
    private ILogger<string> _logger;
    
    public UserRepository(AppContext context, ILogger<string> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<User?> GetUserAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(user =>
            user.Email == email);

    public async Task AddUserAsync(User user)
        => await _context.Users.AddAsync(user);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task DeleteUserAsync(User user) 
        => _context.Users.Remove(user);

    public async Task<User> GetPredicateUserAsync(Func<User, bool> predicate)
    {
        var users = await _context.Users.ToListAsync();
        foreach (var user in users.Where(predicate))
        {
            return user;
        }

        return new User();
    }


    private bool _dispoosed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_dispoosed)
        {
            if (disposing)
            {
                _context.Dispose();
                _logger.Log(LogLevel.Information, "Dispose called");
            }
        }
    }
}