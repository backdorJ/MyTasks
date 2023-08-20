using FleaMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<AnnouncementModel> Announcements { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}