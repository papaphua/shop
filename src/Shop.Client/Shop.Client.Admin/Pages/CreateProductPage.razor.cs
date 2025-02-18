using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.ProductServices;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages;

public sealed partial class CreateProductPage : ComponentBase
{
    private readonly ProductDto _product = new();
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private async Task HandleSaveChangesAsync()
    {
        await ProductService.CreateAsync(_product);
        NavigationManager.NavigateTo("/products");
    }
}