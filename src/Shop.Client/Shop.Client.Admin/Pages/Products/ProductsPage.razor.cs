using Microsoft.AspNetCore.Components;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Client.Admin.Pages.Products;

public partial class ProductsPage
{
    private const int PageSize = 6;

    [Inject] public required IProductService ProductService { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }

    private bool _isLoading;
    private PagedList<ProductDto> _list = new();
    private string? _selectedType;
    private List<string> _types = [];

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        StateHasChanged();

        _types = (await ProductService.GetProductTypesAsync())
            .Select(type => type.Name)
            .ToList();

        _isLoading = false;

        await LoadNewPageAsync(1);
    }

    private async Task LoadNewTypeAsync(string? type)
    {
        _selectedType = type;
        await LoadNewPageAsync(1);
    }

    private async Task LoadNewPageAsync(int pageNumber)
    {
        _isLoading = true;
        StateHasChanged();

        var query = new PagingQuery(pageNumber, PageSize);
        _list = await ProductService.GetAsync(query, _selectedType);

        _isLoading = false;
    }

    private async Task DeleteProduct(int productId)
    {
        await ProductService.RemoveAsync(productId);
        await LoadNewPageAsync(_list.Metadata.PageNumber);
    }
}