using Shop.Shared.Users;

namespace Shop.Client.Admin.Services.UserServices;

public interface IUserService
{
    Task<string> LoginJwtAsync(UserLoginDto dto);
}