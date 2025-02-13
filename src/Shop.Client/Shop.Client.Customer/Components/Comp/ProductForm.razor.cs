using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shop.Shared.Products;

namespace Shop.Client.Customer.Components.Comp;

public partial class ProductForm : ComponentBase
{
    [Parameter] public ProductDto Product { get; set; } = new();
    [Parameter] public EventCallback<ProductDto> OnProductSaved { get; set; }

    private async Task HandleSubmit()
    {
        await OnProductSaved.InvokeAsync(Product);
    }

    private async Task HandleFileChange(InputFileChangeEventArgs e)
    {
        var file = e.File;
        var buffer = new byte[file.Size];
        await file.OpenReadStream().ReadAsync(buffer);
        Product.ImageData = buffer;
    }
}