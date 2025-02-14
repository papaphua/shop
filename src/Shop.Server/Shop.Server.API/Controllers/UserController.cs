using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Server.BLL.Users;
using Shop.Shared.Users;

namespace Shop.Server.API.Controllers;

[Route("api/user")]
public sealed class UserController(IUserService userService) : ApiController
{
    [HttpPost("register")]
    public async Task<IResult> Register(UserRegisterDto dto)
    {
        var result = await userService.RegisterAsync(dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}