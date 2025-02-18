using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages.EditProduct;

public sealed partial class EditProductPage : ComponentBase
{
    [Inject] public required IProductService ProductService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    [Parameter] public int ProductId { get; set; }
 
    private ProductDto _product = new();
    
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