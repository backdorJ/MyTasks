using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Display(Name="Username")]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password do not match")]
    public string ConfirmPassword { get; set; }
}