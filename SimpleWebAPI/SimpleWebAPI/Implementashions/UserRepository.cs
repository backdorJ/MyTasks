using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Interfaces;
using SimpleWebAPI.Models;
using AppContext = SimpleWebAPI.Database.AppContext;

namespace SimpleWebAPI.Implementashions;

public sealed class UserRepository : IUserRepository
{
    private AppContext _context;
    private ILogger<string> _logger;
    public UserRepository(AppContext context, ILogger<string> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddUserAsync(User user)
        => await _context.Users.AddAsync(user);

    public async Task<List<User>> GetUsersAsync()
        => await _context.Users.ToListAsync();

    public async Task<User> GetUserAsync(Guid id)
        => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task DeleteUserAsync(Guid id)
    {
        var delUser = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(delUser);
    }

    public async Task UpdateUserAsync(User user)
    {
        var updateUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        updateUser.Name = user.Name;
        updateUser.Surname = user.Surname;
        updateUser.Age = user.Age;
    }

    private bool _disposed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
                _logger.Log(LogLevel.Information,"Clear manage files");
            }
            _disposed = true;
        }
    }
}