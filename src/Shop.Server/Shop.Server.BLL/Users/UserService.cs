using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Shop.Server.BLL.Core.Results;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Users;
using Shop.Shared.Users;

namespace Shop.Server.BLL.Users;

public sealed class UserService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IUserService
{
    public async Task<Result<UserDto>> LoginAsync(UserLoginDto dto)
    {
        var result = await ValidateUserAsync(dto);

        if (!result.IsSuccess)
            return Result<UserDto>.Failure(result.Error!);

        return mapper.Map<UserDto>(result.Value);
    }

    public async Task<Result<string>> LoginJwtAsync(UserLoginDto dto)
    {
        var result = await ValidateUserAsync(dto);

        if (!result.IsSuccess)
            return Result<string>.Failure(result.Error!);
        
        var user = result.Value!;

        if(user.Role != Role.Admin)
            return UserErrors.NoPermission;
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

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

    private async Task<Result<User>> ValidateUserAsync(UserLoginDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
            return UserErrors.InvalidEmail;

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return UserErrors.InvalidPassword;

        return user;
    }
}