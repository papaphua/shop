using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.Users;
using Shop.Shared.Users;

namespace Shop.Client.Customer.Pages;

public sealed partial class RegisterPage : ComponentBase
{
    [SupplyParameterFromForm] private UserRegisterDto RegisterDto { get; set; } = new();
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private async Task HandleRegisterAsync()
    {
        var result = await UserService.RegisterAsync(RegisterDto);

        if (result.IsSuccess)
        {
            NavigationManager.NavigateTo("/login");
        }
    }
}