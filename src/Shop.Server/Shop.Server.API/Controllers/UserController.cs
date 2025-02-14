using Microsoft.AspNetCore.Mvc;
using Shop.Server.API.Core;
using Shop.Server.BLL.Users;
using Shop.Shared.Users;

namespace Shop.Server.API.Controllers;

[Route("api/user")]
public sealed class UserController(IUserService userService) : ApiController
{
    [HttpPost("login")]
    public async Task<IResult> LoginJwt(UserLoginDto dto)
    {
        var result = await userService.LoginJwtAsync(dto);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }
}