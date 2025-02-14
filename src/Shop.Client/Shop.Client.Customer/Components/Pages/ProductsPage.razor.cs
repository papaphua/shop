using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Shop.Server.BLL.Products;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Client.Customer.Components.Pages;

[Authorize(Roles = "1")]
public partial class ProductsPage : ComponentBase
{
    private const int PageSize = 6;
    private PagedList<ProductDto> _list = new();
    private PagingQuery _query = new(1, PageSize);
    [Inject] private IProductService ProductService { get; set; }
    [Inject] private NavigationManager Nav { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadNewPage(1);
    }

    private async Task LoadNewPage(int pageNumber)
    {
        var query = new PagingQuery(pageNumber, PageSize);
        var result = await ProductService.GetAsync(query);
        if (result.IsSuccess) _list = result.Value!;
    }

    private async Task DeleteProduct(int productId)
    {
        await ProductService.RemoveAsync(productId);
        await LoadNewPage(_list.Metadata.PageNumber);
    }
}