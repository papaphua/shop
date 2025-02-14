using Shop.Server.BLL.Core.Results;
using Shop.Shared.Core.Pagination;
using Shop.Shared.Products;

namespace Shop.Server.BLL.Products;

public interface IProductService
{
    Task<Result<ProductDto>> GetByIdAsync(int id);
    
    Task<Result<PagedList<ProductDto>>> GetAsync(PagingQuery? query);

    Task<Result> CreateAsync(ProductDto dto);

    Task<Result> RemoveAsync(int id);

    Task<Result> UpdateAsync(int id, ProductDto dto);
}