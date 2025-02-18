using Microsoft.EntityFrameworkCore;
using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.ProductTypes;

public sealed class ProductTypeRepository(ApplicationDbContext dbContext)
    : Repository<ProductType, int>(dbContext), IProductTypeRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;


    public async Task<List<ProductType>> GetAllAsync()
    {
        return await _dbContext.Set<ProductType>()
            .ToListAsync();
    }
}