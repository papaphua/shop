using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;

namespace Shop.Client.Customer.Components.Pages;

public partial class LogoutPage : ComponentBase
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    [CascadingParameter] public HttpContext? HttpContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await HttpContext.SignOutAsync();
        NavigationManager.NavigateTo("/");
    }
}