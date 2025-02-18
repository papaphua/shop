using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages.EditProduct;

public sealed partial class EditProductPage : ComponentBase
{
    private ProductDto _product = new();
    [Parameter] public int ProductId { get; set; }
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