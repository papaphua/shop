using System.Net.Http.Json;
using Shop.Client.Admin.Services.Interfaces;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;
using Shop.Shared.ProductTypes;

namespace Shop.Client.Admin.Services;

public sealed class ProductService(HttpClient http) : IProductService
{
    public Task<ProductDto> GetByIdAsync(int id)
    {
        return http.GetFromJsonAsync<ProductDto>($"api/product/{id}")!;
    }

    public Task<PagedList<ProductDto>> GetAsync(PagingQuery? query, string? productType = null)
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

        return http.GetFromJsonAsync<PagedList<ProductDto>>("api/product" + queryString)!;
    }

    public Task CreateAsync(ProductDto dto)
    {
        return http.PostAsJsonAsync("api/product", dto);
    }

    public Task RemoveAsync(int id)
    {
        return http.DeleteAsync($"api/product/{id}");
    }

    public Task UpdateAsync(int id, ProductDto dto)
    {
        return http.PutAsJsonAsync($"api/product/{id}", dto);
    }

    public Task<List<ProductTypeDto>> GetProductTypesAsync()
    {
        return http.GetFromJsonAsync<List<ProductTypeDto>>("api/product/types")!;
    }
}