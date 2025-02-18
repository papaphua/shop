using Microsoft.AspNetCore.Components;

namespace Shop.Client.Admin.Layout;

public partial class Sidebar
{
    private string _currentUri;
    [Inject] public required NavigationManager NavManager { get; set; }

    protected override void OnInitialized()
    {
        _currentUri = NavManager.Uri;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (NavManager.Uri != _currentUri)
        {
            _currentUri = NavManager.Uri;
            StateHasChanged();
        }
    }

    private void NavigateToPage(string page)
    {
        NavManager.NavigateTo(page);
    }

    private bool IsOnLoginPage()
    {
        return NavManager.Uri.EndsWith("/login");
    }
}