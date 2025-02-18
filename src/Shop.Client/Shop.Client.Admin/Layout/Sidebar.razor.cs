using Microsoft.AspNetCore.Components;

namespace Shop.Client.Admin.Layout;

public partial class Sidebar
{
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private bool _isOnLoginPage => NavigationManager.Uri.EndsWith("/login");

    private void NavigateToPage(string page)
    {
        NavigationManager.NavigateTo(page);
    }
}