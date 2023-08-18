using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Models;

[Table("Notes")]
public class NotesViewModel
{
    [Required]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LastUpdate { get; set; }  
}