using System.ComponentModel.DataAnnotations;

namespace Shop.Shared.Users;

public sealed class UserLoginDto
{
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
}