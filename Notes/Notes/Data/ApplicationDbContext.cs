using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Notes.Authorize;
using Notes.Models;

namespace Notes.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<NotesViewModel> Notes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
}