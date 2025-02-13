using Microsoft.AspNetCore.Mvc;

namespace Shop.Server.API.Core;

[ApiController]
public abstract class ApiController : ControllerBase
{
    // protected int UserId => int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    protected int UserId => 4;
}