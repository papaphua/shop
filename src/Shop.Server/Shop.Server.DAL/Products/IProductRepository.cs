using Shop.Server.DAL.Core;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.DAL.Products;

public interface IProductRepository : IRepository<Product, int>
{
    Task<PagedList<Product>> GetAsync(PagingQuery? paging, string? productType);
}