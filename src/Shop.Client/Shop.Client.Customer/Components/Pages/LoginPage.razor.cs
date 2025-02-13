using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Shop.Shared.Users;

namespace Shop.Client.Customer.Components.Pages;

public partial class LoginPage : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }

    [Inject] public IUserService UserService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [SupplyParameterFromForm] private UserLoginDto LoginDto { get; set;  } = new();

    private async Task LoginAsync()
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