using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.ProductServices;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages;

public sealed partial class ProductsPage : ComponentBase
{
    private const int PageSize = 6;
    private PagedList<ProductDto> _list = new();
    private PagingQuery _query = new(1, PageSize);
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager Nav { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadNewPage(1);
    }

    private async Task LoadNewPage(int pageNumber)
    {
        var query = new PagingQuery(pageNumber, PageSize);
        _list = await ProductService.GetAsync(query);
    }

    private async Task DeleteProduct(int productId)
    {
        await ProductService.RemoveAsync(productId);
        await LoadNewPage(_list.Metadata.PageNumber);
    }
}