using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Client.Admin.Auth;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Users;

namespace Shop.Client.Admin.Pages.Login;

public partial class LoginPage
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }
    [Inject] public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private UserLoginDto LoginDto { get; } = new();

    private async Task HandleLoginAsync()
    {
        var token = await UserService.LoginJwtAsync(LoginDto);

        if (string.IsNullOrWhiteSpace(token)) return;

        await (AuthenticationStateProvider as JwtAuthStateProvider)!.NotifyAuthenticated(token);

        NavigationManager.NavigateTo("/");
    }
}