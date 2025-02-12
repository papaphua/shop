using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.Products;

public sealed class ProductRepository(ApplicationDbContext dbContext)
    : Repository<Product, int>(dbContext), IProductRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}