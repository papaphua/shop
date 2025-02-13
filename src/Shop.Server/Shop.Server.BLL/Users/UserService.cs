using AutoMapper;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Users;
using Shop.Shared.Core.Results;
using Shop.Shared.Users;

namespace Shop.Server.BLL.Users;

public sealed class UserService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUserService
{
    public async Task<Result> RegisterAsync(UserRegisterDto dto)
    {
        if (dto.Password != dto.ConfirmPassword)
            return UserErrors.PasswordsNotMatch;

        var existingUser = await userRepository.GetByEmailAsync(dto.Email);

        if (existingUser != null)
            return UserErrors.EmailAlreadyRegistered;

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        await userRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}