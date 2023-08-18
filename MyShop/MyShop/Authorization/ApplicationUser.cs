using Microsoft.AspNetCore.Identity;
using MyShop.Models;

namespace MyShop.Authorization;

public class ApplicationUser : IdentityUser
{
    public string? Gender { get; set; }
    public string? PhotoPath { get; set; }
    public string? NameUser { get; set; }
    public ICollection<UserBookFavourite> Books { get; set; }
}