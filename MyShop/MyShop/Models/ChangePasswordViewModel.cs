using System.ComponentModel.DataAnnotations;

namespace MyShop.Models;

public class ChangePasswordViewModel
{
    [Required, DataType(DataType.Password),Display(Name = "Enter current password!")]
    public string CurrentPassword { get; set; }
    [Required, DataType(DataType.Password), Display(Name = "Enter new password!")]
    public string NewPassword { get; set; }
    [Required, DataType(DataType.Password), Display(Name = "Confirm password")]
    [Compare("NewPassword", ErrorMessage = "New password and confirm password not match")]
    public string ConfirmNewPassword { get; set; }
}