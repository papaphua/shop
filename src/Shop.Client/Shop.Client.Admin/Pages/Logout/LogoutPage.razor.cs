using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Client.Admin.Auth;

namespace Shop.Client.Admin.Pages.Logout;

public partial class LogoutPage
{
    [Inject] public required AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await (AuthenticationStateProvider as JwtAuthStateProvider)!.NotifyLogoutAsync();
        NavigationManager.NavigateTo("/");
    }
}