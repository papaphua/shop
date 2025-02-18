using Microsoft.AspNetCore.Components;

namespace Shop.Client.Admin.Layout;

public partial class Sidebar
{
    private string? _currentUri;
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private bool _isOnLoginPage => NavigationManager.Uri.EndsWith("/login");

    protected override void OnAfterRender(bool firstRender)
    {
        if (NavigationManager.Uri == _currentUri) return;

        _currentUri = NavigationManager.Uri;
        StateHasChanged();
    }

    private void NavigateToPage(string page)
    {
        NavigationManager.NavigateTo(page);
    }
}