using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Client.Admin.Auth;

namespace Shop.Client.Admin.Pages;

public sealed partial class LogoutPage : ComponentBase
{
    [Inject] public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await (AuthenticationStateProvider as JwtAuthStateProvider)!.NotifyLogoutAsync();
        NavigationManager.NavigateTo("/");
    }
}