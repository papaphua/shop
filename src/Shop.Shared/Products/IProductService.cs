using Shop.Shared.Core.Pagination;
using Shop.Shared.Core.Results;

namespace Shop.Shared.Products;

public interface IProductService
{
    Task<Result<PagedList<ProductDto>>> GetAsync(PagingQuery? query);

    Task<Result> CreateAsync(ProductDto dto);

    Task<Result> RemoveAsync(int id);

    Task<Result> UpdateAsync(int id, ProductDto dto);
}