using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleaMarket.Models;

[Table("Announcement")]
public class AnnouncementModel
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; }
    [Display(Name = "Price")]
    public decimal? Price { get; set; }
    [Display(Name = "Description")]
    [MaxLength(100)]
    public string? Description { get; set; }
    [Display(Name = "Set Image")]
    public string? Image { get; set; }
    [Required]
    public string AnnouncementOwner { get; set; }
}