using FleaMarket.Data;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Authoriz;

public class ApplicationUser : IdentityUser
{
    public ICollection<AnnouncementsUsers> Announcements { get; set; }   
    public ICollection<RecipesUsers> Recipes { get; set; }
}