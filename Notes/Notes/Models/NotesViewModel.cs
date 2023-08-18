using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Models;

[Table("Notes")]
public class NotesViewModel
{
    [Required]
    public int Id { get; set; }
    [Display(Name = "Enter Title")]
    public string Title { get; set; }
    [Display(Name = "About?")]
    public string Description { get; set; }
    public string LastUpdate { get; set; }
    [Display(Name = "Choose color view")]
    public int Color { get; set; }
}