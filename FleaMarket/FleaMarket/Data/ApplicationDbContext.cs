using FleaMarket.Authoriz;
using FleaMarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<AnnouncementModel> Announcements { get; set; }
    public DbSet<AnnouncementsUsers> AnnouncementsUsers { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AnnouncementsUsers>()
            .HasKey(au => new { au.UserId, au.AnnouncementId });

        builder.Entity<AnnouncementsUsers>()
            .HasOne(x => x.User)
            .WithMany(u => u.Announcements)
            .HasForeignKey(x => x.UserId);

        builder.Entity<AnnouncementsUsers>()
            .HasOne(x => x.Announcement)
            .WithMany(u => u.Users)
            .HasForeignKey(x => x.AnnouncementId);
    }
}