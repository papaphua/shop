using Microsoft.EntityFrameworkCore;
using Shop.Server.DAL.Core;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.DAL.CartItems;

public sealed class CartItemRepository(ApplicationDbContext dbContext)
    : Repository<CartItem, int>(dbContext), ICartItemRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<PagedList<CartItem>> GetAsync(int userId, PagingQuery? paging)
    {
        var query = _dbContext.Set<CartItem>()
            .Include(item => item.Product)
            .Where(item => item.UserId == userId)
            .OrderBy(item => item.Product.Name);

        if (paging is { PageNumber: > 0, PageSize: > 0 })
            return await query.ToPagedListAsync(paging);

        return PagedList<CartItem>.CreateSinglePage(await query.ToListAsync());
    }

    public async Task<CartItem?> GetByIdsAsync(int userId, int productId)
    {
        return await _dbContext.Set<CartItem>()
            .FirstOrDefaultAsync(item => item.UserId == userId && item.ProductId == productId);
    }
}