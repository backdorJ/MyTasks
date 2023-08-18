using System.ComponentModel.DataAnnotations;

namespace MyShop.Models;

public class EditViewModel
{
    [Display(Name = "Enter name")]
    public string Username { get; set; }
    [Display(Name = "Enter your gender")]
    public string Gender { get; set; }
    [Display(Name = "Enter your image")]
    public IFormFile Photo { get; set; }
}