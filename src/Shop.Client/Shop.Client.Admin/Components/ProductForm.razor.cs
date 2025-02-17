using System.Text.Json;
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

    public required DotNetObjectReference<ProductForm> Reference { get; set; }

    private string? Url { get; set; }

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
            await JS.InvokeVoidAsync("ImagePicker.registerReferenceAsync", Reference);
        }
    }

    private async Task InvokeLoadImageAsync()
    {
        var result = await JS.InvokeAsync<ImageModel>("ImagePicker.loadImageAsync", Reference);
        
        Url = result.ImgUrl;
        Product.ImageData = result.ImgBytes;
    }
}