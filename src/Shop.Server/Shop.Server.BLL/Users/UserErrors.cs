using Shop.Shared.Core.Results;

namespace Shop.Server.BLL.Users;

public static class UserErrors
{
    public static readonly Error PasswordsNotMatch = Error.Validation(
        "User.PasswordsNotMatch", "Passwords do not match.");

    public static readonly Error EmailAlreadyRegistered = Error.Conflict(
        "User.EmailAlreadyRegistered", "This email is already registered.");

    public static readonly Error InvalidEmail = Error.Validation(
        "User.Email", "Email is invalid.");

    public static readonly Error InvalidPassword = Error.Validation(
        "User.Password", "Password is invalid.");
}