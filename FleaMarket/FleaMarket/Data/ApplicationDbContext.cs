using FleaMarket.Authoriz;
using FleaMarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<AnnouncementModel> Announcements { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}