using Microsoft.AspNetCore.Identity;
using Notes.Models;

namespace Notes.Authorize;

public class ApplicationUser : IdentityUser
{
    public string? AccountOwner { get; set; }
    public ICollection<NotesViewModel> CollectionNotes { get; set; }
}