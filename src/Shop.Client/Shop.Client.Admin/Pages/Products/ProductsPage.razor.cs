using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Core;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages.Products;

public sealed partial class ProductsPage : ComponentBase
{
    private const int PageSize = 6;

    [Inject] public required IProductService ProductService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private PagedList<ProductDto> _list = new();
    private List<IDropDownOption> _types = [];
    private int? _selectedType;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _types = (await ProductService.GetProductTypesAsync())
            .Cast<IDropDownOption>()
            .ToList();

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