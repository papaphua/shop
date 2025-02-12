using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.CartItems;

public sealed class CartItemRepository(ApplicationDbContext dbContext)
    : Repository<CartItem, int>(dbContext), ICartItemRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}