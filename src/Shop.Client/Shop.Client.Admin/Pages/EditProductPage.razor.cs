using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shop.Client.Admin.Services.ProductServices;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages;

public sealed partial class EditProductPage : ComponentBase
{
    [Parameter] public int ProductId { get; set; }
    private ProductDto _product = new();
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _product = await ProductService.GetByIdAsync(ProductId);
    }

    private async Task HandleSaveChangesAsync()
    {
        await ProductService.UpdateAsync(ProductId, _product);
        NavigationManager.NavigateTo("/products");
    }
}