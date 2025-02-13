using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Shop.Shared.Products;

namespace Shop.Client.Customer.Components.Pages;

[Authorize(Roles = "1")]
public partial class EditProductPage : ComponentBase
{
    private ProductDto _product = new();
    [Parameter] public int ProductId { get; set; }

    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _product = (await ProductService.GetByIdAsync(ProductId)).Value!;
    }

    private async Task SaveChanges()
    {
        await ProductService.UpdateAsync(ProductId, _product);
        NavigationManager.NavigateTo("/products");
    }
}