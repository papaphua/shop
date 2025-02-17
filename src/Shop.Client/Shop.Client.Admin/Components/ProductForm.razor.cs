using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Components;

public partial class ProductForm : ComponentBase
{
    [Parameter] public ProductDto Product { get; set; } = new();
    [Parameter] public EventCallback<ProductDto> OnProductSaved { get; set; }
    [Inject] public required IJSRuntime JS { get; set; }

    DotNetObjectReference<ProductForm> Reference { get; set; }
    
    private async Task HandleSubmit()
    {
        await OnProductSaved.InvokeAsync(Product);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        
        if (firstRender)
        {
            Reference = DotNetObjectReference.Create(this);
            JS.InvokeVoidAsync("ImagePicker.registerReference", Reference);
        }
    }
    
    [JSInvokable("HandleFileChange")]
    public void HandleFileChange(byte[] imageData)
    {
        Product.ImageData = imageData;
        StateHasChanged();
    }
}