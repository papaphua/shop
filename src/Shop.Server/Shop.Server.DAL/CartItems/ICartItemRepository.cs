using Shop.Server.DAL.Core;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.DAL.CartItems;

public interface ICartItemRepository : IRepository<CartItem, int>
{
    Task<PagedList<CartItem>> GetAsync(int userId, PagingQuery? query);

    Task<CartItem?> GetByIdsAsync(int userId, int productId);
}