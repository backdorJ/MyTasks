using System.ComponentModel.DataAnnotations;

namespace MyShop.Models;

public class RegistrationViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Gender { get; set; }
}