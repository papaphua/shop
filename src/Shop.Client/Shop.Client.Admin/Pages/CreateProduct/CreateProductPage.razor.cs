using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages.CreateProduct;

public sealed partial class CreateProductPage : ComponentBase
{
    [Inject] public required IProductService ProductService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private readonly ProductDto _product = new();
    
    private async Task HandleSaveChangesAsync()
    {
        await ProductService.CreateAsync(_product);
        NavigationManager.NavigateTo("/products");
    }
}