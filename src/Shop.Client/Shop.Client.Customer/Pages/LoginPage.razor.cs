using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.Users;
using Shop.Shared.Users;

namespace Shop.Client.Customer.Pages;

public sealed partial class LoginPage : ComponentBase
{
    [SupplyParameterFromForm] private UserLoginDto LoginDto { get; set; } = new();
    [CascadingParameter] public HttpContext? HttpContext { get; set; }
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private async Task HandleLoginAsync()
    {
        var result = await UserService.LoginAsync(LoginDto);

        if (result.IsSuccess)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, result.Value!.Id.ToString()),
                new(ClaimTypes.Role, result.Value!.Role.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            NavigationManager.NavigateTo("/products");
        }
    }
}