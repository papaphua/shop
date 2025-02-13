using AutoMapper;
using Shop.Server.DAL.Core;
using Shop.Server.DAL.Products;
using Shop.Shared.Products;

namespace Shop.Server.BLL.Products;

public sealed class ProductService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IProductService
{
    
}