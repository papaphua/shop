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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        
        if (firstRender)
        {
            Reference = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("ImagePicker.registerReference", Reference);
        }
    }

    private async Task InvokeLoadImageAsync()
    {
        await JS.InvokeVoidAsync("ImagePicker.loadImage", Reference);
    }    
    
    [JSInvokable("HandleFileChange")]
    public async Task HandleFileChangeAsync(byte[] imageData)
    {
        Product.ImageData = imageData;
        StateHasChanged();
    }
}