using Shop.Server.BLL.Core.Results;
using Shop.Shared.Users;

namespace Shop.Server.BLL.Users;

public interface IUserService
{
    Task<Result> RegisterAsync(UserRegisterDto dto);
    Task<Result<UserDto>> LoginAsync(UserLoginDto dto);
}