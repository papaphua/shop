using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;
using Shop.Shared.ProductTypes;

namespace Shop.Client.Admin.Services.Interfaces;

public interface IProductService
{
    Task<ProductDto> GetByIdAsync(int id);

    Task<PagedList<ProductDto>> GetAsync(PagingQuery? query);

    Task CreateAsync(ProductDto dto);

    Task RemoveAsync(int id);

    Task UpdateAsync(int id, ProductDto dto);

    Task<List<ProductTypeDto>> GetProductTypesAsync();
}