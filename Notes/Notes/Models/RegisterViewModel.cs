using System.ComponentModel.DataAnnotations;

namespace Notes.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Invalid Email")]
    [EmailAddress]
    public string Email { get; set; }
    
    public string? UserName { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirm password dont math")]
    public string ConfirmPassword { get; set; }
}