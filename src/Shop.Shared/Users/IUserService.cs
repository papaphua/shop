using Shop.Server.DAL.Users;
using Shop.Shared.Core.Results;

namespace Shop.Shared.Users;

public interface IUserService
{
    Task<Result> RegisterAsync(UserRegisterDto dto);
    Task<Result<UserDto>> LoginAsync(UserLoginDto dto);
}