using Microsoft.AspNetCore.Components;

namespace Shop.Client.Common.Components.ProductModal;

public partial class ProductModalComponent
{
    [Parameter] public bool IsOpen { get; set; }
    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }
    [Parameter] [EditorRequired] public required string Message { get; set; }

    private async Task CloseModal()
    {
        IsOpen = false;
        await IsOpenChanged.InvokeAsync(IsOpen);
    }
}