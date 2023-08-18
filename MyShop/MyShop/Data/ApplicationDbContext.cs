using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Authorization;
using MyShop.Models;

namespace MyShop.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<BookViewModel> BookViewModels { get; set; }
    public DbSet<ClientViewModel> ClientViewModels { get; set; }
    public DbSet<UserBookFavourite> UserBookFavourites { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserBookFavourite>()
            .HasKey(ubf => new { ubf.UserId, ubf.BookId });

        // Configure the relationships if needed
        modelBuilder.Entity<UserBookFavourite>()
            .HasOne(ubf => ubf.User)
            .WithMany(u => u.Books)
            .HasForeignKey(ubf => ubf.UserId);

        modelBuilder.Entity<UserBookFavourite>()
            .HasOne(ubf => ubf.Book)
            .WithMany(b => b.Users)
            .HasForeignKey(ubf => ubf.BookId);
    }
}