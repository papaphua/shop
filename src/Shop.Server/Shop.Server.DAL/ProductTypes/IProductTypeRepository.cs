using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.ProductTypes;

public interface IProductTypeRepository : IRepository<ProductType, int>
{
    Task<List<ProductType>> GetAllAsync();
}