using LoginWebAppWithJWTToken.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginWebAppWithJWTToken.Database;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppContext(DbContextOptions<AppContext> options) 
        : base(options)
    { }
    
}