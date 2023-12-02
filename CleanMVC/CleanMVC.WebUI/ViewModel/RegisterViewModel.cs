using System.ComponentModel.DataAnnotations;

namespace CleanMVC.WebUI.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password dont match")]
        public string? ConfirmPassword { get; set; }
    }
}
