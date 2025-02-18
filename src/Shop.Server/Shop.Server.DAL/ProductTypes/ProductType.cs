using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;

namespace Shop.Server.DAL.ProductTypes;

public sealed class ProductType : Entity<int>
{
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}