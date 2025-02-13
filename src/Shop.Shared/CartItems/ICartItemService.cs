using Shop.Shared.Core.Pagination;
using Shop.Shared.Core.Results;

namespace Shop.Shared.CartItems;

public interface ICartItemService
{
    Task<Result<PagedList<CartItemDto>>> GetAsync(PagingQuery? query, int userId);

    Task<Result> AddAsync(int userId, int productId);

    Task<Result> RemoveAsync(int userId, int cartItemId);

    Task<Result> SetQuantityAsync(int userId, int cartItemId, int quantity);
};