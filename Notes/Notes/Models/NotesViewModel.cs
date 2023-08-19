using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Notes.Authorize;
using Notes.Enum;

namespace Notes.Models;

[Table("Notes")]
public class NotesViewModel
{
    [Required()]
    public int Id { get; set; }
    [MaxLength(40)]
    public string? Title { get; set; }
    [Display(Name = "About?")]
    public string? Description { get; set; }
    public string? LastUpdate { get; set; }
    [Display(Name = "Choose color view")]
    public int? Color { get; set; }

    public string ApplicationUserId { get; set; }
}