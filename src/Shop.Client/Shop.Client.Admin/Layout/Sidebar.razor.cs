using Microsoft.AspNetCore.Components;

namespace Shop.Client.Admin.Layout;

public partial class Sidebar
{
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private string? _currentUri;

    protected override void OnInitialized()
    {
        _currentUri = NavigationManager.Uri;
    }

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

    private bool IsOnLoginPage()
    {
        return NavigationManager.Uri.EndsWith("/login");
    }
}