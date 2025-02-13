using System.ComponentModel.DataAnnotations;

namespace Shop.Shared.Users;

public sealed class UserRegisterDto
{
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] [Compare(nameof(Password))] public string ConfirmPassword { get; set; }
}