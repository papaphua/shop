using Shop.Shared.Users;

namespace Shop.Client.Admin.Services.Interfaces;

public interface IUserService
{
    Task<string> LoginJwtAsync(UserLoginDto dto);
}