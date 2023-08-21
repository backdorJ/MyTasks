using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Invalid email or password")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Invalid email or password")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
    
    public string? ReturnUrl { get; set; }
}