using Microsoft.AspNetCore.Identity;

namespace Notes.Authorize;

public class ApplicationUser : IdentityUser
{
    public string? AccountOwner { get; set; }
}