using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.Products;
using Shop.Shared.Products;

namespace Shop.Client.Customer.Components.Pages;

[Authorize(Roles = "1")]
public partial class CreateProductPage : ComponentBase
{
    private readonly ProductDto _product = new();
    [Parameter] public int ProductId { get; set; }

    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private async Task SaveChanges()
    {
        await ProductService.CreateAsync(_product);
        NavigationManager.NavigateTo("/products");
    }
}