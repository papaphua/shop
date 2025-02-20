using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shop.Client.Admin.Models;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Components.ProductForm;

public partial class ProductFormComponent
{
    [Inject] public required IJSRuntime JsRuntime { get; set; }

    [Parameter] public ProductDto Product { get; set; } = new();
    [Parameter] public EventCallback<ProductDto> OnProductSaved { get; set; }

    private bool _isModalOpen;
    private DotNetObjectReference<ProductFormComponent>? _reference;
    private string? _url;

    private async Task HandleSubmit()
    {
        await OnProductSaved.InvokeAsync(Product);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender) return;

        _reference = DotNetObjectReference.Create(this);
    }

    private async Task InvokeLoadImageAsync()
    {
        var result = await JsRuntime.InvokeAsync<ImageModel>("loadImageAsync", _reference);

        _url = result.ImgUrl;
        Product.ImageData = result.ImgBytes;
    }

    private void OnImageLoaded()
    {
        _isModalOpen = true;
    }
}