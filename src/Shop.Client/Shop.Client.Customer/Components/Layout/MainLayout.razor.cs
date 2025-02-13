using Microsoft.AspNetCore.Components;

namespace Shop.Client.Customer.Components.Layout;

public partial class MainLayout
{
    [Inject] private NavigationManager Nav { get; set; }

    public void OpenLogin()
    {
        Nav.NavigateTo("login");
    }

    public void OpenLogout()
    {
        Nav.NavigateTo("logout");
    }
}