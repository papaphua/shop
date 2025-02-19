using System.Net.Http.Json;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;
using Shop.Shared.ProductTypes;

namespace Shop.Client.Admin.Services;

public sealed class ProductService(HttpClient http) : IProductService
{
    public async Task<ProductDto> GetByIdAsync(int id)
    {
        return (await http.GetFromJsonAsync<ProductDto>($"api/product/{id}"))!;
    }

    public async Task<PagedList<ProductDto>> GetAsync(PagingQuery? query, string? productType = null)
    {
        var queryString = new System.Text.StringBuilder("?");

        if (query != null)
        {
            queryString.Append($"PageNumber={query.PageNumber}&PageSize={query.PageSize}");
        }

        if (productType != null)
        {
            if (query != null)
            {
                queryString.Append('&');
            }

            queryString.Append($"ProductType={productType}");
        }

        return (await http.GetFromJsonAsync<PagedList<ProductDto>>("api/product" + queryString))!;
    }

    public async Task CreateAsync(ProductDto dto)
    {
        await http.PostAsJsonAsync("api/product", dto);
    }

    public async Task RemoveAsync(int id)
    {
        await http.DeleteAsync($"api/product/{id}");
    }

    public async Task UpdateAsync(int id, ProductDto dto)
    {
        await http.PutAsJsonAsync($"api/product/{id}", dto);
    }

    public async Task<List<ProductTypeDto>> GetProductTypesAsync()
    {
        return (await http.GetFromJsonAsync<List<ProductTypeDto>>("api/product/types"))!;
    }
}