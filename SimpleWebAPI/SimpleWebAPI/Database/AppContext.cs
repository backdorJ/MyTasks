using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Database;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    { }
}